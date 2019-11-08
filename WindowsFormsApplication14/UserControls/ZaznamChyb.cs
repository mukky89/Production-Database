using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;

namespace WindowsFormsApplication14.UserControls
{
    public partial class ZaznamChyb : UserControl
    {
        private UserControl FrmZaznamChyb;
        public ZaznamChyb()
        {
            InitializeComponent();
            FrmZaznamChyb = new UserControl();
        }
        string prihlaseny = Class1.prihlasovacie_meno;
        private void labelX5_Click(object sender, EventArgs e)
        {

        }

        private void txtPopisChyby_TextChanged(object sender, EventArgs e)
        {
            txtZapisal.Text = prihlaseny;
            txtZapisalDna.Text = DateTime.Now.ToString();
        }

        private void txtPopisChyby_Enter(object sender, EventArgs e)
        {
            //nacitanie materialov
            ComboBoxEx Objednavka = Parent.Parent.Parent.Parent.Parent.Parent.Parent.Controls.Find("comboObjednavka", true).FirstOrDefault() as ComboBoxEx;
            ComboBoxEx Zakazka = Parent.Parent.Parent.Parent.Parent.Parent.Parent.Controls.Find("comboBoxEx1", true).FirstOrDefault() as ComboBoxEx;
            MaskedTextBoxAdv PoradoveCislo = Parent.Parent.Parent.Parent.Parent.Parent.Parent.Controls.Find("PoradoveCislo", true).FirstOrDefault() as MaskedTextBoxAdv;
            TextBoxX rework = Parent.Parent.Parent.Parent.Parent.Parent.Parent.Controls.Find("txtRework", true).FirstOrDefault() as TextBoxX;
            string objednavka = Objednavka.Text + "/" + PoradoveCislo.Text;
            Class1.load_materials_to_zniceny_material(Convert.ToInt32(Objednavka.Text), objednavka, Convert.ToInt32(Zakazka.Text), Convert.ToInt32(rework.Text));
            SuperGridControl gridMaterialBom = Parent.Parent.Parent.Parent.Parent.Parent.Parent.Controls.Find("gridMaterialBom", true).FirstOrDefault() as SuperGridControl;
            gridMaterialBom.Refresh();
            gridMaterialBom.PrimaryGrid.EnableFiltering = true;
            gridMaterialBom.PrimaryGrid.EnableColumnFiltering = true;
            gridMaterialBom.PrimaryGrid.EnableRowFiltering = true;
            gridMaterialBom.PrimaryGrid.Columns[1].EnableFiltering = Tbool.True;
            gridMaterialBom.PrimaryGrid.Columns[1].ShowPanelFilterExpr = Tbool.True;
            gridMaterialBom.PrimaryGrid.Columns[1].FilterExpr = "[objednavka] = '" + Objednavka.Text + "/" + PoradoveCislo.Text + "' & [Rework] = " + rework.Text; //tabulka bom
            Class1.update_grid_zniceny_material(ParentForm, true);
            gridMaterialBom.PrimaryGrid.InvalidateRender();
        }
    }
}
