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
using Microsoft.VisualBasic;

namespace Veiled_Kashmir_Admin_Panel
{
    public partial class medorders : Form
    {

        DBConnect obj = new DBConnect();
        MySqlDataReader dr,dr1,dr2;
        string url = "http://lalchowk.in/uploads/";
        public medorders()
        {
            InitializeComponent();
            placeddataview.DoubleBuffered(true);

            PictureBox loading = new PictureBox()
            {
                Image = Properties.Resources.loading,
                Size = new Size(40, 30),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Location = new Point(73, 0),
            };
            this.Controls.Add(loading);

            BackgroundWorker medload = new BackgroundWorker();
            medload.WorkerReportsProgress = true;
           
            try
            {
                medload.DoWork += (o, a) => 
               {
                
                    dr = obj.Query("select customer.mail,medorders.email,medorders.orderid,medorders.timestamp,medorders.amount,medorders.dp,medorders.shipping,medorders.itemcount,medorders.paymenttype,medorders.paymentconfirmed,medorders.status,medorders.name,medorders.address1,medorders.address2,medorders.pincode,medorders.contact,medorders.city,medorders.msg from lalchowk.medorders inner join customer on customer.email=medorders.email where status='placed' or status='confirmed' order by orderid desc;" );

                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    obj.closeConnection();
                    BindingSource bsource = new BindingSource();
                    bsource.DataSource = dt;
                   object[] arg = { bsource};

                   medload.ReportProgress(25,arg);


                   dr = obj.Query("select customer.mail,medorders.email,medorders.orderid,medorders.timestamp,medorders.amount,medorders.dp,medorders.shipping,medorders.itemcount,medorders.paymenttype,medorders.paymentconfirmed,medorders.status,medorders.name,medorders.address1,medorders.address2,medorders.pincode,medorders.contact,medorders.city,medorders.msg from lalchowk.medorders inner join customer on customer.email=medorders.email where status='shipped' order by orderid desc;");

                   DataTable dt3 = new DataTable();
                   dt3.Load(dr);
                   obj.closeConnection();
                   BindingSource bsource3 = new BindingSource();
                   bsource3.DataSource = dt3;
                   object[] arg3 = { bsource3 };

                   medload.ReportProgress(50, arg3);



                   dr1 = obj.Query("select customer.mail,medorders.email,medorders.orderid,medorders.timestamp,medorders.amount,medorders.dp,medorders.shipping,medorders.itemcount,medorders.status,medorders.name,medorders.address1,medorders.address2,medorders.pincode,medorders.contact,medorders.city,medorders.msg from lalchowk.medorders inner join customer on customer.email=medorders.email where status='delivered' order by orderid desc;");

                   DataTable dt1 = new DataTable();
                   dt1.Load(dr1);
                   obj.closeConnection();
                   BindingSource bsource1 = new BindingSource();
                   bsource1.DataSource = dt1;
                   object[] arg1 = { bsource1 };
                   medload.ReportProgress(75,arg1);

                   dr2 = obj.Query("select customer.mail,medorders.email,medorders.orderid,medorders.timestamp,medorders.amount,medorders.dp,medorders.shipping,medorders.itemcount,medorders.status,medorders.name,medorders.address1,medorders.address2,medorders.pincode,medorders.contact,medorders.city,medorders.msg from lalchowk.medorders inner join customer on customer.email=medorders.email order by orderid desc ;");

                   DataTable dt2 = new DataTable();
                   dt2.Load(dr2);
                   obj.closeConnection();
                   BindingSource bsource2 = new BindingSource();
                   bsource2.DataSource = dt2;
                   object[] arg2 = { bsource2 };
                   medload.ReportProgress(90, arg2);
               };

                medload.ProgressChanged += (o, a) =>
                {
                    if (a.ProgressPercentage == 25)
                    {
                        try { 
                        Object[] arg = (object[])a.UserState;
                        BindingSource bsource = arg[0] as BindingSource;
                        placeddataview.DataSource = bsource;
                     //   loadlbl.Text="Health Orders";
                        placeddataview.Columns["email"].Visible = false;
                        placeddataview.Visible = true;
                        medcontrol.Visible = true;

                        DataGridViewButtonColumn ship = new DataGridViewButtonColumn();
                        ship.UseColumnTextForButtonValue = true;
                        ship.Name = "Ship";
                        ship.DataPropertyName = "Ship";
                        ship.Text = "Ship";
                        placeddataview.Columns.Add(ship);
                        }
                        catch { }
                    }
                    else
                    if (a.ProgressPercentage == 50)
                    {
                        try { 
                        Object[] arg = (object[])a.UserState;
                        BindingSource bsource = arg[0] as BindingSource;
                        shippeddataview.DataSource = bsource;
                        dellbl.Visible = false;
                        shippeddataview.Columns["email"].Visible = false;
                        shippeddataview.Visible = true;

                        DataGridViewButtonColumn del = new DataGridViewButtonColumn();
                        del.UseColumnTextForButtonValue = true;
                        del.Name = "Delivered";
                        del.DataPropertyName = "Delivered";
                        del.Text = "Delivered";
                        shippeddataview.Columns.Add(del);
                        }
                        catch { }
                    }                   
                    else
                    if (a.ProgressPercentage == 75)
                    {
                        try
                        {
                            Object[] arg = (object[])a.UserState;
                            BindingSource bsource = arg[0] as BindingSource;
                            deldataview.DataSource = bsource;
                            dellbl.Visible = false;
                            deldataview.Columns["email"].Visible = false;
                            deldataview.Visible = true;
                        }
                        catch { }

                    }
                    else
                    if (a.ProgressPercentage == 90)
                    {
                        try { 
                        Object[] arg = (object[])a.UserState;
                        BindingSource bsource = arg[0] as BindingSource;
                        alldataview.DataSource = bsource;
                        alllbl.Visible = false;
                        loadlbl.Text = "Health Orders";
                        alldataview.Columns["email"].Visible = false;
                        alldataview.Visible = true;
                        }
                        catch { }

                    }



                };

                medload.RunWorkerCompleted += (o, b) => 
                {
                    //BindingSource bsource = b.Result as BindingSource;
                    //placeddataview.DataSource = bsource;
                    //loadlbl.Visible = false;
                    //placeddataview.Columns["email"].Visible = false;
                    //placeddataview.Visible = true;
                    medcontrol.Visible = true;
                    loading.Visible = false;
                    loading.Dispose();

                    obj.closeConnection();

                };
                medload.RunWorkerAsync();
                
            }
            catch (Exception ex) { medcontrol.Visible = false; loadlbl.Text = "error, please reload"; loadlbl.Visible = true; MessageBox.Show(ex.Message); obj.closeConnection(); }

           

        }
        //private void tabPage2_Paint(object sender, PaintEventArgs e)
        //{
        //    dellbl.Visible = true;
        //    medcontrol.Enabled = false;
        //    BackgroundWorker delload = new BackgroundWorker();
        //    try
        //    {
        //        delload.DoWork += (o, a) =>
        //        {

