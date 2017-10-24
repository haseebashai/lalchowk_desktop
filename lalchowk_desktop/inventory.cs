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
        

        private dialogcontainer dg = null;
        private container hp = null;
        private void supidtxt_TextChanged(object sender, EventArgs e)
        {
            try {
                DataView dv = new DataView(dt);
                dv.RowFilter = string.Format("Convert([supplierid],System.String) LIKE '%{0}%'", supidtxt.Text);
                inventorydatagridview.DataSource = dv;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
                MessageBox.Show(ex.ToString());
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
                MessageBox.Show(ex.ToString());
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
                MessageBox.Show(ex.ToString());
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

                if (!Regex.IsMatch(desctxtbox.Text, @"^([a-zA-Z0-9@#$%&*+\-_(),+':;?.,![\]\s\\/{}""|]+)$"))
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
                MessageBox.Show(ex.ToString());
            }
        }

       

        private void upbtn_Click(object sender, EventArgs e)
        {
            try
            {
                cmdbl = new MySqlCommandBuilder(adap);
                adap.Update(dt);
                MessageBox.Show("Updated.");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Please Try again or refresh the page.","Error!");
            }
        }
        public inventory(Form hpcopy, Form dgcopy)
        {
            hp = hpcopy as container;
            dg = dgcopy as dialogcontainer;
            InitializeComponent();
            upbtn.Visible = false;
            loadingdg();
            bgworker.RunWorkerAsync();
        }

        private void cattxt_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = string.Format("categoryid LIKE '%{0}%'", cattxt.Text);
            inventorydatagridview.DataSource = dv;
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
            dg.loadingimage.Visible = false;
            dg.lbl.ForeColor = SystemColors.Highlight;
            dg.lbl.Text = "Edit Inventory";
            
        }

        


       

        private void readinventory()
        {
            try {
                con = new MySqlConnection();
                con.ConnectionString = "SERVER=182.50.133.78;DATABASE=lalchowk;USER=lalchowk;PASSWORD=Lalchowk@123uzmah";
                con.Open();
                adap = new MySqlDataAdapter("select * from products", con);
                dt = new DataTable();
                adap.Fill(dt);
                bsource = new BindingSource();
                bsource.DataSource = dt;
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            }

      

        /*    private void rvmfdbtn_Click(object sender, EventArgs e)
            {
                cmd = ("delete from research where name= '" + resbox.Text + "'");
                obj.nonQuery(cmd);
                MessageBox.Show("selected Research entry removed sucessfully.");
                readresearch();
                ragree.Checked = false;
            }

            private void back_Click(object sender, EventArgs e)
            {
                mainform mf = new mainform(hp);
                mf.TopLevel = false;
                hp.mainpnl.Controls.Clear();
                hp.mainpnl.Controls.Add(mf);
                mf.Show();
            }

            private void resbtn_Click(object sender, EventArgs e)
            {
                readresearch();
            }

            private void addresbtn_Click(object sender, EventArgs e)
            {
                if (nametxtok && desctxtok == true)
                {
                    StringBuilder s1 = new StringBuilder(desctxt.Text);
                    s1.Replace(@"\", @"\\");
                    s1.Replace("'", "\\'");
                    cmd = "insert into research (`name`, `description`) values ('" + nametxt.Text + "', '" + s1 + "')";
                    obj.nonQuery(cmd);

                    MessageBox.Show("New Research entry added succesfully!");
                    nametxt.Text = "";
                    desctxt.Text = "";

                    readresearch();
                }
                else
                    inclblr.Visible = true;
            }

            private void cancelbtn_Click(object sender, EventArgs e)
            {
                nametxt.Text = "";
                desctxt.Text = "";
                inclblr.Visible = false;
                readresearch();
            }

            private void resbox_SelectedIndexChanged(object sender, EventArgs e)
            {
                dr = obj.Query("select * from research where name='" + resbox.Text + "'");
                dr.Read();
                editnametxt.Text = dr[1].ToString();
                editdesctxt.Text = dr[2].ToString();
                inclbler.Visible = false;
                obj.closeConnection();
            }

            private void updateresbtn_Click(object sender, EventArgs e)
            {
                if (editnametxt.Text.Contains("'") || editnametxt.Text.Contains("\\"))
                    MessageBox.Show("Topic cannot contain ' & \\");
                else
                {

                    if (ragree.Checked && editnametxtok && editdesctxtok == true)
                    {
                        StringBuilder s1 = new StringBuilder(editdesctxt.Text);
                        s1.Replace(@"\", @"\\");
                        s1.Replace("'", "\\'");
                        cmd = ("update research set `name`='" + editnametxt.Text + "', `description`='" + s1 + "' where `name`='" + resbox.Text + "'");
                        obj.nonQuery(cmd);

                        MessageBox.Show("Research entry updated succesfully!");
                        editnametxt.Text = "";
                        editdesctxt.Text = "";
                        ragree.Checked = false;
                        readresearch();
                    }
                    else
                    {
                        inclbler.Visible = true;
                    }
                }
            }

            private void editcancelbtn_Click(object sender, EventArgs e)
            {
                editnametxt.Text = "";
                editdesctxt.Text = "";
                inclbler.Visible = false;
                ragree.Checked = false;
                readresearch();
            }

            private void nametxt_Leave(object sender, EventArgs e)
            {
                if (nametxt.Text == "")
                    nametxtok = false;
                else
                    nametxtok = true;
                if (nametxt.Text.Contains("\\") || nametxt.Text.Contains("'"))
                {
                    MessageBox.Show("Name cannot contain special characters");
                    nametxt.Text = "";
                    nametxt.Focus();
                }
            }

            private void ragree_CheckedChanged(object sender, EventArgs e)
            {
                if (editnametxt.Text == "" && editdesctxt.Text == "")
                {
                    editnametxtok = false;
                    editdesctxtok = false;
                }
                else
                {
                    editnametxtok = true;
                    editdesctxtok = true;
                }
            }

            private void desctxt_Leave(object sender, EventArgs e)
            {
                if (desctxt.Text == "")
                    desctxtok = false;
                else
                    desctxtok = true;
            } 
            */
    }
}
