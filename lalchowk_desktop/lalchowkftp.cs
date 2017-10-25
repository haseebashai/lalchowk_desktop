﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using MySql.Data.MySqlClient;

namespace Veiled_Kashmir_Admin_Panel
{

    
    public partial class lalchowkftp : Form
    {
       
        PictureBox loading = new PictureBox();

        private dialogcontainer dg = null;
        public lalchowkftp(Form dgcopy)
        {
            dg = dgcopy as dialogcontainer;
            InitializeComponent();

          
        }



        private void loadfiles()
        {
            Cursor = Cursors.WaitCursor;
            var ftp = new FtpUtility();
            ftp.UserName = "Lalchowk";
            ftp.Password = "Lalchowk@123";
            ftp.Path = ftppath;
            try
            {
                this.ftpdataview.DataSource = ftp.ListFiles()
                                                      .Select(x => new
                                                      {

                                                          Path = ftp.Path + x,   //Path Column 
                                                      Name = x             //Name Column
                                                  }).ToList();
            }catch(Exception e)
            {

            }
           
            fpnl.Visible = true;
            Cursor = Cursors.Arrow;
        }


        private void dirbtn_Click(object sender, EventArgs e)
        {
            
                ftppath = "ftp://lalchowk.in/httpdocs/lalchowk/" + dirtxt.Text + "/";
            filetxt.Text = "";
            loadfiles();
           
        }

        string ftppath= "ftp://lalchowk.in/httpdocs/lalchowk/";
      

        public static bool DeleteFileOnFtpServer(Uri serverUri, string ftpUsername, string ftpPassword)
        {
            try
            {
               
                if (serverUri.Scheme != Uri.UriSchemeFtp)
                {
                    return false;
                }
                // Get the object used to communicate with the server.
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(serverUri);
                request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                request.Method = WebRequestMethods.Ftp.DeleteFile;

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                MessageBox.Show("File deleted successfully.\nSuccess Response code: " + response.StatusDescription);
                response.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        string pathurl;
        private void ftpdelbtn_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = pathurl.Split('/').Last();
                DialogResult dgr = MessageBox.Show("Delete following file ?\n\n" + filename, "Confirm!", MessageBoxButtons.YesNo);
                if (dgr == DialogResult.Yes)
                {
                    DeleteFileOnFtpServer(new Uri(pathurl), "Lalchowk", "Lalchowk@123");

                    loadfiles();
                }

            }catch(Exception ex)
            {
                MessageBox.Show("Please select a file first.");
            }
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.ftpdataview.Rows[e.RowIndex];
                pathurl = row.Cells["path"].Value.ToString();
                filetxt.Text = pathurl.Split('/').Last();
            }
        }


        string downloadpath;
        private void ftpdldbtn_Click(object sender, EventArgs e)
        {
            
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {

                    downloadpath = folderDialog.SelectedPath;
                }
            }
         
            // Run Download on background thread
            Task.Run(() => Download());
           
        }

        private void Download()
        {
           
            try
            {
                string url = pathurl;
                NetworkCredential credentials = new NetworkCredential("Lalchowk", "Lalchowk@123");

                // Query size of the file to be downloaded
                FtpWebRequest sizeRequest = (FtpWebRequest)WebRequest.Create(url);
                sizeRequest.Credentials = credentials;
                sizeRequest.Method = WebRequestMethods.Ftp.GetFileSize;
                long size = sizeRequest.GetResponse().ContentLength/8;

                progressBar1.Invoke(
                    (MethodInvoker)delegate { progressBar1.Maximum = (int)size; });

                // Download the file
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
                request.Credentials = credentials;
                request.Method = WebRequestMethods.Ftp.DownloadFile;
               //      Uri uri = new Uri(url);
                 //  string filename = uri.Segments.Last();

                string filename=url.Substring(url.LastIndexOf("/") + 1);
                using (Stream ftpStream = request.GetResponse().GetResponseStream())
                using (Stream fileStream = File.Create(@downloadpath+filename))
                {
                    byte[] buffer = new byte[10240];
                    int read;
                    int total = 0;
                    while ((read = ftpStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fileStream.Write(buffer, 0, read);
                        total += read;
                        
                        progressBar1.Invoke(
                            (MethodInvoker)delegate { progressBar1.Visible = true; progressBar1.Value = total/8;progresspc.Visible = true; progresspc.Text = progressBar1.Value.ToString()+" Kilobytes downloaded"; });
                    }
                }
                MessageBox.Show("File downloaded.");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }








        public class FtpUtility
        {
            
            public string UserName { get; set; }
            public string Password { get; set; }
            public string Path { get; set; }

            public List<string> ListFiles()
            {
                try {
                    var request = (FtpWebRequest)WebRequest.Create(Path);
                    request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                    request.Credentials = new NetworkCredential(UserName, Password);
                    List<string> files = new List<string>();

                    using (var response = (FtpWebResponse)request.GetResponse())

                    {
                        using (var responseStream = response.GetResponseStream())
                        {
                            var reader = new StreamReader(responseStream);
                            while (!reader.EndOfStream)
                            {
                                var line = reader.ReadLine();
                                if (string.IsNullOrWhiteSpace(line) == false)
                                {

                                    var fileName = line.Split(new[] { ' ', '\t' }).Last();
                                    if (!fileName.StartsWith("."))
                                        files.Add(fileName);
                                }

                            }
                        }
                    }

                    return files;


                }catch(Exception e)
                {
                    
                    MessageBox.Show("Please enter valid directory address.");
                    
                    return null;
                }
               }
            }
                
        

        private void ftpupbtn_Click(object sender, EventArgs e)
        {
            if (uptxt.Text == "")
            {
                MessageBox.Show("Select File first!");
                
            }
            else
            {
                
                Cursor = Cursors.WaitCursor;
                try
                {

                    File.Move(fileaddress, directory + uptxt.Text);
                    uploaddir = directory + uptxt.Text;

                    string responsefromftp = UploadFileToFtp(ftppath, uploaddir);

                    
                    MessageBox.Show("Picture Uploaded.\n\n\n" + responsefromftp.ToString());
                    progressBar1.Value = 0;
                    progressBar1.Visible = false;
                    loadfiles();


                }
                catch (WebException ex)
                {
                    MessageBox.Show(ex.ToString());
                    
                }
                Cursor = Cursors.Arrow;
                uptxt.Text = "Select File";
            }
        }

        public string UploadFileToFtp(string url, string filePath)
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

                        
                        progressBar1.Invoke(
                       (MethodInvoker)delegate { progressBar1.Visible = true; progressBar1.Value = 100; progresspc.Text = "File Uplaoded"; });
                    }
                }


                     var response = (FtpWebResponse)request.GetResponse();
                //    MessageBox.Show("Image uploaded successfully.\nSuccess Response code: " + response.StatusDescription);

                      response.Close();
                return response.StatusDescription;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }

        string fileaddress, filename, fullpath, directory,uploaddir;

        private void lalchowkftp_Load(object sender, EventArgs e)
        {
            loadfiles();
        }

        private void uptxt_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog fd = new OpenFileDialog();
           
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    fileaddress = fd.FileName;
                    filename = fd.SafeFileName;
                    fullpath = Path.GetFullPath(fileaddress).TrimEnd(Path.DirectorySeparatorChar);
                    directory = Path.GetDirectoryName(fullpath) + "\\";
                    uptxt.Text = Path.GetFileName(fullpath);
                }
               
            
        }
    }
}
      

