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
    public partial class approveprice : Form
    {
        DBConnect obj = new DBConnect();
        string cmd;
        MySqlConnection con;
        MySqlDataAdapter adap;
        DataTable dt;
        MySqlCommandBuilder cmdbl;

        private container hp = null;
        public approveprice(Form hpcopy)
        {
            hp = hpcopy as container;
            InitializeComponent();
            readrequest();

        }

        private void readrequest()
        {

            con = new MySqlConnection();
            con.ConnectionString = "SERVER=182.50.133.78;DATABASE=lalchowk;USER=lalchowk;PASSWORD=Lalchowk@123uzmah";
            con.Open();
            adap = new MySqlDataAdapter("SELECT productid,supplierid,productname,mrp,price,dealerprice,requestedprice,requeststatus,stock FROM lalchowk.products where requeststatus='pending';", con);
            dt = new DataTable();
            adap.Fill(dt);
            BindingSource bsource = new BindingSource();
            bsource.DataSource = dt;
            reqdataview.DataSource = bsource;

            

        }

        private void reqdataview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.reqdataview.Rows[e.RowIndex];
                pidlbl.Text = row.Cells["productid"].Value.ToString();
                pnamelbl.Text = row.Cells["productname"].Value.ToString();
                mrplbl.Text = row.Cells["mrp"].Value.ToString();
                pricelbl.Text = row.Cells["price"].Value.ToString();
                dealerlbl.Text = row.Cells["dealerprice"].Value.ToString();
                reqlbl.Text = row.Cells["requestedprice"].Value.ToString();
                rslbl.Text = row.Cells["requeststatus"].Value.ToString();
                stocklbl.Text = row.Cells["stock"].Value.ToString();
                apnl.Visible = true;
            }
        }

        private void apbtn_Click(object sender, EventArgs e)
        {
            cmd = "Update products set dealerprice='"+reqlbl.Text+"', requestedprice=null, requeststatus='Approved' where productid='"+pidlbl.Text+"'";
            obj.nonQuery(cmd);
            MessageBox.Show("Request Approved.");
            readrequest();
            apnl.Visible = false;
            
        }

        private void ubtn_Click(object sender, EventArgs e)
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
