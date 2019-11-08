using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using System.Windows.Threading;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Globalization;
using System.Runtime.InteropServices;
using DevComponents.DotNetBar.Controls;

namespace WindowsFormsApplication14.UserControls
{

    public partial class OvladaciPanelObjednavkySF : UserControl
    {
        public OvladaciPanelObjednavkySF()
        {
            InitializeComponent();

        }



        private void comboBoxEx1_Leave(object sender, EventArgs e)
        {
            string objednavka = comboObjednavka.Text + "/" + PoradoveCislo.Text;
            string zakazka = Convert.ToString(Properties.Settings.Default.CisloZakazky);
            try
            {
                {
                    if (string.IsNullOrWhiteSpace(comboBoxEx1.Text))
                    {
                        MessageBox.Show("Zadajte najprv zákazku!");
                        return;
                    }
                    // nacitanie zakaznickeho kodu a zakaznika
                    Zakaznik.Text = Class1.get_zakaznik_zakaznickykod(comboBoxEx1.Text).Item1;
                    ZakObjednavka.Text = Class1.get_zakaznik_zakaznickykod(comboBoxEx1.Text).Item2;

                    txtObjVytvoril.Text = Class1.prihlasovacie_meno;
                    txtObjVytvorilKedy.Text = DateTime.Now.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            zakazka = comboBoxEx1.Text;

            Class1.update_grid_konektorovanie(ParentForm, true);
        }




        private void comboObjednavka_Enter(object sender, EventArgs e)
        {
            string objednavka = comboObjednavka.Text + "/" + PoradoveCislo.Text;
            string zakazka = Convert.ToString(Properties.Settings.Default.CisloZakazky);
            if (string.IsNullOrWhiteSpace(comboBoxEx1.Text))
            {
                MessageBox.Show("Musíš najprv vyplniť Zákazku");
                return;
            }

            //load data do objednavky combo
            using (SqlConnection conn = new SqlConnection(Class1.dbs_nastavenia("ISYS_connection_string")))
            {
                zakazka = comboBoxEx1.Text;
                string obj = comboObjednavka.Text;
                string query = "SELECT ID, IDZákazky,Popis,Množstvo FROM dbo.Výrobky WHERE IDZákazky=" + zakazka + " ORDER BY ID DESC";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                conn.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "Výrobky");
                comboObjednavka.DisplayMember = "ID";
                comboObjednavka.ValueMember = "ID";
                comboObjednavka.DropDownColumns = "ID,IDZákazky,Množstvo,Popis";
                comboObjednavka.DropDownColumnsHeaders = "Objednávka\r\nZákazka\r\nMnožstvo\r\nPopis";
                comboObjednavka.DataSource = ds.Tables["Výrobky"];
                conn.Close();
                comboObjednavka.Text = obj;
                if (string.IsNullOrWhiteSpace(comboObjednavka.Text))
                {
                    comboObjednavka.SelectedItem = null;
                }
            }
        }

        private void PoradoveCislo_Leave(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(comboBoxEx1.Text) || string.IsNullOrWhiteSpace(comboObjednavka.Text))
                {
                    MessageBox.Show("Zadajte najprv zákazku/objednávku!");
                    return;
                }

                if (Class1.order_exists(comboObjednavka.Text, PoradoveCislo.Text) == true)
                {

                    // Variable
                    string MessageBoxTitle = "Objednávka už existujee";
                    string MessageBoxContent = "Takáto objednávka už je v systéme, prosím zadajte inú objednávku alebo sa jedná o REWORK ? stláč áno pre rework";

                    DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        txtRework.Text = Convert.ToString(Class1.get_max_rework(comboObjednavka.Text + "/" + PoradoveCislo.Text) + 1);
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        return;
                    }

                }


                string objednavka = comboObjednavka.Text + "/" + PoradoveCislo.Text;
                string sub = objednavka.Substring(0, 6);

                //load pn and description from isys
                Class1.get_pn_and_desc_fiber_isys(comboObjednavka.Text);
                txtPNvlakna.Text = Class1.get_pn_and_desc_fiber_isys(comboObjednavka.Text).Item1;
                txtPopisVlakna.Text = Class1.get_pn_and_desc_fiber_isys(comboObjednavka.Text).Item2;


                using (SqlConnection connection = new SqlConnection(Class1.dbs_nastavenia("ISYS_connection_string"))) // ziskanie product name z isysu
                {
                    SqlCommand command =
                    new SqlCommand("SELECT Popis, KódMolex "
                                  + "FROM Výrobky "
                                  + "WHERE  (ID =" + sub + ")", connection);
                    connection.Open();

                    SqlDataReader read = command.ExecuteReader();

                    while (read.Read())
                    {
                        Produkt.Text = (read["Popis"].ToString());
                        SFSerialNumber.Text = (read["KódMolex"].ToString());
                    }
                    read.Close();

                }

