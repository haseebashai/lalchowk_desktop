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
using System.Net;
using System.IO;
using System.Security.Cryptography;

namespace Veiled_Kashmir_Admin_Panel
{
    public partial class notification : Form
    {
        DBConnect obj = new DBConnect();
        MySqlDataReader dr;
        string encmail, filename, fileaddress, fullpath, directory, uploaddir,cmd, url = "http://lalchowk.in/lalchowk/pictures/";
        PictureBox loading = new PictureBox();

        public notification(string encemail,string realemail,string orderid)
        {
         

            InitializeComponent();

            bgworker.RunWorkerAsync();
                orderidbox.Text = orderid;
         
            emailtxt.Text = realemail;
            
                encmail = encemail;
           
            
        }

        public static string md5hash(string input)
        {

            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input + "Zohan123"));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

        private void readorderid()
        {try { 
            dr = obj.Query("Select orderid from orders where email='" + encmail + "'");
            DataTable dt = new DataTable();
            dt.Columns.Add("orderid", typeof(String));
            dt.Load(dr);
            obj.closeConnection();
           
            orderidbox.DataSource = dt;
        }
            catch (Exception ex)
            {
                var message = ex.ToString();
                string[] split = message.Split(new string[] { " at " }, StringSplitOptions.None);
                MessageBox.Show("Something happened, please try again.\n\n" + split[0], "Error!");
            }
        }

        private void picbtn_Click(object sender, EventArgs e)
        {
            if (pic.BackgroundImage == null)
            {
                MessageBox.Show("Select Image first.");
            }
            else
            {
                Cursor = Cursors.WaitCursor;
                try
                {
                    pic.BackgroundImage.Dispose();
                    File.Move(fileaddress, directory + ptxt.Text);
                    uploaddir = directory + ptxt.Text;
                    UploadFileToFtp("ftp://lalchowk.in/httpdocs/lalchowk/pictures/", uploaddir);
                    obj.closeConnection();                 
                }
                catch (Exception ex)
                {
                    Cursor = Cursors.Arrow;
                    MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
                }
                Cursor = Cursors.Arrow;

            }
        
        }

        private void sendbtn_Click_1(object sender, EventArgs e)
        {
            try {
            //    string email = md5hash(emailtxt.Text);
                if (chkbox.Checked)
                {
                    cmd = ("insert into notifications (email,title,subtitle,picture,currtime) values ('" + encmail + "','" + titletxt.Text + "','" + subtxt.Text + "','"+ptxt.Text+ "',DATE_ADD(CURRENT_TIMESTAMP, INTERVAL 750 MINUTE))");
                    obj.nonQuery(cmd);
                }
                else
                {
                    cmd = ("insert into notifications (email,title,subtitle,orderid,picture,currtime) values ('" + encmail + "','" + titletxt.Text + "','" + subtxt.Text + "','" + orderidbox.Text + "','" + ptxt.Text + "',DATE_ADD(CURRENT_TIMESTAMP, INTERVAL 750 MINUTE))");
                    obj.nonQuery(cmd);
                }
                MessageBox.Show("Notification sent sucessfully.");
                
            }
            catch (Exception ex)
            {

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
            obj.closeConnection();
        }


        private void bgworker_DoWork(object sender, DoWorkEventArgs e)
        {
           // readorderid();
        }
        private void bgworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            loading.Visible = false;
          //  orderidbox.DisplayMember = "orderid";
            
            formlbl.Text = "Send Notification";
            npnl.Visible = true;
        }

        public void loadingnormal()
        {
            formlbl.Text = "Loading";
            
            loading = new PictureBox()
            {
                Image = Properties.Resources.loading,
                Size = new Size(40, 30),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Location = new Point(85, 5),
            };
            this.Controls.Add(loading);
        }

        private void pic_Click(object sender, EventArgs e)
        {
            if (picdialog.ShowDialog() == DialogResult.OK)
            {
                fileaddress = picdialog.FileName;
                filename = picdialog.SafeFileName;
                Image myimage = new Bitmap(fileaddress);
                pic.BackgroundImage = myimage;
                pic.BackgroundImageLayout = ImageLayout.Stretch;
                fullpath = Path.GetFullPath(fileaddress).TrimEnd(Path.DirectorySeparatorChar);
                directory = Path.GetDirectoryName(fullpath) + "\\";
                ptxt.Text = Path.GetFileName(fullpath);

            }
        }
        public static void UploadFileToFtp(string url, string filePath)
        {
            try
            {
                var fileName = Path.GetFileName(filePath);
                var request = (FtpWebRequest)WebRequest.Create(url + fileName);

                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential("lalchowk", "Lalchowk@123");
                request.UsePassive = true;
                request.UseBinary = true;
                request.KeepAlive = true;

                using (var fileStream = File.OpenRead(filePath))
                {
                    using (var requestStream = request.GetRequestStream())
                    {
                        fileStream.CopyTo(requestStream);
                        requestStream.Close();
                    }
                }

                var response = (FtpWebResponse)request.GetResponse();
                MessageBox.Show("Upload done: " + response.StatusDescription, "Upload Successful.");

                response.Close();


            }
            catch (Exception ex)
            {

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }
    }
}
