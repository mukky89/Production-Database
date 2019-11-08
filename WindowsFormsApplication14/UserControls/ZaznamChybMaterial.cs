using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication14.UserControls
{
    public partial class ZaznamChybMaterial : UserControl
    {
        private UserControl FrmZaznamChybMaterial;
        public ZaznamChybMaterial()
        {
            InitializeComponent();
            FrmZaznamChybMaterial = new UserControl();
        }
    }
}
