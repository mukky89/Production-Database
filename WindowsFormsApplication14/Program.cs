using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace WindowsFormsApplication14
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Zakazky());
        }

        public static SqlConnection GetConnection
        {
            get
            {
                string ConnectionString = Class1.dbs_nastavenia("DBS_connection_string");
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                return con;
            }
        }
    }
}