                #region vlozenie zoznamu operacii

                string connectionString = Class1.dbs_nastavenia("DBS_connection_string");
                SqlConnection sqlConn = new SqlConnection(connectionString);
                SqlCommand sqlComm = new SqlCommand();


                #endregion vlozenie zoznamu operacii

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(comboObjednavka.Text))
                {
                    MessageBox.Show("Najprv zadaj Objednávku");
                    return;
                }
                if (string.IsNullOrWhiteSpace(comboBoxEx1.Text))
                {
                    MessageBox.Show("Najprv zadaj Zákazku");
                    return;
                }
                string connectionString = Class1.dbs_nastavenia("DBS_connection_string");
                SqlConnection sqlConn = new SqlConnection(connectionString);

                sqlConn.Open();
                SuperGridControl superGridControl1 = Parent.Parent.Controls.Find("superGridControl1", true).FirstOrDefault() as SuperGridControl;
                superGridControl1.PrimaryGrid.EnableFiltering = true;
                superGridControl1.PrimaryGrid.EnableColumnFiltering = true;
                superGridControl1.PrimaryGrid.EnableRowFiltering = true;
                superGridControl1.PrimaryGrid.Columns[1].EnableFiltering = Tbool.True;
                superGridControl1.PrimaryGrid.Columns[1].ShowPanelFilterExpr = Tbool.True;
                superGridControl1.PrimaryGrid.Columns[1].FilterExpr = "[CisloZakazky] = " + comboBoxEx1.Text + " & [Objednavka] = '" + comboObjednavka.Text + "/" + PoradoveCislo.Text + "' & [Rework] = " + txtRework.Text;

