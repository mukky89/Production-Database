namespace WindowsFormsApplication14.Kalibracie
{
    partial class Strain
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
            this.ribbonControl2 = new DevComponents.DotNetBar.RibbonControl();
            this.ribbonPanel1 = new DevComponents.DotNetBar.RibbonPanel();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonTabItem1 = new DevComponents.DotNetBar.RibbonTabItem();
            this.switchButtonItem1 = new DevComponents.DotNetBar.SwitchButtonItem();
            this.ribbonTabItemGroup4 = new DevComponents.DotNetBar.RibbonTabItemGroup();
            this.ribbonTabItemGroup3 = new DevComponents.DotNetBar.RibbonTabItemGroup();
            this.superGridControl1 = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn11 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn12 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.tblSTRAINkalBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.novaDBcsharpDataSet = new WindowsFormsApplication14.novaDBcsharpDataSet();
            this.gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn4 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn5 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn6 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn7 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn8 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn9 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn10 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.ribbonControl2.SuspendLayout();
            this.ribbonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblSTRAINkalBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.novaDBcsharpDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl2
            // 
            this.ribbonControl2.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.ribbonControl2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonControl2.Controls.Add(this.ribbonPanel1);
            this.ribbonControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.ribbonControl2.ForeColor = System.Drawing.Color.Black;
            this.ribbonControl2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.ribbonTabItem1,
            this.switchButtonItem1});
            this.ribbonControl2.KeyTipsFont = new System.Drawing.Font("Calibri", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ribbonControl2.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl2.MdiSystemItemVisible = false;
            this.ribbonControl2.Name = "ribbonControl2";
            this.ribbonControl2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.ribbonControl2.Size = new System.Drawing.Size(437, 140);
            this.ribbonControl2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonControl2.SystemText.MaximizeRibbonText = "&Maximize the Ribbon";
            this.ribbonControl2.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon";
            this.ribbonControl2.SystemText.QatAddItemText = "&Add to Quick Access Toolbar";
            this.ribbonControl2.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>";
            this.ribbonControl2.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar...";
            this.ribbonControl2.SystemText.QatDialogAddButton = "&Add >>";
            this.ribbonControl2.SystemText.QatDialogCancelButton = "Cancel";
            this.ribbonControl2.SystemText.QatDialogCaption = "Customize Quick Access Toolbar";
            this.ribbonControl2.SystemText.QatDialogCategoriesLabel = "&Choose commands from:";
            this.ribbonControl2.SystemText.QatDialogOkButton = "OK";
            this.ribbonControl2.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon";
            this.ribbonControl2.SystemText.QatDialogRemoveButton = "&Remove";
            this.ribbonControl2.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon";
            this.ribbonControl2.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon";
            this.ribbonControl2.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar";
            this.ribbonControl2.TabGroupHeight = 19;
            this.ribbonControl2.TabGroups.AddRange(new DevComponents.DotNetBar.RibbonTabItemGroup[] {
            this.ribbonTabItemGroup4,
            this.ribbonTabItemGroup3});
            this.ribbonControl2.TabGroupsVisible = true;
            this.ribbonControl2.TabIndex = 3;
            this.ribbonControl2.Text = "ribbonControl2";
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonPanel1.Controls.Add(this.ribbonBar1);
            this.ribbonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonPanel1.Location = new System.Drawing.Point(0, 45);
            this.ribbonPanel1.Name = "ribbonPanel1";
            this.ribbonPanel1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ribbonPanel1.Size = new System.Drawing.Size(437, 92);
            // 
            // 
            // 
            this.ribbonPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonPanel1.TabIndex = 2;
            // 
            // ribbonBar1
            // 
            this.ribbonBar1.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar1.DragDropSupport = true;
            this.ribbonBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem2});
            this.ribbonBar1.Location = new System.Drawing.Point(3, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(110, 89);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar1.TabIndex = 0;
            this.ribbonBar1.Text = "Kalibrácia";
            // 
            // 
            // 
            this.ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // buttonItem2
            // 
            this.buttonItem2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonItem2.ForeColor = System.Drawing.Color.Black;
            this.buttonItem2.Name = "buttonItem2";
            this.buttonItem2.SubItemsExpandWidth = 14;
            this.buttonItem2.Text = "Nová kalibrácia";
            this.buttonItem2.Click += new System.EventHandler(this.buttonItem2_Click);
            // 
            // ribbonTabItem1
            // 
            this.ribbonTabItem1.Checked = true;
            this.ribbonTabItem1.Name = "ribbonTabItem1";
            this.ribbonTabItem1.Panel = this.ribbonPanel1;
            this.ribbonTabItem1.Text = "Menu";
            // 
            // switchButtonItem1
            // 
            this.switchButtonItem1.ButtonHeight = 20;
            this.switchButtonItem1.ButtonWidth = 62;
            this.switchButtonItem1.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.switchButtonItem1.Margin.Bottom = 2;
            this.switchButtonItem1.Margin.Left = 4;
            this.switchButtonItem1.Name = "switchButtonItem1";
            this.switchButtonItem1.OffText = "MAX";
            this.switchButtonItem1.OnText = "MIN";
            this.switchButtonItem1.Tooltip = "Minimizes/Maximizes the Ribbon";
            // 
            // ribbonTabItemGroup4
            // 
            this.ribbonTabItemGroup4.GroupTitle = "New Group";
            this.ribbonTabItemGroup4.Name = "ribbonTabItemGroup4";
            // 
            // 
            // 
            this.ribbonTabItemGroup4.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(109)))), ((int)(((byte)(148)))));
            this.ribbonTabItemGroup4.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(72)))), ((int)(((byte)(123)))));
            this.ribbonTabItemGroup4.Style.BackColorGradientAngle = 90;
            this.ribbonTabItemGroup4.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ribbonTabItemGroup4.Style.BorderBottomWidth = 1;
            this.ribbonTabItemGroup4.Style.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(58)))), ((int)(((byte)(59)))));
            this.ribbonTabItemGroup4.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ribbonTabItemGroup4.Style.BorderLeftWidth = 1;
            this.ribbonTabItemGroup4.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ribbonTabItemGroup4.Style.BorderRightWidth = 1;
            this.ribbonTabItemGroup4.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ribbonTabItemGroup4.Style.BorderTopWidth = 1;
            this.ribbonTabItemGroup4.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonTabItemGroup4.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.ribbonTabItemGroup4.Style.TextColor = System.Drawing.Color.White;
            this.ribbonTabItemGroup4.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.ribbonTabItemGroup4.Style.TextShadowColor = System.Drawing.Color.Black;
            this.ribbonTabItemGroup4.Style.TextShadowOffset = new System.Drawing.Point(1, 1);
            // 
            // ribbonTabItemGroup3
            // 
            this.ribbonTabItemGroup3.Color = DevComponents.DotNetBar.eRibbonTabGroupColor.Orange;
            this.ribbonTabItemGroup3.GroupTitle = "Ovládacie nástroje";
            this.ribbonTabItemGroup3.Name = "ribbonTabItemGroup3";
            // 
            // 
            // 
            this.ribbonTabItemGroup3.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(109)))), ((int)(((byte)(148)))));
            this.ribbonTabItemGroup3.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(72)))), ((int)(((byte)(123)))));
            this.ribbonTabItemGroup3.Style.BackColorGradientAngle = 90;
            this.ribbonTabItemGroup3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ribbonTabItemGroup3.Style.BorderBottomWidth = 1;
            this.ribbonTabItemGroup3.Style.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(58)))), ((int)(((byte)(59)))));
            this.ribbonTabItemGroup3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ribbonTabItemGroup3.Style.BorderLeftWidth = 1;
            this.ribbonTabItemGroup3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ribbonTabItemGroup3.Style.BorderRightWidth = 1;
            this.ribbonTabItemGroup3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ribbonTabItemGroup3.Style.BorderTopWidth = 1;
            this.ribbonTabItemGroup3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonTabItemGroup3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.ribbonTabItemGroup3.Style.TextColor = System.Drawing.Color.White;
            this.ribbonTabItemGroup3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.ribbonTabItemGroup3.Style.TextShadowColor = System.Drawing.Color.Black;
            this.ribbonTabItemGroup3.Style.TextShadowOffset = new System.Drawing.Point(1, 1);
            // 
            // superGridControl1
            // 
            this.superGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superGridControl1.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.superGridControl1.Location = new System.Drawing.Point(0, 140);
            this.superGridControl1.Name = "superGridControl1";
            // 
            // 
            // 
            this.superGridControl1.PrimaryGrid.Columns.Add(this.gridColumn1);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.gridColumn2);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.gridColumn11);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.gridColumn12);
            this.superGridControl1.PrimaryGrid.DataSource = this.tblSTRAINkalBindingSource;
            this.superGridControl1.PrimaryGrid.PrimaryColumnIndex = 1;
            this.superGridControl1.PrimaryGrid.ShowTreeButtons = true;
            this.superGridControl1.PrimaryGrid.ShowTreeLines = true;
            this.superGridControl1.Size = new System.Drawing.Size(437, 301);
            this.superGridControl1.TabIndex = 47;
            this.superGridControl1.Text = "superGridControl1";
            // 
            // gridColumn1
            // 
            this.gridColumn1.DataPropertyName = "IDkalstrain";
            this.gridColumn1.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl);
            this.gridColumn1.HeaderText = "IDkalstrain";
            this.gridColumn1.Name = "IDkalstrain";
            this.gridColumn1.ReadOnly = true;
            // 
            // gridColumn2
            // 
            this.gridColumn2.DataPropertyName = "CisloZakazky";
            this.gridColumn2.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl);
            this.gridColumn2.HeaderText = "CisloZakazky";
            this.gridColumn2.Name = "CisloZakazky";
            // 
            // gridColumn11
            // 
            this.gridColumn11.DataPropertyName = "Zakaznik";
            this.gridColumn11.HeaderText = "Zakaznik";
            this.gridColumn11.Name = "Zakaznik";
            // 
            // gridColumn12
            // 
            this.gridColumn12.DataPropertyName = "CRM";
            this.gridColumn12.HeaderText = "CRM";
            this.gridColumn12.Name = "CRM";
            // 
            // tblSTRAINkalBindingSource
            // 
            this.tblSTRAINkalBindingSource.DataMember = "tblSTRAINkal";
            this.tblSTRAINkalBindingSource.DataSource = this.novaDBcsharpDataSet;
            // 
            // novaDBcsharpDataSet
            // 
            this.novaDBcsharpDataSet.DataSetName = "novaDBcsharpDataSet";
            this.novaDBcsharpDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridColumn3
            // 
            this.gridColumn3.DataPropertyName = "IDkal";
            this.gridColumn3.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl);
            this.gridColumn3.HeaderText = "IDkal";
            this.gridColumn3.Name = "IDkal";
            this.gridColumn3.ReadOnly = true;
            // 
            // gridColumn4
            // 
            this.gridColumn4.DataPropertyName = "Objednavka";
            this.gridColumn4.HeaderText = "Objednavka";
            this.gridColumn4.Name = "Objednavka";
            // 
            // gridColumn5
            // 
            this.gridColumn5.DataPropertyName = "Zakazka";
            this.gridColumn5.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl);
            this.gridColumn5.HeaderText = "Zakazka";
            this.gridColumn5.Name = "Zakazka";
            // 
            // gridColumn6
            // 
            this.gridColumn6.DataPropertyName = "CoefficientA";
            this.gridColumn6.HeaderText = "CoefficientA";
            this.gridColumn6.Name = "CoefficientA";
            // 
            // gridColumn7
            // 
            this.gridColumn7.DataPropertyName = "Error";
            this.gridColumn7.HeaderText = "Error";
            this.gridColumn7.Name = "Error";
            // 
            // gridColumn8
            // 
            this.gridColumn8.DataPropertyName = "NominalWL";
            this.gridColumn8.HeaderText = "NominalWL";
            this.gridColumn8.Name = "NominalWL";
            // 
            // gridColumn9
            // 
            this.gridColumn9.DataPropertyName = "Kalibroval";
            this.gridColumn9.HeaderText = "Kalibroval";
            this.gridColumn9.Name = "Kalibroval";
            // 
            // gridColumn10
            // 
            this.gridColumn10.DataPropertyName = "notes";
            this.gridColumn10.HeaderText = "notes";
            this.gridColumn10.Name = "notes";
            // 
            // tblSTRAINkalTableAdapter
            // 
            // 
            // Strain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 441);
            this.Controls.Add(this.superGridControl1);
            this.Controls.Add(this.ribbonControl2);
            this.Name = "Strain";
            this.Text = "Strain";
            this.ribbonControl2.ResumeLayout(false);
            this.ribbonControl2.PerformLayout();
            this.ribbonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblSTRAINkalBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.novaDBcsharpDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.RibbonControl ribbonControl2;
        private DevComponents.DotNetBar.RibbonPanel ribbonPanel1;
        private DevComponents.DotNetBar.RibbonBar ribbonBar1;
        private DevComponents.DotNetBar.ButtonItem buttonItem2;
        private DevComponents.DotNetBar.RibbonTabItem ribbonTabItem1;
        private DevComponents.DotNetBar.SwitchButtonItem switchButtonItem1;
        private DevComponents.DotNetBar.RibbonTabItemGroup ribbonTabItemGroup4;
        private DevComponents.DotNetBar.RibbonTabItemGroup ribbonTabItemGroup3;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl superGridControl1;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn4;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn5;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn6;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn7;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn8;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn9;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn10;
        private novaDBcsharpDataSet novaDBcsharpDataSet;
        private System.Windows.Forms.BindingSource tblSTRAINkalBindingSource;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn11;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn12;
    }
}