        //            dr1 = obj.Query("select customer.mail,medorders.email,medorders.orderid,medorders.timestamp,medorders.amount,medorders.shipping,medorders.itemcount,medorders.status,medorders.name,medorders.address1,medorders.address2,medorders.pincode,medorders.contact,medorders.city from lalchowk.medorders inner join customer on customer.email=medorders.email where status='delivered';");

        //            DataTable dt1 = new DataTable();
        //            dt1.Load(dr1);
        //            obj.closeConnection();
        //            BindingSource bsource1 = new BindingSource();
        //            bsource1.DataSource = dt1;

        //            a.Result = bsource1;
        //        };
        //        delload.RunWorkerCompleted += (o, b) =>
        //        {
        //            BindingSource bsource1 = b.Result as BindingSource;
        //            deldataview.DataSource = bsource1;
        //            dellbl.Visible = false;
        //            deldataview.Columns["email"].Visible = false;
        //            deldataview.Visible = true;
        //            obj.closeConnection();


        //        };
        //        delload.RunWorkerAsync();

        //    }
        //    catch (Exception ex) { obj.closeConnection(); deldataview.Visible = false; dellbl.Text = "error, please reload"; dellbl.Visible = true; MessageBox.Show(ex.Message); }
        //    medcontrol.Enabled = true;
        //}

