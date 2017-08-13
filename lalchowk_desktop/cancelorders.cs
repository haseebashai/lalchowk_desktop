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
    public partial class cancelorders : Form
    {

        DBConnect obj = new DBConnect();
        MySqlDataReader dr;
        DataTable dt, dt1, dt2, dt3;
        string cmd;

       

        public cancelorders()
        {
            InitializeComponent();
            readorders();
        }

        private void readorders()
        {
            dr = obj.Query("SELECT orderid, amount, shipping, itemcount,status, name, address1, address2, pincode, contact, city FROM orders where status='Placed'");

            dt = new DataTable();
            dt.Load(dr);
            obj.closeConnection();
            BindingSource bsource = new BindingSource();

            bsource.DataSource = dt;
            ordergridview.DataSource = bsource;

        }

        private void ordergridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.ordergridview.Rows[e.RowIndex];
               
                
                oidlbl.Text = row.Cells["orderid"].Value.ToString();
                amountlbl.Text = row.Cells["amount"].Value.ToString();
                shiplbl.Text = row.Cells["shipping"].Value.ToString();
                namelbl.Text = row.Cells["name"].Value.ToString();
                statuslbl.Text = row.Cells["status"].Value.ToString();
                stocklbl.Text = row.Cells["itemcount"].Value.ToString();
                
                apnl.Visible = true;
               
            }
            Cursor = Cursors.Arrow;
        }


        private void apbtn_Click(object sender, EventArgs e)
        {
            cmd = "Update orders set status='Cancelled' where orderid='" + oidlbl.Text + "'";
            obj.nonQuery(cmd);
            cmd = "Update products set stock=stock+1 where productid in(SELECT productid FROM lalchowk.orderdetails where orderid in (select orderid from lalchowk.orders where orderid='" + oidlbl.Text + "'))";
            obj.nonQuery(cmd);
            MessageBox.Show("Order cancelled.");
            readorders();
            apnl.Visible = false;
        }

    }
}
