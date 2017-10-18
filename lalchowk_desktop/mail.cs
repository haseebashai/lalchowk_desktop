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
using System.Collections;
using MySql.Data.MySqlClient;

namespace Veiled_Kashmir_Admin_Panel
{
    public partial class mail : Form
    {
        DBConnect obj = new DBConnect();
        String email, cmd, msgid, sendername, emails;
        MySqlDataReader dr;
        MySqlCommand mysqlcmd, mycmd;

        public mail(string emailto, string subject, string message, string mid)
        {
            InitializeComponent();
            totxt.Text = emailto;
            email = emailto;
            subtxt.Text = subject;
            msgtxt.Text = message;
            msgid = mid;
        }


        private void closebtn_Click(object sender, EventArgs e)
        {
            Close();
        }



        private void sendmail()
        {
            Cursor = Cursors.WaitCursor;
            try
            {


                StringBuilder s = new StringBuilder(bodytxt.Text);
                s.Replace(@"\", @"\\");
                s.Replace("'", "\\'");
                StringBuilder s1 = new StringBuilder(subtxt.Text);
                s1.Replace(@"\", @"\\");
                s1.Replace("'", "\\'");



                SmtpClient Smtpobj = new SmtpClient();
                Smtpobj.Host = "smtp.zoho.com";
                Smtpobj.Port = 587;
                Smtpobj.UseDefaultCredentials = false;
                Smtpobj.EnableSsl = true;
                Smtpobj.Credentials = new NetworkCredential(frombox.Text, "Lalchowk@123");
                Smtpobj.DeliveryMethod = SmtpDeliveryMethod.Network;

                
                MailMessage mail = new MailMessage(frombox.Text, totxt.Text);
                mail.From = new MailAddress(frombox.Text, sendername);
                mail.Subject = s1.ToString();
                mail.Body = s.ToString();
                mail.IsBodyHtml = true;

                Smtpobj.Send(mail);
                Cursor = Cursors.Arrow;

                MessageBox.Show("Mail Sent.");
                obj.closeConnection();
            }
                           
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }
    

        private void frombox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (frombox.Text)
            {
                case "support@lalchowk.in":
                    sendername = "Lalchowk Support";
                    break;
                case "feedback@lalchowk.in":
                    sendername = "Lalchowk Feedback";
                    break;
                case "info@lalchowk.in":
                    sendername = "Lalchowk Info";
                    break;
                case "hr@lalchowk.in":
                    sendername = "Human Resources";
                    break;
                default:
                    MessageBox.Show("select a valid email.");
                    break;
            }
        }

        private void sendbtn_Click(object sender, EventArgs e)
        {
            sendmail();
            cmd = "UPDATE `lalchowk`.`messages` SET `reply`='" + bodytxt.Text + "' WHERE `messageid`='" + msgid + "'";
            obj.nonQuery(cmd);
            this.Close();
           
        }

        private void mail_Load(object sender, EventArgs e)
        {
            frombox.DisplayMember = "Text";
            var items = new[]
            {
                new {Text="support@lalchowk.in"},
                new {Text="feedback@lalchowk.in"},
                new {Text="info@lalchowk.in"},
                new {Text="hr@lalchowk.in"}

            };
            frombox.DataSource = items;
        }
    }

   
    }
