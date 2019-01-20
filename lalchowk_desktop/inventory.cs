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
using System.Net;
using System.IO;

namespace Veiled_Kashmir_Admin_Panel
{
    public partial class inventory : Form
    {
        DBConnect obj = new DBConnect();
        String cmd;
        MySqlConnection con;
        MySqlDataAdapter adap;

        MySqlDataReader dr;
        DataTable dt;
        MySqlCommandBuilder cmdbl;
        BindingSource bsource;



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
            catidtxt.Text = "";

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
                dv.RowFilter = string.Format("detail1 LIKE '%{0}%'", supidtxt.Text);
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
                dv.RowFilter = string.Format("tags LIKE '%{0}%'", pronametxt.Text);
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

        string picadd,idlbl;
        private void inventorydatagridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.inventorydatagridview.Rows[e.RowIndex];
                //dp.SizeMode = PictureBoxSizeMode.StretchImage;
                //dp.ImageLocation = "http://lalchowk.in/lalchowk/pictures/" + row.Cells["picture"].Value.ToString();
                progresspc.Text = "";
                progresspc.Visible = false;
                idlbl = row.Cells["productid"].Value.ToString();
                productlbl.Text = row.Cells["productname"].Value.ToString();
                desctxtbox.Text = row.Cells["description"].Value.ToString();
                picadd = row.Cells["picture"].Value.ToString();
                dp.SizeMode = PictureBoxSizeMode.StretchImage;
                dp.ImageLocation = "http://lalchowk.in/lalchowk/pictures/" + picadd;
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

                if (!Regex.IsMatch(desctxtbox.Text, @"^([a-zA-Z0-9@#$%&*+\-_(),+':;?.,![\]\s\\/{}""|]+)$") && desctxtbox.Text != "")
                {

                    MessageBox.Show("Abnormal Special Character found, Please remove it and proceed.");

                }
                else
                {
                    Cursor = Cursors.WaitCursor;
                    StringBuilder desc = new StringBuilder(desctxtbox.Text);
                    desc.Replace(@"\", @"\\").Replace("'", "\\'");

                    cmd = ("update products set `description`='" + desc + "' where `productid`='" + idlbl + "'");
                    obj.nonQuery(cmd);

                    MessageBox.Show("Description Updated.");
                    // readinventory();
                }
                Cursor = Cursors.Arrow;

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
        bool catsel = false;
        private void secbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (secbox.SelectedIndex != -1)
            {

                string id = secbox.Text.Split(':')[0];
                catsel = true;
                catidtxt.Text = id;
                if (supbox.SelectedIndex > 0)
                {
                    catsuplbl.Text = "Category ID";
                }
            }
        }

        private void thirdbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (thirdbox.SelectedIndex != -1)
            {

                string id = thirdbox.Text.Split(':')[0];
                catsel = true;
                catidtxt.Text = id;
                if (supbox.SelectedIndex > 0)
                {
                    catsuplbl.Text = "Category ID";
                }
            }
        }
        bool supplier = false;
        private void supbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (supbox.SelectedIndex != -1)
            {


                string id = supbox.Text.Split(':')[0];
                supplier = true;
                catidtxt.Text = id;
                if (supbox.SelectedIndex > 0)
                {
                    catsuplbl.Text = "Supplier ID";
                }
            }
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            secbox.SelectedIndex = -1;
            thirdbox.SelectedIndex = -1;
            supbox.SelectedIndex = -1;
            catidtxt.Text = "";
            pidtxt.Text = "";
            searchtxt.Text = "";
            catsuplbl.Text = "Cat/Sup ID";
            catsuplbl.Font = new Font(catsuplbl.Font, FontStyle.Regular);
            plbl.Font = new Font(plbl.Font, FontStyle.Regular);
            searchlbl.Font = new Font(searchlbl.Font, FontStyle.Regular);
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

        bool cat = false, proid = false;

        private void pidtxt_TextChanged(object sender, EventArgs e)
        {
            cat = false;
            proid = true;
            catsuplbl.Font = new Font(catsuplbl.Font, FontStyle.Regular);
            catsuplbl.Text = "Cat/Sup ID";
            plbl.Font = new Font(plbl.Font, FontStyle.Bold);
            searchlbl.Font = new Font(searchlbl.Font, FontStyle.Regular);
            search = false;

        }

        private void catidtxt_TextChanged_1(object sender, EventArgs e)
        {
            string id = catidtxt.Text;
            cat = true;
            proid = false;
            search = false;
           
            if (catsel)
            {
                catsuplbl.Text = "Category ID";
                catsuplbl.Font = new Font(catsuplbl.Font, FontStyle.Bold);
                plbl.Font = new Font(plbl.Font, FontStyle.Regular);
                searchlbl.Font = new Font(searchlbl.Font, FontStyle.Regular);

            }
            else if (supplier)
            {
                catsuplbl.Text = "Supplier ID";
                catsuplbl.Font = new Font(catsuplbl.Font, FontStyle.Bold);
                plbl.Font = new Font(plbl.Font, FontStyle.Regular);
                searchlbl.Font = new Font(searchlbl.Font, FontStyle.Regular);

            }
        }

        private void searchtxt_TextChanged(object sender, EventArgs e)
        {
            cat = false;
            proid = false;
            search = true;
            catsuplbl.Font = new Font(catsuplbl.Font, FontStyle.Regular);
            catsuplbl.Text = "Cat/Sup ID";
            plbl.Font = new Font(plbl.Font, FontStyle.Regular);
            searchlbl.Font = new Font(searchlbl.Font, FontStyle.Bold);
        }

