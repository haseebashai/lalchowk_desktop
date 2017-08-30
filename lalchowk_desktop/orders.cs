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

namespace Veiled_Kashmir_Admin_Panel
{
    public partial class orders : Form
    {
        DBConnect obj = new DBConnect();
        String orderid,email, addressid,cmd, productid, productname, price, quantity, size,dealerprice,shipping;
        MySqlDataReader dr;
        DataTable dt,dt1,dt2,dt3;
        MySqlCommand mysqlcmd;


        private container hp = null;
     

        public orders(Form hpcopy)
        {
            hp = hpcopy as container;
            InitializeComponent();
            readorders();
        }


           private void readorders()
            {
            dr = obj.Query("SELECT customer.mail,orders.*  FROM lalchowk.orders inner join customer on customer.email=orders.email;");
            dt = new DataTable();
            dt.Load(dr);
            obj.closeConnection();
            BindingSource bsource = new BindingSource();
            bsource.DataSource = dt;
            ordergridview.DataSource = bsource;

            dr = obj.Query("select count(orderid) from orderdetails");
            dr.Read();
            orlbl.Text = dr[0].ToString();
            obj.closeConnection();

        }

        

        private void emailtxt_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = string.Format("mail LIKE '%{0}%'", emailtxt.Text);
            ordergridview.DataSource = dv;
        }


        private void orderdetails()
        {
            
            dr = obj.Query("SELECT * FROM orderdetails where orderid='"+orderid+"'");
            dt1 = new DataTable();
            dt1.Load(dr);
            obj.closeConnection();
            BindingSource bsource = new BindingSource();
            bsource.DataSource = dt1;
            orderdetailview.DataSource = bsource;
            
            orderdetailview.Visible = true;
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
        {
            DialogResult dr = MessageBox.Show("Sure you want to confirm and print the receipt ?", "Confirm", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                cmd = "update orders set status='Shipped' where orderid='" + orderlbl.Text + "'";
                obj.nonQuery(cmd);
                dpnl.Visible = false;
                orderdetailview.Visible = false;
                
            }

            receipt rc = new receipt();
            rc.ShowDialog();
            readorders();


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
           catch(Exception ex)
           {
                MessageBox.Show(ex.ToString());
                
           }
            obj.closeConnection();
        }

        private void readproduct()
        {
            dr = obj.Query("SELECT productid FROM orderdetails where orderid='" + orderid + "'");
            dt2 = new DataTable();
            dt2.Columns.Add("productid", typeof(String));
            dt2.Load(dr);
            obj.closeConnection();
            proid.DisplayMember = "productid";
            proid.DataSource = dt2;

            dr = obj.Query("SELECT productname FROM orderdetails where orderid='" + orderid + "'");
            dt3 = new DataTable();
            dt3.Columns.Add("productname", typeof(String));
            dt3.Load(dr);
            obj.closeConnection();
            proname.DisplayMember = "productname";
            proname.DataSource = dt3;

            dr = obj.Query("select sum(price) from orderdetails where orderid='" + orderid + "'");
            dr.Read();
            amountlbl.Text = dr[0].ToString();
            obj.closeConnection();
        }
           

        private void ordergridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
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
                orderlbl.Text = orderid;
                dpnl.Visible = true;
               
           //     readaddress();
                orderdetails();
                readproduct();
            }
            Cursor = Cursors.Arrow;
        }

        /*      private void addevbtn_Click(object sender, EventArgs e)
              {
                  if (nametxt.Text.Contains("'") || nametxt.Text.Contains("\\") || loctxt.Text.Contains("'") || loctxt.Text.Contains("\\"))
                      MessageBox.Show("Details cannot contain ' & \\");
                  else
                  {
                      if (eventend.Value < eventstart.Value)
                      {
                          inclble.Text = "The event can't end before it starts.";
                          inclble.Visible = true;
                      }
                      else
                      {
                          if (nametxt.Text != "" && loctxt.Text != "")
                          {
                              cmd = "Insert into events(name, location, eventstart, eventend, user) values ('" + nametxt.Text + "','" + loctxt.Text + "','" + eventstart.Value.ToString("yyyy-MM-dd HH:mm") + "','" + eventend.Value.ToString("yyyy-MM-dd HH:mm") + "','" + userinfo.username + "')";
                              obj.nonQuery(cmd);
                              MessageBox.Show("Event added sucessfully.");
                              nametxt.Text = "";
                              loctxt.Text = "";
                              inclble.Visible = false;
                          }
                          else
                              inclble.Visible = true;
                      }
                  }
              }

              private void cancelbtn_Click(object sender, EventArgs e)
              {
                  nametxt.Text = "";
                  loctxt.Text = "";
                  inclble.Visible = false;
              }

              private void back_Click(object sender, EventArgs e)
              {
                  mainform mf = new mainform(hp);
                  mf.TopLevel = false;
                  hp.mainpnl.Controls.Clear();
                  hp.mainpnl.Controls.Add(mf);
                  mf.Show();
              }

              private void addeventbtn_Click(object sender, EventArgs e)
              {
                  addevpnl.Visible = true;
                  editevpnl.Visible = false;

              }

              private void eventbox_SelectedIndexChanged(object sender, EventArgs e)
              {
                  StringBuilder s = new StringBuilder(eventbox.Text);
                  s.Replace(@"\", @"\\");
                  s.Replace("'", "\\'");
                  dr = obj.Query("select * from events where name='" + s + "'");
                  dr.Read();
                  editeventtxt.Text = dr[1].ToString();
                  editeventloctxt.Text = dr[2].ToString();
                  userlbl.Text = "by " + dr[5].ToString();
                  editpnl.Visible = true;
                  obj.closeConnection();
              }



              private void editcancelbtn_Click(object sender, EventArgs e)
              {
                  editeventtxt.Text = "";
                  editeventloctxt.Text = "";
              }

              private void rvmevbtn_Click(object sender, EventArgs e)
              {
                  StringBuilder s = new StringBuilder(eventbox.Text);
                  s.Replace(@"\", @"\\");
                  s.Replace("'", "\\'");
                  cmd = ("delete from events where name= '" + s + "'");
                  obj.nonQuery(cmd);
                  MessageBox.Show("selected Event removed sucessfully.");
               //   readevents();
              }

              private void editeventbtn_Click(object sender, EventArgs e)
              {
                  addevpnl.Visible = false;
                  editevpnl.Visible = true;
            //      readevents();
              }



              private void events_Load(object sender, EventArgs e)
              {

                  eventstart.Format = DateTimePickerFormat.Custom;
                  eventstart.CustomFormat = "MM/dd/yyyy hh:mm";
                  eventend.Format = DateTimePickerFormat.Custom;
                  eventend.CustomFormat = "MM/dd/yyyy hh:mm";


              }


             */
    }
}
