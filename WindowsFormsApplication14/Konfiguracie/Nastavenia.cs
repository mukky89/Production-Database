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
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;

namespace WindowsFormsApplication14
{
    public partial class Nastavenia : Form
    {
        public Nastavenia()
        {
            InitializeComponent();
            //center form 
            Rectangle rect = Screen.PrimaryScreen.WorkingArea;
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


        private void UlozitZakazku_Click(object sender, EventArgs e)
        {
            try
            {
                this.tblNastaveniaTableAdapter.Update(this.novaDBcsharpDataSet.tblNastavenia);
                this.novaDBcsharpDataSet.tblNastavenia.AcceptChanges();

                Zakazky f = (Zakazky)Application.OpenForms[0];
                f.tblZakazkyTableAdapter.Fill(f.novaDBcsharpDataSet.tblZakazky);
                f.tblObjednavkyTableAdapter.Fill(f.novaDBcsharpDataSet.tblObjednavky);
                Class1.set_sort_main_form();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();

        }

        private void ZavrietZakazku_Click_1(object sender, EventArgs e)
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

        private void Rmax_values_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'novaDBcsharpDataSet.tblNastavenia' table. You can move, or remove it, as needed.
            this.tblNastaveniaTableAdapter.Fill(this.novaDBcsharpDataSet.tblNastavenia);
            // TODO: This line of code loads data into the 'novaDBcsharpDataSet.rmax_values' table. You can move, or remove it, as needed.
            this.tblNastaveniaTableAdapter.Fill(this.novaDBcsharpDataSet.tblNastavenia);
            superGridControl1.PrimaryGrid.Columns[1].ToggleSort();
            superGridControl1.PrimaryGrid.Columns[1].ToggleSort();

        }

        private void superGridControl1_BeginEdit(object sender, DevComponents.DotNetBar.SuperGrid.GridEditEventArgs e)
        {
            var activerow = (DevComponents.DotNetBar.SuperGrid.GridRow)e.GridPanel.ActiveRow;
            activerow.Cells[3].Value = Class1.prihlasovacie_meno;
            activerow.Cells[4].Value = DateTime.Now.ToString();
        }

        private void labelX1_Click(object sender, EventArgs e)
        {

        }

        private void btnVlozitNastavenia_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = Class1.dbs_nastavenia("DBS_connection_string");
                SqlConnection sqlConn = new SqlConnection(connectionString);
                SqlCommand sqlComm = new SqlCommand();
                sqlComm = sqlConn.CreateCommand();
                sqlComm.CommandText = @"INSERT INTO tblNastavenia (Popis,Hodnota,kto,kedy) VALUES (@Popis,@Hodnota,@kto,@kedy)";
                sqlComm.Parameters.Add(new SqlParameter("@Popis", SqlDbType.VarChar, 255)).Value = txtPopis.Text;
                sqlComm.Parameters.Add(new SqlParameter("@Hodnota", SqlDbType.VarChar, 255)).Value = txtNastavenia.Text;
                sqlComm.Parameters.Add(new SqlParameter("@kto", SqlDbType.VarChar, 50)).Value = Class1.prihlasovacie_meno; ;
                sqlComm.Parameters.Add(new SqlParameter("@kedy", SqlDbType.DateTime, 0)).Value = DateTime.Now.ToString();
                sqlConn.Open();
                sqlComm.ExecuteNonQuery();
                sqlConn.Close();
                txtPopis.Text = "";
                txtNastavenia.Text = "";
                this.tblNastaveniaTableAdapter.Fill(this.novaDBcsharpDataSet.tblNastavenia);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
    }
}
