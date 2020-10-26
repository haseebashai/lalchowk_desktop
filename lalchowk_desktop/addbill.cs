using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Veiled_Kashmir_Admin_Panel
{
    public partial class addbill : Form
    {
        DBConnect obj = new DBConnect();
        MySqlCommand mysqlcmd, drcmd;
        string cmd,cname;
        MySqlConnection aconn = new MySqlConnection("SERVER=182.50.133.78;DATABASE=lalchowk_ac;USER=lalchowkac;PASSWORD=Lalchowk@123uzmah");
        MySqlDataReader dr;
        DataTable dt1;



        public addbill(string orderlbl, string email, string amount,string contact,string shipping,string name)
        {
            InitializeComponent();
            otxt.Text = orderlbl;
            contacttxt.Text = contact;
            cname = name;
            addprobtn.Enabled = false;

            BackgroundWorker bill = new BackgroundWorker();
            bill.DoWork += (o, a) =>
            {
                try
                {
                    aconn.Open();
                    drcmd = new MySqlCommand("select count(orderid) from dealing where orderid='" + orderlbl + "'", aconn);
                    dr = drcmd.ExecuteReader();
                    dr.Read();
                    int count = int.Parse(dr[0].ToString());
                    aconn.Close();
                    a.Result = count;
                }catch(Exception ex) { MessageBox.Show(ex.Message); aconn.Close(); }
            };
            bill.RunWorkerCompleted += (o, b) =>
            {
                try
                {
                    int count = (int)b.Result;

                    if (count >0)
                    {
                        billlbl.Visible = true;
                    }
                    else { billlbl.Visible = false; }
                }
                catch(Exception ex) { MessageBox.Show(ex.Message); }
            };
            bill.RunWorkerAsync();


            BackgroundWorker orderdetails = new BackgroundWorker();
            orderdetails.DoWork += (o, a) => 
            {
                try
                {

                    dr = obj.Query("SELECT orderdetails.*,products.supplierid,suppliers.name FROM orderdetails LEFT JOIN products ON (products.productid=orderdetails.productid) left join suppliers on (suppliers.supplierid=products.supplierid) where orderid='" + orderlbl + "'");
                    dt1 = new DataTable();
                    dt1.Load(dr);
                    obj.closeConnection();
                    BindingSource bsource1 = new BindingSource();
                    bsource1.DataSource = dt1;

                    //dr = obj.Query("select distinct concat(supplierid,':  ',name) as name from suppliers");
                    //DataTable dt = new DataTable();
                    //dt.Columns.Add("name", typeof(String));
                    //dt.Load(dr);
                    //obj.closeConnection();
                    //supbox.DataSource = dt;
                   



                    a.Result = bsource1;



                }
                catch
                {
                    obj.closeConnection();
                }


            };
            orderdetails.RunWorkerCompleted += (o, b) => 
            {
                try
                {
                    loadinglbl.Visible = false;
                    BindingSource bsource1 = b.Result as BindingSource;
                    orderdetailview.DataSource = bsource1;
                    orderdetailview.Columns["orderdetailid"].Visible = false;
                    orderdetailview.Columns["picture"].Visible = false;
                    orderdetailview.Columns["size"].Visible = false;
                    //supbox.DisplayMember = "name";
                    //supbox.Enabled = true;
                    orderdetailview.Visible = true;
                    addprobtn.Enabled = true;
                    tltlbl.Visible = true;
                    plbl.Visible = true;


                }
                catch { }
            };

            orderdetails.RunWorkerAsync();



            utxt.Text = email;
            int total = int.Parse(amount);
            atxt.Text = total.ToString();
            shiptxt.Text = shipping;

            //proidtxt.Text = productid;
            //pronametxt.Text = productname;
            //sizetxt.Text = size;
            //counttxt.Text = quantity;
            //try
            //{
            //    int am = int.Parse(price) * int.Parse(counttxt.Text);
            //    amounttxt.Text = am.ToString();
            //    int dp = int.Parse(dealerprice) * int.Parse(counttxt.Text);
            //    dptxt.Text = dp.ToString();
            //}catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message.ToString());
            //}

        }

        private int calculate(int price, int mrp, int dp)
        {
            return price;
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void billaddbtn_Click(object sender, EventArgs e)
        {
           
            if (!Regex.IsMatch(dtxt.Text, @"^([0-9-]+)$") && dtxt.Text != "" || dtxt.Text == string.Empty)
            {

                MessageBox.Show("Please enter date in the following format DD-MM-YYYY");

            }
            else
            {
                try
                {


                    Cursor = Cursors.WaitCursor;
                    string date = Convert.ToDateTime(dtxt.Text).ToString("yyyy-MM-dd HH:mm:ss tt");
                    cmd = "update orders set status='Delivered', deliverdate='" + date + "', in_transit='0' where orderid='" + otxt.Text + "'";
                    obj.nonQuery(cmd);
                    obj.closeConnection();

                    aconn.Open();
                    mysqlcmd = new MySqlCommand("insert into billing(`orderid`, `user`, `amount`,`deliverydate`,`billno`) values ('" + otxt.Text + "','" + utxt.Text + "','" + atxt.Text + "','" + dtxt.Text + "','bill" + btxt.Text + "')", aconn);
                    mysqlcmd.ExecuteNonQuery();
                    mysqlcmd = new MySqlCommand("insert into deliveries(`orderid`, `email`, `amount`,`status`,`date`,`contact`,`shipping`) values ('" + otxt.Text + "','" + utxt.Text + "','" + atxt.Text + "','Delivered','" + dtxt.Text + "','" + contacttxt.Text + "','" + shiptxt.Text + "')", aconn);
                    mysqlcmd.ExecuteNonQuery();
                    aconn.Close();

                    MessageBox.Show("Bill added.");

                }
                catch (Exception ex)
                {
                    aconn.Close();
                    MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
                }

                //DialogResult dgr = MessageBox.Show("Do you want to send feedback SMS?", "Confirm", MessageBoxButtons.YesNo);
                //{
                //    if (dgr == DialogResult.Yes)
                //    {
                //        dialogcontainer dg = new dialogcontainer();
                //        sendsms sms = new sendsms(contacttxt.Text, "", "");
                //        sms.TopLevel = false;
                //        dg.dialogpnl.Controls.Add(sms);
                //        dg.lbl.Text = "Send SMS";
                //        dg.Text = "Send SMS";
                //        dg.Size = new Size(600, 600);
                //        sms.numbertxt.Font = new Font("MS Sans Serif", 9, FontStyle.Regular);
                //        sms.smstxt.Text = "Dear " + cname + ", We would love to hear from you regarding your recent purchase and our services. Please click on the following link and leave your feedback. https://bit.ly/GetLalchowk";
                //        sms.smsnpnl.Visible = false;
                //        sms.txtpnl.Location = new Point(35, 10);
                //        dg.Show();
                //        sms.Show();


                        //dialogcontainer dg = new dialogcontainer();
                        //promomail pm = new promomail(utxt.Text, dg);
                        //pm.TopLevel = false;
                        //dg.Size = new Size(700, 715);
                        //pm.epnl.Location = new Point(-300, 1);
                        //pm.attachtxt.Visible = true;
                        //pm.elistlbl.Text = "";
                        //pm.checkattach.Checked = true;
                        //dg.dialogpnl.Controls.Add(pm);
                        //pm.loadingdg();
                        //dg.Text = "Send Email";

                        //dg.Show();

                        //pm.Show();
                    //}
                    //else
                    //{
                    //    Close();
                    //}
              //  }
                Cursor = Cursors.Arrow;
                Close();
            }
        }

        private void addprobtn_Click(object sender, EventArgs e)
        {

            Cursor = Cursors.WaitCursor;

            string payment="";
            try
            {
                if (!Regex.IsMatch(pickuptxt.Text, @"^([0-9-]+)$") && pickuptxt.Text != "" || pickuptxt.Text==string.Empty)
                {

                    MessageBox.Show("Please enter date in the following format DD-MM-YYYY");

                }
                else {
                    if (yes.Checked == false && no.Checked == false)
                    {
                        MessageBox.Show("Please select payment type.", "Error!");
                    }
                    else
                    {

                        if (yes.Checked)
                        {
                            payment = "1";
                        }
                        else if (no.Checked)
                        {
                            payment = "0";
                        }


                        int count = int.Parse(orderdetailview.RowCount.ToString());

                        for (int i = 0; i < count; i++)
                        {

                            try
                            {
                                StringBuilder pname = new StringBuilder(orderdetailview.Rows[i].Cells[3].Value.ToString());
                                pname.Replace(@"'", "\\'").Replace(@"\", "\\");

                                aconn.Open();
                                mysqlcmd = new MySqlCommand("insert into dealing(`orderid`,`productid`,`productname`,`count`,`amount`,"
                                    + "`dealerprice`,`pickupdate`,`paymentdone`,`paymentdate`,`comments`,`supplierid`,`suppliername`)values ('" + orderdetailview.Rows[i].Cells[1].Value.ToString() + //orderid
                                    "','" + orderdetailview.Rows[i].Cells[2].Value.ToString() +  //proid
                                    "','" + pname + //proname
                                    "','" + orderdetailview.Rows[i].Cells[5].Value.ToString() +  //quantity
                                    "','" + orderdetailview.Rows[i].Cells[4].Value.ToString() +  //price
                                    "','" + orderdetailview.Rows[i].Cells[8].Value.ToString() +  //dp
                                    "','" + pickuptxt.Text +
                                    "','" + payment +
                                    "','" + paymenttxt.Text +
                                    "','" + commentstxt.Text + "','" + orderdetailview.Rows[i].Cells[11].Value.ToString() +  //supid
                                    "','" + orderdetailview.Rows[i].Cells[12].Value.ToString() + "')", aconn);  //supname
                                mysqlcmd.ExecuteNonQuery();
                                aconn.Close();

                                string cmd = "update products set dealerprice= '" + orderdetailview.Rows[i].Cells[8].Value.ToString() + "' where productid='" + orderdetailview.Rows[i].Cells[2].Value.ToString() + "' ";
                                obj.nonQuery(cmd);
                                obj.closeConnection();
                             
                            }
                            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); obj.closeConnection(); aconn.Close(); }
                        }
                        billaddbtn_Click(null, null);
                    }
                 //   MessageBox.Show("Product bill added.");
                    addprobtn.Enabled = false;
                }
                //Cursor = Cursors.WaitCursor;
                //if (supidtxt.Text == "")
                //{
                //    MessageBox.Show("Add Supplier first.");
                //}
                //else
                //{
                //    StringBuilder pname = new StringBuilder(pronametxt.Text);
                //    pname.Replace(@"'", "\\'").Replace(@"\", "\\");

                //    if (yes.Checked)
                //    {
                //        aconn.Open();
                //        mysqlcmd = new MySqlCommand("insert into dealing(`supplierid`, `suppliername`, `productid`,`productname`,`size`,`count`,`amount`,`dealerprice`,`pickupdate`,`paymentdone`,`paymentdate`,`comments`) values ('" + supidtxt.Text + "','" + supnametxt.Text + "','" + proidtxt.Text + "','" + pname + "','" + sizetxt.Text + "','" + counttxt.Text + "','" + amounttxt.Text + "','" + dptxt.Text + "','" + pickuptxt.Text + "','1','" + paymenttxt.Text + "','" + commentstxt.Text + "')", aconn);
                //        mysqlcmd.ExecuteNonQuery();
                //        aconn.Close();
                //    }
                //    else
                //    {
                //        aconn.Open();
                //        mysqlcmd = new MySqlCommand("insert into dealing(`supplierid`, `suppliername`, `productid`,`productname`,`size`,`count`,`amount`,`dealerprice`,`pickupdate`,`paymentdone`,`paymentdate`,`comments`) values ('" + supidtxt.Text + "','" + supnametxt.Text + "','" + proidtxt.Text + "','" + pname + "','" + sizetxt.Text + "','" + counttxt.Text + "','" + amounttxt.Text + "','" + dptxt.Text + "','" + pickuptxt.Text + "','0','" + paymenttxt.Text + "','" + commentstxt.Text + "')", aconn);
                //        mysqlcmd.ExecuteNonQuery();
                //        aconn.Close();
                //    }
                //    MessageBox.Show("Product bill Added.");
                //}


            }
            catch (Exception ex)
            {
                aconn.Close();
                MessageBox.Show("Something happened, please try again.\n\n" + ex.ToString(), "Error!");
            }
            Cursor = Cursors.Arrow;
        }
    

        private void yes_CheckedChanged(object sender, EventArgs e)
        {
            if (yes.Checked)
                no.Checked = false;
        }

        private void no_CheckedChanged(object sender, EventArgs e)
        {
            if (no.Checked)
                yes.Checked = false;
        }

      

        private void orderdetailview_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {

                //  DataGridViewRow row = this.orderdetailview.Rows[e.RowIndex];


                int price = 0, mrp = 0, dp = 0;
                for (int i = 0; i < orderdetailview.Rows.Count; i++)
                {
                    // MessageBox.Show(price.ToString() + " " + row.Cells["price"].Value.ToString() + " " + row.Cells["quantity"].Value.ToString());
                    price = price + (Convert.ToInt32(orderdetailview.Rows[i].Cells["price"].Value) * Convert.ToInt32(orderdetailview.Rows[i].Cells["quantity"].Value));
                    mrp = mrp + (Convert.ToInt32(orderdetailview.Rows[i].Cells["mrp"].Value) * Convert.ToInt32(orderdetailview.Rows[i].Cells["quantity"].Value));
                    dp = dp + (Convert.ToInt32(orderdetailview.Rows[i].Cells["dealerprice"].Value) * Convert.ToInt32(orderdetailview.Rows[i].Cells["quantity"].Value));

                }
                pricelbl.Text = price.ToString();
                mrplbl.Text = mrp.ToString();
                dplbl.Text = dp.ToString();
                profitlbl.Text = (int.Parse(pricelbl.Text)-int.Parse(dplbl.Text)).ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void orderdetailview_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                //  DataGridViewRow row = this.orderdetailview.Rows[e.RowIndex];


                int price = 0, mrp = 0, dp = 0;
                for (int i = 0; i < orderdetailview.Rows.Count; i++)
                {
                    // MessageBox.Show(price.ToString() + " " + row.Cells["price"].Value.ToString() + " " + row.Cells["quantity"].Value.ToString());
                    price = price + (Convert.ToInt32(orderdetailview.Rows[i].Cells["price"].Value) * Convert.ToInt32(orderdetailview.Rows[i].Cells["quantity"].Value));
                    mrp = mrp + (Convert.ToInt32(orderdetailview.Rows[i].Cells["mrp"].Value) * Convert.ToInt32(orderdetailview.Rows[i].Cells["quantity"].Value));
                    dp = dp + (Convert.ToInt32(orderdetailview.Rows[i].Cells["dealerprice"].Value) * Convert.ToInt32(orderdetailview.Rows[i].Cells["quantity"].Value));

                }
                pricelbl.Text = price.ToString();
                mrplbl.Text = mrp.ToString();
                dplbl.Text = dp.ToString();
                profitlbl.Text = (int.Parse(pricelbl.Text) - int.Parse(dplbl.Text)).ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void calbtn_Click(object sender, EventArgs e)
        {
            try
            {
                readpercent();
            }
            catch { }
        }

        private void readpercent()
        {

            if (int.Parse(odistxt.Text) < 10)
            {
                odistxt.Text = 0 + odistxt.Text;
            }

            string sub = "0." + odistxt.Text;

            double sub2 = double.Parse(sub);

            double n = double.Parse(mrptxt.Text);

            n = n - (n * sub2);
            pricetxt.Text = n.ToString();

        }

        private void odistxt_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Enter)
                {
                    readpercent();
                }
            }
            catch { }
        }

        private void mrptxt_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Enter)
                {
                    readpercent();
                }
            }
            catch { }
        }

        private void pickuptxt_TextChanged(object sender, EventArgs e)
        {
            paymenttxt.Text = pickuptxt.Text;
            dtxt.Text = pickuptxt.Text;
        }

        private void sendmailbtn_Click(object sender, EventArgs e)
        {
            dialogcontainer dg = new dialogcontainer();
            promomail pm = new promomail(utxt.Text, dg,"","");
            pm.TopLevel = false;
            dg.Size = new Size(700, 715);
            pm.epnl.Location = new Point(-300, 1);
            pm.attachtxt.Visible = true;
            pm.elistlbl.Text = "";
            pm.checkattach.Checked = true;
            dg.dialogpnl.Controls.Add(pm);
            pm.loadingdg();
            dg.Text = "Send Email";

            dg.Show();

            pm.Show();
        }
    }
}
