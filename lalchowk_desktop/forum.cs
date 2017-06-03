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
    public partial class forum : Form
    {
        DBConnect obj = new DBConnect();
        MySqlDataReader dr,dr2;
        int topic;
        bool threadtxtok, updatethreadtxtok, replytxtok;
        private container hp = null;
        public forum(Form hpcopy)
        {
            hp = hpcopy as container;
            InitializeComponent();
        }

        private void forum_Load(object sender, EventArgs e)
        {
            readthreads();
        }

        private void back_Click(object sender, EventArgs e)
        {
            mainform mf = new mainform(hp);
            mf.TopLevel = false;
            hp.mainpnl.Controls.Clear();
            hp.mainpnl.Controls.Add(mf);
            mf.Show();
        }

        private void readthreads()
        {
            dr = obj.Query("select topic from forumtopics");
            DataTable dt = new DataTable();
            dt.Columns.Add("topic", typeof(String));
            dt.Load(dr);
            obj.closeConnection();
            threadbox.DisplayMember = "topic";
            threadbox.DataSource = dt;
        }

        private void readreplies()
        {
            dr2 = obj.Query("select * from forumreplies where topicid='" + topic + "'");
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("reply", typeof(String));
            dt2.Load(dr2);
            obj.closeConnection();
            replybox.DisplayMember = "reply";
            replybox.DataSource = dt2;
        }

        private void threadbtn_Click(object sender, EventArgs e)
        {
            if (threadtxtok)
            {
                string cmd;
                cmd = "Insert into forumtopics(topic, user) values ('" + threadtxt.Text + "','" + userinfo.username + "')";
                obj.nonQuery(cmd);
                MessageBox.Show("New thread added sucessfully.");
                threadtxt.Text = "";
                readthreads();
            }
            else
                inclblf.Visible = true;
        }

        private void addcancelbtn_Click(object sender, EventArgs e)
        {
            threadtxt.Text = "";
            inclblf.Visible = false;
        }

        private void threadbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            dr = obj.Query("select * from forumtopics where topic='" + threadbox.Text + "'");
            dr.Read();
            updatethreadtxt.Text = dr[1].ToString();
            inclblef.Visible = false;
            obj.closeConnection();
        }

        private void updatecancelbtn_Click(object sender, EventArgs e)
        {
            updatethreadtxt.Text ="";
            threadbox.Text = "";
            fagree.Checked = false;
        }

        private void rvmbtn_Click(object sender, EventArgs e)
        {
            string cmd;
            cmd = "delete from forumtopics where topic='" + threadbox.Text + "'";
            obj.nonQuery(cmd);
            MessageBox.Show("Thread deleted sucessfully.");
            fagree.Checked = false;
            readthreads();
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            if (updatethreadtxt.Text.Contains("'") || updatethreadtxt.Text.Contains("\\"))
                MessageBox.Show("Topic cannot contain ' & \\");
            else
            {
                if (fagree.Checked && updatethreadtxtok == true)
                {
                    string cmd;
                    cmd = ("update forumtopics set `topic`='" + updatethreadtxt.Text + "'where `topic`='" + threadbox.Text + "'");
                    obj.nonQuery(cmd);
                    MessageBox.Show("Thread updated sucessfully.");
                    updatethreadtxt.Text = "";
                    threadbox.Text = "";
                    fagree.Checked = false;
                    readthreads();
                }
                else
                {
                    inclblef.Visible = true;
                }
            }
        }

        private void topicbtn_Click(object sender, EventArgs e)
        {
            repliespnl.Visible = false;
            addpnl.Visible = true;
            readthreads();
        }

        private void repliesbtn_Click(object sender, EventArgs e)
        {
            repliespnl.Visible = true;
            addpnl.Visible = false;
            dr = obj.Query("select topic from forumtopics");
            DataTable dt = new DataTable();
            dt.Columns.Add("topic", typeof(String));
            dt.Load(dr);
            obj.closeConnection();
            threadlist.DisplayMember = "topic";
            threadlist.DataSource = dt;
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            replybox.Text = "";
        }

        private void rvmrepbtn_Click(object sender, EventArgs e)
        {
            string cmd;
            cmd = ("delete from forumreplies where reply= '" + replybox.Text + "';");
            obj.nonQuery(cmd);
            MessageBox.Show("selected reply removed sucessfully.");
            readreplies();
            
        }

        private void replycancelbtn_Click(object sender, EventArgs e)
        {
            replytxt.Text = "";
            inclblr.Visible = false;
        }

        private void addreply_Click(object sender, EventArgs e)
        {
            if (replytxt.Text.Contains("'") || replytxt.Text.Contains("\\"))
                MessageBox.Show("Reply cannot contain ' & \\");
            else
            {
                if (replytxtok == true)
                {
                    string cmd;
                    cmd = "Insert into forumreplies(topicid, reply, user) values ('" + topic + "','" + replytxt.Text + "','" + userinfo.username + "')";
                    obj.nonQuery(cmd);
                    MessageBox.Show("Reply added sucessfully.");
                    replytxt.Text = "";
                    readreplies();
                }
                else
                    inclblr.Visible = true;
            }
        }

        private void threadtxt_Leave(object sender, EventArgs e)
        {
            if (threadtxt.Text == "")
                threadtxtok = false;
            else
                threadtxtok = true;
            if (threadtxt.Text.Contains("\\") || threadtxt.Text.Contains("'"))
            {
                MessageBox.Show("Topic cannot contain ' &\\");
                threadtxt.Text = "";
                threadtxt.Focus();
            }
        }

        private void replybox_SelectedIndexChanged(object sender, EventArgs e)
        {
            inclblr.Visible = false;
        }

        private void replytxt_Leave(object sender, EventArgs e)
        {
            if (replytxt.Text == "")
                replytxtok = false;
            else
                replytxtok = true;
            
        }

        private void fagree_CheckedChanged(object sender, EventArgs e)
        {
            if (updatethreadtxt.Text == "")
            {
                updatethreadtxtok = false;
            }
            else
            {
                updatethreadtxtok = true;
            }
        }

        private void threadlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            dr = obj.Query("select * from forumtopics where topic='" + threadlist.Text + "'");
            dr.Read();
            topic = Convert.ToInt32(dr[0]);
            obj.closeConnection();

            readreplies();
            panel2.Visible = true;
            
        }
    }
}
