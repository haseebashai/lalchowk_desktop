using System;
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
        BackgroundWorker bw;
        BindingSource bsource;


        private dialogcontainer dg = null;
        public lalchowkftp(Form dgcopy)
        {
            dg = dgcopy as dialogcontainer;
            InitializeComponent();
            
            bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            bw.RunWorkerAsync();
            fetchpnl.Visible = true;
        }


    void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {

            fpnl.Enabled = true;
            fetchpnl.Visible = false;
            ftpdataview.DataSource = bsource;
            

        }




    void bw_DoWork(object sender, DoWorkEventArgs e)
    {

            loadfiles();

    }


    private void loadfiles()
        {
            
            var ftp = new FtpUtility();
            ftp.UserName = "Lalchowk";
            ftp.Password = "Lalchowk@123";
            ftp.Path = ftppath;
            try
            {
                bsource = new BindingSource();             
                bsource.DataSource = ftp.ListFiles().Select(x => new { Path = ftp.Path + x, Name = x }).ToList();

            } catch(Exception e)
            {
                var message = e.ToString();
                string[] split = message.Split(new string[] { " at " }, StringSplitOptions.None);

                MessageBox.Show("Could not load FTP, please try again.\n\n" + split[0], "Error!");
            }      
        }
        private void searchtxt_TextChanged(object sender, EventArgs e)
        {
            ftpdataview.DataSource = bsource;
            DataTable dt = new DataTable();
            foreach (DataGridViewColumn col in ftpdataview.Columns)
            {
                dt.Columns.Add(col.HeaderText);
            }

            foreach (DataGridViewRow row in ftpdataview.Rows)
            {
                DataRow dRow = dt.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dRow[cell.ColumnIndex] = cell.Value;
                }
                dt.Rows.Add(dRow);
            }

            DataView dv = new DataView(dt);
            dv.RowFilter = string.Format("name LIKE '%{0}%'", searchtxt.Text);
            ftpdataview.DataSource = dv;
        }

        private void dirbtn_Click(object sender, EventArgs e)
        {
            ftpdataview.DataSource = null;
            fetchpnl.Visible = true;
            fpnl.Enabled = false;
                ftppath = "ftp://lalchowk.in/httpdocs/lalchowk/" + dirtxt.Text + "/";
                filetxt.Text = "";
                bw.RunWorkerAsync();
           
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
                var message = ex.ToString();
                string[] split = message.Split(new string[] { " at " }, StringSplitOptions.None);
                MessageBox.Show("Something happened, please try again.\n\n" + split[0], "Error!");
            
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

                    bw.RunWorkerAsync();
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
                string ftpurl = pathurl.Replace("ftp://", "http://").Replace("httpdocs/", "");
               
                ftppic.ImageLocation = ftpurl;
            }
        }


        string downloadpath;
        private void ftpdldbtn_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
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
                long size = sizeRequest.GetResponse().ContentLength/1000;

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
                            (MethodInvoker)delegate { progressBar1.Visible = true; progressBar1.Value = total/1000;progresspc.Visible = true; progresspc.Text = progressBar1.Value.ToString()+" KB downloaded"; });
                    }
                }
                MessageBox.Show("File downloaded.");
            }
            catch (Exception e)
            {
            
                var message = e.ToString();
                string[] split = message.Split(new string[] { " at " }, StringSplitOptions.None);
                MessageBox.Show(split[0],"Error");
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


                }catch(Exception ex)
                {
                    var message = ex.ToString();
                    string[] split = message.Split(new string[] { " at " }, StringSplitOptions.None);
                    MessageBox.Show("Something happened, please try again.\n\n"+split[0],"Error!");
                    
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
                    bw.RunWorkerAsync();


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
                var message = ex.ToString();
                string[] split = message.Split(new string[] { " at " }, StringSplitOptions.None);
                MessageBox.Show("Something happened, please try again.\n\n" + split[0], "Error!");
                return null;
            }
        }

        string fileaddress, filename, fullpath, directory,uploaddir;

      

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
      

