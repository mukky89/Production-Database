using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;
using Microsoft.Office.Interop.Excel;
using GemBox.Spreadsheet;
using System.Runtime.InteropServices;
using System.IO;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Net.Mime;
using DevComponents.DotNetBar.SuperGrid.Style;


namespace WindowsFormsApplication14
{
    public static class Class1
    {
        public static string prihlasovacie_meno { get; set; }
        public static string opravnenie { get; set; }

        public static double max_power_strana_so_stitkom(string sn)
        {
            string connectionString = Class1.dbs_nastavenia("DBS_connection_string");
            double max_hodnota = 0;
            using (SqlConnection connect = new SqlConnection(connectionString))
            {

                connect.Open();
                using (SqlCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"SELECT MIN(pv_measured_nolabel) AS power_min_nolabel, MIN(pv_measured) AS power_min_label "
                                        + "FROM dbo.tblKonektorovanie "
                                        + "WHERE Objednavka ='" + sn + "'";

                    fmd.CommandType = CommandType.Text;
                    SqlDataReader r = fmd.ExecuteReader();
                    while (r.Read())
                    {
                        if (r.IsDBNull(r.GetOrdinal("power_min_label")))
                            max_hodnota = 0;
                        else
                            max_hodnota = Convert.ToDouble(r["power_min_label"]);

                    }
                }
            }
            return max_hodnota;
        }
        public static double max_power_strana_bez_stitka(string sn)
        {
            string connectionString = Class1.dbs_nastavenia("DBS_connection_string");
            double max_hodnota = 0;
            using (SqlConnection connect = new SqlConnection(connectionString))
            {

                connect.Open();
                using (SqlCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"SELECT MIN(pv_measured_nolabel) AS power_min_nolabel, MIN(pv_measured) AS power_min_label "
                                        + "FROM dbo.tblKonektorovanie "
                                        + "WHERE Objednavka ='" + sn + "'";

                    fmd.CommandType = CommandType.Text;
                    SqlDataReader r = fmd.ExecuteReader();
                    while (r.Read())
                    {
                        if (r.IsDBNull(r.GetOrdinal("power_min_nolabel")))
                            max_hodnota = 0;
                        else
                            max_hodnota = Convert.ToDouble(r["power_min_nolabel"]);
                    }
                }
            }
            return max_hodnota;
        }

