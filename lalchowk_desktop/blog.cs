using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Modest_Attires
{
    public partial class blog : Form
    {
        DBConnect obj = new DBConnect();
        MySqlDataAdapter adap;
        DataTable dt;
        MySqlCommandBuilder cmdbl;
        MySqlDataReader dr;
        MySqlConnection con = new MySqlConnection("SERVER=182.50.133.78;DATABASE=lalchowk;USER=lalchowk;PASSWORD=Lalchowk@123uzmah");
        BindingSource bsource;
        PictureBox loading;

        public blog()
        {
            InitializeComponent();
        }


        string fileaddress, filename,fullpath,directory,uploaddir;

        private void readposts()
        {
            try
            {
                adap = new MySqlDataAdapter("select * from posts order by post_ID desc", con);
                dt = new DataTable();
                adap.Fill(dt);
                bsource = new BindingSource();
                bsource.DataSource = dt;
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message.ToString(), "Error!");
            }



        }

        public void loadingnormal()
        {
            formlbl.Text = "Loading";
            formlbl.Visible = true;
            formlbl.BringToFront();

            loading = new PictureBox()
            {
                Image = Properties.Resources.loading,
                Size = new Size(40, 30),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Location = new Point(76, 0)
                
            };
            this.Controls.Add(loading);
            loading.BringToFront();
            loading.Visible = false;
            formlbl.Text = "Lalchowk Blog";
        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            editbtn.Enabled = false;
            loadingnormal();
            newpnl.Visible = false;
            BackgroundWorker editpost = new BackgroundWorker();
            editpost.DoWork += (o, a) => 
            {
                readposts();

            };
            editpost.RunWorkerCompleted += (o, b) => 
            {
                blogdataview.DataSource = bsource;
                editpnl.Visible = true;
                editbtn.Enabled = true;

            };
            editpost.RunWorkerAsync();
        }

        private void updbtn_Click(object sender, EventArgs e)
        {
            try
            {
                cmdbl = new MySqlCommandBuilder(adap);
                adap.Update(dt);
                MessageBox.Show("Post Updated.","Success");
                readposts();
                blogdataview.DataSource = bsource;
                descpnl.Visible = false;
                tagpnl.Visible = false;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "Error!");
            }
        }

        int postid = 0;
        private void blogdataview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.blogdataview.Rows[e.RowIndex];
                postid = int.Parse(row.Cells["post_ID"].Value.ToString());
                desctxt.Text = row.Cells["post_content"].Value.ToString();
                editarttxt.Text = row.Cells["article_content"].Value.ToString();
                postidlbl.Text = postid.ToString();
                descpnl.Visible = true;
                tagpnl.Visible = true;
            }
        }

        private void updpbtn_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder desc = new StringBuilder(desctxt.Text);
                desc.Replace(@"\", @"\\").Replace("'", "\\'");

                string cmd = ("update posts set `post_content`='" + desc + "' where `post_ID`='" + postid + "'");
                obj.nonQuery(cmd);

                MessageBox.Show("Post Content Updated.","Success");
                readposts();
                blogdataview.DataSource = bsource;
                descpnl.Visible = false;
                tagpnl.Visible = false;

            }
            catch(Exception ex) { obj.closeConnection(); MessageBox.Show(ex.Message.ToString()); }
        }

        private void addtagbtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                StringBuilder tag = new StringBuilder(tagtxt.Text);
                tag.Replace(@"\", @"\\").Replace("'", "\\'");

                string cmd = "insert into tag (`title`)values('"+tagtxt.Text+"')";
                obj.nonQuery(cmd);
                obj.closeConnection();
                dr = obj.Query("select TagID from tag order by TagID desc limit 1");
                dr.Read();
                int id = int.Parse(dr[0].ToString());
                obj.closeConnection();

                string cmd1 = "insert into ItemTag (`ItemID`,`TagID`)values('"+postid+"','"+id+"')";
                obj.nonQuery(cmd1);
                obj.closeConnection();

                MessageBox.Show("Tags Added Successfully.", "Success");
                tagtxt.Text = "";
            }
            catch (Exception ex) { obj.closeConnection(); MessageBox.Show(ex.Message.ToString()); }
            Cursor = Cursors.Arrow;
        }

        private void newbtn_Click(object sender, EventArgs e)
        {
            loadingnormal();
            newpnl.Visible = true;
            editpnl.Visible = false;
        }

        private void label10_Click(object sender, EventArgs e)
        {
            posttxt.Text = posttxt.Text + "<em><span style="+"font - family: 'Calibri','sans-serif'; "+"> content here </span></em>";
        }

        private void label11_Click(object sender, EventArgs e)
        {
            posttxt.Text = posttxt.Text + "<strong> </strong>";
        }

        private void label12_Click(object sender, EventArgs e)
        {
            posttxt.Text = posttxt.Text + "<p>&nbsp;</p><ol start="+"2"+"><li><strong><span style="+"font - size: 14.0pt; line - height: 107 %; "+ ">Content here</span></strong></li></ol>";
        }

        private void linklbl_Click(object sender, EventArgs e)
        {
            posttxt.Text=posttxt.Text+ "<a href="+"https://link here"+">title here</a>";
        }

        private void editartbtn_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder article = new StringBuilder(editarttxt.Text);
                article.Replace(@"\", @"\\").Replace("'", "\\'");

                string cmd = ("update posts set `article_content`='" + article + "' where `post_ID`='" + postid + "'");
                obj.nonQuery(cmd);

                MessageBox.Show("Article Content Updated.", "Success");
                readposts();
                blogdataview.DataSource = bsource;
                descpnl.Visible = false;
                tagpnl.Visible = false;

            }
            catch (Exception ex) { obj.closeConnection(); MessageBox.Show(ex.Message.ToString()); }
        }

        private void uppicbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (artpic.BackgroundImage == null)
                {
                    MessageBox.Show("Please select picture first.");
                }
                else
                {
                    Cursor = Cursors.WaitCursor;
                    File.Move(fileaddress, directory + pictxt.Text);
                    uploaddir = directory + pictxt.Text;
                    UploadFileToFtp("ftp://lalchowk.in/httpdocs/blog/images/", uploaddir);
                    MessageBox.Show("Picture Uploaded.", "Success");
                    
                }

            }
            catch(Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            Cursor = Cursors.Arrow;
        }

        private void upblogbtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if (dptxt.Text == "")
                {
                    MessageBox.Show("Please write display picture name first.", "Error");
                }
                else
                {
                    StringBuilder post = new StringBuilder(posttxt.Text);
                    post.Replace(@"\", @"\\").Replace("'", "\\'");
                    StringBuilder arttitle = new StringBuilder(arttitletxt.Text);
                    arttitle.Replace(@"\", @"\\").Replace("'", "\\'");
                    StringBuilder artcontent = new StringBuilder(artcontxt.Text);
                    artcontent.Replace(@"\", @"\\").Replace("'", "\\'");

                    string cmd = "insert into posts (`post_date`,`post_content`,`post_status`,`post_type`,`post_has_article`,`article_title`,`article_content`,`article_picture`,`author`,`author_picture`,`post_views`)" +
                        "values(DATE_ADD(CURRENT_TIMESTAMP, INTERVAL 750 MINUTE),'" + post + "','" + pstatustxt.Text + "','" + ptypetxt.Text + "','1','" + arttitle + "','" + artcontent + "','" + dptxt.Text + "','" + authtxt.Text + "','"+authdptxt.Text+"','"+pviewtxt.Text+"')";
                    obj.nonQuery(cmd);
                    obj.closeConnection();
                    MessageBox.Show("Blog Post Uploaded\n\nPlease add tags in the Edit Posts tab now.", "Success");
                }
            }
            catch(Exception ex) { obj.closeConnection();MessageBox.Show(ex.Message.ToString()); }

            Cursor = Cursors.Arrow;

        }

        private void artpic_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog picdialog = new OpenFileDialog();
                if (picdialog.ShowDialog() == DialogResult.OK)
                {
                    fileaddress = picdialog.FileName;
                    filename = picdialog.SafeFileName;
                    Image myimage = new Bitmap(fileaddress);
                    Bitmap clone = new Bitmap(myimage.Width, myimage.Height);

                    Graphics g = Graphics.FromImage(clone);
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                    g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighSpeed;

                    g.DrawImage(myimage, 0, 0, myimage.Width, myimage.Height);

                    g.Dispose();
                    myimage.Dispose();
                    artpic.BackgroundImage = clone;
                    artpic.BackgroundImageLayout = ImageLayout.Stretch;
                    fullpath = Path.GetFullPath(fileaddress).TrimEnd(Path.DirectorySeparatorChar);
                    directory = Path.GetDirectoryName(fullpath) + "\\";
                    pictxt.Text = Path.GetFileName(fullpath);

                }
            }catch(Exception ex) { MessageBox.Show(ex.Message.ToString()); }
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
               

            }
            catch (Exception ex)
            {

                MessageBox.Show( ex.ToString(), "Error!");
            }
        }
       
    }
}
