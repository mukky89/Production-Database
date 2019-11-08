namespace WindowsFormsApplication14
{
    partial class EditZakazky
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevComponents.DotNetBar.Rendering.SuperTabColorTable superTabColorTable1 = new DevComponents.DotNetBar.Rendering.SuperTabColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabControlBoxStateColorTable superTabControlBoxStateColorTable1 = new DevComponents.DotNetBar.Rendering.SuperTabControlBoxStateColorTable();
            this.superTabControl1 = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.CisloZakazky = new System.Windows.Forms.MaskedTextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tblZakazkyStavBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.novaDBcsharpDataSet = new WindowsFormsApplication14.novaDBcsharpDataSet();
            this.ZavrietZakazku = new System.Windows.Forms.Button();
            this.VytvorilDna = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.ZakazkuVytvoril = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.Zakaznik = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.ZakaznickaObjednavka = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.PoznamkyZakazky = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.UlozitZakazku = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.superTabItem1 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel2 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.superTabItem2 = new DevComponents.DotNetBar.SuperTabItem();
            this.requiredFieldValidator1 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.requiredFieldValidator2 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.requiredFieldValidator3 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.requiredFieldValidator4 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.tblZakazkyStavTableAdapter = new WindowsFormsApplication14.novaDBcsharpDataSetTableAdapters.tblZakazkyStavTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).BeginInit();
            this.superTabControl1.SuspendLayout();
            this.superTabControlPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblZakazkyStavBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.novaDBcsharpDataSet)).BeginInit();
            this.superTabControlPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // superTabControl1
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabControl1.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabControl1.ControlBox.MenuBox.Name = "";
            this.superTabControl1.ControlBox.Name = "";
            this.superTabControl1.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl1.ControlBox.MenuBox,
            this.superTabControl1.ControlBox.CloseBox});
            this.superTabControl1.Controls.Add(this.superTabControlPanel1);
            this.superTabControl1.Controls.Add(this.superTabControlPanel2);
            this.superTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControl1.Location = new System.Drawing.Point(0, 0);
            this.superTabControl1.Name = "superTabControl1";
            this.superTabControl1.ReorderTabsEnabled = true;
            this.superTabControl1.SelectedTabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.superTabControl1.SelectedTabIndex = 0;
            this.superTabControl1.Size = new System.Drawing.Size(427, 310);
            this.superTabControl1.TabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.superTabControl1.TabIndex = 11;
            this.superTabControl1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabItem1,
            this.superTabItem2});
            superTabControlBoxStateColorTable1.Background = System.Drawing.Color.White;
            superTabColorTable1.ControlBoxDefault = superTabControlBoxStateColorTable1;
            superTabColorTable1.InnerBorder = System.Drawing.Color.White;
            superTabColorTable1.SelectionMarker = System.Drawing.Color.White;
            this.superTabControl1.TabStripColor = superTabColorTable1;
            this.superTabControl1.Text = "superTabControl1";
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Controls.Add(this.button1);
            this.superTabControlPanel1.Controls.Add(this.CisloZakazky);
            this.superTabControlPanel1.Controls.Add(this.comboBox1);
            this.superTabControlPanel1.Controls.Add(this.ZavrietZakazku);
            this.superTabControlPanel1.Controls.Add(this.VytvorilDna);
            this.superTabControlPanel1.Controls.Add(this.ZakazkuVytvoril);
            this.superTabControlPanel1.Controls.Add(this.Zakaznik);
            this.superTabControlPanel1.Controls.Add(this.ZakaznickaObjednavka);
            this.superTabControlPanel1.Controls.Add(this.PoznamkyZakazky);
            this.superTabControlPanel1.Controls.Add(this.label10);
            this.superTabControlPanel1.Controls.Add(this.label9);
            this.superTabControlPanel1.Controls.Add(this.label8);
            this.superTabControlPanel1.Controls.Add(this.label7);
            this.superTabControlPanel1.Controls.Add(this.UlozitZakazku);
            this.superTabControlPanel1.Controls.Add(this.label5);
            this.superTabControlPanel1.Controls.Add(this.label4);
            this.superTabControlPanel1.Controls.Add(this.label3);
            this.superTabControlPanel1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 25);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(427, 285);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.superTabItem1;
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(310, 254);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 23);
            this.button1.TabIndex = 47;
            this.button1.Text = "Vymazať zákazku";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CisloZakazky
            // 
            this.CisloZakazky.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CisloZakazky.ForeColor = System.Drawing.Color.Red;
            this.CisloZakazky.Location = new System.Drawing.Point(111, 7);
            this.CisloZakazky.Mask = "00000";
            this.CisloZakazky.Name = "CisloZakazky";
            this.CisloZakazky.ReadOnly = true;
            this.CisloZakazky.Size = new System.Drawing.Size(133, 20);
            this.CisloZakazky.TabIndex = 46;
            this.CisloZakazky.ValidatingType = typeof(int);
            this.CisloZakazky.Leave += new System.EventHandler(this.CisloZakazky_Leave);
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tblZakazkyStavBindingSource, "StavZakazky", true));
            this.comboBox1.DataSource = this.tblZakazkyStavBindingSource;
            this.comboBox1.DisplayMember = "StavZakazky";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(111, 31);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(133, 21);
            this.comboBox1.TabIndex = 45;
            this.comboBox1.ValueMember = "StavZakazky";
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            this.comboBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox1_KeyPress);
            // 
            // tblZakazkyStavBindingSource
            // 
            this.tblZakazkyStavBindingSource.DataMember = "tblZakazkyStav";
            this.tblZakazkyStavBindingSource.DataSource = this.novaDBcsharpDataSet;
            // 
            // novaDBcsharpDataSet
            // 
            this.novaDBcsharpDataSet.DataSetName = "novaDBcsharpDataSet";
            this.novaDBcsharpDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ZavrietZakazku
            // 
            this.ZavrietZakazku.Location = new System.Drawing.Point(111, 254);
            this.ZavrietZakazku.Name = "ZavrietZakazku";
            this.ZavrietZakazku.Size = new System.Drawing.Size(75, 23);
            this.ZavrietZakazku.TabIndex = 43;
            this.ZavrietZakazku.Text = "Zavrieť";
            this.ZavrietZakazku.UseVisualStyleBackColor = true;
            this.ZavrietZakazku.Click += new System.EventHandler(this.ZavrietZakazku_Click);
            // 
            // VytvorilDna
            // 
            this.VytvorilDna.BackColor = System.Drawing.Color.WhiteSmoke;
            // 
            // 
            // 
            this.VytvorilDna.Border.Class = "TextBoxBorder";
            this.VytvorilDna.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.VytvorilDna.Location = new System.Drawing.Point(296, 110);
            this.VytvorilDna.Name = "VytvorilDna";
            this.VytvorilDna.ReadOnly = true;
            this.VytvorilDna.Size = new System.Drawing.Size(113, 20);
            this.VytvorilDna.TabIndex = 42;
            // 
            // ZakazkuVytvoril
            // 
            this.ZakazkuVytvoril.BackColor = System.Drawing.Color.WhiteSmoke;
            // 
            // 
            // 
            this.ZakazkuVytvoril.Border.Class = "TextBoxBorder";
            this.ZakazkuVytvoril.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ZakazkuVytvoril.Location = new System.Drawing.Point(111, 109);
            this.ZakazkuVytvoril.Name = "ZakazkuVytvoril";
            this.ZakazkuVytvoril.ReadOnly = true;
            this.ZakazkuVytvoril.Size = new System.Drawing.Size(100, 20);
            this.ZakazkuVytvoril.TabIndex = 41;
            // 
            // Zakaznik
            // 
            this.Zakaznik.BackColor = System.Drawing.Color.WhiteSmoke;
            // 
            // 
            // 
            this.Zakaznik.Border.Class = "TextBoxBorder";
            this.Zakaznik.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Zakaznik.Location = new System.Drawing.Point(111, 83);
            this.Zakaznik.Name = "Zakaznik";
            this.Zakaznik.ReadOnly = true;
            this.Zakaznik.Size = new System.Drawing.Size(298, 20);
            this.Zakaznik.TabIndex = 38;
            // 
            // ZakaznickaObjednavka
            // 
            this.ZakaznickaObjednavka.BackColor = System.Drawing.Color.WhiteSmoke;
            // 
            // 
            // 
            this.ZakaznickaObjednavka.Border.Class = "TextBoxBorder";
            this.ZakaznickaObjednavka.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ZakaznickaObjednavka.Location = new System.Drawing.Point(111, 57);
            this.ZakaznickaObjednavka.Name = "ZakaznickaObjednavka";
            this.ZakaznickaObjednavka.ReadOnly = true;
            this.ZakaznickaObjednavka.Size = new System.Drawing.Size(133, 20);
            this.ZakaznickaObjednavka.TabIndex = 37;
            // 
            // PoznamkyZakazky
            // 
            this.PoznamkyZakazky.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PoznamkyZakazky.Location = new System.Drawing.Point(14, 153);
            this.PoznamkyZakazky.Name = "PoznamkyZakazky";
            this.PoznamkyZakazky.ReadOnly = true;
            this.PoznamkyZakazky.Size = new System.Drawing.Size(395, 95);
            this.PoznamkyZakazky.TabIndex = 33;
            this.PoznamkyZakazky.Text = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 84);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "Zákazník :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "Zák. objednávka :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Číslo zákazky :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Status zákazky :";
            // 
            // UlozitZakazku
            // 
            this.UlozitZakazku.Location = new System.Drawing.Point(14, 254);
            this.UlozitZakazku.Name = "UlozitZakazku";
            this.UlozitZakazku.Size = new System.Drawing.Size(91, 23);
            this.UlozitZakazku.TabIndex = 21;
            this.UlozitZakazku.Text = "Uložiť a zavrieť";
            this.UlozitZakazku.UseVisualStyleBackColor = true;
            this.UlozitZakazku.Click += new System.EventHandler(this.UlozitZakazku_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Poznámky zákazky :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(222, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Vytvoril dňa :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Vytvoril :";
            // 
            // superTabItem1
            // 
            this.superTabItem1.AttachedControl = this.superTabControlPanel1;
            this.superTabItem1.GlobalItem = false;
            this.superTabItem1.Name = "superTabItem1";
            this.superTabItem1.Text = "Zákazka";
            // 
            // superTabControlPanel2
            // 
            this.superTabControlPanel2.Controls.Add(this.listBox1);
            this.superTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel2.Location = new System.Drawing.Point(0, 25);
            this.superTabControlPanel2.Name = "superTabControlPanel2";
            this.superTabControlPanel2.Size = new System.Drawing.Size(427, 285);
            this.superTabControlPanel2.TabIndex = 2;
            this.superTabControlPanel2.TabItem = this.superTabItem2;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(427, 285);
            this.listBox1.TabIndex = 0;
            // 
            // superTabItem2
            // 
            this.superTabItem2.AttachedControl = this.superTabControlPanel2;
            this.superTabItem2.Enabled = false;
            this.superTabItem2.GlobalItem = false;
            this.superTabItem2.Name = "superTabItem2";
            this.superTabItem2.Text = "História zmien";
            // 
            // requiredFieldValidator1
            // 
            this.requiredFieldValidator1.ErrorMessage = "Your error message here.";
            this.requiredFieldValidator1.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // requiredFieldValidator2
            // 
            this.requiredFieldValidator2.ErrorMessage = "Your error message here.";
            this.requiredFieldValidator2.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // requiredFieldValidator3
            // 
            this.requiredFieldValidator3.ErrorMessage = "Your error message here.";
            this.requiredFieldValidator3.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // requiredFieldValidator4
            // 
            this.requiredFieldValidator4.ErrorMessage = "Your error message here.";
            this.requiredFieldValidator4.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // tblZakazkyStavTableAdapter
            // 
            this.tblZakazkyStavTableAdapter.ClearBeforeFill = true;
            // 
            // EditZakazky
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 310);
            this.ControlBox = false;
            this.Controls.Add(this.superTabControl1);
            this.Name = "EditZakazky";
            this.Text = "Úprava zákazky";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditZakazky_FormClosing);
            this.Load += new System.EventHandler(this.EditZakazky_Load);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).EndInit();
            this.superTabControl1.ResumeLayout(false);
            this.superTabControlPanel1.ResumeLayout(false);
            this.superTabControlPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblZakazkyStavBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.novaDBcsharpDataSet)).EndInit();
            this.superTabControlPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.SuperTabControl superTabControl1;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel1;
        private System.Windows.Forms.Button UlozitZakazku;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel2;
        private DevComponents.DotNetBar.SuperTabItem superTabItem2;
        private DevComponents.DotNetBar.SuperTabItem superTabItem1;
        private System.Windows.Forms.RichTextBox PoznamkyZakazky;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private DevComponents.DotNetBar.Controls.TextBoxX VytvorilDna;
        private DevComponents.DotNetBar.Controls.TextBoxX ZakazkuVytvoril;
        private DevComponents.DotNetBar.Controls.TextBoxX Zakaznik;
        private DevComponents.DotNetBar.Controls.TextBoxX ZakaznickaObjednavka;
        private System.Windows.Forms.Button ZavrietZakazku;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.MaskedTextBox CisloZakazky;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator2;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator3;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator4;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator1;
        private novaDBcsharpDataSet novaDBcsharpDataSet;
        private System.Windows.Forms.BindingSource tblZakazkyStavBindingSource;
        private novaDBcsharpDataSetTableAdapters.tblZakazkyStavTableAdapter tblZakazkyStavTableAdapter;
        private System.Windows.Forms.Button button1;
    }
}