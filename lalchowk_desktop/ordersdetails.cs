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
using System.Text.RegularExpressions;

namespace Veiled_Kashmir_Admin_Panel
{
    public partial class ordersdetails : Form
    {

        MySqlCommandBuilder cmdbl;
        MySqlDataAdapter adap;
        DataTable dt;
        DBConnect obj= new DBConnect();
        MySqlConnection con = new MySqlConnection("SERVER=182.50.133.78;DATABASE=lalchowk;USER=lalchowk;PASSWORD=Lalchowk@123uzmah");
        MySqlDataReader dr;

     //   private container hp = null;
        private mainform mf = null;
        public ordersdetails(Form mfcopy)
        {
            mf = mfcopy as mainform;
            //     hp = hpcopy as container;
            

            InitializeComponent();
            
        }

        public void readordersdelivered()
        {
            con.Open();
            adap = new MySqlDataAdapter("select * from orders where status='delivered'", con);
            dt = new DataTable();
            adap.Fill(dt);
            BindingSource bsource = new BindingSource();
            bsource.DataSource = dt;
            ordersdataview.DataSource = bsource;
        }

        public void readordersplaced()
        {
            con.Open();
            adap = new MySqlDataAdapter("select * from orders where status='placed'", con);
            dt = new DataTable();
            adap.Fill(dt);
            BindingSource bsource = new BindingSource();
            bsource.DataSource = dt;
            ordersdataview.DataSource = bsource;
        }

        public void readpurchasecost()
        {
            con.Open();
            adap = new MySqlDataAdapter("select * from lalchowk.orderdetails where productid in (SELECT productid FROM lalchowk.orderdetails where orderid in (SELECT orderid FROM lalchowk.orders where status = 'delivered'))", con);
            dt = new DataTable();
            adap.Fill(dt);
            BindingSource bsource = new BindingSource();
            bsource.DataSource = dt;
            ordersdataview.DataSource = bsource;
        }

        public void readprofit()
        {
            con.Open();
            adap = new MySqlDataAdapter("select orderdetailid,orderid,productid,productname,price,quantity,dealerprice,size,price-dealerprice as profit from orderdetails where orderid in (SELECT orderid FROM orders where status = 'delivered')", con);
            dt = new DataTable();
            adap.Fill(dt);
            BindingSource bsource = new BindingSource();
            bsource.DataSource = dt;
            ordersdataview.DataSource = bsource;
        }

        private void upbtn_Click(object sender, EventArgs e)
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

        public void readshipping()
        {
            con.Open();
            adap = new MySqlDataAdapter("select orderid, email, shipdate,shipping from lalchowk.orders where status ='delivered'",con);
            dt = new DataTable();
            adap.Fill(dt);
            BindingSource bsource = new BindingSource();
            bsource.DataSource = dt;
            ordersdataview.DataSource = bsource;
        }

       
    }
}
