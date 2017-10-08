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
        string pid, cmd, url = "http://lalchowk.in/lalchowk/pictures/";
        MySqlCommandBuilder cmdbl;
        DBConnect obj=new DBConnect();


        public viewproducts()
        {
            InitializeComponent();
            readproducts();
        }

        private void readproducts()
        {
            con.Open();
            adap = new MySqlDataAdapter("select productid, productname, groupid, mrp, price, dealerprice, stock, picture from products", con);
            dt = new DataTable();
            adap.Fill(dt);
            con.Close();
            BindingSource bsource = new BindingSource();
            bsource.DataSource = dt;
            productsdataview.DataSource = bsource;
        }

        private void productsdataview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.productsdataview.Rows[e.RowIndex];
                string piclocation = row.Cells["picture"].Value.ToString();
                pid = row.Cells["productid"].Value.ToString();
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

        private void nametxt_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = string.Format("productname LIKE '%{0}%'", nametxt.Text);
            productsdataview.DataSource = dv;
        }

        private void delbtn_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to delete the selected product ?", "Confirm", MessageBoxButtons.YesNo);
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
