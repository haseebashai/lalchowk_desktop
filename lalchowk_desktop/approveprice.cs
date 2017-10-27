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
        BindingSource bsource;
        PictureBox loading = new PictureBox();

        private dialogcontainer dg = null;
        private container hp = null;
        public approveprice(Form hpcopy,Form dgcopy)
        {
            dg = dgcopy as dialogcontainer;
            hp = hpcopy as container;
            InitializeComponent();
            
            bgworker.RunWorkerAsync();

        }

        private void readrequest()
        {
            try { 
            con = new MySqlConnection();
            con.ConnectionString = "SERVER=182.50.133.78;DATABASE=lalchowk;USER=lalchowk;PASSWORD=Lalchowk@123uzmah";
            con.Open();
            adap = new MySqlDataAdapter("SELECT productid,supplierid,productname,mrp,price,dealerprice,requestedprice,requeststatus,stock FROM lalchowk.products where requeststatus='pending';", con);
            dt = new DataTable();
            adap.Fill(dt);
            bsource = new BindingSource();
            bsource.DataSource = dt;
        }
            catch (Exception ex)
            {
                var message = ex.ToString();
                string[] split = message.Split(new string[] { "at" }, StringSplitOptions.None);
                MessageBox.Show("Something happened, please try again.\n\n" + split[0], "Error!");
            }



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
        {try { 
            cmd = "Update products set dealerprice='"+reqlbl.Text+"', requestedprice=null, requeststatus='Approved' where productid='"+pidlbl.Text+"'";
            obj.nonQuery(cmd);
            MessageBox.Show("Request Approved.");
            readrequest();
            apnl.Visible = false;
        }
            catch (Exception ex)
            {
                var message = ex.ToString();
                string[] split = message.Split(new string[] { "at" }, StringSplitOptions.None);
                MessageBox.Show("Something happened, please try again.\n\n" + split[0], "Error!");
            }

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
                var message = ex.ToString();
                string[] split = message.Split(new string[] { "at" }, StringSplitOptions.None);
                MessageBox.Show("Something happened, please try again.\n\n" + split[0], "Error!");
            }
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

        private void bgworker_DoWork(object sender, DoWorkEventArgs e)
        {
            readrequest();
        }

        private void bgworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (ActiveForm == dg)
            {
                dg.loadingimage.Visible = false;
                dg.lbl.ForeColor = SystemColors.Highlight;
                dg.lbl.Text = "Review Price";
                
            }
            else
            {
                loading.Visible = false;
                formlbl.Text = "Review Price";
                formlbl.BringToFront();
            }
            reqdataview.DataSource = bsource;
            ppnl.Visible = true;
        }

    }
}
