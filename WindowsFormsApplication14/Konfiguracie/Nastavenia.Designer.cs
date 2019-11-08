namespace WindowsFormsApplication14
{
    partial class Nastavenia
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
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnVlozitNastavenia = new DevComponents.DotNetBar.ButtonX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtNastavenia = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblPopis = new DevComponents.DotNetBar.LabelX();
            this.txtPopis = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.superGridControl1 = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.gridColumn9 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn14 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn15 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn16 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn17 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.tblNastaveniaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.novaDBcsharpDataSet = new WindowsFormsApplication14.novaDBcsharpDataSet();
            this.ZavrietZakazku = new System.Windows.Forms.Button();
            this.UlozitZakazku = new System.Windows.Forms.Button();
            this.superTabItem1 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel2 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.superTabItem2 = new DevComponents.DotNetBar.SuperTabItem();
            this.gridColumn10 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn11 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn12 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn13 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn4 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn5 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn6 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn7 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn8 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.tblZakazkyStavBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.requiredFieldValidator1 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.requiredFieldValidator2 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.requiredFieldValidator3 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.requiredFieldValidator4 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.tblNastaveniaTableAdapter = new WindowsFormsApplication14.novaDBcsharpDataSetTableAdapters.tblNastaveniaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).BeginInit();
            this.superTabControl1.SuspendLayout();
            this.superTabControlPanel1.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblNastaveniaBindingSource)).BeginInit();
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
            this.superTabControl1.Size = new System.Drawing.Size(838, 491);
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
            this.superTabControlPanel1.Controls.Add(this.groupPanel1);
            this.superTabControlPanel1.Controls.Add(this.superGridControl1);
            this.superTabControlPanel1.Controls.Add(this.ZavrietZakazku);
            this.superTabControlPanel1.Controls.Add(this.UlozitZakazku);
            this.superTabControlPanel1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 25);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(838, 466);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.superTabItem1;
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.btnVlozitNastavenia);
            this.groupPanel1.Controls.Add(this.labelX1);
            this.groupPanel1.Controls.Add(this.txtNastavenia);
            this.groupPanel1.Controls.Add(this.lblPopis);
            this.groupPanel1.Controls.Add(this.txtPopis);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Location = new System.Drawing.Point(15, 3);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(814, 142);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 48;
            this.groupPanel1.Text = "Vložiť nové nastavenie";
            // 
            // btnVlozitNastavenia
            // 
            this.btnVlozitNastavenia.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnVlozitNastavenia.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnVlozitNastavenia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVlozitNastavenia.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnVlozitNastavenia.Location = new System.Drawing.Point(66, 65);
            this.btnVlozitNastavenia.Name = "btnVlozitNastavenia";
            this.btnVlozitNastavenia.Size = new System.Drawing.Size(522, 32);
            this.btnVlozitNastavenia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnVlozitNastavenia.TabIndex = 59;
            this.btnVlozitNastavenia.Text = "Vložiť nové nastavenie";
            this.btnVlozitNastavenia.Click += new System.EventHandler(this.btnVlozitNastavenia_Click);
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(3, 39);
            this.labelX1.Name = "labelX1";
            this.labelX1.SingleLineColor = System.Drawing.Color.Transparent;
            this.labelX1.Size = new System.Drawing.Size(62, 20);
            this.labelX1.TabIndex = 58;
            this.labelX1.Text = "Hodnota:";
            this.labelX1.Click += new System.EventHandler(this.labelX1_Click);
            // 
            // txtNastavenia
            // 
            // 
            // 
            // 
            this.txtNastavenia.Border.Class = "TextBoxBorder";
            this.txtNastavenia.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNastavenia.Location = new System.Drawing.Point(66, 39);
            this.txtNastavenia.Name = "txtNastavenia";
            this.txtNastavenia.PreventEnterBeep = true;
            this.txtNastavenia.Size = new System.Drawing.Size(522, 20);
            this.txtNastavenia.TabIndex = 57;
            // 
            // lblPopis
            // 
            this.lblPopis.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblPopis.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblPopis.Location = new System.Drawing.Point(3, 12);
            this.lblPopis.Name = "lblPopis";
            this.lblPopis.SingleLineColor = System.Drawing.Color.Transparent;
            this.lblPopis.Size = new System.Drawing.Size(35, 20);
            this.lblPopis.TabIndex = 56;
            this.lblPopis.Text = "Popis:";
            // 
            // txtPopis
            // 
            // 
            // 
            // 
            this.txtPopis.Border.Class = "TextBoxBorder";
            this.txtPopis.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPopis.Location = new System.Drawing.Point(66, 13);
            this.txtPopis.Name = "txtPopis";
            this.txtPopis.PreventEnterBeep = true;
            this.txtPopis.Size = new System.Drawing.Size(522, 20);
            this.txtPopis.TabIndex = 0;
            // 
            // superGridControl1
            // 
            this.superGridControl1.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.superGridControl1.Location = new System.Drawing.Point(15, 148);
            this.superGridControl1.Margin = new System.Windows.Forms.Padding(0);
            this.superGridControl1.Name = "superGridControl1";
            // 
            // 
            // 
            this.superGridControl1.PrimaryGrid.Columns.Add(this.gridColumn9);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.gridColumn14);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.gridColumn15);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.gridColumn16);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.gridColumn17);
            this.superGridControl1.PrimaryGrid.DataSource = this.tblNastaveniaBindingSource;
            this.superGridControl1.PrimaryGrid.UseAlternateRowStyle = true;
            this.superGridControl1.Size = new System.Drawing.Size(814, 269);
            this.superGridControl1.TabIndex = 47;
            this.superGridControl1.Text = "superGridControl1";
            this.superGridControl1.BeginEdit += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridEditEventArgs>(this.superGridControl1_BeginEdit);
            // 
            // gridColumn9
            // 
            this.gridColumn9.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.DisplayedCells;
            this.gridColumn9.DataPropertyName = "id";
            this.gridColumn9.DefaultNewRowCellValue = "";
            this.gridColumn9.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl);
            this.gridColumn9.HeaderText = "id";
            this.gridColumn9.Name = "id";
            this.gridColumn9.ReadOnly = true;
            this.gridColumn9.Visible = false;
            // 
            // gridColumn14
            // 
            this.gridColumn14.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.DisplayedCells;
            this.gridColumn14.CellStyles.Default.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gridColumn14.DataPropertyName = "Popis";
            this.gridColumn14.HeaderStyles.Default.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gridColumn14.HeaderText = "Popis";
            this.gridColumn14.Name = "Popis";
            // 
            // gridColumn15
            // 
            this.gridColumn15.CellStyles.Default.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gridColumn15.DataPropertyName = "Hodnota";
            this.gridColumn15.FillWeight = 400;
            this.gridColumn15.HeaderStyles.Default.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gridColumn15.HeaderText = "Hodnota";
            this.gridColumn15.Name = "Hodnota";
            this.gridColumn15.Width = 400;
            // 
            // gridColumn16
            // 
            this.gridColumn16.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.DisplayedCells;
            this.gridColumn16.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.gridColumn16.DataPropertyName = "kto";
            this.gridColumn16.HeaderText = "Užívateľ";
            this.gridColumn16.Name = "kto";
            // 
            // gridColumn17
            // 
            this.gridColumn17.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.DisplayedCells;
            this.gridColumn17.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.gridColumn17.DataPropertyName = "kedy";
            this.gridColumn17.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridDateTimeInputEditControl);
            this.gridColumn17.HeaderText = "Dátum";
            this.gridColumn17.Name = "kedy";
            // 
            // tblNastaveniaBindingSource
            // 
            this.tblNastaveniaBindingSource.DataMember = "tblNastavenia";
            this.tblNastaveniaBindingSource.DataSource = this.novaDBcsharpDataSet;
            // 
            // novaDBcsharpDataSet
            // 
            this.novaDBcsharpDataSet.DataSetName = "novaDBcsharpDataSet";
            this.novaDBcsharpDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ZavrietZakazku
            // 
            this.ZavrietZakazku.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ZavrietZakazku.Location = new System.Drawing.Point(112, 431);
            this.ZavrietZakazku.Name = "ZavrietZakazku";
            this.ZavrietZakazku.Size = new System.Drawing.Size(75, 23);
            this.ZavrietZakazku.TabIndex = 46;
            this.ZavrietZakazku.Text = "Zavrieť";
            this.ZavrietZakazku.UseVisualStyleBackColor = true;
            this.ZavrietZakazku.Click += new System.EventHandler(this.ZavrietZakazku_Click_1);
            // 
            // UlozitZakazku
            // 
            this.UlozitZakazku.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UlozitZakazku.Location = new System.Drawing.Point(15, 431);
            this.UlozitZakazku.Name = "UlozitZakazku";
            this.UlozitZakazku.Size = new System.Drawing.Size(91, 23);
            this.UlozitZakazku.TabIndex = 45;
            this.UlozitZakazku.Text = "Uložiť a zavrieť";
            this.UlozitZakazku.UseVisualStyleBackColor = true;
            this.UlozitZakazku.Click += new System.EventHandler(this.UlozitZakazku_Click);
            // 
            // superTabItem1
            // 
            this.superTabItem1.AttachedControl = this.superTabControlPanel1;
            this.superTabItem1.GlobalItem = false;
            this.superTabItem1.Name = "superTabItem1";
            this.superTabItem1.Text = "Nastavenia";
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
            // gridColumn10
            // 
            this.gridColumn10.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.gridColumn10.DataPropertyName = "LOT";
            this.gridColumn10.HeaderText = "LOT Vlákna";
            this.gridColumn10.Name = "LOT";
            this.gridColumn10.Width = 180;
            // 
            // gridColumn11
            // 
            this.gridColumn11.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.gridColumn11.DataPropertyName = "rmax";
            this.gridColumn11.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridMaskedTextBoxEditControl);
            this.gridColumn11.HeaderText = "Rmax";
            this.gridColumn11.Name = "rmax";
            // 
            // gridColumn12
            // 
            this.gridColumn12.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.gridColumn12.DataPropertyName = "kto";
            this.gridColumn12.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.None;
            this.gridColumn12.HeaderText = "Užívateľ";
            this.gridColumn12.Name = "kto";
            // 
            // gridColumn13
            // 
            this.gridColumn13.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.gridColumn13.DataPropertyName = "kedy";
            this.gridColumn13.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridDateTimeInputEditControl);
            this.gridColumn13.HeaderText = "Dátum";
            this.gridColumn13.Name = "kedy";
            this.gridColumn13.Width = 150;
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
            // tblNastaveniaTableAdapter
            // 
            this.tblNastaveniaTableAdapter.ClearBeforeFill = true;
            // 
            // Nastavenia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 491);
            this.ControlBox = false;
            this.Controls.Add(this.superTabControl1);
            this.Name = "Nastavenia";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nastavenia";
            this.Load += new System.EventHandler(this.Rmax_values_Load);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).EndInit();
            this.superTabControl1.ResumeLayout(false);
            this.superTabControlPanel1.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblNastaveniaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.novaDBcsharpDataSet)).EndInit();
            this.superTabControlPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblZakazkyStavBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.SuperTabControl superTabControl1;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel1;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel2;
        private DevComponents.DotNetBar.SuperTabItem superTabItem2;
        private DevComponents.DotNetBar.SuperTabItem superTabItem1;
        private System.Windows.Forms.ListBox listBox1;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator2;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator3;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator4;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator1;
        private novaDBcsharpDataSet novaDBcsharpDataSet;
        private System.Windows.Forms.BindingSource tblZakazkyStavBindingSource;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl superGridControl1;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn4;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn5;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn6;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn7;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn8;
        private System.Windows.Forms.Button ZavrietZakazku;
        private System.Windows.Forms.Button UlozitZakazku;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn10;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn11;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn12;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn13;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn9;
        private System.Windows.Forms.BindingSource tblNastaveniaBindingSource;
        private novaDBcsharpDataSetTableAdapters.tblNastaveniaTableAdapter tblNastaveniaTableAdapter;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn14;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn15;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPopis;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNastavenia;
        private DevComponents.DotNetBar.LabelX lblPopis;
        private DevComponents.DotNetBar.ButtonX btnVlozitNastavenia;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn16;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn17;
    }
}