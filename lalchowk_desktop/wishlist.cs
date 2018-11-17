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
using System.Net;
using System.IO;
using System.Web;

namespace Veiled_Kashmir_Admin_Panel
{
   

    public partial class wishlist : Form
    {
        private dialogcontainer dg = null;
        DBConnect obj = new DBConnect();
        MySqlDataAdapter adap;
        DataTable dt;
        BindingSource bsource;
        MySqlConnection con = new MySqlConnection("SERVER=182.50.133.78;DATABASE=lalchowk;USER=lalchowk;PASSWORD=Lalchowk@123uzmah");



        public wishlist(Form dgcopy)
        {
            dg = dgcopy as dialogcontainer;
            InitializeComponent();
            BackgroundWorker load = new BackgroundWorker();
            load.RunWorkerCompleted += Load_RunWorkerCompleted;
            load.DoWork += Load_DoWork;
            load.RunWorkerAsync();

        }
        private void Load_DoWork(object sender, DoWorkEventArgs e)
        {
            readwishlist();
        }

        private void Load_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dg.loadingimage.Visible = false;
            dg.lbl.ForeColor = SystemColors.Highlight;
            dg.lbl.Text = "Wishlist Items";
            cartdataview.DataSource = bsource;
            pnl.Visible = true;
        }

        private void readwishlist()
        {
            try
            {
                con.Open();
                adap = new MySqlDataAdapter("SELECT wishlist.wishlistid,customer.name,customer.mail,customer.contact,wishlist.productid,products.productname FROM customer LEFT JOIN wishlist ON (customer.email=wishlist.email) left join products on (wishlist.productid=products.productid) where products.stock>0 and customer.contact!='' order by wishlistid desc", con);
                dt = new DataTable();
                adap.Fill(dt);
                con.Close();
                bsource = new BindingSource();
                bsource.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void loadingdg()
        {
            dg.lbl.ForeColor = SystemColors.Highlight;
            dg.lbl.Text = "Loading";
            dg.loadingimage.SizeMode = PictureBoxSizeMode.StretchImage;
            dg.loadingimage.Visible = true;
        }

        int cartid = 0, productid = 0;
        string productname, name, email;
        private void cartdataview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.cartdataview.Rows[e.RowIndex];
                    numbertxt.Text = row.Cells["contact"].Value.ToString();
                    cartid = int.Parse(row.Cells["wishlistid"].Value.ToString());
                    productid = int.Parse(row.Cells["productid"].Value.ToString());
                    productname = row.Cells["productname"].Value.ToString();
                    name = row.Cells["name"].Value.ToString();
                    email = row.Cells["mail"].Value.ToString();
                    smspnl.Visible = true;
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        private void emailtxt_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = string.Format("mail LIKE '%{0}%'", emailtxt.Text);
            cartdataview.DataSource = dv;
        }

        private void contacttxt_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = string.Format("convert([contact],System.String) LIKE '%{0}%'", contacttxt.Text);
            cartdataview.DataSource = dv;
        }

        private void producttxt_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = string.Format("productname LIKE '%{0}%'", producttxt.Text);
            cartdataview.DataSource = dv;
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            smspnl.Visible = false;
            cartdataview.Enabled = false;
            pnl.Enabled = false;
            refresh.Enabled = false;
            readwishlist();
            cartdataview.DataSource = bsource;
            cartdataview.Enabled = true;
            pnl.Enabled = true;
            refresh.Enabled = true;
            Cursor = Cursors.Arrow;
        }
        private void sendsmsbtn_Click(object sender, EventArgs e)
        {
            singlesms();
            singlesms();
            singlesms();
            sendsmsbtn.Enabled = true;
        }

        private void smstxt_TextChanged(object sender, EventArgs e)
        {
            charlbl.Visible = true;
            int max = 320;
            int charac = smstxt.Text.Length;
            charlbl.Text = "(" + (max - charac) + "/320)";
        }

        private void emailbtn_Click(object sender, EventArgs e)
        {
            if (email == null)
            {
                MessageBox.Show("Please select a user first.");

            }
            else
            {
                dialogcontainer dg = new dialogcontainer();
                promomail pm = new promomail(email, dg,"","");
                pm.TopLevel = false;
                dg.Size = new Size(700, 715);
                pm.epnl.Location = new Point(-300, 1);
                pm.elistlbl.Text = "";

                dg.dialogpnl.Controls.Add(pm);
                pm.loadingdg();
                dg.Text = "Send Email";

                dg.Show();

                pm.Show();
            }
        }
        private void nametxt_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = string.Format("name LIKE '%{0}%'", nametxt.Text);
            cartdataview.DataSource = dv;
        }
        private void singlesms()
        {
            Cursor = Cursors.WaitCursor;
            //     string authKey = "180732AO0nQdUZo759f09569";             //old authentication key

            string authKey = "219357Aj6P2wTP5b1902ab";

            string mobileNumber = numbertxt.Text;                   //Multiple mobiles numbers separated by comma

            string senderId = sendertxt.Text;                        //Sender ID,While using route4 sender id should be 6 characters long.

            string message = HttpUtility.UrlEncode(smstxt.Text);    //Your message to send, Add URL encoding here.

            //Prepare you post parameters
            StringBuilder sbPostData = new StringBuilder();
            sbPostData.AppendFormat("authkey={0}", authKey);
            sbPostData.AppendFormat("&mobiles={0}", mobileNumber);
            sbPostData.AppendFormat("&message={0}", message);
            sbPostData.AppendFormat("&sender={0}", senderId);
            sbPostData.AppendFormat("&route={0}", "4");
            sbPostData.AppendFormat("&country={0}", "91");

            try
            {
                //Call Send SMS API
                string sendSMSUri = "http://api.msg91.com/api/sendhttp.php";
                //Create HTTPWebrequest
                HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(sendSMSUri);
                //Prepare and Add URL Encoded data
                UTF8Encoding encoding = new UTF8Encoding();
                byte[] data = encoding.GetBytes(sbPostData.ToString());
                //Specify post method
                httpWReq.Method = "POST";
                httpWReq.ContentType = "application/x-www-form-urlencoded";
                httpWReq.ContentLength = data.Length;

                using (Stream stream = httpWReq.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
                //Get the response
                HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string responseString = reader.ReadToEnd();

                //Close the response
                reader.Close();
                response.Close();
                sentlbl.Visible = true;
            }
            catch (SystemException ex)
            {
                sentlbl.Text = "Sending failed X";
                sentlbl.ForeColor = Color.Red;
                Cursor = Cursors.Arrow;
                MessageBox.Show(ex.Message.ToString());
            }
            Cursor = Cursors.Arrow;
        }
    }
}
