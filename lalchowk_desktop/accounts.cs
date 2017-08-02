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
        MySqlCommand mysqlcmd;
        DataTable dt;
        string cmd;
        MySqlCommandBuilder cmdbl;
        MySqlDataAdapter adap;
        MySqlConnection aconn = new MySqlConnection("SERVER=182.50.133.78;DATABASE=lalchowk_ac;USER=lalchowkac;PASSWORD=Lalchowk@123uzmah");


        private container hp = null;
        public accounts(Form hpcopy)
        {
            hp = hpcopy as container;
            InitializeComponent();
        }

        public void readexpenses()
        {
            con = new MySqlConnection();
            con.ConnectionString = "SERVER=182.50.133.78;DATABASE=lalchowk_ac;USER=lalchowkac;PASSWORD=Lalchowk@123uzmah";
            con.Open();
            adap = new MySqlDataAdapter("select * from expenses", con);
            dt = new DataTable();
            adap.Fill(dt);
            BindingSource bsource = new BindingSource();
            bsource.DataSource = dt;
            accountdataview.DataSource = bsource;
        }

        public void readmoneypool()
        {
            con = new MySqlConnection();
            con.ConnectionString = "SERVER=182.50.133.78;DATABASE=lalchowk_ac;USER=lalchowkac;PASSWORD=Lalchowk@123uzmah";
            con.Open();
            adap = new MySqlDataAdapter("select * from moneypool", con);
            dt = new DataTable();
            adap.Fill(dt);
            BindingSource bsource = new BindingSource();
            bsource.DataSource = dt;
            accountdataview.DataSource = bsource;
        }

        public void readbank()
        {
            con = new MySqlConnection();
            con.ConnectionString = "SERVER=182.50.133.78;DATABASE=lalchowk_ac;USER=lalchowkac;PASSWORD=Lalchowk@123uzmah";
            con.Open();
            adap = new MySqlDataAdapter("select * from bankdetails", con);
            dt = new DataTable();
            adap.Fill(dt);
            BindingSource bsource = new BindingSource();
            bsource.DataSource = dt;
            accountdataview.DataSource = bsource;
        }

        public void readmisc()
        {
            con = new MySqlConnection();
            con.ConnectionString = "SERVER=182.50.133.78;DATABASE=lalchowk_ac;USER=lalchowkac;PASSWORD=Lalchowk@123uzmah";
            con.Open();
            adap = new MySqlDataAdapter("select * from misc", con);
            dt = new DataTable();
            adap.Fill(dt);
            BindingSource bsource = new BindingSource();
            bsource.DataSource = dt;
            accountdataview.DataSource = bsource;
        }

        private void expbtn_Click(object sender, EventArgs e)
        {
            readexpenses();
            exppnl.Visible = true;
            moneypnl.Visible = false;
            bankpnl.Visible = false;
            miscpnl.Visible = false;
        }

        private void moneybtn_Click(object sender, EventArgs e)
        {
            readmoneypool();
            moneypnl.Visible = true;
            exppnl.Visible = false;
            bankpnl.Visible = false;
            miscpnl.Visible = false;
        }

        private void bankbtn_Click(object sender, EventArgs e)
        {
            readbank();
            bankpnl.Visible = true;
            moneypnl.Visible = false;
            exppnl.Visible = false;
            miscpnl.Visible = false;
        }

        private void miscbtn_Click(object sender, EventArgs e)
        {
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
