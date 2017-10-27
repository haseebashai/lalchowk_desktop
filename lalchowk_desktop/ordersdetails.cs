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
using System.Text.RegularExpressions;

namespace Veiled_Kashmir_Admin_Panel
{
    public partial class ordersdetails : Form
    {

        MySqlCommandBuilder cmdbl;
        MySqlDataAdapter adap;
        DataTable dt;
        DBConnect obj= new DBConnect();
        MySqlConnection con = new MySqlConnection("SERVER=182.50.133.78;DATABASE=lalchowk;USER=lalchowk;PASSWORD=Lalchowk@123uzmah");
        MySqlDataReader dr;
        BindingSource bsource;
        PictureBox loading = new PictureBox();


        private dialogcontainer dg = null;
        private mainform mf = null;
        public ordersdetails(Form mfcopy,Form dgcopy)
        {
            dg = dgcopy as dialogcontainer;
            mf = mfcopy as mainform;
            InitializeComponent();
            
        }

        public void readordersdelivered()
        {try { 
            con.Open();
            adap = new MySqlDataAdapter("select * from orders where status='delivered'", con);
            dt = new DataTable();
            adap.Fill(dt);
            bsource = new BindingSource();
            bsource.DataSource = dt;
        }
            catch (Exception ex)
            {
                var message = ex.ToString();
                string[] split = message.Split(new string[] { "at" }, StringSplitOptions.None);
                MessageBox.Show("Something happened, please try again.\n\n" + split[0], "Error!");
            }

        }

        public void readordersplaced()
        {try { 
            con.Open();
            adap = new MySqlDataAdapter("select * from orders where status='placed'", con);
            dt = new DataTable();
            adap.Fill(dt);
            bsource = new BindingSource();
            bsource.DataSource = dt;
        }
            catch (Exception ex)
            {
                var message = ex.ToString();
                string[] split = message.Split(new string[] { "at" }, StringSplitOptions.None);
                MessageBox.Show("Something happened, please try again.\n\n" + split[0], "Error!");
            }
        }

        public void readordershipped()
        {try { 
            con.Open();
            adap = new MySqlDataAdapter("select * from orders where status='shipped'", con);
            dt = new DataTable();
            adap.Fill(dt);
            bsource = new BindingSource();
            bsource.DataSource = dt;
        }
            catch (Exception ex)
            {
                var message = ex.ToString();
                string[] split = message.Split(new string[] { "at" }, StringSplitOptions.None);
                MessageBox.Show("Something happened, please try again.\n\n" + split[0], "Error!");
            }
        }

        public void readpurchasecost()
        {try { 
            con.Open();
            adap = new MySqlDataAdapter("select * from lalchowk.orderdetails where productid in (SELECT productid FROM lalchowk.orderdetails where orderid in (SELECT orderid FROM lalchowk.orders where status = 'delivered'))", con);
            dt = new DataTable();
            adap.Fill(dt);
            bsource = new BindingSource();
            bsource.DataSource = dt;
        }
            catch (Exception ex)
            {
                var message = ex.ToString();
                string[] split = message.Split(new string[] { "at" }, StringSplitOptions.None);
                MessageBox.Show("Something happened, please try again.\n\n" + split[0], "Error!");
            }
        }

        public void readprofit()
        {try { 
            con.Open();
            adap = new MySqlDataAdapter("select orderdetailid,orderid,productid,productname,price,quantity,dealerprice,size,price-dealerprice as profit from orderdetails where orderid in (SELECT orderid FROM orders where status = 'delivered')", con);
            dt = new DataTable();
            adap.Fill(dt);
            bsource = new BindingSource();
            bsource.DataSource = dt;
        }
            catch (Exception ex)
            {
                var message = ex.ToString();
                string[] split = message.Split(new string[] { "at" }, StringSplitOptions.None);
                MessageBox.Show("Something happened, please try again.\n\n" + split[0], "Error!");
            }
        }

        private void upbtn_Click(object sender, EventArgs e)
        {
            try
            {
                cmdbl = new MySqlCommandBuilder(adap);
                adap.Update(dt);
                MessageBox.Show("Entry Updated.");

            }
            catch (Exception ex)
            {
                var message = ex.ToString();
                string[] split = message.Split(new string[] { "at" }, StringSplitOptions.None);
                MessageBox.Show("Something happened, please try again.\n\n" + split[0], "Error!");
            }
        }