        public static void load_materials_to_zniceny_material(int io, string sn, int zakazka, int rework)
        {
            try
            {

                string connectionString = Class1.dbs_nastavenia("ISYS_connection_string");
                string connectionString2 = Class1.dbs_nastavenia("DBS_connection_string");
                SqlConnection sqlConn = new SqlConnection(connectionString);
                SqlCommand sqlComm = new SqlCommand();
                sqlComm = sqlConn.CreateCommand();
                sqlComm.CommandText = @"SELECT  ČíselníkMateriál.KódMateriálu, ČíselníkMateriál.Popis, VýrobkyMateriál.Množstvo, ČíselníkMateriál.MJ, ČíselníkMateriál.Skupina, " +
                 " Výrobky.IDZákazky AS Zákazka, Výrobky.ID AS Objednávka, SkladČíselníkMateriál.Mena, SkladČíselníkMateriál.CenaDodavateľa " +
                 "FROM Výrobky INNER JOIN VýrobkyMateriál ON Výrobky.ID = VýrobkyMateriál.IdVýrobku INNER JOIN ČíselníkMateriál ON VýrobkyMateriál.IdMateriálu = ČíselníkMateriál.ID INNER JOIN SkladČíselníkMateriál ON ČíselníkMateriál.KódMateriálu = SkladČíselníkMateriál.KódMateriálu " +
                 "WHERE Výrobky.ID=" + io;
                sqlConn.Open();
                SqlDataReader read = sqlComm.ExecuteReader();
                while (read.Read())
                {
                    {
                        SqlConnection sqlConn2 = new SqlConnection(connectionString2);
                        SqlCommand sqlComm2 = new SqlCommand();
                        sqlComm2 = sqlConn2.CreateCommand();
                        sqlConn2.Open();
                        sqlComm2.CommandText = @"INSERT INTO tblZnicenyMaterial (objednavka,PNmaterialu,PopisMaterialu,jednotka,Mnozstvo,zakazka,Cena,rework) VALUES (@objednavka,@PNmaterialu,@PopisMaterialu,@jednotka,@Mnozstvo,@zakazka,@Cena,@rework)";
                        sqlComm2.Parameters.Add(new SqlParameter("@objednavka", SqlDbType.VarChar, 15)).Value = sn;
                        sqlComm2.Parameters.Add(new SqlParameter("@zakazka", SqlDbType.Int, 10)).Value = zakazka;
                        sqlComm2.Parameters.Add(new SqlParameter("@PNmaterialu", Convert.ToInt32(read["KódMateriálu"])));
                        sqlComm2.Parameters.Add(new SqlParameter("@PopisMaterialu", read["Popis"]));
                        sqlComm2.Parameters.Add(new SqlParameter("@jednotka", read["MJ"]));
                        sqlComm2.Parameters.Add(new SqlParameter("@Mnozstvo", Convert.ToDecimal(read["Množstvo"])));
                        if (read.IsDBNull(read.GetOrdinal("CenaDodavateľa")))
                        {
                            sqlComm2.Parameters.Add(new SqlParameter("@Cena", DBNull.Value));
                        }
                        else
                        {
                            sqlComm2.Parameters.Add(new SqlParameter("@Cena", Convert.ToDecimal(read["CenaDodavateľa"])));
                        }

                        sqlComm2.Parameters.Add(new SqlParameter("@rework", SqlDbType.Int, 10)).Value = rework;
                        sqlComm2.ExecuteNonQuery();
                        sqlConn2.Close();
                    }
                }
                read.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void upload_screenshot_from_MOI(string objednavka, string poradove_cislo, string zakazka, int type, string rework, string zakaznicka_objednavka, System.Windows.Forms.TextBox TextBox)
        {
            string nazov_screenshotu = "";
            if (type == 1)
            {
                nazov_screenshotu = "spectrum_label.png";
            }
            else if (type == 2)
            {
                nazov_screenshotu = "wavelength_label.png";
            }
            else if (type == 3)
            {
                nazov_screenshotu = "spectrum_nolabel.png";
            }
            else if (type == 4)
            {
                nazov_screenshotu = "wavelength_nolabel.png";
            }

            string sourcePath_spectrum_label = "";
            string folder_path = dbs_nastavenia("path_screenshot_outgoing_control");
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            string cesta_dokumenty = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Micron Optics\Enlight\Data";
            dialog.InitialDirectory = cesta_dokumenty;
            dialog.IsFolderPicker = false;
            dialog.Filters.Add(new CommonFileDialogFilter("Image", ".bmp"));

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                sourcePath_spectrum_label = dialog.FileName;
                string fileName_spectrum_label = folder_path + zakazka + "_" + zakaznicka_objednavka.Replace("/", "_") + @"\" + objednavka + "_" + poradove_cislo + @"\" + objednavka + "_" + poradove_cislo + ".bmp";
                string targetPath_spectrum_label = folder_path + zakazka + "_" + zakaznicka_objednavka.Replace("/", "_") + @"\" + objednavka + "_" + poradove_cislo;
                string fileName_spectrum_label_convert = folder_path + zakazka + "_" + zakaznicka_objednavka.Replace("/", "_") + @"\" + objednavka + "_" + poradove_cislo + @"\" + objednavka + "_" + poradove_cislo + "_" + "_rework_" + rework + "_" + nazov_screenshotu;

                TextBox.Text = fileName_spectrum_label_convert;
                // Use Path class to manipulate file and directory paths.
                string sourceFile = System.IO.Path.Combine(sourcePath_spectrum_label);
                string destFile = System.IO.Path.Combine(targetPath_spectrum_label);
                string newFileName = System.IO.Path.Combine(fileName_spectrum_label);
                string fileConvert = System.IO.Path.Combine(fileName_spectrum_label_convert);
                // To copy a folder's contents to a new location:
                // Create a new target folder, if necessary.
                if (!System.IO.Directory.Exists(targetPath_spectrum_label))
                {
                    System.IO.Directory.CreateDirectory(targetPath_spectrum_label);
                }
                // To copy a file to another location and 
                // overwrite the destination file if it already exists.
                System.IO.File.Copy(sourceFile, newFileName, true);
                //if (System.IO.File.Exists(oldName))
                using (Image img = Image.FromFile(newFileName))
                {
                    img.Save(fileConvert, ImageFormat.Png);
                }
                System.IO.File.Delete(newFileName);
            }
        }
        public static void upload_snapshot_from_MOI(string objednavka, string poradove_cislo, string zakazka, int type, string rework, string zakaznicka_objednavka, System.Windows.Forms.TextBox TextBox)
        {
            string nazov_screenshotu = "";
            if (type == 1)
            {
                nazov_screenshotu = "snapshot_label.txt";
            }
            else if (type == 2)
            {
                nazov_screenshotu = "snapshot_nolabel.txt";
            }

            string folder_path = dbs_nastavenia("path_screenshot_outgoing_control");
            string sourcePath_spectrum_label = "";
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            string cesta_dokumenty = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Micron Optics\Enlight\Data";
            dialog.InitialDirectory = cesta_dokumenty;
            dialog.IsFolderPicker = false;
            dialog.Filters.Add(new CommonFileDialogFilter("Text File", ".txt"));
            //dialog.Filters.Add(new CommonFileDialogFilter("Image", ".bmp"));

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                sourcePath_spectrum_label = dialog.FileName;

                string fileName_spectrum_label = folder_path + zakazka + "_" + zakaznicka_objednavka.Replace("/", "_") + @"\" + objednavka + "_" + poradove_cislo + @"\" + objednavka + "_" + poradove_cislo + ".txt";
                string targetPath_spectrum_label = folder_path + zakazka + "_" + zakaznicka_objednavka.Replace("/", "_") + @"\" + objednavka + "_" + poradove_cislo;
                string fileName_spectrum_label_convert = folder_path + zakazka + "_" + zakaznicka_objednavka.Replace("/", "_") + @"\" + objednavka + "_" + poradove_cislo + @"\" + objednavka + "_" + poradove_cislo + "_" + "_rework_" + rework + "_" + nazov_screenshotu;

                TextBox.Text = fileName_spectrum_label_convert;
                // Use Path class to manipulate file and directory paths.
                string sourceFile = System.IO.Path.Combine(sourcePath_spectrum_label);
                string destFile = System.IO.Path.Combine(targetPath_spectrum_label);
                string newFileName = System.IO.Path.Combine(fileName_spectrum_label);
                string fileConvert = System.IO.Path.Combine(fileName_spectrum_label_convert);
                // To copy a folder's contents to a new location:
                // Create a new target folder, if necessary.
                if (!System.IO.Directory.Exists(targetPath_spectrum_label))
                {
                    System.IO.Directory.CreateDirectory(targetPath_spectrum_label);
                }
                // To copy a file to another location and 
                // overwrite the destination file if it already exists.
                System.IO.File.Copy(sourceFile, fileConvert, true);
                //System.IO.File.Delete(newFileName);

            }
        }
        public static void upload_screenshot_from_MOI_automatically(string objednavka, string poradove_cislo, string zakazka, int type, string rework, string zakaznicka_objednavka, System.Windows.Forms.TextBox TextBox, int poradie)
        {
            string nazov_screenshotu = "";
            if (type == 1)
            {
                nazov_screenshotu = "spectrum_label.png";
            }
            else if (type == 2)
            {
                nazov_screenshotu = "wavelength_label.png";
            }
            if (type == 3)
            {
                nazov_screenshotu = "spectrum_nolabel.png";
            }
            else if (type == 4)
            {
                nazov_screenshotu = "wavelength_nolabel.png";
            }

            string cesta_dokumenty = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Micron Optics\Enlight\Data";
            // Get the files
            DirectoryInfo info = new DirectoryInfo(cesta_dokumenty);
            FileInfo[] files = info.GetFiles("*.bmp");

            // Sort by creation-time descending 
            Array.Sort(files, delegate (FileInfo f1, FileInfo f2)
            {
                return f2.CreationTime.CompareTo(f1.CreationTime);
            });
            string sourcePath_spectrum_label = "";
            string folder_path = dbs_nastavenia("path_screenshot_outgoing_control");
            if (poradie == 1)
            {
                sourcePath_spectrum_label = cesta_dokumenty + @"\" + Convert.ToString(files.GetValue(1)); // for spectrum
            }
            else if (poradie == 2)
            {
                sourcePath_spectrum_label = cesta_dokumenty + @"\" + Convert.ToString(files.GetValue(0)); // for wl
            }

            string fileName_spectrum_label = folder_path + zakazka + "_" + zakaznicka_objednavka.Replace("/", "_") + @"\" + objednavka + "_" + poradove_cislo + @"\" + objednavka + "_" + poradove_cislo + ".bmp";
            string targetPath_spectrum_label = folder_path + zakazka + "_" + zakaznicka_objednavka.Replace("/", "_") + @"\" + objednavka + "_" + poradove_cislo;
            string fileName_spectrum_label_convert = folder_path + zakazka + "_" + zakaznicka_objednavka.Replace("/", "_") + @"\" + objednavka + "_" + poradove_cislo + @"\" + objednavka + "_" + poradove_cislo + "_" + "_rework_" + rework + "_" + nazov_screenshotu;

            TextBox.Text = fileName_spectrum_label_convert;
            // Use Path class to manipulate file and directory paths.
            string sourceFile = System.IO.Path.Combine(sourcePath_spectrum_label);
            string destFile = System.IO.Path.Combine(targetPath_spectrum_label);
            string newFileName = System.IO.Path.Combine(fileName_spectrum_label);
            string fileConvert = System.IO.Path.Combine(fileName_spectrum_label_convert);
            // To copy a folder's contents to a new location:
            // Create a new target folder, if necessary.
            if (!System.IO.Directory.Exists(targetPath_spectrum_label))
            {
                System.IO.Directory.CreateDirectory(targetPath_spectrum_label);
            }
            // To copy a file to another location and 
            // overwrite the destination file if it already exists.
            System.IO.File.Copy(sourceFile, newFileName, true);
            //if (System.IO.File.Exists(oldName))
            using (Image img = Image.FromFile(newFileName))
            {
                img.Save(fileConvert, ImageFormat.Png);
            }
            System.IO.File.Delete(newFileName);


        }

