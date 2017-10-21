using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Veiled_Kashmir_Admin_Panel
{
    public partial class addbill : Form
    {
        DBConnect obj = new DBConnect();
        MySqlCommand mysqlcmd, drcmd;
        string cmd;
        MySqlConnection aconn = new MySqlConnection("SERVER=182.50.133.78;DATABASE=lalchowk_ac;USER=lalchowkac;PASSWORD=Lalchowk@123uzmah");
        MySqlDataReader dr;



        public addbill(string orderlbl, string email, string amount, string productid, string productname, string price, string quantity, string size, string dealerprice, string shipping)
        {
            InitializeComponent();
            otxt.Text = orderlbl;
            utxt.Text = email;
            int total = int.Parse(amount) + int.Parse(shipping);
            atxt.Text = total.ToString();
            proidtxt.Text = productid;
            pronametxt.Text = productname;
            sizetxt.Text = size;
            counttxt.Text = quantity;
            int am = int.Parse(price) * int.Parse(counttxt.Text);
            amounttxt.Text = am.ToString();
            int dp = int.Parse(dealerprice) * int.Parse(counttxt.Text);
            dptxt.Text = dp.ToString();

        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void billaddbtn_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = "update orders set status='Delivered' where orderid='" + otxt.Text + "'";
                obj.nonQuery(cmd);
                obj.closeConnection();

                aconn.Open();
                mysqlcmd = new MySqlCommand("insert into billing(`orderid`, `user`, `amount`,`deliverydate`,`billno`) values ('" + otxt.Text + "','" + utxt.Text + "','" + atxt.Text + "','" + dtxt.Text + "','bill" + btxt.Text + "')", aconn);
                mysqlcmd.ExecuteNonQuery();
                mysqlcmd = new MySqlCommand("insert into deliveries(`orderid`, `email`, `amount`,`status`,`date`) values ('" + otxt.Text + "','" + utxt.Text + "','" + atxt.Text + "','Delivered','" + dtxt.Text + "')", aconn);
                mysqlcmd.ExecuteNonQuery();
                aconn.Close();

                MessageBox.Show("Bill added.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something happened, please try again.\n\n\n" + ex.ToString());
            }
            DialogResult dgr = MessageBox.Show("Do you want to send confirmation mail with e-bill?", "Confirm", MessageBoxButtons.YesNo);
            {
                if (dgr == DialogResult.Yes)
                {
                    dialogcontainer dg = new dialogcontainer();
                    promomail pm = new promomail(utxt.Text, dg);
                    pm.TopLevel = false;
                    dg.Size = new Size(700, 715);
                    pm.epnl.Location = new Point(-300, 1);
                    pm.attachtxt.Visible = true;
                    pm.elistlbl.Text = "";

                    dg.dialogpnl.Controls.Add(pm);
                    pm.loadingdg();
                    dg.Text = "Send Email";

                    dg.Show();

                    pm.Show();
                }
                else
                {
                    Close();
                }
            }

        }

        private void addprobtn_Click(object sender, EventArgs e)
        { try
            {
                if (supidtxt.Text == "")
                {
                    MessageBox.Show("Add Supplier first.");
                }
                else
                {
                    if (yes.Checked)
                    {
                        aconn.Open();
                        mysqlcmd = new MySqlCommand("insert into dealing(`supplierid`, `suppliername`, `productid`,`productname`,`size`,`count`,`amount`,`dealerprice`,`pickupdate`,`paymentdone`,`paymentdate`,`comments`) values ('" + supidtxt.Text + "','" + supnametxt.Text + "','" + proidtxt.Text + "','" + pronametxt.Text + "','" + sizetxt.Text + "','" + counttxt.Text + "','" + amounttxt.Text + "','" + dptxt.Text + "','" + pickuptxt.Text + "','1','" + paymenttxt.Text + "','" + commentstxt.Text + "')", aconn);
                        mysqlcmd.ExecuteNonQuery();
                        aconn.Close();
                    }
                    else
                    {
                        aconn.Open();
                        mysqlcmd = new MySqlCommand("insert into dealing(`supplierid`, `suppliername`, `productid`,`productname`,`size`,`count`,`amount`,`dealerprice`,`pickupdate`,`paymentdone`,`paymentdate`,`comments`) values ('" + supidtxt.Text + "','" + supnametxt.Text + "','" + proidtxt.Text + "','" + pronametxt.Text + "','" + sizetxt.Text + "','" + counttxt.Text + "','" + amounttxt.Text + "','" + dptxt.Text + "','" + pickuptxt.Text + "','0','" + paymenttxt.Text + "','" + commentstxt.Text + "')", aconn);
                        mysqlcmd.ExecuteNonQuery();
                        aconn.Close();
                    }
                    MessageBox.Show("Product bill Added.");
                }


            }
            catch (Exception)
            {
                MessageBox.Show("Something happened, please try again");
            }
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

        private void sendmailbtn_Click(object sender, EventArgs e)
        {
            dialogcontainer dg = new dialogcontainer();
            promomail pm = new promomail(utxt.Text, dg);
            pm.TopLevel = false;
            dg.Size = new Size(700, 715);
            pm.epnl.Location = new Point(-300, 1);
            pm.attachtxt.Visible = true;
            pm.elistlbl.Text = "";

            dg.dialogpnl.Controls.Add(pm);
            pm.loadingdg();
            dg.Text = "Send Email";

            dg.Show();

            pm.Show();
        }

        private void addsupbtn_Click(object sender, EventArgs e)
        {try { 
            dr = obj.Query("SELECT name,supplierid from suppliers where supplierid in (select supplierid FROM lalchowk.products where productid='" + proidtxt.Text + "');");
            dr.Read();
            supidtxt.Text = dr[1].ToString();
            supnametxt.Text = dr[0].ToString();
            obj.closeConnection();
        }
            catch (Exception)
            {
                MessageBox.Show("Something happened, please try again");
            }
}

       
        
    }
}
