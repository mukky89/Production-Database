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




namespace WindowsFormsApplication14
{
    public partial class SmartPatch : Form
    {

        public SmartPatch()
        {

            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            #region maska pre bunky v tabulke
            GridPanel panel = superGridControl1.PrimaryGrid;
            GridMaskedTextBoxEditControl mtb = panel.Columns["Rmax"].EditControl as GridMaskedTextBoxEditControl;
            GridMaskedTextBoxEditControl mtb1 = panel.Columns["wl_measured"].EditControl as GridMaskedTextBoxEditControl;
            GridMaskedTextBoxEditControl mtb2 = panel.Columns["pv_measured"].EditControl as GridMaskedTextBoxEditControl;
            GridMaskedTextBoxEditControl mtb3 = panel.Columns["RL_measured"].EditControl as GridMaskedTextBoxEditControl;
            GridMaskedTextBoxEditControl mtb4 = panel.Columns["rozdiel_wl_pv"].EditControl as GridMaskedTextBoxEditControl;
            GridMaskedTextBoxEditControl mtb5 = panel.Columns["SNRmin"].EditControl as GridMaskedTextBoxEditControl;
            GridMaskedTextBoxEditControl mtb6 = panel.Columns["RMAX_snrmin"].EditControl as GridMaskedTextBoxEditControl;
            GridMaskedTextBoxEditControl mtb7 = panel.Columns["wl_measured_nolabel"].EditControl as GridMaskedTextBoxEditControl;
            GridMaskedTextBoxEditControl mtb8 = panel.Columns["pv_measured_nolabel"].EditControl as GridMaskedTextBoxEditControl;
            GridMaskedTextBoxEditControl mtb9 = panel.Columns["RL_measured_nolabel"].EditControl as GridMaskedTextBoxEditControl;
            GridMaskedTextBoxEditControl mtb10 = panel.Columns["rozdiel_wl_pv_nolabel"].EditControl as GridMaskedTextBoxEditControl;
            GridMaskedTextBoxEditControl mtb11 = panel.Columns["SNRmin_nolabel"].EditControl as GridMaskedTextBoxEditControl;
            GridMaskedTextBoxEditControl mtb12 = panel.Columns["RMAX_snrmin_nolabel"].EditControl as GridMaskedTextBoxEditControl;
            mtb.Mask = "00.00";
            mtb1.Mask = "0000.000";
            mtb2.Mask = "-00.00";
            mtb3.Mask = "-00.00";
            mtb4.Mask = "00.00";
            mtb5.Mask = "00.00";
            mtb6.Mask = "00000.000";
            mtb7.Mask = "0000.000";
            mtb8.Mask = "-00.00";
            mtb9.Mask = "-00.00";
            mtb10.Mask = "00.00";
            mtb11.Mask = "00.00";
            mtb12.Mask = "00000.000";
            #endregion maska pre bunky v tabulke

            this.comboBoxItem1.ComboBoxEx.DataSource = tblObjednavkyStavBindingSource;
            EnableMenuItem(GetSystemMenu(this.Handle, false), SC_CLOSE, MF_GRAYED); // disable X button
            #region textbox grid konektorovanie farba
            GridPanel panel4 = superGridControl1.PrimaryGrid;
            GridColumn column2 = panel4.Columns["result"];
            GridColumn column3 = panel4.Columns["result_nolabel"];
            column2.EditorType = typeof(MyGridTextBoxXEditControl);
            column3.EditorType = typeof(MyGridTextBoxXEditControl);
            MyGridTextBoxXEditControl mbc2 = column2.EditControl as MyGridTextBoxXEditControl;
            MyGridTextBoxXEditControl mbc3 = column3.EditControl as MyGridTextBoxXEditControl;

            #endregion textbox grid objednavky farba

            #region button grid material bom
            GridPanel panel3 =  zaznamChybMaterial.gridMaterialBom.PrimaryGrid;
            GridColumn column = panel3.Columns["DeleteBtn"];
            column.EditorType = typeof(MyGridButtonXEditControl);
            MyGridButtonXEditControl mbc = column.EditControl as MyGridButtonXEditControl;
            mbc.Cursor = System.Windows.Forms.Cursors.Hand;

            #endregion button grid material bom






            #region load data do combo status
            using (SqlConnection conn = new SqlConnection(Class1.dbs_nastavenia("DBS_connection_string")))
            {

                string query = "SELECT StavObjednavky FROM tblObjednavkyStav ";
                SqlDataAdapter da4 = new SqlDataAdapter(query, conn);
                conn.Open();
                DataSet ds4 = new DataSet();
                da4.Fill(ds4, "tblObjednavkyStav");
                ovladaciPanelFormulare1.comboBoxItem3.ComboBoxEx.DisplayMember = "StavObjednavky";
                ovladaciPanelFormulare1.comboBoxItem3.ComboBoxEx.ValueMember = "StavObjednavky";
                ovladaciPanelFormulare1.comboBoxItem3.ComboBoxEx.DropDownColumns = "StavObjednavky";
                ovladaciPanelFormulare1.comboBoxItem3.ComboBoxEx.DropDownColumnsHeaders = "StavObjednavky";
                ovladaciPanelFormulare1.comboBoxItem3.ComboBoxEx.DataSource = ds4.Tables["tblObjednavkyStav"];
                conn.Close();

            }
            #endregion load data do combo status



            #region spojenie stlpcov tabulka
            GridPanel panel2 = superGridControl1.PrimaryGrid;
            GridColumnCollection columns = panel2.Columns;
            panel2.ColumnHeader.GroupHeaders.Add(StranaSoStitkomMerge(columns));
            panel2.ColumnHeader.GroupHeaders.Add(StranaBezStitkaMerge(columns));
            #endregion spojenie stlpcov tabulka
        }

        #region Globals

        internal const int SC_CLOSE = 0xF060;           //close button's code in windows api
        internal const int MF_GRAYED = 0x1;             //disabled button status (enabled = false)
        internal const int MF_ENABLED = 0x00000000;     //enabled button status
        internal const int MF_DISABLED = 0x00000002;    //disabled button status

        [DllImport("user32.dll")] //Importing user32.dll for calling required function
        private static extern IntPtr GetSystemMenu(IntPtr HWNDValue, bool Revert);

        /// HWND: An IntPtr typed handler of the related form
        /// It is used from the Win API "user32.dll"

        [DllImport("user32.dll")] //Importing user32.dll for calling required function again
        private static extern int EnableMenuItem(IntPtr tMenu, int targetItem, int targetStatus);

        #endregion Globals //disable X button


        #region farba pre bunky v tabulke
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
                if (hodnota == "PASS")
                {
                    style.TextColor = System.Drawing.Color.Black;
                    //style.Font = new Font(style.Font, FontStyle.Bold);
                    style.Background.Color1 = System.Drawing.Color.YellowGreen;
                }
                else if (hodnota == "FAIL")
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
                GridPanel panel = f.zaznamChybMaterial.gridMaterialBom.ActiveRow.GridPanel;

                GridRow row = panel.ActiveRow as GridRow;
                string id_vymazat = Convert.ToString(row.Cells[1].Value);


            }

