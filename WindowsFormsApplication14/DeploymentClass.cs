using System;
using System.ComponentModel;
using System.Deployment.Application;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApplication14
{
    public class DeploymentClass
    {
        /////////////////////////////////////////////////////////////////////
        // Class used for manual updating of Clickonce deployed applications
        // TODO: Declare DeploymentClass in form Main function
        // TODO: Create CheckForUpdate button with onBackground = false;
        // TODO: UseCompatibleTextRendering on Loading Label
        // LIEK DIS:
        /*
        private void FrmMain() 
        {
            DeploymentClass dcl = new DeploymentClass();
            dcl.InitializeDeploymentClass(Update_Notice_Label, Version_Label, Loading_Screen_label,
                Whether_To_Start_On_System_Boot, Whether_To_Update_On_Start_Of_Application);
        }
        ***********************************************************************
        public DeploymentClass _dcl;
        private void link_CheckUpdate_Click(object sender, System.EventArgs e)
        {
            if (_dcl != null)
            {
                 this.Close();
                _dcl.UpdateApplicationAsync(false);
            } 
        }             
         */
        /////////////////////////////////////////////////////////////////////

        LinkLabel labelUpdate;
        LinkLabel labelVersion;
        System.Windows.Forms.Label labelLoading;
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        int timer_interval = 600000; //600 000 ms = 10 min
        string publisherName = "DBSV2"; // publisher
        string appName = "DBSV2"; //app name

        bool updateOnStart;
        public string deployVersion;
        public IWin32Window ownerForm = null;

        bool pendingUpdate = false;
        ApplicationDeployment deployment;

        public bool InitializeDeploymentClass(IWin32Window _ownerForm, LinkLabel _labelUpdate, LinkLabel _labelVersion, System.Windows.Forms.Label _labelLoading, bool _startOnBoot, bool _updateOnStart)
        {
            if (!ApplicationDeployment.IsNetworkDeployed)
            {
                return false;
            }

            if (_ownerForm != null)
            {
                ownerForm = _ownerForm;
            }

            deployment = ApplicationDeployment.CurrentDeployment;
            deployVersion = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();   

            if (_labelUpdate != null)
            {
                labelUpdate = _labelUpdate;
                labelUpdate.Click += new System.EventHandler(this.labelUpdate_Clicked);
                labelUpdate.Text = "Application is updated. Click to restart.";
                labelUpdate.Visible = false;
                labelUpdate.Enabled = true; 
            }

            if (_labelVersion != null)
            {
                labelVersion = _labelVersion;
                labelVersion.Click += new System.EventHandler(this.labelVersion_Clicked);
                labelVersion.Text = string.Format("Version {0}", ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(4));
                labelVersion.Visible = true;
                labelVersion.Enabled = true;
            }

            if (_labelLoading != null)
            {
                labelLoading = _labelLoading;
            }

            if (_startOnBoot)
            {
                string[] mystrings = new string[]
                {
@"@echo off
chcp 65001
IF EXIST ""%appdata%\Microsoft\Windows\Start Menu\Programs\" + publisherName + @"\" + appName + @".appref-ms"" (""%appdata%\Microsoft\Windows\Start Menu\Programs\" + publisherName + @"\" + appName + @".appref-ms"") ELSE (start /b """" cmd /c del ""%~f0""&exit /b)"
                };

                string fullPath = "%appdata%\\Microsoft\\Windows\\Start Menu\\Programs\\Startup\\" + appName + ".bat";

                //Expands the %appdata% path and writes the file to the Startup folder
                File.WriteAllLines(Environment.ExpandEnvironmentVariables(fullPath), mystrings);
            }

            if (_updateOnStart)
            {
                updateOnStart = _updateOnStart;
                UpdateApplicationAsync(false);
            }

            //timer
            timer.Interval = timer_interval;
            timer.Tick += new System.EventHandler(this.timer_Tick);
            timer.Enabled = true;

            return true;
        }

        public void timer_Tick(object sender, EventArgs e)
        {
            UpdateApplicationAsync(true);
        }

        public void UpdateApplicationAsync(bool _onBackground)
        {
            if (!ApplicationDeployment.IsNetworkDeployed)
            {
                // not ClickOnce deployed 
                labelLoading.Visible = false;
                return;
            }

            if (!CheckForInternetConnection())
            {
                labelLoading.Visible = false;
                //MetroFramework.MetroMessageBox.Show(ownerForm, "No internet connection found!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_onBackground)
            {
                labelLoading.Visible = true;
            }
            else
            {
                labelLoading.Visible = false;
            }


            // Why use the ThreadPool instead of CheckForUpdateAsync? 
            // Some network condition, e.g. Hotel or Guest Wi-Fi, can 
            // make ClickOnce throw internally in such a way the exception 
            // is tricky to catch. Instead, use CheckForUpdates (sync) 
            // and handle the exception directly.
            if (!CheckForUpdateAvailable())
            {
                labelLoading.Visible = false;
                return;
            }


            ThreadPool.QueueUserWorkItem(delegate
            {
                try
                {
                    if (deployment != null)
                    {
                        if (deployment.CheckForUpdate() && pendingUpdate != true)
                        {
                            pendingUpdate = true;
                            deployment.UpdateCompleted +=
                                new AsyncCompletedEventHandler(
                                    deployment_UpdateCompleted);
                            deployment.UpdateAsync();
                        }
                        else
                        {
                            updateOnStart = false;
                            labelLoading.Visible = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    labelLoading.Visible = false;
                    MessageBox.Show(ex.Source + "\n" + ex.StackTrace + "\n" + ex.Message);
                }
            });
        }

        private bool CheckForUpdateAvailable()
        {
            try
            {
                Uri updateLocation = ApplicationDeployment.CurrentDeployment.UpdateLocation;

                //Used to use the Clickonce API but we've uncovered a pretty serious bug which results in a COMException and the loss of ability
                //to check for updates. So until this is fixed, we're resorting to a very lo-fi way of checking for an update.

                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string manifestFile = webClient.DownloadString(updateLocation);

                //We have some garbage info from the file header, presumably because the file is a .application and not .xml
                //Just start from the start of the first tag
                int startOfXml = manifestFile.IndexOfAny(new[] {'<'});
                manifestFile = manifestFile.Substring(startOfXml);

                Version version;

                XmlDocument doc = new XmlDocument();

                //build the xml from the manifest
                doc.LoadXml(manifestFile);

                XmlNodeList nodesList = doc.GetElementsByTagName("assemblyIdentity");
                if (nodesList == null || nodesList.Count <= 0)
                {
                    throw new XmlException("Could not read the xml manifest file, which is required to check if an update is available.");
                }

                XmlNode theNode = nodesList[0];
                version = new Version(theNode.Attributes["version"].Value);

                if (version > ApplicationDeployment.CurrentDeployment.CurrentVersion)
                {
                    // update application
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public void deployment_UpdateCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                labelLoading.Visible = false;
                var ex = e.Error;
                MessageBox.Show(ex.Source + "\n" + ex.StackTrace + "\n" + ex.Message);
            }

            // Update installed, prompt the user to see if they'd like to restart now
            labelUpdate.Visible = true;

            if (updateOnStart)
            {
                Application.Restart();
            }

            updateOnStart = false;
            labelLoading.Visible = false;
        }

        public void labelUpdate_Clicked(object sender, EventArgs e)
        {
            Application.Restart();
        }

        public void labelVersion_Clicked(object sender, EventArgs e)
        {
            AboutForm about = new AboutForm();
            about._dcl = this;
            about.ShowDialog();
        }

        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new System.Net.WebClient())
                {
                    using (var stream = client.OpenRead("http://www.google.com"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
