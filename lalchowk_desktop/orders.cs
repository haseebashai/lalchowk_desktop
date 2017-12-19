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
        String orderid,email, addressid,cmd, productid, productname, price, quantity, size,dealerprice,shipping, filename,amount,ordervar;
        MySqlDataReader dr,dr1;
        DataTable dt,dt1,dt2,dt3;
        MySqlCommand mysqlcmd;
        MySqlDataAdapter adap;
        MySqlConnection conn =new MySqlConnection("SERVER = 182.50.133.78; DATABASE=lalchowk;USER=lalchowk;PASSWORD=Lalchowk@123uzmah");
        BindingSource bsource;
        MySqlCommandBuilder cmdbl;
        PictureBox loading = new PictureBox();

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

            dg.Show(); 
            edit.Show();
        }

        private void readorders()
        {try { 
            adap = new MySqlDataAdapter("SELECT customer.mail,orders.*  FROM lalchowk.orders inner join customer on customer.email=orders.email;",conn);
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
            orlbl.Text = ordervar;
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


        private void orderdetails()
        {
            try { 
           
        }
            catch (Exception ex)
            {
                obj.closeConnection();
                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }
        
        

        private void paymenttxt_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = string.Format("paymenttype LIKE '%{0}%'", paymenttxt.Text);
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
            if (productid == null)
                con.Visible = true;
            else
            {
                addbill ab = new addbill(orderlbl.Text, email, amountlbl.Text, productid, productname, price, quantity, size, dealerprice, shipping);
                ab.ShowDialog();
                productid = null;
            }
        }

        private void delbtn_Click(object sender, EventArgs e)
        {try { 
            DialogResult dr = MessageBox.Show("Delete order and all its details with OrderID: "+orderid+" ?", "Confirm", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                cmd = "Delete from orders where orderid='" + orderid + "'";
                obj.nonQuery(cmd);
                cmd = "Delete from orderdetails where orderid='" + orderid + "'";
                obj.nonQuery(cmd);
                MessageBox.Show("Order deleted.");
                dpnl.Visible = false;
                orderdetailview.Visible = false;
                readorders();
                orlbl.Text = ordervar;
                ordergridview.DataSource = bsource;
            }
        }
            catch (Exception ex)
            {

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }

        }

        private void orderdetailview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            con.Visible = false;
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

        private void readaddress()
        {
            try {
                dr = obj.Query("select * from addresses where addressid='" + addressid + "'");
                dr.Read();
                namelbl.Text = dr["name"].ToString();
                address1lbl.Text = dr["address1"].ToString();
                address2lbl.Text = dr["address2"].ToString();
                pinlbl.Text = dr["pincode"].ToString();
                citylbl.Text = dr["city"].ToString();
                contactlbl.Text = dr["contact"].ToString();
                

            }
            catch (Exception ex)
            {

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
            obj.closeConnection();
        }

        private void ordergridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                orderdetailview.Visible = false;
                dpnl.Visible = false;
                loadinglbl.Visible = true;

                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.ordergridview.Rows[e.RowIndex];
                    orderid = row.Cells["orderid"].Value.ToString();
                    email = row.Cells["mail"].Value.ToString();
                    shipping = row.Cells["shipping"].Value.ToString();
                    namelbl.Text = row.Cells["name"].Value.ToString();
                    address1lbl.Text = row.Cells["address1"].Value.ToString();
                    address2lbl.Text = row.Cells["address2"].Value.ToString();
                    pinlbl.Text = row.Cells["pincode"].Value.ToString();
                    citylbl.Text = row.Cells["city"].Value.ToString();
                    contactlbl.Text = row.Cells["contact"].Value.ToString();
                    string amount = row.Cells["amount"].Value.ToString();
                    int result = int.Parse(amount) + int.Parse(shipping);
                    amountlbl.Text = result.ToString();
                    orderlbl.Text = orderid;
                    proname.Items.Clear();


                    BackgroundWorker details = new BackgroundWorker();

                    details.DoWork += (o, a) =>
                    {
                        try
                        {

                            dr = obj.Query("SELECT * FROM orderdetails where orderid='" + orderid + "'");
                            dt1 = new DataTable();
                            dt1.Load(dr);
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
                        orderdetailview.Visible = true;
                        dpnl.Visible = true;
                        loadinglbl.Visible = false;

                        BindingSource bsource1 = d.Result as BindingSource;
                        orderdetailview.DataSource = bsource1;
                        orderdetailview.Visible = true;

                        int count = int.Parse(orderdetailview.RowCount.ToString());

                        for (int i = 0; i < count; i++)
                        {
                            proname.Items.Add(orderdetailview.Rows[i].Cells[0].Value.ToString() + ":   " + orderdetailview.Rows[i].Cells[3].Value.ToString());
                        }

                    };
                    while (details.IsBusy)
                        details.CancelAsync();
                    obj.closeConnection();
                    details.RunWorkerAsync();


                }

            }
            catch
            {
                obj.closeConnection();
            }
           
        }


    }
}
