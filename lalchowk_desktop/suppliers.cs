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
        BindingSource bsource;
        PictureBox loading;

        private dialogcontainer dg = null;
        private container hp = null;
        public suppliers(Form hpcopy,Form dgcopy)
        {
            dg = dgcopy as dialogcontainer;
            hp = hpcopy as container;
            InitializeComponent();
            
            bgworker.RunWorkerAsync();
        }




        private void bgworker_DoWork(object sender, DoWorkEventArgs e)
        {
            readsuppliers();
        }

        private void bgworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {


            if (ActiveForm == dg)
            {
                dg.loadingimage.Visible = false;
                dg.lbl.ForeColor = SystemColors.Highlight;
                dg.lbl.Text = "Suppliers";
                label1.Visible = false;
            }
            else
            {
                loading.Visible = false;
                label1.Text = "Suppliers";
            }
            
            suppnl.Visible = true;
            supplierdatagridview.DataSource = bsource;


        }
        public void loadingnormal()
        {
            label1.Text = "Loading";
            label1.Visible = true;
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
            dg.lbl.ForeColor = SystemColors.Highlight;
            dg.lbl.Text = "Loading";           
            dg.loadingimage.SizeMode = PictureBoxSizeMode.StretchImage;
            dg.loadingimage.Visible = true;
        }


        private void readsuppliers()
        {

            con = new MySqlConnection();
            con.ConnectionString = "SERVER=182.50.133.78;DATABASE=lalchowk;USER=lalchowk;PASSWORD=Lalchowk@123uzmah";
            con.Open();
            adap = new MySqlDataAdapter("select * from suppliers", con);
            dt = new DataTable();
            adap.Fill(dt);
            bsource = new BindingSource();
            bsource.DataSource = dt;
            

         
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

        string supid;
        private void supplierdatagridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.supplierdatagridview.Rows[e.RowIndex];
                supid = row.Cells["supplierid"].Value.ToString();
                supplierlbl.Text = row.Cells["name"].Value.ToString();
                contactlbl.Text = row.Cells["contactname"].Value.ToString();
                addresslbl.Text = row.Cells["address"].Value.ToString();
                phonelbl.Text = row.Cells["phone"].Value.ToString();
                emaillbl.Text = row.Cells["email"].Value.ToString();

                productcount = obj.Count("select count(*) from products where supplierid = '" + supid + "'");
                if (productcount == 0)
                {
                    countlbl.Text = "supplier has " + productcount.ToString() + " products listed currently.";
                    

                }
                else
                {
                    countlbl.Text = "supplier has " + productcount.ToString() + " products listed currently. Cannot remove Supplier unless all products are removed first.";
                    countlbl.Visible = true;
                }
                dpnl.Visible = true;
            }
           
        }

        private void suppliertxt_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = string.Format("name LIKE '%{0}%'", suppliertxt.Text);
            supplierdatagridview.DataSource = dv;
        }

        private void rmvbtn_Click(object sender, EventArgs e)
        {
            if (productcount == 0)
            {
                DialogResult dgr = MessageBox.Show("Delete supplier ?\n" + supplierlbl.Text, "Confirm!", MessageBoxButtons.YesNo);
                if (dgr == DialogResult.Yes)
                {
                    cmd = "delete from suppliers where supplierid='" + supid + "'";
                    obj.nonQuery(cmd);
                    MessageBox.Show("Supplier removed successfully.");
                    readsuppliers();
                    dpnl.Visible = false;
                }
                
            }
            else
            {
                MessageBox.Show("Cannot remove Supplier while the products are listed.");
            }

        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            if (supemailtxt.Text == "" || suppwdtxt.Text == "")
            {
                MessageBox.Show("Add details first!");
            }
            else
            {
                cmd = "insert into suppliers (`name`,`email`,`password`,`contactname`,`address`,`postalcode`,`phone`,`description`) values" +
                "('" + supnametxt.Text + "','" + supemailtxt.Text + "','" + suppwdtxt.Text + "','" + contxt.Text + "','" + conaddtxt.Text + "','" + posttxt.Text + "','" + phonetxt.Text + "','" + desctxt.Text + "')";
                obj.nonQuery(cmd);
                MessageBox.Show("Supplier added.");
                supnametxt.Text = "";
                supemailtxt.Text = "";
                suppwdtxt.Text = "";
                contxt.Text = "";
                conaddtxt.Text = "";
                posttxt.Text = "";
                phonetxt.Text = "";
                desctxt.Text = "";
                readsuppliers();
            }
        }

    }
}
