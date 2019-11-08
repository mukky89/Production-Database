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
    
    public partial class BarRevizieFormulare : UserControl
    {
        private UserControl BarRevizie;
        public BarRevizieFormulare()
        {
            InitializeComponent();
             BarRevizie = new UserControl();
        }
    }
}
