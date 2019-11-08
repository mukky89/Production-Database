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

namespace WindowsFormsApplication14
{

    public partial class OvladaciPanelFormulare : UserControl
    {
        private UserControl ovladaciPanel;
        string prihlaseny = Class1.prihlasovacie_meno;
        public OvladaciPanelFormulare()
        {
            InitializeComponent();
            ovladaciPanel = new UserControl();

        }

        public int close_save_status = 0;

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }


        private void btnSaveClose_Click_1(object sender, EventArgs e)
        {
            try
            {
                ComboBoxEx Objednavka = Parent.Parent.Controls.Find("comboObjednavka", true).FirstOrDefault() as ComboBoxEx;
                MaskedTextBoxAdv PoradoveCislo = Parent.Parent.Controls.Find("PoradoveCislo", true).FirstOrDefault() as MaskedTextBoxAdv;
                TextBoxX Rework = Parent.Parent.Controls.Find("txtRework", true).FirstOrDefault() as TextBoxX;
                Form currentForm = Form.ActiveForm;
                string form = currentForm.Name;
                if (form == "Konektorovanie")
                {
                    #region konektorovanie
                    Konektorovanie f = (Konektorovanie)Application.OpenForms[1];
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
                            sqlCommKonektorovanie.Parameters.AddWithValue("@SylexObjednavka", Objednavka.Text + "/" + PoradoveCislo.Text);
                            sqlCommKonektorovanie.Parameters.AddWithValue("@Zakazka", f.ovladaciPanelObjednavkyNEW1.comboBoxEx1.Text);
                            sqlCommKonektorovanie.Parameters.AddWithValue("@Formular", comboBoxItem4.Text);
                            sqlCommKonektorovanie.Parameters.AddWithValue("@Snimac", textBoxItem2.Text);
                            sqlCommKonektorovanie.Parameters.AddWithValue("@PnVlakna", f.ovladaciPanelObjednavkyNEW1.txtPNvlakna.Text);
                            sqlCommKonektorovanie.Parameters.AddWithValue("@LotVlakna", f.ovladaciPanelObjednavkyNEW1.txtLotVlakna.Text);
                            sqlCommKonektorovanie.Parameters.AddWithValue("@ObjVytvoril", f.ovladaciPanelObjednavkyNEW1.txtObjVytvoril.Text);
                            sqlCommKonektorovanie.Parameters.AddWithValue("@ObjVytvorilDatum", Convert.ToDateTime(f.ovladaciPanelObjednavkyNEW1.txtObjVytvorilKedy.Text));
                            sqlCommKonektorovanie.Parameters.AddWithValue("@PopisVlakna", f.ovladaciPanelObjednavkyNEW1.txtPopisVlakna.Text);
                            sqlCommKonektorovanie.Parameters.AddWithValue("@Rework", f.ovladaciPanelObjednavkyNEW1.txtRework.Text);
                            sqlCommKonektorovanie.Parameters.AddWithValue("@StavObjednavky", comboBoxItem3.Text);
                            sqlCommKonektorovanie.Parameters.AddWithValue("@FBGSSN", f.ovladaciPanelObjednavkyNEW1.txtFBGSSN.Text);
                            sqlCommKonektorovanie.Parameters.AddWithValue("@spektrum_label", f.vystupnaKontrolaScr1.txtScrSpektrumVystupStitok.Text);
                            sqlCommKonektorovanie.Parameters.AddWithValue("@vl_label", f.vystupnaKontrolaScr1.txtScrVlVystupStitok.Text);
                            sqlCommKonektorovanie.Parameters.AddWithValue("@snapshot_label", f.vystupnaKontrolaScr1.txtScrSnapshotVystupStitok.Text);
                            sqlCommKonektorovanie.Parameters.AddWithValue("@spektrum_nolabel", f.vystupnaKontrolaScr1.txtScrSpektrumVystupBezStitok.Text);
                            sqlCommKonektorovanie.Parameters.AddWithValue("@vl_nolabel", f.vystupnaKontrolaScr1.txtScrVlVystupBezStitok.Text);
                            sqlCommKonektorovanie.Parameters.AddWithValue("@snapshot_nolabel", f.vystupnaKontrolaScr1.txtScrSnapshotVystupBezStitok.Text);
                            sqlCommKonektorovanie.Parameters.AddWithValue("@vlhkost", f.vystupnaKontrolaScr1.txtVlhkostVzduchuVystup.Text);
                            sqlCommKonektorovanie.Parameters.AddWithValue("@teplota", f.vystupnaKontrolaScr1.txtTeplotaPracoviskaVystup.Text);
                            sqlCommKonektorovanie.Parameters.AddWithValue("@tlak", f.vystupnaKontrolaScr1.txtTlakVystup.Text);
                            sqlCommKonektorovanie.Parameters.AddWithValue("@product", f.ovladaciPanelObjednavkyNEW1.Produkt.Text);
                            sqlCommKonektorovanie.Parameters.AddWithValue("@zakaznicka_objednavka", f.ovladaciPanelObjednavkyNEW1.ZakObjednavka.Text);
                            sqlCommKonektorovanie.Parameters.AddWithValue("@zakaznik", f.ovladaciPanelObjednavkyNEW1.Zakaznik.Text);
                            sqlCommKonektorovanie.Parameters.AddWithValue("@PopisChyby", f.zaznamChyb.txtPopisChyby.Text);
                            sqlCommKonektorovanie.Parameters.AddWithValue("@ChybaKto1", f.zaznamChyb.comboTree1.Text);
                            sqlCommKonektorovanie.Parameters.AddWithValue("@ChybaKto2", f.zaznamChyb.comboTree2.Text);
                            sqlCommKonektorovanie.Parameters.AddWithValue("@CasChybySpolu", f.zaznamChyb.textBoxX2.Text);
                            sqlCommKonektorovanie.Parameters.AddWithValue("@ChybuZapisal", f.zaznamChyb.txtZapisal.Text);

                            if (string.IsNullOrWhiteSpace(f.zaznamChyb.txtZapisalDna.Text))
                            {
                                sqlCommKonektorovanie.Parameters.AddWithValue("@ChybuZapisalKedy", DBNull.Value);
                            }
                            else
                            {
                                sqlCommKonektorovanie.Parameters.AddWithValue("@ChybuZapisalKedy", Convert.ToDateTime(f.zaznamChyb.txtZapisalDna.Text));
                            }


                            sqlConn.Open();
                            sqlCommKonektorovanie.ExecuteNonQuery();

                            sqlComm.CommandText = @"UPDATE tblZakazky SET CisloZakazky=@CisloZakazky,ZakazkaVytvoril=@ZakazkaVytvoril,ZakazkaVytvorilKedy=@ZakazkaVytvorilKedy,StavZakazky=@StavZakazky,Zakaznik=@Zakaznik,ZakaznickaObjednavka=@ZakaznickaObjednavka WHERE CisloZakazky=@CisloZakazky";
                            sqlComm.Parameters.AddWithValue("@CisloZakazky", f.ovladaciPanelObjednavkyNEW1.comboBoxEx1.Text);
                            sqlComm.Parameters.AddWithValue("@ZakazkaVytvoril", f.ovladaciPanelObjednavkyNEW1.txtObjVytvoril.Text);
                            sqlComm.Parameters.AddWithValue("@ZakazkaVytvorilKedy", Convert.ToDateTime(f.ovladaciPanelObjednavkyNEW1.txtObjVytvorilKedy.Text));
                            sqlComm.Parameters.AddWithValue("@StavZakazky", "Rozpracované");
                            sqlComm.Parameters.AddWithValue("@Zakaznik", f.ovladaciPanelObjednavkyNEW1.Zakaznik.Text);
                            sqlComm.Parameters.AddWithValue("@ZakaznickaObjednavka", f.ovladaciPanelObjednavkyNEW1.ZakObjednavka.Text);
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
                            sqlComm.Parameters.Add(new SqlParameter("@SylexObjednavka", SqlDbType.VarChar, 255)).Value = f.ovladaciPanelObjednavkyNEW1.comboObjednavka.Text + "/" + f.ovladaciPanelObjednavkyNEW1.PoradoveCislo.Text;
                            sqlComm.Parameters.Add(new SqlParameter("@Zakazka", SqlDbType.NChar, 10)).Value = f.ovladaciPanelObjednavkyNEW1.comboBoxEx1.Text;
                            sqlComm.Parameters.Add(new SqlParameter("@Formular", SqlDbType.NVarChar, 255)).Value = comboBoxItem4.Text;
                            sqlComm.Parameters.Add(new SqlParameter("@Snimac", SqlDbType.NVarChar, 255)).Value = textBoxItem2.Text;
                            sqlComm.Parameters.Add(new SqlParameter("@PnVlakna", SqlDbType.VarChar, 255)).Value = f.ovladaciPanelObjednavkyNEW1.txtPNvlakna.Text;
                            sqlComm.Parameters.Add(new SqlParameter("@LotVlakna", SqlDbType.VarChar, 255)).Value = f.ovladaciPanelObjednavkyNEW1.txtLotVlakna.Text;
                            sqlComm.Parameters.Add(new SqlParameter("@ObjVytvoril", SqlDbType.VarChar, 255)).Value = f.ovladaciPanelObjednavkyNEW1.txtObjVytvoril.Text;
                            sqlComm.Parameters.Add(new SqlParameter("@ObjVytvorilDatum", SqlDbType.DateTime, 0)).Value = f.ovladaciPanelObjednavkyNEW1.txtObjVytvorilKedy.Text;
                            sqlComm.Parameters.Add(new SqlParameter("@PopisVlakna", SqlDbType.VarChar, 255)).Value = f.ovladaciPanelObjednavkyNEW1.txtPopisVlakna.Text;
                            sqlComm.Parameters.Add(new SqlParameter("@Rework", SqlDbType.VarChar, 255)).Value = f.ovladaciPanelObjednavkyNEW1.txtRework.Text;
                            sqlComm.Parameters.Add(new SqlParameter("@StavObjednavky", SqlDbType.VarChar, 255)).Value = comboBoxItem3.Text;
                            sqlComm.Parameters.Add(new SqlParameter("@FBGSSN", SqlDbType.VarChar, 255)).Value = f.ovladaciPanelObjednavkyNEW1.txtFBGSSN.Text;
                            sqlComm.Parameters.Add(new SqlParameter("@spektrum_label", SqlDbType.NVarChar, 255)).Value = f.vystupnaKontrolaScr1.txtScrSpektrumVystupStitok.Text;
                            sqlComm.Parameters.Add(new SqlParameter("@vl_label", SqlDbType.NVarChar, 255)).Value = f.vystupnaKontrolaScr1.txtScrVlVystupStitok.Text;
                            sqlComm.Parameters.Add(new SqlParameter("@snapshot_label", SqlDbType.NVarChar, 255)).Value = f.vystupnaKontrolaScr1.txtScrSnapshotVystupStitok.Text;
                            sqlComm.Parameters.Add(new SqlParameter("@spektrum_nolabel", SqlDbType.NVarChar, 255)).Value = f.vystupnaKontrolaScr1.txtScrSpektrumVystupBezStitok.Text;
                            sqlComm.Parameters.Add(new SqlParameter("@vl_nolabel", SqlDbType.NVarChar, 255)).Value = f.vystupnaKontrolaScr1.txtScrVlVystupBezStitok.Text;
                            sqlComm.Parameters.Add(new SqlParameter("@snapshot_nolabel", SqlDbType.NVarChar, 255)).Value = f.vystupnaKontrolaScr1.txtScrSnapshotVystupBezStitok.Text;
                            sqlComm.Parameters.Add(new SqlParameter("@vlhkost", SqlDbType.VarChar, 255)).Value = f.vystupnaKontrolaScr1.txtVlhkostVzduchuVystup.Text;
                            sqlComm.Parameters.Add(new SqlParameter("@teplota", SqlDbType.VarChar, 255)).Value = f.vystupnaKontrolaScr1.txtTeplotaPracoviskaVystup.Text;
                            sqlComm.Parameters.Add(new SqlParameter("@tlak", SqlDbType.VarChar, 255)).Value = f.vystupnaKontrolaScr1.txtTlakVystup.Text;
                            sqlComm.Parameters.Add(new SqlParameter("@product", SqlDbType.VarChar, 255)).Value = f.ovladaciPanelObjednavkyNEW1.Produkt.Text;
                            sqlComm.Parameters.Add(new SqlParameter("@Zakaznik", SqlDbType.VarChar, 255)).Value = f.ovladaciPanelObjednavkyNEW1.Zakaznik.Text;
                            sqlComm.Parameters.Add(new SqlParameter("@zakaznicka_objednavka", SqlDbType.VarChar, 255)).Value = f.ovladaciPanelObjednavkyNEW1.ZakObjednavka.Text;
                            sqlComm.Parameters.Add(new SqlParameter("@PopisChyby", SqlDbType.VarChar, 255)).Value = f.zaznamChyb.txtPopisChyby.Text;
                            sqlComm.Parameters.Add(new SqlParameter("@ChybaKto1", SqlDbType.VarChar, 50)).Value = f.zaznamChyb.comboTree1.Text;
                            sqlComm.Parameters.Add(new SqlParameter("@ChybaKto2", SqlDbType.VarChar, 50)).Value = f.zaznamChyb.comboTree2.Text;
                            string time = f.zaznamChyb.textBoxX2.Text;
                            var result = Convert.ToDateTime(time);
                            string test = result.ToString("hh:mm:ss", CultureInfo.CurrentCulture);
                            sqlComm.Parameters.Add(new SqlParameter("@CasChybySpolu", SqlDbType.Time, 7)).Value = f.zaznamChyb.textBoxX2.Text;
                            sqlComm.Parameters.Add(new SqlParameter("@ChybuZapisal", SqlDbType.VarChar, 50)).Value = f.zaznamChyb.txtZapisal.Text;

                            if (string.IsNullOrWhiteSpace(f.zaznamChyb.txtZapisalDna.Text))
                            {
                                sqlComm.Parameters.Add(new SqlParameter("@ChybuZapisalKedy", SqlDbType.DateTime, 0)).Value = DBNull.Value;
                            }
                            else
                            {
                                sqlComm.Parameters.Add(new SqlParameter("@ChybuZapisalKedy", SqlDbType.DateTime, 0)).Value = f.zaznamChyb.txtZapisalDna.Text;
                            }

                            sqlConn.Open();
                            sqlComm.ExecuteNonQuery();
                            sqlComm = sqlConn.CreateCommand();
                            sqlComm.CommandText = @"SELECT COUNT (CisloZakazky) FROM tblZakazky WHERE CisloZakazky = '" + f.ovladaciPanelObjednavkyNEW1.comboBoxEx1.Text + "' ";

                            int temp = Convert.ToInt32(sqlComm.ExecuteScalar().ToString());
                            if (temp > 0)
                            {
                                sqlComm.CommandText = @"UPDATE tblZakazky SET CisloZakazky=@CisloZakazky,ZakazkaVytvoril=@ZakazkaVytvoril,ZakazkaVytvorilKedy=@ZakazkaVytvorilKedy,StavZakazky=@StavZakazky,Zakaznik=@Zakaznik,ZakaznickaObjednavka=@ZakaznickaObjednavka WHERE CisloZakazky=@CisloZakazky";
                                sqlComm.Parameters.AddWithValue("@CisloZakazky", f.ovladaciPanelObjednavkyNEW1.comboBoxEx1.Text);
                                sqlComm.Parameters.AddWithValue("@ZakazkaVytvoril", f.ovladaciPanelObjednavkyNEW1.txtObjVytvoril.Text);
                                sqlComm.Parameters.AddWithValue("@ZakazkaVytvorilKedy", Convert.ToDateTime(f.ovladaciPanelObjednavkyNEW1.txtObjVytvorilKedy.Text));
                                sqlComm.Parameters.AddWithValue("@StavZakazky", "Rozpracované");
                                sqlComm.Parameters.AddWithValue("@Zakaznik", f.ovladaciPanelObjednavkyNEW1.Zakaznik.Text);
                                sqlComm.Parameters.AddWithValue("@ZakaznickaObjednavka", f.ovladaciPanelObjednavkyNEW1.ZakObjednavka.Text);
                                sqlComm.ExecuteNonQuery();
                                sqlConn.Close();
                            }
                            else
                            {
                                sqlComm = sqlConn.CreateCommand();
                                sqlComm.CommandText = @"INSERT INTO tblZakazky (CisloZakazky,ZakazkaVytvoril,ZakazkaVytvorilKedy,StavZakazky,Zakaznik,ZakaznickaObjednavka) VALUES (@CisloZakazky,@ZakazkaVytvoril,@ZakazkaVytvorilKedy,@StavZakazky,@Zakaznik,@ZakaznickaObjednavka)";
                                sqlComm.Parameters.Add(new SqlParameter("@CisloZakazky", SqlDbType.VarChar, 255)).Value = f.ovladaciPanelObjednavkyNEW1.comboBoxEx1.Text;
                                sqlComm.Parameters.Add(new SqlParameter("@ZakazkaVytvoril", SqlDbType.VarChar, 255)).Value = f.ovladaciPanelObjednavkyNEW1.txtObjVytvoril.Text;
                                sqlComm.Parameters.Add(new SqlParameter("@ZakazkaVytvorilKedy", SqlDbType.DateTime, 0)).Value = f.ovladaciPanelObjednavkyNEW1.txtObjVytvorilKedy.Text;
                                sqlComm.Parameters.Add(new SqlParameter("@StavZakazky", SqlDbType.NChar, 25)).Value = "Rozpracované";
                                sqlComm.Parameters.Add(new SqlParameter("@Zakaznik", SqlDbType.VarChar, 255)).Value = f.ovladaciPanelObjednavkyNEW1.Zakaznik.Text;
                                sqlComm.Parameters.Add(new SqlParameter("@ZakaznickaObjednavka", SqlDbType.VarChar, 255)).Value = f.ovladaciPanelObjednavkyNEW1.ZakObjednavka.Text;
                                sqlComm.ExecuteNonQuery();
                                sqlConn.Close();
                            }




                        }

                        Class1.update_grid_konektorovanie(ParentForm, false);
                        Class1.update_grid_zniceny_material(ParentForm, false);

                        Class1.set_sort_main_form(); //nastavi zobrazenie v hlavnom formulari
                        if (close_save_status == 0) // 0 = zavrie formular, 1= ulozi ale nezavrie formular
                        {
                            f.Close();
                        }
                    }
                }
                #endregion konektorovanie

