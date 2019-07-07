using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modest_Attires
{
    public partial class old_addorder : Form
    {
        DBConnect obj = new DBConnect();
        MySqlDataReader dr;
        MySqlConnection con = new MySqlConnection("SERVER=182.50.133.78;DATABASE=lalchowk;USER=lalchowk;PASSWORD=Lalchowk@123uzmah");
        MySqlCommand cmd;

        public old_addorder(string email)
        {
            InitializeComponent();

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

                    dr = obj.Query("select distinct concat(pincode,':  ',postoffice) as pincode from pincodes where city='Srinagar' order by id asc");
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

                    ptypebox.DisplayMember = "Text";
                    var items = new[]
                    {
                         new {Text="Pre-Pay"},
                         new {Text ="Cash on Delivery"},
                    };
                    ptypebox.DataSource = items;
                    ptypebox.SelectedIndex = 1;

                    pcnbox.Checked = true;
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); };
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
                        string pconf = "";
                        if (pcybox.Checked)
                            pconf = "1";
                        else
                            pconf = "0";

                        string email = md5hash(emailtxt.Text);
                        string cmd = "INSERT INTO orders(`email`, `amount`,`timestamp`,`shipping`,`paymenttype`,`paymentconfirmed`, `transanctionid`,`itemcount`,`status`,`name`,`address1`,`address2`,`contact`,`pincode`,`city`,`loyaltybonus`,`deliveryguy`,`in_transit`,`alternate_contact`) values ('" + email + "','" + amounttxt.Text
                            + "',DATE_ADD(CURRENT_TIMESTAMP, INTERVAL 750 MINUTE),'" + shiptxt.Text + "','"+ptypebox.Text+"','"+pconf+"','SW','" + counttxt.Text + "','" + statustxt.Text + "','" + nametxt.Text + "','" + add1txt.Text + "','" + add2txt.Text + "','" + contacttxt.Text 
                            + "','" + pintxt.Text + "','" + citytxt.Text + "','" + loyaltxt.Text + "','"+devtxt.Text+"','0','"+altcontxt.Text+"')";
                        obj.nonQuery(cmd);
                        long orderid = userinfo.orid;
                        //    int orderid = obj.Count("SELECT LAST_INSERT_ID()");

                        obj.closeConnection();
                        pidtxt.Text = pidtxt.Text.Remove(pidtxt.Text.Length - 1);
                        string[] pids = pidtxt.Text.Split(',');
                        foreach (string pid in pids)
                        {
                            // MessageBox.Show(orderid.ToString());
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

                   
                    searchbtn.Enabled = false;
                    StringBuilder search = new StringBuilder(searchtxt.Text);
                    search.Replace(@"'", "\\'").Replace(@"\", "\\");

                    BackgroundWorker bg = new BackgroundWorker();
                    bg.DoWork += (o, a) =>
                    {
                        try
                        {
                            string id = (string)a.Argument;
                            string pattern = @"\s";
                            String[] words = Regex.Split(id, pattern);
                            string cmd = "select productid,supplierid,productname,mrp,price,dealerprice,stock,detail1,detail2,picture from products where ";
                            int x = 0;
                            foreach (var word in words)
                            {
                                if (x == 0)
                                    cmd = cmd + "tags like '%" + word + "%'";
                                else
                                    cmd = cmd + "and tags like '%" + word + "%'";
                                x++;

                            }

                            dr = obj.Query(cmd);
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
                          
                            searchbtn.Enabled = true;


                        }
                        catch { searchbtn.Enabled = true; }
                    };
                    bg.RunWorkerAsync(search.ToString());
                }
            }
            catch { }
        }
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
                    id = row.Cells["productid"].Value.ToString();
                    price = row.Cells["price"].Value.ToString();
                    addorderbtn.Enabled = true;
                }
            }
            catch { }
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
            if (emailtxt.Text == "")
            {
                MessageBox.Show("Please enter user account email first.", "Error");
            }
            else
            {
                if (pidtxt.Text != string.Empty)
                {
                    string email = md5hash(emailtxt.Text);
                    pidtxt.Text = pidtxt.Text.Remove(pidtxt.Text.Length - 1);
                    string[] pids = pidtxt.Text.Split(',');
                    Cursor = Cursors.WaitCursor;
                    foreach (string pid in pids)
                    {
                        try
                        {

                            string cmd1 = "insert into cartitems(`email`,`productid`,`quantity`)values('" + email + "','" + pid + "','1')";
                            obj.nonQuery(cmd1);

                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.ToString()); obj.closeConnection(); }

                    }
                    Cursor = Cursors.Arrow;
                    MessageBox.Show("Items added to cart successfully.", "Success.");
                    pidtxt.Text = "";
                    pidtxt.Visible = false;
                }
                else
                {
                    MessageBox.Show("Add products first.", "Error!");
                }
            }
        }

        private void addbonusbtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (tempbox.Checked)
            {
                try
                {

                    string cmd1 = "update customer set bonus='" + bonustxt.Text + "',temp=1 where mail='" + emailtxt.Text + "'";
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

        private void addbtn_Click(object sender, EventArgs e)
        {
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
                }
                catch { }
            }
        }

        private void oldlbl_Click(object sender, EventArgs e)
        {
            Close();
            addorder add = new addorder("");
            add.Show();
        }

        private void pcybox_CheckedChanged(object sender, EventArgs e)
        {
            if (pcybox.Checked)
                pcnbox.Checked = false;
        }

        private void pcnbox_CheckedChanged(object sender, EventArgs e)
        {
            if (pcnbox.Checked)
                pcybox.Checked = false;
        }


        private void statustxt_Leave(object sender, EventArgs e)
        {
            statustxt.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(statustxt.Text.ToLower());
        }



        //private void dldbtn_Click(object sender, EventArgs e)
        //{
        //    BackgroundWorker search = new BackgroundWorker();
        //    search.WorkerReportsProgress = true;
        //    search.DoWork += (o, a) =>
        //    {


        //        AutoCompleteStringCollection col1 = new AutoCompleteStringCollection();

        //        try
        //        {
        //            con.Open();
        //            string path = "C:\\Lalchowk\\data.txt";

        //            if (File.Exists(path))
        //            {
        //                DialogResult dgr = MessageBox.Show("File already exists. Do you want to update it ?", "Update?", MessageBoxButtons.YesNo);
        //                if (dgr == DialogResult.Yes)
        //                {
        //                    cmd = new MySqlCommand("Select concat_ws(' ',productname,'(',detail1,detail2,')','@',mrp,'#',productid) as tag from products where productid>9999", con);
        //                    MySqlDataReader data = cmd.ExecuteReader();
        //                    while (data.Read())
        //                    {
        //                        string sname = data.GetString("tag");
        //                        col1.Add(sname);


        //                       using (StreamWriter tw = File.AppendText(path))
        //                        {
        //                            tw.WriteLine(sname);
        //                            tw.WriteLine("\n");
        //                            tw.Close();
        //                        }
        //                    }
        //                }


        //            }
        //            else if(!File.Exists(path))
        //            {
        //                File.Create(path);
        //                File.Open(path, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
        //                cmd = new MySqlCommand("Select concat_ws(' ',productname,'(',detail1,detail2,')','@',mrp,'#',productid) as tag from products where productid>9999", con);
        //                MySqlDataReader data = cmd.ExecuteReader();

        //                while (data.Read())
        //                {
        //                    string sname = data.GetString("tag");
        //                    col1.Add(sname);

        //                          using (StreamWriter tw = File.AppendText(path))
        //                        {
        //                            tw.WriteLine(sname);
        //                            tw.WriteLine("\n");
        //                            tw.Close();
        //                        }


        //                }

        //            }


        //            con.Close();
        //            a.Result = col1;
        //        }
        //        catch (Exception ex) { con.Close(); MessageBox.Show(ex.Message); }

        //    };

        //    search.RunWorkerCompleted += (o, b) => {
        //        AutoCompleteStringCollection col2 = b.Result as AutoCompleteStringCollection;


        //        searchtxt.Text = "";

        //        searchtxt.AutoCompleteCustomSource = col2;
        //    };
        //    search.RunWorkerAsync();
        //}

        private void lastidbtn_Click(object sender, EventArgs e)
        {
            //StreamReader objReader = new StreamReader(@"C:\Lalchowk\data.txt");
            //string sLine = "";
            //ArrayList arrText = new ArrayList();

            //while (sLine != null)
            //{
            //    sLine = objReader.ReadLine();
            //    if (sLine != null)
            //        arrText.Add(sLine);
            //}
            //objReader.Close();
                
            //   arrText.Reverse();


            //foreach (string sOutput in arrText)
            //{
            //    string[] tokens= sOutput.Split(new[] { " # " }, StringSplitOptions.None);
            //    MessageBox.Show(tokens[3]);
            //}

        }
    }
    }
