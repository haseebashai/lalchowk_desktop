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
        DataTable dt1;



        public addbill(string orderlbl, string email, string amount)
        {
            InitializeComponent();
            otxt.Text = orderlbl;
            addprobtn.Enabled = false;
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

                    dr = obj.Query("select distinct concat(supplierid,':  ',name) as name from suppliers");
                    DataTable dt = new DataTable();
                    dt.Columns.Add("name", typeof(String));
                    dt.Load(dr);
                    obj.closeConnection();
                    supbox.DataSource = dt;
                   



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
                    supbox.DisplayMember = "name";
                    supbox.Enabled = true;
                    orderdetailview.Visible = true;
                    addprobtn.Enabled = true;
                }catch { }
            };

            orderdetails.RunWorkerAsync();



            utxt.Text = email;
            int total = int.Parse(amount);
            atxt.Text = total.ToString();

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

        private void closebtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void billaddbtn_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
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
                aconn.Close();
                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
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
                    pm.checkattach.Checked = true;
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
            Cursor = Cursors.Arrow;

        }

        private void addprobtn_Click(object sender, EventArgs e)
        {

            Cursor = Cursors.WaitCursor;
            try
            {
                string payment;
                if (yes.Checked)
                {
                    payment = "'1'";
                }
                else
                {
                    payment = "'0'";
                }

                int count = int.Parse(orderdetailview.RowCount.ToString());

                for (int i = 0; i < count; i++)
                {
                    StringBuilder pname = new StringBuilder(orderdetailview.Rows[i].Cells[3].Value.ToString());
                    pname.Replace(@"'", "\\'").Replace(@"\", "\\");

                    aconn.Open();
                    mysqlcmd = new MySqlCommand("insert into dealing(`orderid`,`productid`,`productname`,`count`,`amount`," +
                        "`dealerprice`,`pickupdate`,`paymentdone`,`paymentdate`,`comments`,`supplierid`,`suppliername`)" +
                        "values ('" + orderdetailview.Rows[i].Cells[1].Value.ToString() + //orderid
                        "','" + orderdetailview.Rows[i].Cells[2].Value.ToString() +  //proid
                        "','" + pname + //proname
                        "','" + orderdetailview.Rows[i].Cells[5].Value.ToString() +  //quantity
                        "','" + orderdetailview.Rows[i].Cells[4].Value.ToString() +  //price
                        "','" + orderdetailview.Rows[i].Cells[8].Value.ToString() +  //dp
                        "','" + pickuptxt.Text +
                        "'," + payment +
                        ",'" + paymenttxt.Text +
                        "','" + commentstxt.Text +
                        "','" + orderdetailview.Rows[i].Cells[11].Value.ToString() + //supid
                        "','" + orderdetailview.Rows[i].Cells[12].Value.ToString() + "'", aconn);  //supname
                    mysqlcmd.ExecuteNonQuery();
                    aconn.Close();

                }
                MessageBox.Show("Product bill Added.");

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
                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
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

        private void sendmailbtn_Click(object sender, EventArgs e)
        {
            dialogcontainer dg = new dialogcontainer();
            promomail pm = new promomail(utxt.Text, dg);
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
