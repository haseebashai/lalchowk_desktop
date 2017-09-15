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
using System.Threading;


namespace Veiled_Kashmir_Admin_Panel
{

    public partial class mainform : Form
    {

        DBConnect obj = new DBConnect();
        MySqlConnection con = new MySqlConnection("SERVER=182.50.133.78;DATABASE=lalchowk;USER=lalchowk;PASSWORD=Lalchowk@123uzmah");
        MySqlDataAdapter adap;
        DataTable dt;
        MySqlDataReader dr;

        private container hp = null;
        public mainform(Form hpcopy)
        {
            hp = hpcopy as container;
            InitializeComponent();

            Form loading = new Form();
            loading.Size = new Size(50, 50);
            loading.FormBorderStyle = FormBorderStyle.FixedDialog;
            loading.ControlBox = false;
            loading.BackColor = Color.LightBlue;
            loading.StartPosition = FormStartPosition.CenterScreen;
            loading.Controls.Add(new Label() { Text = "LOADING...", Font = new Font("trajan pro", Font.Size, FontStyle.Bold) });
            loading.Show();
            Cursor = Cursors.WaitCursor;
            readordersshipped();
            readordersplaced();
            readordersdelivered();
            Cursor = Cursors.Arrow;
            loading.Close();
        }



        private void mainform_Load(object sender, EventArgs e)
        {

            if (userinfo.loggedin == true)
                signout();
            changelabel("Welcome, " + userinfo.username + "");


        }



        private void readordersplaced()
        {
            try { 
            con.Open();
            adap = new MySqlDataAdapter("select * from orders where status='placed'", con);
            dt = new DataTable();
            adap.Fill(dt);
            con.Close();
            BindingSource bsource = new BindingSource();
            bsource.DataSource = dt;
            placeddataview.DataSource = bsource;

            dr = obj.Query("Select count(status) from orders where status='placed'");
            dr.Read();
            attentionlbl.Text = "> " + dr[0].ToString() + " Order(s) need your Attention ASAP!";
            obj.closeConnection();

            dr = obj.Query("select sum(dealerprice*quantity) from orderdetails where productid in (SELECT productid FROM orderdetails where orderid in (SELECT orderid FROM orders where status = 'placed'))");
            dr.Read();
            costlbl.Text = "> Will cost Rs. " + dr[0].ToString() + "/-";
            obj.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    

        private void readordersshipped()
        {
            try {
                con.Open();
                adap = new MySqlDataAdapter("select * from orders where status='shipped'", con);
                dt = new DataTable();
                adap.Fill(dt);
                con.Close();
                BindingSource bsource = new BindingSource();
                bsource.DataSource = dt;
                shippeddataview.DataSource = bsource;
            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void readordersdelivered()
        {
            try {
                dr = obj.Query("SELECT count(status) FROM orders where status='delivered'");
                dr.Read();
                ordersdlbl.Text = dr[0].ToString();
                obj.closeConnection();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    

        private void ordersbtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            orders or = new orders(hp);
            or.TopLevel = false;
            cntpnl.Controls.Clear();
            cntpnl.Controls.Add(or);           
            or.Show();
            Cursor = Cursors.Arrow;
        }
        public void changelabel(String welcome)
        {
            signinlbl.Text = welcome;

            signinlbl.Visible = true;

        }
        public void signout()
        {
            signoutlbl.Visible = true;
        }

        private void signoutlbl_Click(object sender, EventArgs e)
        {
            userinfo.loggedin = false;
            userinfo.username = "";           
            this.Close();
            MessageBox.Show("Logged out sucessfully.\nPlease Log in to continue");

            loginform lg = new loginform(hp,this);
            hp.mainpnl.Controls.Clear();
            lg.TopLevel = false;
            hp.mainpnl.Controls.Add(lg);
            lg.Show();
        }

        private void signoutlbl_Enter(object sender, EventArgs e)
        {
            signoutlbl.Cursor = Cursors.Hand;
        }

        private void productsbtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            products pr = new products(hp,this);
            pr.TopLevel = false;
            cntpnl.Controls.Clear();
            cntpnl.Controls.Add(pr);           
            pr.Show();
            Cursor = Cursors.Arrow;
        }

       

        private void customersbtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            customers cus = new customers(hp);
            cus.TopLevel = false;
            cntpnl.Controls.Clear();
            cntpnl.Controls.Add(cus);
            cus.Show();
            Cursor = Cursors.Arrow;
        }

        


        private void expbtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            expenditure exp = new expenditure(this,hp);
            exp.TopLevel = false;
            cntpnl.Controls.Clear();
            cntpnl.Controls.Add(exp);
            exp.Show();
            Cursor = Cursors.Arrow;
        }

        private void suppliersbtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            suppliers sup = new suppliers(hp);
            sup.TopLevel = false;
            cntpnl.Controls.Clear();
            cntpnl.Controls.Add(sup);
            sup.Show();
            Cursor = Cursors.Arrow;
        }

        private void chkbtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            accounts acc = new accounts(hp);
            acc.TopLevel = false;
            cntpnl.Controls.Clear();
            cntpnl.Controls.Add(acc);
            acc.readexpenses();
            acc.Show();
            Cursor = Cursors.Arrow;
        }