        string id; bool search = false;
        private void listbtn_Click(object sender, EventArgs e)
        {
            descpnl.Visible = false;
            listbtn.Enabled = false;
            if (catidtxt.Text == "" && pidtxt.Text == "" && searchtxt.Text == "")
            {
                MessageBox.Show("Please select an option first.", "Error!");
                listbtn.Enabled = true;
            }
            else
            {
                if (cat)
                {
                    id = catidtxt.Text;
                    loadinglbl.Visible = true;
                    bgworker.RunWorkerAsync();
                } else if (proid)
                {
                    id = pidtxt.Text;
                    loadinglbl.Visible = true;
                    bgworker.RunWorkerAsync();
                } else if (search)
                {
                    StringBuilder search = new StringBuilder(searchtxt.Text);
                    search.Replace(@"'", "\\'").Replace(@"\", "\\");
                    id = search.ToString();
                    loadinglbl.Visible = true;
                    bgworker.RunWorkerAsync();
                }
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
            try
            {
                if (dt.Rows.Count == 0)
                {
                    ipnl.Visible = false;
                    descpnl.Visible = false;
                    upbtn.Visible = false;
                    listbtn.Enabled = true;
                    loadinglbl.Visible = false;
                    MessageBox.Show("No results found.\n\n- Please check for correct spelling.\n\n- Please make sure that category selected is final.\n- Supplier or Product ID is correct.", "Error!");

                }
                else
                {
                    inventorydatagridview.DoubleBuffered(true);
                    inventorydatagridview.DataSource = bsource;
                    ipnl.Visible = true;
                    upbtn.Visible = true;
                    listbtn.Enabled = true;
                    loadinglbl.Visible = false;
                }
            } catch { listbtn.Enabled = true; }
        }

        private void dldpic_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    dldpic.Enabled = false;
                    dldpic.Text = "Downloading...";
                    string downloadpath = folderDialog.SelectedPath;

                    BackgroundWorker pic = new BackgroundWorker();
                    pic.DoWork += (o, a) =>
                    {
                        try
                        {
                            string url = "ftp://lalchowk.in/httpdocs/lalchowk/pictures/" + picadd;
                            string ext = Path.GetExtension(url);
                            if (ext != "")
                            {

                                NetworkCredential credentials = new NetworkCredential("Lalchowk", "Lalchowk@123");

                                // Query size of the file to be downloaded
                                FtpWebRequest sizeRequest = (FtpWebRequest)WebRequest.Create(url);
                                sizeRequest.Credentials = credentials;
                                sizeRequest.Method = WebRequestMethods.Ftp.GetFileSize;
                                long size = sizeRequest.GetResponse().ContentLength / 1000;
          


                                // Download the file
                                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
                                request.Credentials = credentials;
                                request.Timeout = 10000;
                                request.Method = WebRequestMethods.Ftp.DownloadFile;
                                string filename = url.Substring(url.LastIndexOf("/") + 1);



                                using (Stream ftpStream = request.GetResponse().GetResponseStream())
                                using (Stream fileStream = File.Create(downloadpath + "\\" + filename))
                                {
                                    byte[] buffer = new byte[10240];
                                    int read;
                                    int total = 0;
                                    while ((read = ftpStream.Read(buffer, 0, buffer.Length)) > 0)
                                    {
                                        fileStream.Write(buffer, 0, read);
                                        total += read;

                                        progresspc.Invoke(
                                            (MethodInvoker)delegate { progresspc.Visible = true; progresspc.Text = "(" + total / 1000 + "/" + size + ") KB"; });
                                    }
                                }
                                a.Result = "success";
                            }
                           

                        }
                        catch (Exception ex) { MessageBox.Show(ex.ToString()); a.Result = "fail"; }
                    };


                    pic.RunWorkerCompleted += (o, b) =>
                    {
                        try
                        {
                            string result = b.Result as string;
                            if (result == "success")
                            {
                                MessageBox.Show("Picture downloaded.");
                                progresspc.Text = "";
                                
                            }
                            else if (result == "fail")
                            {
                                MessageBox.Show("Download failed.");
                            }
                           dldpic.Text = "Download";
                           dldpic.Enabled = true;
                        }
                        catch { }
                    };

                    pic.RunWorkerAsync();


                }
            }         
        }

        private void readinventory()
        {
            try {
                con = new MySqlConnection();
                con.ConnectionString = "SERVER=182.50.133.78;DATABASE=lalchowk;USER=lalchowk;PASSWORD=Lalchowk@123uzmah";
                con.Open();

                if(catsuplbl.Text=="Category ID" && catsuplbl.Font.Bold)
                {
                    adap = new MySqlDataAdapter("select * from products where categoryid='" + id + "'", con);
                }
                else if(catsuplbl.Text == "Supplier ID" && catsuplbl.Font.Bold)
                {
                    adap = new MySqlDataAdapter("select * from products where supplierid='" + id + "'", con);
                }
                else if(plbl.Text=="Product ID" && plbl.Font.Bold==true && catsuplbl.Font.Bold == false)
                {
                    
                    adap = new MySqlDataAdapter("select * from products where productid='" + id + "'", con);
                }
                else if (search)
                {
                    string pattern=@"\s";
                    String[] words = Regex.Split(id,pattern);
                    
                    string cmd = "select * from products where ";
                    int x = 0;
                    foreach (var word in words)
                    {
                        if (x == 0)
	                      cmd =cmd + "tags like '%" + word + "%'";
                        else
                          cmd =cmd + "and tags like '%" + word + "%'";	
                        x++;
                       
                    }
                    adap = new MySqlDataAdapter(cmd, con);
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
