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
    public partial class Strain : Form
    {
        public Strain()
        {
            InitializeComponent();
        }


        private void buttonItem2_Click(object sender, EventArgs e)
        {
            Kalibracie.STRAIN_new STRAIN_new = new Kalibracie.STRAIN_new();
            STRAIN_new.Show();


        }
    }
}
