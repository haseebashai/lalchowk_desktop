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
using System.IO;
using System.Threading;

namespace Veiled_Kashmir_Admin_Panel
{
    public partial class promomail : Form
    {
        DBConnect obj = new DBConnect();
        MySqlConnection con;
        String cmd, sendername, from, tick= "✔", returned, fileaddress,filename,directory,fullpath, uploaddir;
        MySqlCommandBuilder cmdbl;
        MySqlDataReader dr;
        MySqlDataAdapter adap;
        DataTable dt;
        DataSet ds;
        MySqlCommand mycmd;
        MySqlConnection aconn = new MySqlConnection("SERVER=182.50.133.78;DATABASE=lalchowk_ac;USER=lalchowkac;PASSWORD=Lalchowk@123uzmah");
        int i = 0, maillist, emails, j = 0,emailerrorno;
        List<string> myData = new List<string>();
        PictureBox loading = new PictureBox();
        bool attachment = false;
        string name,bname;



        private dialogcontainer dg = null;
        public promomail(string from,Form dgcopy,string paraname,string bookname)
        {
            dg = dgcopy as dialogcontainer;
            InitializeComponent();
           
            if (from == "")
            {
                totxt.Text = "Enter single email here.";
                totxt.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Italic);
                bgworker1.RunWorkerAsync();
            }
            else
            {
                totxt.Text = from;
                totxt.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
                name = paraname;
                bname = bookname;
            }
        }

        private void bgworker1_DoWork(object sender, DoWorkEventArgs e)
        {
            readlist();
            
        }