                else if (form == "Konektorovanie2")
                {
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Naozaj chcete zavrieť? nič nebude uložené!", "Zatvoriť",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                 == DialogResult.Yes)
            {
                ((Form)this.TopLevelControl).Close();
            }
        }

        private void buttonItem2_Click(object sender, EventArgs e) //delete record
        {
            ComboBoxEx Objednavka = Parent.Parent.Controls.Find("comboObjednavka", true).FirstOrDefault() as ComboBoxEx;
            MaskedTextBoxAdv PoradoveCislo = Parent.Parent.Controls.Find("PoradoveCislo", true).FirstOrDefault() as MaskedTextBoxAdv;
            TextBoxX Rework = Parent.Parent.Controls.Find("txtRework", true).FirstOrDefault() as TextBoxX;
            string tabulka = "tbl" + Convert.ToString(Konektorovanie.ActiveForm.Text).Replace("-", "_");

            Class1.delete_record(Convert.ToString(Objednavka.Text), PoradoveCislo.Text, tabulka, Konektorovanie.ActiveForm, Convert.ToInt32(Rework.Text));
        }

        private void btnChybne_Click(object sender, EventArgs e)
        {

            ComboBoxEx Objednavka = Parent.Parent.Controls.Find("comboObjednavka", true).FirstOrDefault() as ComboBoxEx;
            MaskedTextBoxAdv PoradoveCislo = Parent.Parent.Controls.Find("PoradoveCislo", true).FirstOrDefault() as MaskedTextBoxAdv;
            ComboBoxEx Zakazka = Parent.Parent.Controls.Find("comboBoxEx1", true).FirstOrDefault() as ComboBoxEx;
            TextBoxX Rework = Parent.Parent.Controls.Find("txtRework", true).FirstOrDefault() as TextBoxX;
            ComboBoxEx chyba_kto1 = Parent.Parent.Controls.Find("comboTree1", true).FirstOrDefault() as ComboBoxEx;
            ComboBoxEx chyba_kto2 = Parent.Parent.Controls.Find("comboTree2", true).FirstOrDefault() as ComboBoxEx;
            TextBoxX cas = Parent.Parent.Controls.Find("textBoxX2", true).FirstOrDefault() as TextBoxX;
            RichTextBoxEx popis_chyby = Parent.Parent.Controls.Find("txtPopisChyby", true).FirstOrDefault() as RichTextBoxEx;
            TextBoxX zakaznik = Parent.Parent.Controls.Find("zakaznik", true).FirstOrDefault() as TextBoxX;
            SuperTabControl tab_form = Parent.Parent.Controls.Find("tabFormulare", true).FirstOrDefault() as SuperTabControl;

            if (string.IsNullOrWhiteSpace(popis_chyby.Text) || string.IsNullOrWhiteSpace(chyba_kto1.Text) || string.IsNullOrWhiteSpace(chyba_kto2.Text) || string.IsNullOrWhiteSpace(cas.Text))
            {
                MessageBox.Show("Musíš vyplniť všetky povinné polia v karte Záznam chýb!");
                tab_form.SelectedTabIndex = 1;
                return;
            }

            Class1.send_message_chyba(Objednavka.Text + "/" + PoradoveCislo.Text, Convert.ToString(Zakazka.Text), Rework.Text, textBoxItem2.Text, prihlaseny, chyba_kto1.Text + "/" + chyba_kto2.Text, cas.Text, popis_chyby.Text, zakaznik.Text);
            comboBoxItem3.Text = "CHYBA";
            comboBoxItem3.Refresh();
        }

