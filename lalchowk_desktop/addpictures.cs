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


namespace Modest_Attires
{
    public partial class addpictures : Form
    {
        DBConnect obj = new DBConnect();
        string cmd, filename, fileaddress, fullpath, directory, uploaddir,pid, url = "http://lalchowk.in/lalchowk/pictures/";
        MySqlConnection con = new MySqlConnection("SERVER= 182.50.133.78; DATABASE=lalchowk;USER=lalchowk;PASSWORD=Lalchowk@123uzmah");
        MySqlDataAdapter adap;
        DataTable dt;
        MySqlCommandBuilder cmdbl;
        BindingSource bsource;
       

        private dialogcontainer dg = null;
        public addpictures(Form dgcopy)
        {
            dg = dgcopy as dialogcontainer;
            InitializeComponent();
            loadingdg();
            bgworker.RunWorkerAsync();

        }

        public void loadingdg()
        {

            dg.lbl.ForeColor = SystemColors.Highlight;
            dg.lbl.Text = "Loading";
            dg.loadingimage.SizeMode = PictureBoxSizeMode.StretchImage;
            dg.loadingimage.Visible = true;
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
            try { 
            DialogResult dr = MessageBox.Show("Do you want to delete the selected picture ?\n"+pid, "Confirm", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {

                cmd = ("delete from pictures where pictureid='" + pid + "'");
                obj.nonQuery(cmd);
                    dp.BackgroundImage = null;
                    MessageBox.Show("Picture Deleted.");
                
                readpictures();
                    picturesdataview.DoubleBuffered(true);
                picturesdataview.DataSource = bsource;
            }
            }
            catch (Exception ex)
            {
                obj.closeConnection();
                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }

        private void gridtxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataView dv = new DataView(dt);
                dv.RowFilter = string.Format("Convert([groupid],System.String) LIKE '%{0}%'", gridtxt.Text);
                picturesdataview.DataSource = dv;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }

        private void gidtxt_Enter(object sender, EventArgs e)
        {

            if (gidtxt.Text == "Enter Group ID")
            {
                gidtxt.Text = "";
                gidtxt.ForeColor = Color.Black;
            }
        }

        private void gidtxt_Leave(object sender, EventArgs e)
        {
            if (gidtxt.Text == "")
            {

                gidtxt.ForeColor = SystemColors.ControlDark;
                gidtxt.Text = "Enter Group ID";
            }
        }

       

        private void bgworker_DoWork(object sender, DoWorkEventArgs e)
        {
            readpictures();
        }

        private void bgworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            refresh.Enabled = true;
            picturesdataview.DoubleBuffered(true);
            picturesdataview.DataSource = bsource;
            ppnl.Visible = true;
            Cursor = Cursors.Arrow;
            dg.loadingimage.Visible = false;
            dg.lbl.ForeColor = SystemColors.Highlight;
            dg.lbl.Text = "Add Pictures";
        }

        int numberOfPoints = 0;
        private void timer_Tick(object sender, EventArgs e)
        {
           
            int maxPoints = 5;             //loading sign on timer

            uploadlbl.Visible = true;
            uploadlbl.Text = "Uploading" + new string('.', numberOfPoints);
            numberOfPoints = (numberOfPoints + 1) % (maxPoints + 1);
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            refresh.Enabled = false;
            bgworker.RunWorkerAsync();
        }


        private void picturesdataview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.picturesdataview.Rows[e.RowIndex];
                pid = row.Cells["pictureid"].Value.ToString();
                string piclocation = row.Cells["picture"].Value.ToString();
                dp.SizeMode = PictureBoxSizeMode.StretchImage;
                dp.ImageLocation = (url + piclocation);

            }
        }

        public static void UploadFileToFtp(string url, string filePath)
        {
            try
            {
                var fileName = Path.GetFileName(filePath);
                var request = (FtpWebRequest)WebRequest.Create(url + fileName);

                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential("lalchowk", "Lalchowk@123uzmah");
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

        private void picworker_DoWork(object sender, DoWorkEventArgs e)
        {try { 
            pic.BackgroundImage.Dispose();
            File.Move(fileaddress, directory + ptxt.Text);
            uploaddir = directory + ptxt.Text;

            UploadFileToFtp("ftp://lalchowk.in/httpdocs/lalchowk/pictures/", uploaddir);

            cmd = "insert into pictures (`groupid`, `picture`) " +
                 "values ('" + gidtxt.Text + @"','" + ptxt.Text + "')";
            obj.nonQuery(cmd);

            obj.closeConnection();
            }
            catch (Exception ex)
            {
                obj.closeConnection();
                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }

        private void picworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            timer.Stop();
            uploadlbl.Visible = false;
            Cursor = Cursors.WaitCursor;
            ptxt.Text = "";
            gidtxt.Text = "";
            pic.BackgroundImage = null;            
            readpictures();
            picturesdataview.DoubleBuffered(true);
            picturesdataview.DataSource = bsource;
            addbtn.Enabled = true;
            Cursor = Cursors.Arrow;
        }
        private void addbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (gidtxt.Text == "")
                {
                    MessageBox.Show("Product undefined!, Enter GroupdID.");
                }
                else
                {
                    if (pic.BackgroundImage == null)
                    {
                        DialogResult dgr = MessageBox.Show("Do you want to update database only ?", "Warning!", MessageBoxButtons.YesNo);
                        if (dgr == DialogResult.Yes)
                        {
                            cmd = "insert into pictures (`groupid`, `picture`) " +
                             "values ('" + gidtxt.Text + @"','" + ptxt.Text + "')";
                            obj.nonQuery(cmd);
                            MessageBox.Show("Image address added in database, please upload the picture seperately now.");
                            readpictures();
                            picturesdataview.DoubleBuffered(true);
                            picturesdataview.DataSource = bsource;
                        }
                    }
                    else
                    {

                        try
                        {
                            timer.Start();
                            addbtn.Enabled = false;
                            picworker.RunWorkerAsync();
                        }
                        catch (WebException ex)
                        {

                            MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
                        }


                    }
                    }
                
            }catch
            {
                obj.closeConnection();
            }
        }
        

        private void readpictures()
        {try { 
            con.Open();
            adap = new MySqlDataAdapter("select * from pictures order by pictureid desc", con);
            dt = new DataTable();
            adap.Fill(dt);
            con.Close();
            bsource = new BindingSource();
            bsource.DataSource = dt;
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
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

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }

    }

        
    }

