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
using System.IO;
using System.Net;

namespace Veiled_Kashmir_Admin_Panel
{
    public partial class addcategories : Form
    {
        PictureBox loading = new PictureBox();
        DBConnect obj = new DBConnect();
        MySqlConnection con = new MySqlConnection("SERVER=182.50.133.78;DATABASE=lalchowk;USER=lalchowk;PASSWORD=Lalchowk@123uzmah");
        MySqlDataReader dr;
        MySqlDataAdapter adap;
        DataTable dt;
        MySqlCommandBuilder cmdbl;
        BindingSource bsource;
        string cmd, filename, fileaddress, fullpath, directory, uploaddir, url = "http://lalchowk.in/lalchowk/pictures/";


        private dialogcontainer dg = null;
        public addcategories(Form dgcopy)
        {
            dg = dgcopy as dialogcontainer;
            InitializeComponent();
            bgworker.RunWorkerAsync();
        }


        public void loadingnormal()
        {
            formlbl.Text = "Loading";
            formlbl.BringToFront();
            loading = new PictureBox()
            {
                Image = Properties.Resources.loading,
                Size = new Size(40, 30),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Location = new Point(72, 0),
            };
            this.Controls.Add(loading);
            loading.BringToFront();
        }

        public void loadingdg()
        {
            dg.lbl.ForeColor = SystemColors.Highlight;
            dg.lbl.Text = "Loading";
            dg.loadingimage.SizeMode = PictureBoxSizeMode.StretchImage;
            dg.loadingimage.Visible = true;
        }

        private void loadingshow()
        {
            loadingaccpic.Visible = true;
            loadinglbl.Visible = true;
        }

        private void bgworker_DoWork(object sender, DoWorkEventArgs e)
        {
            readfirstcat();
            
        }

        private void bgworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (ActiveForm == dg)
            {
                dg.loadingimage.Visible = false;
                dg.lbl.ForeColor = SystemColors.Highlight;
                dg.lbl.Text = "Categories";

            }
            else
            {
                loading.Visible = false;
                formlbl.Visible = false;

            }
            bpnl.Visible = true;
            catdataview.DataSource = bsource;
            
            cpnl.Visible = true;
            panelshow();
        }

        public void readfirstcat()
        {
            try { 
            adap = new MySqlDataAdapter("select * from firstcategory",con);
            dt = new DataTable();
            adap.Fill(dt);
            bsource = new BindingSource();
            bsource.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Something happened, please try again");
            }
        }
        public void readsecondcat()
        {try { 

            adap = new MySqlDataAdapter("select * from secondcategory", con);
            dt = new DataTable();
            adap.Fill(dt);
            bsource = new BindingSource();
            bsource.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Something happened, please try again");
            }
        }
        public void readthirdcat()
        {
            try { 
            adap = new MySqlDataAdapter("select * from thirdcategory", con);
            dt = new DataTable();
            adap.Fill(dt);
            bsource = new BindingSource();
            bsource.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Something happened, please try again");
            }
        }

        private void bgworker2_DoWork(object sender, DoWorkEventArgs e)
        {
            readsecondcat();
        }

