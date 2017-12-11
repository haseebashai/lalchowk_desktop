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
    public partial class apphomepage : Form
    {

        DBConnect obj = new DBConnect();
        string cmd;
        MySqlDataAdapter adap, adap1;
        DataTable dt, dt1, dt5;
        MySqlCommandBuilder cmdbl, cmdbl1;
        MySqlDataReader dr;
        string oid,oname;
        MySqlConnection con = new MySqlConnection("SERVER=182.50.133.78;DATABASE=lalchowk;USER=lalchowk;PASSWORD=Lalchowk@123uzmah");
        string url = "http://lalchowk.in/lalchowk/pictures/";
        BindingSource bsource, bsource2, bsource3;
        PictureBox loading = new PictureBox();

        private dialogcontainer dg = null;
        public apphomepage(Form dgcopy)
        {
            dg = dgcopy as dialogcontainer;
            InitializeComponent();
            bgworker.RunWorkerAsync();
        }

        private void updoffers_Click(object sender, EventArgs e)
        {
            try
            {
                cmdbl = new MySqlCommandBuilder(adap1);
                adap1.Update(dt5);
                MessageBox.Show("Offers Updated.");
                readoffers();
                offersdataview.DataSource = bsource;

            }
            catch (Exception ex)
            {

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }

        private void readoffers()
        {try { 
            con.Open();
            adap1 = new MySqlDataAdapter("SELECT * FROM offers", con);
            dt5 = new DataTable();
            adap1.Fill(dt5);
            con.Close();
            bsource = new BindingSource();
            bsource.DataSource = dt5;
        }
            catch (Exception ex)
            {

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }


        }
        public void loadingnormal()
        {
            formlbl.Text = "Loading";

            loading = new PictureBox()
            {
                Image = Properties.Resources.loading,
                Size = new Size(40, 30),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Location = new Point(72, 0),
            };
            this.Controls.Add(loading);
        }
        public void loadingdg()
        {
            formlbl.Visible = false;
            dg.lbl.ForeColor = SystemColors.Highlight;
            dg.lbl.Text = "Loading";
            dg.loadingimage.SizeMode = PictureBoxSizeMode.StretchImage;
            dg.loadingimage.Visible = true;
        }
        private void bgworker_DoWork(object sender, DoWorkEventArgs e)
        {
            readoffers();
            readhomepage2();
            readitems();
        }

        private void readitems()
        {
            con.Open();
            adap = new MySqlDataAdapter("SELECT * FROM homepage2 where homeid >6", con);
            dt1 = new DataTable();
            adap.Fill(dt1);
            con.Close();
            bsource3 = new BindingSource();
            bsource3.DataSource = dt1;
        }

        private void bgworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {


            if (dg!=null)
            {
                dg.loadingimage.Visible = false;
                dg.lbl.ForeColor = SystemColors.Highlight;
                dg.lbl.Text = "";

            }
            else
            {
                loading.Visible = false;
                formlbl.Text = "Change Offers";
                formlbl.BringToFront();
            }
            offersdataview.DataSource = bsource;
            productsdataview.DataSource = bsource2;
            itemsdataview.DataSource = bsource3;
            hpnl.Visible = true;

            lefttxt.Text = lefttxtvar;
            leftlink.Text = leftlinkvar;
            righttxt.Text = righttxtvar;
            rightlink.Text = rightlinkvar;

            p1title.Text = p1titlevar;
            p1sub.Text = p1subvar;
            p1pic.Text = p1picvar;
            p1link.Text = p1linkvar;

            p2title.Text = p2titlevar;
            p2sub.Text = p2subvar;
            p2pic.Text = p2picvar;
            p2link.Text = p2linkvar;

            p3title.Text = p3titlevar;
            p3sub.Text = p3subvar;
            p3pic.Text = p3picvar;
            p3link.Text = p3linkvar;

            p4title.Text = p4titlevar;
            p4sub.Text = p4subvar;
            p4pic.Text = p4picvar;
            p4link.Text = p4linkvar;

           
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


            }
            catch (Exception ex)
            {

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }

        string righttxtvar, rightlinkvar, lefttxtvar, leftlinkvar, p1titlevar, p1subvar, p1picvar, p1linkvar, p2titlevar, p2subvar, p2picvar, p2linkvar,
                p3titlevar, p3subvar, p3picvar, p3linkvar, p4titlevar, p4subvar, p4picvar, p4linkvar,fileaddress,filename,fullpath,
                directory,uploaddir;

        bool rightpicture = false, leftpicture = false;
        private void rightpic_Click(object sender, EventArgs e)
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
                rightpic.BackgroundImage = clone;
                rightpic.BackgroundImageLayout = ImageLayout.Stretch;
                fullpath = Path.GetFullPath(fileaddress).TrimEnd(Path.DirectorySeparatorChar);
                directory = Path.GetDirectoryName(fullpath) + "\\";
                righttxt.Text = Path.GetFileName(fullpath);
                rightpicture = true;

            }
        }

        private void leftpic_Click(object sender, EventArgs e)
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
                leftpic.BackgroundImage = clone;
                leftpic.BackgroundImageLayout = ImageLayout.Stretch;
                fullpath = Path.GetFullPath(fileaddress).TrimEnd(Path.DirectorySeparatorChar);
                directory = Path.GetDirectoryName(fullpath) + "\\";
                lefttxt.Text = Path.GetFileName(fullpath);
                leftpicture = true;
            }
            
        }
        private void uploadrightpic()
        {
           
            File.Move(fileaddress, directory + righttxt.Text);
            uploaddir = directory + righttxt.Text;
          
            UploadFileToFtp("ftp://lalchowk.in/httpdocs/lalchowk/pictures/", uploaddir);

            cmd = "update homepage2 set picture='" + righttxt.Text + "',link='" + rightlink.Text + "' where homeid='2'";
            obj.nonQuery(cmd);
            obj.closeConnection();
           
        }

        private void uploadleftpic()
        {
            
            File.Move(fileaddress, directory + lefttxt.Text);
            uploaddir = directory + lefttxt.Text;
            UploadFileToFtp("ftp://lalchowk.in/httpdocs/lalchowk/pictures/", uploaddir);

            cmd = "update homepage2 set picture='" + lefttxt.Text + "',link='" + leftlink.Text + "' where homeid='1'";
            obj.nonQuery(cmd);
            obj.closeConnection();
          
        }


        private void upddpbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (rightpicture && leftpicture)
                {
                    try
                    {
                        Cursor = Cursors.WaitCursor;
                       
                        uploadrightpic();
                        uploadleftpic();
                        Cursor = Cursors.Arrow;
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
                    }
                }
                else if (rightpicture==false || leftpicture==false)
                {
                    MessageBox.Show("Please select both pictures.");
                }
                else
                {
                    cmd = "update homepage2 set picture='" + lefttxt.Text + "',link='" + leftlink.Text + "' where homeid='1'";
                    obj.nonQuery(cmd);

                    cmd = "update homepage2 set picture='" + righttxt.Text + "',link='" + rightlink.Text + "' where homeid='2'";
                    obj.nonQuery(cmd);

                    MessageBox.Show("Display pictures updated.");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }

        private void randlist_Click(object sender, EventArgs e)
        {
            try { 
            Cursor = Cursors.WaitCursor;
            dr = obj.Query("SELECT productname,productid FROM lalchowk.products WHERE stock>0 ORDER BY RAND() LIMIT 16 ");
           
            List<string> productid = new List<string>();
                List<string> productname = new List<string>();

            int i = 0;
            int homeid = 35;
            while (dr.Read())
            {
                
                productid.Add(dr["productid"].ToString());
                    productname.Add(dr["productname"].ToString());
                i++;
                

            }
                obj.closeConnection();
                try
                {
                    for (i = 0; i < 16; i++)
                     {
                   
                        cmd = "update homepage2 set link='" + productid[i] + "',title='"+productname[i]+"' where homeid='" + homeid + "'";
                        obj.nonQuery(cmd);
                        obj.closeConnection();

                        homeid++;
                    }
                    readitems();
                    itemsdataview.DataSource = bsource3;
                    MessageBox.Show("Updated.");
                }
                catch (Exception ex)
                {
                    Cursor = Cursors.Arrow;
                    MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
                }
                Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Arrow;
                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }

        private void randbtn_Click(object sender, EventArgs e)
        {

            try
            {
                Cursor = Cursors.WaitCursor;
                dr = obj.Query("SELECT productname,picture,productid FROM lalchowk.products WHERE stock>0 ORDER BY RAND() LIMIT 4 ");
                List<string> productname = new List<string>();
                List<string> picture = new List<string>();
                List<string> productid = new List<string>();
                int i = 0;
                while (dr.Read())
                {
                    productname.Add(dr["productname"].ToString());
                    picture.Add(dr["picture"].ToString());
                    productid.Add(dr["productid"].ToString());

                    i++;

                }
                obj.closeConnection();


                p1title.Text = productname[0];
                p1pic.Text = picture[0];
                p1link.Text = productid[0];
                p1.ImageLocation = url + p1pic.Text;

                p2title.Text = productname[1];
                p2pic.Text = picture[1];
                p2link.Text = productid[1];
                p2.ImageLocation = url + p2pic.Text;

                p3title.Text = productname[2];
                p3pic.Text = picture[2];
                p3link.Text = productid[2];
                p3.ImageLocation = url + p3pic.Text;

                p4title.Text = productname[3];
                p4pic.Text = picture[3];
                p4link.Text = productid[3];
                p4.ImageLocation = url + p4pic.Text;
                Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }

        }

        private void readhomepage2()
        {
            try
            {
                con.Open();
                adap = new MySqlDataAdapter("SELECT productid, productname, picture, stock, price, categoryid FROM products", con);
                dt = new DataTable();
                adap.Fill(dt);
                con.Close();
                bsource2 = new BindingSource();
                bsource2.DataSource = dt;

               
                
                dr = obj.Query("select picture,link from homepage2 where homeid='1'");
                dr.Read();
                lefttxtvar = dr[0].ToString();
                leftlinkvar = dr[1].ToString();
                obj.closeConnection();

                dr = obj.Query("select picture,link from homepage2 where homeid='2'");
                dr.Read();
                righttxtvar = dr[0].ToString();
                rightlinkvar = dr[1].ToString();
                obj.closeConnection();

                leftpic.ImageLocation = (url + lefttxt.Text);
                leftpic.SizeMode = PictureBoxSizeMode.StretchImage;
                rightpic.ImageLocation = (url + righttxt.Text);
                rightpic.SizeMode = PictureBoxSizeMode.StretchImage;

                dr = obj.Query("select title, subtitle, picture, link from homepage2 where homeid='3'");
                dr.Read();
                p1titlevar = dr[0].ToString();
                p1subvar = dr[1].ToString();
                p1picvar = dr[2].ToString();
                p1linkvar = dr[3].ToString();
                obj.closeConnection();
                p1.ImageLocation = (url + p1pic.Text);


                dr = obj.Query("select title, subtitle, picture, link from homepage2 where homeid='4'");
                dr.Read();
                p2titlevar = dr[0].ToString();
                p2subvar = dr[1].ToString();
                p2picvar = dr[2].ToString();
                p2linkvar = dr[3].ToString();
                obj.closeConnection();
                p2.ImageLocation = (url + p2pic.Text);

                dr = obj.Query("select title, subtitle, picture, link from homepage2 where homeid='5'");
                dr.Read();
                p3titlevar = dr[0].ToString();
                p3subvar = dr[1].ToString();
                p3picvar = dr[2].ToString();
                p3linkvar = dr[3].ToString();
                obj.closeConnection();
                p3.ImageLocation = (url + p3pic.Text);

                dr = obj.Query("select title, subtitle, picture, link from homepage2 where homeid='6'");
                dr.Read();
                p4titlevar = dr[0].ToString();
                p4subvar = dr[1].ToString();
                p4picvar = dr[2].ToString();
                p4linkvar = dr[3].ToString();
                obj.closeConnection();
                p4.ImageLocation = (url + p4pic.Text);

            }
            catch (Exception ex)
            {

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }



        private void fcattxt_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = string.Format("categoryid LIKE '%{0}%'", fcattxt.Text);
            productsdataview.DataSource = dv;
        }

        private void p1pic_TextChanged(object sender, EventArgs e)
        {
            p1.ImageLocation = (url + p1pic.Text);
        }

        private void p2pic_TextChanged(object sender, EventArgs e)
        {
            p2.ImageLocation = (url + p2pic.Text);
        }

        private void p3pic_TextChanged(object sender, EventArgs e)
        {
            p3.ImageLocation = (url + p3pic.Text);
        }

        private void p4pic_TextChanged(object sender, EventArgs e)
        {
            p4.ImageLocation = (url + p4pic.Text);
        }

      

        private void u1_Click(object sender, EventArgs e)
        {
            try {
                cmd = "update homepage2 set title='" + p1title.Text + "',subtitle='" + p1sub.Text + "',picture='" + p1pic.Text + "',link='" + p1link.Text + "' where homeid='3'";
                obj.nonQuery(cmd);
                MessageBox.Show("Updated.");
            }

            catch (Exception ex)
            {

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }

        private void u2_Click(object sender, EventArgs e)
        {
            try {
                cmd = "update homepage2 set title='" + p2title.Text + "',subtitle='" + p2sub.Text + "',picture='" + p2pic.Text + "',link='" + p2link.Text + "' where homeid='4'";
                obj.nonQuery(cmd);
                MessageBox.Show("Updated.");
            }

            catch (Exception ex)
            {

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }

        private void offersdataview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.offersdataview.Rows[e.RowIndex];
                oid = row.Cells["offerid"].Value.ToString();
                oname= row.Cells["picture"].Value.ToString();
            }
        }

        private void rowdelbtn_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dgr = MessageBox.Show("Do you want to delete the following offer ?\n" + oname, "Confirm!", MessageBoxButtons.YesNo);
                if (dgr == DialogResult.Yes) { 
                cmd = "delete from offers where offerid='" + oid + "'";
                obj.nonQuery(cmd);
                MessageBox.Show("Deleted sucessfully.");
            }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
            Cursor = Cursors.WaitCursor;
            readoffers();
            offersdataview.DataSource = bsource;
            Cursor = Cursors.Arrow;
        }

        private void productsdataview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.productsdataview.Rows[e.RowIndex];
                string ppiclocation = row.Cells["picture"].Value.ToString();
                ppic.ImageLocation = (url + ppiclocation);
            }
        }

        private void lefttxt_TextChanged(object sender, EventArgs e)
        {
            leftpic.ImageLocation = (url + lefttxt.Text);
        }

        private void righttxt_TextChanged(object sender, EventArgs e)
        {
            rightpic.ImageLocation = (url + righttxt.Text);
        }

        private void u3_Click(object sender, EventArgs e)
        {
            try {
                cmd = "update homepage2 set title='" + p3title.Text + "',subtitle='" + p3sub.Text + "',picture='" + p3pic.Text + "',link='" + p3link.Text + "' where homeid='5'";
                obj.nonQuery(cmd);
                MessageBox.Show("Updated.");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }


        private void u4_Click(object sender, EventArgs e)
        {
            try
            { 
            cmd = "update homepage2 set title='" + p4title.Text + "',subtitle='" + p4sub.Text + "',picture='" + p4pic.Text + "',link='" + p4link.Text + "' where homeid='6'";
            obj.nonQuery(cmd);
            MessageBox.Show("Updated.");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }


        private void upd4btn_Click(object sender, EventArgs e)
        {
            try {
                cmd = "update homepage2 set title='" + p1title.Text + "',subtitle='" + p1sub.Text + "',picture='" + p1pic.Text + "',link='" + p1link.Text + "' where homeid='3'";
                obj.nonQuery(cmd);
                cmd = "update homepage2 set title='" + p2title.Text + "',subtitle='" + p2sub.Text + "',picture='" + p2pic.Text + "',link='" + p2link.Text + "' where homeid='4'";
                obj.nonQuery(cmd);
                cmd = "update homepage2 set title='" + p3title.Text + "',subtitle='" + p3sub.Text + "',picture='" + p3pic.Text + "',link='" + p3link.Text + "' where homeid='5'";
                obj.nonQuery(cmd);
                cmd = "update homepage2 set title='" + p4title.Text + "',subtitle='" + p4sub.Text + "',picture='" + p4pic.Text + "',link='" + p4link.Text + "' where homeid='6'";
                obj.nonQuery(cmd);
                MessageBox.Show("Updated.");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }

        private void updbbtn_Click(object sender, EventArgs e)
        {
            try
            {
                cmdbl = new MySqlCommandBuilder(adap);
                adap.Update(dt1);
                MessageBox.Show("Updated Successfully.");

            }
            catch (Exception ex)
            {

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }
    }
}
