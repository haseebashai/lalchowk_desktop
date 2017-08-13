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
        MySqlDataReader dr;
        MySqlCommandBuilder cmdbl;
        MySqlDataAdapter adap;
        MySqlConnection aconn = new MySqlConnection("SERVER=182.50.133.78;DATABASE=lalchowk_ac;USER=lalchowkac;PASSWORD=Lalchowk@123uzmah");


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
            exppnl.Visible = true;
            moneypnl.Visible = false;
            bankpnl.Visible = false;
            miscpnl.Visible = false;
        }

        private void moneybtn_Click(object sender, EventArgs e)
        {
            readdetails();
            
            readmoneypool();
            moneypnl.Visible = true;
            exppnl.Visible = false;
            bankpnl.Visible = false;
            miscpnl.Visible = false;
        }

        private void bankbtn_Click(object sender, EventArgs e)
        {
            readdetails();
            
            readbank();
            bankpnl.Visible = true;
            moneypnl.Visible = false;
            exppnl.Visible = false;
            miscpnl.Visible = false;
        }

        private void miscbtn_Click(object sender, EventArgs e)
        {
            readdetails();
            
            readmisc();
            miscpnl.Visible = true;
            bankpnl.Visible = false;
            moneypnl.Visible = false;
            exppnl.Visible = false;
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

            billpnl.Visible = true;
            miscpnl.Visible = false;
            bankpnl.Visible = false;
            moneypnl.Visible = false;
            exppnl.Visible = false;
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
            delpnl.Visible = true;
            exppnl.Visible = false;
            moneypnl.Visible = false;
            bankpnl.Visible = false;
            miscpnl.Visible = false;
            billpnl.Visible = false;

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
