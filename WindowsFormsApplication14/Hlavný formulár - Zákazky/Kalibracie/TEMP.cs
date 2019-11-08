using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication14.Kalibracie
{
    public partial class TEMP : Form
    {
        public TEMP()
        {
            InitializeComponent();
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            Kalibracie.TEMP_new TEMP_new = new Kalibracie.TEMP_new();
            TEMP_new.Show();
        }
    }
}
