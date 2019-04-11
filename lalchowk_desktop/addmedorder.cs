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
using System.Security.Cryptography;
using System.Globalization;

namespace Veiled_Kashmir_Admin_Panel
{
    public partial class addmedorder : Form
    {
        DBConnect obj = new DBConnect();
        MySqlDataReader dr;
        MySqlConnection con = new MySqlConnection("SERVER=182.50.133.78;DATABASE=lalchowk;USER=lalchowk;PASSWORD=Lalchowk@123uzmah");
        MySqlCommand cmd;

        public addmedorder()
        {
            InitializeComponent();

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

        private void addorderbtn_Click(object sender, EventArgs e)
        {
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
                        Cursor = Cursors.WaitCursor;
                        string pconf = "";
                        if (pcybox.Checked)
                            pconf = "1";
                        else
                            pconf = "0";

                        string email = md5hash(emailtxt.Text);
                        string cmd = "INSERT INTO medorders(`email`, `amount`,`timestamp`,`shipping`,`paymenttype`,`paymentconfirmed`, `transanctionid`,`itemcount`,`status`,`name`,`address1`,`address2`,`contact`,`pincode`,`city`,`loyaltybonus`,`deliveryguy`,`in_transit`,`alternate_contact`,`dp`,`msg`) values ('" + email + "','" + amounttxt.Text
                            + "',DATE_ADD(CURRENT_TIMESTAMP, INTERVAL 750 MINUTE),'" + shiptxt.Text + "','" + ptypebox.Text + "','" + pconf + "','SW','" + counttxt.Text + "','" + statustxt.Text + "','" + nametxt.Text + "','" + add1txt.Text + "','" + add2txt.Text + "','" + contacttxt.Text + "','" + pintxt.Text + "','" + citytxt.Text
                            + "','" + loyaltxt.Text + "','" + devtxt.Text + "','0','" + altcontxt.Text + "','" + dptxt.Text + "','" + msgtxt.Text + "')";
                        obj.nonQuery(cmd);
                        //   long orderid = userinfo.orid;
                        //    int orderid = obj.Count("SELECT LAST_INSERT_ID()");

                        obj.closeConnection();
                        MessageBox.Show("Order added successfully.", "Success.");
                        Cursor = Cursors.Arrow;
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); obj.closeConnection(); }
           
            Cursor = Cursors.Arrow;
        }

        private void pinbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pinbox.SelectedIndex > -1)
            {
                pintxt.Text = pinbox.Text.Split(':')[0];

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
    }
}
