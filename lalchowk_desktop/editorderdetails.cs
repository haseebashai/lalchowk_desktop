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
using System.Globalization;

namespace Veiled_Kashmir_Admin_Panel
{
    public partial class editorderdetails : Form
    {

        DBConnect obj = new DBConnect();
        MySqlDataReader dr;
        string id;
        MySqlConnection conn = new MySqlConnection("SERVER = 182.50.133.78; DATABASE=lalchowk;USER=lalchowk;PASSWORD=Lalchowk@123uzmah");
        MySqlDataAdapter adap;
        DataTable dt;
        MySqlCommand cmd;


        public editorderdetails(string orderid)
        {
            InitializeComponent();
            id = orderid;
            updbtn.Text = "Loading...";
            updbtn.Enabled = false;
            BackgroundWorker orderload = new BackgroundWorker();
            orderload.DoWork += Orderload_DoWork;
            orderload.RunWorkerCompleted += Orderload_RunWorkerCompleted;
            orderload.RunWorkerAsync(orderid);
            titlelbl.Text = "Edit order details for OrderID: " + orderid;
            searchtxt.AutoCompleteCustomSource = userinfo.col;

        }

        private void Orderload_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            try
            {

                ptypebox.DisplayMember = "Text";
                var items = new[]
                {
                new {Text="Pre-Pay"},
                new {Text ="Cash on Delivery"},
                 new {Text="DC"},
                new {Text ="CC"},
                 new {Text="UPI"},
                new {Text ="Online"},
                 new {Text="NB"},
               new {Text="Paytm"},
                };
                ptypebox.DataSource = items;

                updbtn.Text = "Update";
                updbtn.Enabled = true;

                object[] arg = (object[])e.Result;

                amtxt.Text = (string)arg[0];
                shiptxt.Text = arg[1] as String;
                nametxt.Text = arg[2] as String;
                add1txt.Text = arg[3] as String;
                add2txt.Text = arg[4] as String;
                pintxt.Text = arg[5] as String;
                contxt.Text = arg[6] as String;
                citytxt.Text = arg[7] as String;
                statustxt.Text = arg[8] as string;
                counttxt.Text = arg[9] as string;
                dguytxt.Text = arg[10] as string;
                string ptype = arg[11] as string;
                string pconf = arg[12] as string;
                BindingSource bsource = arg[13] as BindingSource;
                shipdttxt.Text = arg[14] as string;
                deldttxt.Text = arg[15] as string;
                string transit = arg[16] as string;
                
                orderdetailview.DataSource = bsource;

                orderdetailview.Visible = true;
                deupdbtn.Visible = true;
                
                if (transit == "False")
                {
                    transitbox.Checked = false;
                }
                else if(transit=="True")
                    transitbox.Checked = true;
                


                if (pconf == "False")
                {
                    pcnbox.Checked = true;
                    pcybox.Checked = false;
                }
                else if (pconf == "True")
                {
                    pcybox.Checked = true;
                    pcnbox.Checked = false;
                }
               
                if (ptype == "Pre-Pay")
                {
                    ptypebox.SelectedIndex = 0;
                }else if(ptype=="Cash on Delivery")
                {
                    ptypebox.SelectedIndex = 1;
                }
                else if (ptype == "DC")
                {
                    ptypebox.SelectedIndex = 2;
                }
                else if (ptype == "CC")
                {
                    ptypebox.SelectedIndex = 3;
                }
                else if (ptype == "UPI")
                {
                    ptypebox.SelectedIndex = 4;
                }
                else if (ptype == "Online")
                {
                    ptypebox.SelectedIndex = 5;
                }
                else if (ptype == "NB")
                {
                    ptypebox.SelectedIndex = 6;
                }
                else if (ptype == "Paytm")
                {
                    ptypebox.SelectedIndex = 7;
                }

                refreshbtn.Visible = true;



            }
            catch (Exception ex) 
            {
                obj.closeConnection();
                conn.Close();
                MessageBox.Show(ex.Message);
                updbtn.Text = "Please Reload.";
                updbtn.Enabled =false;
                orderdetailview.Visible = false;
                deupdbtn.Visible =false;
                refreshbtn.Visible = true;

             

            }
        }

        private void Orderload_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string orderid = e.Argument as string;
               
                dr = obj.Query("select amount,shipping,name,address1,address2,pincode,contact,city,status,itemcount,deliveryguy,paymenttype,paymentconfirmed,shipdate,deliverdate,in_transit from orders where orderid='" + orderid + "'");
                dr.Read();
                string amount = dr[0].ToString();
                string shipping = dr[1].ToString();
                string name = dr[2].ToString();
                string add1 = dr[3].ToString();
                string add2 = dr[4].ToString();
                string pin = dr[5].ToString();
                string con = dr[6].ToString();
                string city = dr[7].ToString();
                string status = dr[8].ToString();
                string count = dr[9].ToString();
                string dguy= dr[10].ToString();
                string ptype = dr[11].ToString();
                string pconf = dr[12].ToString();
                string sdate= dr[13].ToString();
                string ddate = dr[14].ToString();               
                string transit = dr[15].ToString();
             