        private void OvladaciPanelFormulare_Load(object sender, EventArgs e)
        {

        }

        private void btnDuplikovat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Naozaj chcete duplikovať túto objednávku ?", "Duplikácia",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {

                MaskedTextBoxAdv PoradoveCislo = Parent.Parent.Controls.Find("PoradoveCislo", true).FirstOrDefault() as MaskedTextBoxAdv;
                ComboBoxEx Objednavka = Parent.Parent.Controls.Find("comboObjednavka", true).FirstOrDefault() as ComboBoxEx;
                string obj = Objednavka.Text;
                int pocet_zaznamov = Convert.ToInt32(txtPocetDuplikatov.Text);
                int poradove_cislo = Convert.ToInt32(PoradoveCislo.Text);

                if (string.IsNullOrWhiteSpace(txtPocetDuplikatov.Text))
                {
                    MessageBox.Show("Musíš vyplniť počet duplikátov");
                    return;
                }
                Form currentForm = Form.ActiveForm;
                string form = Convert.ToString(currentForm.Name);

                try
                {
                    Konektorovanie f = (Konektorovanie)Application.OpenForms[1];
                    for (int i = 0; i <= pocet_zaznamov; i++)
                    {

                        if (form == "Konektorovanie")
                        {

                            #region konektorovanie

                            string connectionString = Class1.dbs_nastavenia("DBS_connection_string");
                            SqlConnection sqlConn = new SqlConnection(connectionString);
                            SqlCommand sqlComm = new SqlCommand();
                            sqlComm = sqlConn.CreateCommand();
                            int poradove_cislo_final = i + poradove_cislo;
                            sqlComm.CommandText = @"INSERT INTO tblObjednavky (SylexObjednavka,Zakazka,Snimac,PnVlakna,LotVlakna,ObjVytvoril,ObjVytvorilDatum,PopisVlakna,Rework,StavObjednavky,FBGSSN,spektrum_label,vl_label,snapshot_label,spektrum_nolabel,vl_nolabel,snapshot_nolabel,vlhkost,teplota,tlak,product,Zakaznik,zakaznicka_objednavka,PopisChyby,ChybaKto1,ChybaKto2,CasChybySpolu,ChybuZapisal,ChybuZapisalKedy,Formular) VALUES (@SylexObjednavka,@Zakazka,@Snimac,@PnVlakna,@LotVlakna,@ObjVytvoril,@ObjVytvorilDatum,@PopisVlakna,@Rework,@StavObjednavky,@FBGSSN,@spektrum_label,@vl_label,@snapshot_label,@spektrum_nolabel,@vl_nolabel,@snapshot_nolabel,@vlhkost,@teplota,@tlak,@product,@Zakaznik,@zakaznicka_objednavka,@PopisChyby,@ChybaKto1,@ChybaKto2,@CasChybySpolu,@ChybuZapisal,@ChybuZapisalKedy,@Formular)";
                            sqlComm.Parameters.Add(new SqlParameter("@SylexObjednavka", SqlDbType.VarChar, 255)).Value = f.ovladaciPanelObjednavkyNEW1.comboObjednavka.Text + "/" + poradove_cislo_final.ToString("D4");
                            sqlComm.Parameters.Add(new SqlParameter("@Zakazka", SqlDbType.NChar, 10)).Value = f.ovladaciPanelObjednavkyNEW1.comboBoxEx1.Text;
                            sqlComm.Parameters.Add(new SqlParameter("@Formular", SqlDbType.NVarChar, 255)).Value = comboBoxItem4.Text;
                            sqlComm.Parameters.Add(new SqlParameter("@Snimac", SqlDbType.NVarChar, 255)).Value = textBoxItem2.Text;
                            sqlComm.Parameters.Add(new SqlParameter("@PnVlakna", SqlDbType.VarChar, 255)).Value = f.ovladaciPanelObjednavkyNEW1.txtPNvlakna.Text;
                            sqlComm.Parameters.Add(new SqlParameter("@LotVlakna", SqlDbType.VarChar, 255)).Value = f.ovladaciPanelObjednavkyNEW1.txtLotVlakna.Text;
                            sqlComm.Parameters.Add(new SqlParameter("@ObjVytvoril", SqlDbType.VarChar, 255)).Value = f.ovladaciPanelObjednavkyNEW1.txtObjVytvoril.Text;
                            sqlComm.Parameters.Add(new SqlParameter("@ObjVytvorilDatum", SqlDbType.DateTime, 0)).Value = f.ovladaciPanelObjednavkyNEW1.txtObjVytvorilKedy.Text;
                            sqlComm.Parameters.Add(new SqlParameter("@PopisVlakna", SqlDbType.VarChar, 255)).Value = f.ovladaciPanelObjednavkyNEW1.txtPopisVlakna.Text;
                            sqlComm.Parameters.Add(new SqlParameter("@Rework", SqlDbType.VarChar, 255)).Value = f.ovladaciPanelObjednavkyNEW1.txtRework.Text;
                            sqlComm.Parameters.Add(new SqlParameter("@StavObjednavky", SqlDbType.VarChar, 255)).Value = comboBoxItem3.Text;
                            sqlComm.Parameters.Add(new SqlParameter("@FBGSSN", SqlDbType.VarChar, 255)).Value = f.ovladaciPanelObjednavkyNEW1.txtFBGSSN.Text;
                            sqlComm.Parameters.Add(new SqlParameter("@spektrum_label", SqlDbType.NVarChar, 255)).Value = f.vystupnaKontrolaScr1.txtScrSpektrumVystupStitok.Text;
                            sqlComm.Parameters.Add(new SqlParameter("@vl_label", SqlDbType.NVarChar, 255)).Value = f.vystupnaKontrolaScr1.txtScrVlVystupStitok.Text;
                            sqlComm.Parameters.Add(new SqlParameter("@snapshot_label", SqlDbType.NVarChar, 255)).Value = f.vystupnaKontrolaScr1.txtScrSnapshotVystupStitok.Text;
                            sqlComm.Parameters.Add(new SqlParameter("@spektrum_nolabel", SqlDbType.NVarChar, 255)).Value = f.vystupnaKontrolaScr1.txtScrSpektrumVystupBezStitok.Text;
                            sqlComm.Parameters.Add(new SqlParameter("@vl_nolabel", SqlDbType.NVarChar, 255)).Value = f.vystupnaKontrolaScr1.txtScrVlVystupBezStitok.Text;
                            sqlComm.Parameters.Add(new SqlParameter("@snapshot_nolabel", SqlDbType.NVarChar, 255)).Value = f.vystupnaKontrolaScr1.txtScrSnapshotVystupBezStitok.Text;
                            sqlComm.Parameters.Add(new SqlParameter("@vlhkost", SqlDbType.VarChar, 255)).Value = f.vystupnaKontrolaScr1.txtVlhkostVzduchuVystup.Text;
                            sqlComm.Parameters.Add(new SqlParameter("@teplota", SqlDbType.VarChar, 255)).Value = f.vystupnaKontrolaScr1.txtTeplotaPracoviskaVystup.Text;
                            sqlComm.Parameters.Add(new SqlParameter("@tlak", SqlDbType.VarChar, 255)).Value = f.vystupnaKontrolaScr1.txtTlakVystup.Text;
                            sqlComm.Parameters.Add(new SqlParameter("@product", SqlDbType.VarChar, 255)).Value = f.ovladaciPanelObjednavkyNEW1.Produkt.Text;
                            sqlComm.Parameters.Add(new SqlParameter("@Zakaznik", SqlDbType.VarChar, 255)).Value = f.ovladaciPanelObjednavkyNEW1.Zakaznik.Text;
                            sqlComm.Parameters.Add(new SqlParameter("@zakaznicka_objednavka", SqlDbType.VarChar, 255)).Value = f.ovladaciPanelObjednavkyNEW1.ZakObjednavka.Text;
                            sqlComm.Parameters.Add(new SqlParameter("@PopisChyby", SqlDbType.VarChar, 255)).Value = f.zaznamChyb.txtPopisChyby.Text;
                            sqlComm.Parameters.Add(new SqlParameter("@ChybaKto1", SqlDbType.VarChar, 50)).Value = f.zaznamChyb.comboTree1.Text;
                            sqlComm.Parameters.Add(new SqlParameter("@ChybaKto2", SqlDbType.VarChar, 50)).Value = f.zaznamChyb.comboTree2.Text;
                            string time = f.zaznamChyb.textBoxX2.Text;
                            var result = Convert.ToDateTime(time);
                            string test = result.ToString("hh:mm:ss", CultureInfo.CurrentCulture);
                            sqlComm.Parameters.Add(new SqlParameter("@CasChybySpolu", SqlDbType.Time, 7)).Value = f.zaznamChyb.textBoxX2.Text;
                            sqlComm.Parameters.Add(new SqlParameter("@ChybuZapisal", SqlDbType.VarChar, 50)).Value = f.zaznamChyb.txtZapisal.Text;

                            if (string.IsNullOrWhiteSpace(f.zaznamChyb.txtZapisalDna.Text))
                            {
                                sqlComm.Parameters.Add(new SqlParameter("@ChybuZapisalKedy", SqlDbType.DateTime, 0)).Value = DBNull.Value;
                            }
                            else
                            {
                                sqlComm.Parameters.Add(new SqlParameter("@ChybuZapisalKedy", SqlDbType.DateTime, 0)).Value = f.zaznamChyb.txtZapisalDna.Text;
                            }

                            sqlConn.Open();
                            sqlComm.ExecuteNonQuery();


                            ComboBoxEx Zakazka = Parent.Parent.Controls.Find("comboBoxEx1", true).FirstOrDefault() as ComboBoxEx;
                            TextBoxX Rework = Parent.Parent.Controls.Find("txtRework", true).FirstOrDefault() as TextBoxX;
                            TextBoxX pocet_mriezok = Parent.Parent.Controls.Find("textBoxX1", true).FirstOrDefault() as TextBoxX;
                            ComboBoxEx chyba_kto1 = Parent.Parent.Controls.Find("comboTree1", true).FirstOrDefault() as ComboBoxEx;
                            ComboBoxEx chyba_kto2 = Parent.Parent.Controls.Find("comboTree2", true).FirstOrDefault() as ComboBoxEx;
                            TextBoxX cas = Parent.Parent.Controls.Find("textBoxX2", true).FirstOrDefault() as TextBoxX;
                            RichTextBoxEx popis_chyby = Parent.Parent.Controls.Find("txtPopisChyby", true).FirstOrDefault() as RichTextBoxEx;
                            TextBoxX zakaznik = Parent.Parent.Controls.Find("zakaznik", true).FirstOrDefault() as TextBoxX;
                            SuperGridControl grid_kon = Parent.Parent.Controls.Find("superGridControl1", true).FirstOrDefault() as SuperGridControl;


                            if (string.IsNullOrWhiteSpace(Objednavka.Text))
                            {
                                MessageBox.Show("Najprv zadaj Objednávku");
                                return;
                            }
                            if (string.IsNullOrWhiteSpace(Zakazka.Text))
                            {
                                MessageBox.Show("Najprv zadaj Zákazku");
                                return;
                            }
                            if (string.IsNullOrWhiteSpace(pocet_mriezok.Text))
                            {
                                MessageBox.Show("Nenapísala si počet mriežok, nemôžem vytvoriť tabuľku");
                                return;
                            }



                            if (poradove_cislo_final > 1)
                            {
                                for (int i2 = 1; i2 <= Convert.ToInt32(pocet_mriezok.Text); i2++)
                                {
                                    SqlCommand sqlCommKonektorovanie = new SqlCommand();
                                    sqlCommKonektorovanie = sqlConn.CreateCommand();
                                    sqlCommKonektorovanie.CommandText = @"INSERT INTO tblKonektorovanie (CisloZakazky,Objednavka,FBGnr,rework) VALUES (@CisloZakazky,@Objednavka,@FBGnr,@rework)";
                                    sqlCommKonektorovanie.Parameters.Add(new SqlParameter("@CisloZakazky", SqlDbType.Int)).Value = Zakazka.Text;
                                    sqlCommKonektorovanie.Parameters.Add(new SqlParameter("@Objednavka", SqlDbType.NVarChar, 50)).Value = Objednavka.Text + "/" + poradove_cislo_final.ToString("D4");
                                    sqlCommKonektorovanie.Parameters.Add(new SqlParameter("@FBGnr", SqlDbType.NChar, 10)).Value = i2;
                                    sqlCommKonektorovanie.Parameters.Add(new SqlParameter("@rework", SqlDbType.NChar, 10)).Value = Rework.Text;
                                    sqlCommKonektorovanie.ExecuteNonQuery();
                                }
                                sqlConn.Close();
                            }

                        }
                        #endregion konektorovanie

                    }
                    Class1.set_sort_main_form(); //nastavi zobrazenie v hlavnom formulari
                    f.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }

