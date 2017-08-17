using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace Veiled_Kashmir_Admin_Panel
{
    public partial class mail : Form
    {
        DBConnect obj = new DBConnect();
        String email,cmd,msgid;

        public mail(string emailto,string subject,string message,string mid)
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
            string password = "Lalchowk@123uzmah";
                try
                {
                StringBuilder s = new StringBuilder(bodytxt.Text);
                s.Replace(@"\", @"\\");
                s.Replace("'", "\\'");
                StringBuilder s1 = new StringBuilder(subtxt.Text);
                s1.Replace(@"\", @"\\");
                s1.Replace("'", "\\'");

                    MailMessage mail = new MailMessage();
                    
                    mail.From = new MailAddress(frombox.Text);
                    mail.To.Add(new MailAddress(email));
                
                    mail.Subject = "Reply: "+ s1;
                    mail.Body = s + Environment.NewLine + Environment.NewLine + "Regards,"+Environment.NewLine+"Lalchowk";

                //   Smtpobj.Credentials = new System.Net.NetworkCredential(frombox.Text, password);
                //  Smtpobj.EnableSsl = true;
                SmtpClient client = new SmtpClient();
                    client.Send(mail);
                    MessageBox.Show("Mail Sent.");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }

        private void sendbtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Does not work yet.");
            this.Close();

        //    cmd = "UPDATE `lalchowk`.`messages` SET `reply`='" + bodytxt.Text + "' WHERE `messageid`='"+ msgid+"'";
          //  obj.nonQuery(cmd);
        }

        private void mail_Load(object sender, EventArgs e)
        {
            frombox.DisplayMember = "Text";
            var items = new[]
            {
                new {Text="support@lalchowk.in"},
                new {Text="feedback@lalchowk.in"}
            };
            frombox.DataSource = items;
        }
    }

   
    }
