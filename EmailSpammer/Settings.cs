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
    public partial class Settings : Form
    {
        public Settings()
        {

            InitializeComponent();
        }

        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblLanguage.Text = cmbLanguage.SelectedIndex.ToString();           
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (lblLanguage.Text != "label")
            {
             if (lblLanguage.Text == "0") //english
                {

                    var changeLanguage = new ChangeLanguage();
                    changeLanguage.UpdateConfig("language", "en");
                    Application.Restart();
                }   else if (lblLanguage.Text == "1") //deutsch
                {

                    var changeLanguage = new ChangeLanguage();
                    changeLanguage.UpdateConfig("language", "de");
                    Application.Restart();
                }else if (lblLanguage.Text == "2")
                {
                    var changeLanguage = new ChangeLanguage();
                    changeLanguage.UpdateConfig("language", "fr");
                    Application.Restart();
                }
            }
            else
            {
                MessageBox.Show("Please select a Setting to apply it!","Warnings",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            lblLanguage.Visible = false;
            var language = ConfigurationManager.AppSettings["language"];

            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(language);
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(language);
        }
    }
}
