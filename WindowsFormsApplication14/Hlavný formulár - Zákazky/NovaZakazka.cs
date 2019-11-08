using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication14
{
    public partial class NovaZakazka : Form
    {
        public NovaZakazka()
        {
            InitializeComponent();
            //center form 
            Rectangle rect = Screen.PrimaryScreen.WorkingArea;
            this.Top = (rect.Height / 2) - (this.Height / 2);
            this.Left = (rect.Width / 2) - (this.Width / 2);
        }

        private void UlozitZakazku_Click(object sender, EventArgs e)
        {
            if (CisloZakazky.Text == "") 
            {
                MessageBox.Show("Vyplňte prosím všetky bunky");
                return;
            }
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Vyplňte prosím všetky bunky");
                return;
            }
            try
            {
                string connectionString = Class1.dbs_nastavenia("DBS_connection_string");
                SqlConnection sqlConn = new SqlConnection(connectionString);
            SqlCommand sqlComm = new SqlCommand();
            sqlComm = sqlConn.CreateCommand();
            sqlComm.CommandText = @"INSERT INTO tblZakazky (CisloZakazky,ZakazkaVytvoril,ZakazkaVytvorilKedy,StavZakazky,Zakaznik,ZakazkaPoznamky,ZakaznickaObjednavka) VALUES (@CisloZakazky,@ZakazkaVytvoril,@ZakazkaVytvorilKedy,@StavZakazky,@Zakaznik,@ZakazkaPoznamky,@ZakaznickaObjednavka)";
            sqlComm.Parameters.Add(new SqlParameter("@CisloZakazky", SqlDbType.VarChar, 255)).Value = this.CisloZakazky.Text;
            sqlComm.Parameters.Add(new SqlParameter("@ZakazkaVytvoril", SqlDbType.VarChar, 255)).Value = this.ZakazkuVytvoril.Text;
            sqlComm.Parameters.Add(new SqlParameter("@ZakazkaVytvorilKedy", SqlDbType.DateTime, 0)).Value = this.VytvorilDna.Text;
            sqlComm.Parameters.Add(new SqlParameter("@StavZakazky", SqlDbType.NChar, 25)).Value = this.comboBox1.Text;
            sqlComm.Parameters.Add(new SqlParameter("@Zakaznik", SqlDbType.VarChar, 255)).Value = this.Zakaznik.Text;
            sqlComm.Parameters.Add(new SqlParameter("@ZakazkaPoznamky", SqlDbType.VarChar, 255)).Value = this.PoznamkyZakazky.Text;
            sqlComm.Parameters.Add(new SqlParameter("@ZakaznickaObjednavka", SqlDbType.VarChar, 255)).Value = this.ZakaznickaObjednavka.Text;
            sqlConn.Open();
            sqlComm.ExecuteNonQuery();
            sqlConn.Close();
            this.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }
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

        private void NovaZakazka_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'novaDBcsharpDataSet.tblZakazkyStav' table. You can move, or remove it, as needed.
            this.tblZakazkyStavTableAdapter.Fill(this.novaDBcsharpDataSet.tblZakazkyStav);
            // TODO: This line of code loads data into the 'novaDBcsharpDataSet.tblZakazkyStav' table. You can move, or remove it, as needed.



            //load data do combo stav
            using (SqlConnection conn = new SqlConnection(Class1.dbs_nastavenia("DBS_connection_string")))
            {

                string query = "SELECT StavZakazky FROM tblZakazkyStav ";
                SqlDataAdapter da3 = new SqlDataAdapter(query, conn);
                conn.Open();
                DataSet ds3 = new DataSet();
                da3.Fill(ds3, "tblZakazkyStav");
                comboBox1.DisplayMember = "StavZakazky";
                comboBox1.ValueMember = "StavZakazky";
                comboBox1.DataSource = ds3.Tables["tblZakazkyStav"];
                conn.Close();

            }

            VytvorilDna.Text = DateTime.Now.ToString();
            ZakazkuVytvoril.Text = Properties.Settings.Default.Login;
        }

        private void tblZakazkyStavBindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void novaDBcsharpDataSetBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void tblZakazkyStavBindingSource1_CurrentChanged_1(object sender, EventArgs e)
        {

        }

        private void NovaZakazka_FormClosing(object sender, FormClosingEventArgs e)
        {
            Zakazky f = (Zakazky)Application.OpenForms[0];
            f.tblZakazkyTableAdapter.Fill(f.novaDBcsharpDataSet.tblZakazky);
            f.tblObjednavkyTableAdapter.Fill(f.novaDBcsharpDataSet.tblObjednavky);
            Class1.set_sort_main_form();
        }

        private void CisloZakazky_Leave(object sender, EventArgs e)
        {

            string connectionString = Class1.dbs_nastavenia("DBS_connection_string");
            SqlConnection sqlConn = new SqlConnection(connectionString);
            SqlCommand sqlComm = new SqlCommand();
            sqlComm = sqlConn.CreateCommand();
            sqlComm.CommandText = @"SELECT COUNT (CisloZakazky) FROM tblZakazky WHERE CisloZakazky = '" + CisloZakazky.Text + "' ";
            sqlConn.Open();

            int temp = Convert.ToInt32(sqlComm.ExecuteScalar().ToString());
            if (temp > 0)
            {
                MessageBox.Show("Táto zákazka sa už nachádza v systéme, prosím zadajte inú zákazku");
                sqlConn.Close();
                this.CisloZakazky.Focus();
                return;
            }
            sqlComm.ExecuteNonQuery();
            sqlConn.Close();

            using (SqlConnection connection = new SqlConnection(Class1.dbs_nastavenia("ISYS_connection_string")))
            {
                SqlCommand command =
                new SqlCommand("select * FROM dbo.Zákazky WHERE ID='" + this.CisloZakazky.Text + "'", connection);
                connection.Open();

                SqlDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                    Zakaznik.Text = (read["Obchodné meno"].ToString());
                    ZakaznickaObjednavka.Text = (read["Objednávka"].ToString());
                    PoznamkyZakazky.Text = (read["DopytPoznámky"].ToString());
                }
                read.Close();

            }

            
        }

        private void tblZakazkyStavBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CisloZakazky_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
