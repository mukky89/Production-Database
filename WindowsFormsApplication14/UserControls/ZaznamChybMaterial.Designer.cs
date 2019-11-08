namespace WindowsFormsApplication14.UserControls
{
    partial class ZaznamChybMaterial
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tblZnicenyMaterialTableAdapter = new WindowsFormsApplication14.novaDBcsharpDataSetTableAdapters.tblZnicenyMaterialTableAdapter();
            this.tblZnicenyMaterialBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.novaDBcsharpDataSet = new WindowsFormsApplication14.novaDBcsharpDataSet();
            this.gridColumn32 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn27 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn30 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn28 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn26 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn25 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn24 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn23 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn22 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn29 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridMaterialBom = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.gpZnicenyMaterial = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.gridRow4 = new DevComponents.DotNetBar.SuperGrid.GridRow();
            this.gridRow3 = new DevComponents.DotNetBar.SuperGrid.GridRow();
            this.gridCell1 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            this.gridRow2 = new DevComponents.DotNetBar.SuperGrid.GridRow();
            ((System.ComponentModel.ISupportInitialize)(this.tblZnicenyMaterialBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.novaDBcsharpDataSet)).BeginInit();
            this.gpZnicenyMaterial.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblZnicenyMaterialTableAdapter
            // 
            this.tblZnicenyMaterialTableAdapter.ClearBeforeFill = true;
            // 
            // tblZnicenyMaterialBindingSource
            // 
            this.tblZnicenyMaterialBindingSource.DataMember = "tblZnicenyMaterial";
            this.tblZnicenyMaterialBindingSource.DataSource = this.novaDBcsharpDataSet;
            // 
            // novaDBcsharpDataSet
            // 
            this.novaDBcsharpDataSet.DataSetName = "novaDBcsharpDataSet";
            this.novaDBcsharpDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridColumn32
            // 
            this.gridColumn32.DataPropertyName = "rework";
            this.gridColumn32.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl);
            this.gridColumn32.HeaderText = "rework";
            this.gridColumn32.Name = "rework";
            this.gridColumn32.Visible = false;
            // 
            // gridColumn27
            // 
            this.gridColumn27.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.DisplayedCells;
            this.gridColumn27.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.gridColumn27.CellStyles.Default.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gridColumn27.DataPropertyName = "Mnozstvo";
            this.gridColumn27.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridDoubleInputEditControl);
            this.gridColumn27.HeaderStyles.Default.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gridColumn27.HeaderText = "Množstvo";
            this.gridColumn27.Name = "Mnozstvo";
            // 
            // gridColumn30
            // 
            this.gridColumn30.AllowEdit = false;
            this.gridColumn30.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.DisplayedCells;
            this.gridColumn30.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.gridColumn30.DataPropertyName = "Cena";
            this.gridColumn30.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridDoubleInputEditControl);
            this.gridColumn30.HeaderText = "Cena";
            this.gridColumn30.Name = "Cena";
            this.gridColumn30.ReadOnly = true;
            // 
            // gridColumn28
            // 
            this.gridColumn28.AllowEdit = false;
            this.gridColumn28.DataPropertyName = "zakazka";
            this.gridColumn28.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl);
            this.gridColumn28.HeaderText = "zakazka";
            this.gridColumn28.Name = "zakazka";
            this.gridColumn28.ReadOnly = true;
            this.gridColumn28.Visible = false;
            // 
            // gridColumn26
            // 
            this.gridColumn26.AllowEdit = false;
            this.gridColumn26.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.DisplayedCells;
            this.gridColumn26.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.gridColumn26.DataPropertyName = "jednotka";
            this.gridColumn26.HeaderText = "Jednotka";
            this.gridColumn26.Name = "jednotka";
            this.gridColumn26.ReadOnly = true;
            // 
            // gridColumn25
            // 
            this.gridColumn25.AllowEdit = false;
            this.gridColumn25.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.DisplayedCells;
            this.gridColumn25.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft;
            this.gridColumn25.DataPropertyName = "PopisMaterialu";
            this.gridColumn25.HeaderText = "Popis";
            this.gridColumn25.Name = "PopisMaterialu";
            this.gridColumn25.ReadOnly = true;
            // 
            // gridColumn24
            // 
            this.gridColumn24.AllowEdit = false;
            this.gridColumn24.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.DisplayedCells;
            this.gridColumn24.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.gridColumn24.DataPropertyName = "PNmaterialu";
            this.gridColumn24.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl);
            this.gridColumn24.HeaderText = "PN";
            this.gridColumn24.Name = "PNmaterialu";
            this.gridColumn24.ReadOnly = true;
            // 
            // gridColumn23
            // 
            this.gridColumn23.AllowEdit = false;
            this.gridColumn23.DataPropertyName = "objednavka";
            this.gridColumn23.HeaderText = "objednavka";
            this.gridColumn23.Name = "objednavka";
            this.gridColumn23.ReadOnly = true;
            this.gridColumn23.Visible = false;
            // 
            // gridColumn22
            // 
            this.gridColumn22.AllowEdit = false;
            this.gridColumn22.DataPropertyName = "id";
            this.gridColumn22.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl);
            this.gridColumn22.HeaderText = "id";
            this.gridColumn22.Name = "id";
            this.gridColumn22.ReadOnly = true;
            this.gridColumn22.Visible = false;
            // 
            // gridColumn29
            // 
            this.gridColumn29.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.gridColumn29.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridButtonXEditControl);
            this.gridColumn29.HeaderStyles.Default.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gridColumn29.HeaderStyles.Default.TextColor = System.Drawing.Color.Red;
            this.gridColumn29.HeaderText = "Delete";
            this.gridColumn29.Name = "DeleteBtn";
            // 
            // gridMaterialBom
            // 
            this.gridMaterialBom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMaterialBom.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.gridMaterialBom.Location = new System.Drawing.Point(5, 5);
            this.gridMaterialBom.Name = "gridMaterialBom";
            // 
            // 
            // 
            this.gridMaterialBom.PrimaryGrid.Columns.Add(this.gridColumn29);
            this.gridMaterialBom.PrimaryGrid.Columns.Add(this.gridColumn22);
            this.gridMaterialBom.PrimaryGrid.Columns.Add(this.gridColumn23);
            this.gridMaterialBom.PrimaryGrid.Columns.Add(this.gridColumn24);
            this.gridMaterialBom.PrimaryGrid.Columns.Add(this.gridColumn25);
            this.gridMaterialBom.PrimaryGrid.Columns.Add(this.gridColumn26);
            this.gridMaterialBom.PrimaryGrid.Columns.Add(this.gridColumn28);
            this.gridMaterialBom.PrimaryGrid.Columns.Add(this.gridColumn30);
            this.gridMaterialBom.PrimaryGrid.Columns.Add(this.gridColumn27);
            this.gridMaterialBom.PrimaryGrid.Columns.Add(this.gridColumn32);
            this.gridMaterialBom.PrimaryGrid.DataSource = this.tblZnicenyMaterialBindingSource;
            this.gridMaterialBom.PrimaryGrid.UseAlternateRowStyle = true;
            this.gridMaterialBom.Size = new System.Drawing.Size(962, 407);
            this.gridMaterialBom.TabIndex = 1;
            this.gridMaterialBom.Text = "superGridControl1";
            // 
            // gpZnicenyMaterial
            // 
            this.gpZnicenyMaterial.CanvasColor = System.Drawing.SystemColors.Control;
            this.gpZnicenyMaterial.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.gpZnicenyMaterial.Controls.Add(this.gridMaterialBom);
            this.gpZnicenyMaterial.DisabledBackColor = System.Drawing.Color.Empty;
            this.gpZnicenyMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpZnicenyMaterial.Location = new System.Drawing.Point(0, 0);
            this.gpZnicenyMaterial.Name = "gpZnicenyMaterial";
            this.gpZnicenyMaterial.Padding = new System.Windows.Forms.Padding(5);
            this.gpZnicenyMaterial.Size = new System.Drawing.Size(978, 438);
            // 
            // 
            // 
            this.gpZnicenyMaterial.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.gpZnicenyMaterial.Style.BackColorGradientAngle = 90;
            this.gpZnicenyMaterial.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.gpZnicenyMaterial.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpZnicenyMaterial.Style.BorderBottomWidth = 1;
            this.gpZnicenyMaterial.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.gpZnicenyMaterial.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpZnicenyMaterial.Style.BorderLeftWidth = 1;
            this.gpZnicenyMaterial.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpZnicenyMaterial.Style.BorderRightWidth = 1;
            this.gpZnicenyMaterial.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpZnicenyMaterial.Style.BorderTopWidth = 1;
            this.gpZnicenyMaterial.Style.CornerDiameter = 4;
            this.gpZnicenyMaterial.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.gpZnicenyMaterial.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.gpZnicenyMaterial.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.gpZnicenyMaterial.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.gpZnicenyMaterial.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.gpZnicenyMaterial.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.gpZnicenyMaterial.TabIndex = 2;
            this.gpZnicenyMaterial.Text = "Zničený materiál";
            // 
            // gridRow3
            // 
            this.gridRow3.Expanded = true;
            this.gridRow3.Rows.Add(this.gridRow4);
            // 
            // gridRow2
            // 
            this.gridRow2.Cells.Add(this.gridCell1);
            // 
            // ZaznamChybMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gpZnicenyMaterial);
            this.Name = "ZaznamChybMaterial";
            this.Size = new System.Drawing.Size(978, 438);
            ((System.ComponentModel.ISupportInitialize)(this.tblZnicenyMaterialBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.novaDBcsharpDataSet)).EndInit();
            this.gpZnicenyMaterial.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn32;
        public DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn27;
        public DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn30;
        public DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn28;
        public DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn26;
        public DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn25;
        public DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn24;
        public DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn23;
        public DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn22;
        public DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn29;
        public DevComponents.DotNetBar.SuperGrid.SuperGridControl gridMaterialBom;
        public DevComponents.DotNetBar.Controls.GroupPanel gpZnicenyMaterial;
        private DevComponents.DotNetBar.SuperGrid.GridRow gridRow4;
        private DevComponents.DotNetBar.SuperGrid.GridRow gridRow3;
        private DevComponents.DotNetBar.SuperGrid.GridCell gridCell1;
        private DevComponents.DotNetBar.SuperGrid.GridRow gridRow2;
        public novaDBcsharpDataSetTableAdapters.tblZnicenyMaterialTableAdapter tblZnicenyMaterialTableAdapter;
        public System.Windows.Forms.BindingSource tblZnicenyMaterialBindingSource;
        public novaDBcsharpDataSet novaDBcsharpDataSet;
    }
}
