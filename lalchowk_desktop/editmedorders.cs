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

namespace Modest_Attires
{
    public partial class editmedorders : Form
    {
        DBConnect obj = new DBConnect();
        MySqlDataReader dr;
        string id;
        MySqlConnection conn = new MySqlConnection("SERVER = 182.50.133.78; DATABASE=lalchowk;USER=lalchowk;PASSWORD=Lalchowk@123uzmah");
        MySqlDataAdapter adap;
        DataTable dt;
        MySqlCommand cmd;


        public editmedorders(string orderid)
        {
            InitializeComponent();
            id = orderid;
           
            BackgroundWorker orderload = new BackgroundWorker();
            orderload.DoWork += Orderload_DoWork;
            orderload.RunWorkerCompleted += Orderload_RunWorkerCompleted;
            orderload.RunWorkerAsync(orderid);
            titlelbl.Text = "Edit Medicine order for ID: " + orderid;


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
               
                shipdttxt.Text = arg[13] as string;
                deldttxt.Text = arg[14] as string;
                string transit = arg[15] as string;
                altcontxt.Text = arg[16] as string;
                dptxt.Text= arg[17] as string;
                msgtxt.Text= arg[18] as string;


                if (transit == "False")
                {
                    transitbox.Checked = false;
                }
                else if (transit == "True")
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
                }
                else if (ptype == "Cash on Delivery")
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

               


            }
            catch (Exception ex)
            {
                obj.closeConnection();
                conn.Close();
                MessageBox.Show(ex.Message);
                updbtn.Text = "Please Reload.";
                updbtn.Enabled = false;
              


            }
        }

        private void Orderload_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string orderid = e.Argument as string;

                dr = obj.Query("select amount,shipping,name,address1,address2,pincode,contact,city,status,itemcount,deliveryguy,paymenttype,paymentconfirmed,shipdate,deliverdate,in_transit,alternate_contact,dp,msg from medorders where orderid='" + orderid + "'");
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
                string sdate = dr[13].ToString();
                string ddate = dr[14].ToString();
                string transit = dr[15].ToString();
                string altcon = dr[16].ToString();
                string dp = dr[17].ToString();
                string msg = dr[18].ToString();


                obj.closeConnection();

                object[] arg = { amount, shipping, name, add1, add2, pin, con, city, status, count, dguy, ptype, pconf, sdate, ddate, transit, altcon,dp,msg };

                e.Result = arg;

            }
            catch
            {
                obj.closeConnection();
                conn.Close();
            }
        }

        private void updbtn_Click(object sender, EventArgs e)
        {
            string pconf = "", transit = "";
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
                        string cmd = "update medorders set amount='" + amtxt.Text + "',shipping='" + shiptxt.Text + "',name='" + nametxt.Text + "',address1='" + add1txt.Text + "'" +
                        ",address2='" + add2txt.Text + "',pincode='" + pintxt.Text + "',contact='" + contxt.Text + "',city='" + citytxt.Text + "',status='" + statustxt.Text + "'" +
                        ",itemcount='" + counttxt.Text + "',deliveryguy='" + dguytxt.Text + "',paymenttype='" + ptypebox.Text + "',paymentconfirmed='" + pconf
                        + "',deliverdate=" + date + ",in_transit='" + transit + "',alternate_contact='" + altcontxt.Text + "',dp='"+dptxt.Text+"',msg='"+msgtxt.Text+"' where orderid='" + id + "'";
                        obj.nonQuery(cmd);
                    }
                    else
                    {


                        string date = Convert.ToDateTime(deldttxt.Text).ToString("yyyy-MM-dd HH:mm:ss tt");
                        string cmd = "update medorders set amount='" + amtxt.Text + "',shipping='" + shiptxt.Text + "',name='" + nametxt.Text + "',address1='" + add1txt.Text + "'" +
                            ",address2='" + add2txt.Text + "',pincode='" + pintxt.Text + "',contact='" + contxt.Text + "',city='" + citytxt.Text + "',status='" + statustxt.Text + "'" +
                            ",itemcount='" + counttxt.Text + "',deliveryguy='" + dguytxt.Text + "',paymenttype='" + ptypebox.Text + "',paymentconfirmed='" + pconf
                            + "',deliverdate='" + date + "',in_transit='" + transit + "',alternate_contact='" + altcontxt.Text + "',dp='" + dptxt.Text + "',msg='" + msgtxt.Text + "' where orderid='" + id + "'";
                        obj.nonQuery(cmd);



                    }

                    Cursor = Cursors.Arrow;
                   
                    MessageBox.Show("Updated.");
                }


            }
            catch (Exception ex)
            {
                Cursor = Cursors.Arrow;
                obj.closeConnection();
                MessageBox.Show(ex.Message);
            }
        }

        private void pcybox_CheckedChanged(object sender, EventArgs e)
        {
            if (pcybox.Checked)
                pcnbox.Checked = false;
        }

        private void pcnbox_CheckedChanged(object sender, EventArgs e)
        {
            if (pcnbox.Checked)
                pcybox.Checked = false;
        }

        private void deldttxt_TextChanged(object sender, EventArgs e)
        {
            deldttxt.MaxLength = 10;
        }
    }
}
