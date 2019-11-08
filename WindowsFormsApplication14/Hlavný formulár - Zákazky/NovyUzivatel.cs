using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevComponents.DotNetBar.SuperGrid;

namespace WindowsFormsApplication14
{
    public partial class NovyUzivatel : Form
    {
        public NovyUzivatel()
        {
            InitializeComponent();
            //center form 
            Rectangle rect = Screen.PrimaryScreen.WorkingArea;
            this.Top = (rect.Height / 2) - (this.Height / 2);
            this.Left = (rect.Width / 2) - (this.Width / 2);
        }

        private void UlozitZakazku_Click(object sender, EventArgs e)
        {
            foreach (DevComponents.DotNetBar.SuperGrid.GridRow row in superGridControl1.PrimaryGrid.Rows.Reverse().Skip(1).Reverse())
            {
                

                string connectionString = Class1.dbs_nastavenia("DBS_connection_string");
                SqlConnection sqlConn = new SqlConnection(connectionString);
                SqlCommand sqlCommKonektorovanie = new SqlCommand();
                sqlCommKonektorovanie = sqlConn.CreateCommand();
                sqlConn.Open();
                SqlCommand cmdCount = new SqlCommand("SELECT count(*) from tblUzivatelia WHERE IdUzivatela = @IdUzivatela", sqlConn);
                cmdCount.Parameters.AddWithValue("@IdUzivatela", row.Cells[0].Value);
                int count = (int)cmdCount.ExecuteScalar();

                if (count > 0)
                {
                    // UPDATE STATEMENT
                    sqlCommKonektorovanie.CommandText = @"UPDATE tblUzivatelia SET Skupina=@Skupina,Meno=@Meno,Heslo=@Heslo,Email=@Email,Opravnenie=@Opravnenie,Kto=@Kto,Kedy=@Kedy WHERE IdUzivatela=@IdUzivatela";
                }
                else
                {
                    // UPDATE STATEMENT
                    sqlCommKonektorovanie.CommandText = @"INSERT INTO tblUzivatelia (Skupina,Meno,Heslo,Email,Opravnenie,Kto,Kedy) VALUES (@Skupina,@Meno,@Heslo,@Email,@Opravnenie,@Kto,@Kedy)";
                    }
                sqlCommKonektorovanie.Parameters.AddWithValue("@IdUzivatela", row.Cells[0].Value);
               
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    switch (i)
                    {
                        case 1:
                            sqlCommKonektorovanie.Parameters.AddWithValue("@Skupina", row.Cells[i].Value);
                            break;
                        case 2:
                            sqlCommKonektorovanie.Parameters.AddWithValue("@Meno", row.Cells[i].Value);
                            break;
                        case 3:
                            sqlCommKonektorovanie.Parameters.AddWithValue("@Heslo", row.Cells[i].Value);
                            break;
                        case 4:
                            sqlCommKonektorovanie.Parameters.AddWithValue("@Email", row.Cells[i].Value);
                            break;
                        case 5:
                            sqlCommKonektorovanie.Parameters.AddWithValue("@Opravnenie", row.Cells[i].Value);
                            break;
                        case 6:
                            sqlCommKonektorovanie.Parameters.AddWithValue("@Kto", row.Cells[i].Value);
                            break;
                        case 7:
                            var outputParam = row.Cells[i].Value;
                            if (outputParam == DBNull.Value)
                            {
                                sqlCommKonektorovanie.Parameters.AddWithValue("@Kedy", "");
                            }
                            else
                            {
                                sqlCommKonektorovanie.Parameters.AddWithValue("@Kedy", Convert.ToDateTime(row.Cells[i].Value));
                            }
                            break;
                    }
                }
                sqlCommKonektorovanie.ExecuteNonQuery();
                sqlConn.Close();
            }



            Zakazky f = (Zakazky)Application.OpenForms[0];
            f.tblZakazkyTableAdapter.Fill(f.novaDBcsharpDataSet.tblZakazky);
            f.tblObjednavkyTableAdapter.Fill(f.novaDBcsharpDataSet.tblObjednavky);
            Class1.set_sort_main_form();
            this.Close();
        }

        private void ZavrietZakazku_Click(object sender, EventArgs e)
        {

            DialogResult dlgresult = MessageBox.Show("Naozaj chcete zavrieť okno? Všetky zmeny budú stratené!",
                             "Zavrieť okno",
                             MessageBoxButtons.YesNo,
                             MessageBoxIcon.Question);
            if (dlgresult == DialogResult.No)
            {

            }
            else
            {
                this.Close();
            }
        }

        private void NovaZakazka_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'novaDBcsharpDataSet.tblUzivatelia' table. You can move, or remove it, as needed.
            this.tblUzivateliaTableAdapter.Fill(this.novaDBcsharpDataSet.tblUzivatelia);
            // TODO: This line of code loads data into the 'novaDBcsharpDataSet.tblZakazkyStav' table. You can move, or remove it, as needed.
            this.tblZakazkyStavTableAdapter.Fill(this.novaDBcsharpDataSet.tblZakazkyStav);
            // TODO: This line of code loads data into the 'novaDBcsharpDataSet.tblZakazkyStav' table. You can move, or remove it, as needed.

        }


        private void NovaZakazka_FormClosing(object sender, FormClosingEventArgs e)
        {
            Zakazky f = (Zakazky)Application.OpenForms[0];
            f.tblZakazkyTableAdapter.Fill(f.novaDBcsharpDataSet.tblZakazky);
            f.tblObjednavkyTableAdapter.Fill(f.novaDBcsharpDataSet.tblObjednavky);
            Class1.set_sort_main_form();
        }

        private void superGridControl1_BeginEdit(object sender, GridEditEventArgs e)
        {
            var activerow = (DevComponents.DotNetBar.SuperGrid.GridRow)e.GridPanel.ActiveRow;
            activerow.Cells[6].Value = Class1.prihlasovacie_meno;
            activerow.Cells[7].Value = DateTime.Now.ToString();
        }
    }
}