        public static void upload_snapshot_from_MOI_automatically(string objednavka, string poradove_cislo, string zakazka, int type, string rework, string zakaznicka_objednavka, System.Windows.Forms.TextBox TextBox)
        {
            string nazov_screenshotu = "";
            if (type == 1)
            {
                nazov_screenshotu = "snapshot_label.txt";
            }
            else if (type == 2)
            {
                nazov_screenshotu = "snapshot_nolabel.txt";
            }


            string cesta_dokumenty = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Micron Optics\Enlight\Data";
            DirectoryInfo info = new DirectoryInfo(cesta_dokumenty);
            FileInfo[] files2 = info.GetFiles("*.txt");

            // Sort by creation-time descending 
            Array.Sort(files2, delegate (FileInfo f1, FileInfo f2)
            {
                return f2.CreationTime.CompareTo(f1.CreationTime);
            });

            string folder_path = dbs_nastavenia("path_screenshot_outgoing_control");

            string sourcePath_spectrum_label = cesta_dokumenty + @"\" + Convert.ToString(files2.GetValue(0));
            string fileName_spectrum_label = folder_path + zakazka + "_" + zakaznicka_objednavka.Replace("/", "_") + @"\" + objednavka + "_" + poradove_cislo + @"\" + objednavka + "_" + poradove_cislo + ".txt";
            string targetPath_spectrum_label = folder_path + zakazka + "_" + zakaznicka_objednavka.Replace("/", "_") + @"\" + objednavka + "_" + poradove_cislo;
            string fileName_spectrum_label_convert = folder_path + zakazka + "_" + zakaznicka_objednavka.Replace("/", "_") + @"\" + objednavka + "_" + poradove_cislo + @"\" + objednavka + "_" + poradove_cislo + "_" + "_rework_" + rework + "_" + nazov_screenshotu;

            TextBox.Text = fileName_spectrum_label_convert;
            // Use Path class to manipulate file and directory paths.
            string sourceFile = System.IO.Path.Combine(sourcePath_spectrum_label);
            string destFile = System.IO.Path.Combine(targetPath_spectrum_label);
            string newFileName = System.IO.Path.Combine(fileName_spectrum_label);
            string fileConvert = System.IO.Path.Combine(fileName_spectrum_label_convert);
            // To copy a folder's contents to a new location:
            // Create a new target folder, if necessary.
            if (!System.IO.Directory.Exists(targetPath_spectrum_label))
            {
                System.IO.Directory.CreateDirectory(targetPath_spectrum_label);
            }
            // To copy a file to another location and 
            // overwrite the destination file if it already exists.
            System.IO.File.Copy(sourceFile, fileConvert, true);
            //System.IO.File.Delete(newFileName);

        }

