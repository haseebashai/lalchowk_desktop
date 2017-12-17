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

            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Orderload_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string orderid = e.Argument as string;
               
                dr = obj.Query("select amount,shipping,name,address1,address2,pincode,contact,city from orders where orderid='" + orderid + "'");
                dr.Read();
                string amount = dr[0].ToString();
                string shipping = dr[1].ToString();
                string name = dr[2].ToString();
                string add1 = dr[3].ToString();
                string add2 = dr[4].ToString();
                string pin = dr[5].ToString();
                string con = dr[6].ToString();
                string city = dr[7].ToString();
                obj.closeConnection();
                object[] arg = {amount,shipping,name,add1,add2,pin,con,city};
              
                e.Result = arg;

            }catch
            {
                obj.closeConnection();
            }
        }

        private void updbtn_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dgr = MessageBox.Show("Update details for this OrderID: " + id + " ?", "Confirm", MessageBoxButtons.YesNo);
                if (dgr == DialogResult.Yes)
                {
                    Cursor = Cursors.WaitCursor;

                    string cmd = "update orders set amount='" + amtxt.Text + "',shipping='" + shiptxt.Text + "',name='" + nametxt.Text + "',address1='" + add1txt.Text + "'" +
                        ",address2='" + add2txt.Text + "',pincode='" + pintxt.Text + "',contact='" + contxt.Text + "',city='" + citytxt.Text + "' where orderid='" + id + "'";
                    obj.nonQuery(cmd);
                    Cursor = Cursors.Arrow;
                    MessageBox.Show("Updated.");
                }
              

            }
            catch
            {
                Cursor = Cursors.Arrow;
                obj.closeConnection();
            }
        }
    }
}