        private void approvebtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            approveprice ap = new approveprice(hp);
            cntpnl.Controls.Clear();
            ap.TopLevel = false;
            cntpnl.Controls.Add(ap);
            ap.Show();
            Cursor = Cursors.Arrow;
        }

        private void termsbtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            terms tr = new terms(hp);
            tr.TopLevel = false;
            cntpnl.Controls.Clear();
            cntpnl.Controls.Add(tr);
            tr.readterms();
            tr.Show();
            Cursor = Cursors.Arrow;
        }

        private void faqbtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            terms tr = new terms(hp);
            tr.TopLevel = false;
            cntpnl.Controls.Clear();
            tr.faqpnl.Visible = true;
            cntpnl.Controls.Add(tr);
            tr.readfaq();
            tr.Show();
            Cursor = Cursors.Arrow;
        }

        private void aboutbtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            terms tr = new terms(hp);
            tr.TopLevel = false;
            cntpnl.Controls.Clear();
            tr.aboutpnl.Visible = true;
            cntpnl.Controls.Add(tr);
            tr.readabout();
            tr.Show();
            Cursor = Cursors.Arrow;
        }

        private void navtxt_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            mainform mf = new mainform(hp);
            hp.mainpnl.Controls.Clear();
            mf.TopLevel = false;
            hp.mainpnl.Controls.Add(mf);
            mf.Show();
            Cursor = Cursors.Arrow;
        }

        private void orderslbl_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            ordersdetails od = new ordersdetails(hp);
            cntpnl.Controls.Clear();
            od.TopLevel = false;
            od.readordersdelivered();
            cntpnl.Controls.Add(od);
            od.Show();
            Cursor = Cursors.Arrow;
        }

        private void placedlbl_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            ordersdetails od = new ordersdetails(hp);
            od.TopLevel = false;
            cntpnl.Controls.Clear();
            od.orderslbl.Text = "Orders Placed";
            od.readordersplaced();
            cntpnl.Controls.Add(od);
            od.Show();
            Cursor = Cursors.Arrow;
        }

        private void cobtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            cancelorders co = new cancelorders();
            cntpnl.Controls.Clear();
            co.TopLevel = false;
            cntpnl.Controls.Add(co);
            co.Show();
            Cursor = Cursors.Arrow;
        }

        private void msgbtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            messages msg = new messages();
            cntpnl.Controls.Clear();
            msg.TopLevel = false;
            cntpnl.Controls.Add(msg);
            msg.Show();
            Cursor = Cursors.Arrow;
            

        }

        private void homepagebtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            apphomepage aph = new apphomepage();
            cntpnl.Controls.Clear();
            aph.TopLevel = false;
            cntpnl.Controls.Add(aph);
            aph.Show();
            Cursor = Cursors.Arrow;
        }
    }
}
