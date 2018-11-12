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
                }else if(ptype=="Cash on Delivery")
                {
                    ptypebox.SelectedIndex = 1;
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
               
                dr = obj.Query("select amount,shipping,name,address1,address2,pincode,contact,city,status,itemcount,deliveryguy,paymenttype,paymentconfirmed,shipdate,deliverdate from orders where orderid='" + orderid + "'");
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
                obj.closeConnection();

               adap = new MySqlDataAdapter("SELECT * FROM orderdetails where orderid='" + orderid + "'", conn);
               dt = new DataTable();
                adap.Fill(dt);
                conn.Close();
                BindingSource bsource = new BindingSource();
                bsource.DataSource = dt;


                object[] arg = {amount,shipping,name,add1,add2,pin,con,city,status,count,dguy,ptype,pconf,bsource,sdate,ddate};
              
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
            string pconf= "";
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
                    string date = Convert.ToDateTime(deldttxt.Text).ToString("yyyy-dd-MM");
                    string cmd = "update orders set amount='" + amtxt.Text + "',shipping='" + shiptxt.Text + "',name='" + nametxt.Text + "',address1='" + add1txt.Text + "'" +
                        ",address2='" + add2txt.Text + "',pincode='" + pintxt.Text + "',contact='" + contxt.Text + "',city='" + citytxt.Text + "',status='"+statustxt.Text+"'"+
                        ",itemcount='"+counttxt.Text+"',deliveryguy='"+dguytxt.Text+"',paymenttype='"+ptypebox.Text+"',paymentconfirmed='"+pconf
                        +"',deliverdate='"+date+"' where orderid='" + id + "'";
                    obj.nonQuery(cmd);
                    Cursor = Cursors.Arrow;
                    update = true;
                    MessageBox.Show("Updated.");
                }
              

            }
            catch
            {
                Cursor = Cursors.Arrow;
                obj.closeConnection();
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
    }
}
