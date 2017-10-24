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

namespace Veiled_Kashmir_Admin_Panel
{
    public partial class lalchowkftp : Form
    {
        private dialogcontainer dg = null;
        public lalchowkftp(Form dgcopy)
        {
            dg = dgcopy as dialogcontainer;
            InitializeComponent();
        }

        private void lalchowkftp_Load(object sender, EventArgs e)
        {
            this.loadfiles();
        }

        public void loadfiles()
        {
            var ftp = new FtpUtility();
            ftp.UserName = "Lalchowk";
            ftp.Password = "Lalchowk@123";
            ftp.Path = "ftp://lalchowk.in/httpdocs/lalchowk/";

            this.dataGridView1.DataSource = ftp.ListFiles()
                                                .Select(x => new
                                                {
                                                    Name = x, //Name Column
                                                    Path = ftp.Path + x   //Path Column
                                                }).ToList();
        }


        public static bool DeleteFileOnFtpServer(Uri serverUri, string ftpUsername, string ftpPassword)
        {
            try
            {
                // The serverUri parameter should use the ftp:// scheme.
                // It contains the name of the server file that is to be deleted.
                // Example: ftp://contoso.com/someFile.txt.
                // 

                if (serverUri.Scheme != Uri.UriSchemeFtp)
                {
                    return false;
                }
                // Get the object used to communicate with the server.
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(serverUri);
                request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                request.Method = WebRequestMethods.Ftp.DeleteFile;

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                MessageBox.Show("Image deleted successfully.\nSuccess Response code: " + response.StatusDescription);
                response.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        string delurl;
        private void button1_Click(object sender, EventArgs e)
        {
            DeleteFileOnFtpServer(new Uri(delurl), "Lalchowk", "Lalchowk@123");
            this.loadfiles();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                delurl = row.Cells["path"].Value.ToString();
                MessageBox.Show(delurl);
            }
        }

        public class FtpUtility
        {
            public string UserName { get; set; }
            public string Password { get; set; }
            public string Path { get; set; }
            public List<string> ListFiles()
            {
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
                        return files;
                    }
                }
            }
        }
    }
}
      

