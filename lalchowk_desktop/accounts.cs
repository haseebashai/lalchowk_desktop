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
    public partial class accounts : Form
    {
        DBConnect obj = new DBConnect();
        MySqlConnection con;
        MySqlCommand mysqlcmd, cmd;
        DataTable dt;
        MySqlDataReader dr,dr1;
        MySqlCommandBuilder cmdbl;
        MySqlDataAdapter adap,adap1;
        MySqlConnection aconn = new MySqlConnection("SERVER=182.50.133.78;DATABASE=lalchowk_ac;USER=lalchowkac;PASSWORD=Lalchowk@123uzmah");
        string date, month;

        private container hp = null;
        public accounts(Form hpcopy)
        {
            hp = hpcopy as container;
            InitializeComponent();
            readdetails();
            
        }

        public void readexpenses()
        {
            aconn.Open();
            adap = new MySqlDataAdapter("select * from expenses", aconn);
            dt = new DataTable();
            adap.Fill(dt);
            aconn.Close();
            BindingSource bsource = new BindingSource();
            bsource.DataSource = dt;
            accountdataview.DataSource = bsource;

            aconn.Open();
            cmd = new MySqlCommand("SELECT balance FROM lalchowk_ac.expenses order by eid desc limit 1", aconn);
            dr = cmd.ExecuteReader();
            dr.Read();
            baltxt.Text = dr[0].ToString();
            aconn.Close();
        }

        public void readmoneypool()
        {
            aconn.Open();
            adap = new MySqlDataAdapter("select * from moneypool", aconn);
            dt = new DataTable();
            adap.Fill(dt);
            aconn.Close();
            BindingSource bsource = new BindingSource();
            bsource.DataSource = dt;
            accountdataview.DataSource = bsource;
        }

        public void readbank()
        {
            aconn.Open();
            adap = new MySqlDataAdapter("select * from bankdetails", aconn);
            dt = new DataTable();
            adap.Fill(dt);
            aconn.Close();
            BindingSource bsource = new BindingSource();
            bsource.DataSource = dt;
            accountdataview.DataSource = bsource;
        }

        public void readmisc()
        {
            aconn.Open();
            adap = new MySqlDataAdapter("select * from misc", aconn);
            dt = new DataTable();
            adap.Fill(dt);
            aconn.Close();
            BindingSource bsource = new BindingSource();
            bsource.DataSource = dt;
            accountdataview.DataSource = bsource;
        }

        public void readbilling()
        {
            aconn.Open();
            adap = new MySqlDataAdapter("select * from billing", aconn);
            dt = new DataTable();
            adap.Fill(dt);
            aconn.Close();
            BindingSource bsource = new BindingSource();
            bsource.DataSource = dt;
            accountdataview.DataSource = bsource;

            aconn.Open();
            cmd = new MySqlCommand("select count(bid) from billing", aconn);
            dr = cmd.ExecuteReader();
            dr.Read();
            totallbl.Text = "Total bills: " + dr[0].ToString();
            totallbl.Visible = true;
            aconn.Close();
        }

        public void readdeliveries()
        {
            aconn.Open();
            adap = new MySqlDataAdapter("select * from deliveries", aconn);
            dt = new DataTable();
            adap.Fill(dt);
            aconn.Close();
            BindingSource bsource = new BindingSource();
            bsource.DataSource = dt;
            accountdataview.DataSource = bsource;

            aconn.Open();
            cmd = new MySqlCommand("select count(did) from deliveries", aconn);
            dr = cmd.ExecuteReader();
            dr.Read();
            totallbl.Text = "Total deliveries: " + dr[0].ToString();
            totallbl.Visible = true;
            aconn.Close();
        }

        public void readdealings()
        {
            aconn.Open();
            adap = new MySqlDataAdapter("select * from dealing", aconn);
            dt = new DataTable();
            adap.Fill(dt);
            aconn.Close();
            BindingSource bsource = new BindingSource();
            bsource.DataSource = dt;
            accountdataview.DataSource = bsource;

            aconn.Open();
            cmd = new MySqlCommand("select count(did) from dealing", aconn);
            dr = cmd.ExecuteReader();
            dr.Read();
            totallbl.Text = "Total dealings: " + dr[0].ToString();
            totallbl.Visible = true;
            aconn.Close();
        }

        
        public void readrevenue()
        {
            aconn.Open();
            adap = new MySqlDataAdapter("select * from revenue", aconn);
            dt = new DataTable();
            adap.Fill(dt);
            aconn.Close();
            BindingSource bsource = new BindingSource();
            bsource.DataSource = dt;
            accountdataview.DataSource = bsource;

            aconn.Open();
            cmd = new MySqlCommand("SELECT date FROM lalchowk_ac.deliveries ORDER BY did DESC LIMIT 1;", aconn);
            dr = cmd.ExecuteReader();
            dr.Read();
            date = dr[0].ToString();
            aconn.Close();
            month = date.Substring(3, 2);
            
        }


        private void readdetails()
        {
            aconn.Open();
            cmd = new MySqlCommand("select sum(amount)-3000 from moneypool",aconn);
            dr = cmd.ExecuteReader();
            dr.Read();
            moneylbl.Text = "Total Money pooled: Rs. " + dr[0].ToString(); 
            aconn.Close();

            aconn.Open();
            cmd = new MySqlCommand("select sum(amount) from expenses", aconn);
            dr = cmd.ExecuteReader();
            dr.Read();
            costlbl.Text = "Total Cost spent: Rs. " + dr[0].ToString();
            aconn.Close();

            aconn.Open();
            cmd = new MySqlCommand(" SELECT balance FROM expenses ORDER BY eid DESC LIMIT 1", aconn);
            dr = cmd.ExecuteReader();
            dr.Read();
            ballbl.Text = "Balance in hand: Rs. " + dr[0].ToString();
            aconn.Close();

            aconn.Open();
            cmd = new MySqlCommand(" SELECT closingbal FROM bankdetails ORDER BY bid DESC LIMIT 1", aconn);
            dr = cmd.ExecuteReader();
            dr.Read();
            banklbl.Text = "Bank balance: Rs. " + dr[0].ToString();
            aconn.Close();
        }

       
        private void expbtn_Click(object sender, EventArgs e)
        {
            readdetails();
            
            readexpenses();
            fsuptxt.Visible = false;
            fsuplbl.Visible = false;
            exppnl.Visible = true;
            moneypnl.Visible = false;
            bankpnl.Visible = false;
            miscpnl.Visible = false;
            rpnl.Visible = false;
            totallbl.Visible = false;
        }

        private void moneybtn_Click(object sender, EventArgs e)
        {
            readdetails();
            
            readmoneypool();
            fsuptxt.Visible = false;
            fsuplbl.Visible = false;
            moneypnl.Visible = true;
            exppnl.Visible = false;
            bankpnl.Visible = false;
            miscpnl.Visible = false;
            rpnl.Visible = false;
            totallbl.Visible = false;
        }

        private void bankbtn_Click(object sender, EventArgs e)
        {
            readdetails();
            
            readbank();
            fsuptxt.Visible = false;
            fsuplbl.Visible = false;
            bankpnl.Visible = true;
            moneypnl.Visible = false;
            exppnl.Visible = false;
            miscpnl.Visible = false;
            rpnl.Visible = false;
            totallbl.Visible = false;
        }

        private void miscbtn_Click(object sender, EventArgs e)
        {
            readdetails();
            
            readmisc();
            fsuptxt.Visible = false;
            fsuplbl.Visible = false;
            miscpnl.Visible = true;
            bankpnl.Visible = false;
            moneypnl.Visible = false;
            exppnl.Visible = false;
            rpnl.Visible = false;
            totallbl.Visible = false;
        }


        private void updatebtn_Click(object sender, EventArgs e)
        {
            aconn.Open();
            mysqlcmd = new MySqlCommand ("insert into expenses(`item`, `amount`, `purchasedate`,`balance`,`reason`) values ('" + itemtxt.Text + "','"+amounttxt.Text+"','"+datetxt.Text+"','"+baltxt.Text+"','"+reasontxt1.Text+"')",aconn);
            mysqlcmd.ExecuteNonQuery();
            MessageBox.Show("Entry added.");
            aconn.Close();
            itemtxt.Text = "";
            amounttxt.Text="";
            datetxt.Text = "";
            baltxt.Text = "";
            reasontxt1.Text = "";
            
            readexpenses();
            
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            aconn.Open();
            mysqlcmd = new MySqlCommand("INSERT INTO moneypool(`name`, `amount`, `pooldate`, `reason`, `entry_by`) VALUES ('"+nametxt.Text+"', '"+amounttxt2.Text+"', '"+datetxt2.Text+"', '"+reasontxt.Text+"', 'haseeb')", aconn);
            mysqlcmd.ExecuteNonQuery();
            MessageBox.Show("Entry added.");
            aconn.Close();
            nametxt.Text = "";
            amounttxt2.Text = "";
            datetxt2.Text = "";
            reasontxt.Text = "";
            readmoneypool();
        }

        private void addmbtn_Click(object sender, EventArgs e)
        {
            aconn.Open();
            mysqlcmd = new MySqlCommand("insert into misc(`name`, `amount`,`reason`) values ('" + nametxt4.Text + "','" + amounttxt4.Text + "','" + reasontxt4.Text + "')",aconn);
            mysqlcmd.ExecuteNonQuery();
            MessageBox.Show("Entry added.");
            aconn.Close();
            nametxt4.Text = "";
            amounttxt4.Text = "";
            reasontxt4.Text = "";
            readmisc();
        }

        private void addbbtn_Click(object sender, EventArgs e)
        {
            aconn.Open();
            mysqlcmd = new MySqlCommand("insert into bankdetails(`date`, `openingbal`, `closingbal`,`reason`) values ('" + datetxt3.Text + "','" + obaltxt.Text + "','" + cbaltxt.Text + "','" + reasontxt2.Text + "')",aconn);
            mysqlcmd.ExecuteNonQuery();
            MessageBox.Show("Entry added.");
            aconn.Close();
            datetxt3.Text = "";
            obaltxt.Text = "";
            cbaltxt.Text = "";
            reasontxt2.Text = "";
            readbank();

        }

        private void billbtn_Click(object sender, EventArgs e)
        {

            readdetails();
            readbilling();
            fsuptxt.Visible = false;
            fsuplbl.Visible = false;
            billpnl.Visible = true;
            dealpnl.Visible = false;           
            miscpnl.Visible = false;
            bankpnl.Visible = false;
            moneypnl.Visible = false;
            exppnl.Visible = false;
            delpnl.Visible = false;
            rpnl.Visible = false;
        }

        private void billaddbtn_Click(object sender, EventArgs e)
        {
            aconn.Open();
            mysqlcmd = new MySqlCommand("insert into billing(`orderid`, `user`, `amount`,`deliverydate`,`billno`) values ('" + otxt.Text + "','" + utxt.Text + "','" + atxt.Text + "','" + dtxt.Text + "','bill" + btxt.Text + "')", aconn);
            mysqlcmd.ExecuteNonQuery();
            MessageBox.Show("Entry added.");
            aconn.Close();
            atxt.Text = "";
            btxt.Text = "";
            dtxt.Text = "";
            utxt.Text = "";
            otxt.Text = "";
            readbilling();
        }

        private void delbtn_Click(object sender, EventArgs e)
        {
            readdetails();

            readdeliveries();
            fsuptxt.Visible = false;
            fsuplbl.Visible = false;
            delpnl.Visible = true;
            dealpnl.Visible = false;
            exppnl.Visible = false;
            moneypnl.Visible = false;
            bankpnl.Visible = false;
            miscpnl.Visible = false;
            billpnl.Visible = false;
            rpnl.Visible = false;

        }

        private void adddbtn_Click(object sender, EventArgs e)
        {
            aconn.Open();
            mysqlcmd = new MySqlCommand("insert into deliveries(`orderid`, `email`, `amount`,`status`) values ('" + otxt2.Text + "','" + etxt2.Text + "','" + atxt2.Text + "','" + stxt.Text + "')", aconn);
            mysqlcmd.ExecuteNonQuery();
            MessageBox.Show("Entry added.");
            aconn.Close();
            otxt2.Text = "";
            etxt2.Text = "";
            atxt2.Text = "";
            stxt.Text = "";
            
            readdeliveries();
        }

        private void dealbtn_Click(object sender, EventArgs e)
        {
            readdetails();

            readdealings();

            fsuptxt.Visible = true;
            fsuplbl.Visible = true;
            dealpnl.Visible = true;
            delpnl.Visible = false;
            exppnl.Visible = false;
            moneypnl.Visible = false;
            bankpnl.Visible = false;
            miscpnl.Visible = false;
            billpnl.Visible = false;
            rpnl.Visible = false;
        }

        private void dealaddbtn_Click(object sender, EventArgs e)
        {
            if (yes.Checked)
            {
                aconn.Open();
                mysqlcmd = new MySqlCommand("insert into dealing(`supplierid`, `suppliername`, `productid`,`productname`,`size`,`count`,`amount`,`pickupdate`,`paymentdone`,`paymentdate`,`comments`) values ('" + suptxt.Text + "','" + supnametxt.Text + "','" + proidtxt.Text + "','" + pronametxt.Text + "','" + sizetxt.Text + "','" + counttxt.Text + "','" + atxt3.Text + "','" + pickuptxt.Text + "','1','" + paymentdatetxt.Text + "','" + commentstxt.Text + "')", aconn);
                mysqlcmd.ExecuteNonQuery();
                MessageBox.Show("Entry added.");
                aconn.Close();
            }
            else
            {
                aconn.Open();
                mysqlcmd = new MySqlCommand("insert into dealing(`supplierid`, `suppliername`, `productid`,`productname`,`size`,`count`,`amount`,`pickupdate`,`paymentdone`,`paymentdate`,`comments`) values ('" + suptxt.Text + "','" + supnametxt.Text + "','" + proidtxt.Text + "','" + pronametxt.Text + "','" + sizetxt.Text + "','" + counttxt.Text + "','" + atxt3.Text + "','" + pickuptxt.Text + "','0','" + paymentdatetxt.Text + "','" + commentstxt.Text + "')", aconn);
                mysqlcmd.ExecuteNonQuery();
                MessageBox.Show("Entry added.");
                aconn.Close();
            }
            suptxt.Text = "";
            supnametxt.Text = "";
            proidtxt.Text = "";
            pronametxt.Text = "";
            sizetxt.Text = "";
            counttxt.Text = "";
            atxt3.Text = "";
            pickuptxt.Text = "";
            paymentdatetxt.Text = "";
            paymentdatetxt.Text = "";
            commentstxt.Text = "";
            readdealings();
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

        private void amounttxt_Leave(object sender, EventArgs e)
        {
            try {
                int amount = int.Parse(amounttxt.Text);
                int balance = int.Parse(baltxt.Text);
                baltxt.Text = (balance - amount).ToString();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            }

        private void refresh_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            readdetails();
            Cursor = Cursors.Arrow;
        }

        private void fsuptxt_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = string.Format("suppliername LIKE '%{0}%'", fsuptxt.Text);
            accountdataview.DataSource = dv;
        }

        private void revbtn_Click(object sender, EventArgs e)
        {
            readdetails();

            readrevenue();
            fsuptxt.Visible = false;
            fsuplbl.Visible = false;
            rpnl.Visible = true;
            delpnl.Visible = false;
            dealpnl.Visible = false;
            exppnl.Visible = false;
            moneypnl.Visible = false;
            bankpnl.Visible = false;
            miscpnl.Visible = false;
            billpnl.Visible = false;
            totallbl.Visible = false;

            switch(month)
            {
                case "01":
                    monlbl.Text = "January";
                    break;
                case "02":
                    monlbl.Text = "February";
                    break;
                case "03":
                    monlbl.Text = "March";
                    break;
                case "04":
                    monlbl.Text = "April";
                    break;
                case "05":
                    monlbl.Text = "May";
                    break;
                case "06":
                    monlbl.Text = "June";
                    break;
                case "07":
                    monlbl.Text = "July";
                    break;
                case "08":
                    monlbl.Text = "August";
                    break;
                case "09":
                    monlbl.Text = "September";
                    break;
                case "10":
                    monlbl.Text = "October";
                    break;
                case "11":
                    monlbl.Text = "November";
                    break;
                case "12":
                    monlbl.Text = "December";
                    break;
                default:
                    monlbl.Visible = false;
                    break;
            }

            aconn.Open();
            cmd = new MySqlCommand(" SELECT sum(amount) from deliveries where status='delivered' and date like '%-"+month+"-%'", aconn);
            dr = cmd.ExecuteReader();
            dr.Read();
            salebox.Text = dr[0].ToString();
            aconn.Close();

            aconn.Open();
            cmd = new MySqlCommand(" SELECT sum(dealerprice) from dealing where pickupdate like '%-" + month + "-%'", aconn);
            dr = cmd.ExecuteReader();
            dr.Read();
            purchasebox.Text = dr[0].ToString();
            aconn.Close();

            profitbox.Text = (int.Parse(salebox.Text) - int.Parse(purchasebox.Text)).ToString();


            aconn.Open();
            cmd = new MySqlCommand(" SELECT sum(amount) from expenses where purchasedate like '%-" + month + "-%'", aconn);
            dr = cmd.ExecuteReader();
            dr.Read();
            investbox.Text = dr[0].ToString();
            aconn.Close();
        }

       

        private void addrbtn_Click(object sender, EventArgs e)
        {
            aconn.Open();
            mysqlcmd = new MySqlCommand("insert into revenue(`month`, `year`,`sale`,`profit`,`invested`,`reason`,`gross_profit`,`purchase_cost`) values ('" + monthtxt.Text + "','" + yeartxt.Text + "','" + saletxt.Text + "','" + profittxt.Text + "','"+investedtxt.Text+"','"+ireasontxt.Text+"','"+gprofittxt.Text+"','"+pcosttxt.Text+"')", aconn);
            mysqlcmd.ExecuteNonQuery();
            MessageBox.Show("Entry added.");
            aconn.Close();
            monthtxt.Text = "";
            yeartxt.Text = "";
            saletxt.Text = "";
            profittxt.Text = "";
            investedtxt.Text = "";
            ireasontxt.Text = "";
            gprofittxt.Text = "";
            pcosttxt.Text = "";

            readrevenue();
        }



        private void investedtxt_TextChanged(object sender, EventArgs e)
        {
           
                try
                {
                    gprofittxt.Text = (int.Parse(profittxt.Text) - int.Parse(investedtxt.Text)).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                       
        }

        private void pcosttxt_TextChanged(object sender, EventArgs e)
        {
            
                try
                {
                    profittxt.Text = (int.Parse(saletxt.Text) - int.Parse(pcosttxt.Text)).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            
          
         }


        private void updbtn_Click(object sender, EventArgs e)
        {
            try
            {
                cmdbl = new MySqlCommandBuilder(adap);
                adap.Update(dt);
                MessageBox.Show("Entry Updated.");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        
    }
}
