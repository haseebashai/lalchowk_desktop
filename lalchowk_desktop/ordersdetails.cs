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

        MySqlConnection con;
        MySqlDataAdapter adap;
        DataTable dt;

        

        DBConnect obj= new DBConnect();

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
            con = new MySqlConnection();
            con.ConnectionString = "SERVER=182.50.133.91;DATABASE=lalchowk;USER=lalchowk;PASSWORD=Lalchowk@123uzmah";
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
            con = new MySqlConnection();
            con.ConnectionString = "SERVER=182.50.133.91;DATABASE=lalchowk;USER=lalchowk;PASSWORD=Lalchowk@123uzmah";
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
            con = new MySqlConnection();
            con.ConnectionString = "SERVER=182.50.133.91;DATABASE=lalchowk;USER=lalchowk;PASSWORD=Lalchowk@123uzmah";
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
            con = new MySqlConnection();
            con.ConnectionString = "SERVER=182.50.133.91;DATABASE=lalchowk;USER=lalchowk;PASSWORD=Lalchowk@123uzmah";
            con.Open();
            adap = new MySqlDataAdapter("select orderdetailid,orderid,productid,productname,price,quantity,dealerprice,size from orderdetails where orderid in (SELECT orderid FROM orders where status = 'delivered')", con);
            dt = new DataTable();
            adap.Fill(dt);
            BindingSource bsource = new BindingSource();
            bsource.DataSource = dt;
            ordersdataview.DataSource = bsource;
        }

        public void readshipping()
        {
            con = new MySqlConnection();
            con.ConnectionString = "SERVER=182.50.133.91;DATABASE=lalchowk;USER=lalchowk;PASSWORD=Lalchowk@123uzmah";
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
