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
    public partial class suppliers : Form
    {

        DBConnect obj = new DBConnect();
        MySqlConnection con;
        String cmd;
        MySqlCommandBuilder cmdbl;
        MySqlDataReader dr;
        MySqlDataAdapter adap;
        DataTable dt;
        DataSet ds;
        int productcount;
        private container hp = null;
        public suppliers(Form hpcopy)
        {
            hp = hpcopy as container;
            InitializeComponent();
        }

        private void readsuppliers()
        {

            con = new MySqlConnection();
            con.ConnectionString = "SERVER=182.50.133.91;DATABASE=lalchowk;USER=lalchowk;PASSWORD=Lalchowk@123uzmah";
            con.Open();
            adap = new MySqlDataAdapter("select * from suppliers", con);
            dt = new DataTable();
            adap.Fill(dt);
            BindingSource bsource = new BindingSource();
            bsource.DataSource = dt;
            supplierdatagridview.DataSource = bsource;

          /*  ds = new DataSet();
            adap.Fill(ds, "supplier_details");
            supplierdatagridview.DataSource = ds.Tables[0]; */

         /*   dr = obj.Query("select * from suppliers");

            dt = new DataTable();
            dt.Load(dr);
            BindingSource bsource = new BindingSource();

            bsource.DataSource = dt;
            supplierdatagridview.DataSource = bsource;
            */
        }
        private void suppliers_Load(object sender, EventArgs e)
        {
            readsuppliers();
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            try
            {
                cmdbl = new MySqlCommandBuilder(adap);
                adap.Update(dt);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void emailtxt_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = string.Format("email LIKE '%{0}%'", emailtxt.Text);
            supplierdatagridview.DataSource = dv;
        }

        private void supplierdatagridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                
                idlbl.Visible = true;
                supplierlbl.Visible = true;
                contactlbl.Visible = true;
                addresslbl.Visible = true;
                phonelbl.Visible = true;
                emaillbl.Visible = true;
                


                DataGridViewRow row = this.supplierdatagridview.Rows[e.RowIndex];
                idlbl.Text = row.Cells["supplierid"].Value.ToString();
                supplierlbl.Text = row.Cells["suppliername"].Value.ToString();
                contactlbl.Text = row.Cells["contactname"].Value.ToString();
                addresslbl.Text = row.Cells["address"].Value.ToString();
                phonelbl.Text = row.Cells["phone"].Value.ToString();
                emaillbl.Text = row.Cells["email"].Value.ToString();

                productcount = obj.Count("select count(*) from products where supplierid = '" + idlbl.Text + "'");
                if (productcount == 0)
                {
                    countlbl.Text = "supplier has " + productcount.ToString() + " products listed currently.";
                    rmvbtn.Visible = true;

                }
                else
                {
                    countlbl.Text = "supplier has " + productcount.ToString() + " products listed currently. Cannot remove Supplier unless all products are removed first.";
                    countlbl.Visible = true;
                }
            }
           
        }

        private void suppliertxt_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = string.Format("suppliername LIKE '%{0}%'", suppliertxt.Text);
            supplierdatagridview.DataSource = dv;
        }

        private void rmvbtn_Click(object sender, EventArgs e)
        {
            if (productcount == 0)
            {
                cmd="delete from suppliers where supplierid='"+idlbl.Text+"'";
                obj.nonQuery(cmd);
                MessageBox.Show("Supplier removed successfully.");
                readsuppliers();
            }
            else
            {
                MessageBox.Show("Cannot remove Supplier while the products are listed.");
            }
        }

        private void idlbl_Click(object sender, EventArgs e)
        {

        }

        private void supplierlbl_Click(object sender, EventArgs e)
        {

        }
    }
}
