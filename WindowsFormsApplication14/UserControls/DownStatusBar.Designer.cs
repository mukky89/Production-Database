namespace WindowsFormsApplication14.UserControls
{
    partial class DownStatusBar
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
        public void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblPrihlaseny = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtPrihlaseny = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblOpravnenie = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtOpravnenie = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblPrihlaseny,
            this.txtPrihlaseny,
            this.lblOpravnenie,
            this.txtOpravnenie});
            this.statusStrip1.Location = new System.Drawing.Point(0, 1);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1091, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblPrihlaseny
            // 
            this.lblPrihlaseny.Name = "lblPrihlaseny";
            this.lblPrihlaseny.Size = new System.Drawing.Size(67, 17);
            this.lblPrihlaseny.Text = "Prihlásený :";
            // 
            // txtPrihlaseny
            // 
            this.txtPrihlaseny.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtPrihlaseny.Name = "txtPrihlaseny";
            this.txtPrihlaseny.Size = new System.Drawing.Size(0, 17);
            // 
            // lblOpravnenie
            // 
            this.lblOpravnenie.Name = "lblOpravnenie";
            this.lblOpravnenie.Size = new System.Drawing.Size(74, 17);
            this.lblOpravnenie.Text = "Oprávnenie :";
            // 
            // txtOpravnenie
            // 
            this.txtOpravnenie.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtOpravnenie.Name = "txtOpravnenie";
            this.txtOpravnenie.Size = new System.Drawing.Size(0, 17);
            // 
            // DownStatusBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStrip1);
            this.Name = "DownStatusBar";
            this.Size = new System.Drawing.Size(1091, 23);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripStatusLabel lblPrihlaseny;
        private System.Windows.Forms.ToolStripStatusLabel lblOpravnenie;
        public System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel txtPrihlaseny;
        public System.Windows.Forms.ToolStripStatusLabel txtOpravnenie;
    }
}
