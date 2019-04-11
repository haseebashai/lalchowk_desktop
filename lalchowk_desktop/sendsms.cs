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
using System.Web;
using System.IO;
using MySql.Data.MySqlClient;
using System.Runtime.InteropServices;

namespace Veiled_Kashmir_Admin_Panel
{
    public partial class sendsms : Form
    {

        DBConnect obj = new DBConnect();
        MySqlDataReader dr;
        string bname,cname;


        public sendsms(string contact, string bookname,string name)
        {
            InitializeComponent();

            numbertxt.Text = contact;
            bname = bookname;
            cname = name;
            sendertxt.Text = "LALCHK";
            smstxt.Focus();
            //if (contact == ""||bookname==""||name=="")
            //{
            //    numbertxt.Text = contact;

            //    sendertxt.Text = "LALCHK";
            //}
            //else
            //{
            //    numbertxt.Text = contact;
            //    bname = bookname;
            //    cname = name;
            //    sendertxt.Text = "LALCHK";
            //    smstxt.Focus();

            //}

        }


        private void singlesms()
        {
            Cursor = Cursors.WaitCursor;
            //     string authKey = "180732AO0nQdUZo759f09569";             //Your authentication key

            string authKey = "219357Aj6P2wTP5b1902ab";

            string mobileNumber = numbertxt.Text;                   //Multiple mobiles numbers separated by comma

            string senderId = sendertxt.Text;                        //Sender ID,While using route4 sender id should be 6 characters long.

            string message = HttpUtility.UrlEncode(smstxt.Text);    //Your message to send, Add URL encoding here.

            //Prepare you post parameters
            StringBuilder sbPostData = new StringBuilder();
            sbPostData.AppendFormat("authkey={0}", authKey);
            sbPostData.AppendFormat("&mobiles={0}", mobileNumber);
            sbPostData.AppendFormat("&message={0}", message);
            sbPostData.AppendFormat("&sender={0}", senderId);
            sbPostData.AppendFormat("&route={0}", "4");
            sbPostData.AppendFormat("&country={0}", "91");

            try
            {
                //Call Send SMS API
                string sendSMSUri = "http://api.msg91.com/api/sendhttp.php";
                //Create HTTPWebrequest
                HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(sendSMSUri);
                //Prepare and Add URL Encoded data
                UTF8Encoding encoding = new UTF8Encoding();
                byte[] data = encoding.GetBytes(sbPostData.ToString());
                //Specify post method
                httpWReq.Method = "POST";
                httpWReq.ContentType = "application/x-www-form-urlencoded";
                httpWReq.ContentLength = data.Length;

                using (Stream stream = httpWReq.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
                //Get the response
                HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string responseString = reader.ReadToEnd();

                //Close the response
                reader.Close();
                response.Close();
                sentlbl.Visible = true;
            }
            catch (SystemException ex)
            {
                sentlbl.Text = "Sending failed X";
                sentlbl.ForeColor = Color.Red;
                Cursor = Cursors.Arrow;
                MessageBox.Show(ex.Message.ToString());
            }
            Cursor = Cursors.Arrow;
        }

     
        BackgroundWorker smsloop = new BackgroundWorker();
        string sentfrom;
        private void sendsmsbtn_Click(object sender, EventArgs e)
        {

            sendsmsbtn.Enabled=false;
            sentlbl.Visible = false;
            if (sendertxt.Text == "")
            {
                MessageBox.Show("Please enter sender.", "Error!");
                sendsmsbtn.Enabled = true;
            }
            else if (numbertxt.Text == "" || numbertxt.Text == "Enter numbers seperated with comma")
            {
                MessageBox.Show("Please enter recievers.", "Error!");
                sendsmsbtn.Enabled = true;
            }
            else if (smstxt.Text == "")
            {
                MessageBox.Show("Please enter message body.", "Error!");
                sendsmsbtn.Enabled = true;
            }
            else
            {
                if (loop)
                {
                    try
                    {
                        
                        sentfrom = sendertxt.Text;
                        string[] txtNumbers = numbertxt.Text.Split(',');
                        foreach (string nbr in txtNumbers)
                        {
                            string number = nbr;
                            numList.Add(number);
                        }
                        progressBar1.Maximum = numList.Count;
                        smsloop.DoWork += Smsloop_DoWork;
                        smsloop.RunWorkerCompleted += Smsloop_RunWorkerCompleted;
                        smsloop.WorkerReportsProgress = true;
                        smsloop.ProgressChanged += Smsloop_ProgressChanged;
                        smsloop.RunWorkerAsync();
                  
                       
                    }
                    catch (Exception exce)
                    {
                        sentlbl.Visible = true;
                        MessageBox.Show( exce.Message.ToString());
                        sendsmsbtn.Enabled = true;
                    }

                }
                else
                {
                    if (numbertxt.TextLength > 21)
                    {
                        MessageBox.Show("For more than 2 numbers, please check Loop option.", "Warning");
                    }
                    else
                    {
                        singlesms();
                        sendsmsbtn.Enabled = true;
                    }
                }
            }

        }

        private void Smsloop_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
           
            progressBar1.Visible = true;
            
            string count = (string)e.UserState;
            tolbl.Text = "Sending to: " + count;
            maxcountlbl.Text = "(" + e.ProgressPercentage.ToString() + "/" + numList.Count + ")";
            maxcountlbl.Visible = true;
            progressBar1.Value = e.ProgressPercentage;
            tolbl.Visible = true;
        }

