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
    public partial class cancelorders : Form
    {

        DBConnect obj = new DBConnect();
        MySqlDataReader dr;
        DataTable dt, dt1, dt2, dt3;
        string cmd;
        PictureBox loading = new PictureBox();
        BindingSource bsource;


        private dialogcontainer dg = null;
        public cancelorders(Form dgcopy)
        {
            dg = dgcopy as dialogcontainer;
            InitializeComponent();
            bgworker.RunWorkerAsync();
        }

        private void bgworker_DoWork(object sender, DoWorkEventArgs e)
        {
            readorders();
        }

        private void bgworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (dg!=null)
            {
                dg.loadingimage.Visible = false;
                dg.lbl.ForeColor = SystemColors.Highlight;
                dg.lbl.Text = "Cancel Order";

            }
            else
            {
                loading.Visible = false;
                formlbl.Visible = true;
                formlbl.Text = "Cancel Order";
                formlbl.BringToFront();
            }
            ordergridview.DataSource = bsource;
            cpnl.Visible = true;
        }
        public void loadingnormal()
        {
            formlbl.Text = "Loading";

            loading = new PictureBox()
            {
                Image = Properties.Resources.loading,
                Size = new Size(40, 30),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Location = new Point(72, 0),
            };
            this.Controls.Add(loading);
        }
        public void loadingdg()
        {
            formlbl.Visible = false;
            dg.lbl.ForeColor = SystemColors.Highlight;
            dg.lbl.Text = "Loading";
            dg.loadingimage.SizeMode = PictureBoxSizeMode.StretchImage;
            dg.loadingimage.Visible = true;
        }

        private void readorders()
        {try { 
            dr = obj.Query("SELECT orderid, amount, shipping, itemcount,status, name, address1, address2, pincode, contact, city FROM orders where status='Placed'");

            dt = new DataTable();
            dt.Load(dr);
            obj.closeConnection();
            bsource = new BindingSource();

            bsource.DataSource = dt;
        }
            catch (Exception ex)
            {

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }

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
            Cursor = Cursors.WaitCursor;
            try
            {
                cmd = "Update orders set status='Cancelled' where orderid='" + oidlbl.Text + "'";
                obj.nonQuery(cmd);
                cmd = "Update products set stock=stock+1 where productid in(SELECT productid FROM lalchowk.orderdetails where orderid in (select orderid from lalchowk.orders where orderid='" + oidlbl.Text + "'))";
                obj.nonQuery(cmd);
                MessageBox.Show("Order cancelled.");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
            readorders();
            ordergridview.DataSource = bsource;
            apnl.Visible = false;
            Cursor = Cursors.Arrow;
        }

    }
}
