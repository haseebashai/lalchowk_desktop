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
using System.Diagnostics;

namespace Veiled_Kashmir_Admin_Panel
{
    public partial class orders : Form
    {
        DBConnect obj = new DBConnect();
        String email, addressid,cmd, productid, productname, price, quantity, size,dealerprice,shipping, filename,amount,ordervar;
        MySqlDataReader dr,dr1;
        DataTable dt,dt1,dt2,dt3;
        MySqlCommand mysqlcmd,mysqlcmd1;
        MySqlDataAdapter adap,adap1;
        MySqlConnection conn =new MySqlConnection("SERVER = 182.50.133.78; DATABASE=lalchowk;USER=lalchowk;PASSWORD=Lalchowk@123uzmah;Convert Zero Datetime=True");
        MySqlConnection aconn = new MySqlConnection("SERVER=182.50.133.78;DATABASE=lalchowk_ac;USER=lalchowkac;PASSWORD=Lalchowk@123uzmah;Convert Zero Datetime=True");

        BindingSource bsource;
        MySqlCommandBuilder cmdbl;
        PictureBox loading = new PictureBox();
        private container hp = null;

        private dialogcontainer dg = null;
        public orders(Form hpcopy, Form dgcopy) //
        {
            dg = dgcopy as dialogcontainer;
            hp = hpcopy as container;
            InitializeComponent();



            bgworker.RunWorkerAsync();

        }