        private void Smsloop_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string result = (string)e.Result;
            if (result == "fail")
            {
                sentlbl.Text = "Sending to some numbers failed X";
                sentlbl.ForeColor = Color.Red;
                sentlbl.Visible = true;
            }
            else if(result=="success")
            {
                sentlbl.Text = "MESSAGE SENT ✔";
                sentlbl.ForeColor = Color.Green;
                sentlbl.Visible = true;
                tolbl.Text = "All Messages sent.";
                progressBar1.Value = progressBar1.Maximum;
                maxcountlbl.Text = "(" + numList.Count + "/" + numList.Count + ")";
                MessageBox.Show("Messages sent.", "Success!");
            }
            sendsmsbtn.Enabled = true;
           // numList.Clear();

         

        }


        private void Smsloop_DoWork(object sender, DoWorkEventArgs e)
        {

            
            for (int i = 0; i < numList.Count; i++)
            {
                
                smsloop.ReportProgress(i, numList[i]);
                string authKey = "219357Aj6P2wTP5b1902ab";             //Your authentication key

                string mobileNumber = numList[i];                   //Multiple mobiles numbers separated by comma

                string senderId = sentfrom;                        //Sender ID,While using route4 sender id should be 6 characters long.

                string message = HttpUtility.UrlEncode(smstxt.Text);    //Your message to send, Add URL encoding here.
                

                //Prepare you post parameters
                StringBuilder sbPostData = new StringBuilder();
                sbPostData.AppendFormat("authkey={0}", authKey);
                sbPostData.AppendFormat("&mobiles={0}", mobileNumber);
                sbPostData.AppendFormat("&message={0}", message);
                sbPostData.AppendFormat("&sender={0}", senderId);
                sbPostData.AppendFormat("&route={0}", "4");
                sbPostData.AppendFormat("&country={0}", "91");



                try
                {
                    //Call Send SMS API
                    string sendSMSUri = "http://api.msg91.com/api/sendhttp.php";
                    //Create HTTPWebrequest
                    HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(sendSMSUri);
                    //Prepare and Add URL Encoded data
                    UTF8Encoding encoding = new UTF8Encoding();
                    byte[] data = encoding.GetBytes(sbPostData.ToString());
                    //Specify post method
                    httpWReq.Method = "POST";
                    httpWReq.ContentType = "application/x-www-form-urlencoded";
                    httpWReq.ContentLength = data.Length;

                    using (Stream stream = httpWReq.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }
                    //Get the response
                    HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    string responseString = reader.ReadToEnd();

                    //Close the response
                    reader.Close();
                    response.Close();

                }
                catch (SystemException ex)
                {
                    e.Result = "fail";


                    sentlbl.Text = ex.Message.ToString();
                }
                Random rnd = new Random();
                int time = rnd.Next(1000, 6000);
                System.Threading.Thread.Sleep(time);
            }
            e.Result = "success";
            numList.Clear();

        }