        private void bgworker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            catdataview.DataSource = bsource;
            cpnl.Visible = true;
            panelshow();
            
        }

        private void bgworker3_DoWork(object sender, DoWorkEventArgs e)
        {
            readthirdcat();
        }

        private void bgworker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
            catdataview.DataSource = bsource;
            cpnl.Visible = true;
            panelshow();

        }

        private void panelshow()
        {

            bpnl.Enabled = true;
            epnl.Visible = true;
            updbtn.Visible = true;
            catdataview.Visible = true;
            
        }

        private void panelhide()
        {
            bpnl.Enabled = false;
            epnl.Visible = false;
            updbtn.Visible = false;
            catdataview.Visible = false;
            
        }
        private void fcbtn_Click(object sender, EventArgs e)
        {
            panelhide();
            loadingshow();
            
            bgworker.RunWorkerAsync();


           fcpnl.Visible = true;
            scpnl.Visible = false;
            tcpnl.Visible = false;
        }

        private void scbtn_Click(object sender, EventArgs e)
        {
            panelhide();
            loadingshow();
            
            bgworker2.RunWorkerAsync();


            fcpnl.Visible = false;
            scpnl.Visible = true;
            tcpnl.Visible = false;
        }

        private void faddpicbtn_Click(object sender, EventArgs e)
        {
            try { 
            Cursor = Cursors.WaitCursor;
            fpic.BackgroundImage.Dispose();
            File.Move(fileaddress, directory + fpictxt.Text);
            uploaddir = directory + fpictxt.Text;

            UploadFileToFtp("ftp://lalchowk.in/httpdocs/lalchowk/pictures/", uploaddir);
            Cursor = Cursors.Arrow;
        }
            catch (Exception)
            {
                MessageBox.Show("Something happened, please try again.");
            }
}

        private void spicbtn_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                spic.BackgroundImage.Dispose();
                File.Move(fileaddress, directory + spictxt.Text);
                uploaddir = directory + spictxt.Text;

                UploadFileToFtp("ftp://lalchowk.in/httpdocs/lalchowk/pictures/", uploaddir);
                Cursor = Cursors.Arrow;
            }
            catch (Exception)
            {
                MessageBox.Show("Something happened, please try again.");
            }
        }

        private void spic_Click(object sender, EventArgs e)
        {
            if (picdialog.ShowDialog() == DialogResult.OK)
            {
                fileaddress = picdialog.FileName;
                filename = picdialog.SafeFileName;
                Image myimage = new Bitmap(fileaddress);
                spic.BackgroundImage = myimage;
                spic.BackgroundImageLayout = ImageLayout.Stretch;
                fullpath = Path.GetFullPath(fileaddress).TrimEnd(Path.DirectorySeparatorChar);
                directory = Path.GetDirectoryName(fullpath) + "\\";
                spictxt.Text = Path.GetFileName(fullpath);

            }
        }

        private void syes_CheckedChanged(object sender, EventArgs e)
        {
            if (syes.Checked)
                sno.Checked = false;
        }

        private void sno_CheckedChanged(object sender, EventArgs e)
        {
            if (sno.Checked)
                syes.Checked = false;   
        }

        private void addscbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (syes.Checked)
                {
                    cmd = ("insert into secondcategory(`cid`, `categoryid`, `categoryname`,`picture`,`firstcategoryid`,`final`) values ('" + sidtxt.Text + "','" + scidtxt.Text + "','" + scnametxt.Text + "','" + spictxt.Text + "','" + fscidtxt.Text + ",'1'");
                    obj.nonQuery(cmd);
                    obj.closeConnection();
                }
                else
                {
                    cmd = ("insert into secondcategory(`cid`, `categoryid`, `categoryname`,`picture`,`firstcategoryid`,`final`) values ('" + sidtxt.Text + "','" + scidtxt.Text + "','" + scnametxt.Text + "','" + spictxt.Text + "','" + fscidtxt.Text + ",'0'");
                    obj.nonQuery(cmd);
                    obj.closeConnection();
                }
                MessageBox.Show("Category added.");

                sidtxt.Text = "";
                scidtxt.Text = "";
                scnametxt.Text = "";
                fscidtxt.Text = "";
                spictxt.Text = "";
                syes.Checked = false;
                sno.Checked = false;

                readsecondcat();
                catdataview.DataSource = bsource;
            }
            catch (Exception)
            {
                obj.closeConnection();
                MessageBox.Show("Something happened, please try again.");
            }
        }

        private void tpic_Click(object sender, EventArgs e)
        {
            if (picdialog.ShowDialog() == DialogResult.OK)
            {
                fileaddress = picdialog.FileName;
                filename = picdialog.SafeFileName;
                Image myimage = new Bitmap(fileaddress);
                tpic.BackgroundImage = myimage;
                tpic.BackgroundImageLayout = ImageLayout.Stretch;
                fullpath = Path.GetFullPath(fileaddress).TrimEnd(Path.DirectorySeparatorChar);
                directory = Path.GetDirectoryName(fullpath) + "\\";
                tpictxt.Text = Path.GetFileName(fullpath);

            }
        }

        private void tpicaddbtn_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                spic.BackgroundImage.Dispose();
                File.Move(fileaddress, directory + tpictxt.Text);
                uploaddir = directory + tpictxt.Text;

                UploadFileToFtp("ftp://lalchowk.in/httpdocs/lalchowk/pictures/", uploaddir);
                Cursor = Cursors.Arrow;
            }
            catch (Exception)
            {
                MessageBox.Show("Something happened, please try again.");
            }
        }

        private void tcaddbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (tyes.Checked)
                {
                    cmd = ("insert into thirdcategory(`categoryid`, `categoryname`,`picture`,`secondcategoryid`,`final`) values ('" + tidtxt.Text + "','" + tcnametxt.Text + "','" + tpictxt.Text + "','" + stcidtxt.Text + "','1'");
                    obj.nonQuery(cmd);
                    obj.closeConnection();
                    MessageBox.Show("Category added.");
                    tidtxt.Text = "";
                    tcnametxt.Text = "";
                    tpictxt.Text = "";
                    stcidtxt.Text = "";

                    readthirdcat();
                    catdataview.DataSource = bsource;
                }
                else
                {
                    obj.closeConnection();
                    MessageBox.Show("Please check final option.");
                }
                

               
            }
            catch (Exception)
            {
                obj.closeConnection();
                MessageBox.Show("Something happened, try again.");
            }
        }

        private void updbtn_Click(object sender, EventArgs e)
        {
            try
            {
                cmdbl = new MySqlCommandBuilder(adap);
                adap.Update(dt);
                MessageBox.Show("Entry Updated.");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Something happened, please try again.\n\n\n"+ex.ToString());
            }
        }

      

        private void tcbtn_Click(object sender, EventArgs e)
        {
            panelhide();
            loadingshow();
            
            bgworker3.RunWorkerAsync();


            fcpnl.Visible = false;
            scpnl.Visible = false;
            tcpnl.Visible = true;
        }

        private void fyes_CheckedChanged(object sender, EventArgs e)
        {
            if (fyes.Checked)
                fno.Checked = false;
        }

        private void fno_CheckedChanged(object sender, EventArgs e)
        {
            if (fno.Checked)
                fyes.Checked = false;
        }

        private void faddbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (fyes.Checked)
                {
                    cmd = ("insert into firstcategory(`cid`, `categoryid`, `categoryname`,`picture`,`final`) values ('" + fidtxt.Text + "','" + fcidtxt.Text + "','" + fnametxt.Text + "','"+fpictxt.Text+"','1'");
                    obj.nonQuery(cmd);
                    obj.closeConnection();
                }
                else
                {
                    cmd = ("insert into firstcategory(`cid`, `categoryid`, `categoryname`,`picture`,`final`) values ('" + fidtxt.Text + "','" + fcidtxt.Text + "','" + fnametxt.Text + "','" + fpictxt.Text + "','0'");
                    obj.nonQuery(cmd);
                    obj.closeConnection();
                }
                MessageBox.Show("Category added.");
                
                fidtxt.Text = "";
                fcidtxt.Text = "";
                fnametxt.Text = "";
                fpictxt.Text = "";
                fyes.Checked = false;
                fno.Checked = false;

                readfirstcat();
                catdataview.DataSource = bsource;
            }
            catch (Exception)
            {
                obj.closeConnection();
                MessageBox.Show("Something happened, please try again.");
            }
        }

        private void fpic_Click(object sender, EventArgs e)
        {
            if (picdialog.ShowDialog() == DialogResult.OK)
            {
                fileaddress = picdialog.FileName;
                filename = picdialog.SafeFileName;
                Image myimage = new Bitmap(fileaddress);
                fpic.BackgroundImage = myimage;
                fpic.BackgroundImageLayout = ImageLayout.Stretch;
                fullpath = Path.GetFullPath(fileaddress).TrimEnd(Path.DirectorySeparatorChar);
                directory = Path.GetDirectoryName(fullpath) + "\\";
                fpictxt.Text = Path.GetFileName(fullpath);

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
                MessageBox.Show("Image uploaded successfully.\nSuccess Response code: " + response.StatusDescription);

                response.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }
    }
}
