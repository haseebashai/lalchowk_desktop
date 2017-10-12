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
        String cmd, sendername, from, tick= "✔";
        MySqlCommandBuilder cmdbl;
        MySqlDataReader dr;
        MySqlDataAdapter adap;
        DataTable dt;
        DataSet ds;
        MySqlCommand mycmd;
        int i = 0, maillist, emails = 6;
        List<string> myData = new List<string>();

        


        public promomail(string from)
        {
            InitializeComponent();
            if (from == "")
            {
                totxt.Text = "Enter single email here.";
                totxt.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Italic);
            }
            else
            {
                totxt.Text = from;
                totxt.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
            }
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


            //offset
            dr = obj.Query("select eid from emailno");
            dr.Read();
            maillist = int.Parse(dr[0].ToString());
            obj.closeConnection();

            dr = obj.Query("SELECT email FROM email ORDER BY id LIMIT "+emails+" OFFSET "+maillist+" ");            
            dt = new DataTable();
            dt.Columns.Add("email", typeof(String));
            dt.Load(dr);           
            obj.closeConnection();
            emaillist.DisplayMember = "email";
            emaillist.DataSource = dt;

           

        }

        int emailerrorno;
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

                dr=obj.Query(" SELECT email FROM email ORDER BY id LIMIT " + emails + " OFFSET " + maillist + "");
                
                i = 0;
               
                while (dr.Read())
                {
                    
                    var recipients = new MailAddress(dr["email"].ToString());
                    MailMessage mail = new MailMessage(from,recipients.ToString());
                    mail.From = new MailAddress(from, sendername);
                    mail.Subject = s1.ToString();
                    mail.Body = s.ToString();
                    mail.IsBodyHtml = true;
                    myData.Add(dr["email"].ToString());
                    Smtpobj.Send(mail);

                   
                    i += 100/emails;
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
                obj.closeConnection();
                return (myData[i]);

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



        string returned;
        private void bgworker_DoWork(object sender, DoWorkEventArgs e)
        {
            var bgworker = sender as BackgroundWorker;
           
            if (totxt.Text == ""||totxt.Text=="Enter single email here.")
            {               
                   
              returned= sendmail(from);
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

                    i = 0;
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
            for (int i = 0; i < myData.Count; i++)
            {
                tolbl.Text = "Sending to: " + myData[i] +"  " + tick;
            }    
            
        }


        private void sendbtn_Click(object sender, EventArgs e)
        {
            
            sendbtn.Enabled = false;
            timer.Start();
            bgworker.RunWorkerAsync();
            
        }

        int numberOfPoints = 0;
        private void timer_Tick(object sender, EventArgs e)
        {
            int maxPoints = 5;
            sendinglbl.Text = "Sending" + new string('.', numberOfPoints);
            numberOfPoints = (numberOfPoints + 1) % (maxPoints + 1);
        }

        private void bgworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           
            sendbtn.Enabled = true;
            totxt.Text = "";
            subtxt.Text = "";
            tolbl.Text = "";
            timer.Stop();
            sendinglbl.Text = "";           
            progressBar1.Value = 0;

            
            
            if (returned == null)
            {
                cmd = ("update emailno set eid = (eid + '" + emails + "') where id=1 ");
                obj.nonQuery(cmd);
                obj.closeConnection();

                
            }
            else
            {
                dr = obj.Query("select id from email where email='" + myData[i] + "'");
                dr.Read();
                emailerrorno = int.Parse(dr[0].ToString());
                obj.closeConnection();

                cmd = ("update emailno set eid = ((eid + '" + emailerrorno + "')-1) where id=1 ");
                obj.nonQuery(cmd);
                obj.closeConnection();
            }
            readlist();


        }
    }
}

        