        private void getnumbersbtn_Click(object sender, EventArgs e)
        {
            
            try {
                string command = "";
                if (limittxt.Text == "Enter LIMIT" || limittxt.Text == "" || offsettxt.Text == "Enter Offset" || offsettxt.Text == "")
                {
                    MessageBox.Show("Enter Limit and offset.");

                }
                else
                {
                    command = "select distinct contact from customer where subscribed =1 and contact like '7%' or contact like '8%' or contact like '9%'  ORDER BY id LIMIT " + limittxt.Text + " OFFSET " + offsettxt.Text + "";


                    int i = 0;
                    string numbers = "";
                    Cursor = Cursors.WaitCursor;
                    dr = obj.Query(command);
                    while (dr.Read())
                    {
                        numbers += dr["contact"].ToString();
                        numbers += "\r\n";
                        i++;
                    }
                    Cursor = Cursors.Arrow;
                    obj.closeConnection();
                    numlisttxt.Text = numbers;
                    arrow.Visible = true;
                }
                
            }catch
            {
                obj.closeConnection();
            }
            }

        List<string> numList = new List<string>();
        private void arrow_Click(object sender, EventArgs e)
        {
            StringBuilder recievers = new StringBuilder(numlisttxt.Text);
            recievers.Replace("\r\n", ",");
            numbertxt.Font = new Font("MS Sans Serif", 9, FontStyle.Regular);
            numbertxt.ForeColor = Color.Black;
            numbertxt.Text = recievers.ToString();


        }

        private void numbertxt_Enter(object sender, EventArgs e)
        {
            if (numbertxt.Text == "Enter numbers seperated with comma")
                numbertxt.Text = "";
            numbertxt.Font = new Font("MS Sans Serif", 9, FontStyle.Regular);

        }

        private void numbertxt_Leave(object sender, EventArgs e)
        {
            if (numbertxt.Text == "")
            {
                numbertxt.Font = new Font("MS Sans Serif", 8, FontStyle.Italic);
                numbertxt.ForeColor = Color.Gray;
                numbertxt.Text = "Enter numbers seperated with comma";
            }
        }

        private void numlisttxt_TextChanged(object sender, EventArgs e)
        {
            arrow.Visible = true;
        }

        bool loop = false;
        private void loopchk_CheckedChanged(object sender, EventArgs e)
        {
            if (loopchk.Checked)
            {
                loop = true;

            }
            else
                loop = false;
        }

        private void sendertxt_Enter(object sender, EventArgs e)
        {
            sendertxt.MaxLength = 6;
        }

        private void limittxt_Enter(object sender, EventArgs e)
        {
            if (limittxt.Text == "Enter LIMIT")
                limittxt.Text = "";
        }

        private void limittxt_Leave(object sender, EventArgs e)
        {
            if (limittxt.Text == "")
            {
                limittxt.ForeColor = Color.Black;
                limittxt.Text = "Enter LIMIT";
            }
        }

        private void offsettxt_Enter(object sender, EventArgs e)
        {
            if (offsettxt.Text == "Enter Offset")
                offsettxt.Text = "";
        }

        private void offsettxt_Leave(object sender, EventArgs e)
        {
            if (offsettxt.Text == "")
            {
                offsettxt.ForeColor = Color.Black;
                offsettxt.Text = "Enter Offset";
            }
        }

        private void stbtn_Click(object sender, EventArgs e)
        {
            smstxt.Text = "";
            if (cname == "")
            {
                
                smstxt.Text = "Dear customer, your order has been dispatched and will reach you in 30-60 mins. Please keep your phone in reach.\nTeam Lalchowk.";

            }else
            {
                smstxt.Text = "Dear "+cname+", your order has been dispatched and will reach you in 30-60 mins. Please keep your phone in reach.\nTeam Lalchowk.";

            }

        }

       
        private void smstxt_TextChanged(object sender, EventArgs e)
        {
            charlbl.Visible = true;
            int max = 320;
            int charac= smstxt.Text.Length;
            charlbl.Text = "(" + (max-charac) + "/320)";
        }

