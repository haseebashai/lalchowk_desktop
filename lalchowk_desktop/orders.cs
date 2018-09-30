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
using System.Diagnostics;

namespace Veiled_Kashmir_Admin_Panel
{
    public partial class orders : Form
    {
        DBConnect obj = new DBConnect();
        String orderid,email, addressid,cmd, productid, productname, price, quantity, size,dealerprice,shipping, filename,amount,ordervar;
        MySqlDataReader dr,dr1;
        DataTable dt,dt1,dt2,dt3;
        MySqlCommand mysqlcmd,mysqlcmd1;
        MySqlDataAdapter adap,adap1;
        MySqlConnection conn =new MySqlConnection("SERVER = 182.50.133.78; DATABASE=lalchowk;USER=lalchowk;PASSWORD=Lalchowk@123uzmah");
        MySqlConnection aconn = new MySqlConnection("SERVER=182.50.133.78;DATABASE=lalchowk_ac;USER=lalchowkac;PASSWORD=Lalchowk@123uzmah");

        BindingSource bsource;
        MySqlCommandBuilder cmdbl;
        PictureBox loading = new PictureBox();

        private void ordidtxt_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = string.Format("convert([orderid],System.String) LIKE '%{0}%'", ordidtxt.Text);
            ordergridview.DataSource = dv;
        }

