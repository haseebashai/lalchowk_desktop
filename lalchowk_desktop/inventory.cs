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
    public partial class inventory : Form
    {
        DBConnect obj = new DBConnect();
        String cmd, sc;
        MySqlConnection con;
        MySqlDataAdapter adap;
        bool nametxtok, desctxtok, editnametxtok, editdesctxtok;
        MySqlDataReader dr;
        DataTable dt;
        MySqlCommandBuilder cmdbl;
        BindingSource bsource;
        bool secondcat = false, thirdcat = false, supplier = false;
        

        private dialogcontainer dg = null;
        private container hp = null;
        public inventory(Form hpcopy, Form dgcopy)
        {
            hp = hpcopy as container;
            dg = dgcopy as dialogcontainer;
            InitializeComponent();
            upbtn.Visible = false;
            loadingdg();
            BackgroundWorker catload = new BackgroundWorker();
            catload.DoWork += Catload_DoWork;
            catload.RunWorkerCompleted += Catload_RunWorkerCompleted;
            catload.RunWorkerAsync();
        }

        private void Catload_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dg.loadingimage.Visible = false;
            dg.lbl.ForeColor = SystemColors.Highlight;
            dg.lbl.Text = "Edit Inventory";
            secbox.DisplayMember = "categoryname";
            thirdbox.DisplayMember = "categoryname";
            supbox.DisplayMember = "name";
            secbox.SelectedIndex = -1;
            thirdbox.SelectedIndex = -1;
            supbox.SelectedIndex = -1;
            invpnl.Visible = true;
            spnl.Visible = true;
        }

        private void Catload_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {

                dr = obj.Query("select concat(categoryid,':    ',categoryname) as categoryname from secondcategory");
                DataTable dt = new DataTable();
                dt.Columns.Add("categoryname", typeof(String));
                dt.Load(dr);
                obj.closeConnection();
                secbox.DataSource = dt;

                dr = obj.Query("select concat(categoryid,':    ',categoryname) as categoryname from thirdcategory");
                DataTable dt1 = new DataTable();
                dt1.Columns.Add("categoryname", typeof(String));
                dt1.Load(dr);
                obj.closeConnection();
                thirdbox.DataSource = dt1;

                dr = obj.Query("select concat(supplierid,':    ',name) as name from suppliers");
                DataTable dt2 = new DataTable();
                dt2.Columns.Add("name", typeof(String));
                dt2.Load(dr);
                obj.closeConnection();
                supbox.DataSource = dt2;



            }
            catch (Exception ex)
            {
                obj.closeConnection();
                
            }
        }

        private void supidtxt_TextChanged(object sender, EventArgs e)
        {
            try {
                DataView dv = new DataView(dt);
                dv.RowFilter = string.Format("Convert([supplierid],System.String) LIKE '%{0}%'", supidtxt.Text);
                inventorydatagridview.DataSource = dv;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }

        private void pronametxt_TextChanged(object sender, EventArgs e)
        {
            try {
                DataView dv = new DataView(dt);
                dv.RowFilter = string.Format("productname LIKE '%{0}%'", pronametxt.Text);
                inventorydatagridview.DataSource = dv;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }

        }

        private void catidtxt_TextChanged(object sender, EventArgs e)
        {
            try {
                DataView dv = new DataView(dt);
                dv.RowFilter = string.Format("Convert([productid],System.String) LIKE '%{0}%'", proidtxt.Text);
                inventorydatagridview.DataSource = dv;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }

        }

        private void brandtxt_TextChanged(object sender, EventArgs e)
        {
            try {
                DataView dv = new DataView(dt);
                dv.RowFilter = string.Format("brand LIKE '%{0}%'", brandtxt.Text);
                inventorydatagridview.DataSource = dv;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }

        }

        private void inventorydatagridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.inventorydatagridview.Rows[e.RowIndex];
                idlbl.Text = row.Cells["productid"].Value.ToString();
                productlbl.Text = row.Cells["productname"].Value.ToString();              
                desctxtbox.Text = row.Cells["description"].Value.ToString();
                descpnl.Visible = true;
               
            }
        }

      

        public static string RemoveSpecialCharacters(string str)
        {

            if (!Regex.IsMatch(str, @"[a-zA-Z0-9@#$%&*+\-_(),+':;?.,![\]\s\\/{}]+$"))
            {
                
                MessageBox.Show("Abnormal Special Character found, Please remove it and proceed.");
                
            }
            return (str);



            /*    StringBuilder sb = new StringBuilder();
                foreach (char c in str)
                {
                    if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_' || c == ';' || c == ','
                         || c == '/' || c == '\n' || c == ' ' || c == '\\' || c == '\'' || c == '{' || c == '}' || c == '[' || c==']'
                         || c=='@' || c==':' || c=='!'|| c=='#' || c == '$' || c == '%' || c=='(' ||c==')' || c=='=' || c=='+' || c=='-' || c=='&'
                         ||c=='*' ||c=='"' || c=='<' ||c=='>' ||c=='?')
                    {
                        sb.Append(c);
                    }
                }
                return sb.ToString(); */
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            try
            {
                //   StringBuilder s1 = new StringBuilder(desctxtbox.Text);
                // s1.Replace(@"\", @"\\");
                //s1.Replace("'", "\\'");
                //s1.Replace("‘", "");

                if (!Regex.IsMatch(desctxtbox.Text, @"^([a-zA-Z0-9@#$%&*+\-_(),+':;?.,![\]\s\\/{}""|]+)$")&& desctxtbox.Text!="")
                {

                    MessageBox.Show("Abnormal Special Character found, Please remove it and proceed.");

                }
                else
                {
                    cmd = ("update products set `description`='" + desctxtbox.Text + "' where `productid`='" + idlbl.Text + "'");
                    obj.nonQuery(cmd);

                    MessageBox.Show("Description Updated.");
                    // readinventory();
                }

            }
            catch (Exception ex)
            {
                obj.closeConnection();
                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }

        BackgroundWorker bw;
        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            upbtn.Enabled = true;
            pbar.Visible = false;
            refreshlbl.Visible = false;
            ipnl.Enabled = true;
            inventorydatagridview.DataSource = bsource;


        }
        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            readinventory();

        }
        private void upbtn_Click(object sender, EventArgs e)
        {
            upbtn.Enabled = false;
            try
            {
                Cursor = Cursors.WaitCursor;
                cmdbl = new MySqlCommandBuilder(adap);
                adap.Update(dt);

                Cursor = Cursors.Arrow;
                MessageBox.Show("Updated");
                upbtn.Enabled = true;

            }
            catch (Exception ex)
            {
                upbtn.Enabled = true;
                DialogResult dgr = MessageBox.Show("Cannot update, Data mismatch. Press YES to refresh the page.\n\n" + ex.Message.ToString(), "Error!", MessageBoxButtons.YesNo);
                if (dgr == DialogResult.Yes)
                {
                    ipnl.Enabled = false;
                    descpnl.Visible = false;
                    refreshlbl.Visible = true;
                    pbar.Visible = true;
                    bw = new BackgroundWorker();
                    bw.DoWork += new DoWorkEventHandler(bw_DoWork);
                    bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
                    bw.RunWorkerAsync();
                    upbtn.Enabled = false;
                }
                Cursor = Cursors.Arrow;
            }
        }

        private void cattxt_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = string.Format("categoryid LIKE '%{0}%'", cattxt.Text);
            inventorydatagridview.DataSource = dv;
        }

        private void secbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (secbox.SelectedIndex > 0)
            {
                seclbl.Font = new Font(seclbl.Font, FontStyle.Bold);
                thirdlbl.Font = new Font(thirdlbl.Font, FontStyle.Regular);
                suplbl.Font = new Font(suplbl.Font, FontStyle.Regular);
                secondcat = true;
                thirdcat = false;
                supplier = false;
                string id = secbox.Text.Split(':')[0];
                catidtxt.Text = id;
                catsuplbl.Text = "Category ID";
            }
        }

        private void thirdbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (thirdbox.SelectedIndex > 0)
            {
                seclbl.Font = new Font(seclbl.Font, FontStyle.Regular);
                thirdlbl.Font = new Font(thirdlbl.Font, FontStyle.Bold);
                suplbl.Font = new Font(suplbl.Font, FontStyle.Regular);
                secondcat = false;
                thirdcat = true;
                supplier = false;
                string id = thirdbox.Text.Split(':')[0];
                catidtxt.Text = id;
                catsuplbl.Text = "Category ID";
            }
        }

        private void supbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (supbox.SelectedIndex > 0)
            {
                seclbl.Font = new Font(seclbl.Font, FontStyle.Regular);
                thirdlbl.Font = new Font(thirdlbl.Font, FontStyle.Regular);
                suplbl.Font = new Font(suplbl.Font, FontStyle.Bold);
                secondcat = false;
                thirdcat = false;
                supplier = true;
                string id = supbox.Text.Split(':')[0];
                catidtxt.Text = id;
                catsuplbl.Text = "Supplier ID";
            }
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            secbox.SelectedIndex = -1;
            thirdbox.SelectedIndex = -1;
            supbox.SelectedIndex = -1;
            catidtxt.Text = "";
        }

      

        private void allinvbtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                con = new MySqlConnection();
                con.ConnectionString = "SERVER=182.50.133.78;DATABASE=lalchowk;USER=lalchowk;PASSWORD=Lalchowk@123uzmah";
                con.Open();
                adap = new MySqlDataAdapter("select * from products", con);
                
                dt = new DataTable();
                adap.Fill(dt);
                con.Close();
                bsource = new BindingSource();
                bsource.DataSource = dt;
                inventorydatagridview.DataSource = bsource;

            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
            Cursor = Cursors.Arrow;
        }

        string id;
        private void listbtn_Click(object sender, EventArgs e)
        {

            listbtn.Enabled = false;
            if (catidtxt.Text == "")
            {
                MessageBox.Show("Please select an option first.", "Error!");
                listbtn.Enabled = true;
            }
            else
            {
                id = catidtxt.Text;
                loadinglbl.Visible = true;
                bgworker.RunWorkerAsync();
            }
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
            readinventory();
        }

        private void bgworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           
          
            inventorydatagridview.DataSource = bsource;
            ipnl.Visible = true;
            upbtn.Visible = true;
            listbtn.Enabled = true;
            loadinglbl.Visible = false;


        }    

        private void readinventory()
        {
            try {
                con = new MySqlConnection();
                con.ConnectionString = "SERVER=182.50.133.78;DATABASE=lalchowk;USER=lalchowk;PASSWORD=Lalchowk@123uzmah";
                con.Open();
                if (secondcat == true || thirdcat == true)
                {
                    adap = new MySqlDataAdapter("select * from products where categoryid='" + id + "'", con);
                } else if (supplier)
                {
                    adap = new MySqlDataAdapter("select * from products where supplierid='" + id + "'", con);
                }
                else if (secondcat == false && thirdcat == false && supplier == false)
                {
                    adap = new MySqlDataAdapter("select * from products where categoryid='" + id + "'", con);
                }
                dt = new DataTable();
                adap.Fill(dt);
                con.Close();
                bsource = new BindingSource();
                bsource.DataSource = dt;
                
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }

      
    }
}
