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

namespace WindowsFormsApplication14
{
    public partial class FBGS_Report : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
        public FBGS_Report()
        {
            InitializeComponent();
            //center form 
            System.Drawing.Rectangle rect = Screen.PrimaryScreen.WorkingArea;
            this.Top = (rect.Height / 2) - (this.Height / 2);
            this.Left = (rect.Width / 2) - (this.Width / 2);
        }



        private void ZavrietZakazku_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Naozaj chcete zavrieť okno? Všetky zmeny budú stratené!", "Zavrieť okno",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                     == DialogResult.Yes)
            {
                this.Close();

            }
        }

        private void CisloZakazky_Leave(object sender, EventArgs e)
        {
            List<string[]> data_io = new List<string[]>();
            data_io = GetImportedFileList(this.CisloZakazky.Text);
            int sheet_nr = 1;
            int pocet_riadkov = data_io.Count;


            if (pocet_riadkov > 16 && pocet_riadkov < 31)
            {
                sheet_nr = 2;
            }
            else if (pocet_riadkov > 32 && pocet_riadkov < 47)
            {
                sheet_nr = 3;
            }
            else if (pocet_riadkov > 48)
            {
                sheet_nr = 4;
            }

            for (int i = 0; i <= sheet_nr - 1; i++) //loop pre vytvorenie sheetov podla poctu objednavok
            {
                string filename_report_template = "Template_FBGS_report.xlsx";
                int sheet = i + 1;
                string rename_report_name = CisloZakazky.Text + "_" + getIOinformation(CisloZakazky.Text) + "_ControlCard" + "_sheet_" + sheet + ".xlsx";
                string sourcePath_report_template = @"\\syxfsx04\Group\Projekty\FOS&S\11_DATABASE\actual.database\Databáza\Kontrolne_karty_FBGS\Connectorisation\"; // zmenit po testoch na \\syxfsx04\Group\Projekty\FOS&S\11_DATABASE\actual.database\Databáza\Kontrolne_karty_FBGS\Connectorisation\
                string targetPath_report_template = @"\\syxfsx04\Group\Projekty\FOS&S\11_DATABASE\actual.database\Databáza\Kontrolne_karty_FBGS\Connectorisation\" + CisloZakazky.Text;

                // Use Path class to manipulate file and directory paths.
                string sourceFile = System.IO.Path.Combine(sourcePath_report_template, filename_report_template);
                string destFile = System.IO.Path.Combine(targetPath_report_template, rename_report_name);
                textBoxX1.Text = destFile;
                // To copy a folder's contents to a new location:
                // Create a new target folder, if necessary.
                if (!System.IO.Directory.Exists(targetPath_report_template))
                {
                    System.IO.Directory.CreateDirectory(targetPath_report_template);
                }
                // To copy a file to another location and 
                // overwrite the destination file if it already exists.
                System.IO.File.Copy(sourceFile, destFile, true);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // opens the folder in explorer
            Process.Start(textBoxX1.Text);
        }

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

        public static string getIOinformation(string zakazka)
        {
            string connectionString = Class1.dbs_nastavenia("DBS_connection_string");
            string zakaznickaobjednavka = "";
            using (SqlConnection connect = new SqlConnection(connectionString))
            {

                connect.Open();
                using (SqlCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"SELECT CisloZakazky,ZakaznickaObjednavka "
                                        + "FROM tblZakazky "
                                        + "WHERE CisloZakazky =" + zakazka;
                    fmd.CommandType = CommandType.Text;
                    SqlDataReader r = fmd.ExecuteReader();
                    while (r.Read())
                    {
                        if (r.IsDBNull(r.GetOrdinal("ZakaznickaObjednavka")))
                        {
                            MessageBox.Show("Tato zakazka sa nenachádza v systeme");
                            zakaznickaobjednavka = "";
                        }
                        else
                            zakaznickaobjednavka = (Convert.ToString(r["ZakaznickaObjednavka"]));


                    }
                }
            }
            return zakaznickaobjednavka;
        }


        public static List<string[]> GetImportedFileList(string zakazka)
        {
            List<string[]> objednavka = new List<string[]>();

            string connectionString = Class1.dbs_nastavenia("DBS_connection_string");
            using (SqlConnection connect = new SqlConnection(connectionString))
            {

                connect.Open();
                using (SqlCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"SELECT dbo.tblKonektorovanie.Objednavka, dbo.tblKonektorovanie.CisloZakazky, dbo.tblObjednavky.Product, dbo.tblObjednavky.LotVlakna, dbo.tblObjednavky.FBGSSN, dbo.tblObjednavky.zakaznicka_objednavka,"
                                        + "dbo.tblObjednavky.zakaznik, dbo.tblKonektorovanie.Rmax, dbo.tblKonektorovanie.SNRmin, dbo.tblKonektorovanie.Rmax_snrmin, dbo.tblKonektorovanie.result, dbo.tblKonektorovanie.SNRmin_nolabel,"
                                        + "dbo.tblKonektorovanie.Rmax_snrmin_nolabel, dbo.tblKonektorovanie.result_nolabel, dbo.tblKonektorovanie.RL_measured_nolabel, dbo.tblKonektorovanie.RL_measured, dbo.tblKonektorovanie.FBGnr "
                                        + "FROM dbo.tblKonektorovanie INNER JOIN "
                                        + "dbo.tblObjednavky ON dbo.tblKonektorovanie.Objednavka = dbo.tblObjednavky.SylexObjednavka "
                                        + "WHERE CisloZakazky ='" + zakazka + "' AND FBGnr=1 "
                                        + "ORDER BY Objednavka ASC";
                    fmd.CommandType = CommandType.Text;
                    SqlDataReader r = fmd.ExecuteReader();
                    while (r.Read())
                    {
                        string[] Array = new string[19];
                        double max_power = max_power_strana_so_stitkom(Convert.ToString(r["Objednavka"]));
                        double max_power_no_label = max_power_strana_bez_stitka(Convert.ToString(r["Objednavka"]));
                        Array[0] = (Convert.ToString(r["FBGnr"]));
                        Array[1] = (Convert.ToString(r["zakaznicka_objednavka"]));
                        Array[2] = (Convert.ToString(r["zakaznik"]));
                        Array[3] = (Convert.ToString(r["CisloZakazky"]));
                        Array[4] = (Convert.ToString(r["Product"]));
                        Array[5] = (Convert.ToString(r["Objednavka"]));
                        Array[6] = (Convert.ToString(r["FBGSSN"]));
                        Array[7] = (Convert.ToString(r["LotVlakna"]));
                        Array[8] = (Convert.ToString(Convert.ToString(max_power)));//strana so stitkom
                        Array[9] = (Convert.ToString(r["RL_measured"]));               //strana so stitkom
                        Array[10] = (Convert.ToString(r["Rmax"]));
                        Array[11] = (Convert.ToString(r["SNRmin"]));                    //strana so stitkom
                        Array[12] = (Convert.ToString(r["Rmax_snrmin"]));               //strana so stitkom
                        Array[13] = (Convert.ToString(r["result"]));                    //strana so stitkom
                        Array[14] = (Convert.ToString(Convert.ToString(max_power_no_label)));//strana bez stitka
                        Array[15] = (Convert.ToString(r["RL_measured_nolabel"]));      //strana bez stitka
                        Array[16] = (Convert.ToString(r["SNRmin_nolabel"]));           //strana bez stitka
                        Array[17] = (Convert.ToString(r["Rmax_snrmin_nolabel"]));      //strana bez stitka
                        Array[18] = (Convert.ToString(r["result_nolabel"]));           //strana bez stitka
                        objednavka.Add(Array);
                    }
                }
            }
            return objednavka;
        }
        private void GenerujReport_Click(object sender, EventArgs e)
        {
            List<string[]> data_io = new List<string[]>();
            data_io = GetImportedFileList(this.CisloZakazky.Text);


            int pocet_riadkov = data_io.Count;
#pragma warning disable CS0219 // Variable is assigned but its value is never used
            int sheet_nr = 1;
#pragma warning restore CS0219 // Variable is assigned but its value is never used
            if (pocet_riadkov > 16)
            {
                sheet_nr = 2;
            }
            else if (pocet_riadkov > 32)
            {
                sheet_nr = 3;
            }
            else if (pocet_riadkov > 48)
            {
                sheet_nr = 4;
            }

            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            SpreadsheetInfo.SetLicense("ETZW-AT28-33Q6-1HAS");



            string templateFile = textBoxX1.Text;
            string get_file_name_without_nr = templateFile.Substring(0, textBoxX1.Text.Length - 6);



            int riadok = 12;
            int pocet_objednavok = data_io.Count;

            string save_actual_file = get_file_name_without_nr + 1 + ".xlsx";
            for (int i = 0; i <= pocet_objednavok - 1; i++) //loop pre pocet objednavok
            {
                int sheet = 1;
                string file_name = "";

                if (i < 16)
                {
                    file_name = get_file_name_without_nr + sheet + ".xlsx";
                }

                if (i > 15 && i < 32)
                {
                    file_name = get_file_name_without_nr + 2 + ".xlsx";
                    if (i == 16) riadok = 12;
                    save_actual_file = get_file_name_without_nr + 2 + ".xlsx";
                }
                else if (i > 31 && i < 48)
                {
                    file_name = get_file_name_without_nr + 3 + ".xlsx";
                    if (i == 32) riadok = 12;
                    save_actual_file = get_file_name_without_nr + 3 + ".xlsx";
                }
                else if (i > 47)
                {
                    file_name = get_file_name_without_nr + 4 + ".xlsx";
                    if (i == 48) riadok = 12;
                    save_actual_file = get_file_name_without_nr + 4 + ".xlsx";
                }


                var templateExcel = ExcelFile.Load(file_name);
                var templateReportSheet = templateExcel.Worksheets[0];

                templateReportSheet.Cells["C" + riadok].Value = i + 1; //NR
                templateReportSheet.Cells["D" + riadok].Value = data_io[i][4]; //product
                templateReportSheet.Cells["AD" + riadok].Value = data_io[i][5]; //SX SN
                templateReportSheet.Cells["AN" + riadok].Value = data_io[i][6]; //FBGS SN
                templateReportSheet.Cells["AX" + riadok].Value = data_io[i][7]; //Fiber LOT
                templateReportSheet.Cells["BJ" + riadok].Value = data_io[i][8]; //Min power
                templateReportSheet.Cells["BQ" + riadok].Value = data_io[i][9]; //RL
                templateReportSheet.Cells["BW" + riadok].Value = data_io[i][10]; //rmax
                templateReportSheet.Cells["CB" + riadok].Value = data_io[i][11]; //snrmin
                templateReportSheet.Cells["CK" + riadok].Value = data_io[i][12]; //snrmin linear
                templateReportSheet.Cells["DC" + riadok].Value = data_io[i][14]; //min power
                templateReportSheet.Cells["DJ" + riadok].Value = data_io[i][15]; //RL
                templateReportSheet.Cells["DP" + riadok].Value = data_io[i][10]; //rmax
                templateReportSheet.Cells["DU" + riadok].Value = data_io[i][16]; //snrmin
                templateReportSheet.Cells["ED" + riadok].Value = data_io[i][17]; //snrmin linear
                                                                                 // i++;
                riadok = riadok + 4;


                templateExcel.Save(save_actual_file);


            }

            //templateExcel.Save(get_file_name_without_nr + 1 + ".xlsx");
            //templateExcel.Save(get_file_name_without_nr + 2 + ".xlsx");
            //templateExcel.Save(get_file_name_without_nr + 3 + ".xlsx");


            uint ExcelPID;
            GetWindowThreadProcessId(new IntPtr(app.Hwnd), out ExcelPID);

            if (ExcelPID > 0)
            {
                Process ExcelProc = Process.GetProcessById(Convert.ToInt32(ExcelPID));
                if (ExcelProc != null)
                {
                    ExcelProc.Kill();
                }
            }
        }
    }
}

