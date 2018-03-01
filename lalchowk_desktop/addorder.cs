using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Veiled_Kashmir_Admin_Panel
{
    public partial class addorder : Form
    {
        DBConnect obj = new DBConnect();
        MySqlDataReader dr;

        private dialogcontainer dg = null;
      
        public addorder(Form dgcopy)
        {
            dg = dgcopy as dialogcontainer;
            
            InitializeComponent();

            BackgroundWorker pin = new BackgroundWorker();
            pin.DoWork += (o, a) => 
            {
                try
                {
                  
                    dr = obj.Query("select distinct concat(pincode,':  ',area) as pincode from pincodes order by pincode asc");
                    DataTable dt = new DataTable();
                    dt.Columns.Add("pincode", typeof(String));
                    dt.Load(dr);
                    obj.closeConnection();

                    pinbox.DataSource = dt;

                }
                catch { obj.closeConnection(); }
            };
            pin.RunWorkerCompleted += (o, b) => 
            {
                try
                {
                    pinbox.DisplayMember = "pincode";
                    pinbox.SelectedIndex = -1;
                }catch { };
            };
            pin.RunWorkerAsync();
        }


        public static string md5hash(string input)
        {

            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input + "Zohan123"));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

        List<string> products = new List<string>();
        private void addorderbtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if (emailtxt.Text == "" || nametxt.Text == "" || add1txt.Text == "" || amounttxt.Text == "" || contacttxt.Text == "" || statustxt.Text == "")
                {
                    MessageBox.Show("Please fill details first.", "Error!");
                }
                else
                {
                    DialogResult dgr = MessageBox.Show("Please ensure all the details are correct, it will reflect on the user account.\r\nDo you want to proceed ?", "Confirm!", MessageBoxButtons.YesNo);
                    if (dgr == DialogResult.Yes)
                    {

                        string email = md5hash(emailtxt.Text);
                        string cmd = "INSERT INTO orders(`email`, `amount`,`timestamp`,`shipping`,`paymenttype`, `transanctionid`,`itemcount`,`status`,`name`,`address1`,`address2`,`contact`,`pincode`,`city`,`loyaltybonus`) values ('" + email + "','" + amounttxt.Text
                            + "',DATE_ADD(CURRENT_TIMESTAMP, INTERVAL 750 MINUTE),'" + shiptxt.Text + "','Cash on Delivery','SW','" + counttxt.Text + "','" + statustxt.Text + "','" + nametxt.Text + "','" + add1txt.Text + "','" + add2txt.Text + "','" + contacttxt.Text + "','" + pintxt.Text + "','" + citytxt.Text + "','" + loyaltxt.Text + "')";
                        obj.nonQuery(cmd);
                        long orderid = userinfo.orid;
                    //    int orderid = obj.Count("SELECT LAST_INSERT_ID()");
                      
                        obj.closeConnection();
                        pidtxt.Text = pidtxt.Text.Remove(pidtxt.Text.Length - 1);
                        string[] pids = pidtxt.Text.Split(',');
                        foreach (string pid in pids)
                        {
                            MessageBox.Show(orderid.ToString());
                            try
                            {
                                dr = obj.Query("select productname,price,mrp,dealerprice,picture from products where productid='" + pid + "'");
                                dr.Read();
                                string name = dr[0].ToString();
                                string price = dr[1].ToString();
                                string mrp = dr[2].ToString();
                                string dp = dr[3].ToString();
                                string pic = dr[4].ToString();
                                obj.closeConnection();

                              
                                StringBuilder pname = new StringBuilder(name);
                                pname.Replace(@"'", "\\'").Replace(@"\", "\\");
                                string cmd1 = "insert into orderdetails(`orderid`,`productid`,`productname`,`price`,`quantity`,`discount`,`mrp`,`dealerprice`,`size`,`picture`)values('" + orderid + "','" + pid + "','" + pname + "','" + price + "','1','0','" + mrp + "','" + dp + "',NULL,'" + pic + "')";
                                obj.nonQuery(cmd1);
                               
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.ToString()); obj.closeConnection(); }
                        }
                        MessageBox.Show("Order added successfully.", "Success.");
                        pidtxt.Text = "";
                        pidtxt.Visible = false;
                        addorderbtn.Enabled = false;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); obj.closeConnection(); addorderbtn.Enabled = true; }
            Cursor = Cursors.Arrow;
        }

        public void loadingdg()
        {
            dg.lbl.ForeColor = SystemColors.Highlight;
            dg.lbl.Text = "Add new order";
            
        }

        private void searchbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (searchtxt.Text == "")
                {
                    MessageBox.Show("Please enter a product.", "Error!");
                }
                else
                {

                    loadinglbl.Visible = true;
                    searchbtn.Enabled = false;
                    StringBuilder search = new StringBuilder(searchtxt.Text);
                    search.Replace(@"'", "\\'").Replace(@"\", "\\");

                    BackgroundWorker bg = new BackgroundWorker();
                    bg.DoWork += (o, a) =>
                    {
                        try
                        {
                            string id = (string)a.Argument;
                            dr = obj.Query("select productid,supplierid,productname,mrp,price,dealerprice,stock,detail1,detail2,picture from products where tags like '%" + id + "%'");
                            DataTable dt = new DataTable();
                            dt.Load(dr);
                            obj.closeConnection();
                            BindingSource bsource = new BindingSource();
                            bsource.DataSource = dt;
                            a.Result = bsource;
                        }
                        catch { obj.closeConnection(); }
                    };
                    bg.RunWorkerCompleted += (o, b) =>
                    {
                        try
                        {
                            BindingSource bsource = b.Result as BindingSource;
                            inventorydatagridview.DataSource = bsource;
                            inventorydatagridview.Columns["picture"].Visible = false;
                            loadinglbl.Visible = false;
                            searchbtn.Enabled = true;


                        }
                        catch { searchbtn.Enabled = true; }
                    };
                    bg.RunWorkerAsync(search.ToString());
                }
            }catch { }
        }
        string id,price;
        private void inventorydatagridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.inventorydatagridview.Rows[e.RowIndex];
                    dp.SizeMode = PictureBoxSizeMode.StretchImage;
                    dp.ImageLocation = "http://lalchowk.in/lalchowk/pictures/" + row.Cells["picture"].Value.ToString();
                    id = row.Cells["productid"].Value.ToString();
                    price= row.Cells["price"].Value.ToString();
                    addbtn.Enabled = true;
                }
            }catch { }
        }

        private void pinbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pinbox.SelectedIndex > -1)
            {
                pintxt.Text = pinbox.Text.Split(':')[0];

            }
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (pidtxt.Text == "")
                {
                    pidtxt.Text = id + ",";
                }
                else
                {
                    pidtxt.Text = pidtxt.Text + id + ",";
                }
               
                pidtxt.Visible = true;
                addorderbtn.Enabled = true;
            }catch { }
        }
    }
}
