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
    public partial class viewproducts : Form
    {
        MySqlConnection con = new MySqlConnection("SERVER= 182.50.133.78; DATABASE=lalchowk;USER=lalchowk;PASSWORD=Lalchowk@123uzmah");
        MySqlDataAdapter adap;
        DataTable dt;
        string pid,pname, cmd, url = "http://lalchowk.in/lalchowk/pictures/";
        MySqlCommandBuilder cmdbl;
        DBConnect obj=new DBConnect();
        BindingSource bsource;

        private dialogcontainer dg = null;
        public viewproducts(Form dgcopy)
        {
            dg = dgcopy as dialogcontainer;
            InitializeComponent();

            loadingdg();
            bgworker.RunWorkerAsync();
            
        }

        private void readproducts()
        {
            con.Open();
            adap = new MySqlDataAdapter("select productid, productname, groupid, mrp, price, dealerprice, stock, picture from products", con);
            dt = new DataTable();
            adap.Fill(dt);
            con.Close();
            bsource = new BindingSource();
            bsource.DataSource = dt;
            
        }

        private void productsdataview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.productsdataview.Rows[e.RowIndex];
                string piclocation = row.Cells["picture"].Value.ToString();
                pid = row.Cells["productid"].Value.ToString();
                pname = row.Cells["productname"].Value.ToString();
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.ImageLocation = (url + piclocation);
            }
        }

        private void updbtn_Click(object sender, EventArgs e)
        {
            try
            {
                cmdbl = new MySqlCommandBuilder(adap);
                adap.Update(dt);
                MessageBox.Show("Updated.");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void idtxt_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = string.Format("Convert([productid],System.String) LIKE '%{0}%'", idtxt.Text);
            productsdataview.DataSource = dv;
        }

        public void loadingdg()
        {

            dg.lbl.ForeColor = SystemColors.Highlight;
            dg.lbl.Text = "Loading";
            dg.loadingimage.SizeMode = PictureBoxSizeMode.StretchImage;
            dg.loadingimage.Visible = true;
        }



        private void bgworker_DoWork(object sender, DoWorkEventArgs e)
        {
            readproducts();
        }

        private void bgworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            productsdataview.DataSource = bsource;
            ppnl.Visible = true;

            dg.loadingimage.Visible = false;
            dg.lbl.ForeColor = SystemColors.Highlight;
            dg.lbl.Text = "View Products";
        }

        private void nametxt_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = string.Format("productname LIKE '%{0}%'", nametxt.Text);
            productsdataview.DataSource = dv;
        }

        private void delbtn_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to delete the selected product ?\n"+pname, "Confirm", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {

                cmd = ("delete from products where productid='" + pid + "'");
                obj.nonQuery(cmd);
                MessageBox.Show("Product Deleted.");
                readproducts();
            }
        }
    }
}
