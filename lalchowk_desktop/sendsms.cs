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

        public sendsms()
        {
            InitializeComponent();

        }


        private void singlesms()
        {
            Cursor = Cursors.WaitCursor;
            string authKey = "180732AO0nQdUZo759f09569";             //Your authentication key

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

        private void loopsms()
        {
            Cursor = Cursors.WaitCursor;
            for (int i = 0; i < numList.Count; i++)
            {
                string authKey = "180732AO0nQdUZo759f09569";             //Your authentication key

                string mobileNumber = numList[i];                   //Multiple mobiles numbers separated by comma

                string senderId = sendertxt.Text;                        //Sender ID,While using route4 sender id should be 6 characters long.

                string message = HttpUtility.UrlEncode(smstxt.Text);    //Your message to send, Add URL encoding here.
                MessageBox.Show(numList[i]);

                //Prepare you post parameters
                StringBuilder sbPostData = new StringBuilder();
                sbPostData.AppendFormat("authkey={0}", authKey);
                sbPostData.AppendFormat("&mobiles={0}", mobileNumber);
                sbPostData.AppendFormat("&message={0}", message);
                sbPostData.AppendFormat("&sender={0}", senderId);
                sbPostData.AppendFormat("&route={0}", "4");

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

            }
            numList.Clear();
            Cursor = Cursors.Arrow;

        }


        private void sendsmsbtn_Click(object sender, EventArgs e)
        {


            sentlbl.Visible = false;
            if (sendertxt.Text == "")
            {
                MessageBox.Show("Please enter sender.", "Error!");
            }
            else if (numbertxt.Text == "" || numbertxt.Text == "Enter numbers seperated with comma")
            {
                MessageBox.Show("Please enter recievers.", "Error!");
            }
            else if (smstxt.Text == "")
            {
                MessageBox.Show("Please enter message body.", "Error!");
            }
            else
            {
                if (loop)
                {
                    try
                    {
                        string[] txtNumbers = numbertxt.Text.Split(',');
                        foreach (string nbr in txtNumbers)
                        {
                            string number = nbr;
                            numList.Add(number);
                        }
                        loopsms();
                    }
                    catch (Exception exce)
                    {
                        MessageBox.Show(exce.Message.ToString());
                    }

                }
                else
                {

                    singlesms();
                }
            }

        }

        private void getnumbersbtn_Click(object sender, EventArgs e)
        {
            string command = "";
            if (limittxt.Text=="Enter LIMIT" || limittxt.Text == "")
            {
                command= "select distinct contact from customer where contact like '7%' or contact like '8%' or contact like '9%'  ORDER BY id "+dirbox.Text+" ";
               
            }else
            {
                command= "select distinct id, contact from customer where contact like '7%' or contact like '8%' or contact like '9%'  ORDER BY id " + dirbox.Text + " limit " + limittxt.Text + "";
                
            }
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
    }


}