        private void ordttxt_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = string.Format("convert([timestamp],System.String) LIKE '%{0}%'", ordttxt.Text);
            ordergridview.DataSource = dv;
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            ordergridview.Enabled = false;
            orderdetailview.Visible = false;
            dpnl.Visible = false;
            billlbl.Visible = false;
            refresh.Enabled = false;
            bgworker.RunWorkerAsync();
        }

        private void addfiltxt_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = string.Format("address1 LIKE '%{0}%'", addfiltxt.Text);
            ordergridview.DataSource = dv;
        }

        private void confiltxt_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = string.Format("convert([contact],System.String) LIKE '%{0}%'", confiltxt.Text);
            ordergridview.DataSource = dv;
        }

        private void smsbtn_Click(object sender, EventArgs e)
        {
            dialogcontainer dg = new dialogcontainer();
            sendsms sms = new sendsms(contactlbl.Text,"",namelbl.Text);
            sms.TopLevel = false;
            dg.dialogpnl.Controls.Add(sms);
            dg.lbl.Text = "Send SMS";
            dg.Text = "Send SMS";
            dg.Size = new Size(600, 600);
            sms.numbertxt.Font = new Font("MS Sans Serif", 9, FontStyle.Regular);
            sms.smstxt.Text = "Dear "+namelbl.Text+", We would love to hear from you regarding your recent purchase and our services. Please click on the following link and leave your feedback. https://bit.ly/lalchowkonline";
            sms.smsnpnl.Visible = false;
            sms.txtpnl.Location = new Point(35, 10);
            dg.Show();
            sms.Show();
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                DialogResult dgr = MessageBox.Show("Press YES to cancel order '" + orderlbl.Text + "' and update stock\nPress NO to cancel order without updating stock", "Confirm!", MessageBoxButtons.YesNoCancel);
                if (dgr == DialogResult.Yes)
                {

                    string cmd = "Update orders set status='Cancelled' where orderid='" + orderlbl.Text + "'";
                    obj.nonQuery(cmd);

                    List<string> pid = new List<string>();
                    dr = obj.Query("select productid from orderdetails where orderid ='" + orderlbl.Text + "'");
                    while (dr.Read())
                    {
                        pid.Add(dr[0].ToString());
                    }
                    obj.closeConnection();
                    foreach (string products in pid)
                    {

                        string cmd1 = "Update products set stock=stock+1 where productid ='" + products + "'";
                        obj.nonQuery(cmd1);

                    }
                    MessageBox.Show("Order cancelled.");

                    readorders();
                    ordergridview.DataSource = bsource;
                    Cursor = Cursors.Arrow;
                    ordergridview.CurrentCell = ordergridview.Rows[int.Parse(orderidcount)].Cells[0];
                    orderdetailview.Visible = false;
                    dpnl.Visible = false;
                    loadinglbl.Visible = false;




                } else if (dgr == DialogResult.No) {

                    string cmd = "Update orders set status='Cancelled' where orderid='" + orderlbl.Text + "'";
                    obj.nonQuery(cmd);
                    MessageBox.Show("Order cancelled.");

                    readorders();
                    ordergridview.DataSource = bsource;
                    Cursor = Cursors.Arrow;
                    ordergridview.CurrentCell = ordergridview.Rows[int.Parse(orderidcount)].Cells[0];
                    orderdetailview.Visible = false;
                    dpnl.Visible = false;
                    loadinglbl.Visible = false;

                }
                
            
               
            }
            catch (Exception ex)
            {
                obj.closeConnection();
                MessageBox.Show( ex.Message, "Error!");
            }
            Cursor = Cursors.Arrow;
        }

        private dialogcontainer dg = null;
        private container hp = null;

        public orders(Form hpcopy,Form dgcopy)
        {
            dg = dgcopy as dialogcontainer;
            hp = hpcopy as container;
            InitializeComponent();

           
            
            bgworker.RunWorkerAsync();
            
        }

        private void updbtn_Click(object sender, EventArgs e)
        {
            dialogcontainer dg = new dialogcontainer();
            editorderdetails edit = new editorderdetails(orderlbl.Text);
            edit.TopLevel = false;
            dg.Size = new Size(628, 511);
            dg.dialogpnl.Controls.Add(edit);
           
            dg.Text = "Edit Order details";

            edit.Show();
            dg.ShowDialog();
            Cursor = Cursors.WaitCursor;
            readorders();
            ordergridview.DataSource = bsource;
            Cursor = Cursors.Arrow;
            ordergridview.CurrentCell = ordergridview.Rows[int.Parse(orderidcount)].Cells[0] ;
            orderdetailview.Visible = false;
            dpnl.Visible = false;
            loadinglbl.Visible = false;
        }

        private void readorders()
        {try { 
            adap = new MySqlDataAdapter("SELECT customer.mail,orders.*  FROM lalchowk.orders inner join customer on customer.email=orders.email order by orderid desc;",conn);
            dt = new DataTable();
            adap.Fill(dt);
            obj.closeConnection();
            bsource = new BindingSource();
            bsource.DataSource = dt;
            

            dr = obj.Query("select count(orderid) from orders");
            dr.Read();
            ordervar = dr[0].ToString();
            obj.closeConnection();
        }
            catch (Exception ex)
            {
                obj.closeConnection();
                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }

        }

        private void bgworker_DoWork(object sender, DoWorkEventArgs e)
        {
           
            readorders();
            
        }

        private void bgworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {


            if (dg!=null)
            {
                dg.loadingimage.Visible = false;
                dg.lbl.ForeColor = SystemColors.Highlight;
                dg.lbl.Text = "Orders";
                formlbl.Visible = false;
            }
            else
            {
                loading.Visible = false;
                
            }
            formlbl.Visible = false;
            panel1.Visible = true;
            ordergridview.Visible = true;
            ordergridview.DataSource = bsource;
            ordergridview.Columns["shipdate"].Visible = false;
            ordergridview.Columns["deliverdate"].Visible = false;
            ordergridview.Columns["paymentconfirmed"].Visible = false;
            ordergridview.Columns["email"].Visible = false;
            ordergridview.Columns["paymenttype"].Visible = false;
            orlbl.Text = ordervar;
            refresh.Enabled = true;
            ordergridview.Enabled = true;
            Cursor = Cursors.Arrow;
        }


        public void loadingnormal()
        {
            formlbl.Text = "Loading";
            formlbl.Visible = true;

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

            dg.lbl.ForeColor = SystemColors.Highlight;
            dg.lbl.Text = "Loading";
            dg.loadingimage.SizeMode = PictureBoxSizeMode.StretchImage;
            dg.loadingimage.Visible = true;
        }


        private void emailtxt_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = string.Format("mail LIKE '%{0}%'", emailtxt.Text);
            ordergridview.DataSource = dv;
        }


        private void paymenttxt_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = string.Format("name LIKE '%{0}%'", paymenttxt.Text);
            ordergridview.DataSource = dv;
        }

        private void statustxt_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = string.Format("status LIKE '%{0}%'", statustxt.Text);
            ordergridview.DataSource = dv;
        }

        private void billbtn_Click(object sender, EventArgs e)
        {
           
                addbill ab = new addbill(orderlbl.Text, email, amountlbl.Text,contactlbl.Text,shipping,namelbl.Text);
                ab.Show();
                productid = null;
            
        }

        private void delbtn_Click(object sender, EventArgs e)
        {try { 
            DialogResult dr = MessageBox.Show("Delete order and all its details with OrderID: "+orderid+" ?", "Confirm", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                    Cursor = Cursors.WaitCursor;
                cmd = "Delete from orders where orderid='" + orderid + "'";
                obj.nonQuery(cmd);
                cmd = "Delete from orderdetails where orderid='" + orderid + "'";
                obj.nonQuery(cmd);
                    Cursor = Cursors.Arrow;
                MessageBox.Show("Order deleted.");
                dpnl.Visible = false;
                orderdetailview.Visible = false;
                    Cursor = Cursors.WaitCursor;
                readorders();
                orlbl.Text = ordervar;
                ordergridview.DataSource = bsource;
                    ordergridview.CurrentCell = ordergridview.Rows[int.Parse(orderidcount)].Cells[0];
                    orderdetailview.Visible = false;
                    dpnl.Visible = false;
                    loadinglbl.Visible = false;
                    Cursor = Cursors.Arrow;
                }
        }
            catch (Exception ex)
            {
                Cursor = Cursors.Arrow;
                obj.closeConnection();
            }

        }

        private void orderdetailview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.orderdetailview.Rows[e.RowIndex];
                productid = row.Cells["productid"].Value.ToString();
                productname = row.Cells["productname"].Value.ToString();
                price = row.Cells["price"].Value.ToString();
                quantity = row.Cells["quantity"].Value.ToString();
                size = row.Cells["size"].Value.ToString();
                dealerprice = row.Cells["dealerprice"].Value.ToString();       
            }
        }

        private void cnfbtn_Click(object sender, EventArgs e)
        {try { 
            DialogResult dr = MessageBox.Show("Open the bill format file and print the bill?\n", "Confirm", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                
               

                OpenFileDialog bill = new OpenFileDialog();
                bill.Filter = "All Files (*.*)|*.*";
                bill.FilterIndex = 1;

                if (bill.ShowDialog() == DialogResult.OK)
                {
                    filename = bill.FileName;
                }
                Process.Start(filename);

                //  receipt rc = new receipt(orderid);
                // rc.ShowDialog();

            }

            
            readorders();
                ordergridview.DataSource = bsource;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }


        }

       

        string orderidcount;
        private void ordergridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
               

                if (e.RowIndex >= 0)
                {
                    orderdetailview.Visible = false;
                    dpnl.Visible = false;
                    loadinglbl.Visible = true;
                    billlbl.Visible = false;

                    DataGridViewRow row = this.ordergridview.Rows[e.RowIndex];
                    orderid = row.Cells["orderid"].Value.ToString();
                    email = row.Cells["mail"].Value.ToString();
                    shipping = row.Cells["shipping"].Value.ToString();
                    namelbl.Text = row.Cells["name"].Value.ToString();
                    address1lbl.Text = row.Cells["address1"].Value.ToString() +", "+ row.Cells["address2"].Value.ToString()+
                     ", "+ row.Cells["city"].Value.ToString()+", "+ row.Cells["pincode"].Value.ToString();
                    string status= row.Cells["status"].Value.ToString();
                    contactlbl.Text = row.Cells["contact"].Value.ToString();
                    string amount = row.Cells["amount"].Value.ToString();
                    int result = int.Parse(amount) + int.Parse(shipping);
                    amountlbl.Text = result.ToString();
                    orderlbl.Text = orderid;
                    orderidcount= e.RowIndex.ToString();
                    


                    BackgroundWorker details = new BackgroundWorker();

                    details.DoWork += (o, a) =>
                    {
                        try
                        {

                            //dr = obj.Query("SELECT * FROM orderdetails where orderid='" + orderid + "'");
                            //dt1 = new DataTable();
                            //dt1.Load(dr);
                            adap1 = new MySqlDataAdapter("SELECT * FROM orderdetails where orderid='" + orderid + "'", conn);
                            dt1 = new DataTable();
                            adap1.Fill(dt1);
                            obj.closeConnection();
                            BindingSource bsource1 = new BindingSource();
                            bsource1.DataSource = dt1;


                            a.Result = bsource1;

                        }
                        catch
                        {
                            obj.closeConnection();
                        }
                    };

                    details.RunWorkerCompleted += (c, d) =>
                    {
                        try
                        {
                            orderdetailview.Visible = true;
                            dpnl.Visible = true;
                            loadinglbl.Visible = false;

                            BindingSource bsource1 = d.Result as BindingSource;
                            orderdetailview.DataSource = bsource1;
                            orderdetailview.Visible = true;
                            deupdbtn.Visible = true;
                            int count = int.Parse(orderdetailview.RowCount.ToString());

                            //for (int i = 0; i < count; i++)
                            //{
                            //    proname.Items.Add(orderdetailview.Rows[i].Cells[2].Value.ToString() + ":   " + orderdetailview.Rows[i].Cells[3].Value.ToString());
                            //}
                            if (status == "Delivered")
                            {
                                billbtn.Text = "Delivered";

                            }
                            else if (status == "Cancelled")
                            {
                                billbtn.Text = "Cancelled";

                            }
                            else
                            {
                                billbtn.Text = "Confirm Delivery and Add Bill";

                            }
                        }catch { }
                    };
                    while (details.IsBusy)
                        details.CancelAsync();
                    obj.closeConnection();
                    details.RunWorkerAsync();

                    BackgroundWorker bill = new BackgroundWorker();
                    bill.DoWork += (o, a) => 
                    {
                        try
                        {
                            aconn.Open();
                            mysqlcmd1 = new MySqlCommand("select count(orderid) from lalchowk_ac.billing where orderid='"+orderid+"'", aconn);
                            dr = mysqlcmd1.ExecuteReader();
                            dr.Read();
                            int count = int.Parse(dr[0].ToString());
                           
                            aconn.Close();

                            a.Result = count;
                        }catch { aconn.Close(); }

                    };
                    bill.RunWorkerCompleted += (o, b) => 
                    {
                        try
                        {
                            int count = (int)b.Result;

                            if (count > 0)
                            {
                                billlbl.Visible = true;
                            }
                            else { }
                        }catch { }
                    };
                   
                    bill.RunWorkerAsync();

                }

            }
            catch
            {
                obj.closeConnection();
            }
           
        }
        private void deupdbtn_Click(object sender, EventArgs e)
        {
            try
            {
                cmdbl = new MySqlCommandBuilder(adap1);
                adap1.Update(dt1);
                MessageBox.Show("Order Updated.");

            }
            catch (Exception ex)
            {

                MessageBox.Show("Something happened, please try again.\n\n" + ex.ToString(), "Error!");
            }
        }


    }
}
