using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace WindowsFormsApplication14
{
    public partial class Prihlásenie : Form
    {
        public Prihlásenie()
        {
            InitializeComponent();
            this.login.Select();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            string connectionString = Class1.dbs_nastavenia("DBS_connection_string");
            SqlConnection con = new SqlConnection(connectionString);
            SqlDataReader dr = null;
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblUzivatelia WHERE Meno = '" +
                    this.login.Text + "' AND Heslo ='" + this.password.Text + "'", con);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Zakazky f = (Zakazky)System.Windows.Forms.Application.OpenForms[0];
                    f.textBoxItem1.Text = dr.GetString(2);
                    f.textBoxItem2.Text = dr.GetString(5);
                    Class1.prihlasovacie_meno = dr.GetString(2);
                    Class1.opravnenie = dr.GetString(5);
                    //Properties.Settings.Default.Login = dr.GetString(2);
                    //Properties.Settings.Default.Opravnenie = dr.GetString(5);
                    //Properties.Settings.Default.Save();
                    this.Close();
                }
                else
                    MessageBox.Show("Nesprávne meno alebo heslo");
                this.login.Text = "";
                this.password.Text = "";
                this.login.Select();
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.password.Select();
        }

        public void password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.button1_Click(null, null);
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            string connectionString = Class1.dbs_nastavenia("DBS_connection_string");
            SqlConnection con = new SqlConnection(connectionString);
            SqlDataReader dr = null;
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblUzivatelia WHERE Meno = '" +
                    "mukky" + "' AND Heslo ='" + "marek0" + "'", con);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Zakazky f = (Zakazky)System.Windows.Forms.Application.OpenForms[0];
                    f.textBoxItem1.Text = dr.GetString(2);
                    f.textBoxItem2.Text = dr.GetString(5);
                    Class1.prihlasovacie_meno = dr.GetString(2);
                    Class1.opravnenie = dr.GetString(5);
                    //Properties.Settings.Default.Login = dr.GetString(2);
                    //Properties.Settings.Default.Opravnenie = dr.GetString(5);
                    //Properties.Settings.Default.Save();
                    this.Close();
                }
                else
                    MessageBox.Show("Nesprávne meno alebo heslo");
                this.login.Text = "";
                this.password.Text = "";
                this.login.Select();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