                Class1.update_grid_konektorovanie(ParentForm, true);
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(checkedListBox1.Text))
                {
                    MessageBox.Show("Musíš najprv vybrať kanál z ktorého chceš importovať namerané dáta");
                    return;
                }
                string table_ch = "";
                if (checkedListBox1.Text == "CH 1")
                {
                    table_ch = "channel1";
                }
                else if (checkedListBox1.Text == "CH 2")
                {
                    table_ch = "channel2";
                }
                else if (checkedListBox1.Text == "CH 3")
                {
                    table_ch = "channel3";
                }
                else if (checkedListBox1.Text == "CH 4")
                {
                    table_ch = "channel4";
                }

                string connectionString = Class1.dbs_nastavenia("DBS_connection_string");
                SqlConnection sqlConn = new SqlConnection(connectionString);
                SqlCommand sqlComm = new SqlCommand();
                sqlComm = sqlConn.CreateCommand();
                sqlComm.CommandText = @"SELECT COUNT (wavelength) FROM " + table_ch;
                sqlConn.Open();
                int pocet_peakov = Convert.ToInt32(sqlComm.ExecuteScalar().ToString());
                sqlConn.Close();

                sqlComm = sqlConn.CreateCommand();
                sqlComm.CommandText = @"SELECT * FROM " + table_ch;
                sqlConn.Open();
                SqlDataReader read = sqlComm.ExecuteReader();
                for (int i = 1; i <= pocet_peakov; i++)
                    while (read.Read())
                    {

                        {
                            SqlConnection sqlConn2 = new SqlConnection(connectionString);
                            SqlCommand sqlComm2 = new SqlCommand();
                            sqlComm2 = sqlConn2.CreateCommand();
                            sqlConn2.Open();
                            sqlComm2.CommandText = @"UPDATE tblKonektorovanie SET wl_measured=@wl_measured,pv_measured=@pv_measured WHERE Objednavka=@Objednavka AND FBGnr=@FBGnr";
                            sqlComm2.Parameters.AddWithValue("@Objednavka", comboObjednavka.Text + "/" + PoradoveCislo.Text);
                            sqlComm2.Parameters.AddWithValue("@FBGnr", i);
                            sqlComm2.Parameters.AddWithValue("@wl_measured", Convert.ToDouble(read["wavelength"]));
                            sqlComm2.Parameters.AddWithValue("@pv_measured", Convert.ToDouble(read["level"]));
                            sqlComm2.ExecuteNonQuery();
                            sqlConn2.Close();
                            i++;

                        }
                    }
                read.Close();


                Class1.update_grid_konektorovanie(ParentForm, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            Class1.update_grid_konektorovanie(ParentForm, false);
            try
            {
                if (string.IsNullOrWhiteSpace(checkedListBox1.Text))
                {
                    MessageBox.Show("Musíš najprv vybrať kanál z ktorého chceš importovať namerané dáta");
                    return;
                }
                string table_ch = "";
                if (checkedListBox1.Text == "CH 1")
                {
                    table_ch = "channel1";
                }
                else if (checkedListBox1.Text == "CH 2")
                {
                    table_ch = "channel2";
                }
                else if (checkedListBox1.Text == "CH 3")
                {
                    table_ch = "channel3";
                }
                else if (checkedListBox1.Text == "CH 4")
                {
                    table_ch = "channel4";
                }

                string connectionString = Class1.dbs_nastavenia("DBS_connection_string");
                SqlConnection sqlConn = new SqlConnection(connectionString);
                SqlCommand sqlComm = new SqlCommand();
                sqlComm = sqlConn.CreateCommand();
                sqlComm.CommandText = @"SELECT COUNT (wavelength) FROM " + table_ch;
                sqlConn.Open();
                int pocet_peakov = Convert.ToInt32(sqlComm.ExecuteScalar().ToString());
                sqlConn.Close();

                sqlComm = sqlConn.CreateCommand();
                sqlComm.CommandText = @"SELECT * FROM " + table_ch;
                sqlConn.Open();
                SqlDataReader read = sqlComm.ExecuteReader();
                for (int i = 1; i <= pocet_peakov; i++)
                    while (read.Read())
                    {

                        {
                            SqlConnection sqlConn2 = new SqlConnection(connectionString);
                            SqlCommand sqlComm2 = new SqlCommand();
                            sqlComm2 = sqlConn2.CreateCommand();
                            sqlConn2.Open();
                            sqlComm2.CommandText = @"UPDATE tblKonektorovanie SET wl_measured_nolabel=@wl_measured_nolabel,pv_measured_nolabel=@pv_measured_nolabel WHERE Objednavka=@Objednavka AND FBGnr=@FBGnr";
                            sqlComm2.Parameters.AddWithValue("@Objednavka", comboObjednavka.Text + "/" + PoradoveCislo.Text);
                            sqlComm2.Parameters.AddWithValue("@FBGnr", i);
                            sqlComm2.Parameters.AddWithValue("@wl_measured_nolabel", Convert.ToDouble(read["wavelength"]));
                            sqlComm2.Parameters.AddWithValue("@pv_measured_nolabel", Convert.ToDouble(read["level"]));
                            sqlComm2.ExecuteNonQuery();
                            sqlConn2.Close();
                            i++;

                        }
                    }
                read.Close();

                Class1.update_grid_konektorovanie(ParentForm, true);
                Class1.update_grid_konektorovanie(ParentForm, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OvladaciPanelObjednavkyNEW_Load(object sender, EventArgs e)
        {
            PoradoveCislo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            SFSerialNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            txtLotVlakna.UseCustomBackColor = true;
            txtLotVlakna.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            comboObjednavka.UseCustomBackColor = true;
            comboObjednavka.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            comboBoxEx1.UseCustomBackColor = true;
            comboBoxEx1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            #region load data do zakazky combo
            using (SqlConnection conn = new SqlConnection(Class1.dbs_nastavenia("ISYS_connection_string")))
            {
                string query = "SELECT ID, Status, Objednávka, [Obchodné meno], Špecifikácia, ObjednávkaZákZák FROM dbo.Zákazky WHERE (Špecifikácia LIKE '%FOS%') AND (Status = 3) ORDER BY ID DESC";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                conn.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "Zákazky");
                comboBoxEx1.DisplayMember = "ID";
                comboBoxEx1.ValueMember = "ID";
                comboBoxEx1.SelectedItem = null;
                comboBoxEx1.DropDownColumns = "ID,Objednávka,Obchodné meno";
                comboBoxEx1.DropDownColumnsHeaders = "Zákazka\r\nZák.Objednávka\r\nZákazník";
                comboBoxEx1.DataSource = ds.Tables["Zákazky"];
                conn.Close();

            }
            #endregion load data do zakazky combo
            #region load data do LOT combo
            using (SqlConnection conn = new SqlConnection(Class1.dbs_nastavenia("DBS_connection_string")))
            {
                string query = "SELECT LOT,rmax FROM rmax_values";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                conn.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "rmax_values");
                txtLotVlakna.DisplayMember = "LOT";
                txtLotVlakna.ValueMember = "LOT";
                txtLotVlakna.SelectedItem = null;
                txtLotVlakna.DropDownColumns = "LOT,rmax";
                txtLotVlakna.DropDownColumnsHeaders = "LOT\r\nrmax\r";
                txtLotVlakna.DataSource = ds.Tables["rmax_values"];
                conn.Close();
            }
            #endregion load data do LOT combo
            txtLotVlakna.SelectedItem = null;
            comboBoxEx1.SelectedItem = null;
        }

        private void comboObjednavka_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