        private void ordidtxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                orderdetailview.Visible = false;
                dpnl.Visible = false;
                billlbl.Visible = false;
                DataView dv = new DataView(dt);
                dv.RowFilter = string.Format("convert([orderid],System.String) LIKE '%{0}%'", ordidtxt.Text);
                ordergridview.DataSource = dv;
            }catch { }
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
            delbtn.Enabled = false;
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
            try
            {
                DataView dv = new DataView(dt);
                dv.RowFilter = string.Format("convert([contact],System.String) LIKE '%{0}%'", confiltxt.Text);
                ordergridview.DataSource = dv;
            }catch { }
        }

        private void smsbtn_Click(object sender, EventArgs e)
        {
            dialogcontainer dg = new dialogcontainer();
            sendsms sms = new sendsms(contactlbl,"",name);
            sms.TopLevel = false;
            dg.dialogpnl.Controls.Add(sms);
            dg.lbl.Text = "Send SMS";
            dg.Text = "Send SMS";
            dg.Size = new Size(600, 600);
            sms.numbertxt.Font = new Font("MS Sans Serif", 9, FontStyle.Regular);
            sms.smstxt.Text = "Dear "+name+", We would love to hear from you regarding your recent purchase and our services. Please click on the following link and leave your feedback. https://bit.ly/lalchowkonline";
            sms.smsnpnl.Visible = false;
            sms.txtpnl.Location = new Point(35, 10);
            dg.Show();
            sms.Show();
        }

        private void shipbtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                DialogResult dgr = MessageBox.Show("Change status to Shipped for orderid '" + orderlbl.Text + "'", "Confirm!", MessageBoxButtons.YesNo);
                if (dgr == DialogResult.Yes)
                {
                    DateTime time = DateTime.Now;             // Use current time.
                    string shipdate = time.ToString("yyyy-MM-dd HH:mm:ss");

                    string cmd = "Update orders set status='Shipped', shipdate='" + shipdate + "' where orderid='" + orderlbl.Text + "'";
                    obj.nonQuery(cmd);
                    obj.closeConnection();


                    DialogResult ntf = MessageBox.Show("Do you want to send the in-app notification ?", "Confirm!", MessageBoxButtons.YesNo);
                    if (ntf == DialogResult.Yes)
                    {
                        notification nf = new notification(encmail, email, orderlbl.Text);
                        nf.loadingnormal();
                        nf.Show();


                    }
                    MessageBox.Show("Order shipped.","Shipped");

                    readorders();
                    ordergridview.DataSource = bsource;
                    ordergridview.DoubleBuffered(true);
                    Cursor = Cursors.Arrow;
                    //   ordergridview.CurrentCell = ordergridview.Rows[int.Parse(orderidcount)].Cells[0];
                    orderdetailview.Visible = false;
                    dpnl.Visible = false;
                    loadinglbl.Visible = false;
                }
                obj.closeConnection();

            }
            catch { obj.closeConnection(); }
            Cursor = Cursors.Arrow;
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
                    ordergridview.DoubleBuffered(true);
                    Cursor = Cursors.Arrow;
                 //   ordergridview.CurrentCell = ordergridview.Rows[int.Parse(orderidcount)].Cells[0];
                    orderdetailview.Visible = false;
                    dpnl.Visible = false;
                    loadinglbl.Visible = false;




                } else if (dgr == DialogResult.No) {

                    string cmd = "Update orders set status='Cancelled' where orderid='" + orderlbl.Text + "'";
                    obj.nonQuery(cmd);
                    MessageBox.Show("Order cancelled.");

                    readorders();
                    ordergridview.DataSource = bsource;
                    ordergridview.DoubleBuffered(true);
                    Cursor = Cursors.Arrow;
               //     ordergridview.CurrentCell = ordergridview.Rows[int.Parse(orderidcount)].Cells[0];
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

        private void Deliverytxt_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = string.Format("deliveryguy LIKE '%{0}%'", Deliverytxt.Text);
            ordergridview.DataSource = dv;
        }


        private void statustxt_KeyUp(object sender, KeyEventArgs e)
        {
            orderdetailview.Visible = false;
            dpnl.Visible = false;
            billlbl.Visible = false;
        }

        private void ordidtxt_KeyUp(object sender, KeyEventArgs e)
        {
            orderdetailview.Visible = false;
            dpnl.Visible = false;
            billlbl.Visible = false;
        }

        private void emailtxt_KeyUp(object sender, KeyEventArgs e)
        {
            orderdetailview.Visible = false;
            dpnl.Visible = false;
            billlbl.Visible = false;
        }

        private void paymenttxt_KeyUp(object sender, KeyEventArgs e)
        {
            orderdetailview.Visible = false;
            dpnl.Visible = false;
            billlbl.Visible = false;
        }

        private void addfiltxt_KeyUp(object sender, KeyEventArgs e)
        {
            orderdetailview.Visible = false;
            dpnl.Visible = false;
            billlbl.Visible = false;
        }

        private void confiltxt_KeyUp(object sender, KeyEventArgs e)
        {
            orderdetailview.Visible = false;
            dpnl.Visible = false;
            billlbl.Visible = false;
        }

        private void emailbtn_Click(object sender, EventArgs e)
        {
            try
            {
                dialogcontainer dg = new dialogcontainer();
                promomail pm = new promomail(email, dg, name, "");
                pm.TopLevel = false;
                dg.Size = new Size(700, 715);
                pm.epnl.Location = new Point(-300, 1);
                pm.elistlbl.Text = "";

                dg.dialogpnl.Controls.Add(pm);
                pm.loadingdg();
                pm.opnl.Visible = true;
                pm.subtxt.Text = "How was your shopping experience with us?";
                pm.bodytxt.Text = "Dear " + name + ",\r\n\r\nHope you had a nice shopping experience with www.lalchowk.in\r\nWe would love to read your reviews on our Google play store link here: bit.ly/lalchowkonline or our social media handles @lalchowkonline.\r\nYou can also contact us on our Office/WhatsApp number: 9906523492\r\n\r\nThanks and warm regards,\r\nTeam Lalchowk";


                dg.Text = "Send Email";

                dg.Show();

                pm.Show();

            }
            catch
            {
                obj.closeConnection();
            }
        }


        private void ordttxt_KeyUp(object sender, KeyEventArgs e)
        {
            orderdetailview.Visible = false;
            dpnl.Visible = false;
            billlbl.Visible = false;
        }

        private void Deliverytxt_KeyUp(object sender, KeyEventArgs e)
        {
            orderdetailview.Visible = false;
            dpnl.Visible = false;
            billlbl.Visible = false;
        }

       



        //private void ordergridview_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        //{
        //    try
        //    {
        //        foreach (DataGridViewRow row in this.ordergridview.Rows)
        //        {


        //            if (Convert.ToString(row.Cells["paymentconfirmed"].Value) == "True")
        //            {
        //                row.DefaultCellStyle.BackColor = Color.LightGreen;
        //            }
        //            if (Convert.ToString(row.Cells["status"].Value) == "Confirmed")
        //            {
        //                row.DefaultCellStyle.BackColor = Color.LightBlue;
        //            }


        //        }
        //    }
        //    catch { };
        //}

      

        private void updbtn_Click(object sender, EventArgs e)
        {
          
            editorderdetails edit = new editorderdetails(orderlbl.Text);
            edit.TopLevel = true;
           

            edit.ShowDialog();
            
            //Cursor = Cursors.WaitCursor;
            //readorders();
            //ordergridview.DataSource = bsource;
            //Cursor = Cursors.Arrow;
            //ordergridview.CurrentCell = ordergridview.Rows[int.Parse(orderidcount)].Cells[0] ;
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
            

            //dr = obj.Query("select count(orderid) from orders");
            //dr.Read();
            //ordervar = dr[0].ToString();
            //obj.closeConnection();
        }
            catch (Exception ex)
            {
                refresh.Visible = true;
                refresh.Enabled = true;
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
                dg.lbl.Visible = false;
                formlbl.Visible = false;
                dg.dialogpnl.Location = new Point(1, 1);
              
            }
            else
            {
                loading.Visible = false;
                
            }
            formlbl.Visible = false;
           
            try
            {
                ordergridview.Visible = true;
                ordergridview.DataSource = bsource;
                ordergridview.DoubleBuffered(true);
              
                
                ordergridview.Columns["email"].Visible = false;
                panel1.Visible = true;
                orlbl.Text = ordergridview.RowCount.ToString();
                refresh.Enabled = true;
                ordergridview.Enabled = true;
                delbtn.Visible = true;
                delbtn.Enabled = true;
            }
            catch { delbtn.Visible = false; refresh.Enabled = true; ordergridview.Visible = false;  refresh.Visible = true; }
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
            try
            {
               
                DataView dv = new DataView(dt);
                dv.RowFilter = string.Format("status LIKE '%{0}%'", statustxt.Text);
                ordergridview.DataSource = dv;
            }catch { }
        }

        private void billbtn_Click(object sender, EventArgs e)
        {
           
                addbill ab = new addbill(orderlbl.Text, email, amountlbl.Text,contactlbl,shipping,name);
                ab.Show();
                productid = null;
            
        }

        private void delbtn_Click(object sender, EventArgs e)
        {

            if (orderid !=0)
            {

                try
                {
                    DialogResult dr = MessageBox.Show("Delete order and all its details with OrderID: " + orderid + " ?", "Confirm", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        Cursor = Cursors.WaitCursor;
                        cmd = "Delete from orders where orderid='" + orderid + "'";
                        obj.nonQuery(cmd);
                        cmd = "Delete from orderdetails where orderid='" + orderid + "'";
                        obj.nonQuery(cmd);

                        MessageBox.Show("Order deleted.");
                        orderid = 0;
                        dpnl.Visible = false;
                        orderdetailview.Visible = false;

                        readorders();

                        ordergridview.DataSource = bsource;
                        orlbl.Text = ordergridview.RowCount.ToString();
                        ordergridview.DoubleBuffered(true);
                        //    ordergridview.CurrentCell = ordergridview.Rows[int.Parse(orderidcount)].Cells[0];
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
            else
                MessageBox.Show("Please select an order first.", "Error");
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




        private void ordergridview_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex==1)
            {
                
                DataGridViewRow row = this.ordergridview.Rows[e.RowIndex];
                orderid = int.Parse(row.Cells["orderid"].Value.ToString());
            }
        }




            int sumtotal, orderid=0;
        string orderidcount, contactlbl,name,encmail;
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
                    orderid = int.Parse(row.Cells["orderid"].Value.ToString());
                    email = row.Cells["mail"].Value.ToString();
                    encmail = row.Cells["email"].Value.ToString();
                    shipping = row.Cells["shipping"].Value.ToString();
                    name = row.Cells["name"].Value.ToString();
                    addresstxt.Text = row.Cells["name"].Value.ToString()+"\r\n"+ row.Cells["address1"].Value.ToString() +" "+ row.Cells["address2"].Value.ToString()+
                     "\r\n"+ row.Cells["city"].Value.ToString()+", "+ row.Cells["pincode"].Value.ToString()+"\r\n"+ row.Cells["contact"].Value.ToString();
                    contactlbl = row.Cells["contact"].Value.ToString();
                    string status= row.Cells["status"].Value.ToString();
                     /*= row.Cells["amount"].Value.ToString();*/
                    //int result = int.Parse(amount) + int.Parse(shipping);
                    //amountlbl.Text = result.ToString();
                    orderlbl.Text = orderid.ToString();
                    datelbl.Text= row.Cells["timestamp"].Value.ToString();
                    orderidcount = e.RowIndex.ToString();
                    


                    BackgroundWorker details = new BackgroundWorker();

                    details.DoWork += (o, a) =>
                    {
                        try
                        {

                            dr = obj.Query("SELECT amount,shipping FROM orders where orderid='" + orderid + "'");
                            dr.Read();
                            sumtotal= int.Parse(dr[0].ToString()) + int.Parse(dr[1].ToString());
                            obj.closeConnection();
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
                            amountlbl.Text = sumtotal.ToString();

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
