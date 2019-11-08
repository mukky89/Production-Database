namespace WindowsFormsApplication14
{
    partial class FBGS_Report
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
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label1 = new System.Windows.Forms.Label();
            this.CisloZakazky = new System.Windows.Forms.MaskedTextBox();
            this.ZavrietZakazku = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.GenerujReport = new System.Windows.Forms.Button();
            this.superTabItem1 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel2 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.superTabItem2 = new DevComponents.DotNetBar.SuperTabItem();
            this.tblZakazkyStavBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.novaDBcsharpDataSet = new WindowsFormsApplication14.novaDBcsharpDataSet();
            this.requiredFieldValidator1 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.requiredFieldValidator2 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.requiredFieldValidator3 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.requiredFieldValidator4 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.tblZakazkyStavTableAdapter = new WindowsFormsApplication14.novaDBcsharpDataSetTableAdapters.tblZakazkyStavTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).BeginInit();
            this.superTabControl1.SuspendLayout();
            this.superTabControlPanel1.SuspendLayout();
            this.superTabControlPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblZakazkyStavBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.novaDBcsharpDataSet)).BeginInit();
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
            this.superTabControl1.Size = new System.Drawing.Size(281, 128);
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
            this.superTabControlPanel1.Controls.Add(this.textBoxX1);
            this.superTabControlPanel1.Controls.Add(this.label1);
            this.superTabControlPanel1.Controls.Add(this.CisloZakazky);
            this.superTabControlPanel1.Controls.Add(this.ZavrietZakazku);
            this.superTabControlPanel1.Controls.Add(this.label8);
            this.superTabControlPanel1.Controls.Add(this.GenerujReport);
            this.superTabControlPanel1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 25);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(281, 103);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.superTabItem1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(211, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(52, 23);
            this.button1.TabIndex = 49;
            this.button1.Text = "Otvoriť";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxX1
            // 
            // 
            // 
            // 
            this.textBoxX1.Border.Class = "TextBoxBorder";
            this.textBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX1.Location = new System.Drawing.Point(111, 33);
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.PreventEnterBeep = true;
            this.textBoxX1.Size = new System.Drawing.Size(152, 20);
            this.textBoxX1.TabIndex = 48;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 47;
            this.label1.Text = "Cesta uloženia :";
            // 
            // CisloZakazky
            // 
            this.CisloZakazky.Location = new System.Drawing.Point(111, 7);
            this.CisloZakazky.Mask = "00000";
            this.CisloZakazky.Name = "CisloZakazky";
            this.CisloZakazky.Size = new System.Drawing.Size(58, 20);
            this.CisloZakazky.TabIndex = 46;
            this.CisloZakazky.ValidatingType = typeof(int);
            this.CisloZakazky.Leave += new System.EventHandler(this.CisloZakazky_Leave);
            // 
            // ZavrietZakazku
            // 
            this.ZavrietZakazku.Location = new System.Drawing.Point(130, 65);
            this.ZavrietZakazku.Name = "ZavrietZakazku";
            this.ZavrietZakazku.Size = new System.Drawing.Size(75, 23);
            this.ZavrietZakazku.TabIndex = 43;
            this.ZavrietZakazku.Text = "Zavrieť";
            this.ZavrietZakazku.UseVisualStyleBackColor = true;
            this.ZavrietZakazku.Click += new System.EventHandler(this.ZavrietZakazku_Click);
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
            // GenerujReport
            // 
            this.GenerujReport.Location = new System.Drawing.Point(12, 65);
            this.GenerujReport.Name = "GenerujReport";
            this.GenerujReport.Size = new System.Drawing.Size(112, 23);
            this.GenerujReport.TabIndex = 21;
            this.GenerujReport.Text = "Vygenerovať report";
            this.GenerujReport.UseVisualStyleBackColor = true;
            this.GenerujReport.Click += new System.EventHandler(this.GenerujReport_Click);
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
            // FBGS_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 128);
            this.ControlBox = false;
            this.Controls.Add(this.superTabControl1);
            this.Name = "FBGS_Report";
            this.Text = "FBGS report";
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).EndInit();
            this.superTabControl1.ResumeLayout(false);
            this.superTabControlPanel1.ResumeLayout(false);
            this.superTabControlPanel1.PerformLayout();
            this.superTabControlPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblZakazkyStavBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.novaDBcsharpDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.SuperTabControl superTabControl1;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel1;
        private System.Windows.Forms.Button GenerujReport;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel2;
        private DevComponents.DotNetBar.SuperTabItem superTabItem2;
        private DevComponents.DotNetBar.SuperTabItem superTabItem1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button ZavrietZakazku;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.MaskedTextBox CisloZakazky;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator2;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator3;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator4;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator1;
        private novaDBcsharpDataSet novaDBcsharpDataSet;
        private System.Windows.Forms.BindingSource tblZakazkyStavBindingSource;
        private novaDBcsharpDataSetTableAdapters.tblZakazkyStavTableAdapter tblZakazkyStavTableAdapter;
        private System.Windows.Forms.Button button1;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
        private System.Windows.Forms.Label label1;
    }
}