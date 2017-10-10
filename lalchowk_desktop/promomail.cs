using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Net.Mail;
using System.Net;
using System.Threading;

namespace Veiled_Kashmir_Admin_Panel
{
    public partial class promomail : Form
    {
        DBConnect obj = new DBConnect();
        MySqlConnection con;
        String cmd, sendername, from;
        MySqlCommandBuilder cmdbl;
        MySqlDataReader dr;
        MySqlDataAdapter adap;
        DataTable dt;
        DataSet ds;
        MySqlCommand mycmd;
        int emailno;




        public promomail(string from)
        {
            InitializeComponent();
            totxt.Text = from;
        }

        private void promomail_Load(object sender, EventArgs e)
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

        public void readlist()
        {
            dr = obj.Query("select mail from customer");
            dt = new DataTable();
            dt.Columns.Add("mail", typeof(String));
            dt.Load(dr);
            obj.closeConnection();
            emaillist.DisplayMember = "mail";
            emaillist.DataSource = dt;

            dr = obj.Query("select count(mail) from customer");
            dr.Read();
            emailno = int.Parse(dr[0].ToString());
            elistlbl.Text = "Send email to all " + emailno + " customers or enter a single email ID.";
            obj.closeConnection();
        }


        private string sendmail(string from)
        {

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
                Smtpobj.Credentials = new NetworkCredential(from, "Lalchowk@123");
                Smtpobj.DeliveryMethod = SmtpDeliveryMethod.Network;
                Smtpobj.Timeout = 30000;

                dr=obj.Query(" select mail from customer");
               
                int i = 0;
                    while (dr.Read())
                {
                     
                    var recipients = new MailAddress(dr["email"].ToString());
                    MailMessage mail = new MailMessage(from,recipients.ToString());
                    mail.From = new MailAddress(from, sendername);
                    mail.Subject = s1.ToString();
                    mail.Body = s.ToString();
                    mail.IsBodyHtml = true;
                    
                    Smtpobj.Send(mail);
                    i += 100/emailno;
                    bgworker.ReportProgress(i);
                    
                }
                obj.closeConnection();

                bgworker.ReportProgress(100);
                MessageBox.Show("Mail Sent.");
               

                return (null);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
                return null;
            }
        }


        private void frombox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (frombox.Text)
            {
                case "support@lalchowk.in":
                    sendername = "Lalchowk Support";
                    from = "support@lalchowk.in";
                    break;
                case "feedback@lalchowk.in":
                    sendername = "Lalchowk Feedback";
                    from = "feedback@lalchowk.in";
                    break;
                case "info@lalchowk.in":
                    sendername = "Lalchowk Info";
                    from = "info@lalchowk.in";
                    break;
                case "hr@lalchowk.in":
                    sendername = "Human Resources";
                    from = "hr@lalchowk.in";
                    break;
                default:
                    MessageBox.Show("select a valid email.");
                    break;
            }
        }

        private void totxt_Enter(object sender, EventArgs e)
        {

            if (totxt.Text == "Enter single email here.")
            {
                totxt.Text = "";
                totxt.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
            }
           
        }

        private void bgworker_DoWork(object sender, DoWorkEventArgs e)
        {
            var bgworker = sender as BackgroundWorker;
           
            if (totxt.Text == ""||totxt.Text=="Enter single email here.")
            {               
                   
               sendmail(from);
            }
            else
            {

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
                    Smtpobj.Credentials = new NetworkCredential(from, "Lalchowk@123");
                    Smtpobj.DeliveryMethod = SmtpDeliveryMethod.Network;

                    int i = 0;
                    MailMessage mail = new MailMessage(from, totxt.Text);
                    mail.From = new MailAddress(from, sendername);
                    mail.Subject = s1.ToString();
                    mail.Body = s.ToString();
                    mail.IsBodyHtml = true;
                    
                    Smtpobj.Send(mail);
                    i += 100 / 1;
                    bgworker.ReportProgress(i);


                    MessageBox.Show("Mail Sent.");
                    


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());

                }
                
            }
            
        }

        private void bgworker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            
        }


        private void sendbtn_Click(object sender, EventArgs e)
        {
            
            sendbtn.Enabled = false;
            bgworker.RunWorkerAsync();
            
        }

        private void bgworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           
            sendbtn.Enabled = true;
            totxt.Text = "";
            subtxt.Text = "";
            bodytxt.Text = "";
            progressBar1.Value = 0;

        }
    }
}

        

