using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.IO;
using System.Configuration;

namespace EmailSpammer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            var language = ConfigurationManager.AppSettings["language"];

            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(language);
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(language);

            InitializeComponent();         
        }

        
    
        private void LinklblLaugny_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            System.Diagnostics.Process.Start("https://www.laugny.com");
        }

        private void btnShowPw_Click(object sender, EventArgs e)
        {
            if (chkBoxPWChar.Checked == true)
            {
                chkBoxPWChar.Checked = false;
            }
            else
            {
                chkBoxPWChar.Checked = true;
            }
        }

        private void chkBoxPWChar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxPWChar.Checked == true)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var language = ConfigurationManager.AppSettings["language"];

            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(language);
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(language);

            chkBoxPWChar.Checked = true;
            txtStatus.Text = "STOPPED";
        }

        private void lblFAQ_Click(object sender, EventArgs e)
        {
            FAQ faq = new FAQ();
            faq.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            

            if (txtBody.Text == "" || txtPassword.Text == "" || txtReceiverEmail.Text == "" || txtSenderEmail.Text == "" || txtSubject.Text == "")
            {
                MessageBox.Show("Please fill out all missing fields!","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                if (emailCount.Text == "0")
                {
                    MessageBox.Show("Email sending count must be over 0","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                else
                {
                    spamm();
                }
            }
        }

        public void spamm()
        {
            txtStatus.Text = "SPAMMING";
            string emailCountString = emailCount.Text;
            int count = Convert.ToInt32(emailCountString);

            for (int i = 1; i <= count; i++) 
            {

               

                Random rnd = new Random();

                int randomInt = rnd.Next(8242, 383724);



            string to, from, pass, messageBody;
            MailMessage message = new MailMessage();
            to = txtReceiverEmail.Text;
            from = txtSenderEmail.Text;
            pass = txtPassword.Text;
            messageBody = txtBody.Text;
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = messageBody;
            message.Subject = txtSubject.Text + randomInt.ToString();
            message.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);

            

            progressBar.Maximum = count;

                try
                {
                    smtp.Send(message);
                }
                catch
                {
                }

            progressBar.Increment(1);
            Thread.Sleep(300);          
                
            }
            MessageBox.Show("Successfully spammed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtStatus.Text = "STOPPED";
            progressBar.Value = 0;
        }

        private void emailCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if(!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.Show();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtBody.Text = "";
            txtPassword.Text = "";
            txtReceiverEmail.Text = "";
            txtSenderEmail.Text = "";
            txtSubject.Text = "";
            emailCount.Text = "0";
        }
    }
}
