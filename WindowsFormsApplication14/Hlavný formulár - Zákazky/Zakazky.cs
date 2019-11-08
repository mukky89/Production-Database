using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Rendering;
using System.Globalization;
using System.Reflection;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;

namespace WindowsFormsApplication14
{
    public partial class Zakazky : Form
    {
        private Command RibbonStateCommand;
        public Zakazky()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.buttonX.DataPropertyName = "CisloZakazky";
            this.buttonX.HeaderText = "Otvoriť";
            txtTeplota.Text = Class1.get_data_from_HMS().Item1;
            txtTlak.Text = Class1.get_data_from_HMS().Item2;
            txtVlhkost.Text = Class1.get_data_from_HMS().Item3;

            DeploymentClass dcl = new DeploymentClass();
            dcl.InitializeDeploymentClass(this, Update_Notice_Label, Version_Label, Loading_Screen_Label,
                false, true);
            this.gridObjednavky.FilterUseExtendedCustomDialog = true;
            this.gridObjednavky.PrimaryGrid.EnableColumnFiltering = true;
            this.gridObjednavky.PrimaryGrid.EnableFiltering = true;
            this.gridObjednavky.PrimaryGrid.EnableRowFiltering = true;
            #region textbox grid objednavky 
            GridPanel panel4 = gridObjednavky.PrimaryGrid;
            GridColumn column2 = panel4.Columns["StavObjednavky"];
            column2.EditorType = typeof(MyGridTextBoxXEditControl);
            MyGridTextBoxXEditControl mbc2 = column2.EditControl as MyGridTextBoxXEditControl;

            #endregion textbox grid objednavky 

            #region button open
            GridPanel panel3 = gridObjednavky.PrimaryGrid;
            GridColumn column = panel3.Columns["btnOpen"];
            column.EditorType = typeof(MyGridButtonXEditControl);
            MyGridButtonXEditControl mbc = column.EditControl as MyGridButtonXEditControl;
            mbc.Cursor = System.Windows.Forms.Cursors.Hand;

            #endregion button open

            
        }

        #region tlacidlo otvorit v objednavkach
        public class MyGridButtonXEditControl : GridButtonXEditControl
        {
            /// <summary>
            /// Constructor
            /// </summary>
            public MyGridButtonXEditControl()
            {
                // We want to be notified when the user clicks the button
                // so that we can change the underlying cell value to reflect
                // the mouse click.

                Click += MyGridButtonXEditControlClick;
            }

            #region InitializeContext

            /// <summary>
            /// Initializes the color table for the button
            /// </summary>
            /// <param name="cell"></param>
            /// <param name="style"></param>
            public override void
                InitializeContext(GridCell cell, CellVisualStyle style)
            {
                base.InitializeContext(cell, style);
                Text = "otvoriť";
            }

            #endregion
            #region MyGridButtonXEditControlClick

            /// <summary>
            /// Handles user clicks of the button
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            public void MyGridButtonXEditControlClick(object sender, EventArgs e)
            {

                Zakazky f = (Zakazky)Application.OpenForms[0];
                GridPanel panel = f.gridObjednavky.ActiveRow.GridPanel;

                GridRow row = panel.ActiveRow as GridRow;

                String Objednavka = Convert.ToString(row.Cells[3].Value);
                String formular = Convert.ToString(row.Cells[53].Value);
                int rework = Convert.ToInt32(row.Cells[4].Value);
                Properties.Settings.Default.Objednavka = Objednavka;
                Properties.Settings.Default.Snimac = formular;
                Properties.Settings.Default.rework = rework;
                Properties.Settings.Default.CisloZakazky = Convert.ToInt32(row.Cells[2].Value);
                Properties.Settings.Default.formulare_otvorenie = true;
                Properties.Settings.Default.Save();
                Form form_to_open = (Form)Assembly.GetExecutingAssembly().CreateInstance("WindowsFormsApplication14." + formular);
                Class1.open_form(form_to_open);

            }

            #endregion

        }
        #endregion tlacidlo otvorit v objednavkach


        public class MyGridTextBoxXEditControl : GridTextBoxXEditControl
        {
            /// <summary>
            /// Constructor
            /// </summary>
            public MyGridTextBoxXEditControl()
            {
                // We want to be notified when the user clicks the button
                // so that we can change the underlying cell value to reflect
                // the mouse click.

                // Click += MyGridButtonXEditControlClick;
            }

            #region InitializeContext

            /// <summary>
            /// Initializes the color table for the button
            /// </summary>
            /// <param name="cell"></param>
            /// <param name="style"></param>
            public override void
                InitializeContext(GridCell cell, CellVisualStyle style)
            {
                base.InitializeContext(cell, style);
                string hodnota = Convert.ToString(cell.Value);
                if (hodnota == "Rozpracované")
                {
                    style.TextColor = System.Drawing.Color.Black;
                    //style.Font = new Font(style.Font, FontStyle.Bold);
                    style.Background.Color1 = System.Drawing.Color.YellowGreen;
                }
                else if (hodnota == "Po výstupnej kontrole")
                    {
                    style.TextColor = System.Drawing.Color.Black;
                    //style.Font = new Font(style.Font, FontStyle.Bold);
                    style.Background.Color1 = System.Drawing.Color.LightSkyBlue;
                }
                else if (hodnota == "Ukončené")
                {
                    style.TextColor = System.Drawing.Color.Black;
                    //style.Font = new Font(style.Font, FontStyle.Bold);
                    style.Background.Color1 = System.Drawing.Color.WhiteSmoke;
                }
                else if (hodnota == "CHYBA")
                {
                    style.TextColor = System.Drawing.Color.Black;
                    style.Font = new Font(style.Font, FontStyle.Bold);
                    style.Background.Color1 = System.Drawing.Color.IndianRed;
                }

            }