        public static void delete_record(string objednavka, string poradove_cislo, string tabulka, System.Windows.Forms.Form Form, int rework)
        {
            if (MessageBox.Show("Naozaj chcete vymazať objednávku? všetko bude vymazané!", "DELETE",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                  == DialogResult.Yes)
                try
                {
                    string connectionString = Class1.dbs_nastavenia("DBS_connection_string");
                    SqlConnection sqlConn = new SqlConnection(connectionString);
                    SqlCommand sqlComm = new SqlCommand();
                    sqlComm = sqlConn.CreateCommand();
                    SqlCommand sqlCommDelete = new SqlCommand();
                    sqlCommDelete = sqlConn.CreateCommand();
                    sqlCommDelete.CommandText = @"DELETE FROM tblObjednavky WHERE SylexObjednavka = '" + objednavka + "/" + poradove_cislo + "' AND rework=" + rework;
                    sqlConn.Open();
                    sqlCommDelete.ExecuteNonQuery();
                    sqlCommDelete.CommandText = @"DELETE FROM " + tabulka + " WHERE Objednavka = '" + objednavka + "/" + poradove_cislo + "' AND rework=" + rework;
                    sqlCommDelete.ExecuteNonQuery();
                    sqlCommDelete.CommandText = @"DELETE FROM tblZnicenyMaterial WHERE objednavka = '" + objednavka + "/" + poradove_cislo + "' AND rework=" + rework;
                    sqlCommDelete.ExecuteNonQuery();
                    sqlConn.Close();
                    Form f1 = (Form)System.Windows.Forms.Application.OpenForms[1];
                    f1.Close();
                    Zakazky f = (Zakazky)System.Windows.Forms.Application.OpenForms[0];
                    f.tblZakazkyTableAdapter.Fill(f.novaDBcsharpDataSet.tblZakazky);
                    f.tblObjednavkyTableAdapter.Fill(f.novaDBcsharpDataSet.tblObjednavky);
                    Class1.set_sort_main_form();
                }
#pragma warning disable CS0168 // Variable is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // Variable is declared but never used
                {
                    MessageBox.Show("Error occured!");
                }
        }

        public static Tuple<string, string> get_pn_and_desc_fiber_isys(string objednavka)
        {

            using (SqlConnection connection = new SqlConnection(Class1.dbs_nastavenia("ISYS_connection_string"))) // ziskanie pn a popisu vlakna z isysu
            {


                SqlCommand command =
                new SqlCommand("SELECT ČíselníkMateriál.KódMateriálu, Výrobky.ID , ČíselníkMateriál.Popis "
                              + "FROM Výrobky INNER JOIN VýrobkyMateriál ON Výrobky.ID = VýrobkyMateriál.IdVýrobku INNER JOIN  ČíselníkMateriál ON VýrobkyMateriál.IdMateriálu = ČíselníkMateriál.ID "
                              + "WHERE  (Výrobky.ID =" + objednavka + ") AND (ČíselníkMateriál.Popis LIKE N'M;%' OR ČíselníkMateriál.Popis LIKE N'D;%' OR ČíselníkMateriál.Popis LIKE N'S;%'OR ČíselníkMateriál.Popis LIKE N'SG%')", connection);
                connection.Open();

                SqlDataReader read = command.ExecuteReader();

                string pn = "";
                string desc = "";

                while (read.Read())
                {
                    pn = (read["KódMateriálu"].ToString());
                    desc = (read["Popis"].ToString());
                }
                read.Close();
                var tuple = new Tuple<string, string>(pn, desc);
                return tuple;

            }


        }

        public static bool order_exists(string objednavka, string poradove_cislo)
        {
            string connectionString = Class1.dbs_nastavenia("DBS_connection_string"); //zisti ci uz existuje takato objednavka
            SqlConnection sqlConn = new SqlConnection(connectionString);
            SqlCommand sqlComm = new SqlCommand();
            sqlComm = sqlConn.CreateCommand();
            sqlComm.CommandText = @"SELECT COUNT (SylexObjednavka) FROM tblObjednavky WHERE SylexObjednavka = '" + objednavka + "/" + poradove_cislo + "' ";
            sqlConn.Open();

            int pocet_objednavok = Convert.ToInt32(sqlComm.ExecuteScalar().ToString());
            if (pocet_objednavok > 0)
            {
                sqlConn.Close();
                return true;
            }
            return false;
        }

        public static Tuple<string, string> get_zakaznik_zakaznickykod(string zakazka)
        {

            using (SqlConnection connection = new SqlConnection(Class1.dbs_nastavenia("ISYS_connection_string"))) // ziskanie pn a popisu vlakna z isysu
            {
                string connectionString = Class1.dbs_nastavenia("DBS_connection_string");
                SqlConnection sqlConn = new SqlConnection(connectionString);
                SqlCommand sqlComm = new SqlCommand();
                sqlComm = sqlConn.CreateCommand();
                sqlComm.CommandText = @"SELECT COUNT (CisloZakazky) FROM tblZakazky WHERE CisloZakazky = '" + zakazka + "' ";
                sqlConn.Open();

                int pocet_zakaziek = Convert.ToInt32(sqlComm.ExecuteScalar().ToString());
                string zakaznik = "";
                string zakobjednavka = "";
                if (pocet_zakaziek >= 0)
                {
                    #region nacitanie info o zakazke do objednavky
                    sqlComm.ExecuteNonQuery();
                    sqlConn.Close();

                    SqlCommand command =
                    new SqlCommand("select * FROM dbo.Zákazky WHERE ID='" + zakazka + "'", connection);
                    connection.Open();

                    SqlDataReader read = command.ExecuteReader();

                    while (read.Read())
                    {
                        zakaznik = (read["Obchodné meno"].ToString());
                        zakobjednavka = (read["Objednávka"].ToString());
                    }
                    read.Close();


                    #endregion
                }

                var tuple = new Tuple<string, string>(zakaznik, zakobjednavka);
                return tuple;

            }


        }
        public static Tuple<string, string> get_product_name_and_customer_order(string objednavka)
        {

            using (SqlConnection connection = new SqlConnection(Class1.dbs_nastavenia("ISYS_connection_string"))) // ziskanie product name z isysu
            {

                SqlCommand command =
                new SqlCommand("SELECT Popis, KódMolex "
                              + "FROM Výrobky "
                              + "WHERE  (ID =" + objednavka + ")", connection);
                connection.Open();

                SqlDataReader read = command.ExecuteReader();

                string produkt = "";
                string zakaznickaobj = "";

                while (read.Read())
                {

                    produkt = (read["Popis"].ToString());
                    zakaznickaobj = (read["KódMolex"].ToString());
                }
                read.Close();
                var tuple = new Tuple<string, string>(produkt, zakaznickaobj);
                return tuple;

            }



        }

        public static void set_sort_main_form()
        {
            Zakazky f = (Zakazky)System.Windows.Forms.Application.OpenForms[0];
            f.tblZakazkyTableAdapter.Fill(f.novaDBcsharpDataSet.tblZakazky);
            f.tblObjednavkyTableAdapter.Fill(f.novaDBcsharpDataSet.tblObjednavky);
            f.gridZakazky.PrimaryGrid.Columns[1].ToggleSort();
            f.gridZakazky.PrimaryGrid.Columns[1].ToggleSort();
            f.gridObjednavky.PrimaryGrid.Columns[3].ToggleSort();
            f.gridObjednavky.PrimaryGrid.Columns[3].ToggleSort();

            f.gridObjednavky.PrimaryGrid.EnableFiltering = true;
            f.gridObjednavky.PrimaryGrid.EnableColumnFiltering = true;
            f.gridObjednavky.PrimaryGrid.EnableRowFiltering = true;
            f.gridObjednavky.PrimaryGrid.Columns[1].EnableFiltering = Tbool.True;
            f.gridObjednavky.PrimaryGrid.Columns[1].ShowPanelFilterExpr = Tbool.True;
            f.gridObjednavky.PrimaryGrid.Columns[1].FilterExpr = "not ([Status] = 'Ukončené') & not ([Status] = 'CHYBA')";

        }

        public static Tuple<string, string, string> get_data_from_HMS()
        {
            string cesta = dbs_nastavenia("path_temperature_logger");

            // Get the files
            DirectoryInfo info = new DirectoryInfo(cesta);
            FileInfo[] files = info.GetFiles("*.txt");
            // Sort by creation-time descending 
            Array.Sort(files, delegate (FileInfo f1, FileInfo f2)
            {
                return f2.CreationTime.CompareTo(f1.CreationTime);
            });

            string subor = Convert.ToString(files.GetValue(0));

            string[] lines = File.ReadAllLines(cesta + subor, Encoding.UTF8);
            string[] split_temp = Regex.Split(Convert.ToString(lines[8]), ":");
            string[] split_pressure = Regex.Split(Convert.ToString(lines[2]), ":");

            string temperature = split_temp[1].Substring(0, 6).Replace(" ", string.Empty).Replace(".", ",");
            string pressure = split_pressure[1].Replace(" ", string.Empty).Replace(".", ",");
            string humidity = split_temp[2].Replace(" ", string.Empty).Replace(".", ",");

            var tuple = new Tuple<string, string, string>(temperature, pressure, humidity);
            return tuple;

        }

        public static int get_max_rework(string sn)
        {
            string connectionString = Class1.dbs_nastavenia("DBS_connection_string");
            int max_hodnota = 0;
            using (SqlConnection connect = new SqlConnection(connectionString))
            {

                connect.Open();
                using (SqlCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"SELECT MAX(Rework) AS max_rework "
                                        + "FROM dbo.tblObjednavky "
                                        + "WHERE SylexObjednavka ='" + sn + "'";

                    fmd.CommandType = CommandType.Text;
                    SqlDataReader r = fmd.ExecuteReader();
                    while (r.Read())
                    {
                        if (r.IsDBNull(r.GetOrdinal("max_rework")))
                            max_hodnota = 0;
                        else
                            max_hodnota = Convert.ToInt32(r["max_rework"]);
                    }
                }
            }
            return max_hodnota;
        }

        public static void send_message_chyba(string objednavka, string zakazka, string rework, string snimac, string odoslal, string sposobil, string celkovy_cas, string popis_chyby, string zakaznik)
        {
            try
            {

                Attachment inlineLogo = new Attachment(dbs_nastavenia("path_sylex_logo"));
                MailMessage message = new MailMessage();
                message.Attachments.Add(inlineLogo);
                string contentID = "Image";
                inlineLogo.ContentId = contentID;
                inlineLogo.ContentDisposition.Inline = true;
                inlineLogo.ContentDisposition.DispositionType = DispositionTypeNames.Inline;

                message.From = new MailAddress(dbs_nastavenia("email_from"));
                message.To.Add(dbs_nastavenia("email_to"));
                message.Subject = "DBSv2 - Chyba - SN: " + objednavka + " - Rework: " + rework + " - Snímač: " + snimac + " - Zákazník: " + zakaznik;
                message.IsBodyHtml = true;
                string Body = Properties.Resources.email_chyba;
                Body = Body.Replace("#Objednávka#", objednavka);
                Body = Body.Replace("#Zákazka#", zakazka);
                Body = Body.Replace("#Rework#", rework);
                Body = Body.Replace("#Snímač#", snimac);
                Body = Body.Replace("#Email odoslal#", odoslal);
                Body = Body.Replace("#Chybu spôsobil#", sposobil);
                Body = Body.Replace("#Celkový čas chyby#", celkovy_cas);
                Body = Body.Replace("#Popis chyby#", popis_chyby);
                Body = Body.Replace("#contentID#", contentID);

                #region load materials

                try
                {

                    string connectionString2 = Class1.dbs_nastavenia("DBS_connection_string");
                    SqlConnection sqlConn = new SqlConnection(connectionString2);
                    SqlCommand sqlComm = new SqlCommand();
                    sqlComm = sqlConn.CreateCommand();
                    sqlComm.CommandText = @"SELECT  id,objednavka,PNmaterialu,PopisMaterialu,jednotka,Mnozstvo,Cena,rework " +
                     "FROM tblZnicenyMaterial " +
                     "WHERE Objednavka='" + objednavka + "' AND rework=" + rework;
                    sqlConn.Open();
                    SqlDataReader read = sqlComm.ExecuteReader();
                    int pocet_mat = 1;
                    while (read.Read())
                    {

                        Body = Body +
                            "<tr>" +
                                "<td class='tg-b7b8'>" + pocet_mat + "</td>" +
                                "<td class='tg-b7b8'>" + read["PNmaterialu"] + "</td>" +
                                "<td class='tg-b7b8'>" + read["PopisMaterialu"] + "</td>" +
                                "<td class='tg-b7b8'>" + read["jednotka"] + "</td>" +
                                "<td class='tg-b7b8'>" + read["Mnozstvo"] + "</td>" +
                            "</tr>";

                        pocet_mat = pocet_mat + 1;
                    }

                    Body = Body + "</table>";
                    read.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                #endregion load materials

                message.Body = Body;
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Host = dbs_nastavenia("email_smtp_host");
                smtpClient.Port = 2525; //toto nie pre sylex
                smtpClient.Credentials = new System.Net.NetworkCredential(dbs_nastavenia("email_login"), dbs_nastavenia("email_password"));


                smtpClient.Send(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //nastavenia
        public static string dbs_nastavenia(string type)
        {
            bool debug = true; // ak debugujem tak TRUE 
            string connectionString = "";
            string tabulka = "";
            string hodnota = "";
            try
            {
                if (debug == true)
                {
                    connectionString = @"Data Source=DESKTOP-5K6HKKB;Initial Catalog=novaDBcsharp;User ID=mukky;Password=marek0";
                    tabulka = "tblNastavenia";
                    Properties.Settings.Default.novaDBcsharpConnectionString = @"Data Source=DESKTOP-5K6HKKB;Initial Catalog=novaDBcsharp;User ID=mukky;Password=marek0";
                    //Properties.Settings.Default.novaDBcsharpConnectionString1 = @"Data Source=DESKTOP-5K6HKKB;Initial Catalog=novaDBcsharp;User ID=mukky;Password=marek3005";
                    Properties.Settings.Default.ISYSconnectionstring = @"Data Source=DESKTOP-5K6HKKB;Initial Catalog=ISYS;User ID=mukky;Password=marek0";
                    Properties.Settings.Default.ISYSConnectionString1 = @"Data Source=DESKTOP-5K6HKKB;Initial Catalog=ISYS;User ID=mukky;Password=marek0";
                    Properties.Settings.Default.Save();
                }
                else
                {
                    connectionString = @"Data Source=SYXDBX02\ISYS;Initial Catalog=novaDBcsharp;User ID=peaklogger;Password=peaklogger123";
                    tabulka = "tblNastavenia";
                    Properties.Settings.Default.novaDBcsharpConnectionString = @"Data Source=SYXDBX02\ISYS;Initial Catalog=novaDBcsharp;User ID=peaklogger;Password=peaklogger123";
                    ///Properties.Settings.Default.novaDBcsharpConnectionString1 = @"Data Source=SYXDBX02\ISYS;Initial Catalog=novaDBcsharp;User ID=peaklogger;Password=peaklogger123";
                    Properties.Settings.Default.ISYSconnectionstring = @"Data Source=SYXDBX02\ISYS;Initial Catalog=ISYS;User ID=peaklogger;Password=peaklogger123";
                    Properties.Settings.Default.ISYSConnectionString1 = @"Data Source=SYXDBX02\ISYS;Initial Catalog=ISYS;User ID=peaklogger;Password=peaklogger123";
                    Properties.Settings.Default.Save();
                }

                using (SqlConnection connect = new SqlConnection(connectionString))
                {

                    connect.Open();
                    using (SqlCommand fmd = connect.CreateCommand())
                    {
                        fmd.CommandText = @"SELECT popis,hodnota "
                                            + "FROM " + tabulka + " "
                                            + "WHERE Popis ='" + type + "'";

                        fmd.CommandType = CommandType.Text;
                        SqlDataReader r = fmd.ExecuteReader();
                        while (r.Read())
                        {

                            hodnota = Convert.ToString(r["hodnota"]);

                        }

                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return hodnota;

        }
        //nastavenia
        public static int count_orders(string objednavka)
        {
            List<string> objednavky = new List<string>();

            Int32 count = 0;
            using (SqlConnection connect = new SqlConnection(Class1.dbs_nastavenia("DBS_connection_string")))
            {
                connect.Open();
                
                using (SqlCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"SELECT COUNT(*) "
                                        + "FROM tblObjednavky "
                                        + "WHERE SylexObjednavka LIKE '" + objednavka + "%'";

                    fmd.CommandType = CommandType.Text;
                    count = (Int32)fmd.ExecuteScalar();
                    
                }

            }
            return count;

        }

        public static List<string[]> get_objednavky_DBS_not_ukoncene()
        {
            List<string[]> objednavky = new List<string[]>();

            using (SqlConnection connect = new SqlConnection(Class1.dbs_nastavenia("DBS_connection_string")))
            {
                connect.Open();
                using (SqlCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"SELECT SylexObjednavka,StavObjednavky,rework "
                                        + "FROM tblObjednavky "
                                        + "WHERE StavObjednavky NOT LIKE '%Ukončené%'";

                    fmd.CommandType = CommandType.Text;
                    SqlDataReader r = fmd.ExecuteReader();
                    while (r.Read())
                    {
                        string[] Array = new string[3];
                        Array[0] = Convert.ToString((r["SylexObjednavka"]));
                        Array[1] = Convert.ToString((r["rework"]));
                        Array[2] = Convert.ToString((r["StavObjednavky"]));
                        objednavky.Add(Array);
                    }
                    return new List<string[]>(objednavky);
                }

            }


        }

        public static List<string[]> get_objednavky_ISYS_vyrobene()
        {
            //string SN = objednavka.Substring(0, 6);
            List<string[]> objednavky = new List<string[]>();

            using (SqlConnection connect = new SqlConnection(Class1.dbs_nastavenia("ISYS_connection_string")))
            {
                connect.Open();
                using (SqlCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"SELECT IdVýrobku,Množstvo,Dátum "
                                        + "FROM Výroba ";
                    //+ "WHERE IdVýrobku=" + Convert.ToInt32(SN);

                    fmd.CommandType = CommandType.Text;
                    SqlDataReader r = fmd.ExecuteReader();
                    while (r.Read())
                    {
                        string[] Array = new string[3];
                        Array[0] = Convert.ToString((r["IdVýrobku"]));
                        Array[1] = Convert.ToString((r["Množstvo"]));
                        Array[2] = Convert.ToString((r["Dátum"]));
                        objednavky.Add(Array);
                    }

                }

            }
            return objednavky;

        }

        public static void set_status_ukoncene()
        {

            List<string[]> objednavky_DBS = new List<string[]>();
            objednavky_DBS = Class1.get_objednavky_DBS_not_ukoncene();

            using (SqlConnection connect = new SqlConnection(Class1.dbs_nastavenia("DBS_connection_string")))
            {
                foreach (string[] dbs_objednavky in objednavky_DBS)
                {
                    int dbs_sn = Convert.ToInt32(dbs_objednavky[0].Substring(0, 6));

                    int objednavka_isys = Class1.get_sn_isys_vyrobene(dbs_sn).Item1;
                    DateTime datum_isys = Class1.get_sn_isys_vyrobene(dbs_sn).Item2;


                    if (objednavka_isys == dbs_sn)
                    {
                        string stav = "Ukončené";
                        if (dbs_objednavky[2] == "CHYBA")
                        {
                        }
                        else
                        {
                            stav = "Ukončené";
                        }
                        SqlCommand command = new SqlCommand();
                        command = connect.CreateCommand();
                        command.CommandText = @"UPDATE tblObjednavky SET StavObjednavky=@StavObjednavky,UkonceneKedy=@UkonceneKedy WHERE SylexObjednavka=@SylexObjednavka AND Rework=@Rework";
                        command.Parameters.AddWithValue("@StavObjednavky", stav);
                        string sn = dbs_objednavky[0];
                        string rework = dbs_objednavky[1];
                        command.Parameters.AddWithValue("@SylexObjednavka", "" + sn + "");
                        command.Parameters.AddWithValue("@Rework", rework);
                        command.Parameters.AddWithValue("@UkonceneKedy", datum_isys);
                        connect.Open();
                        command.ExecuteNonQuery();
                        connect.Close();
                    }


                }

            }

        }

        public static Tuple<int, DateTime> get_sn_isys_vyrobene(int sn)
        {
            string connectionString = Class1.dbs_nastavenia("ISYS_connection_string");
            int objednavka = 0;
            DateTime datum = DateTime.MinValue;

            using (SqlConnection connect = new SqlConnection(connectionString))
            {

                connect.Open();
                using (SqlCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"SELECT IdVýrobku,Množstvo,Dátum "
                                        + "FROM Výroba "
                                        + "WHERE IdVýrobku=" + Convert.ToInt32(sn);

                    fmd.CommandType = CommandType.Text;
                    SqlDataReader r = fmd.ExecuteReader();
                    while (r.Read())
                    {
                        if (r.IsDBNull(r.GetOrdinal("IdVýrobku")))
                            objednavka = 0;

                        else
                            objednavka = Convert.ToInt32(r["IdVýrobku"]);
                        datum = Convert.ToDateTime(r["Dátum"]);
                    }
                }
            }
            var tuple = new Tuple<int, DateTime>(objednavka, datum);
            return tuple;
        }

        public static void update_grid_konektorovanie(Form formular, bool fillorupdate)
        {
            #region update table podla formulara
            string formName = formular.Name;
            Formy form;
            Enum.TryParse(formName, out form);
            if (formName != null)
            {
                switch (form)
                {
                    case Formy.Konektorovanie:
                        Konektorovanie kon = formular as Konektorovanie;
                        if (fillorupdate)
                            kon.tblKonektorovanieTableAdapter.Fill(kon.novaDBcsharpDataSet.tblKonektorovanie);
                        else
                            kon.tblKonektorovanieTableAdapter.Update(kon.novaDBcsharpDataSet.tblKonektorovanie);
                        break;
                    default:
                        break;
                }
            }
            #endregion update table podla formulara
        }

        public static void update_grid_zniceny_material(Form formular,bool fillorupdate)
        {
            #region update table podla formulara
            string formName = formular.Name;
            Formy form;
            Enum.TryParse(formName, out form);
            if (formName != null)
            {
                switch (form)
                {
                    case Formy.Konektorovanie:
                        Konektorovanie kon = formular as Konektorovanie;
                        if (fillorupdate)
                        kon.zaznamChybMaterial.tblZnicenyMaterialTableAdapter.Fill(kon.zaznamChybMaterial.novaDBcsharpDataSet.tblZnicenyMaterial);
                        else
                        kon.zaznamChybMaterial.tblZnicenyMaterialTableAdapter.Update(kon.zaznamChybMaterial.novaDBcsharpDataSet.tblZnicenyMaterial);
                        break;
                    default:
                        break;
                }
            }
            #endregion update table podla formulara
        }

        public static void open_form(Form formular)
        {
            #region open form podla formulara
            string formName = formular.Name;
            Formy form;
            Enum.TryParse(formName, out form);
            if (formName != null)
            {
                switch (form)
                {
                    case Formy.Konektorovanie:
                        Konektorovanie kon = formular as Konektorovanie;
                        kon.ShowDialog();
                        break;
                    case Formy.SmartPatch:
                        SmartPatch kon2 = formular as SmartPatch;
                        kon2.ShowDialog();
                        break;
                    default:
                        break;
                }
            }
            #endregion open form podla formulara
        }

        public static String left(String input, int len)
        {
            return input.Substring(0, len);
        }

        public static String right(String input, int len)
        {
            return input.Substring(input.Length - len);
        }

        enum Formy
        {
            Konektorovanie,
            SmartPatch
        };

    }

}







