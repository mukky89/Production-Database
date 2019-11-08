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
    public partial class VystupnaKontrolaScr : UserControl
    {
        public VystupnaKontrolaScr()
        {
            InitializeComponent();
        }

        private void btnVlozitHMS_Click(object sender, EventArgs e)
        {
            txtTeplotaPracoviskaVystup.Text = Class1.get_data_from_HMS().Item1;
            txtTlakVystup.Text = Class1.get_data_from_HMS().Item2;
            txtVlhkostVzduchuVystup.Text = Class1.get_data_from_HMS().Item3;
        }

        private void btnScrSpektrumVystupStitok_Click(object sender, EventArgs e)
        {
            ComboBoxEx Objednavka = Parent.Parent.Parent.Parent.Controls.Find("comboObjednavka", true).FirstOrDefault() as ComboBoxEx;
            MaskedTextBoxAdv PoradoveCislo = Parent.Parent.Parent.Parent.Controls.Find("PoradoveCislo", true).FirstOrDefault() as MaskedTextBoxAdv;
            ComboBoxEx Zakazka = Parent.Parent.Parent.Parent.Controls.Find("comboBoxEx1", true).FirstOrDefault() as ComboBoxEx;
            TextBoxX Rework = Parent.Parent.Parent.Parent.Controls.Find("txtRework", true).FirstOrDefault() as TextBoxX;
            TextBoxX zakzakaznicka_objednavka = Parent.Parent.Parent.Parent.Controls.Find("ZakObjednavka", true).FirstOrDefault() as TextBoxX;

            Class1.upload_screenshot_from_MOI(Objednavka.Text, PoradoveCislo.Text, Zakazka.Text, 1, Rework.Text, zakzakaznicka_objednavka.Text, this.txtScrSpektrumVystupStitok);
        }

        private void btnScrVlVystupStitok_Click(object sender, EventArgs e)
        {
            ComboBoxEx Objednavka = Parent.Parent.Parent.Parent.Controls.Find("comboObjednavka", true).FirstOrDefault() as ComboBoxEx;
            MaskedTextBoxAdv PoradoveCislo = Parent.Parent.Parent.Parent.Controls.Find("PoradoveCislo", true).FirstOrDefault() as MaskedTextBoxAdv;
            ComboBoxEx Zakazka = Parent.Parent.Parent.Parent.Controls.Find("comboBoxEx1", true).FirstOrDefault() as ComboBoxEx;
            TextBoxX Rework = Parent.Parent.Parent.Parent.Controls.Find("txtRework", true).FirstOrDefault() as TextBoxX;
            TextBoxX zakzakaznicka_objednavka = Parent.Parent.Parent.Parent.Controls.Find("ZakObjednavka", true).FirstOrDefault() as TextBoxX;
            TextBoxX txtScrVlVystupStitok = Parent.Parent.Parent.Parent.Controls.Find("txtScrVlVystupStitok", true).FirstOrDefault() as TextBoxX;

            Class1.upload_screenshot_from_MOI(Objednavka.Text, PoradoveCislo.Text, Zakazka.Text, 2, Rework.Text, zakzakaznicka_objednavka.Text, this.txtScrVlVystupStitok);
        }

        private void btnScrSnapshotVystupStitok_Click(object sender, EventArgs e)
        {
            ComboBoxEx Objednavka = Parent.Parent.Parent.Parent.Controls.Find("comboObjednavka", true).FirstOrDefault() as ComboBoxEx;
            MaskedTextBoxAdv PoradoveCislo = Parent.Parent.Parent.Parent.Controls.Find("PoradoveCislo", true).FirstOrDefault() as MaskedTextBoxAdv;
            ComboBoxEx Zakazka = Parent.Parent.Parent.Parent.Controls.Find("comboBoxEx1", true).FirstOrDefault() as ComboBoxEx;
            TextBoxX Rework = Parent.Parent.Parent.Parent.Controls.Find("txtRework", true).FirstOrDefault() as TextBoxX;
            TextBoxX zakzakaznicka_objednavka = Parent.Parent.Parent.Parent.Controls.Find("ZakObjednavka", true).FirstOrDefault() as TextBoxX;
            TextBoxX txtScrSnapshotVystupStitok = Parent.Parent.Parent.Parent.Controls.Find("txtScrSnapshotVystupStitok", true).FirstOrDefault() as TextBoxX;

            Class1.upload_snapshot_from_MOI(Objednavka.Text, PoradoveCislo.Text, Zakazka.Text, 1, Rework.Text, zakzakaznicka_objednavka.Text, txtScrSnapshotVystupStitok);
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            ComboBoxEx Objednavka = Parent.Parent.Parent.Parent.Controls.Find("comboObjednavka", true).FirstOrDefault() as ComboBoxEx;
            MaskedTextBoxAdv PoradoveCislo = Parent.Parent.Parent.Parent.Controls.Find("PoradoveCislo", true).FirstOrDefault() as MaskedTextBoxAdv;
            ComboBoxEx Zakazka = Parent.Parent.Parent.Parent.Controls.Find("comboBoxEx1", true).FirstOrDefault() as ComboBoxEx;
            TextBoxX Rework = Parent.Parent.Parent.Parent.Controls.Find("txtRework", true).FirstOrDefault() as TextBoxX;
            TextBoxX zakzakaznicka_objednavka = Parent.Parent.Parent.Parent.Controls.Find("ZakObjednavka", true).FirstOrDefault() as TextBoxX;
            TextBoxX txtScrSpektrumVystupStitok = Parent.Parent.Parent.Parent.Controls.Find("txtScrSpektrumVystupStitok", true).FirstOrDefault() as TextBoxX;
            TextBoxX txtScrVlVystupStitok = Parent.Parent.Parent.Parent.Controls.Find("txtScrVlVystupStitok", true).FirstOrDefault() as TextBoxX;
            TextBoxX txtScrSnapshotVystupStitok = Parent.Parent.Parent.Parent.Controls.Find("txtScrSnapshotVystupStitok", true).FirstOrDefault() as TextBoxX;


            Class1.upload_screenshot_from_MOI_automatically(Objednavka.Text, PoradoveCislo.Text, Zakazka.Text, 1, Rework.Text, zakzakaznicka_objednavka.Text, txtScrSpektrumVystupStitok, 1); //spektrum
            Class1.upload_screenshot_from_MOI_automatically(Objednavka.Text, PoradoveCislo.Text, Zakazka.Text, 2, Rework.Text, zakzakaznicka_objednavka.Text, txtScrVlVystupStitok, 2); //wavelength
            Class1.upload_snapshot_from_MOI_automatically(Objednavka.Text, PoradoveCislo.Text, Zakazka.Text, 1, Rework.Text, zakzakaznicka_objednavka.Text, txtScrSnapshotVystupStitok); //snap
        }

        private void btnScrSpektrumVystupBezStitok_Click(object sender, EventArgs e)
        {
            ComboBoxEx Objednavka = Parent.Parent.Parent.Parent.Controls.Find("comboObjednavka", true).FirstOrDefault() as ComboBoxEx;
            MaskedTextBoxAdv PoradoveCislo = Parent.Parent.Parent.Parent.Controls.Find("PoradoveCislo", true).FirstOrDefault() as MaskedTextBoxAdv;
            ComboBoxEx Zakazka = Parent.Parent.Parent.Parent.Controls.Find("comboBoxEx1", true).FirstOrDefault() as ComboBoxEx;
            TextBoxX Rework = Parent.Parent.Parent.Parent.Controls.Find("txtRework", true).FirstOrDefault() as TextBoxX;
            TextBoxX zakzakaznicka_objednavka = Parent.Parent.Parent.Parent.Controls.Find("ZakObjednavka", true).FirstOrDefault() as TextBoxX;
            TextBoxX txtScrSpektrumVystupBezStitok = Parent.Parent.Parent.Parent.Controls.Find("txtScrSpektrumVystupBezStitok", true).FirstOrDefault() as TextBoxX;

            Class1.upload_screenshot_from_MOI(Objednavka.Text, PoradoveCislo.Text, Zakazka.Text, 3, Rework.Text, zakzakaznicka_objednavka.Text, txtScrSpektrumVystupBezStitok);
        }

        private void btnScrVlVystupBezStitok_Click(object sender, EventArgs e)
        {
            ComboBoxEx Objednavka = Parent.Parent.Parent.Parent.Controls.Find("comboObjednavka", true).FirstOrDefault() as ComboBoxEx;
            MaskedTextBoxAdv PoradoveCislo = Parent.Parent.Parent.Parent.Controls.Find("PoradoveCislo", true).FirstOrDefault() as MaskedTextBoxAdv;
            ComboBoxEx Zakazka = Parent.Parent.Parent.Parent.Controls.Find("comboBoxEx1", true).FirstOrDefault() as ComboBoxEx;
            TextBoxX Rework = Parent.Parent.Parent.Parent.Controls.Find("txtRework", true).FirstOrDefault() as TextBoxX;
            TextBoxX zakzakaznicka_objednavka = Parent.Parent.Parent.Parent.Controls.Find("ZakObjednavka", true).FirstOrDefault() as TextBoxX;
            TextBoxX txtScrVlVystupBezStitok = Parent.Parent.Parent.Parent.Controls.Find("txtScrVlVystupBezStitok", true).FirstOrDefault() as TextBoxX;

            Class1.upload_screenshot_from_MOI(Objednavka.Text, PoradoveCislo.Text, Zakazka.Text, 4, Rework.Text, zakzakaznicka_objednavka.Text, txtScrVlVystupBezStitok);
        }

        private void btnScrSnapshotVystupBezStitok_Click(object sender, EventArgs e)
        {
            ComboBoxEx Objednavka = Parent.Parent.Parent.Parent.Controls.Find("comboObjednavka", true).FirstOrDefault() as ComboBoxEx;
            MaskedTextBoxAdv PoradoveCislo = Parent.Parent.Parent.Parent.Controls.Find("PoradoveCislo", true).FirstOrDefault() as MaskedTextBoxAdv;
            ComboBoxEx Zakazka = Parent.Parent.Parent.Parent.Controls.Find("comboBoxEx1", true).FirstOrDefault() as ComboBoxEx;
            TextBoxX Rework = Parent.Parent.Parent.Parent.Controls.Find("txtRework", true).FirstOrDefault() as TextBoxX;
            TextBoxX zakzakaznicka_objednavka = Parent.Parent.Parent.Parent.Controls.Find("ZakObjednavka", true).FirstOrDefault() as TextBoxX;
            TextBoxX txtScrSnapshotVystupBezStitok = Parent.Parent.Parent.Parent.Controls.Find("txtScrSnapshotVystupBezStitok", true).FirstOrDefault() as TextBoxX;

            Class1.upload_snapshot_from_MOI(Objednavka.Text, PoradoveCislo.Text, Zakazka.Text, 2, Rework.Text, zakzakaznicka_objednavka.Text, txtScrSnapshotVystupBezStitok);
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            ComboBoxEx Objednavka = Parent.Parent.Parent.Parent.Controls.Find("comboObjednavka", true).FirstOrDefault() as ComboBoxEx;
            MaskedTextBoxAdv PoradoveCislo = Parent.Parent.Parent.Parent.Controls.Find("PoradoveCislo", true).FirstOrDefault() as MaskedTextBoxAdv;
            ComboBoxEx Zakazka = Parent.Parent.Parent.Parent.Controls.Find("comboBoxEx1", true).FirstOrDefault() as ComboBoxEx;
            TextBoxX Rework = Parent.Parent.Parent.Parent.Controls.Find("txtRework", true).FirstOrDefault() as TextBoxX;
            TextBoxX zakzakaznicka_objednavka = Parent.Parent.Parent.Parent.Controls.Find("ZakObjednavka", true).FirstOrDefault() as TextBoxX;
            TextBoxX txtScrSpektrumVystupBezStitok = Parent.Parent.Parent.Parent.Controls.Find("txtScrSpektrumVystupBezStitok", true).FirstOrDefault() as TextBoxX;
            TextBoxX txtScrVlVystupBezStitok = Parent.Parent.Parent.Parent.Controls.Find("txtScrVlVystupBezStitok", true).FirstOrDefault() as TextBoxX;
            TextBoxX txtScrSnapshotVystupBezStitok = Parent.Parent.Parent.Parent.Controls.Find("txtScrSnapshotVystupBezStitok", true).FirstOrDefault() as TextBoxX;


            Class1.upload_screenshot_from_MOI_automatically(Objednavka.Text, PoradoveCislo.Text, Zakazka.Text, 3, Rework.Text, zakzakaznicka_objednavka.Text, txtScrSpektrumVystupBezStitok, 1);
            Class1.upload_screenshot_from_MOI_automatically(Objednavka.Text, PoradoveCislo.Text, Zakazka.Text, 4, Rework.Text, zakzakaznicka_objednavka.Text, txtScrVlVystupBezStitok, 2);
            Class1.upload_snapshot_from_MOI_automatically(Objednavka.Text, PoradoveCislo.Text, Zakazka.Text, 2, Rework.Text, zakzakaznicka_objednavka.Text, txtScrSnapshotVystupBezStitok);
        }

        private void txtScrSpektrumVystupStitok_Click(object sender, EventArgs e)
        {
            string imgPath = System.IO.Path.Combine(this.txtScrSpektrumVystupStitok.Text);
            if (System.IO.File.Exists(imgPath))
                System.Diagnostics.Process.Start(imgPath);
        }

        private void txtScrVlVystupStitok_Click(object sender, EventArgs e)
        {
            string imgPath = System.IO.Path.Combine(this.txtScrVlVystupStitok.Text);
            if (System.IO.File.Exists(imgPath))
                System.Diagnostics.Process.Start(imgPath);
        }

        private void txtScrSnapshotVystupStitok_Click(object sender, EventArgs e)
        {
            string imgPath = System.IO.Path.Combine(this.txtScrSnapshotVystupStitok.Text);
            if (System.IO.File.Exists(imgPath))
                System.Diagnostics.Process.Start(imgPath);
        }

        private void txtScrSpektrumVystupBezStitok_Click(object sender, EventArgs e)
        {
            string imgPath = System.IO.Path.Combine(this.txtScrSpektrumVystupBezStitok.Text);
            if (System.IO.File.Exists(imgPath))
                System.Diagnostics.Process.Start(imgPath);
        }

        private void txtScrVlVystupBezStitok_Click(object sender, EventArgs e)
        {
            string imgPath = System.IO.Path.Combine(this.txtScrVlVystupBezStitok.Text);
            if (System.IO.File.Exists(imgPath))
                System.Diagnostics.Process.Start(imgPath);
        }

        private void txtScrSnapshotVystupBezStitok_Click(object sender, EventArgs e)
        {
            string imgPath = System.IO.Path.Combine(this.txtScrSnapshotVystupBezStitok.Text);
            if (System.IO.File.Exists(imgPath))
                System.Diagnostics.Process.Start(imgPath);
        }
    }
}
