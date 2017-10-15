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

namespace Veiled_Kashmir_Admin_Panel
{
    public partial class notification : Form
    {
        DBConnect obj = new DBConnect();
        MySqlDataReader dr;
        string encmail, filename, fileaddress, fullpath, directory, uploaddir,cmd, url = "http://lalchowk.in/lalchowk/pictures/";
        PictureBox loading = new PictureBox();

        public notification(string encemail,string realemail)
        {
         

            InitializeComponent();
            bgworker.RunWorkerAsync();
            
            emailtxt.Text = realemail;
            encmail = encemail;
            
        }
        
        private void readorderid()
        {
            dr = obj.Query("Select orderid from orders where email='" + encmail + "'");
            DataTable dt = new DataTable();
            dt.Columns.Add("orderid", typeof(String));
            dt.Load(dr);
            obj.closeConnection();
           
            orderidbox.DataSource = dt;
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
                    UploadFileToFtp("ftp://182.50.151.83/httpdocs/lalchowk/pictures/", uploaddir);
                    obj.closeConnection();                 
                }
                catch (WebException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                Cursor = Cursors.Arrow;

            }
        
        }

        private void sendbtn_Click_1(object sender, EventArgs e)
        {
            try {
                
                if (chkbox.Checked)
                {
                    cmd = ("insert into notifications (email,title,subtitle,picture) values ('" + encmail + "','" + titletxt.Text + "','" + subtxt.Text + "','"+ptxt.Text+"')");
                    obj.nonQuery(cmd);
                }
                else
                {
                    cmd = ("insert into notifications (email,title,subtitle,orderid,picture) values ('" + encmail + "','" + titletxt.Text + "','" + subtxt.Text + "','" + orderidbox.Text + "','" + ptxt.Text + "')");
                    obj.nonQuery(cmd);
                }
                MessageBox.Show("Notification sent sucessfully.");
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            obj.closeConnection();
        }

        private void close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bgworker_DoWork(object sender, DoWorkEventArgs e)
        {
            readorderid();
        }
        private void bgworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            loading.Visible = false;
            orderidbox.DisplayMember = "orderid";
            
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
                MessageBox.Show(ex.ToString());

            }
        }
    }
}
