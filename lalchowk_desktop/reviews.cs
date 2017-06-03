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
    public partial class reviews : Form
    {
        DBConnect obj = new DBConnect();
        string user;
        int placeid;
        MySqlDataReader dr;
        private container hp = null;
        public reviews(Form hpcopy)
        {
            hp = hpcopy as container;
            InitializeComponent();
        }

        private void readusers()
        {
            dr = obj.Query("select distinct user from ratings");
            DataTable dt = new DataTable();
            dt.Columns.Add("user", typeof(String));
            dt.Load(dr);
            obj.closeConnection();
            userlist.DisplayMember = "user";
            userlist.DataSource = dt;
        }

        private void readreviews()
        {
            dr = obj.Query("select review from ratings where user='"+user+"' &&review !=''");
            DataTable dt = new DataTable();
            dt.Columns.Add("review", typeof(String));
            dt.Load(dr);
            obj.closeConnection();
            reviewbox.DisplayMember = "review";
            reviewbox.DataSource = dt;
        }

        private void reviews_Load(object sender, EventArgs e)
        {
            readusers();
        }

        private void back_Click(object sender, EventArgs e)
        {
            mainform mf = new mainform(hp);
            mf.TopLevel = false;
            hp.mainpnl.Controls.Clear();
            hp.mainpnl.Controls.Add(mf);
            mf.Show();
        }

        private void userlist_SelectedIndexChanged(object sender, EventArgs e)
        {

            dr = obj.Query("select * from ratings where user='" + userlist.Text + "'");
            dr.Read();

            user = dr[2].ToString();
           
            obj.closeConnection();            
            readreviews();
            
        }

        private void rvmrepbtn_Click(object sender, EventArgs e)
        {
            string cmd;
            cmd = "delete from ratings where review='" + reviewbox.Text + "'";
            obj.nonQuery(cmd);
            MessageBox.Show("Review deleted sucessfully.");
            
            readreviews();
        }

        private void reviewbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            StringBuilder s1 = new StringBuilder(reviewbox.Text);
            s1.Replace(@"\", @"\\");
            s1.Replace("'", "\\'");
            dr = obj.Query("select pid from ratings where review='"+ s1+"'");
            dr.Read();
            placeid = Convert.ToInt32(dr[0]);
            obj.closeConnection();
            dr = obj.Query("select * from places where pid='" + placeid + "'");
            dr.Read();
            placelbl.Text = "in " +dr[1].ToString()+"";
            obj.closeConnection();
        
        }
    }
}
