namespace WindowsFormsApplication14
{
    partial class NovyUzivatel
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
            this.superGridControl1 = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn4 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn5 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn6 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn7 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn8 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.tblUzivateliaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.novaDBcsharpDataSet = new WindowsFormsApplication14.novaDBcsharpDataSet();
            this.ZavrietZakazku = new System.Windows.Forms.Button();
            this.UlozitZakazku = new System.Windows.Forms.Button();
            this.superTabItem1 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel2 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.superTabItem2 = new DevComponents.DotNetBar.SuperTabItem();
            this.tblZakazkyStavBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.requiredFieldValidator1 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.requiredFieldValidator2 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.requiredFieldValidator3 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.requiredFieldValidator4 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.tblZakazkyStavTableAdapter = new WindowsFormsApplication14.novaDBcsharpDataSetTableAdapters.tblZakazkyStavTableAdapter();
            this.tblUzivateliaTableAdapter = new WindowsFormsApplication14.novaDBcsharpDataSetTableAdapters.tblUzivateliaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).BeginInit();
            this.superTabControl1.SuspendLayout();
            this.superTabControlPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblUzivateliaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.novaDBcsharpDataSet)).BeginInit();
            this.superTabControlPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblZakazkyStavBindingSource)).BeginInit();
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
            this.superTabControl1.Size = new System.Drawing.Size(862, 310);
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
            this.superTabControlPanel1.Controls.Add(this.superGridControl1);
            this.superTabControlPanel1.Controls.Add(this.ZavrietZakazku);
            this.superTabControlPanel1.Controls.Add(this.UlozitZakazku);
            this.superTabControlPanel1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 25);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(862, 285);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.superTabItem1;
            // 
            // superGridControl1
            // 
            this.superGridControl1.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.superGridControl1.Location = new System.Drawing.Point(14, 13);
            this.superGridControl1.Name = "superGridControl1";
            // 
            // 
            // 
            this.superGridControl1.PrimaryGrid.AllowRowInsert = true;
            this.superGridControl1.PrimaryGrid.Columns.Add(this.gridColumn1);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.gridColumn2);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.gridColumn3);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.gridColumn4);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.gridColumn5);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.gridColumn6);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.gridColumn7);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.gridColumn8);
            this.superGridControl1.PrimaryGrid.DataSource = this.tblUzivateliaBindingSource;
            this.superGridControl1.PrimaryGrid.ShowInsertRow = true;
            this.superGridControl1.PrimaryGrid.ShowTreeButtons = true;
            this.superGridControl1.PrimaryGrid.ShowTreeLines = true;
            this.superGridControl1.PrimaryGrid.UseAlternateColumnStyle = true;
            this.superGridControl1.PrimaryGrid.UseAlternateRowStyle = true;
            this.superGridControl1.Size = new System.Drawing.Size(836, 235);
            this.superGridControl1.TabIndex = 44;
            this.superGridControl1.Text = "superGridControl1";
            this.superGridControl1.BeginEdit += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridEditEventArgs>(this.superGridControl1_BeginEdit);
            // 
            // gridColumn1
            // 
            this.gridColumn1.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.DisplayedCells;
            this.gridColumn1.DataPropertyName = "IdUzivatela";
            this.gridColumn1.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl);
            this.gridColumn1.HeaderText = "IdUzivatela";
            this.gridColumn1.Name = "IdUzivatela";
            this.gridColumn1.ReadOnly = true;
            this.gridColumn1.Visible = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.DisplayedCells;
            this.gridColumn2.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.gridColumn2.DataPropertyName = "Skupina";
            this.gridColumn2.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl);
            this.gridColumn2.HeaderText = "Skupina";
            this.gridColumn2.Name = "Skupina";
            // 
            // gridColumn3
            // 
            this.gridColumn3.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.gridColumn3.DataPropertyName = "Meno";
            this.gridColumn3.HeaderText = "Meno";
            this.gridColumn3.Name = "Meno";
            // 
            // gridColumn4
            // 
            this.gridColumn4.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.gridColumn4.DataPropertyName = "Heslo";
            this.gridColumn4.HeaderText = "Heslo";
            this.gridColumn4.Name = "Heslo";
            // 
            // gridColumn5
            // 
            this.gridColumn5.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.DisplayedCells;
            this.gridColumn5.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.gridColumn5.DataPropertyName = "Email";
            this.gridColumn5.HeaderText = "Email";
            this.gridColumn5.Name = "Email";
            // 
            // gridColumn6
            // 
            this.gridColumn6.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.gridColumn6.DataPropertyName = "Opravnenie";
            this.gridColumn6.HeaderText = "Opravnenie";
            this.gridColumn6.Name = "Opravnenie";
            // 
            // gridColumn7
            // 
            this.gridColumn7.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.gridColumn7.DataPropertyName = "Kto";
            this.gridColumn7.HeaderText = "Kto";
            this.gridColumn7.Name = "Kto";
            // 
            // gridColumn8
            // 
            this.gridColumn8.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.gridColumn8.DataPropertyName = "Kedy";
            this.gridColumn8.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridDateTimeInputEditControl);
            this.gridColumn8.HeaderText = "Kedy";
            this.gridColumn8.Name = "Kedy";
            // 
            // tblUzivateliaBindingSource
            // 
            this.tblUzivateliaBindingSource.DataMember = "tblUzivatelia";
            this.tblUzivateliaBindingSource.DataSource = this.novaDBcsharpDataSet;
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
            // superTabItem1
            // 
            this.superTabItem1.AttachedControl = this.superTabControlPanel1;
            this.superTabItem1.GlobalItem = false;
            this.superTabItem1.Name = "superTabItem1";
            this.superTabItem1.Text = "Užívatelia";
            // 
            // superTabControlPanel2
            // 
            this.superTabControlPanel2.Controls.Add(this.listBox1);
            this.superTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel2.Location = new System.Drawing.Point(0, 25);
            this.superTabControlPanel2.Name = "superTabControlPanel2";
            this.superTabControlPanel2.Size = new System.Drawing.Size(610, 285);
            this.superTabControlPanel2.TabIndex = 2;
            this.superTabControlPanel2.TabItem = this.superTabItem2;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(610, 285);
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
            // tblUzivateliaTableAdapter
            // 
            this.tblUzivateliaTableAdapter.ClearBeforeFill = true;
            // 
            // NovyUzivatel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(862, 310);
            this.ControlBox = false;
            this.Controls.Add(this.superTabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NovyUzivatel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nový užívateľ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NovaZakazka_FormClosing);
            this.Load += new System.EventHandler(this.NovaZakazka_Load);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).EndInit();
            this.superTabControl1.ResumeLayout(false);
            this.superTabControlPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblUzivateliaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.novaDBcsharpDataSet)).EndInit();
            this.superTabControlPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblZakazkyStavBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.SuperTabControl superTabControl1;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel1;
        private System.Windows.Forms.Button UlozitZakazku;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel2;
        private DevComponents.DotNetBar.SuperTabItem superTabItem2;
        private DevComponents.DotNetBar.SuperTabItem superTabItem1;
        private System.Windows.Forms.Button ZavrietZakazku;
        private System.Windows.Forms.ListBox listBox1;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator2;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator3;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator4;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator1;
        private novaDBcsharpDataSet novaDBcsharpDataSet;
        private System.Windows.Forms.BindingSource tblZakazkyStavBindingSource;
        private novaDBcsharpDataSetTableAdapters.tblZakazkyStavTableAdapter tblZakazkyStavTableAdapter;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl superGridControl1;
        private System.Windows.Forms.BindingSource tblUzivateliaBindingSource;
        private novaDBcsharpDataSetTableAdapters.tblUzivateliaTableAdapter tblUzivateliaTableAdapter;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn4;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn5;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn6;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn7;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn8;
    }
}