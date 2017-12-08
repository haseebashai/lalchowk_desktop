﻿using System;
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
        BindingSource bsource, bsource2;
        string order, cost, atten;
        PictureBox loading = new PictureBox();

        private container hp = null;
        public mainform(Form hpcopy)
        {
            hp = hpcopy as container;
            InitializeComponent();

            loadingnormal();

            bgworker.RunWorkerAsync();

            BackgroundWorker bookreq = new BackgroundWorker();
            bookreq.DoWork += Bookreq_DoWork;
            bookreq.RunWorkerCompleted += Bookreq_RunWorkerCompleted;
            bookreq.RunWorkerAsync();

            //     loadingform();
        }

        private void Bookreq_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Object[] arg = e.Result as Object[];
            
            string count = (string)arg[0];
            string msg = (string)arg[1];
            if (count == "0")
            {
                rcountlbl.Visible = false;
            }else
            {
                rcountlbl.Text = count;
                rcountlbl.Visible = true;
            }

            if (msg == "0")
            {
                msglbl.Visible = false;
            }else
            {
                msglbl.Text = msg;
                msglbl.Visible = true;
            }
        }

        private void Bookreq_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                dr = obj.Query("select count(id) from bookrequests where processed ='0'");
                dr.Read();
                string count = dr[0].ToString();
            
                obj.closeConnection();
                dr = obj.Query("select count(messageid) from messages where messageid>60 and reply is null");
                dr.Read();
                string msg = dr[0].ToString();
             
                obj.closeConnection();

                object[] arg = { count, msg };
                e.Result = arg;

            }catch { obj.closeConnection(); }
        }

        /*    private void loadingform()
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

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    loading.Close();
                }
                finally {
                    loading.Close();
                }

            }*/

        private void mainform_Load(object sender, EventArgs e)
        {

            if (userinfo.loggedin == true)
                signout();
            changelabel("Welcome, " + userinfo.username + "");


        }
        BackgroundWorker bw;
        bool starterror=false;
        PictureBox refresh;
        Label refreshlbl;
        int placedcount, shippedcount;
        private void readorders()
        {
            
            try {
                con.Open();
                adap = new MySqlDataAdapter("select customer.mail,orders.* from lalchowk.orders inner join customer on customer.email=orders.email where status='placed';", con);
                dt = new DataTable();
                adap.Fill(dt);
                con.Close();
                bsource = new BindingSource();
                bsource.DataSource = dt;
                placedcount = dt.Rows.Count;


                con.Open();
                adap = new MySqlDataAdapter("select customer.mail,orders.* from lalchowk.orders inner join customer on customer.email=orders.email where status='shipped';", con);
                dt = new DataTable();
                adap.Fill(dt);
                con.Close();
                bsource2 = new BindingSource();
                bsource2.DataSource = dt;
                shippedcount=dt.Rows.Count;
               

                dr = obj.Query("Select count(status) from orders where status='placed'");
                dr.Read();
                atten = dr[0].ToString();
                obj.closeConnection();

                dr = obj.Query("select sum(dealerprice*quantity) from orderdetails where orderid in(SELECT orderid FROM orders where status = 'placed');");
                dr.Read();
                cost = dr[0].ToString();
                obj.closeConnection();


                dr = obj.Query("SELECT count(status) FROM orders where status='delivered'");
                dr.Read();
                order = dr[0].ToString();
                obj.closeConnection();

                starterror = false;


            }
            catch (Exception ex)
            {
               
                MessageBox.Show("Something happened.\nPlease check your internet connection and click Refresh.\n\n" , "Error!");
            
            starterror = true;

 
            }
        }
        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            refresh = new PictureBox()
            {
                Image = Properties.Resources.refresh,
                Size = new Size(80, 70),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Location = new Point(437, 212),
                Cursor = Cursors.Hand,
            };

            refresh.BringToFront();
            refresh.Click += Refresh_Click;
            refreshlbl = new Label()
            {
                ForeColor = SystemColors.Highlight,
                Font = new Font("MS Sans Seriff", 14, FontStyle.Regular),
                Text = "Refresh",
                Location = new Point(442, 289),
            };

        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
            cntpnl.Controls.Add(refresh);
            cntpnl.Controls.Add(refreshlbl);
        }

    private void Refresh_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            mainform mf = new mainform(hp);
            hp.mainpnl.Controls.Clear();
            mf.TopLevel = false;
            hp.mainpnl.Controls.Add(mf);
            mf.Show();
            Cursor = Cursors.Arrow;

        }

        private void ordersbtn_Click(object sender, EventArgs e)
        {

            if (cntpnl.Contains(placeddataview))
            {
                Cursor = Cursors.WaitCursor;
                orders or = new orders(hp,this);
                or.TopLevel = false;
                cntpnl.Controls.Clear();
                cntpnl.Visible = true;
                cntpnl.Controls.Add(or);
                or.loadingnormal();
                or.Show();
                Cursor = Cursors.Arrow;
            }
            else
            {
                dialogcontainer dg = new dialogcontainer();
                orders or = new orders(hp,dg);
                or.TopLevel = false;
                
                dg.dialogpnl.Controls.Add(or);
                or.loadingdg();
                dg.Text = "Orders";

                dg.Show();
                or.Show();
            }
        }
        public void changelabel(String welcome)
        {
        //    signinlbl.Text = welcome;

      //      signinlbl.Visible = true;

        }
        public void signout()
        {
         //   signoutlbl.Visible = true;
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
            if (cntpnl.Contains(placeddataview) )
            {
                Cursor = Cursors.WaitCursor;
                products pr = new products(hp, this,this);
                pr.TopLevel = false;
                cntpnl.Controls.Clear();
                cntpnl.Visible = true;
                cntpnl.Controls.Add(pr);
                pr.loadingnormal();
                pr.Show();
                Cursor = Cursors.Arrow;
            }
            else
            {
                dialogcontainer dg = new dialogcontainer();
                products pr  = new products(hp,this,dg);
                pr.TopLevel = false;
                
                dg.dialogpnl.Controls.Add(pr);
                pr.loadingdg();
                dg.Text = "Products";

                dg.Show();
                pr.Show();
            }
        }


        private void customersbtn_Click(object sender, EventArgs e)
        {
            if (cntpnl.Contains(placeddataview) )
            {
                Cursor = Cursors.WaitCursor;
                customers cus = new customers(hp,this);
                cus.TopLevel = false;
                cntpnl.Controls.Clear();
                cntpnl.Visible = true;
                cus.loadingnormal();
                cntpnl.Controls.Add(cus);
                cus.Show();
                Cursor = Cursors.Arrow;
            }
            else
            {
                dialogcontainer dg = new dialogcontainer();
                customers cus = new customers(hp,dg);
                cus.TopLevel = false;
                
                dg.dialogpnl.Controls.Add(cus);
                cus.loadingdg();
                dg.Text = "Customers";
                
                dg.Show();
                cus.Show();
            }
        }



        private void expbtn_Click(object sender, EventArgs e)
        {
            if (cntpnl.Contains(placeddataview))
            {
                Cursor = Cursors.WaitCursor;
                expenditure exp = new expenditure(this, hp,this);
                exp.TopLevel = false;
                cntpnl.Controls.Clear();
                cntpnl.Visible = true;
                cntpnl.Controls.Add(exp);
                exp.loadingnormal();
                exp.Show();
                Cursor = Cursors.Arrow;
            }
            else
            {
                dialogcontainer dg = new dialogcontainer();
                expenditure exp = new expenditure(this, hp,dg);
                exp.TopLevel = false;
                dg.Size = new Size(1000, 725);
                dg.Text = "Expenditure";
                dg.dialogpnl.Controls.Add(exp);
                exp.loadingdg();
                

                dg.Show();
                exp.Show();
            }
        }

        private void suppliersbtn_Click(object sender, EventArgs e)
        {
            if (cntpnl.Contains(placeddataview))
            {
                Cursor = Cursors.WaitCursor;
                suppliers sup = new suppliers(hp,this);
                sup.TopLevel = false;
                cntpnl.Controls.Clear();
                cntpnl.Visible = true;
                cntpnl.Controls.Add(sup);
                sup.loadingnormal();
                sup.Show();
                Cursor = Cursors.Arrow;
            }
            else
            {
                dialogcontainer dg = new dialogcontainer();
                suppliers sup = new suppliers(hp,dg);
                sup.TopLevel = false;
                sup.loadingdg();
                dg.dialogpnl.Controls.Add(sup);
                dg.Text = "Suppliers";

                dg.Show();
                sup.Show();
            }

        }

        private void chkbtn_Click(object sender, EventArgs e)
        {
            if (cntpnl.Contains(placeddataview))
            {
                Cursor = Cursors.WaitCursor;
                accounts acc = new accounts(hp,this);
                acc.TopLevel = false;
                cntpnl.Visible = true;
                cntpnl.Controls.Clear();
                cntpnl.Controls.Add(acc);
                acc.loadingnormal();
                
                acc.Show();
                Cursor = Cursors.Arrow;
            }
            else
            {
                dialogcontainer dg = new dialogcontainer();
                accounts acc = new accounts(hp,dg);
                acc.TopLevel = false;
                
                dg.dialogpnl.Controls.Add(acc);
                acc.loadingdg();
                dg.Text = "Accounts";
                
                dg.Show();
                acc.Show();
            }
        }

        private void approvebtn_Click(object sender, EventArgs e)
        {
            if (cntpnl.Contains(placeddataview))
            {
                Cursor = Cursors.WaitCursor;
                approveprice ap = new approveprice(hp,this);
                cntpnl.Controls.Clear();
                ap.TopLevel = false;
                cntpnl.Visible = true;
                cntpnl.Controls.Add(ap);
                ap.loadingnormal();
                ap.Show();
                Cursor = Cursors.Arrow;
            }
            else
            {
                dialogcontainer dg = new dialogcontainer();
                approveprice ap = new approveprice(hp,dg);
                ap.TopLevel = false;
                
                dg.dialogpnl.Controls.Add(ap);
                ap.loadingdg();
                dg.Text = "Review Price";

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
            ordersdetails od = new ordersdetails(hp,this);
            cntpnl.Controls.Clear();
            od.TopLevel = false;
            
            cntpnl.Controls.Add(od);
            od.loadingnormal();
            od.Show();
            od.bgworker1.RunWorkerAsync();
            Cursor = Cursors.Arrow;
        }

        private void placedlbl_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            ordersdetails od = new ordersdetails(hp,this);
            od.TopLevel = false;
            cntpnl.Controls.Clear();
            cntpnl.Controls.Add(od);
            od.Show();
            od.loadingnormal();
            od.bgworker.RunWorkerAsync();
            Cursor = Cursors.Arrow;
        }

        private void cobtn_Click(object sender, EventArgs e)
        {
            if (cntpnl.Contains(placeddataview))
            {
                Cursor = Cursors.WaitCursor;
                cancelorders co = new cancelorders(this);
                cntpnl.Controls.Clear();
                co.TopLevel = false;
                cntpnl.Controls.Add(co);
                co.loadingnormal();
                co.Show();
                Cursor = Cursors.Arrow;
            }
            else
            {
                dialogcontainer dg = new dialogcontainer();
                cancelorders co = new cancelorders(dg);
                co.TopLevel = false;
                
                dg.dialogpnl.Controls.Add(co);
                co.loadingdg();
                dg.Text = "Cancel Order";

                dg.Show();
                co.Show();
            }
        }

        private void msgbtn_Click(object sender, EventArgs e)
        {
            if (cntpnl.Contains(placeddataview))
            {
                Cursor = Cursors.WaitCursor;
                messages msg = new messages(this);
                cntpnl.Controls.Clear();
                msg.TopLevel = false;
                cntpnl.Visible = true;
                cntpnl.Controls.Add(msg);
                msg.loadingnormal();
                msg.Show();
                Cursor = Cursors.Arrow;
            }
            else
            {
                dialogcontainer dg = new dialogcontainer();
                messages msg = new messages(dg);
                msg.TopLevel = false;
                dg.Size = new Size(900, 735);
                dg.dialogpnl.Controls.Add(msg);
                msg.loadingdg();
                dg.Text = "User Messages";
                msg.msgpnl.Location = new Point(1, -20);
                dg.Show();
                msg.Show();
            }

        }

        private void homepagebtn_Click(object sender, EventArgs e)
        {
            if (cntpnl.Contains(placeddataview))
            {
                Cursor = Cursors.WaitCursor;
                apphomepage aph = new apphomepage(this);
                cntpnl.Controls.Clear();
                aph.TopLevel = false;
                cntpnl.Visible = true;
                cntpnl.Controls.Add(aph);
                aph.loadingnormal();
                aph.Show();
                Cursor = Cursors.Arrow;
            }
            else
            {
                dialogcontainer dg = new dialogcontainer();
                apphomepage aph = new apphomepage(dg);
                aph.TopLevel = false;
                
                dg.dialogpnl.Controls.Add(aph);
                aph.loadingdg();
                dg.dialogpnl.Location = new Point(0, -1);
                dg.dialogpnl.Size = new Size(1185, 698);
                
                dg.Text = "Edit Homepage";

                dg.Show();
                aph.Show();
            }
        }

        private void caboutbtn_Click(object sender, EventArgs e)
        {
            if (cntpnl.Contains(placeddataview))
            {
                Cursor = Cursors.WaitCursor;
                terms tr = new terms(hp,this);
                tr.TopLevel = false;
                cntpnl.Controls.Clear();
                cntpnl.Visible = true;
                cntpnl.Controls.Add(tr);
                tr.loadingnormal();
                
                tr.Show();
                Cursor = Cursors.Arrow;
            }
            else
            {
                dialogcontainer dg = new dialogcontainer();
                terms tr = new terms(hp,dg);
                tr.TopLevel = false;
                dg.Size = new Size(900, 715);
                dg.dialogpnl.Controls.Add(tr);
                tr.loadingdg();
                dg.Text = "Policies";
                
               
                dg.Show();
                tr.Show();
            }
        }

        private void clientbtn_Click(object sender, EventArgs e)
        {
            if (cntpnl.Contains(placeddataview))
            {

                lifeclicks_account la = new lifeclicks_account(this);
                la.TopLevel = false;
                cntpnl.Controls.Clear();
                cntpnl.Visible = true;
                cntpnl.Controls.Add(la);
                la.loadingnormal();

                la.Show();
                
            }
            else
            {
                dialogcontainer dg = new dialogcontainer();
                lifeclicks_account la = new lifeclicks_account(dg);
                la.TopLevel = false;
                dg.dialogpnl.Controls.Add(la);
                la.loadingdg();
                dg.Text = "Client Accounts";


                dg.Show();
                la.Show();
            }
        }

        private void shippedlbl_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            ordersdetails od = new ordersdetails(hp,this);
            od.TopLevel = false;
            cntpnl.Controls.Clear();
            od.orderslbl.Text = "Orders Shipped";
            
            cntpnl.Controls.Add(od);
            od.loadingnormal();
            od.Show();
            od.bgworker2.RunWorkerAsync();
            Cursor = Cursors.Arrow;


        }


        

        private void sendmailbtn_Click(object sender, EventArgs e)
        {
            
            Cursor = Cursors.WaitCursor;
            dialogcontainer dg = new dialogcontainer();
            promomail pm = new promomail("",dg);
            pm.TopLevel = false;
            
            pm.emaillistpnl.Visible=true;

            dg.Size = new Size(1000, 732);
            dg.dialogpnl.Controls.Add(pm);
            pm.loadingdg();
            
            dg.Text = "Send Email";

            dg.Show();

            pm.Show();
            Cursor = Cursors.Arrow;
        }

        private void categorybtn_Click(object sender, EventArgs e)
        {
            if (cntpnl.Contains(placeddataview))
            {

                addcategories ac = new addcategories(this);
                ac.TopLevel = false;
                cntpnl.Controls.Clear();
                cntpnl.Visible = true;
                cntpnl.Controls.Add(ac);
                ac.loadingnormal();

                ac.Show();

            }
            else
            {
                dialogcontainer dg = new dialogcontainer();
                addcategories ac = new addcategories(dg);
                ac.TopLevel = false;
                dg.dialogpnl.Controls.Add(ac);
                ac.loadingdg();
                dg.Text = "Categories";


                dg.Show();
                ac.Show();
            }
        }

        private void totalordersdel_Click(object sender, EventArgs e)
        {
           
            Cursor = Cursors.WaitCursor;
            ordersdetails od = new ordersdetails(hp, this);
            cntpnl.Controls.Clear();
            od.TopLevel = false;
            cntpnl.Controls.Add(od);
            od.loadingnormal();
            cntpnl.Visible = true;        
            od.Show();
           
            od.bgworker1.RunWorkerAsync();
            Cursor = Cursors.Arrow;
        }

        private void smsbtn_Click(object sender, EventArgs e)
        {
            dialogcontainer dg = new dialogcontainer();
           sendsms sms = new sendsms();
            sms.TopLevel = false;
            dg.dialogpnl.Controls.Add(sms);
            dg.lbl.Text="Send SMS";
            dg.Text = "Send SMS";
            dg.Size = new Size(800, 600);

            dg.Show();
            sms.Show();
        }

      
        private void settingsbtn_Click(object sender, EventArgs e)
        {
            if (cntpnl.Contains(placeddataview))
            {

                Settings st = new Settings(this);
                st.TopLevel = false;
                cntpnl.Controls.Clear();
                cntpnl.Visible = true;
                cntpnl.Controls.Add(st);
                st.loadingnormal();

                st.Show();

            }
            else
            {
                dialogcontainer dg = new dialogcontainer();
                Settings st = new Settings(dg);
                st.TopLevel = false;
                dg.dialogpnl.Controls.Add(st);
                st.loadingdg();
                dg.Text = "OTP/Pincodes";


                dg.Show();
                st.Show();
            }
        }

        private void bookbtn_Click(object sender, EventArgs e)
        {
            dialogcontainer dg = new dialogcontainer();
            dg.Size = new Size(860, 650);
            books bk = new books(dg);
            bk.TopLevel = false;
            dg.dialogpnl.Controls.Add(bk);
            bk.loadingdg();
            dg.Text = "Book Requests";


            dg.Show();
            bk.Show();
            rcountlbl.Visible = false;
        }

        public void loadingnormal()
        {
            
            loadinglbl.Visible = true;
            loadingpic.Visible = true;
            loading = new PictureBox()
            {
                Image = Properties.Resources.loading,
                Size = new Size(400, 300),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Location = new Point(400, 700),
            };
            this.Controls.Add(loading);
            loadinglbl.SendToBack();
        }

        private void bgworker_DoWork(object sender, DoWorkEventArgs e)
        {
            readorders();
        }

        private void bgworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (shippedcount == 0 && placedcount == 0 && starterror==false)
            {

                zeropnl.Visible = true;
               
            }
            else
            {
                if (starterror)
                {


                    placedh.Visible = false;
                    placeddataview.Visible = false;
                    shippedh.Visible = false;
                    shippedlbl.Visible = false;
                    attention.Visible = false; placedlbl.Visible = false; deliveredh.Visible = false; orderslbl.Visible = false;
                    shippeddataview.Visible = false;
                    loadingpic.Visible = false;
                    loadinglbl.Visible = false;

                    bw = new BackgroundWorker();
                    bw.DoWork += new DoWorkEventHandler(bw_DoWork);
                    bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
                    bw.RunWorkerAsync();
                }


                else
                {


                    loadingpic.Visible = false;
                    loadinglbl.Visible = false;
                    placedh.Visible = true;
                    shippedh.Visible = true;
                    shippedlbl.Visible = true;
                    attention.Visible = true; placedlbl.Visible = true; deliveredh.Visible = true; orderslbl.Visible = true;

                    placeddataview.DataSource = bsource;
                    shippeddataview.DataSource = bsource2;
                    placeddataview.Visible = true;
                    shippeddataview.Visible = true;
                    attentionlbl.Text = "> " + atten + " Order(s) need your Attention ASAP!";
                    costlbl.Text = "> Will cost Rs. " + cost + "/-";
                    ordersdlbl.Text = order;
                }

            }          
       }
        private void homelbl_Click(object sender, EventArgs e)
        {
            zeropnl.Visible = false;

            loadingpic.Visible = false;
            loadinglbl.Visible = false;
            placedh.Visible = true;
            shippedh.Visible = true;
            shippedlbl.Visible = true;
            attention.Visible = true; placedlbl.Visible = true; deliveredh.Visible = true; orderslbl.Visible = true;

            placeddataview.DataSource = bsource;
            shippeddataview.DataSource = bsource2;
            placeddataview.Visible = true;
            shippeddataview.Visible = true;
            attentionlbl.Text = "> " + atten + " Order(s) need your Attention ASAP!";
            int cst = int.Parse(atten);
            if (cst == 0)
            {
                costlbl.Text = "";
            }else
            costlbl.Text = "> Will cost Rs. " + cost + "/-";
            ordersdlbl.Text = order;
        }
    }
}
