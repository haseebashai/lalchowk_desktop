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


namespace Veiled_Kashmir_Admin_Panel
{
    public partial class addpictures : Form
    {
        DBConnect obj = new DBConnect();
        string filename;
        public addpictures(int productid)
        {
            InitializeComponent();
            proid.Text = productid.ToString();

        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        

        public static void UploadFileToFtp(string url, string filePath)
        {
            try {
                var fileName = Path.GetFileName(filePath);
                var request = (FtpWebRequest)WebRequest.Create(url + fileName);

                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential("terminological-hois", "project12345");
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
                MessageBox.Show("Upload done: " +response.StatusDescription,"Upload Successful.");
                
                response.Close();
               

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                
            }
            }

        private void picbtn_Click(object sender, EventArgs e)
        {
            try {
                UploadFileToFtp("ftp://files.000webhost.com/public_html/lalchowk/pictures/", filename);

               



            }
            catch(WebException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                picbox.BackgroundImage = null;
            }
           
        }

        private void selectbtn_Click(object sender, EventArgs e)
        {
            if (picdialog.ShowDialog() == DialogResult.OK)
            {
                filename = picdialog.FileName;                
                Image myimage = new Bitmap(filename);
                picbox.BackgroundImage = myimage;
                picbox.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

     
    }

        
    }

