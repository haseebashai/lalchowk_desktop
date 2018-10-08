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
        MySqlConnection aconn = new MySqlConnection("SERVER=182.50.133.78;DATABASE=lalchowk_ac;USER=lalchowkac;PASSWORD=Lalchowk@123uzmah");
        MySqlDataAdapter adap;
        DataTable dt;
        MySqlDataReader dr;
        BindingSource bsource, bsource2;
        string order, cost, atten, billno;
        PictureBox loading = new PictureBox();
        BackgroundWorker bills;
        MySqlCommand cmd;

        private container hp = null;
        public mainform(Form hpcopy)
        {
            hp = hpcopy as container;
            InitializeComponent();

            loadingnormal();

            bgworker.RunWorkerAsync();
            


            //     loadingform();
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
            pageload.Visible = true;
          
    }

        BackgroundWorker bw;
        bool starterror = false;
        PictureBox refresh;
        Label refreshlbl;
        int placedcount, shippedcount;

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            refresh = new PictureBox()
            {
                Image = Properties.Resources.refresh,
                Size = new Size(80, 70),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Location = new Point(480, 220),
                Cursor = Cursors.Hand,
            };

            refresh.BringToFront();
            refresh.Click += Refresh_Click;
            refreshlbl = new Label()
            {
                ForeColor = SystemColors.Highlight,
                Font = new Font("MS Sans Seriff", 14, FontStyle.Regular),
                Text = "Refresh",
                Location = new Point(485, 297),
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
                orders or = new orders(hp, this);
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
                orders or = new orders(hp, dg);
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

            loginform lg = new loginform(hp, this);
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
                products pr = new products(hp, this, this);
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
                products pr = new products(hp, this, dg);
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
            if (cntpnl.Contains(placeddataview))
            {
                Cursor = Cursors.WaitCursor;
                customers cus = new customers(hp, this);
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
                customers cus = new customers(hp, dg);
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
                expenditure exp = new expenditure(this, hp, this);
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
                expenditure exp = new expenditure(this, hp, dg);
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
                suppliers sup = new suppliers(hp, this);
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
                suppliers sup = new suppliers(hp, dg);
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
                accounts acc = new accounts(hp, this);
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
                accounts acc = new accounts(hp, dg);
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
            //if (cntpnl.Contains(placeddataview))
            //{
            //    Cursor = Cursors.WaitCursor;
            //    approveprice ap = new approveprice(hp, this);
            //    cntpnl.Controls.Clear();
            //    ap.TopLevel = false;
            //    cntpnl.Visible = true;
            //    cntpnl.Controls.Add(ap);
            //    ap.loadingnormal();
            //    ap.Show();
            //    Cursor = Cursors.Arrow;
            //}
            //else
            //{
            //    dialogcontainer dg = new dialogcontainer();
            //    approveprice ap = new approveprice(hp, dg);
            //    ap.TopLevel = false;

            //    dg.dialogpnl.Controls.Add(ap);
            //    ap.loadingdg();
            //    dg.Text = "Review Price";

            //    dg.Show();
            //    ap.Show();
            //}
        }


        public void navtxt_Click(object sender, EventArgs e)
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
            ordersdetails od = new ordersdetails(hp, this);
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
            ordersdetails od = new ordersdetails(hp, this);
            od.TopLevel = false;
            cntpnl.Controls.Clear();
            cntpnl.Controls.Add(od);
            od.Show();
            od.loadingnormal();
            od.bgworker.RunWorkerAsync();
            Cursor = Cursors.Arrow;
        }

        //private void cobtn_Click(object sender, EventArgs e)
        //{
        //    if (cntpnl.Contains(placeddataview))
        //    {
        //        Cursor = Cursors.WaitCursor;
        //        cancelorders co = new cancelorders(this);
        //        cntpnl.Controls.Clear();
        //        co.TopLevel = false;
        //        cntpnl.Controls.Add(co);
        //        co.loadingnormal();
        //        co.Show();
        //        Cursor = Cursors.Arrow;
        //    }
        //    else
        //    {
        //        dialogcontainer dg = new dialogcontainer();
        //        cancelorders co = new cancelorders(dg);
        //        co.TopLevel = false;

        //        dg.dialogpnl.Controls.Add(co);
        //        co.loadingdg();
        //        dg.Text = "Cancel Order";

        //        dg.Show();
        //        co.Show();
        //    }
        //}

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
            msglbl.Visible = false;

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
            //if (cntpnl.Contains(placeddataview))
            //{
            //    Cursor = Cursors.WaitCursor;
            //    terms tr = new terms(hp, this);
            //    tr.TopLevel = false;
            //    cntpnl.Controls.Clear();
            //    cntpnl.Visible = true;
            //    cntpnl.Controls.Add(tr);
            //    tr.loadingnormal();

            //    tr.Show();
            //    Cursor = Cursors.Arrow;
            //}
            //else
            //{
            //    dialogcontainer dg = new dialogcontainer();
            //    terms tr = new terms(hp, dg);
            //    tr.TopLevel = false;
            //    dg.Size = new Size(900, 715);
            //    dg.dialogpnl.Controls.Add(tr);
            //    tr.loadingdg();
            //    dg.Text = "Policies";


            //    dg.Show();
            //    tr.Show();
            //}
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
            ordersdetails od = new ordersdetails(hp, this);
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
            promomail pm = new promomail("", dg);
            pm.TopLevel = false;

            pm.emaillistpnl.Visible = true;

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
            sendsms sms = new sendsms("","","");
            sms.TopLevel = false;
            dg.dialogpnl.Controls.Add(sms);
            dg.lbl.Text = "Send SMS";
            dg.Text = "Send SMS";
            dg.Size = new Size(800, 600);
            sms.feedbtn.Visible = false;
            sms.stbtn.Visible = false;
            sms.btbtn.Visible = false;

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
            dg.Size = new Size(860, 700);
            books bk = new books(dg);
            bk.TopLevel = false;
            dg.dialogpnl.Controls.Add(bk);
            bk.loadingdg();
            dg.Text = "Book Requests";


            dg.Show();
            bk.Show();
            rcountlbl.Visible = false;
        }

        private void addorderbtn_Click(object sender, EventArgs e)
        {
          
            dialogcontainer dg = new dialogcontainer();
            dg.Size = new Size(950, 700);
            addorder ao= new addorder(dg,"");
            ao.TopLevel = false;
            dg.dialogpnl.Controls.Add(ao);
            ao.loadingdg();
            dg.Text = "Add new order";


            dg.Show();
            ao.Show();
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

        BackgroundWorker products;
        string id,contact,name,email,encmail;
        private void placeddataview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >-1)
            {
                plbl.Visible = true;
                shipbtn.Visible = false;
                sendsmsbtn.Visible = false;
                cancelbtn.Visible = false;
                ppnl.Controls.Clear();
                placeddataview.Enabled = false;

                DataGridViewRow row = this.placeddataview.Rows[e.RowIndex];
                id = row.Cells["orderid"].Value.ToString();
                contact = row.Cells["contact"].Value.ToString();
                status = row.Cells["status"].Value.ToString();
                name= row.Cells["name"].Value.ToString();
                email= row.Cells["mail"].Value.ToString();
                encmail= row.Cells["email"].Value.ToString();
                //quantity= row.Cells["quantity"].Value.ToString();
                products = new BackgroundWorker();
                products.DoWork += Products_DoWork;
                products.RunWorkerCompleted += Products_RunWorkerCompleted;
                products.WorkerSupportsCancellation = true;
                if (products.IsBusy)
                    products.CancelAsync();
                else if ( !products.CancellationPending)
                products.RunWorkerAsync(id);
            }
        }

        private void Products_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            placeddataview.Enabled = true;
            shippeddataview.Enabled = true;
            if (!e.Cancelled)
            {
                List<details> dobj = (List<details>)e.Result;

                foreach (var details in dobj)
                {

                    TextBox t1 = new TextBox()
                    {
                        Size = new Size(230, 115),
                        Text = "ID: " + details.Pid + "\r\n" + "Name: " + details.Pname + "\r\n"
                        + "Publisher: "+details.Publisher+ "\r\n"+ "Price: " + details.Price + "\r\n" + "Quantity: " + details.Quantity + "\r\n"
                        + "Dealer Price: " + details.Dp,
                        Multiline = true,
                        BorderStyle = BorderStyle.None,
                        ReadOnly = true,
                        BackColor = Color.White,
                        ForeColor = SystemColors.Highlight,
                        Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular),
                    };
                    PictureBox p1 = new PictureBox()
                    {
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        ImageLocation = "https://lalchowk.in/lalchowk/pictures/" + details.Picture,
                        Size = new Size(100, 115),
                    };

                    ppnl.Controls.Add(p1);
                    ppnl.Controls.Add(t1);
                }
              
                if (status == "Placed")
                {
                    shipbtn.Visible = true;
                }else if (status == "Shipped")
                {
                    shipbtn.Visible = false;
                }
                ppnl.Visible = true;
                plbl.Visible = false;
               
                sendsmsbtn.Visible = true;
                cancelbtn.Visible = true;
            }
        }

        private void shipbtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                DialogResult dgr = MessageBox.Show("Change status to Shipped for orderid '" + id + "'", "Confirm!", MessageBoxButtons.YesNo);
                if (dgr == DialogResult.Yes)
                {
                    string cmd = "Update orders set status='Shipped' where orderid='" + id + "'";
                    obj.nonQuery(cmd);

                    DialogResult ntf = MessageBox.Show("Do you want to send the in-app notification ?", "Confirm!", MessageBoxButtons.YesNo);
                    if (ntf == DialogResult.Yes)
                        {
                        notification nf = new notification(encmail, email,id);
                        nf.loadingnormal();
                        nf.Show();


                    }                             
                                
                                
                  

                    con.Open();

                    adap = new MySqlDataAdapter("select customer.mail,orders.* from lalchowk.orders inner join customer on customer.email=orders.email where status='placed';", con);
                    dt = new DataTable();
                    adap.Fill(dt);
                    con.Close();
                    bsource = new BindingSource();
                    bsource.DataSource = dt;
                    placeddataview.DataSource = bsource;
                    placeddataview.Columns["shipdate"].Visible = false;
                    placeddataview.Columns["deliverdate"].Visible = false;
                    placeddataview.Columns["paymentconfirmed"].Visible = false;
                    placeddataview.Columns["email"].Visible = false;
                    placeddataview.Columns["transanctionid"].Visible = false;
                    placeddataview.Columns["paymenttype"].Visible = false;

                    con.Open();
                    adap = new MySqlDataAdapter("select customer.mail,orders.* from lalchowk.orders inner join customer on customer.email=orders.email where status='shipped';", con);
                    dt = new DataTable();
                    adap.Fill(dt);
                    con.Close();
                    bsource2 = new BindingSource();
                    bsource2.DataSource = dt;
                    shippeddataview.DataSource = bsource2;
                   
                    try { 
                    shippeddataview.Columns["shipdate"].Visible = false;
                    shippeddataview.Columns["deliverdate"].Visible = false;
                    shippeddataview.Columns["paymentconfirmed"].Visible = false;
                    shippeddataview.Columns["email"].Visible = false;
                    shippeddataview.Columns["transanctionid"].Visible = false;
                    shippeddataview.Columns["paymenttype"].Visible = false;
                    }
                    catch { }
                    shippeddataview.Visible = true;
                    ppnl.Visible = false;
                    shipbtn.Visible = false;
                    sendsmsbtn.Visible = false;
                    cancelbtn.Visible = false;
                    shippedh.Visible = true;
                  //  shippedlbl.Visible = true;




                }
            }
            catch
            {
                obj.closeConnection();
            }
            Cursor = Cursors.Arrow;
        }

        private void sendsmsbtn_Click(object sender, EventArgs e)
        {
            dialogcontainer dg = new dialogcontainer();
            sendsms sms = new sendsms(contact,"",name);
            sms.TopLevel = false;
            dg.dialogpnl.Controls.Add(sms);
            dg.lbl.Text = "Send SMS";
            dg.Text = "Send SMS";
            dg.Size = new Size(600, 600);
            sms.numbertxt.Font = new Font("MS Sans Serif", 9, FontStyle.Regular);
            sms.smstxt.Text="Dear "+ name+", ";
            sms.smsnpnl.Visible = false;
            sms.txtpnl.Location = new Point(35, 10);
            dg.Show();
            sms.Show();
        }
        private void cancelbtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                DialogResult dgr = MessageBox.Show("Press YES to cancel order '" + id + "' and update stock\nPress NO to cancel order without updating stock", "Confirm!", MessageBoxButtons.YesNoCancel);
                if (dgr == DialogResult.Yes)
                {
                    string cmd = "Update orders set status='Cancelled' where orderid='" + id + "'";
                    obj.nonQuery(cmd);
                   
                    foreach (string products in pid)
                    {
                       
                        cmd = "Update products set stock=stock+1 where productid ='" + products + "'";
                        obj.nonQuery(cmd);
                    }
                    MessageBox.Show("Order cancelled.");
                    ppnl.Visible = false;
                
                adap = new MySqlDataAdapter("select customer.mail,orders.* from lalchowk.orders inner join customer on customer.email=orders.email where status='placed';", con);
                dt = new DataTable();
                adap.Fill(dt);
                con.Close();
                bsource = new BindingSource();
                bsource.DataSource = dt;
                placeddataview.DataSource = bsource;
                try {
                    shipbtn.Visible = false;
                    sendsmsbtn.Visible = false;
                    cancelbtn.Visible = false;
                placeddataview.Columns["shipdate"].Visible = false;
                placeddataview.Columns["deliverdate"].Visible = false;
                placeddataview.Columns["paymentconfirmed"].Visible = false;
                placeddataview.Columns["email"].Visible = false;
                placeddataview.Columns["transanctionid"].Visible = false;
                placeddataview.Columns["paymenttype"].Visible = false;

                }
                catch { }
                }
                else if (dgr == DialogResult.No)
                {
                    string cmd = "Update orders set status='Cancelled' where orderid='" + id + "'";
                    obj.nonQuery(cmd);

                    MessageBox.Show("Order cancelled.");
                    ppnl.Visible = false;

                    adap = new MySqlDataAdapter("select customer.mail,orders.* from lalchowk.orders inner join customer on customer.email=orders.email where status='placed';", con);
                    dt = new DataTable();
                    adap.Fill(dt);
                    con.Close();
                    bsource = new BindingSource();
                    bsource.DataSource = dt;
                    placeddataview.DataSource = bsource;
                    try
                    {
                        shipbtn.Visible = false;
                        sendsmsbtn.Visible = false;
                        cancelbtn.Visible = false;
                        placeddataview.Columns["shipdate"].Visible = false;
                        placeddataview.Columns["deliverdate"].Visible = false;
                        placeddataview.Columns["paymentconfirmed"].Visible = false;
                        placeddataview.Columns["email"].Visible = false;
                        placeddataview.Columns["transanctionid"].Visible = false;
                        placeddataview.Columns["paymenttype"].Visible = false;

                    }
                    catch { }

                }
            }
            catch (Exception ex)
            {
                obj.closeConnection();
                MessageBox.Show( ex.Message, "Error!");
            }
            Cursor = Cursors.Arrow;
        }

        List<string> prds = new List<string>();
        string status;
        private void shippeddataview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

            if (e.RowIndex >=0)
            {
                plbl.Visible = true;
                shipbtn.Visible = false;
                sendsmsbtn.Visible = false;
                cancelbtn.Visible = false;
                ppnl.Controls.Clear();
                shippeddataview.Enabled = false;

                DataGridViewRow row = this.shippeddataview.Rows[e.RowIndex];
                id = row.Cells["orderid"].Value.ToString();
                contact = row.Cells["contact"].Value.ToString();
                status= row.Cells["status"].Value.ToString();
                name = row.Cells["name"].Value.ToString();
                products = new BackgroundWorker();
                products.DoWork += Products_DoWork;
                products.RunWorkerCompleted += Products_RunWorkerCompleted;
                products.WorkerSupportsCancellation = true;
                if (products.IsBusy)
                    products.CancelAsync();
                else if (!products.CancellationPending)
                    products.RunWorkerAsync(id);
            }
        }

        private void shippeddataview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.shippeddataview.Rows[e.RowIndex];
                    id = row.Cells["orderid"].Value.ToString();
                    int amount= int.Parse(row.Cells["amount"].Value.ToString());
                    int shipping = int.Parse(row.Cells["shipping"].Value.ToString());
                    int result= int.Parse(retolbl.Text) + (amount + shipping);
                    retolbl.Text = result.ToString();

                    totallbl.Visible = true;
                    retolbl.Visible = true;
                    clearlbl.Visible = true;


                }
            }catch { }
         }

        private void clearlbl_Click(object sender, EventArgs e)
        {
            retolbl.Text = "0";
            totallbl.Visible = false;
            retolbl.Visible = false;
            clearlbl.Visible = false;

        }

        private void cartbtn_Click(object sender, EventArgs e)
        {
            dialogcontainer dg = new dialogcontainer();
            cartitems cart = new cartitems(dg);
            cart.TopLevel = false;
            dg.dialogpnl.Controls.Add(cart);
            cart.loadingdg();
            dg.lbl.Text = "Loading";
            dg.Text = "Cart Items";
            dg.Size = new Size(830, 720);

            dg.Show();
            cart.Show();
        }

        private void usedbookbtn_Click(object sender, EventArgs e)
        {
            //if (cntpnl.Contains(placeddataview))
            //{
                Cursor = Cursors.WaitCursor;
                usedbook usb=new usedbook(hp);
                cntpnl.Controls.Clear();
                usb.TopLevel = false;
                cntpnl.Visible = true;
                cntpnl.Controls.Add(usb);
                 usb.loadingnormal();
                usb.Show();
            sellreqlbl.Visible = false;
            Cursor = Cursors.Arrow;
         //   }
            //else
            //{
            //    dialogcontainer dg = new dialogcontainer();
            //    usedbook usb = new usedbook(dg);
            //    usb.TopLevel = false;

            //    dg.dialogpnl.Controls.Add(usb);
            //   // usb.loadingdg();
            //    dg.Text = "Review Price";

            //    dg.Show();
            //    usb.Show();
            //}
        }

        private void blogbtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            blog blog = new blog();
            cntpnl.Controls.Clear();
            blog.TopLevel = false;
            cntpnl.Visible = true;
            cntpnl.Controls.Add(blog);
            blog.loadingnormal();
            blog.Show();
            Cursor = Cursors.Arrow;
        }

        List<string> pid = new List<string>();
        private void Products_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                
                    string id = e.Argument as string;
                    List<details> dobj = new List<details>();
                   

                    dr = obj.Query("select productid from orderdetails where orderid ='" + id + "'");
                    while (dr.Read())
                    {
                        prds.Add(dr[0].ToString());
                        pid.Add(dr[0].ToString());
                    }
                    obj.closeConnection();

               
                foreach (String products in prds)
                    {

                        dr = obj.Query("select orderdetails.productid,orderdetails.productname,orderdetails.price,orderdetails.quantity,orderdetails.dealerprice,orderdetails.picture,products.detail2 from orderdetails inner join products on (orderdetails.productid="+products+" and products.productid="+products+") and orderdetails.orderid="+id+"");
                        dr.Read();

                        string pid = dr[0].ToString();
                        string  pname = dr[1].ToString();
                        string price = dr[2].ToString();
                        string quantity = dr[3].ToString();
                        string dp = dr[4].ToString();
                        string pic = dr[5].ToString();
                        string pub = dr[6].ToString();

                        obj.closeConnection();
                        dobj.Add(new details(pid, pname, price, quantity, dp, pic,pub));


                    }
                    prds.Clear();
                    e.Result = dobj;

                }catch(Exception ex)
            {
                obj.closeConnection();
                MessageBox.Show(ex.Message);
            }
        }




        private void bgworker_DoWork(object sender, DoWorkEventArgs e)
        {
            
            try
            {
                dr = obj.Query("select count(id) from bookrequests where processed ='0'");
                dr.Read();
                string count = dr[0].ToString();
                obj.closeConnection();

                bgworker.ReportProgress(20);

                dr = obj.Query("select count(messageid) from messages where messageid>60 and reply is null");
                dr.Read();
                string msg = dr[0].ToString();
                obj.closeConnection();

                dr = obj.Query("select count(id) from sellbookrequests where processed ='0'");
                dr.Read();
                string scount = dr[0].ToString();
                obj.closeConnection();



                object[] arg = { count, msg,scount };
                bgworker.ReportProgress(40,arg);

              

             
                    con.Open();
                    adap = new MySqlDataAdapter("select customer.mail,orders.* from lalchowk.orders inner join customer on customer.email=orders.email where status='placed';", con);
                    dt = new DataTable();
                    adap.Fill(dt);
                    con.Close();
                    bsource = new BindingSource();
                    bsource.DataSource = dt;
                    placedcount = dt.Rows.Count;
                    bgworker.ReportProgress(50);

                    con.Open();
                    adap = new MySqlDataAdapter("select customer.mail,orders.* from lalchowk.orders inner join customer on customer.email=orders.email where status='shipped';", con);
                    dt = new DataTable();
                    adap.Fill(dt);
                    con.Close();
                    bsource2 = new BindingSource();
                    bsource2.DataSource = dt;
                    shippedcount = dt.Rows.Count;
                    bgworker.ReportProgress(60);

                    dr = obj.Query("Select count(status) from orders where status='placed'");
                    dr.Read();
                    atten = dr[0].ToString();
                    obj.closeConnection();
                    bgworker.ReportProgress(80);

                    dr = obj.Query("select sum(dealerprice*quantity) from orderdetails where orderid in(SELECT orderid FROM orders where status = 'placed');");
                    dr.Read();
                    cost = dr[0].ToString();
                    obj.closeConnection();
                    

                    dr = obj.Query("SELECT count(status) FROM orders where status='delivered'");
                    dr.Read();
                    order = dr[0].ToString();
                    obj.closeConnection();
                bgworker.ReportProgress(100);

                aconn.Open();
                cmd = new MySqlCommand("select count(did) from deliveries where status='delivered'", aconn);
                dr = cmd.ExecuteReader();
                dr.Read();
                billno = dr[0].ToString();
                aconn.Close();

                

                starterror = false;


                }
                catch (Exception ex)
                {
                    obj.closeConnection(); con.Close();
                    MessageBox.Show("Something happened.\nPlease check your internet connection and click Refresh.\n\n", "Error!");

                    starterror = true;


                }
               
        }

        private void bgworker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            placeddataview.Enabled = false;
            pageload.Value = e.ProgressPercentage;
            if (e.ProgressPercentage == 50)
            {
                loadingpic.Visible = false;
                loadinglbl.Visible = false;
               
                placedh.Visible = true;

                placeddataview.DataSource = bsource;
                try
                {
                    foreach (DataGridViewRow row in this.placeddataview.Rows)
                    {
                        int count = Convert.ToInt32(row.Cells["itemcount"].Value);
                       
                            if (count > 1)
                            {
                                placeddataview.Columns["itemcount"].DefaultCellStyle.Font = new Font(placeddataview.DefaultCellStyle.Font, FontStyle.Bold);
                            }
                        
                    }
                    placeddataview.Columns["shipdate"].Visible = false;
                    placeddataview.Columns["deliverdate"].Visible = false;
                    placeddataview.Columns["paymentconfirmed"].Visible = false;
                    placeddataview.Columns["email"].Visible = false;
                    placeddataview.Columns["transanctionid"].Visible = false;
                    placeddataview.Columns["paymenttype"].Visible = false;
                }
                catch { }
                placeddataview.Visible = true;
            }

            Object[] arg = (object[])e.UserState;
            if (arg == null) { }
            else
            {

                string count = (string)arg[0];
                string msg = (string)arg[1];
                string scount = (string)arg[2];
                if (count == "0")
                {
                    rcountlbl.Visible = false;
                }
                else
                {
                    rcountlbl.Text = count;
                    rcountlbl.Visible = true;
                }

                if (msg == "0")
                {
                    msglbl.Visible = false;
                }
                else
                {
                    msglbl.Text = msg;
                    msglbl.Visible = true;
                }
                if (scount == "0")
                {
                    sellreqlbl.Visible = false;
                }
                else
                {
                    sellreqlbl.Text = scount;
                    sellreqlbl.Visible = true;
                }

            }
        }


        private void bgworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pageload.Value = 100;
            
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
                   // shippedlbl.Visible = false;
                   /* attention.Visible = false; placedlbl.Visible = false;*/ deliveredh.Visible = false; //orderslbl.Visible = false;
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
                    pageload.Visible = false;
                    placedh.Visible = true;
                  /*  attention.Visible = true; placedlbl.Visible = true; */deliveredh.Visible = true; billsh.Visible = true; //orderslbl.Visible = true; 

                    placeddataview.DataSource = bsource;
                    try
                    {
                        placeddataview.Columns["shipdate"].Visible = false;
                        placeddataview.Columns["deliverdate"].Visible = false;
                        placeddataview.Columns["paymentconfirmed"].Visible = false;
                        placeddataview.Columns["email"].Visible = false;
                        placeddataview.Columns["transanctionid"].Visible = false;
                        placeddataview.Columns["paymenttype"].Visible = false;
                        shippeddataview.DataSource = bsource2;
                        shippeddataview.Columns["shipdate"].Visible = false;
                        shippeddataview.Columns["deliverdate"].Visible = false;
                        shippeddataview.Columns["paymentconfirmed"].Visible = false;
                        shippeddataview.Columns["email"].Visible = false;
                        shippeddataview.Columns["transanctionid"].Visible = false;
                        shippeddataview.Columns["paymenttype"].Visible = false;
                    }catch { }
                    placeddataview.Visible = true;
                    placeddataview.Enabled = true;
                    if (shippedcount == 0)
                    {
                        shippeddataview.Visible = false;
                        shippedh.Visible = false;
                       // shippedlbl.Visible = false;
                    }
                    else
                    {
                        shippeddataview.Visible = true;
                        shippedh.Visible = true;
                     //   shippedlbl.Visible = true;
                    }

                    //attentionlbl.Text = "> " + atten + " Order(s) need your Attention ASAP!";
                    //costlbl.Text = "> Will cost Rs. " + cost + "/-";
                    if (int.Parse(order) != int.Parse(billno))
                    {
                        ordersdlbl.ForeColor = Color.Red;
                        billslbl.ForeColor = Color.Red;
                        billmismatchlbl.Visible = true;
                        billmismatchlbl.Text = "Please add the bills for remaining orders.";
                    }
                    ordersdlbl.Text = order;
                    billslbl.Text = billno;
                }

            }          
       }
        private void homelbl_Click(object sender, EventArgs e)
        {
            zeropnl.Visible = false;

            loadingpic.Visible = false;
            loadinglbl.Visible = false;
            pageload.Visible = false;
            placedh.Visible = true;
            shippedh.Visible = true;
          //  shippedlbl.Visible = true;
           /* attention.Visible = true; placedlbl.Visible = true;*/ deliveredh.Visible = true; billsh.Visible = true; //orderslbl.Visible = true; 

            placeddataview.DataSource = bsource;
            try { 
            placeddataview.Columns["shipdate"].Visible = false;
            placeddataview.Columns["deliverdate"].Visible = false;
            placeddataview.Columns["paymentconfirmed"].Visible = false;
            placeddataview.Columns["email"].Visible = false;
            placeddataview.Columns["transanctionid"].Visible = false;
            placeddataview.Columns["paymenttype"].Visible = false;
            }
            catch { }

            shippeddataview.DataSource = bsource2;
            try { 
            shippeddataview.Columns["shipdate"].Visible = false;
            shippeddataview.Columns["deliverdate"].Visible = false;
            shippeddataview.Columns["paymentconfirmed"].Visible = false;
            shippeddataview.Columns["email"].Visible = false;
            shippeddataview.Columns["transanctionid"].Visible = false;
            shippeddataview.Columns["paymenttype"].Visible = false;
            }
            catch { }
            placeddataview.Visible = true;
            shippeddataview.Visible = true;
            //attentionlbl.Text = "> " + atten + " Order(s) need your Attention ASAP!";
            //int cst = int.Parse(atten);
            //if (cst == 0)
            //{
            //    costlbl.Text = "";
            //}else
            //costlbl.Text = "> Will cost Rs. " + cost + "/-";
            if (int.Parse(order) != int.Parse(billno))
            {
                ordersdlbl.ForeColor = Color.Red;
                billslbl.ForeColor = Color.Red;
                billmismatchlbl.Visible = true;
                billmismatchlbl.Text = "Please add the bills for remaining orders.";
            }
            ordersdlbl.Text = order;
            billslbl.Text = billno;
        }
    }

    public class details
    {
        private string pid;
        private string pname;
        private string price;
        private string quantity;
        private string dp;
        private string picture;
        private string publisher;

        public details(string pid, string pname, string price, string quantity, string dp,string picture,string publisher)
        {
            this.pid = pid;
            this.pname = pname;
            this.price = price;
            this.quantity = quantity;
            this.dp = dp;
            this.picture = picture;
            this.publisher = publisher;
        }

        public string Pid
        {
            get { return pid; }
            set { pid = value; }
        }

        public string Pname
        {
            get { return pname; }
            set { pname = value; }
        }
        public string Price
        {
            get { return price; }
            set { price = value; }
        }
        public string Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        public string Dp
        {
            get { return dp; }
            set { dp = value; }
        }
        public string Picture
        {
            get { return picture; }
            set { picture = value; }
        }
        public string Publisher
        {
            get { return publisher; }
            set { publisher = value; }
        }
    }
}