            #endregion
            #region MyGridButtonXEditControlClick

            /// <summary>
            /// Handles user clicks of the button
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            public void MyGridButtonXEditControlClick(object sender, EventArgs e)
            {

                Konektorovanie f = (Konektorovanie)Application.OpenForms[1];
               // GridPanel panel = f.gridMaterialBom.ActiveRow.GridPanel;

               // GridRow row = panel.ActiveRow as GridRow;
                //string id_vymazat = Convert.ToString(row.Cells[1].Value);


            }

            #endregion

        }

        private void switchButtonItem1_Click(object sender, EventArgs e)
        {
            ribbonControl2.Expanded = RibbonStateCommand.Checked;
            RibbonStateCommand.Checked = !RibbonStateCommand.Checked;
        }



        private void Zakazky_Load(object sender, EventArgs e)
        {
            Properties.Settings.Default.formulare_otvorenie = false;
            Properties.Settings.Default.Login = "";
            Properties.Settings.Default.Save();
            this.tblSnimaceZoznamTableAdapter.Fill(this.novaDBcsharpDataSet.tblSnimaceZoznam);
            this.tblObjednavkyTableAdapter.Fill(this.novaDBcsharpDataSet.tblObjednavky);
            this.tblZakazkyTableAdapter.Fill(this.novaDBcsharpDataSet.tblZakazky);
            this.comboBoxItem2.ComboBoxEx.DataSource = this.tblSnimaceZoznamBindingSource;
            Class1.set_sort_main_form();
            Prihlásenie aa = new Prihlásenie();
            aa.ShowDialog();
        }

        private void buttonItem12_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["NovaZakazka"] as NovaZakazka != null)
                MessageBox.Show("Formulár nová zákazka je už otvorený");
            else
            {
                NovaZakazka NovaZakazka = new NovaZakazka();
                NovaZakazka.ShowDialog();
            }

        }

        private void gridZakazky_RowDoubleClick(object sender, DevComponents.DotNetBar.SuperGrid.GridRowDoubleClickEventArgs e)
        {
            DevComponents.DotNetBar.SuperGrid.GridRow selectedRow = (DevComponents.DotNetBar.SuperGrid.GridRow)e.GridRow;
            int cisloZakazky = Convert.ToInt32(selectedRow.Cells[1].Value);
            Properties.Settings.Default.CisloZakazky = cisloZakazky;
            Properties.Settings.Default.Save();
            if (System.Windows.Forms.Application.OpenForms["EditZakazky"] as EditZakazky != null)
                MessageBox.Show("Formulár úprava zákazky je už otvorený");
            else
            {

                EditZakazky EditZakazky = new EditZakazky();
                EditZakazky.ShowDialog();
            }

        }
        public bool formulare_otvorenie;

        private void btnOdhlasit_Click(object sender, EventArgs e)
        {
            Prihlásenie aa = new Prihlásenie();
            aa.ShowDialog();
        }

        private void buttonItem1_Click_1(object sender, EventArgs e)
        {
            Form form_to_open = (Form)Assembly.GetExecutingAssembly().CreateInstance("WindowsFormsApplication14." + comboBoxItem2.Text);
            Class1.open_form(form_to_open);
        }


        private void btnNovyUzivatel_Click(object sender, EventArgs e)
        {

            if (System.Windows.Forms.Application.OpenForms["NovyUzivatel"] as NovyUzivatel != null)
                MessageBox.Show("Formulár NovyUzivatel je už otvorený");
            else
            {
                NovyUzivatel NovyUzivatel = new NovyUzivatel();
                NovyUzivatel.ShowDialog();
            }
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {

            if (System.Windows.Forms.Application.OpenForms["Report_FBGS"] as NovyUzivatel != null)
                MessageBox.Show("Formulár FBGS report je už otvorený");
            else
            {
                FBGS_Report FBGS_Report = new FBGS_Report();
                FBGS_Report.ShowDialog();
            }
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["Rmax_values"] as Rmax_values != null)
                MessageBox.Show("Formulár FBGS report je už otvorený");
            else
            {
                Rmax_values Rmax_values = new Rmax_values();
                Rmax_values.ShowDialog();
            }
        }


        private void buttonItem4_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["Nastavenia"] as Nastavenia != null)
                MessageBox.Show("Formulár Nastavenia je už otvorený");
            else
            {
                Nastavenia Nastavenia = new Nastavenia();
                Nastavenia.ShowDialog();
            }
        }

        private void closeObj_Click(object sender, EventArgs e)
        {
            Class1.set_status_ukoncene(); // zmeny stavy objednavok, podla toho ako su ukoncene v isyse
            this.tblObjednavkyTableAdapter.Fill(this.novaDBcsharpDataSet.tblObjednavky);
        }
    }
}