            #endregion

        }
        #endregion farba pre bunky v tabulke

        #region StranaSoStitkomMerge

        /// <summary>
        /// Creates and returns the 'Company Info' header
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        private ColumnGroupHeader StranaSoStitkomMerge(GridColumnCollection columns)
        {
            ColumnGroupHeader cgh = new ColumnGroupHeader();

            cgh.Name = "Strana so štítkom";

            // Set the header to not show the root column headers, and
            // perform some misc Style/display related setup.

            //cgh.ShowColumnHeaders = Tbool.False;
            cgh.MinRowHeight = 36;

            cgh.HeaderStyles.Default.Background = new Background(Color.LightGreen, Color.LightSeaGreen);
            cgh.HeaderStyles.MouseOver.Background = new Background(Color.LimeGreen, Color.ForestGreen);

            // Set the header's start and end Display Indecees

            cgh.StartDisplayIndex = GetDisplayIndex(columns, "wl_measured");
            cgh.EndDisplayIndex = GetDisplayIndex(columns, "result");

            return (cgh);
        }

        #endregion

        #region StranaBezStitkaMerge

        /// <summary>
        /// Creates and returns the 'Company Info' header
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        private ColumnGroupHeader StranaBezStitkaMerge(GridColumnCollection columns)
        {
            ColumnGroupHeader cgh = new ColumnGroupHeader();

            cgh.Name = "Strana bez štítka";

            // Set the header to not show the root column headers, and
            // perform some misc Style/display related setup.

            //cgh.ShowColumnHeaders = Tbool.False;
            cgh.MinRowHeight = 36;

            cgh.HeaderStyles.Default.Background = new Background(Color.LightBlue, Color.CadetBlue);
            cgh.HeaderStyles.MouseOver.Background = new Background(Color.CadetBlue, Color.LightBlue);

            // Set the header's start and end Display Indecees

            cgh.StartDisplayIndex = GetDisplayIndex(columns, "wl_measured_nolabel");
            cgh.EndDisplayIndex = GetDisplayIndex(columns, "result_nolabel");

            return (cgh);
        }

        #endregion

        #region GetDisplayIndex

        /// <summary>
        /// Gets the DisplayIndex for the column with the given name.
        /// </summary>
        /// <param name="columns"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private int GetDisplayIndex(GridColumnCollection columns, string name)
        {
            return (columns.GetDisplayIndex(columns[name]));
        }

        #endregion




        #region nastavenie tlacidla v grid BOM chyby
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
                Text = "Vymazať";
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

                SmartPatch f = (SmartPatch)Application.OpenForms[1];
                GridPanel panel = f.zaznamChybMaterial.gridMaterialBom.ActiveRow.GridPanel;

                GridRow row = panel.ActiveRow as GridRow;
                string id_vymazat = Convert.ToString(row.Cells[1].Value);

                string connectionString = Class1.dbs_nastavenia("DBS_connection_string");
                SqlConnection sqlConn = new SqlConnection(connectionString);
                SqlCommand sqlComm = new SqlCommand();
                sqlComm = sqlConn.CreateCommand();
                SqlCommand sqlCommDelete = new SqlCommand();
                sqlCommDelete = sqlConn.CreateCommand();
                sqlConn.Open();
                sqlCommDelete.CommandText = @"DELETE FROM tblZnicenyMaterial WHERE objednavka = '" + f.ovladaciPanelObjednavkySF1.comboObjednavka.Text + "/" + f.ovladaciPanelObjednavkySF1.PoradoveCislo.Text + "' AND id =" + id_vymazat;
                sqlCommDelete.ExecuteNonQuery();
                sqlConn.Close();

                f.zaznamChybMaterial.tblZnicenyMaterialTableAdapter.Fill(f.zaznamChybMaterial.novaDBcsharpDataSet.tblZnicenyMaterial);

            }

            #endregion

        }
        #endregion nastavenie tlacidla v grid BOM chyby



        public void Konektorovanie_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'novaDBcsharpDataSet.tblSmartPatch' table. You can move, or remove it, as needed.
            this.tblSmartPatchTableAdapter.Fill(this.novaDBcsharpDataSet.tblSmartPatch);
            // TODO: This line of code loads data into the 'novaDBcsharpDataSet.tblSnimaceZoznam' table. You can move, or remove it, as needed.
            this.tblSnimaceZoznamTableAdapter.Fill(this.novaDBcsharpDataSet.tblSnimaceZoznam);
            // TODO: This line of code loads data into the 'novaDBcsharpDataSet.tblUzivatelia' table. You can move, or remove it, as needed.
            this.tblUzivateliaTableAdapter.Fill(this.novaDBcsharpDataSet.tblUzivatelia);


            // TODO: This line of code loads data into the 'novaDBcsharpDataSet.tblZnicenyMaterial' table. You can move, or remove it, as needed.
            zaznamChybMaterial.tblZnicenyMaterialTableAdapter.Fill(zaznamChybMaterial.novaDBcsharpDataSet.tblZnicenyMaterial);

            // TODO: This line of code loads data into the 'novaDBcsharpDataSet.tblObjednavky' table. You can move, or remove it, as needed.
            this.tblObjednavkyTableAdapter.Fill(this.novaDBcsharpDataSet.tblObjednavky);
            try
            {

                #region load data do combo zniceny material
                using (SqlConnection conn = new SqlConnection(Class1.dbs_nastavenia("DBS_connection_string")))
                {

                    string query = "SELECT Meno FROM tblUzivatelia ";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    conn.Open();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "tblUzivatelia");
                    zaznamChyb.comboTree1.DisplayMember = "Meno";
                    zaznamChyb.comboTree1.ValueMember = "Meno";
                    zaznamChyb.comboTree1.DropDownColumns = "Meno";
                    zaznamChyb.comboTree1.DropDownColumnsHeaders = "Meno";
                    zaznamChyb.comboTree1.DataSource = ds.Tables["tblUzivatelia"];
                    SqlDataAdapter da2 = new SqlDataAdapter(query, conn);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2, "tblUzivatelia");
                    zaznamChyb.comboTree2.DisplayMember = "Meno";
                    zaznamChyb.comboTree2.ValueMember = "Meno";
                    zaznamChyb.comboTree2.DropDownColumns = "Meno";
                    zaznamChyb.comboTree2.DropDownColumnsHeaders = "Meno";
                    zaznamChyb.comboTree2.DataSource = ds2.Tables["tblUzivatelia"];
                    conn.Close();
                    zaznamChyb.comboTree1.SelectedItem = null;
                    zaznamChyb.comboTree2.SelectedItem = null;
                }
                #endregion load data do combo zniceny material


                #region load data do combo snimac
                using (SqlConnection conn = new SqlConnection(Class1.dbs_nastavenia("DBS_connection_string")))
                {

                    string query = "SELECT TypSnimaca FROM tblSnimaceZoznam ";
                    SqlDataAdapter da3 = new SqlDataAdapter(query, conn);
                    conn.Open();
                    DataSet ds3 = new DataSet();
                    da3.Fill(ds3, "tblSnimaceZoznam");
                    ovladaciPanelFormulare1.textBoxItem2.ComboBoxEx.DisplayMember = "TypSnimaca";
                    ovladaciPanelFormulare1.textBoxItem2.ComboBoxEx.ValueMember = "TypSnimaca";
                    ovladaciPanelFormulare1.textBoxItem2.ComboBoxEx.DropDownColumns = "TypSnimaca";
                    ovladaciPanelFormulare1.textBoxItem2.ComboBoxEx.DropDownColumnsHeaders = "TypSnimaca";
                    ovladaciPanelFormulare1.textBoxItem2.ComboBoxEx.DataSource = ds3.Tables["tblSnimaceZoznam"];
                    conn.Close();

                }
                #endregion load data do combo snimac

                this.tblObjednavkyStavTableAdapter.Fill(this.novaDBcsharpDataSet.tblObjednavkyStav);
                this.tblKonektorovanieTableAdapter.Fill(this.novaDBcsharpDataSet.tblKonektorovanie);

                this.superGridControl1.PrimaryGrid.EnableFiltering = true;
                superGridControl1.PrimaryGrid.EnableColumnFiltering = true;
                superGridControl1.PrimaryGrid.EnableRowFiltering = true;
                superGridControl1.PrimaryGrid.Columns[1].EnableFiltering = Tbool.True;
                superGridControl1.PrimaryGrid.Columns[1].ShowPanelFilterExpr = Tbool.True;
                zaznamChybMaterial.gridMaterialBom.PrimaryGrid.EnableFiltering = true;
                zaznamChybMaterial.gridMaterialBom.PrimaryGrid.EnableColumnFiltering = true;
                zaznamChybMaterial.gridMaterialBom.PrimaryGrid.EnableRowFiltering = true;
                zaznamChybMaterial.gridMaterialBom.PrimaryGrid.Columns[1].EnableFiltering = Tbool.True;
                zaznamChybMaterial.gridMaterialBom.PrimaryGrid.Columns[1].ShowPanelFilterExpr = Tbool.True;

                if (Properties.Settings.Default.formulare_otvorenie == true)
                {
                    zakazka = Convert.ToString(Properties.Settings.Default.CisloZakazky);
                    superGridControl1.PrimaryGrid.Columns[1].FilterExpr = "[Objednavka] = '" + Properties.Settings.Default.Objednavka + "' & [Rework] = " + Properties.Settings.Default.rework; //tabulka konektorovanie
                    zaznamChybMaterial.gridMaterialBom.PrimaryGrid.Columns[1].FilterExpr = "[objednavka] = '" + Properties.Settings.Default.Objednavka + "' & [Rework] = " + Properties.Settings.Default.rework; //tabulka bom
                    using (SqlConnection connection = new SqlConnection(Class1.dbs_nastavenia("DBS_connection_string")))
                    {
                        SqlCommand command =
                        new SqlCommand("select * FROM tblObjednavky WHERE SylexObjednavka='" + Properties.Settings.Default.Objednavka + "' AND Rework=" + Properties.Settings.Default.rework, connection);
                        connection.Open();

                        SqlDataReader read = command.ExecuteReader();

                        while (read.Read())
                        {
                            ovladaciPanelObjednavkySF1.comboObjednavka.Text = Class1.left((read["SylexObjednavka"].ToString()), 6);
                            ovladaciPanelObjednavkySF1.PoradoveCislo.Text = Class1.right((read["SylexObjednavka"].ToString()), 4);
                            ovladaciPanelObjednavkySF1.comboBoxEx1.Text = (read["Zakazka"].ToString());
                            ovladaciPanelFormulare1.comboBoxItem4.Text = (read["Formular"].ToString());
                            ovladaciPanelFormulare1.textBoxItem2.Text = (read["Snimac"].ToString());
                            ovladaciPanelObjednavkySF1.txtPNvlakna.Text = (read["PnVlakna"].ToString());
                            ovladaciPanelObjednavkySF1.txtLotVlakna.Text = (read["LotVlakna"].ToString());
                            ovladaciPanelObjednavkySF1.txtObjVytvoril.Text = (read["ObjVytvoril"].ToString());
                            ovladaciPanelObjednavkySF1.txtObjVytvorilKedy.Text = (read["ObjVytvorilDatum"].ToString());
                            ovladaciPanelObjednavkySF1.txtPopisVlakna.Text = (read["PopisVlakna"].ToString());
                            ovladaciPanelObjednavkySF1.txtRework.Text = (read["Rework"].ToString());
                            ovladaciPanelFormulare1.comboBoxItem3.Text = (read["StavObjednavky"].ToString());
                            ovladaciPanelObjednavkySF1.SFSerialNumber.Text = (read["FBGSSN"].ToString());
                            vystupnaKontrolaScr1.txtScrSpektrumVystupStitok.Text = (read["spektrum_label"].ToString());
                            vystupnaKontrolaScr1.txtScrVlVystupStitok.Text = (read["vl_label"].ToString());
                            vystupnaKontrolaScr1.txtScrSnapshotVystupStitok.Text = (read["snapshot_label"].ToString());
                            vystupnaKontrolaScr1.txtScrSpektrumVystupBezStitok.Text = (read["spektrum_nolabel"].ToString());
                            vystupnaKontrolaScr1.txtScrVlVystupBezStitok.Text = (read["vl_nolabel"].ToString());
                            vystupnaKontrolaScr1.txtScrSnapshotVystupBezStitok.Text = (read["snapshot_nolabel"].ToString());
                            vystupnaKontrolaScr1.txtVlhkostVzduchuVystup.Text = (read["vlhkost"].ToString());
                            vystupnaKontrolaScr1.txtTeplotaPracoviskaVystup.Text = (read["teplota"].ToString());
                            vystupnaKontrolaScr1.txtTlakVystup.Text = (read["tlak"].ToString());
                            ovladaciPanelObjednavkySF1.Produkt.Text = (read["Product"].ToString());
                            ovladaciPanelObjednavkySF1.Zakaznik.Text = (read["Zakaznik"].ToString());
                            ovladaciPanelObjednavkySF1.ZakObjednavka.Text = (read["zakaznicka_objednavka"].ToString());
                            zaznamChyb.txtPopisChyby.Text = (read["PopisChyby"].ToString());
                            zaznamChyb.comboTree1.Text = (read["ChybaKto1"].ToString());
                            zaznamChyb.comboTree2.Text = (read["ChybaKto2"].ToString());
                            zaznamChyb.textBoxX2.Text = (read["CasChybySpolu"].ToString());
                            zaznamChyb.txtZapisal.Text = (read["ChybuZapisal"].ToString());
                            zaznamChyb.txtZapisalDna.Text = (read["ChybuZapisalKedy"].ToString());

                        }
                        read.Close();

                    }
                }
                else
                {

                    zakazka = ovladaciPanelObjednavkySF1.comboBoxEx1.Text;
                    ovladaciPanelFormulare1.comboBoxItem3.SelectedIndex = 0;
                    ovladaciPanelFormulare1.textBoxItem2.SelectedIndex = 26; // vyberie defaultne snimac Konektorovanie
                    superGridControl1.PrimaryGrid.Columns[1].FilterExpr = "[CisloZakazky] = " + ovladaciPanelObjednavkySF1.comboBoxEx1.Text + " & [Objednavka] = '" + ovladaciPanelObjednavkySF1.comboObjednavka.Text + "/" + ovladaciPanelObjednavkySF1.PoradoveCislo.Text + "' & [Rework] = " + Properties.Settings.Default.rework; //tbl konektorovanie
                    zaznamChybMaterial.gridMaterialBom.PrimaryGrid.Columns[1].FilterExpr = "[objednavka] = '" + ovladaciPanelObjednavkySF1.comboObjednavka.Text + "/" + ovladaciPanelObjednavkySF1.PoradoveCislo.Text + "' & [Rework] = " + Properties.Settings.Default.rework; //tbl konektorovanie
                }

                ovladaciPanelObjednavkySF1.comboObjednavka.SelectedItem = null;
                //vlozi nazov formulara do pola formular
                if (string.IsNullOrWhiteSpace(ovladaciPanelFormulare1.comboBoxItem4.Text))
                {
                    ovladaciPanelFormulare1.comboBoxItem4.Text = Form.ActiveForm.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.superGridControl1.Update();

        }


        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            try
            {

                if (Properties.Settings.Default.formulare_otvorenie == true)
                {

                    string connectionString = Class1.dbs_nastavenia("DBS_connection_string");
                    SqlConnection sqlConn = new SqlConnection(connectionString);
                    SqlCommand sqlComm = new SqlCommand();
                    sqlComm = sqlConn.CreateCommand();
                    SqlCommand sqlCommKonektorovanie = new SqlCommand();
                    sqlCommKonektorovanie = sqlConn.CreateCommand();
                    sqlCommKonektorovanie.CommandText = @"UPDATE tblObjednavky SET SylexObjednavka=@SylexObjednavka,Zakazka=@Zakazka,Snimac=@Snimac,PnVlakna=@PnVlakna,LotVlakna=@LotVlakna,ObjVytvoril=@ObjVytvoril,ObjVytvorilDatum=@ObjVytvorilDatum,PopisVlakna=@PopisVlakna,Rework=@Rework,StavObjednavky=@StavObjednavky,FBGSSN=@FBGSSN,spektrum_label=@spektrum_label,vl_label=@vl_label,snapshot_label=@snapshot_label,spektrum_nolabel=@spektrum_nolabel,vl_nolabel=@vl_nolabel,snapshot_nolabel=@snapshot_nolabel,vlhkost=@vlhkost,teplota=@teplota,tlak=@tlak,product=@product,zakaznicka_objednavka=@zakaznicka_objednavka,zakaznik=@zakaznik,PopisChyby=@PopisChyby,ChybaKto1=@ChybaKto1,ChybaKto2=@ChybaKto2,CasChybySpolu=@CasChybySpolu,ChybuZapisal=@ChybuZapisal,ChybuZapisalKedy=@ChybuZapisalKedy, Formular=@Formular WHERE SylexObjednavka=@SylexObjednavka AND Rework=@Rework";
                    sqlCommKonektorovanie.Parameters.AddWithValue("@SylexObjednavka", Properties.Settings.Default.Objednavka);
                    sqlCommKonektorovanie.Parameters.AddWithValue("@Zakazka", ovladaciPanelObjednavkySF1.comboBoxEx1.Text);
                    sqlCommKonektorovanie.Parameters.AddWithValue("@Formular", ovladaciPanelFormulare1.comboBoxItem4.Text);
                    sqlCommKonektorovanie.Parameters.AddWithValue("@Snimac", ovladaciPanelFormulare1.textBoxItem2.Text);
                    sqlCommKonektorovanie.Parameters.AddWithValue("@PnVlakna", ovladaciPanelObjednavkySF1.txtPNvlakna.Text);
                    sqlCommKonektorovanie.Parameters.AddWithValue("@LotVlakna", ovladaciPanelObjednavkySF1.txtLotVlakna.Text);
                    sqlCommKonektorovanie.Parameters.AddWithValue("@ObjVytvoril", ovladaciPanelObjednavkySF1.txtObjVytvoril.Text);
                    sqlCommKonektorovanie.Parameters.AddWithValue("@ObjVytvorilDatum", Convert.ToDateTime(ovladaciPanelObjednavkySF1.txtObjVytvorilKedy.Text));
                    sqlCommKonektorovanie.Parameters.AddWithValue("@PopisVlakna", ovladaciPanelObjednavkySF1.txtPopisVlakna.Text);
                    sqlCommKonektorovanie.Parameters.AddWithValue("@Rework", ovladaciPanelObjednavkySF1.txtRework.Text);
                    sqlCommKonektorovanie.Parameters.AddWithValue("@StavObjednavky", ovladaciPanelFormulare1.comboBoxItem3.Text);
                    sqlCommKonektorovanie.Parameters.AddWithValue("@FBGSSN", ovladaciPanelObjednavkySF1.SFSerialNumber.Text);
                    sqlCommKonektorovanie.Parameters.AddWithValue("@spektrum_label", vystupnaKontrolaScr1.txtScrSpektrumVystupStitok.Text);
                    sqlCommKonektorovanie.Parameters.AddWithValue("@vl_label", vystupnaKontrolaScr1.txtScrVlVystupStitok.Text);
                    sqlCommKonektorovanie.Parameters.AddWithValue("@snapshot_label", vystupnaKontrolaScr1.txtScrSnapshotVystupStitok.Text);
                    sqlCommKonektorovanie.Parameters.AddWithValue("@spektrum_nolabel", vystupnaKontrolaScr1.txtScrSpektrumVystupBezStitok.Text);
                    sqlCommKonektorovanie.Parameters.AddWithValue("@vl_nolabel", vystupnaKontrolaScr1.txtScrVlVystupBezStitok.Text);
                    sqlCommKonektorovanie.Parameters.AddWithValue("@snapshot_nolabel", vystupnaKontrolaScr1.txtScrSnapshotVystupBezStitok.Text);
                    sqlCommKonektorovanie.Parameters.AddWithValue("@vlhkost", vystupnaKontrolaScr1.txtVlhkostVzduchuVystup.Text);
                    sqlCommKonektorovanie.Parameters.AddWithValue("@teplota", vystupnaKontrolaScr1.txtTeplotaPracoviskaVystup.Text);
                    sqlCommKonektorovanie.Parameters.AddWithValue("@tlak", vystupnaKontrolaScr1.txtTlakVystup.Text);
                    sqlCommKonektorovanie.Parameters.AddWithValue("@product", ovladaciPanelObjednavkySF1.Produkt.Text);
                    sqlCommKonektorovanie.Parameters.AddWithValue("@zakaznicka_objednavka", ovladaciPanelObjednavkySF1.ZakObjednavka.Text);
                    sqlCommKonektorovanie.Parameters.AddWithValue("@zakaznik", ovladaciPanelObjednavkySF1.Zakaznik.Text);
                    sqlCommKonektorovanie.Parameters.AddWithValue("@PopisChyby", zaznamChyb.txtPopisChyby.Text);
                    sqlCommKonektorovanie.Parameters.AddWithValue("@ChybaKto1", zaznamChyb.comboTree1.Text);
                    sqlCommKonektorovanie.Parameters.AddWithValue("@ChybaKto2", zaznamChyb.comboTree2.Text);
                    sqlCommKonektorovanie.Parameters.AddWithValue("@CasChybySpolu", zaznamChyb.textBoxX2.Text);
                    sqlCommKonektorovanie.Parameters.AddWithValue("@ChybuZapisal", zaznamChyb.txtZapisal.Text);

                    if (string.IsNullOrWhiteSpace(zaznamChyb.txtZapisalDna.Text))
                    {
                        sqlCommKonektorovanie.Parameters.AddWithValue("@ChybuZapisalKedy", DBNull.Value);
                    }
                    else
                    {
                        sqlCommKonektorovanie.Parameters.AddWithValue("@ChybuZapisalKedy", Convert.ToDateTime(zaznamChyb.txtZapisalDna.Text));
                    }


                    sqlConn.Open();
                    sqlCommKonektorovanie.ExecuteNonQuery();

                    sqlComm.CommandText = @"UPDATE tblZakazky SET CisloZakazky=@CisloZakazky,ZakazkaVytvoril=@ZakazkaVytvoril,ZakazkaVytvorilKedy=@ZakazkaVytvorilKedy,StavZakazky=@StavZakazky,Zakaznik=@Zakaznik,ZakaznickaObjednavka=@ZakaznickaObjednavka WHERE CisloZakazky=@CisloZakazky";
                    sqlComm.Parameters.AddWithValue("@CisloZakazky", ovladaciPanelObjednavkySF1.comboBoxEx1.Text);
                    sqlComm.Parameters.AddWithValue("@ZakazkaVytvoril", ovladaciPanelObjednavkySF1.txtObjVytvoril.Text);
                    sqlComm.Parameters.AddWithValue("@ZakazkaVytvorilKedy", Convert.ToDateTime(ovladaciPanelObjednavkySF1.txtObjVytvorilKedy.Text));
                    sqlComm.Parameters.AddWithValue("@StavZakazky", "Rozpracované");
                    sqlComm.Parameters.AddWithValue("@Zakaznik", ovladaciPanelObjednavkySF1.Zakaznik.Text);
                    sqlComm.Parameters.AddWithValue("@ZakaznickaObjednavka", ovladaciPanelObjednavkySF1.ZakObjednavka.Text);
                    sqlComm.ExecuteNonQuery();
                    sqlConn.Close();
                }
                else
                {
                    string connectionString = Class1.dbs_nastavenia("DBS_connection_string");
                    SqlConnection sqlConn = new SqlConnection(connectionString);
                    SqlCommand sqlComm = new SqlCommand();
                    sqlComm = sqlConn.CreateCommand();
                    sqlComm.CommandText = @"INSERT INTO tblObjednavky (SylexObjednavka,Zakazka,Snimac,PnVlakna,LotVlakna,ObjVytvoril,ObjVytvorilDatum,PopisVlakna,Rework,StavObjednavky,FBGSSN,spektrum_label,vl_label,snapshot_label,spektrum_nolabel,vl_nolabel,snapshot_nolabel,vlhkost,teplota,tlak,product,Zakaznik,zakaznicka_objednavka,PopisChyby,ChybaKto1,ChybaKto2,CasChybySpolu,ChybuZapisal,ChybuZapisalKedy,Formular) VALUES (@SylexObjednavka,@Zakazka,@Snimac,@PnVlakna,@LotVlakna,@ObjVytvoril,@ObjVytvorilDatum,@PopisVlakna,@Rework,@StavObjednavky,@FBGSSN,@spektrum_label,@vl_label,@snapshot_label,@spektrum_nolabel,@vl_nolabel,@snapshot_nolabel,@vlhkost,@teplota,@tlak,@product,@Zakaznik,@zakaznicka_objednavka,@PopisChyby,@ChybaKto1,@ChybaKto2,@CasChybySpolu,@ChybuZapisal,@ChybuZapisalKedy,@Formular)";
                    sqlComm.Parameters.Add(new SqlParameter("@SylexObjednavka", SqlDbType.VarChar, 255)).Value = ovladaciPanelObjednavkySF1.comboObjednavka.Text + "/" + ovladaciPanelObjednavkySF1.PoradoveCislo.Text;
                    sqlComm.Parameters.Add(new SqlParameter("@Zakazka", SqlDbType.NChar, 10)).Value = ovladaciPanelObjednavkySF1.comboBoxEx1.Text;
                    sqlComm.Parameters.Add(new SqlParameter("@Formular", SqlDbType.NVarChar, 255)).Value = ovladaciPanelFormulare1.comboBoxItem4.Text;
                    sqlComm.Parameters.Add(new SqlParameter("@Snimac", SqlDbType.NVarChar, 255)).Value = ovladaciPanelFormulare1.textBoxItem2.Text;
                    sqlComm.Parameters.Add(new SqlParameter("@PnVlakna", SqlDbType.VarChar, 255)).Value = ovladaciPanelObjednavkySF1.txtPNvlakna.Text;
                    sqlComm.Parameters.Add(new SqlParameter("@LotVlakna", SqlDbType.VarChar, 255)).Value = ovladaciPanelObjednavkySF1.txtLotVlakna.Text;
                    sqlComm.Parameters.Add(new SqlParameter("@ObjVytvoril", SqlDbType.VarChar, 255)).Value = ovladaciPanelObjednavkySF1.txtObjVytvoril.Text;
                    sqlComm.Parameters.Add(new SqlParameter("@ObjVytvorilDatum", SqlDbType.DateTime, 0)).Value = ovladaciPanelObjednavkySF1.txtObjVytvorilKedy.Text;
                    sqlComm.Parameters.Add(new SqlParameter("@PopisVlakna", SqlDbType.VarChar, 255)).Value = ovladaciPanelObjednavkySF1.txtPopisVlakna.Text;
                    sqlComm.Parameters.Add(new SqlParameter("@Rework", SqlDbType.VarChar, 255)).Value = ovladaciPanelObjednavkySF1.txtRework.Text;
                    sqlComm.Parameters.Add(new SqlParameter("@StavObjednavky", SqlDbType.VarChar, 255)).Value = ovladaciPanelFormulare1.comboBoxItem3.Text;
                    sqlComm.Parameters.Add(new SqlParameter("@FBGSSN", SqlDbType.VarChar, 255)).Value = ovladaciPanelObjednavkySF1.SFSerialNumber.Text;
                    sqlComm.Parameters.Add(new SqlParameter("@spektrum_label", SqlDbType.NVarChar, 255)).Value = vystupnaKontrolaScr1.txtScrSpektrumVystupStitok.Text;
                    sqlComm.Parameters.Add(new SqlParameter("@vl_label", SqlDbType.NVarChar, 255)).Value = vystupnaKontrolaScr1.txtScrVlVystupStitok.Text;
                    sqlComm.Parameters.Add(new SqlParameter("@snapshot_label", SqlDbType.NVarChar, 255)).Value = vystupnaKontrolaScr1.txtScrSnapshotVystupStitok.Text;
                    sqlComm.Parameters.Add(new SqlParameter("@spektrum_nolabel", SqlDbType.NVarChar, 255)).Value = vystupnaKontrolaScr1.txtScrSpektrumVystupBezStitok.Text;
                    sqlComm.Parameters.Add(new SqlParameter("@vl_nolabel", SqlDbType.NVarChar, 255)).Value = vystupnaKontrolaScr1.txtScrVlVystupBezStitok.Text;
                    sqlComm.Parameters.Add(new SqlParameter("@snapshot_nolabel", SqlDbType.NVarChar, 255)).Value = vystupnaKontrolaScr1.txtScrSnapshotVystupBezStitok.Text;
                    sqlComm.Parameters.Add(new SqlParameter("@vlhkost", SqlDbType.VarChar, 255)).Value = vystupnaKontrolaScr1.txtVlhkostVzduchuVystup.Text;
                    sqlComm.Parameters.Add(new SqlParameter("@teplota", SqlDbType.VarChar, 255)).Value = vystupnaKontrolaScr1.txtTeplotaPracoviskaVystup.Text;
                    sqlComm.Parameters.Add(new SqlParameter("@tlak", SqlDbType.VarChar, 255)).Value = vystupnaKontrolaScr1.txtTlakVystup.Text;
                    sqlComm.Parameters.Add(new SqlParameter("@product", SqlDbType.VarChar, 255)).Value = ovladaciPanelObjednavkySF1.Produkt.Text;
                    sqlComm.Parameters.Add(new SqlParameter("@Zakaznik", SqlDbType.VarChar, 255)).Value = ovladaciPanelObjednavkySF1.Zakaznik.Text;
                    sqlComm.Parameters.Add(new SqlParameter("@zakaznicka_objednavka", SqlDbType.VarChar, 255)).Value = ovladaciPanelObjednavkySF1.ZakObjednavka.Text;
                    sqlComm.Parameters.Add(new SqlParameter("@PopisChyby", SqlDbType.VarChar, 255)).Value = zaznamChyb.txtPopisChyby.Text;
                    sqlComm.Parameters.Add(new SqlParameter("@ChybaKto1", SqlDbType.VarChar, 50)).Value = zaznamChyb.comboTree1.Text;
                    sqlComm.Parameters.Add(new SqlParameter("@ChybaKto2", SqlDbType.VarChar, 50)).Value = zaznamChyb.comboTree2.Text;
                    string time = zaznamChyb.textBoxX2.Text;
                    var result = Convert.ToDateTime(time);
                    string test = result.ToString("hh:mm:ss", CultureInfo.CurrentCulture);
                    sqlComm.Parameters.Add(new SqlParameter("@CasChybySpolu", SqlDbType.Time, 7)).Value = zaznamChyb.textBoxX2.Text;
                    sqlComm.Parameters.Add(new SqlParameter("@ChybuZapisal", SqlDbType.VarChar, 50)).Value = zaznamChyb.txtZapisal.Text;

                    if (string.IsNullOrWhiteSpace(zaznamChyb.txtZapisalDna.Text))
                    {
                        sqlComm.Parameters.Add(new SqlParameter("@ChybuZapisalKedy", SqlDbType.DateTime, 0)).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add(new SqlParameter("@ChybuZapisalKedy", SqlDbType.DateTime, 0)).Value = zaznamChyb.txtZapisalDna.Text;
                    }

                    sqlConn.Open();
                    sqlComm.ExecuteNonQuery();
                    sqlComm = sqlConn.CreateCommand();
                    sqlComm.CommandText = @"SELECT COUNT (CisloZakazky) FROM tblZakazky WHERE CisloZakazky = '" + ovladaciPanelObjednavkySF1.comboBoxEx1.Text + "' ";

                    int temp = Convert.ToInt32(sqlComm.ExecuteScalar().ToString());
                    if (temp > 0)
                    {
                        sqlComm.CommandText = @"UPDATE tblZakazky SET CisloZakazky=@CisloZakazky,ZakazkaVytvoril=@ZakazkaVytvoril,ZakazkaVytvorilKedy=@ZakazkaVytvorilKedy,StavZakazky=@StavZakazky,Zakaznik=@Zakaznik,ZakaznickaObjednavka=@ZakaznickaObjednavka WHERE CisloZakazky=@CisloZakazky";
                        sqlComm.Parameters.AddWithValue("@CisloZakazky", ovladaciPanelObjednavkySF1.comboBoxEx1.Text);
                        sqlComm.Parameters.AddWithValue("@ZakazkaVytvoril", ovladaciPanelObjednavkySF1.txtObjVytvoril.Text);
                        sqlComm.Parameters.AddWithValue("@ZakazkaVytvorilKedy", Convert.ToDateTime(ovladaciPanelObjednavkySF1.txtObjVytvorilKedy.Text));
                        sqlComm.Parameters.AddWithValue("@StavZakazky", "Rozpracované");
                        sqlComm.Parameters.AddWithValue("@Zakaznik", ovladaciPanelObjednavkySF1.Zakaznik.Text);
                        sqlComm.Parameters.AddWithValue("@ZakaznickaObjednavka", ovladaciPanelObjednavkySF1.ZakObjednavka.Text);
                        sqlComm.ExecuteNonQuery();
                        sqlConn.Close();
                    }
                    else
                    {
                        sqlComm = sqlConn.CreateCommand();
                        sqlComm.CommandText = @"INSERT INTO tblZakazky (CisloZakazky,ZakazkaVytvoril,ZakazkaVytvorilKedy,StavZakazky,Zakaznik,ZakaznickaObjednavka) VALUES (@CisloZakazky,@ZakazkaVytvoril,@ZakazkaVytvorilKedy,@StavZakazky,@Zakaznik,@ZakaznickaObjednavka)";
                        sqlComm.Parameters.Add(new SqlParameter("@CisloZakazky", SqlDbType.VarChar, 255)).Value = ovladaciPanelObjednavkySF1.comboBoxEx1.Text;
                        sqlComm.Parameters.Add(new SqlParameter("@ZakazkaVytvoril", SqlDbType.VarChar, 255)).Value = ovladaciPanelObjednavkySF1.txtObjVytvoril.Text;
                        sqlComm.Parameters.Add(new SqlParameter("@ZakazkaVytvorilKedy", SqlDbType.DateTime, 0)).Value = ovladaciPanelObjednavkySF1.txtObjVytvorilKedy.Text;
                        sqlComm.Parameters.Add(new SqlParameter("@StavZakazky", SqlDbType.NChar, 25)).Value = "Rozpracované";
                        sqlComm.Parameters.Add(new SqlParameter("@Zakaznik", SqlDbType.VarChar, 255)).Value = ovladaciPanelObjednavkySF1.Zakaznik.Text;
                        sqlComm.Parameters.Add(new SqlParameter("@ZakaznickaObjednavka", SqlDbType.VarChar, 255)).Value = ovladaciPanelObjednavkySF1.ZakObjednavka.Text;
                        sqlComm.ExecuteNonQuery();
                        sqlConn.Close();
                    }

                    this.Close();
                }

                this.tblKonektorovanieTableAdapter.Update(this.novaDBcsharpDataSet.tblKonektorovanie);
                zaznamChybMaterial.tblZnicenyMaterialTableAdapter.Update(zaznamChybMaterial.novaDBcsharpDataSet.tblZnicenyMaterial);

                Class1.set_sort_main_form(); //nastavi zobrazenie v hlavnom formulari
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }


        string objednavka;
        string zakazka;

        private void txtObjednavka_TextChanged(object sender, EventArgs e)
        {
            objednavka = ovladaciPanelObjednavkySF1.comboObjednavka.Text + "/" + ovladaciPanelObjednavkySF1.PoradoveCislo.Text;
        }


        private void txtObjednavka_Leave(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ovladaciPanelObjednavkySF1.comboBoxEx1.Text))
                {
                    MessageBox.Show("Zadajte najprv zákazku!");
                    return;
                }

                //load pn and description from isys
                ovladaciPanelObjednavkySF1.txtPNvlakna.Text = Class1.get_pn_and_desc_fiber_isys(ovladaciPanelObjednavkySF1.comboObjednavka.Text).Item1;
                ovladaciPanelObjednavkySF1.txtPopisVlakna.Text = Class1.get_pn_and_desc_fiber_isys(ovladaciPanelObjednavkySF1.comboObjednavka.Text).Item2;

                ovladaciPanelObjednavkySF1.Produkt.Text = Class1.get_product_name_and_customer_order(ovladaciPanelObjednavkySF1.comboObjednavka.Text).Item1;
                ovladaciPanelObjednavkySF1.SFSerialNumber.Text = Class1.get_product_name_and_customer_order(ovladaciPanelObjednavkySF1.comboObjednavka.Text).Item1;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonX1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ovladaciPanelObjednavkySF1.comboObjednavka.Text))
                {
                    MessageBox.Show("Najprv zadaj Objednávku");
                    return;
                }
                if (string.IsNullOrWhiteSpace(ovladaciPanelObjednavkySF1.comboBoxEx1.Text))
                {
                    MessageBox.Show("Najprv zadaj Zákazku");
                    return;
                }
                string connectionString = Class1.dbs_nastavenia("DBS_connection_string");
                SqlConnection sqlConn = new SqlConnection(connectionString);

                sqlConn.Open();
                this.superGridControl1.PrimaryGrid.EnableFiltering = true;
                superGridControl1.PrimaryGrid.EnableColumnFiltering = true;
                superGridControl1.PrimaryGrid.EnableRowFiltering = true;
                superGridControl1.PrimaryGrid.Columns[1].EnableFiltering = Tbool.True;
                superGridControl1.PrimaryGrid.Columns[1].ShowPanelFilterExpr = Tbool.True;
                superGridControl1.PrimaryGrid.Columns[1].FilterExpr = "[CisloZakazky] = " + ovladaciPanelObjednavkySF1.comboBoxEx1.Text + " & [Objednavka] = '" + ovladaciPanelObjednavkySF1.comboObjednavka.Text + "/" + ovladaciPanelObjednavkySF1.PoradoveCislo.Text + "' & [Rework] = " + ovladaciPanelObjednavkySF1.txtRework.Text;
                this.tblKonektorovanieTableAdapter.Fill(this.novaDBcsharpDataSet.tblKonektorovanie);
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        string prihlaseny = Class1.prihlasovacie_meno;
        private void superGridControl1_CellValueChanged(object sender, GridCellValueChangedEventArgs e)
        {
            try
            {

                string objednavka = ovladaciPanelObjednavkySF1.comboObjednavka.Text + "/" + ovladaciPanelObjednavkySF1.PoradoveCislo.Text;
                var seletedcells = superGridControl1.GetSelectedCells();
                GridCell seletedcell = seletedcells[0] as GridCell;
                var activerow = (DevComponents.DotNetBar.SuperGrid.GridRow)e.GridPanel.ActiveRow;
                var activecell = (DevComponents.DotNetBar.SuperGrid.GridCell)e.GridPanel.ActiveCell;
                int a;
                a = Convert.ToInt32(activecell.ColumnIndex);
                if (a == 6 || a == 14)
                {
                    if (seletedcell == e.GridCell)
                    {
                        this.tblKonektorovanieTableAdapter.Update(this.novaDBcsharpDataSet.tblKonektorovanie);
                        List<string[]> objednavka2 = new List<string[]>();
                        string[] Array = new string[8];

                        this.superGridControl1.PrimaryGrid.BeginDataUpdate();

                        this.superGridControl1.PrimaryGrid.EndDataUpdate();

                        double pw;
                        double rl;
                        int row_count;
                        row_count = Convert.ToInt32(activerow.GridPanel.VisibleRowCount); //pocet zobrazenych riadkov v tabulke

                        string rmax = "";
                        string connectionString = Class1.dbs_nastavenia("DBS_connection_string");
                        SqlConnection sqlConn = new SqlConnection(connectionString);
                        SqlCommand sqlComm = new SqlCommand();
                        sqlComm = sqlConn.CreateCommand();
                        sqlComm.CommandText = @"SELECT rmax FROM rmax_values WHERE LOT='" + ovladaciPanelObjednavkySF1.txtLotVlakna.Text + "'";
                        sqlConn.Open();

                        object getrmax = sqlComm.ExecuteScalar();
                        if (getrmax != null)
                        {
                            rmax = sqlComm.ExecuteScalar().ToString(); //zapisanie rmax do vsetkych rows v o objednavke
                        }
                        else
                        {
                            MessageBox.Show("Nieje vyplnená hodnota Rmax vo formulári Rmax hodnoty alebo sa lot nezhoduje s lotom v Rmax hodnoty, najprv to tam vyplň!");
                            return;
                        }

                        sqlConn.Close();

                        #region zapis do RL bunky - label
                        if (a == 6) // ak ziapisem do RL tak... - do prveho riadku
                        {
                            double power = Class1.max_power_strana_so_stitkom(objednavka);
                            string rl_Value = Convert.ToString(activerow.Cells[6].Value); //zapisanie rl do vsetkych rows v o objednavke
                            using (SqlConnection connection = new SqlConnection(Class1.dbs_nastavenia("DBS_connection_string")))
                            {
                                SqlCommand command =
                                new SqlCommand("SELECT pv_measured,FBGnr FROM tblKonektorovanie WHERE Objednavka='" + objednavka + "' ORDER BY FBGnr ASC", connection);
                                connection.Open();

                                SqlDataReader read = command.ExecuteReader();

                                while (read.Read())
                                {
                                    pw = Convert.ToDouble((read["pv_measured"].ToString()));
                                    rl = Convert.ToDouble(activerow.Cells[6].Value);
                                    Array[0] = (Convert.ToString(rl_Value));
                                    Array[1] = (Convert.ToString(pw - rl));
                                    Array[2] = (Convert.ToString(Convert.ToDouble(rmax)));
                                    Array[3] = (Convert.ToString(Convert.ToString(power - rl)));
                                    double rmax_vypocet = ((power - rl) / 10);
                                    double rmax_snrmin_vypocet = Math.Pow(10, rmax_vypocet) / Convert.ToDouble(Array[2]);
                                    Array[4] = (Convert.ToString(Math.Round(rmax_snrmin_vypocet, 3)));
                                    Array[5] = (Convert.ToString(Convert.ToString(Class1.prihlasovacie_meno)));
                                    Array[6] = (Convert.ToString(Convert.ToString(DateTime.Now.ToString())));

                                    if (rmax_snrmin_vypocet >= 10)
                                    {
                                        Array[7] = (Convert.ToString("PASS"));
                                    }
                                    else
                                    {
                                        Array[7] = (Convert.ToString("FAIL"));
                                    }
                                    objednavka2.Add(Array);

                                }
                                read.Close();


                            }

                            for (int i = 0; i <= row_count - 1; i++)
                            {

                                {
                                    SqlConnection sqlConn3 = new SqlConnection(connectionString);
                                    SqlCommand sqlComm3 = new SqlCommand();
                                    sqlComm3 = sqlConn3.CreateCommand();
                                    sqlConn3.Open();
                                    sqlComm3.CommandText = @"UPDATE tblKonektorovanie SET RL_measured=@RL_measured,Meno=@Meno,Kedy=@Kedy,Rmax=@Rmax,SNRmin=@SNRmin,Rmax_snrmin=@Rmax_snrmin,result=@result,rozdiel_wl_pv=@rozdiel_wl_pv WHERE Objednavka=@Objednavka AND FBGnr=@FBGnr";
                                    sqlComm3.Parameters.AddWithValue("@Objednavka", Convert.ToString(ovladaciPanelObjednavkySF1.comboObjednavka.Text + "/" + ovladaciPanelObjednavkySF1.PoradoveCislo.Text));
                                    sqlComm3.Parameters.AddWithValue("@FBGnr", i + 1);
                                    sqlComm3.Parameters.AddWithValue("@RL_measured", Convert.ToDouble(objednavka2[i][0]));
                                    sqlComm3.Parameters.AddWithValue("@Meno", Convert.ToString(objednavka2[i][5]));
                                    sqlComm3.Parameters.AddWithValue("@Kedy", Convert.ToDateTime(objednavka2[i][6]));
                                    sqlComm3.Parameters.AddWithValue("@Rmax", Convert.ToDouble(objednavka2[i][2]));
                                    sqlComm3.Parameters.AddWithValue("@SNRmin", Convert.ToDouble(objednavka2[i][3]));
                                    sqlComm3.Parameters.AddWithValue("@Rmax_snrmin", Convert.ToDouble(objednavka2[i][4]));
                                    sqlComm3.Parameters.AddWithValue("@result", Convert.ToString(objednavka2[i][7]));
                                    sqlComm3.Parameters.AddWithValue("@rozdiel_wl_pv", Convert.ToDouble(objednavka2[i][1]));
                                    sqlComm3.ExecuteNonQuery();
                                    sqlConn3.Close();


                                }
                            }

                            this.superGridControl1.PrimaryGrid.BeginDataUpdate();
                            this.tblKonektorovanieTableAdapter.Fill(this.novaDBcsharpDataSet.tblKonektorovanie);
                            this.superGridControl1.PrimaryGrid.EndDataUpdate();
                            vystupnaKontrolaScr1.txtTeplotaPracoviskaVystup.Text = Class1.get_data_from_HMS().Item1;
                            vystupnaKontrolaScr1.txtTlakVystup.Text = Class1.get_data_from_HMS().Item2;
                            vystupnaKontrolaScr1.txtVlhkostVzduchuVystup.Text = Class1.get_data_from_HMS().Item3;

                        }
                        #endregion



                        #region zapis do RL bunky - nolabel
                        if (a == 14) // ak ziapisem do RL tak... - do prveho riadku
                        {

                            string rl_Value = Convert.ToString(activerow.Cells[14].Value); //zapisanie rl do vsetkych rows v o objednavke

                            double power = Class1.max_power_strana_bez_stitka(objednavka);

                            using (SqlConnection connection = new SqlConnection(Class1.dbs_nastavenia("DBS_connection_string")))
                            {
                                SqlCommand command =
                                new SqlCommand("SELECT pv_measured_nolabel,FBGnr FROM tblKonektorovanie WHERE Objednavka='" + objednavka + "' ORDER BY FBGnr ASC", connection);
                                connection.Open();

                                SqlDataReader read = command.ExecuteReader();

                                while (read.Read())
                                {
                                    pw = Convert.ToDouble((read["pv_measured_nolabel"].ToString()));
                                    rl = Convert.ToDouble(activerow.Cells[14].Value);
                                    Array[0] = (Convert.ToString(rl_Value));
                                    Array[1] = (Convert.ToString(pw - rl));
                                    Array[2] = (Convert.ToString(Convert.ToDouble(rmax)));
                                    Array[3] = (Convert.ToString(Convert.ToString(power - rl)));
                                    double rmax_vypocet = ((power - rl) / 10);
                                    double rmax_snrmin_vypocet = Math.Pow(10, rmax_vypocet) / Convert.ToDouble(Array[2]);
                                    Array[4] = (Convert.ToString(Math.Round(rmax_snrmin_vypocet, 3)));
                                    Array[5] = (Convert.ToString(Convert.ToString(Class1.prihlasovacie_meno)));
                                    Array[6] = (Convert.ToString(Convert.ToString(DateTime.Now.ToString())));

                                    if (rmax_snrmin_vypocet >= 10)
                                    {
                                        Array[7] = (Convert.ToString("PASS"));
                                    }
                                    else
                                    {
                                        Array[7] = (Convert.ToString("FAIL"));
                                    }
                                    objednavka2.Add(Array);

                                }
                                read.Close();


                            }

                            for (int i = 0; i <= row_count - 1; i++)
                            {

                                {
                                    SqlConnection sqlConn4 = new SqlConnection(connectionString);
                                    SqlCommand sqlComm4 = new SqlCommand();
                                    sqlComm4 = sqlConn4.CreateCommand();
                                    sqlConn4.Open();
                                    sqlComm4.CommandText = @"UPDATE tblKonektorovanie SET RL_measured_nolabel=@RL_measured_nolabel,Meno=@Meno,Kedy=@Kedy,SNRmin_nolabel=@SNRmin_nolabel,Rmax_snrmin_nolabel=@Rmax_snrmin_nolabel,result_nolabel=@result_nolabel,rozdiel_wl_pv_nolabel=@rozdiel_wl_pv_nolabel WHERE Objednavka=@Objednavka AND FBGnr=@FBGnr";
                                    sqlComm4.Parameters.AddWithValue("@Objednavka", ovladaciPanelObjednavkySF1.comboObjednavka.Text + "/" + ovladaciPanelObjednavkySF1.PoradoveCislo.Text);
                                    sqlComm4.Parameters.AddWithValue("@FBGnr", i + 1);
                                    sqlComm4.Parameters.AddWithValue("@RL_measured_nolabel", Convert.ToDouble(objednavka2[i][0]));
                                    sqlComm4.Parameters.AddWithValue("@Meno", objednavka2[i][5]);
                                    sqlComm4.Parameters.AddWithValue("@Kedy", Convert.ToDateTime(objednavka2[i][6]));
                                    sqlComm4.Parameters.AddWithValue("@SNRmin_nolabel", Convert.ToDouble(objednavka2[i][3]));
                                    sqlComm4.Parameters.AddWithValue("@Rmax_snrmin_nolabel", Convert.ToDouble(objednavka2[i][4]));
                                    sqlComm4.Parameters.AddWithValue("@result_nolabel", objednavka2[i][7]);
                                    sqlComm4.Parameters.AddWithValue("@rozdiel_wl_pv_nolabel", Convert.ToDouble(objednavka2[i][1]));
                                    sqlComm4.ExecuteNonQuery();
                                    sqlConn4.Close();

                                }
                            }

                            this.superGridControl1.PrimaryGrid.BeginDataUpdate();
                            this.tblKonektorovanieTableAdapter.Fill(this.novaDBcsharpDataSet.tblKonektorovanie);
                            this.superGridControl1.PrimaryGrid.EndDataUpdate();
                        }


                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




        private void Konektorovanie_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.formulare_otvorenie = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Naozaj chcete zavrieť? nič nebude uložené!", "Zatvoriť",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
            {
                this.Close();
            }

        }


        private void superGridControl1_RowAdded(object sender, DevComponents.DotNetBar.SuperGrid.GridRowAddedEventArgs e)
        {
            var activerow = (DevComponents.DotNetBar.SuperGrid.GridRow)e.GridPanel.ActiveRow;
            activerow.Cells[1].Value = zakazka;
            activerow.Cells[2].Value = objednavka;
            activerow.Cells[19].Value = Class1.prihlasovacie_meno;
            activerow.Cells[20].Value = DateTime.Now.ToString(); ;
        }

        private void comboBoxEx1_Leave(object sender, EventArgs e)
        {
            try
            {
                {
                    if (string.IsNullOrWhiteSpace(ovladaciPanelObjednavkySF1.comboBoxEx1.Text))
                    {
                        MessageBox.Show("Zadajte najprv zákazku!");
                        return;
                    }
                    // nacitanie zakaznickeho kodu a zakaznika
                    ovladaciPanelObjednavkySF1.Zakaznik.Text = Class1.get_zakaznik_zakaznickykod(ovladaciPanelObjednavkySF1.comboBoxEx1.Text).Item1;
                    ovladaciPanelObjednavkySF1.ZakObjednavka.Text = Class1.get_zakaznik_zakaznickykod(ovladaciPanelObjednavkySF1.comboBoxEx1.Text).Item2;

                    ovladaciPanelObjednavkySF1.txtObjVytvoril.Text = Class1.prihlasovacie_meno;
                    ovladaciPanelObjednavkySF1.txtObjVytvorilKedy.Text = DateTime.Now.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            zakazka = ovladaciPanelObjednavkySF1.comboBoxEx1.Text;
            this.tblKonektorovanieTableAdapter.Update(this.novaDBcsharpDataSet.tblKonektorovanie);
        }


        private void superGridControl1_CellClick(object sender, GridCellClickEventArgs e)
        {

            var activecell = (DevComponents.DotNetBar.SuperGrid.GridCell)e.GridPanel.ActiveCell;
            var activerow = (DevComponents.DotNetBar.SuperGrid.GridRow)e.GridPanel.ActiveRow;
            int active_cell = Convert.ToInt32(activecell.ColumnIndex);
            string wl = Convert.ToString(activerow.Cells[4].Value);
            string pv = Convert.ToString(activerow.Cells[5].Value);

            if (active_cell == 6 || active_cell == 14) //ak nieje zapisany lot tak nespusti dalej
            {
                if (string.IsNullOrWhiteSpace(ovladaciPanelObjednavkySF1.txtLotVlakna.Text))
                {
                    MessageBox.Show("Nieje vyplnený lot vlákna, najprv to vyplň!");
                    return;
                }

                else if (string.IsNullOrWhiteSpace(wl) || string.IsNullOrWhiteSpace(pv)) //ak nieje zapisany pw a vl tak nespusti dalej
                {
                    MessageBox.Show("Nieje vyplnená vlnová dĺžka alebo power value!");
                    return;
                }
            }
        }

        private void txtScrSpektrumVystupStitok_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


