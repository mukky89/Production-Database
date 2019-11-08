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
    public partial class EditZakazky : Form
    {
        public EditZakazky()
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
            sqlComm.CommandText = @"UPDATE tblZakazky SET CisloZakazky=@CisloZakazky,ZakazkaVytvoril=@ZakazkaVytvoril,ZakazkaVytvorilKedy=@ZakazkaVytvorilKedy,StavZakazky=@StavZakazky,Zakaznik=@Zakaznik,ZakazkaPoznamky=@ZakazkaPoznamky,ZakaznickaObjednavka=@ZakaznickaObjednavka WHERE CisloZakazky=@CisloZakazky";
            sqlComm.Parameters.AddWithValue("@CisloZakazky", Properties.Settings.Default.CisloZakazky);
            sqlComm.Parameters.AddWithValue("@ZakazkaVytvoril", this.ZakazkuVytvoril.Text);
            sqlComm.Parameters.AddWithValue("@ZakazkaVytvorilKedy", Convert.ToDateTime(this.VytvorilDna.Text));
            sqlComm.Parameters.AddWithValue("@StavZakazky", this.comboBox1.Text);
            sqlComm.Parameters.AddWithValue("@Zakaznik", this.Zakaznik.Text);
            sqlComm.Parameters.AddWithValue("@ZakazkaPoznamky", this.PoznamkyZakazky.Text);
            sqlComm.Parameters.AddWithValue("@ZakaznickaObjednavka", this.ZakaznickaObjednavka.Text);
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

        private void EditZakazky_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'novaDBcsharpDataSet.tblZakazkyStav' table. You can move, or remove it, as needed.
            this.tblZakazkyStavTableAdapter.Fill(this.novaDBcsharpDataSet.tblZakazkyStav);
            // TODO: This line of code loads data into the 'novaDBcsharpDataSet.tblZakazkyStav' table. You can move, or remove it, as needed.



            using (SqlConnection connection = new SqlConnection(Class1.dbs_nastavenia("DBS_connection_string")))
            {
                SqlCommand command =
                new SqlCommand("select * FROM tblZakazky WHERE CisloZakazky='" + Properties.Settings.Default.CisloZakazky + "'", connection);
                connection.Open();

                SqlDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                    CisloZakazky.Text = (read["CisloZakazky"].ToString());
                    comboBox1.Text = (read["StavZakazky"].ToString());
                    ZakaznickaObjednavka.Text = (read["ZakaznickaObjednavka"].ToString());
                    Zakaznik.Text = (read["Zakaznik"].ToString());
                    VytvorilDna.Text = (read["ZakazkaVytvorilKedy"].ToString());
                    ZakazkuVytvoril.Text = (read["ZakazkaVytvoril"].ToString());
                    PoznamkyZakazky.Text = (read["ZakazkaPoznamky"].ToString());
                }
                read.Close();

            }



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

        private void EditZakazky_FormClosing(object sender, FormClosingEventArgs e)
        {
            Zakazky f = (Zakazky)Application.OpenForms[0];
            f.tblZakazkyTableAdapter.Fill(f.novaDBcsharpDataSet.tblZakazky);
            f.tblObjednavkyTableAdapter.Fill(f.novaDBcsharpDataSet.tblObjednavky);
            Class1.set_sort_main_form();
        }

        private void CisloZakazky_Leave(object sender, EventArgs e)
        {

        }

        private void tblZakazkyStavBindingSource_CurrentChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Naozaj chcete vymazať zákazku ?", "Zmazať záznam", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string connectionString = Class1.dbs_nastavenia("DBS_connection_string");
                SqlConnection sqlConn = new SqlConnection(connectionString);
                SqlCommand sqlComm = new SqlCommand();
                sqlComm = sqlConn.CreateCommand();
                sqlComm.CommandText = @"DELETE FROM tblZakazky WHERE CisloZakazky = " + CisloZakazky.Text + " ";
                sqlConn.Open();
                sqlComm.ExecuteNonQuery();
                sqlConn.Close();
                this.Close();
            }
            else if (dialogResult == DialogResult.No)
            {
                
            }

           
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            VytvorilDna.Text = DateTime.Now.ToString();
            ZakazkuVytvoril.Text = Properties.Settings.Default.Login;
        }
    }
}
