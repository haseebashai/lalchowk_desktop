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
using System.Globalization;

namespace Veiled_Kashmir_Admin_Panel
{
    public partial class addorder : Form
    {
        DBConnect obj = new DBConnect();
        MySqlDataReader dr;
        MySqlConnection con = new MySqlConnection("SERVER=182.50.133.78;DATABASE=lalchowk;USER=lalchowk;PASSWORD=Lalchowk@123uzmah");
        MySqlCommand cmd;
        
    //    private dialogcontainer dg = null;

        public addorder(string email)
        {
          //  dg = dgcopy as dialogcontainer;

            InitializeComponent();
            //searchtxt.AutoCompleteMode = AutoCompleteMode.Suggest;
            //searchtxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            searchtxt.AutoCompleteCustomSource = userinfo.col;
         
            //String[] _values = { "one", "two", "three", "tree", "four", "fivee ghj","haseeb ashai" };

         //   autotxt.Values = _values;

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
                        string pconf = "";
                        if (pcybox.Checked)
                            pconf = "1";
                        else
                            pconf = "0";

                        string email = md5hash(emailtxt.Text);
                        string cmd = "INSERT INTO orders(`email`, `amount`,`timestamp`,`shipping`,`paymenttype`,`paymentconfirmed`, `transanctionid`,`itemcount`,`status`,`name`,`address1`,`address2`,`contact`,`pincode`,`city`,`loyaltybonus`,`deliveryguy`,`in_transit`,`alternate_contact`) values ('" + email + "','" + amounttxt.Text
                            + "',DATE_ADD(CURRENT_TIMESTAMP, INTERVAL 750 MINUTE),'" + shiptxt.Text + "','"+ptypebox.Text+"','"+pconf+"','SW','" + counttxt.Text + "','" + statustxt.Text + "','" + nametxt.Text + "','" + add1txt.Text + "','" + add2txt.Text + "','" + contacttxt.Text + "','" + pintxt.Text + "','" + citytxt.Text 
                            + "','" + loyaltxt.Text + "','"+devtxt.Text+"','0','"+altcontxt.Text+"')";
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
                        MessageBox.Show("Order added successfully.", "Success.");
                        inventorydatagridview.Columns.Clear();
                        addorderbtn.Enabled = false;
                        dp.Visible = false;
                    }
                   
                    
                }
                // }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); obj.closeConnection(); addorderbtn.Enabled = true; }
            Cursor = Cursors.Arrow;
        }

        //public void loadingdg()
        //{
        //    dg.lbl.ForeColor = SystemColors.Highlight;
        //    dg.lbl.Text = "Add new order";

        //}

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
                    //string name = searchtxt.Text.Split('(')[0];
                    //StringBuilder productname = new StringBuilder(name);
                    //productname.Replace(@"'", "\\'").Replace(@"\", "\\");
                    //string mrp = searchtxt.Text.Split('@')[1];
                    string id= searchtxt.Text.Split('#')[1];
                    if (inventorydatagridview.RowCount == 0 && inventorydatagridview.ColumnCount == 0)
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

                        dr = obj.Query("select productid,productname,detail1,detail2,price,mrp,dealerprice,picture from products where productid='" + id + "'");
                        dr.Read();
                        inventorydatagridview.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), "1", "10", dr[5].ToString(), dr[6].ToString(), dr[7].ToString());
                        obj.closeConnection();
                        amounttxt.Text = inventorydatagridview.Rows[0].Cells[4].Value.ToString();
                        counttxt.Text = inventorydatagridview.Rows[0].Cells[5].Value.ToString();
                    }
                    else
                    {
                        dr = obj.Query("select productid,productname,detail1,detail2,price,mrp,dealerprice,picture from products where productid='" + id + "'");
                        dr.Read();
                        inventorydatagridview.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), "1", "10", dr[5].ToString(), dr[6].ToString(), dr[7].ToString());
                        obj.closeConnection();
                        int amount=0,count=0;
                        for (int i = 0; i < inventorydatagridview.RowCount; i++)
                        {

                            amount = int.Parse(amounttxt.Text);
                            amount = amount + int.Parse(inventorydatagridview.Rows[i].Cells[4].Value.ToString());
                            count = int.Parse(counttxt.Text);
                            count = count + int.Parse(inventorydatagridview.Rows[i].Cells[5].Value.ToString());

                        }
                        amounttxt.Text = amount.ToString();
                        counttxt.Text = count.ToString();
                    }
                    searchtxt.Text = "";
                    addorderbtn.Enabled = true;
                      
                }
            }catch(Exception ex) { MessageBox.Show(ex.Message); obj.closeConnection(); }
            Cursor = Cursors.Arrow;
        }

        private void label15_Click(object sender, EventArgs e)
        {
            refresh_Click(null, null);
        }

        private void oldlbl_Click(object sender, EventArgs e)
        {

            Close();
            old_addorder old = new old_addorder(emailtxt.Text);

            old.Show();

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

        private void inventorydatagridview_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {



                int price = 0, quant = 0;
                for (int i = 0; i < inventorydatagridview.Rows.Count; i++)
                {
                    price = price + (Convert.ToInt32(inventorydatagridview.Rows[i].Cells["price"].Value) * Convert.ToInt32(inventorydatagridview.Rows[i].Cells["quantity"].Value));
                    quant = quant + Convert.ToInt32(inventorydatagridview.Rows[i].Cells["quantity"].Value);
                }
                amounttxt.Text = price.ToString();
                counttxt.Text = quant.ToString();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void inventorydatagridview_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {


                int price = 0,quant=0;
                for (int i = 0; i < inventorydatagridview.Rows.Count; i++)
                {
                    price = price + (Convert.ToInt32(inventorydatagridview.Rows[i].Cells["price"].Value) * Convert.ToInt32(inventorydatagridview.Rows[i].Cells["quantity"].Value));
                    quant = quant + Convert.ToInt32(inventorydatagridview.Rows[i].Cells["quantity"].Value);
                }
                amounttxt.Text = price.ToString();
                counttxt.Text = quant.ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void statustxt_Leave(object sender, EventArgs e)
        {
            statustxt.Text= CultureInfo.CurrentCulture.TextInfo.ToTitleCase(statustxt.Text.ToLower());
        }

        private void emailtxt_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Enter)
                {
                    string email = md5hash(emailtxt.Text);

                    BackgroundWorker details = new BackgroundWorker();
                    details.DoWork += (o, a) =>
                    {
                        dr = obj.Query("Select name,address1,address2,contact,alternate_contact,city,pincode from addresses where email='" + email + "'");
                        dr.Read();
                        string name, address1, address2, contact, alternate_contact, city, pincode;
                        name = dr[0].ToString();
                        address1 = dr[1].ToString();
                        address2 = dr[2].ToString();
                        contact = dr[3].ToString();
                        alternate_contact = dr[4].ToString();
                        city = dr[5].ToString();
                        pincode = dr[6].ToString();
                        obj.closeConnection();
                        object[] arg = { name, address1, address2, contact, alternate_contact, city, pincode };
                        a.Result = arg;
                    };
                    details.RunWorkerCompleted += (o, b) => 
                    {
                        object[] arg = (object[])b.Result;
                        nametxt.Text = arg[0].ToString();
                        add1txt.Text = arg[1].ToString();
                        add2txt.Text = arg[2].ToString();
                        contacttxt.Text = arg[3].ToString();
                        altcontxt.Text = arg[4].ToString();
                        citytxt.Text = arg[5].ToString();
                        pintxt.Text = arg[6].ToString();

                    };
                    details.RunWorkerAsync();
                }
            }catch { obj.closeConnection(); }
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

                    
                 //   var items = new List<string>();

                    cmd = new MySqlCommand("Select concat_ws(' ',productname,'(',detail1,detail2,')','@',mrp,'#',productid) as tag from products where productid>9999", con);
                    try
                    {
                        con.Open();
                        search.ReportProgress(30);
                        //int i = 0;
                        //using (var dr = cmd.ExecuteReader())
                        //{
                        //    while (dr.Read())
                        //    {
                        //        string item;
                        //        {
                        //            item = dr[0].ToString();
                        //        };

                        //        items.Add(item);
                        //    };

                        //};


                       
                        MySqlDataReader data = cmd.ExecuteReader();
                        while (data.Read())
                        {
                            string sname = data.GetString("tag");
                            col1.Add(sname);
                        }
                        search.ReportProgress(90);
                        con.Close();
                        a.Result = col1;
                    }
                    catch(Exception ex) { MessageBox.Show(ex.ToString()); }
                    
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

                    // List<string> col = (List<string>)b.Result;
                    userinfo.col = b.Result as AutoCompleteStringCollection;
                    loadinglbl.Visible = false;
                    searchtxt.Enabled = true;
                    searchtxt.Text = "";
                    refresh.Enabled = true;
                    searchtxt.AutoCompleteCustomSource = userinfo.col;
                    //string[] names = col.Select(i => i.ToString()).ToArray();
                    //autotxt.Values =names;
                };
                search.RunWorkerAsync();

            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); con.Close(); }
            
        }

    }
    public class AutoCompleteTextBox : TextBox
    {
        private ListBox _listBox;
        private bool _isAdded;
        private String[] _values;
        private String _formerValue = String.Empty;

        public AutoCompleteTextBox()
        {
            InitializeComponent();
            ResetListBox();
        }

        private void InitializeComponent()
        {
            _listBox = new ListBox();
            KeyDown += this_KeyDown;
            KeyUp += this_KeyUp;
        }

        private void ShowListBox()
        {
            if (!_isAdded)
            {
                Parent.Controls.Add(_listBox);
                _listBox.Left = Left;
                _listBox.Top = Top + Height;
                _isAdded = true;
            }
            _listBox.Visible = true;
            _listBox.BringToFront();
        }

        private void ResetListBox()
        {
            _listBox.Visible = false;
        }

        private void this_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateListBox();
        }

        private void this_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Tab:
                    {
                        if (_listBox.Visible)
                        {
                            InsertWord((String)_listBox.SelectedItem);
                            ResetListBox();
                            _formerValue = Text;
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        if ((_listBox.Visible) && (_listBox.SelectedIndex < _listBox.Items.Count - 1))
                            _listBox.SelectedIndex++;

                        break;
                    }
                case Keys.Up:
                    {
                        if ((_listBox.Visible) && (_listBox.SelectedIndex > 0))
                            _listBox.SelectedIndex--;

                        break;
                    }
            }
        }

        protected override bool IsInputKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Tab:
                    return true;
                default:
                    return base.IsInputKey(keyData);
            }
        }

        private void UpdateListBox()
        {
            if (Text == _formerValue) return;
            _formerValue = Text;
            String word = GetWord();

            if (_values != null && word.Length > 0)
            {
                String[] matches = Array.FindAll(_values,
                                                 x => (x.StartsWith(word) && !SelectedValues.Contains(x)));
                if (matches.Length > 0)
                {
                    ShowListBox();
                    _listBox.Items.Clear();
                    Array.ForEach(matches, x => _listBox.Items.Add(x));
                    _listBox.SelectedIndex = 0;
                    _listBox.Height = 0;
                    _listBox.Width = 0;
                    Focus();
                    using (Graphics graphics = _listBox.CreateGraphics())
                    {
                        for (int i = 0; i < _listBox.Items.Count; i++)
                        {
                            _listBox.Height += _listBox.GetItemHeight(i);
                            // it item width is larger than the current one
                            // set it to the new max item width
                            // GetItemRectangle does not work for me
                            // we add a little extra space by using '_'
                            int itemWidth = (int)graphics.MeasureString(((String)_listBox.Items[i]) + "_", _listBox.Font).Width;
                            _listBox.Width = (_listBox.Width < itemWidth) ? itemWidth : _listBox.Width;
                        }
                    }
                }
                else
                {
                    ResetListBox();
                }
            }
            else
            {
                ResetListBox();
            }
        }

        private String GetWord()
        {
            String text = Text;
            int pos = SelectionStart;

            int posStart = text.LastIndexOf(' ', (pos < 1) ? 0 : pos - 1);
            posStart = (posStart == -1) ? 0 : posStart + 1;
            int posEnd = text.IndexOf(' ', pos);
            posEnd = (posEnd == -1) ? text.Length : posEnd;

            int length = ((posEnd - posStart) < 0) ? 0 : posEnd - posStart;

            return text.Substring(posStart, length);
        }

        private void InsertWord(String newTag)
        {
            String text = Text;
            int pos = SelectionStart;

            int posStart = text.LastIndexOf(' ', (pos < 1) ? 0 : pos - 1);
            posStart = (posStart == -1) ? 0 : posStart + 1;
            int posEnd = text.IndexOf(' ', pos);

            String firstPart = text.Substring(0, posStart) + newTag;
            String updatedText = firstPart + ((posEnd == -1) ? "" : text.Substring(posEnd, text.Length - posEnd));


            Text = updatedText;
            SelectionStart = firstPart.Length;
        }

        public String[] Values
        {
            get
            {
                return _values;
            }
            set
            {
                _values = value;
            }
        }

        public List<String> SelectedValues
        {
            get
            {
                String[] result = Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                return new List<String>(result);
            }
        }

    }

}