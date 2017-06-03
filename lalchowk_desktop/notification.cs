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
    public partial class notification : Form
    {
        DBConnect obj = new DBConnect();

        private mainform mf = null;
        private container hp = null;

        MySqlDataReader dr;

        public notification(Form mfcopy,Form hpcopy)
        {
            mf = mfcopy as mainform;
            hp = hpcopy as container;

            InitializeComponent();
        }

        private void sendbtn_Click(object sender, EventArgs e)
        {
            if (msgtxt.Text != "")
            {
                StringBuilder s1 = new StringBuilder(msgtxt.Text);
                s1.Replace(@"\", @"\\");
                s1.Replace("'", "\\'");
                string cmd;
                cmd = ("insert into notifications (notification) values ('" + s1 + "')");
                obj.nonQuery(cmd);
                MessageBox.Show("Notification sent sucessfully.");
                msgtxt.Text = "";
                readmsg();
            }
            else
                inclblm.Visible = true;
        }

        private void readmsg()
        {
            dr = obj.Query("select * from notifications");
            DataTable dt = new DataTable();
            dt.Columns.Add("notification", typeof(String));
            dt.Load(dr);               
            obj.closeConnection();
            msgbox.DisplayMember = "notification";
            msgbox.DataSource = dt;
        }

        private void notification_Load(object sender, EventArgs e)
        {
            readmsg();
        }


        private void rvmbtn_Click(object sender, EventArgs e)
        {
            StringBuilder s1 = new StringBuilder(msgbox.Text);
            s1.Replace(@"\", @"\\");
            s1.Replace("'", "\\'");
            string cmd;
            cmd=("delete from notifications where notification='"+s1+"'");
            obj.nonQuery(cmd);
            MessageBox.Show("Notification removed sucessfully.");
            msgboxtxt.Text = "";
            readmsg();
            if (msgbox.Items.Count == 0)
                msgbox.Text = "";
        }

        private void msgcancelbtn_Click(object sender, EventArgs e)
        {
            msgboxtxt.Text = "";
            inclblem.Visible = false;
        }

        private void msgbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            StringBuilder s;
            s = new StringBuilder(msgbox.Text);
            s.Replace("'", "\\'");
            dr = obj.Query("select * from notifications where notification='" + s + "'");
            dr.Read();
            msgboxtxt.Text = dr[1].ToString();
            inclblem.Visible = false;
            obj.closeConnection();
            
        }

        private void msgupdatebtn_Click(object sender, EventArgs e)
        {
            if (msgboxtxt.Text != "")
            {
                string cmd;
                StringBuilder s1 = new StringBuilder(msgboxtxt.Text);
                s1.Replace(@"\", @"\\");
                s1.Replace("'", "\\'");
                cmd = ("update notifications set `notification`='" + s1 + "'where `notification`='" + msgbox.Text + "'");
                obj.nonQuery(cmd);
                MessageBox.Show("Message updated sucessfully.");
                readmsg();
            }
            else
                inclblem.Visible = true;
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            msgtxt.Text = "";
            inclblm.Visible = false;
        }

        private void back_Click(object sender, EventArgs e)
        {
            mainform mf = new mainform(hp);
            mf.TopLevel = false;
            hp.mainpnl.Controls.Clear();
            hp.mainpnl.Controls.Add(mf);
            mf.Show();
        }
    }
}
