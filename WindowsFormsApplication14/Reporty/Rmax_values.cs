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
using System.Text.RegularExpressions;

namespace WindowsFormsApplication14
{
    public partial class Rmax_values : Form
    {
        public Rmax_values()
        {
            InitializeComponent();
            //center form 
            Rectangle rect = Screen.PrimaryScreen.WorkingArea;
            this.Top = (rect.Height / 2) - (this.Height / 2);
            this.Left = (rect.Width / 2) - (this.Width / 2);

            GridPanel panel = gridRmax.PrimaryGrid;
            GridMaskedTextBoxEditControl mtb = panel.Columns["rmax"].EditControl as GridMaskedTextBoxEditControl;
            mtb.Mask = "00.00";

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

                this.rmax_valuesTableAdapter.Update(this.novaDBcsharpDataSet.rmax_values);
                this.novaDBcsharpDataSet.rmax_values.AcceptChanges();

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
            // TODO: This line of code loads data into the 'novaDBcsharpDataSet.rmax_values' table. You can move, or remove it, as needed.
            this.rmax_valuesTableAdapter.Fill(this.novaDBcsharpDataSet.rmax_values);
            //superGridControl1.PrimaryGrid.Columns[1].ToggleSort();
            //superGridControl1.PrimaryGrid.Columns[1].ToggleSort();

        }

        private void superGridControl1_BeginEdit(object sender, DevComponents.DotNetBar.SuperGrid.GridEditEventArgs e)
        {
            var activerow = (DevComponents.DotNetBar.SuperGrid.GridRow)e.GridPanel.ActiveRow;
            activerow.Cells[2].Value = Class1.prihlasovacie_meno;
            activerow.Cells[3].Value = DateTime.Now.ToString();
        }

        private void btnInsertViac_Click_1(object sender, EventArgs e)
        {
            List<string> loty = new List<string>();
            List<string> rmaxy = new List<string>();

            string[] tempArray = richTextBoxExRmaxLot.Lines;
            for (int counter = 0; counter < tempArray.Length; counter++)
            {
                string[] line = tempArray[counter].Split(' ');
                loty.Add(line[0]);
                rmaxy.Add(line[1]);

                try
                {
                    string connectionString = Class1.dbs_nastavenia("DBS_connection_string");
                    SqlConnection sqlConn = new SqlConnection(connectionString);
                    SqlCommand sqlComm = new SqlCommand();
                    sqlComm = sqlConn.CreateCommand();
                    sqlComm.CommandText = @"INSERT INTO rmax_values (Lot,Rmax,kto,kedy) VALUES (@Lot,@Rmax,@kto,@kedy)";
                    sqlComm.Parameters.Add(new SqlParameter("@Lot", SqlDbType.NVarChar, 100)).Value = loty[counter];
                    sqlComm.Parameters.Add(new SqlParameter("@Rmax", SqlDbType.Decimal, 0)).Value = rmaxy[counter];
                    sqlComm.Parameters.Add(new SqlParameter("@kto", SqlDbType.NVarChar, 50)).Value = Class1.prihlasovacie_meno;
                    sqlComm.Parameters.Add(new SqlParameter("@kedy", SqlDbType.DateTime, 0)).Value = DateTime.Now.ToString();
                    sqlConn.Open();
                    sqlComm.ExecuteNonQuery();
                    sqlConn.Close();
                    txtLot.Text = "";
                    txtRmax.Text = "";
                    this.rmax_valuesTableAdapter.Fill(this.novaDBcsharpDataSet.rmax_values);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }


            }
        }

        private void btnInsertSingle_Click_1(object sender, EventArgs e)
        {
            try
            {
                string connectionString = Class1.dbs_nastavenia("DBS_connection_string");
                SqlConnection sqlConn = new SqlConnection(connectionString);
                SqlCommand sqlComm = new SqlCommand();
                sqlComm = sqlConn.CreateCommand();
                sqlComm.CommandText = @"INSERT INTO rmax_values (Lot,Rmax,kto,kedy) VALUES (@Lot,@Rmax,@kto,@kedy)";
                sqlComm.Parameters.Add(new SqlParameter("@Lot", SqlDbType.VarChar, 100)).Value = txtLot.Text;
                sqlComm.Parameters.Add(new SqlParameter("@Rmax", SqlDbType.Decimal, 4)).Value = Convert.ToDecimal(txtRmax.Text);
                sqlComm.Parameters.Add(new SqlParameter("@kto", SqlDbType.VarChar, 50)).Value = Class1.prihlasovacie_meno; ;
                sqlComm.Parameters.Add(new SqlParameter("@kedy", SqlDbType.DateTime, 0)).Value = DateTime.Now.ToString();
                sqlConn.Open();
                sqlComm.ExecuteNonQuery();
                sqlConn.Close();
                txtLot.Text = "";
                txtRmax.Text = "";
                this.rmax_valuesTableAdapter.Fill(this.novaDBcsharpDataSet.rmax_values);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
    }
}