        private void bgworker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dg.loadingimage.Visible = false;
            dg.lbl.ForeColor = SystemColors.Highlight;
            dg.lbl.Text = "Send Email";
            emailno.Text = maillist.ToString();
            recno.Text = emails.ToString();
            elistlbl.Text = "Send email to " + recno.Text + " customers today or enter a single email ID.";
            emaillist.DisplayMember = "mail";
            epnl.Visible = true;
        }

        public void loadingnormal()
        {
           
            loading = new PictureBox()
            {
                Image = Properties.Resources.loading,
                Size = new Size(40, 30),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Location = new Point(72, 0),
            };
            this.Controls.Add(loading);
        }
        public void loadingdg()
        {
            
            dg.lbl.ForeColor = SystemColors.Highlight;
            dg.lbl.Text = "Loading";
            dg.loadingimage.SizeMode = PictureBoxSizeMode.StretchImage;
            dg.loadingimage.Visible = true;
        }

        private void promomail_Load(object sender, EventArgs e)
        {

            dg.loadingimage.Visible = false;
            dg.lbl.ForeColor = SystemColors.Highlight;
            dg.lbl.Text = "Send Email";
            epnl.Visible = true;
            frombox.DisplayMember = "Text";
            var items = new[]
            {
                new {Text="support@lalchowk.in"},
                new {Text ="promo@lalchowk.in"},
                new {Text="info@lalchowk.in"},
                 new {Text="noreply@lalchowk.in"},
                new {Text="feedback@lalchowk.in"},
                new {Text="hr@lalchowk.in"}
                
            };
            frombox.DataSource = items;

        }

        public void readlist()
        {

            try
            {
                //offset
                aconn.Open();
                mycmd = new MySqlCommand("select eid,no_of_rec from emailno", aconn);
                dr = mycmd.ExecuteReader();
                dr.Read();
                maillist = int.Parse(dr[0].ToString());
                
                emails = int.Parse(dr[1].ToString());
                
               
                aconn.Close();

                dr = obj.Query("SELECT concat(id,':    ',mail) as mail FROM customer where subscribed=1 ORDER BY id LIMIT " + emails + " OFFSET " + maillist + " ");
                dt = new DataTable();
                dt.Columns.Add("mail", typeof(String));
                dt.Load(dr);
                obj.closeConnection();
                
                emaillist.DataSource = dt;

            }
            catch (Exception ex)
            {
                obj.closeConnection();
                aconn.Close();
                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
            
        }

        private void checkattach_CheckedChanged(object sender, EventArgs e)
        {
            if (checkattach.Checked)
                attachtxt.Visible = true;
            else
            
                attachtxt.Visible = false;
              
        }

        private void feedbtn_Click(object sender, EventArgs e)
        {
            subtxt.Text = "How was your shopping experience with us?";
            bodytxt.Text= "Dear "+name+",\r\n\r\nHope you had a nice shopping experience with www.lalchowk.in\r\nWe would love to read your reviews on our store links here: bit.ly/GetLalchowk or our social media handles @lalchowkonline.\r\nYou can also contact us on our WhatsApp/Phone number: 9906523492\r\n\r\nThanks and warm regards,\r\nTeam Lalchowk";
        
    }

        private void shiplbtn_Click(object sender, EventArgs e)
        {
            subtxt.Text = "Your order has been dispatched!";
            bodytxt.Text= "Dear " + name + ",\r\n\r\nYour order has been dispatched and will be reaching you soon.\r\nPlease keep your phone in reach.\r\n\r\nFor further assistance, you can reach out to us on our WhatsApp/Phone number: 9906523492\r\n\r\nTeam Lalchowk";

        }

        private void shippbtn_Click(object sender, EventArgs e)
        {
            subtxt.Text = "Your order has been dispatched!";
            bodytxt.Text = "Dear " + name + ",\r\n\r\nYour order has been dispatched via SpeedPost and will reach you in few days.\r\nYou can track your order on indiapost.gov.in using tracking number: \r\nPlease keep your phone in reach.\r\n\r\nFor further assistance, you can reach out to us on our WhatsApp/Phone number: 9906523492\r\n\r\nTeam Lalchowk";

        }

        private void breqbtn_Click(object sender, EventArgs e)
        {
            subtxt.Text = "Your request has been processed!";
           bodytxt.Text= "Dear " + name + ",\r\n\r\nYour requested book ' " + bname + " ' is currently not available.\r\nWe hope to serve you better next time.\r\nFor further assistance, you can reach out to us on our WhatsApp/Phone number: 9906523492\r\n\r\nTeam Lalchowk";

        }

        private string sendmail(string from)
        {

            try
            {
               
                SmtpClient Smtpobj = new SmtpClient();
                Smtpobj.Host = "smtp.zoho.com";
                Smtpobj.Port = 587;
                Smtpobj.UseDefaultCredentials = false;
                Smtpobj.EnableSsl = true;
                Smtpobj.Credentials = new NetworkCredential(from, "Lalchowk@123");
                Smtpobj.DeliveryMethod = SmtpDeliveryMethod.Network;

               
                dr =obj.Query(" SELECT mail FROM customer where subscribed=1 ORDER BY id LIMIT " + emails + " OFFSET " + maillist + "");

                i = 0;
                j = 0;
                while (dr.Read())
                {
                   
                    var recipients = new MailAddress(dr["mail"].ToString());
                    MailMessage mail = new MailMessage(from,recipients.ToString());
                    mail.From = new MailAddress(from, sendername);
                    mail.Subject = subtxt.Text;
                    mail.Body = bodytxt.Text;
                    mail.IsBodyHtml = true;
                    myData.Add(dr["mail"].ToString());
                    if (checkattach.Checked && attachment)
                    {
                        uploaddir = directory + attachtxt.Text;
                        mail.Attachments.Add(new Attachment(uploaddir));
                        Smtpobj.Send(mail);
                    }
                    else
                    {
                        Smtpobj.Send(mail);
                    }

                    j++;
                    i += 100/emails;
                    bgworker.ReportProgress(i);
                    Thread.Sleep(2000);
                }
                obj.closeConnection();

                bgworker.ReportProgress(100);
                MessageBox.Show("Mail Sent.");
                


                return (null);

            }
            catch (Exception ex)
            {
                obj.closeConnection();
                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message, "Error!");
            

            if (myData.Count == 0)
                {
                    
                    return ("shit");
                }
                else
                return (myData[j]);

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
                case "promo@lalchowk.in":
                    sendername = "Lalchowk Promos";
                    from = "promo@lalchowk.in";
                    break;
                case "hr@lalchowk.in":
                    sendername = "Human Resources";
                    from = "hr@lalchowk.in";
                    break;
                case "noreply@lalchowk.in":
                    sendername = "Lalchowk";
                    from = "noreply@lalchowk.in";
                    break;
                   
                default:
                    MessageBox.Show("select a valid email.");
                    break;
            }
        }

        private void setrecno_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                aconn.Open();
                mycmd = new MySqlCommand("update emailno set no_of_rec = '" + recno.Text + "' where id=1", aconn);
                mycmd.ExecuteNonQuery();
                aconn.Close();
                emails = int.Parse(recno.Text);
                elistlbl.Text = "Send email to " + emails + " customers today or enter a single email ID.";
                readlist();
            }
            catch (Exception ex)
            {
                aconn.Close();
                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
            Cursor = Cursors.Arrow;
        }

        private void totxt_Leave(object sender, EventArgs e)
        {
            if (totxt.Text =="")
            {

                totxt.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Italic);
                totxt.Text = "Enter single email here.";
            }

        }

        private void attachtxt_Click(object sender, EventArgs e)
        {
            if (attachdialog.ShowDialog() == DialogResult.OK)
            {
                fileaddress = attachdialog.FileName;
                filename = attachdialog.SafeFileName;
                
               
               
                fullpath = Path.GetFullPath(fileaddress).TrimEnd(Path.DirectorySeparatorChar);
                directory = Path.GetDirectoryName(fullpath) + "\\";
                attachtxt.Text = Path.GetFileName(fullpath);
                attachment = true;

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



       

        private void setemailno_Click(object sender, EventArgs e)
        {
            try
            {
                aconn.Open();
                mycmd = new MySqlCommand("update emailno set eid = '" + emailno.Text + "' where id=1", aconn);
                mycmd.ExecuteNonQuery();
                aconn.Close();

                readlist();
            }
            catch (Exception ex)
            {
                aconn.Close();
                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }

        private void bgworker_DoWork(object sender, DoWorkEventArgs e)
        {
            var bgworker = sender as BackgroundWorker;         
            returned= sendmail(from);
           
            
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
            if (subtxt.Text == "")
            {
                MessageBox.Show("Please enter subject.");
            }
            else if (totxt.Text == "" || totxt.Text == "Enter single email here.")
                {

                    DialogResult dgr = MessageBox.Show("Do you want to send emails now?", "Confirm", MessageBoxButtons.YesNo);
                    if (dgr == DialogResult.Yes)
                    {
                        sendbtn.Enabled = false;
                        timer.Start();
                        bgworker.RunWorkerAsync();
                    }

                }
                else
                {
                    Cursor = Cursors.WaitCursor;

                    try
                    {
                        StringBuilder s = new StringBuilder(bodytxt.Text);
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


                        MailMessage mail = new MailMessage(from, totxt.Text);
                        mail.From = new MailAddress(from, sendername);
                        mail.Subject = s1.ToString();
                        mail.Body = s.ToString();
                        if (checkhtml.Checked)
                        {
                            mail.IsBodyHtml = true;

                        }

                        if (checkattach.Checked && attachment)
                        {
                            uploaddir = directory + attachtxt.Text;
                            mail.Attachments.Add(new Attachment(uploaddir));
                            Smtpobj.Send(mail);
                        }
                        else
                        {
                            Smtpobj.Send(mail);

                        }




                        sendinglbl.Text = "";
                        MessageBox.Show("Mail Sent.");
                    }
                catch (Exception ex)
                {

                    MessageBox.Show("Something happened, please try again.\n\n" + ex.Message, "Error!");
                }
                Cursor = Cursors.Arrow;
                }
           
        }

        int numberOfPoints = 0;
        private void timer_Tick(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            int maxPoints = 5;
            sendinglbl.Text = "Sending" + new string('.', numberOfPoints);
            numberOfPoints = (numberOfPoints + 1) % (maxPoints + 1);
        }

        private void bgworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           
            sendbtn.Enabled = true;
            timer.Stop();
            sendinglbl.Text = "";
            tolbl.Text = "";
            progressBar1.Value = 0;
            progressBar1.Visible = false;

            Cursor = Cursors.WaitCursor;
            try { 
            if (returned == null)
            {
                    aconn.Open();
                    mycmd = new MySqlCommand("update emailno set eid = (eid + '" + myData.Count + "') where id=1", aconn); //emails
                    mycmd.ExecuteNonQuery();
                    aconn.Close();
                    //BackgroundWorker email1 = new BackgroundWorker();
                    //email1.DoWork += (o, a) => 
                    //{
                    //    aconn.Open();
                    //    mycmd = new MySqlCommand("update emailno set eid = (eid + '" + myData.Count + "') where id=1", aconn); //emails
                    //    mycmd.ExecuteNonQuery();
                    //    aconn.Close();
                    //};
                    //email1.RunWorkerCompleted += (o, b) => 
                    //{
                    //    Cursor = Cursors.Arrow;
                    //    aconn.Close();
                    //};
                    //email1.RunWorkerAsync();
                    
                }
            else if (returned == "shit")
            {
                MessageBox.Show("Please check your internet connection.");

            }
            else{
                    Cursor = Cursors.WaitCursor;
                dr = obj.Query("select id from customer where mail='" + myData[j] + "'");
                dr.Read();
                emailerrorno = int.Parse(dr[0].ToString());
                obj.closeConnection();
                

                aconn.Open();
                mycmd = new MySqlCommand("update emailno set eid = ((eid + " + myData.Count + ")-1) where id=1", aconn);
                mycmd.ExecuteNonQuery();
                aconn.Close();
                    Cursor = Cursors.Arrow;
                MessageBox.Show("Email sending failed from: " + myData[j] + "\nPlease Check the error and continue sending emails.","Error!");
                   
                }
            }
            catch (Exception ex)
            {
                obj.closeConnection();
                aconn.Close();
                Cursor = Cursors.Arrow;
                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
            myData.Clear();
            Cursor = Cursors.WaitCursor;
            readlist();
                emailno.Text = maillist.ToString();
                recno.Text = emails.ToString();
                elistlbl.Text = "Send email to " + recno.Text + " customers today or enter a single email ID.";
                emaillist.DisplayMember = "mail";
                Cursor = Cursors.Arrow;
           


        }
    }
 
}

        

