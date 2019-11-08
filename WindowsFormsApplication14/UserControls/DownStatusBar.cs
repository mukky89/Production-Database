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
    
    public partial class DownStatusBar : UserControl, INotifyPropertyChanged
    {
        private string _loginName, _opravnenie;

        public string loginName
        {
            get { return _loginName; }
            set
            {
                _loginName = value;
                OnPropertyChanged("loginName");
            }
        }
        public string opravnenie
        {
            get { return _opravnenie; }
            set
            {
                _opravnenie = value;
                OnPropertyChanged("opravnenie");
            }
        }

        protected virtual void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            if (property == "loginName")
                txtPrihlaseny.Text = _loginName;
            if (property == "opravnenie")
                txtOpravnenie.Text = _opravnenie;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public DownStatusBar()
        {
            InitializeComponent();          
        }
    }
}
