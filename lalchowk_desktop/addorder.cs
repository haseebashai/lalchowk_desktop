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
using System.Text.RegularExpressions;

namespace Veiled_Kashmir_Admin_Panel
{
    public partial class addorder : Form
    {
        DBConnect obj = new DBConnect();
        MySqlDataReader dr;
        MySqlConnection con = new MySqlConnection("SERVER=182.50.133.78;DATABASE=lalchowk;USER=lalchowk;PASSWORD=Lalchowk@123uzmah");
        MySqlCommand cmd;
        private dialogcontainer dg = null;

        public addorder(Form dgcopy, string email)
        {
            dg = dgcopy as dialogcontainer;

            InitializeComponent();
            //searchtxt.AutoCompleteMode = AutoCompleteMode.Suggest;
            //searchtxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            searchtxt.AutoCompleteCustomSource = userinfo.col;

            string emailt = email;
            if (emailt != string.Empty)
            {
                emailtxt.Text = emailt;
            }
            else
            {
                emailtxt.Text = "lalchowkonline@gmail.com";
            }

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
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); };
            };
            pin.RunWorkerAsync();

        }

        //private void textchange()
        //{
        //    con.Close();
        //    searchtxt.AutoCompleteMode = AutoCompleteMode.Suggest;
        //    searchtxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
        //    BackgroundWorker search = new BackgroundWorker();
        //    search.DoWork += (o, a) =>
        //    {
        //        try
        //        {

        //            AutoCompleteStringCollection col = new AutoCompleteStringCollection();

        //            cmd = new MySqlCommand("Select concat(productname,' @',mrp) as tags from products", con);

        //            con.Open();
        //            MySqlDataReader data = cmd.ExecuteReader();
        //            while (data.Read())
        //            {
        //                string sname = data.GetString("tags");
        //                col.Add(sname);
        //            }
        //            con.Close();
        //            a.Result = col;

        //        }
        //        catch (Exception ex) { MessageBox.Show(ex.ToString()); }

        //    };
        //    search.RunWorkerCompleted += (o, b) => {
        //        AutoCompleteStringCollection col = b.Result as AutoCompleteStringCollection;
        //        searchtxt.AutoCompleteCustomSource = col;
        //    };
        //    search.RunWorkerAsync();


        //}

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
                if (inventorydatagridview.RowCount == 0)
                {
                    MessageBox.Show("Please select a product.", "Error!");
                }else
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
                        //pidtxt.Text = pidtxt.Text.Remove(pidtxt.Text.Length - 1);
                        //string[] pids = pidtxt.Text.Split(',');
                        //foreach (string pid in pids)
                        //{
                        //   // MessageBox.Show(orderid.ToString());
                        try
                        {
                            //        dr = obj.Query("select productname,price,mrp,dealerprice,picture from products where productid='" + pid + "'");
                            //        dr.Read();
                            //        string name = dr[0].ToString();
                            //        string price = dr[1].ToString();
                            //        string mrp = dr[2].ToString();
                            //        string dp = dr[3].ToString();
                            //        string pic = dr[4].ToString();
                            //        obj.closeConnection();

                            for (int i = 0; i < inventorydatagridview.RowCount; i++)
                            {
                                StringBuilder pname = new StringBuilder(inventorydatagridview.Rows[i].Cells[1].Value.ToString());
                                pname.Replace(@"'", "\\'").Replace(@"\", "\\");
                                string cmd1 = "insert into orderdetails(`orderid`,`productid`,`productname`,`price`,`quantity`,`discount`,`mrp`,`dealerprice`,`size`,`picture`)values" +
                                    "('" + orderid + "','" + inventorydatagridview.Rows[i].Cells[0].Value.ToString() + //pid
                                    "','" + pname + "','" + inventorydatagridview.Rows[i].Cells[4].Value.ToString() + //price
                                    "','" + inventorydatagridview.Rows[i].Cells[5].Value.ToString() + //quan
                                    "','" + inventorydatagridview.Rows[i].Cells[6].Value.ToString() + //dis
                                    "','" + inventorydatagridview.Rows[i].Cells[7].Value.ToString() + //mrp
                                    "','" + inventorydatagridview.Rows[i].Cells[8].Value.ToString() + //dp
                                    "',NULL,'" + inventorydatagridview.Rows[i].Cells[9].Value.ToString() + "')"; //pic
                                obj.nonQuery(cmd1);


                            }
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.ToString()); obj.closeConnection(); }
                    }
                    MessageBox.Show("Order added successfully.", "Success.");
                    inventorydatagridview.Columns.Clear();
                    addorderbtn.Enabled = false;
                }
                // }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); obj.closeConnection(); addorderbtn.Enabled = true; }
            Cursor = Cursors.Arrow;
        }

        public void loadingdg()
        {
            dg.lbl.ForeColor = SystemColors.Highlight;
            dg.lbl.Text = "Add new order";

        }

        //private void searchbtn_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (searchtxt.Text == "")
        //        {
        //            MessageBox.Show("Please enter a product.", "Error!");
        //        }
        //        else
        //        {

        //            loadinglbl.Visible = true;
                   
        //            StringBuilder search = new StringBuilder(searchtxt.Text);
        //            search.Replace(@"'", "\\'").Replace(@"\", "\\");

        //            BackgroundWorker bg = new BackgroundWorker();
        //            bg.DoWork += (o, a) =>
        //            {
        //                try
        //                {
        //                    string id = (string)a.Argument;
        //                    string pattern = @"\s";
        //                    String[] words = Regex.Split(id, pattern);
        //                    string cmd = "select productid,supplierid,productname,mrp,price,dealerprice,stock,detail1,detail2,picture from products where ";
        //                    int x = 0;
        //                    foreach (var word in words)
        //                    {
        //                        if (x == 0)
        //                            cmd = cmd + "tags like '%" + word + "%'";
        //                        else
        //                            cmd = cmd + "and tags like '%" + word + "%'";
        //                        x++;

        //                    }

        //                    dr = obj.Query(cmd);
        //                    DataTable dt = new DataTable();
        //                    dt.Load(dr);
        //                    obj.closeConnection();
        //                    BindingSource bsource = new BindingSource();
        //                    bsource.DataSource = dt;
        //                    a.Result = bsource;
        //                }
        //                catch { obj.closeConnection(); }
        //            };
        //            bg.RunWorkerCompleted += (o, b) =>
        //            {
        //                try
        //                {
        //                    BindingSource bsource = b.Result as BindingSource;
        //                    inventorydatagridview.DataSource = bsource;
        //                    inventorydatagridview.Columns["picture"].Visible = false;
        //                    loadinglbl.Visible = false;
                           


        //                }
        //                catch(Exception ex) { MessageBox.Show(ex.Message); }
        //            };
        //            bg.RunWorkerAsync(search.ToString());
        //        }
        //    } catch { }
        //}
        string id, price;
        private void inventorydatagridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.inventorydatagridview.Rows[e.RowIndex];
                    dp.SizeMode = PictureBoxSizeMode.StretchImage;
                    dp.ImageLocation = "http://lalchowk.in/lalchowk/pictures/" + row.Cells["picture"].Value.ToString();
                    
                   
                }
            } catch { }
        }

        private void pinbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pinbox.SelectedIndex > -1)
            {
                pintxt.Text = pinbox.Text.Split(':')[0];

            }
        }

        private void addtocartbtn_Click(object sender, EventArgs e)
        {
            if (inventorydatagridview.RowCount == 0)
            {
                MessageBox.Show("Add Products First.", "Error!");
            }
            else
            if (emailtxt.Text == "")
            {
                MessageBox.Show("Please enter user account email first.", "Error");
            }
            else
            {
                string email = md5hash(emailtxt.Text);

                Cursor = Cursors.WaitCursor;
                for (int i = 0; i < inventorydatagridview.RowCount; i++)
                {
                    try
                    {

                        string cmd1 = "insert into cartitems(`email`,`productid`,`quantity`)values('" + email + "','" + inventorydatagridview.Rows[i].Cells[0].Value.ToString() +
                        "','" + inventorydatagridview.Rows[i].Cells[5].Value.ToString() + "')";
                        obj.nonQuery(cmd1);

                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.ToString()); obj.closeConnection(); }

                }
                Cursor = Cursors.Arrow;
                MessageBox.Show("Items added to cart successfully.", "Success.");
                inventorydatagridview.Columns.Clear();
            }

        }

    

        private void addbonusbtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (tempbox.Checked)
            {
                try
                {

                    string cmd1 = "update customer set bonus='"+bonustxt.Text+"',temp=1 where mail='"+emailtxt.Text+"'";
                    obj.nonQuery(cmd1);
                    MessageBox.Show("Temporary Bonus added to user.", "Success");
                    obj.closeConnection();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.ToString()); obj.closeConnection(); }
            }
            else
            {
                try
                {

                    string cmd1 = "update customer set bonus='" + bonustxt.Text + "',temp=0 where mail='" + emailtxt.Text + "'";
                    obj.nonQuery(cmd1);
                    MessageBox.Show("Bonus added to user.", "Success");
                    obj.closeConnection();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.ToString()); obj.closeConnection(); }

            }
            Cursor = Cursors.Arrow;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (searchtxt.Text == "")
                {
                    MessageBox.Show("Please search a product.", "Error!");
                }
                else
                {
                    Cursor = Cursors.WaitCursor;
                    string name = searchtxt.Text.Split('@')[0];
                    StringBuilder productname = new StringBuilder(name);
                    productname.Replace(@"'", "\\'").Replace(@"\", "\\");
                    string mrp = searchtxt.Text.Split('@')[1];
                    if (inventorydatagridview.RowCount == 0)
                    {
                        inventorydatagridview.Columns.Add("productid", "productid");
                        inventorydatagridview.Columns.Add("productname", "productname");
                        inventorydatagridview.Columns.Add("author", "author");
                        inventorydatagridview.Columns.Add("publisher", "publisher");
                        inventorydatagridview.Columns.Add("price", "price");
                        inventorydatagridview.Columns.Add("quantity", "quantity");
                        inventorydatagridview.Columns.Add("discount", "discount");
                        inventorydatagridview.Columns.Add("mrp", "mrp");
                        inventorydatagridview.Columns.Add("dealerprice", "dealerprice");
                        inventorydatagridview.Columns.Add("picture", "picture");

                        dr = obj.Query("select productid,productname,detail1,detail2,price,mrp,dealerprice,picture from products where productname='" + productname + "' and mrp='" + mrp + "'");
                        dr.Read();
                        inventorydatagridview.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), "1", "10", dr[5].ToString(), dr[6].ToString(), dr[7].ToString());
                        obj.closeConnection();
                    }
                    else
                    {
                        dr = obj.Query("select productid,productname,detail1,detail2,price,mrp,dealerprice,picture from products where productname='" + productname + "' and mrp='" + mrp + "'");
                        dr.Read();
                        inventorydatagridview.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), "1", "10", dr[5].ToString(), dr[6].ToString(), dr[7].ToString());
                        obj.closeConnection();
                    }
                    searchtxt.Text = "";
                    addorderbtn.Enabled = true;
                }
            }catch(Exception ex) { MessageBox.Show(ex.Message); obj.closeConnection(); }
            Cursor = Cursors.Arrow;
        }


        private void refresh_Click(object sender, EventArgs e)
        {
            refresh.Enabled = false;

            loadinglbl.Visible = true;
            searchtxt.Enabled = false;
            try
            {
                con.Close();
                
                BackgroundWorker search = new BackgroundWorker();
                search.WorkerReportsProgress = true;
                search.DoWork += (o, a) =>
                {

                    search.ReportProgress(10);
                    AutoCompleteStringCollection col1 = new AutoCompleteStringCollection();

                    cmd = new MySqlCommand("Select concat(productname,' @',mrp) as tags from products", con);

                    con.Open();
                    search.ReportProgress(30);
                    MySqlDataReader data = cmd.ExecuteReader();
                    while (data.Read())
                    {
                        string sname = data.GetString("tags");
                        col1.Add(sname);
                    }
                    search.ReportProgress(90);
                    con.Close();
                    a.Result = col1;
                    
                };
                search.ProgressChanged += (o, c) =>
                {
                    if (c.ProgressPercentage == 10)
                    {
                        loadinglbl.Text = "loading...10%";
                    }else if(c.ProgressPercentage == 30)
                    {
                        loadinglbl.Text = "loading...30%";
                    }
                    else if (c.ProgressPercentage == 90)
                    {
                        loadinglbl.Text = "loading...90%";
                    }

                };

                search.RunWorkerCompleted += (o, b) => {
                    userinfo.col = b.Result as AutoCompleteStringCollection;
                    loadinglbl.Visible = false;
                    searchtxt.Enabled = true;
                    refresh.Enabled = true;
                    searchtxt.AutoCompleteCustomSource = userinfo.col;
                };
                search.RunWorkerAsync();

            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); con.Close(); }
            
        }

    }
}