        private void orderbtn_Click(object sender, EventArgs e)
        {
            try
            {
                string command = "";
                if (limittxt.Text == "Enter LIMIT" || limittxt.Text == "" || offsettxt.Text == "Enter Offset" || offsettxt.Text == "")
                {
                    MessageBox.Show("Enter Limit and offset.");

                }
                else
                {
                    command = "select distinct contact from orders where contact like '7%' or contact like '8%' or contact like '9%'  ORDER BY orderid LIMIT " + limittxt.Text + " OFFSET " + offsettxt.Text + "";


                    int i = 0;
                    string numbers = "";
                    Cursor = Cursors.WaitCursor;
                    dr = obj.Query(command);
                    while (dr.Read())
                    {
                        numbers += dr["contact"].ToString();
                        numbers += "\r\n";
                        i++;
                    }
                    Cursor = Cursors.Arrow;
                    obj.closeConnection();
                    numlisttxt.Text = numbers;
                    arrow.Visible = true;
                }
                
            }
            catch
            {
                obj.closeConnection();
            }
        }

        private void reqbtn_Click(object sender, EventArgs e)
        {
            try
            {
                string command = "";
                if (limittxt.Text == "Enter LIMIT" || limittxt.Text == "" || offsettxt.Text == "Enter Offset" || offsettxt.Text == "")
                {
                    MessageBox.Show("Enter Limit and offset.");

                }
                else
                {
                    command = "select distinct contact from bookrequests where contact like '7%' or contact like '8%' or contact like '9%'  ORDER BY id LIMIT " + limittxt.Text + " OFFSET " + offsettxt.Text + "";


                    int i = 0;
                    string numbers = "";
                    Cursor = Cursors.WaitCursor;
                    dr = obj.Query(command);
                    while (dr.Read())
                    {
                        numbers += dr["contact"].ToString();
                        numbers += "\r\n";
                        i++;
                    }
                    Cursor = Cursors.Arrow;
                    obj.closeConnection();
                    numlisttxt.Text = numbers;
                    arrow.Visible = true;
                }

            }
            catch
            {
                obj.closeConnection();
            }
        }

        private void btbtn_Click(object sender, EventArgs e)
        {
            smstxt.Text = "";
            if (cname == "")
            {
                smstxt.Text = "Dear customer, your requested book ' " + bname + " ' is currently not available. We hope to serve you better next time.\r\nTeam Lalchowk";


            }
            else
            {
                smstxt.Text = "Dear " + cname + ", your requested book ' " + bname + " ' is currently not available. We hope to serve you better next time.\r\nTeam Lalchowk";

            }

        }

        private void pshipbtn_Click(object sender, EventArgs e)
        {
            smstxt.Text = "";
            if (cname == "")
            {

                smstxt.Text = "Dear customer, your order has been dispatched via SpeedPost. You can track your order on indiapost.gov.in using tracking number:  \r\nPlease keep your phone in reach.\r\nTeam Lalchowk.";

            }
            else
            {
                smstxt.Text = "Dear " + cname + ", your order has been dispatched via SpeedPost. You can track your order on indiapost.gov.in using tracking number:  \r\nPlease keep your phone in reach.\r\nTeam Lalchowk.";

            }
        }

        private void feedbtn_Click(object sender, EventArgs e)
        {
            smstxt.Text = "";
            
            if (cname == "")
            {
                smstxt.Text = "Dear Customer, hope you had a nice shopping experience with www.lalchowk.in. We would love to read your reviews on our Appstores here: bit.ly/GetLalchowk or our social media handles.";
            }
            else if(cname!="")
            {
                smstxt.Text = "Dear "+cname+ ", hope you had a nice shopping experience with www.lalchowk.in. We would love to read your reviews on our Appstores here: bit.ly/GetLalchowk or our social media handles.";

            }
        }
    }
}
  