                obj.closeConnection();

               adap = new MySqlDataAdapter("SELECT * FROM orderdetails where orderid='" + orderid + "'", conn);
               dt = new DataTable();
                adap.Fill(dt);
                conn.Close();
                BindingSource bsource = new BindingSource();
                bsource.DataSource = dt;


                object[] arg = {amount,shipping,name,add1,add2,pin,con,city,status,count,dguy,ptype,pconf,bsource,sdate,ddate,transit};
              
                e.Result = arg;

            }catch
            {
                obj.closeConnection();
                conn.Close();
            }
        }

        public bool update = false;
        private void updbtn_Click(object sender, EventArgs e)
        {
            string pconf= "",transit="";
            try
            {
                DialogResult dgr = MessageBox.Show("Update details for this OrderID: " + id + " ?", "Confirm", MessageBoxButtons.YesNo);
                if (dgr == DialogResult.Yes)
                {
                    Cursor = Cursors.WaitCursor;
                    if (pcybox.Checked)
                        pconf = "1";
                    else
                        pconf = "0";
                    if (transitbox.Checked)
                        transit = "1";
                    else
                        transit = "0";
                  

                    if (deldttxt.Text == String.Empty)
                    {
                        string date = "NULL";
                        string cmd = "update orders set amount='" + amtxt.Text + "',shipping='" + shiptxt.Text + "',name='" + nametxt.Text + "',address1='" + add1txt.Text + "'" +
                        ",address2='" + add2txt.Text + "',pincode='" + pintxt.Text + "',contact='" + contxt.Text + "',city='" + citytxt.Text + "',status='" + statustxt.Text + "'" +
                        ",itemcount='" + counttxt.Text + "',deliveryguy='" + dguytxt.Text + "',paymenttype='" + ptypebox.Text + "',paymentconfirmed='" + pconf
                        + "',deliverdate="+date+",in_transit='"+transit+"' where orderid='" + id + "'";
                        obj.nonQuery(cmd);
                    }
                    else
                    {

                      
                        string date = Convert.ToDateTime(deldttxt.Text).ToString("yyyy-MM-dd HH:mm:ss tt");
                        string cmd = "update orders set amount='" + amtxt.Text + "',shipping='" + shiptxt.Text + "',name='" + nametxt.Text + "',address1='" + add1txt.Text + "'" +
                            ",address2='" + add2txt.Text + "',pincode='" + pintxt.Text + "',contact='" + contxt.Text + "',city='" + citytxt.Text + "',status='" + statustxt.Text + "'" +
                            ",itemcount='" + counttxt.Text + "',deliveryguy='" + dguytxt.Text + "',paymenttype='" + ptypebox.Text + "',paymentconfirmed='" + pconf
                            + "',deliverdate='" + date + "',in_transit='" + transit + "' where orderid='" + id + "'";
                            obj.nonQuery(cmd);
                      
                        
                           
                    }
                    
                    Cursor = Cursors.Arrow;
                    update = true;
                    MessageBox.Show("Updated.");
                }
              

            }
            catch(Exception ex)
            {
                Cursor = Cursors.Arrow;
                obj.closeConnection();
                MessageBox.Show(ex.ToString());
            }
        }

        private void pcybox_CheckedChanged(object sender, EventArgs e)
        {

            if (pcybox.Checked)
                pcnbox.Checked = false;
        }

        private void pcnbox_CheckedChanged(object sender, EventArgs e)
        {
           
          if(  pcnbox.Checked)
                pcybox.Checked = false;
        }

        private void deupdbtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
               MySqlCommandBuilder cmdbl = new MySqlCommandBuilder(adap);
                adap.Update(dt);
                MessageBox.Show("Items Updated.");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "Error!");
            }
            Cursor = Cursors.Arrow;
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            refreshbtn.Enabled = false;
            updbtn.Text = "Loading...";
            updbtn.Enabled = false;
            orderdetailview.Visible = false;
            deupdbtn.Visible =false;

            BackgroundWorker refresh = new BackgroundWorker();
            refresh.DoWork += (o, a) => {
                try
                {
                    string orderid = a.Argument as string;

                    dr = obj.Query("select amount,shipping,name,address1,address2,pincode,contact,city,status,itemcount,deliveryguy,paymenttype,paymentconfirmed from orders where orderid='" + orderid + "'");
                    dr.Read();
                    string amount = dr[0].ToString();
                    string shipping = dr[1].ToString();
                    string name = dr[2].ToString();
                    string add1 = dr[3].ToString();
                    string add2 = dr[4].ToString();
                    string pin = dr[5].ToString();
                    string con = dr[6].ToString();
                    string city = dr[7].ToString();
                    string status = dr[8].ToString();
                    string count = dr[9].ToString();
                    string dguy = dr[10].ToString();
                    string ptype = dr[11].ToString();
                    string pconf = dr[12].ToString();
                    obj.closeConnection();

                    adap = new MySqlDataAdapter("SELECT * FROM orderdetails where orderid='" + orderid + "'", conn);
                    dt = new DataTable();
                    adap.Fill(dt);
                    obj.closeConnection();
                    BindingSource bsource = new BindingSource();
                    bsource.DataSource = dt;


                    object[] arg = { amount, shipping, name, add1, add2, pin, con, city, status, count, dguy, ptype, pconf, bsource };

                    a.Result = arg;

                }
                catch
                {
                    obj.closeConnection();
                }
            };
            refresh.RunWorkerCompleted += (o, b) => {
                try
                {

                    ptypebox.DisplayMember = "Text";
                    var items = new[]
                    {
                new {Text="Pre-Pay"},
                new {Text ="Cash on Delivery"},
                };
                    ptypebox.DataSource = items;

                    updbtn.Text = "Update";
                    updbtn.Enabled = true;

                    object[] arg = (object[])b.Result;

                    amtxt.Text = (string)arg[0];
                    shiptxt.Text = arg[1] as String;
                    nametxt.Text = arg[2] as String;
                    add1txt.Text = arg[3] as String;
                    add2txt.Text = arg[4] as String;
                    pintxt.Text = arg[5] as String;
                    contxt.Text = arg[6] as String;
                    citytxt.Text = arg[7] as String;
                    statustxt.Text = arg[8] as string;
                    counttxt.Text = arg[9] as string;
                    dguytxt.Text = arg[10] as string;
                    string ptype = arg[11] as string;
                    string pconf = arg[12] as string;
                    BindingSource bsource = arg[13] as BindingSource;
                    orderdetailview.DataSource = bsource;

                    orderdetailview.Visible = true;
                    deupdbtn.Visible = true;

                    if (pconf == "False")
                    {
                        pcnbox.Checked = true;
                        pcybox.Checked = false;
                    }
                    else if (pconf == "True")
                    {
                        pcybox.Checked = true;
                        pcnbox.Checked = false;
                    }

                    if (ptype == "Pre-Pay")
                    {
                        ptypebox.SelectedIndex = 0;
                    }
                    else if (ptype == "Cash on Delivery")
                    {
                        ptypebox.SelectedIndex = 1;
                    }


                    Cursor = Cursors.Arrow;
                    refreshbtn.Enabled = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    updbtn.Text = "Please Reload.";
                    updbtn.Enabled = false;
                    orderdetailview.Visible = true;
                    deupdbtn.Visible = false;
                    refreshbtn.Enabled = true;
                    Cursor = Cursors.Arrow;
                    obj.closeConnection();
                    conn.Close();

                }
            };
            refresh.RunWorkerAsync(id);
            
          
        }

        private void deldttxt_TextChanged(object sender, EventArgs e)
        {
            deldttxt.MaxLength = 10;
        }


        private void orderdetailview_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {



                int price = 0, quant = 0;
                for (int i = 0; i < orderdetailview.Rows.Count; i++)
                {
                    price = price + (Convert.ToInt32(orderdetailview.Rows[i].Cells["price"].Value) * Convert.ToInt32(orderdetailview.Rows[i].Cells["quantity"].Value));
                    quant = quant + Convert.ToInt32(orderdetailview.Rows[i].Cells["quantity"].Value);
                }
                amtxt.Text = price.ToString();
                counttxt.Text = quant.ToString();

            }
            catch (Exception ex) { }// MessageBox.Show(ex.Message); }
        }

        private void refresh_Click_1(object sender, EventArgs e)
        {
            refresh.Enabled = false;

            loadinglbl.Visible = true;
            searchtxt.Enabled = false;
            try
            {
                conn.Close();

                BackgroundWorker search = new BackgroundWorker();
                search.WorkerReportsProgress = true;
                search.DoWork += (o, a) =>
                {

                    search.ReportProgress(10);
                    AutoCompleteStringCollection col1 = new AutoCompleteStringCollection();

                    cmd = new MySqlCommand("Select concat_ws(' ',productname,'(',detail1,detail2,')','@',mrp,'#',productid) as tag from products where productid>9999", conn);
                    try
                    {
                        conn.Open();
                        search.ReportProgress(30);
                        MySqlDataReader data = cmd.ExecuteReader();
                        while (data.Read())
                        {
                            string sname = data.GetString("tag");
                            col1.Add(sname);
                        }
                        search.ReportProgress(90);
                        conn.Close();
                        a.Result = col1;
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }

                };
                search.ProgressChanged += (o, c) =>
                {
                    if (c.ProgressPercentage == 10)
                    {
                        loadinglbl.Text = "loading...10%";
                    }
                    else if (c.ProgressPercentage == 30)
                    {
                        loadinglbl.Text = "loading...30%";
                    }
                    else if (c.ProgressPercentage == 90)
                    {
                        loadinglbl.Text = "loading...90%";
                    }

                };

                search.RunWorkerCompleted += (o, b) => {
                    userinfo.col = b.Result as AutoCompleteStringCollection;
                    loadinglbl.Visible = false;
                    searchtxt.Enabled = true;
                    searchtxt.Text = "";
                    refresh.Enabled = true;
                    searchtxt.AutoCompleteCustomSource = userinfo.col;
                };
                search.RunWorkerAsync();

            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); conn.Close(); }

        }

        //private void addpbtn_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (searchtxt.Text == "")
        //        {
        //            MessageBox.Show("Please search a product.", "Error!");
        //        }
        //        else
        //        {
        //            Cursor = Cursors.WaitCursor;
        //            //string name = searchtxt.Text.Split('(')[0];
        //            //StringBuilder productname = new StringBuilder(name);
        //            //productname.Replace(@"'", "\\'").Replace(@"\", "\\");
        //            //string mrp = searchtxt.Text.Split('@')[1];
        //            string id = searchtxt.Text.Split('#')[1];
        //            if (orderdetailview.RowCount == 0 && orderdetailview.ColumnCount == 0)
        //            {
        //                orderdetailview.Columns.Add("productid", "productid");
        //                orderdetailview.Columns.Add("productname", "productname");
        //                orderdetailview.Columns.Add("author", "author");
        //                orderdetailview.Columns.Add("publisher", "publisher");
        //                orderdetailview.Columns.Add("price", "price");
        //                orderdetailview.Columns.Add("quantity", "quantity");
        //                orderdetailview.Columns.Add("discount", "discount");
        //                orderdetailview.Columns.Add("mrp", "mrp");
        //                orderdetailview.Columns.Add("dealerprice", "dealerprice");
        //                orderdetailview.Columns.Add("picture", "picture");

        //                dr = obj.Query("select productid,productname,detail1,detail2,price,mrp,dealerprice,picture from products where productid='" + id + "'");
        //                dr.Read();
        //                orderdetailview.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), "1", "10", dr[5].ToString(), dr[6].ToString(), dr[7].ToString());
        //                obj.closeConnection();
        //               // amounttxt.Text = inventorydatagridview.Rows[0].Cells[4].Value.ToString();
        //                //counttxt.Text = inventorydatagridview.Rows[0].Cells[5].Value.ToString();
        //            }
        //            else
        //            {
                      
        //                int amount = 0, count = 0;
        //                //for (int i = 0; i < orderdetailview.RowCount; i++)
        //                //{

        //                //    amount = int.Parse(amounttxt.Text);
        //                //    amount = amount + int.Parse(inventorydatagridview.Rows[i].Cells[4].Value.ToString());
        //                //    count = int.Parse(counttxt.Text);
        //                //    count = count + int.Parse(inventorydatagridview.Rows[i].Cells[5].Value.ToString());

        //                //}
        //                //amounttxt.Text = amount.ToString();
        //                //counttxt.Text = count.ToString();
        //            }
        //            searchtxt.Text = "";
        //            addpbtn.Enabled = true;

        //        }
        //    }
        //    catch (Exception ex) { MessageBox.Show(ex.Message); obj.closeConnection(); }
        //    Cursor = Cursors.Arrow;
        //}



        //private void orderdetailview_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        //{
        //    try
        //    {



        //        int price = 0, quant = 0;
        //        for (int i = 0; i < orderdetailview.Rows.Count; i++)
        //        {
        //            price = price + (Convert.ToInt32(orderdetailview.Rows[i].Cells["price"].Value) * Convert.ToInt32(orderdetailview.Rows[i].Cells["quantity"].Value));
        //            quant = quant + Convert.ToInt32(orderdetailview.Rows[i].Cells["quantity"].Value);
        //        }
        //        amtxt.Text = price.ToString();
        //        counttxt.Text = quant.ToString();

        //    }
        //    catch (Exception ex) { MessageBox.Show(ex.Message); }
        //}
    }
}
