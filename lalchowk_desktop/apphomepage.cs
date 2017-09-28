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

namespace Veiled_Kashmir_Admin_Panel
{
    public partial class apphomepage : Form
    {

        DBConnect obj = new DBConnect();
        string cmd;
        MySqlDataAdapter adap,adap1;
        DataTable dt,dt1,dt5;
        MySqlCommandBuilder cmdbl,cmdbl1;
        MySqlDataReader dr;
        string oid;
        MySqlConnection con = new MySqlConnection("SERVER=182.50.133.78;DATABASE=lalchowk;USER=lalchowk;PASSWORD=Lalchowk@123uzmah");
        string url = "http://lalchowk.in/lalchowk/pictures/";

        public apphomepage()
        {
            InitializeComponent();
            readoffers();
            readhomepage2();
        }

       
        private void readoffers()
        {
            con.Open();
            adap1 = new MySqlDataAdapter("SELECT * FROM offers", con);
            dt5 = new DataTable();
            adap1.Fill(dt5);
            con.Close();
            BindingSource bsource = new BindingSource();
            bsource.DataSource = dt5;
            offersdataview.DataSource = bsource;

        }

        private void updoffers_Click(object sender, EventArgs e)
        {
            try
            {
                cmdbl = new MySqlCommandBuilder(adap1);
                adap1.Update(dt5);
                MessageBox.Show("Offers Updated.");
                readoffers();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void readhomepage2()
        {

            con.Open();
            adap = new MySqlDataAdapter("SELECT productid, productname, picture, stock, price, categoryid FROM products", con);
            dt = new DataTable();
            adap.Fill(dt);
            con.Close();
            BindingSource bsource2 = new BindingSource();
            bsource2.DataSource = dt;
            productsdataview.DataSource = bsource2;


            con.Open();
            adap = new MySqlDataAdapter("SELECT * FROM homepage2 where homeid >6", con);
            dt1 = new DataTable();
            adap.Fill(dt1);
            con.Close();
            BindingSource bsource3 = new BindingSource();
            bsource3.DataSource = dt1;
            itemsdataview.DataSource = bsource3;



            dr = obj.Query("select picture,link from homepage2 where homeid='1'");
            dr.Read();
            lefttxt.Text = dr[0].ToString();
            leftlink.Text = dr[1].ToString();
            obj.closeConnection();

            dr= obj.Query("select picture,link from homepage2 where homeid='2'");
            dr.Read();
            righttxt.Text = dr[0].ToString();
            rightlink.Text = dr[1].ToString();
            obj.closeConnection();
            
            leftpic.ImageLocation = (url + lefttxt.Text);
            leftpic.SizeMode = PictureBoxSizeMode.StretchImage;
            rightpic.ImageLocation= (url + righttxt.Text);
            rightpic.SizeMode = PictureBoxSizeMode.StretchImage;




            dr = obj.Query("select title, subtitle, picture, link from homepage2 where homeid='3'");
            dr.Read();
            p1title.Text = dr[0].ToString();
            p1sub.Text = dr[1].ToString();
            p1pic.Text = dr[2].ToString();
            p1link.Text = dr[3].ToString();
            obj.closeConnection();
            p1.ImageLocation= (url + p1pic.Text);
        
         

            dr = obj.Query("select title, subtitle, picture, link from homepage2 where homeid='4'");
            dr.Read();
            p2title.Text = dr[0].ToString();
            p2sub.Text = dr[1].ToString();
            p2pic.Text = dr[2].ToString();
            p2link.Text = dr[3].ToString();
            obj.closeConnection();
            p2.ImageLocation = (url + p2pic.Text);
           


            dr = obj.Query("select title, subtitle, picture, link from homepage2 where homeid='5'");
            dr.Read();
            p3title.Text = dr[0].ToString();
            p3sub.Text = dr[1].ToString();
            p3pic.Text = dr[2].ToString();
            p3link.Text = dr[3].ToString();
            obj.closeConnection();
            p3.ImageLocation = (url + p3pic.Text);
           


            dr = obj.Query("select title, subtitle, picture, link from homepage2 where homeid='6'");
            dr.Read();
            p4title.Text = dr[0].ToString();
            p4sub.Text = dr[1].ToString();
            p4pic.Text = dr[2].ToString();
            p4link.Text = dr[3].ToString();
            obj.closeConnection();
            p4.ImageLocation = (url + p4pic.Text);
           


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

        private void upddpbtn_Click(object sender, EventArgs e)
        {
            cmd = "update homepage2 set picture='"+lefttxt.Text+"',link='"+leftlink.Text+"' where homeid='1'";
            obj.nonQuery(cmd);

            cmd = "update homepage2 set picture='" + righttxt.Text + "',link='" + rightlink.Text + "' where homeid='2'";
            obj.nonQuery(cmd);

            MessageBox.Show("Display pictures updated.");
        }

        private void u1_Click(object sender, EventArgs e)
        {
            cmd = "update homepage2 set title='" + p1title.Text + "',subtitle='"+p1sub.Text+"',picture='"+p1pic.Text+"',link='" + p1link.Text + "' where homeid='3'";
            obj.nonQuery(cmd);
            MessageBox.Show("Updated.");
        }

        private void u2_Click(object sender, EventArgs e)
        {
            cmd = "update homepage2 set title='" + p2title.Text + "',subtitle='" + p2sub.Text + "',picture='" + p2pic.Text + "',link='" + p2link.Text + "' where homeid='4'";
            obj.nonQuery(cmd);
            MessageBox.Show("Updated.");
        }

        private void offersdataview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.offersdataview.Rows[e.RowIndex];
                oid = row.Cells["offerid"].Value.ToString();
            }
        }

        private void rowdelbtn_Click(object sender, EventArgs e)
        {
            cmd = "delete from offers where offerid='"+oid+"'";
            obj.nonQuery(cmd);
            MessageBox.Show("Deleted sucessfully.");
            Cursor = Cursors.WaitCursor;
            readoffers();
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
            cmd = "update homepage2 set title='" + p3title.Text + "',subtitle='" + p3sub.Text + "',picture='" + p3pic.Text + "',link='" + p3link.Text + "' where homeid='5'";
            obj.nonQuery(cmd);
            MessageBox.Show("Updated.");
        }

        private void u4_Click(object sender, EventArgs e)
        {
            cmd = "update homepage2 set title='" + p4title.Text + "',subtitle='" + p4sub.Text + "',picture='" + p4pic.Text + "',link='" + p4link.Text + "' where homeid='6'";
            obj.nonQuery(cmd);
            MessageBox.Show("Updated.");
        }

       
        private void upd4btn_Click(object sender, EventArgs e)
        {
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
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
