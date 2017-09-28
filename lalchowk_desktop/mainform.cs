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
using System.Diagnostics;

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

            loadingform();
        }

        private void loadingform()
        {
            Form loading = new Form();
            loading.Size = new Size(50, 50);
            loading.FormBorderStyle = FormBorderStyle.FixedDialog;
            loading.ControlBox = false;
            loading.BackColor = Color.LightBlue;
            loading.StartPosition = FormStartPosition.CenterScreen;
            loading.Controls.Add(new Label() { Text = "LOADING...", Font = new Font("trajan pro", Font.Size, FontStyle.Bold) });

            try
            {
                loading.Show();
                Cursor = Cursors.WaitCursor;
                readordersshipped();
                readordersplaced();
                readordersdelivered();
                Cursor = Cursors.Arrow;
                loading.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally {
                loading.Close();
            }

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
            adap = new MySqlDataAdapter("select customer.mail,orders.* from lalchowk.orders inner join customer on customer.email=orders.email where status='placed';", con);
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

            dr = obj.Query("select sum(dealerprice*quantity) from orderdetails where orderid in(SELECT orderid FROM orders where status = 'placed');");
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
                adap = new MySqlDataAdapter("select customer.mail,orders.* from lalchowk.orders inner join customer on customer.email=orders.email where status='shipped';", con);
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

            if (cntpnl.Contains(placeddataview))
            {
                Cursor = Cursors.WaitCursor;
                orders or = new orders(hp);
                or.TopLevel = false;
                cntpnl.Controls.Clear();
                cntpnl.Controls.Add(or);
                or.Show();
                Cursor = Cursors.Arrow;
            }
            else
            {
                orders or = new orders(hp);
                or.TopLevel = false;
                dialogcontainer dg = new dialogcontainer();
                dg.dialogpnl.Controls.Add(or);
                dg.lbl.Text = "Orders";

                dg.Show();
                or.Show();
            }
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
            if (cntpnl.Contains(placeddataview))
            {
                Cursor = Cursors.WaitCursor;
                products pr = new products(hp, this);
                pr.TopLevel = false;
                cntpnl.Controls.Clear();
                cntpnl.Controls.Add(pr);
                pr.Show();
                Cursor = Cursors.Arrow;
            }
            else
            {
                products pr  = new products(hp,this);
                pr.TopLevel = false;
                dialogcontainer dg = new dialogcontainer();
                dg.dialogpnl.Controls.Add(pr);
                dg.lbl.Text = "";

                dg.Show();
                pr.Show();
            }
        }


        private void customersbtn_Click(object sender, EventArgs e)
        {
            if (cntpnl.Contains(placeddataview))
            {
                Cursor = Cursors.WaitCursor;
                customers cus = new customers(hp);
                cus.TopLevel = false;
                cntpnl.Controls.Clear();
                cntpnl.Controls.Add(cus);
                cus.Show();
                Cursor = Cursors.Arrow;
            }
            else
            {
                customers cus = new customers(hp);
                cus.TopLevel = false;
                dialogcontainer dg = new dialogcontainer();
                dg.dialogpnl.Controls.Add(cus);
                dg.lbl.Text = "";

                dg.Show();
                cus.Show();
            }
        }



        private void expbtn_Click(object sender, EventArgs e)
        {
            if (cntpnl.Contains(placeddataview))
            {
                Cursor = Cursors.WaitCursor;
                expenditure exp = new expenditure(this, hp);
                exp.TopLevel = false;
                cntpnl.Controls.Clear();
                cntpnl.Controls.Add(exp);
                exp.Show();
                Cursor = Cursors.Arrow;
            }
            else
            {
                expenditure exp = new expenditure(this, hp);
                exp.TopLevel = false;
                dialogcontainer dg = new dialogcontainer();
                dg.dialogpnl.Controls.Add(exp);
                dg.lbl.Text = "";

                dg.Show();
                exp.Show();
            }
        }

        private void suppliersbtn_Click(object sender, EventArgs e)
        {
            if (cntpnl.Contains(placeddataview))
            {
                Cursor = Cursors.WaitCursor;
                suppliers sup = new suppliers(hp);
                sup.TopLevel = false;
                cntpnl.Controls.Clear();
                cntpnl.Controls.Add(sup);
                sup.Show();
                Cursor = Cursors.Arrow;
            }
            else
            {
                suppliers sup = new suppliers(hp);
                sup.TopLevel = false;
                dialogcontainer dg = new dialogcontainer();
                dg.dialogpnl.Controls.Add(sup);
                dg.lbl.Text = "";

                dg.Show();
                sup.Show();
            }

        }

        private void chkbtn_Click(object sender, EventArgs e)
        {
            if (cntpnl.Contains(placeddataview))
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
            else
            {
                accounts acc = new accounts(hp);
                acc.TopLevel = false;
                dialogcontainer dg = new dialogcontainer();
                dg.dialogpnl.Controls.Add(acc);
                dg.lbl.Text = "";

                dg.Show();
                acc.Show();
            }
        }

        private void approvebtn_Click(object sender, EventArgs e)
        {
            if (cntpnl.Contains(placeddataview))
            {
                Cursor = Cursors.WaitCursor;
                approveprice ap = new approveprice(hp);
                cntpnl.Controls.Clear();
                ap.TopLevel = false;
                cntpnl.Controls.Add(ap);
                ap.Show();
                Cursor = Cursors.Arrow;
            }
            else
            {
                approveprice ap = new approveprice(hp);
                ap.TopLevel = false;
                dialogcontainer dg = new dialogcontainer();
                dg.dialogpnl.Controls.Add(ap);
                dg.lbl.Text = "";

                dg.Show();
                ap.Show();
            }
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
            if (cntpnl.Contains(placeddataview))
            {
                Cursor = Cursors.WaitCursor;
                cancelorders co = new cancelorders();
                cntpnl.Controls.Clear();
                co.TopLevel = false;
                cntpnl.Controls.Add(co);
                co.Show();
                Cursor = Cursors.Arrow;
            }
            else
            {
                cancelorders co = new cancelorders();
                co.TopLevel = false;
                dialogcontainer dg = new dialogcontainer();
                dg.dialogpnl.Controls.Add(co);
                dg.lbl.Text = "";

                dg.Show();
                co.Show();
            }
        }

        private void msgbtn_Click(object sender, EventArgs e)
        {
            if (cntpnl.Contains(placeddataview))
            {
                Cursor = Cursors.WaitCursor;
                messages msg = new messages();
                cntpnl.Controls.Clear();
                msg.TopLevel = false;
                cntpnl.Controls.Add(msg);
                msg.Show();
                Cursor = Cursors.Arrow;
            }
            else
            {
                messages msg = new messages();
                msg.TopLevel = false;
                dialogcontainer dg = new dialogcontainer();
                dg.dialogpnl.Controls.Add(msg);
                dg.lbl.Text = "";

                dg.Show();
                msg.Show();
            }

        }

        private void homepagebtn_Click(object sender, EventArgs e)
        {
            if (cntpnl.Contains(placeddataview))
            {
                Cursor = Cursors.WaitCursor;
                apphomepage aph = new apphomepage();
                cntpnl.Controls.Clear();
                aph.TopLevel = false;
                cntpnl.Controls.Add(aph);
                aph.Show();
                Cursor = Cursors.Arrow;
            }
            else
            {
                apphomepage aph = new apphomepage();
                aph.TopLevel = false;
                dialogcontainer dg = new dialogcontainer();
                dg.dialogpnl.Controls.Add(aph);
                dg.lbl.Text = "";

                dg.Show();
                aph.Show();
            }
        }

        private void caboutbtn_Click(object sender, EventArgs e)
        {
            if (cntpnl.Contains(placeddataview))
            {
                Cursor = Cursors.WaitCursor;
                terms tr = new terms(hp);
                tr.TopLevel = false;
                cntpnl.Controls.Clear();
                tr.termspnl.Visible = true;
                cntpnl.Controls.Add(tr);
                tr.readterms();
                tr.Show();
                Cursor = Cursors.Arrow;
            }
            else
            {
                terms tr = new terms(hp);
                tr.TopLevel = false;
                dialogcontainer dg = new dialogcontainer();
                dg.dialogpnl.Controls.Add(tr);
                dg.lbl.Text = "";

                dg.Show();
                tr.Show();
            }
        }

        private void shippedlbl_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            ordersdetails od = new ordersdetails(hp);
            od.TopLevel = false;
            cntpnl.Controls.Clear();
            od.orderslbl.Text = "Orders Shipped";
            od.readordershipped();
            cntpnl.Controls.Add(od);
            od.Show();
            Cursor = Cursors.Arrow;
        }
    }
}
