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
    public partial class messages : Form
    {
        private mainform mf = null;
        private container hp = null;

        string user;

        DBConnect obj= new DBConnect();

        MySqlDataReader dr;

        public messages(Form mfcopy, Form hpcopy)
        {
            mf = mfcopy as mainform;
            hp = hpcopy as container;

            InitializeComponent();
        }

        private void back_Click(object sender, EventArgs e)
        {
            mainform mf = new mainform(hp);
            mf.TopLevel = false;
            hp.mainpnl.Controls.Clear();
            hp.mainpnl.Controls.Add(mf);
            mf.Show();
        }


        private void readsub()
        {
            dr = obj.Query("select * from messages where username='"+user+"'");
            DataTable dt = new DataTable();
            dt.Columns.Add("subject", typeof(String));
            dt.Load(dr);
            obj.closeConnection();
            sublist.DisplayMember = "subject";
            sublist.DataSource = dt;

        }

        private void readusers()
        {

            dr = obj.Query("select distinct username from messages ");
            DataTable dt = new DataTable();
            dt.Columns.Add("username", typeof(String));
            dt.Load(dr);
            obj.closeConnection();
            userlist.DisplayMember = "username";
            userlist.DataSource = dt;
        }

        private void messages_Load(object sender, EventArgs e)
        {
            readusers();
            
        }

        private void msglist_SelectedIndexChanged(object sender, EventArgs e)
        {
            
               
                dr = obj.Query("select * from messages where username='" + userlist.Text + "'");
                dr.Read();
                user = dr[1].ToString();

                obj.closeConnection();
            readsub();
        

        }


        private void sublist_SelectedIndexChanged(object sender, EventArgs e)
        {
            StringBuilder s = new StringBuilder(sublist.Text);
            s.Replace(@"\", @"\\");
            s.Replace("'", "\\'");
            dr = obj.Query("select * from messages where username='" + user + "'&&subject='"+s+"'");
            dr.Read();
           
            msgtxt.Text = dr[3].ToString();
            repliedtxt.Text = "\r\n\r\n" + dr[4].ToString();

            obj.closeConnection();
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            replytxt.Text = "";
        }

        private void sndbtn_Click(object sender, EventArgs e)
        {
            if (replytxt.Text != "")
            {
                StringBuilder s1 = new StringBuilder(replytxt.Text);
                s1.Replace(@"\", @"\\");
                s1.Replace("'", "\\'");
                StringBuilder s = new StringBuilder(msgtxt.Text);
                s.Replace(@"\", @"\\");
                s.Replace("'", "\\'");
                string cmd;
                cmd = ("UPDATE messages SET `reply`='" + s1 + "' where message ='" + s + "'");
                obj.nonQuery(cmd);
                MessageBox.Show("Reply Sent.");
                replytxt.Text = "";
                readsub();
            }
            else
                MessageBox.Show("Add reply first.");
        }
    }
}
