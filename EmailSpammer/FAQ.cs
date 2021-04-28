using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Configuration;

namespace EmailSpammer
{
    public partial class FAQ : Form
    {
        public FAQ()
        {

            InitializeComponent();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://myaccount.google.com/lesssecureapps?");
        }

        private void FAQ_Load(object sender, EventArgs e)
        {
            var language = ConfigurationManager.AppSettings["language"];

            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(language);
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(language);
        }
    }
}