        //private void allorderspg_Paint(object sender, PaintEventArgs e)
        //{
        //    alllbl.Visible = true;
        //    medcontrol.Enabled = false;
        //    BackgroundWorker allload = new BackgroundWorker();
        //    try
        //    {
        //        allload.DoWork += (o, a) =>
        //        {

        //            dr2 = obj.Query("select customer.mail,medorders.email,medorders.orderid,medorders.timestamp,medorders.amount,medorders.shipping,medorders.itemcount,medorders.status,medorders.name,medorders.address1,medorders.address2,medorders.pincode,medorders.contact,medorders.city from lalchowk.medorders inner join customer on customer.email=medorders.email ;");

        //            DataTable dt2 = new DataTable();
        //            dt2.Load(dr2);
        //            obj.closeConnection();
        //            BindingSource bsource2 = new BindingSource();
        //            bsource2.DataSource = dt2;

        //            a.Result = bsource2;
        //        };
        //        allload.RunWorkerCompleted += (o, b) =>
        //        {
        //            BindingSource bsource2 = b.Result as BindingSource;
        //            alldataview.DataSource = bsource2;
        //            alllbl.Visible = false;
        //            alldataview.Columns["email"].Visible = false;
        //            alldataview.Visible = true;

        //            obj.closeConnection();

        //        };
        //        allload.RunWorkerAsync();

        //    }
        //    catch (Exception ex) { obj.closeConnection(); alldataview.Visible = false; alllbl.Text = "error, please reload"; alllbl.Visible = true; MessageBox.Show(ex.Message); }
        //    medcontrol.Enabled = true;
        //}