        public void btnNext_Click(object sender, EventArgs e)
        {
            ComboBoxEx Objednavka = Parent.Parent.Controls.Find("comboObjednavka", true).FirstOrDefault() as ComboBoxEx;
            MaskedTextBoxAdv PoradoveCislo = Parent.Parent.Controls.Find("PoradoveCislo", true).FirstOrDefault() as MaskedTextBoxAdv;
            SuperGridControl grid_kon = Parent.Parent.Controls.Find("superGridControl1", true).FirstOrDefault() as SuperGridControl;

            close_save_status = 1;
            btnSaveClose_Click_1(sender, e);
            close_save_status = 0;

            int pocet_objednavok = Class1.count_orders(Objednavka.Text);
            int por_cislo = Convert.ToInt32(PoradoveCislo.Text);
            int aktualna_objednavka_pc = Convert.ToInt32(por_cislo.ToString("D4"));
            int nasledujuca_objednavka = Convert.ToInt32((por_cislo + 1).ToString("D4"));
            if (nasledujuca_objednavka > pocet_objednavok)
            {
                nasledujuca_objednavka = Convert.ToInt32((1).ToString("D4"));
            }

            string objednavka_final = Objednavka.Text + "/" + Convert.ToString(nasledujuca_objednavka.ToString("D4"));

            Form currentForm = Form.ActiveForm;
            string form = currentForm.Name;
            if (form == "Konektorovanie")
            {
                #region konektorovanie
                Konektorovanie f = (Konektorovanie)Application.OpenForms[1];
                {
                    string zakazka = Convert.ToString(Properties.Settings.Default.CisloZakazky);
                    grid_kon.PrimaryGrid.Columns[1].FilterExpr = "[Objednavka] = '" + objednavka_final + "' & [Rework] = " + 0; //tabulka konektorovanie
                    f.zaznamChybMaterial.gridMaterialBom.PrimaryGrid.Columns[1].FilterExpr = "[objednavka] = '" + objednavka_final + "' & [Rework] = " + 0; //tabulka bom
                    using (SqlConnection connection = new SqlConnection(Class1.dbs_nastavenia("DBS_connection_string")))
                    {
                        SqlCommand command =
                        new SqlCommand("select * FROM tblObjednavky WHERE SylexObjednavka='" + objednavka_final + "' AND Rework=" + 0, connection);
                        connection.Open();

                        SqlDataReader read = command.ExecuteReader();

                        while (read.Read())
                        {
                            f.ovladaciPanelObjednavkyNEW1.comboObjednavka.Text = Class1.left((read["SylexObjednavka"].ToString()), 6);
                            f.ovladaciPanelObjednavkyNEW1.PoradoveCislo.Text = Class1.right((read["SylexObjednavka"].ToString()), 4);
                            f.ovladaciPanelObjednavkyNEW1.comboBoxEx1.Text = (read["Zakazka"].ToString());
                            f.ovladaciPanelFormulare1.comboBoxItem4.Text = (read["Formular"].ToString());
                            f.ovladaciPanelFormulare1.textBoxItem2.Text = (read["Snimac"].ToString());
                            f.ovladaciPanelObjednavkyNEW1.txtPNvlakna.Text = (read["PnVlakna"].ToString());
                            f.ovladaciPanelObjednavkyNEW1.txtLotVlakna.Text = (read["LotVlakna"].ToString());
                            f.ovladaciPanelObjednavkyNEW1.txtObjVytvoril.Text = (read["ObjVytvoril"].ToString());
                            f.ovladaciPanelObjednavkyNEW1.txtObjVytvorilKedy.Text = (read["ObjVytvorilDatum"].ToString());
                            f.ovladaciPanelObjednavkyNEW1.txtPopisVlakna.Text = (read["PopisVlakna"].ToString());
                            f.ovladaciPanelObjednavkyNEW1.txtRework.Text = (read["Rework"].ToString());
                            f.ovladaciPanelFormulare1.comboBoxItem3.Text = (read["StavObjednavky"].ToString());
                            f.ovladaciPanelObjednavkyNEW1.txtFBGSSN.Text = (read["FBGSSN"].ToString());
                            f.vystupnaKontrolaScr1.txtScrSpektrumVystupStitok.Text = (read["spektrum_label"].ToString());
                            f.vystupnaKontrolaScr1.txtScrVlVystupStitok.Text = (read["vl_label"].ToString());
                            f.vystupnaKontrolaScr1.txtScrSnapshotVystupStitok.Text = (read["snapshot_label"].ToString());
                            f.vystupnaKontrolaScr1.txtScrSpektrumVystupBezStitok.Text = (read["spektrum_nolabel"].ToString());
                            f.vystupnaKontrolaScr1.txtScrVlVystupBezStitok.Text = (read["vl_nolabel"].ToString());
                            f.vystupnaKontrolaScr1.txtScrSnapshotVystupBezStitok.Text = (read["snapshot_nolabel"].ToString());
                            f.vystupnaKontrolaScr1.txtVlhkostVzduchuVystup.Text = (read["vlhkost"].ToString());
                            f.vystupnaKontrolaScr1.txtTeplotaPracoviskaVystup.Text = (read["teplota"].ToString());
                            f.vystupnaKontrolaScr1.txtTlakVystup.Text = (read["tlak"].ToString());
                            f.ovladaciPanelObjednavkyNEW1.Produkt.Text = (read["Product"].ToString());
                            f.ovladaciPanelObjednavkyNEW1.Zakaznik.Text = (read["Zakaznik"].ToString());
                            f.ovladaciPanelObjednavkyNEW1.ZakObjednavka.Text = (read["zakaznicka_objednavka"].ToString());
                            f.zaznamChyb.txtPopisChyby.Text = (read["PopisChyby"].ToString());
                            f.zaznamChyb.comboTree1.Text = (read["ChybaKto1"].ToString());
                            f.zaznamChyb.comboTree2.Text = (read["ChybaKto2"].ToString());
                            f.zaznamChyb.textBoxX2.Text = (read["CasChybySpolu"].ToString());
                            f.zaznamChyb.txtZapisal.Text = (read["ChybuZapisal"].ToString());
                            f.zaznamChyb.txtZapisalDna.Text = (read["ChybuZapisalKedy"].ToString());

                        }
                        read.Close();
                    }
                }


                #endregion konektorovanie
            }


        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {

            ComboBoxEx Objednavka = Parent.Parent.Controls.Find("comboObjednavka", true).FirstOrDefault() as ComboBoxEx;
            MaskedTextBoxAdv PoradoveCislo = Parent.Parent.Controls.Find("PoradoveCislo", true).FirstOrDefault() as MaskedTextBoxAdv;
            SuperGridControl grid_kon = Parent.Parent.Controls.Find("superGridControl1", true).FirstOrDefault() as SuperGridControl;

            close_save_status = 1;
            btnSaveClose_Click_1(sender, e);
            close_save_status = 0;

            int pocet_objednavok = Class1.count_orders(Objednavka.Text);
            int por_cislo = Convert.ToInt32(PoradoveCislo.Text);
            int aktualna_objednavka_pc = Convert.ToInt32(por_cislo.ToString("D4"));
            int nasledujuca_objednavka = Convert.ToInt32((por_cislo - 1).ToString("D4"));
            if (nasledujuca_objednavka == 0)
            {
                nasledujuca_objednavka = Convert.ToInt32((pocet_objednavok).ToString("D4"));
            }

            string objednavka_final = Objednavka.Text + "/" + Convert.ToString(nasledujuca_objednavka.ToString("D4"));

            Form currentForm = Form.ActiveForm;
            string form = currentForm.Name;
            if (form == "Konektorovanie")
            {
                #region konektorovanie
                Konektorovanie f = (Konektorovanie)Application.OpenForms[1];
                {
                    string zakazka = Convert.ToString(Properties.Settings.Default.CisloZakazky);
                    grid_kon.PrimaryGrid.Columns[1].FilterExpr = "[Objednavka] = '" + objednavka_final + "' & [Rework] = " + 0; //tabulka konektorovanie
                    f.zaznamChybMaterial.gridMaterialBom.PrimaryGrid.Columns[1].FilterExpr = "[objednavka] = '" + objednavka_final + "' & [Rework] = " + 0; //tabulka bom
                    using (SqlConnection connection = new SqlConnection(Class1.dbs_nastavenia("DBS_connection_string")))
                    {
                        SqlCommand command =
                        new SqlCommand("select * FROM tblObjednavky WHERE SylexObjednavka='" + objednavka_final + "' AND Rework=" + 0, connection);
                        connection.Open();

                        SqlDataReader read = command.ExecuteReader();

                        while (read.Read())
                        {
                            f.ovladaciPanelObjednavkyNEW1.comboObjednavka.Text = Class1.left((read["SylexObjednavka"].ToString()), 6);
                            f.ovladaciPanelObjednavkyNEW1.PoradoveCislo.Text = Class1.right((read["SylexObjednavka"].ToString()), 4);
                            f.ovladaciPanelObjednavkyNEW1.comboBoxEx1.Text = (read["Zakazka"].ToString());
                            f.ovladaciPanelFormulare1.comboBoxItem4.Text = (read["Formular"].ToString());
                            f.ovladaciPanelFormulare1.textBoxItem2.Text = (read["Snimac"].ToString());
                            f.ovladaciPanelObjednavkyNEW1.txtPNvlakna.Text = (read["PnVlakna"].ToString());
                            f.ovladaciPanelObjednavkyNEW1.txtLotVlakna.Text = (read["LotVlakna"].ToString());
                            f.ovladaciPanelObjednavkyNEW1.txtObjVytvoril.Text = (read["ObjVytvoril"].ToString());
                            f.ovladaciPanelObjednavkyNEW1.txtObjVytvorilKedy.Text = (read["ObjVytvorilDatum"].ToString());
                            f.ovladaciPanelObjednavkyNEW1.txtPopisVlakna.Text = (read["PopisVlakna"].ToString());
                            f.ovladaciPanelObjednavkyNEW1.txtRework.Text = (read["Rework"].ToString());
                            f.ovladaciPanelFormulare1.comboBoxItem3.Text = (read["StavObjednavky"].ToString());
                            f.ovladaciPanelObjednavkyNEW1.txtFBGSSN.Text = (read["FBGSSN"].ToString());
                            f.vystupnaKontrolaScr1.txtScrSpektrumVystupStitok.Text = (read["spektrum_label"].ToString());
                            f.vystupnaKontrolaScr1.txtScrVlVystupStitok.Text = (read["vl_label"].ToString());
                            f.vystupnaKontrolaScr1.txtScrSnapshotVystupStitok.Text = (read["snapshot_label"].ToString());
                            f.vystupnaKontrolaScr1.txtScrSpektrumVystupBezStitok.Text = (read["spektrum_nolabel"].ToString());
                            f.vystupnaKontrolaScr1.txtScrVlVystupBezStitok.Text = (read["vl_nolabel"].ToString());
                            f.vystupnaKontrolaScr1.txtScrSnapshotVystupBezStitok.Text = (read["snapshot_nolabel"].ToString());
                            f.vystupnaKontrolaScr1.txtVlhkostVzduchuVystup.Text = (read["vlhkost"].ToString());
                            f.vystupnaKontrolaScr1.txtTeplotaPracoviskaVystup.Text = (read["teplota"].ToString());
                            f.vystupnaKontrolaScr1.txtTlakVystup.Text = (read["tlak"].ToString());
                            f.ovladaciPanelObjednavkyNEW1.Produkt.Text = (read["Product"].ToString());
                            f.ovladaciPanelObjednavkyNEW1.Zakaznik.Text = (read["Zakaznik"].ToString());
                            f.ovladaciPanelObjednavkyNEW1.ZakObjednavka.Text = (read["zakaznicka_objednavka"].ToString());
                            f.zaznamChyb.txtPopisChyby.Text = (read["PopisChyby"].ToString());
                            f.zaznamChyb.comboTree1.Text = (read["ChybaKto1"].ToString());
                            f.zaznamChyb.comboTree2.Text = (read["ChybaKto2"].ToString());
                            f.zaznamChyb.textBoxX2.Text = (read["CasChybySpolu"].ToString());
                            f.zaznamChyb.txtZapisal.Text = (read["ChybuZapisal"].ToString());
                            f.zaznamChyb.txtZapisalDna.Text = (read["ChybuZapisalKedy"].ToString());

                        }
                        read.Close();
                    }
                }


                #endregion konektorovanie
            }


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            close_save_status = 1;
            btnSaveClose_Click_1(sender,e);
            close_save_status = 0;
        }
    }
}