        public void readshipping()
        {try { 
            con.Open();
            adap = new MySqlDataAdapter("select orderid, email, shipdate,shipping from lalchowk.orders where status ='delivered'",con);
            dt = new DataTable();
            adap.Fill(dt);
            bsource = new BindingSource();
            bsource.DataSource = dt;
        }
            catch (Exception ex)
            {
                var message = ex.ToString();
                string[] split = message.Split(new string[] { "at" }, StringSplitOptions.None);
                MessageBox.Show("Something happened, please try again.\n\n" + split[0], "Error!");
            }
        }

        private void bgworker_DoWork(object sender, DoWorkEventArgs e)
        {
            readordersplaced();
        }

        private void bgworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (ActiveForm == dg)
            {
                dg.loadingimage.Visible = false;
                dg.lbl.ForeColor = SystemColors.Highlight;
                dg.lbl.Text = "Orders currently placed";

            }
            else
            {
                loading.Visible = false;
                orderslbl.Text = "Orders currently placed";
                
            }
            ordersdataview.DataSource = bsource;
            ordersdataview.Visible = true;
            upbtn.Visible = true;
        }

        private void bgworker1_DoWork(object sender, DoWorkEventArgs e)
        {
            readordersdelivered();
        }

        private void bgworker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (ActiveForm == dg)
            {
                dg.loadingimage.Visible = false;
                dg.lbl.ForeColor = SystemColors.Highlight;
                dg.lbl.Text = "Orders Delivered";

            }
            else
            {
                loading.Visible = false;
                orderslbl.Text = "Orders Delivered";

            }
            ordersdataview.DataSource = bsource;
            ordersdataview.Visible = true;
            upbtn.Visible = true;
            
        }

        private void bgworker2_DoWork(object sender, DoWorkEventArgs e)
        {
            readordershipped();
        }

        private void bgworker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (ActiveForm == dg)
            {
                dg.loadingimage.Visible = false;
                dg.lbl.ForeColor = SystemColors.Highlight;
                dg.lbl.Text = "Orders currently shipped";

            }
            else
            {
                loading.Visible = false;
                orderslbl.Text = "Orders currently shipped";

            }
            ordersdataview.DataSource = bsource;
            ordersdataview.Visible = true;
            upbtn.Visible = true;
            
        }

        private void bgworker3_DoWork(object sender, DoWorkEventArgs e)
        {
            readshipping();
        }

        private void bgworker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (ActiveForm == dg)
            {
                dg.loadingimage.Visible = false;
                dg.lbl.ForeColor = SystemColors.Highlight;
                dg.lbl.Text = "Shipping Charges";

            }
            else
            {
                loading.Visible = false;
                orderslbl.Text = "Shipping Charges";

            }
            ordersdataview.DataSource = bsource;
            ordersdataview.Visible = true;
            upbtn.Visible = true;
        }

        private void bgworker4_DoWork(object sender, DoWorkEventArgs e)
        {
            readprofit();
        }

        private void bgworker4_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (ActiveForm == dg)
            {
                dg.loadingimage.Visible = false;
                dg.lbl.ForeColor = SystemColors.Highlight;
                dg.lbl.Text = "Profit distribution";

            }
            else
            {
                loading.Visible = false;
                orderslbl.Text = "Profit distribution";

            }
            ordersdataview.DataSource = bsource;
            ordersdataview.Visible = true;
            upbtn.Visible = true;
        }

        private void bgworker5_DoWork(object sender, DoWorkEventArgs e)
        {
            readpurchasecost();
        }

        private void bgworker5_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (ActiveForm == dg)
            {
                dg.loadingimage.Visible = false;
                dg.lbl.ForeColor = SystemColors.Highlight;
                dg.lbl.Text = "Purchase cost";

            }
            else
            {
                loading.Visible = false;
                orderslbl.Text = "Purchase cost";

            }
            ordersdataview.DataSource = bsource;
            ordersdataview.Visible = true;
            upbtn.Visible = true;
        }

        public void loadingnormal()
        {
            orderslbl.Text = "Loading";

            loading = new PictureBox()
            {
                Image = Properties.Resources.loading,
                Size = new Size(40, 30),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Location = new Point(82, 0),
            };
            this.Controls.Add(loading);
        }
        public void loadingdg()
        {
            orderslbl.Visible = false;
            dg.lbl.ForeColor = SystemColors.Highlight;
            dg.lbl.Text = "Loading";
            dg.loadingimage.SizeMode = PictureBoxSizeMode.StretchImage;
            dg.loadingimage.Visible = true;
        }
    }
}
