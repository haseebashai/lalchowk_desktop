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
        string cmd, filename, fileaddress, fullpath, directory, uploaddir,pid;
        MySqlConnection con = new MySqlConnection("SERVER= 182.50.133.78; DATABASE=lalchowk;USER=lalchowk;PASSWORD=Lalchowk@123uzmah");
        MySqlDataAdapter adap;
        DataTable dt;
        MySqlCommandBuilder cmdbl;


        public addpictures()
        {
            InitializeComponent();
            readpictures();

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

        private void delbtn_Click(object sender, EventArgs e)
        {
            cmd=("delete from pictures where pictureid='"+pid+"'");
            obj.nonQuery(cmd);
            MessageBox.Show("Picture Deleted.");
            readpictures();
        }

        private void picturesdataview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.picturesdataview.Rows[e.RowIndex];
                pid = row.Cells["pictureid"].Value.ToString();

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

        private void addbtn_Click(object sender, EventArgs e)
        {
            if (gidtxt.Text == "")
            {
                MessageBox.Show("Product undefined!, Enter GroupdID.");
            }
            else
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

                        cmd = "insert into pictures (`groupid`, `picture`) " +
                             "values ('" + gidtxt.Text + @"','" + ptxt.Text + "')";
                        obj.nonQuery(cmd);

                        obj.closeConnection();
                        ptxt.Text = "";
                        gidtxt.Text = "";
                        pic.BackgroundImage = null;
                        readpictures();
                    }
                    catch (WebException ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    Cursor = Cursors.Arrow;
                   
                }
            }
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void readpictures()
        {
            con.Open();
            adap = new MySqlDataAdapter("select * from pictures", con);
            dt = new DataTable();
            adap.Fill(dt);
            con.Close();
            BindingSource bsource = new BindingSource();
            bsource.DataSource = dt;
            picturesdataview.DataSource = bsource;
        }

        private void updbtn_Click(object sender, EventArgs e)
        {
            try
            {
                cmdbl = new MySqlCommandBuilder(adap);
                adap.Update(dt);
                MessageBox.Show("Updated.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }

        
    }