        int oid=0;
        private void placeddataview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          //  MessageBox.Show(e.ColumnIndex.ToString());
            try
            {
                btpnl.Visible = true;
                if (e.RowIndex >= 0 && e.ColumnIndex < 18)
                {
                    detailpnl.Visible =false;
                      
                    DataGridViewRow row = this.placeddataview.Rows[e.RowIndex];
                    oid = int.Parse(row.Cells["orderid"].Value.ToString());
                    dr = obj.Query("select url from lalchowk.image_uploads where oid ='"+oid+"';");
                    dr.Read();
                    string file = dr[0].ToString();
                    obj.closeConnection();
                    
                    string imagename = file.Split('/')[3];
                    MessageBox.Show(url + imagename);
                    presdp.SizeMode = PictureBoxSizeMode.StretchImage;
                    presdp.ImageLocation = (url + imagename);




                    presdp.Visible = true;
                    nametxt.Text = row.Cells["name"].Value.ToString();
                    contxt.Text = row.Cells["contact"].Value.ToString();
                    msgtxt.Text = row.Cells["msg"].Value.ToString();
                    detailpnl.Visible = true;
                }
                else if(e.RowIndex>=0 && e.ColumnIndex == 18)
                {

                    
                    Cursor = Cursors.WaitCursor;
                    try
                    {
                        DataGridViewRow row = this.placeddataview.Rows[e.RowIndex];
                        string id = row.Cells["orderid"].Value.ToString();
                        DialogResult dgr = MessageBox.Show("Change status to Shipped for orderid '" + id + "'", "Confirm!", MessageBoxButtons.YesNo);
                        if (dgr == DialogResult.Yes)
                        {
                            string input = Interaction.InputBox("Please Enter Delivery Guy info:", "Delivery info", "Suhaib", -1, -1);
                            DateTime time = DateTime.Now;             // Use current time.
                            string shipdate = time.ToString("yyyy-MM-dd HH:mm:ss");

                            string cmd = "Update medorders set status='Shipped', shipdate='" + shipdate + "', deliveryguy='" + input + "',in_transit='1' where orderid='" + id + "'";
                            obj.nonQuery(cmd);
                            obj.closeConnection();
                            MessageBox.Show("Order status changed.", "Success");
                            //placedorders();


                            //shippedorders();
                            //placedh.Text = "Orders placed: " + placeddataview.RowCount;
                            //shippedh.Text = "Orders currently shipped: " + shippeddataview.RowCount;
                            //shippeddataview.Visible = true;
                            //ppnl.Visible = false;
                            //emailbtn.Visible = false;
                            //sendsmsbtn.Visible = false;
                            //cancelbtn.Visible = false;
                            //shippedh.Visible = true;
                            //printadd2btn.Visible = false;
                            //cshipbtn.Visible = false;
                            //cselbtn.Visible = false;
                            //selectlbl.Visible = false;
                            //ordelbtn.Visible = false;
                            //num = 0;

                        }
                    }
                    catch
                    {
                        obj.closeConnection();
                    }
                    Cursor = Cursors.Arrow;
                   

                }



                }
            catch(Exception ex) { MessageBox.Show(ex.Message); obj.closeConnection(); };


        }
        private void shippeddataview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                btpnl.Visible = true;
                if (e.RowIndex >= 0 && e.ColumnIndex>0)
                {
                    detailpnl.Visible = false;
                    //  MessageBox.Show(e.ColumnIndex.ToString());
                    DataGridViewRow row = this.shippeddataview.Rows[e.RowIndex];
                    oid = int.Parse(row.Cells["orderid"].Value.ToString());
                    dr = obj.Query("select url from lalchowk.image_uploads where oid ='" + oid + "';");
                    dr.Read();
                    string file = dr[0].ToString();
                    obj.closeConnection();

                    string imagename = file.Split('/')[3];
                    MessageBox.Show(url + imagename);
                    presdp.SizeMode = PictureBoxSizeMode.StretchImage;
                    presdp.ImageLocation = (url + imagename);

                    presdp.Visible = true;
                    nametxt.Text = row.Cells["name"].Value.ToString();
                    contxt.Text = row.Cells["contact"].Value.ToString();
                    msgtxt.Text = row.Cells["msg"].Value.ToString();
                    detailpnl.Visible = true;

                }
                else if (e.RowIndex >= 0 && e.ColumnIndex == 0)
                {


                    Cursor = Cursors.WaitCursor;
                    try
                    {
                        DataGridViewRow row = this.shippeddataview.Rows[e.RowIndex];
                        string id = row.Cells["orderid"].Value.ToString();
                        DialogResult dgr = MessageBox.Show("Change status to Delivered for orderid '" + id + "'", "Confirm!", MessageBoxButtons.YesNo);
                        if (dgr == DialogResult.Yes)
                        {
                            DateTime time = DateTime.Now;             // Use current time.
                            string deldate = time.ToString("yyyy-MM-dd HH:mm:ss tt");
                            string cmd = "update medorders set status='Delivered', deliverdate='" + deldate + "', in_transit='0' where orderid='" + id + "'";
                            obj.nonQuery(cmd);
                            obj.closeConnection();
                            MessageBox.Show("Order status changed.", "Success");
                            //placedorders();


                            //shippedorders();
                            //placedh.Text = "Orders placed: " + placeddataview.RowCount;
                            //shippedh.Text = "Orders currently shipped: " + shippeddataview.RowCount;
                            //shippeddataview.Visible = true;
                            //ppnl.Visible = false;
                            //emailbtn.Visible = false;
                            //sendsmsbtn.Visible = false;
                            //cancelbtn.Visible = false;
                            //shippedh.Visible = true;
                            //printadd2btn.Visible = false;
                            //cshipbtn.Visible = false;
                            //cselbtn.Visible = false;
                            //selectlbl.Visible = false;
                            //ordelbtn.Visible = false;
                            //num = 0;

                        }
                    }
                    catch
                    {
                        obj.closeConnection();
                    }
                    Cursor = Cursors.Arrow;


                }
                }
            catch (Exception ex) { MessageBox.Show(ex.Message); obj.closeConnection(); };

        }

        private void addorderbtn_Click(object sender, EventArgs e)
        {
            addmedorder add = new addmedorder();
            add.Show();
        }


        private void cancelbtn_Click(object sender, EventArgs e)
        {
            if (oid != 0)
            {

                try
                {
                    DialogResult dr = MessageBox.Show("Cancel order with OrderID: " + oid + " ?", "Confirm", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        Cursor = Cursors.WaitCursor;
                        string cmd = "Update medorders set status='Cancelled' where orderid='" + oid + "'";
                        obj.nonQuery(cmd);


                        MessageBox.Show("Order Cancelled.");
                        oid = 0;
                        btpnl.Visible = false;



                        Cursor = Cursors.Arrow;
                    }
                }
                catch (Exception ex)
                {
                    Cursor = Cursors.Arrow;
                    obj.closeConnection();
                }
            }
            else
                MessageBox.Show("Please select an order first.", "Error");
        }


        private void delorderbtn_Click(object sender, EventArgs e)
        {
            if (oid != 0)
            {

                try
                {
                    DialogResult dr = MessageBox.Show("Delete order and all its details with OrderID: " + oid + " ?", "Confirm", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        Cursor = Cursors.WaitCursor;
                        string cmd = "Delete from medorders where orderid='" + oid + "'";
                        obj.nonQuery(cmd);
                       

                        MessageBox.Show("Order deleted.");
                        oid = 0;
                        btpnl.Visible = false;
                       

                       
                        Cursor = Cursors.Arrow;
                    }
                }
                catch (Exception ex)
                {
                    Cursor = Cursors.Arrow;
                    obj.closeConnection();
                }
            }
            else
                MessageBox.Show("Please select an order first.", "Error");
        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            editmedorders edit = new editmedorders(oid.ToString());
            edit.Show();
        }

      
        private void deldataview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                btpnl.Visible = true;
                if (e.RowIndex >= 0)
                {
                    detailpnl.Visible = false;
                    DataGridViewRow row = this.deldataview.Rows[e.RowIndex];
                    oid = int.Parse(row.Cells["orderid"].Value.ToString());
                    dr = obj.Query("select url from lalchowk.image_uploads where oid ='" + oid + "';");
                    dr.Read();
                    string file = dr[0].ToString();
                    obj.closeConnection();

                    string imagename = file.Split('/')[3];
                    MessageBox.Show(url + imagename);
                    presdp.SizeMode = PictureBoxSizeMode.StretchImage;
                    presdp.ImageLocation = (url + imagename);

                    presdp.Visible = true;
                    presdp.Visible = true;
                    nametxt.Text = row.Cells["name"].Value.ToString();
                    contxt.Text = row.Cells["contact"].Value.ToString();
                    msgtxt.Text = row.Cells["msg"].Value.ToString();
                    detailpnl.Visible = true;
                }



            }
            catch (Exception ex) { MessageBox.Show(ex.Message); obj.closeConnection(); };

        }

        private void alldataview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                btpnl.Visible = true;
                if (e.RowIndex >= 0)
                {
                    detailpnl.Visible = false;
                    DataGridViewRow row = this.alldataview.Rows[e.RowIndex];
                    oid = int.Parse(row.Cells["orderid"].Value.ToString());
                    dr = obj.Query("select url from lalchowk.image_uploads where oid ='" + oid + "';");
                    dr.Read();
                    string file = dr[0].ToString();
                    obj.closeConnection();

                    string imagename = file.Split('/')[3];
                    MessageBox.Show(url + imagename);
                    presdp.SizeMode = PictureBoxSizeMode.StretchImage;
                    presdp.ImageLocation = (url + imagename);

                    presdp.Visible = true;
                    presdp.Visible = true;
                    nametxt.Text = row.Cells["name"].Value.ToString();
                    contxt.Text = row.Cells["contact"].Value.ToString();
                    msgtxt.Text = row.Cells["msg"].Value.ToString();
                    detailpnl.Visible = true;
                }



            }
            catch (Exception ex) { MessageBox.Show(ex.Message); obj.closeConnection(); };

        }


    }
}
