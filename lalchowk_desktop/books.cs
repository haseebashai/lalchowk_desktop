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
    public partial class books : Form
    {

        MySqlDataAdapter adap;
        DataTable dt;
        MySqlConnection con = new MySqlConnection("SERVER=182.50.133.78;DATABASE=lalchowk;USER=lalchowk;PASSWORD=Lalchowk@123uzmah");
        DBConnect obj = new DBConnect();
        MySqlDataReader dr;

        private dialogcontainer dg = null;
        BindingSource bsource;

        public books(Form dgcopy)
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
            readreqs();
        }

        private void Load_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dg.loadingimage.Visible = false;
            dg.lbl.ForeColor = SystemColors.Highlight;
            dg.lbl.Text = "Book Requests";
            booksdataview.DataSource = bsource;
            bpnl.Visible = true;
        }

        public void loadingdg()
        {
            dg.lbl.ForeColor = SystemColors.Highlight;
            dg.lbl.Text = "Loading";
            dg.loadingimage.SizeMode = PictureBoxSizeMode.StretchImage;
            dg.loadingimage.Visible = true;
        }

        public void readreqs()
        {
            try
            {
                adap = new MySqlDataAdapter("select * from bookrequests", con);
                dt = new DataTable();
                adap.Fill(dt);
                bsource = new BindingSource();
                bsource.DataSource = dt;
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }

        }

        string id,email;
        private void booksdataview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            temailbtn.Visible = false;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.booksdataview.Rows[e.RowIndex];
                id = row.Cells["id"].Value.ToString();             
                nametxt.Text = row.Cells["name"].Value.ToString();
                contxt.Text = row.Cells["contact"].Value.ToString();
                booknametxt.Text = row.Cells["bookname"].Value.ToString();
                detailstxt.Text = row.Cells["details"].Value.ToString();
                email = row.Cells["email"].Value.ToString();
                if (email == "null")
                {   
                    
                    emailtxt.Text = "New customer";
                }else
                {
                    temailbtn.Visible = true;
                    emailtxt.Text = email;
                }
                dpnl.Visible = true;
            }
        }

        private void Trueemail_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
          
          

            string mail = (string)e.Result;
            emailtxt.Text = mail;
            temailbtn.Enabled = true;
        }

        private void Trueemail_DoWork(object sender, DoWorkEventArgs e)
        {
            try {
                dr = obj.Query("select mail from customer where email='" + email + "'");
                dr.Read();
                string temail = dr[0].ToString();
                e.Result = temail;
                obj.closeConnection();
            }catch { obj.closeConnection(); temailbtn.Enabled = true; }
        }

        private void temailbtn_Click(object sender, EventArgs e)
        {



            temailbtn.Enabled = false;
            BackgroundWorker trueemail = new BackgroundWorker();
            trueemail.DoWork += Trueemail_DoWork;
            trueemail.RunWorkerCompleted += Trueemail_RunWorkerCompleted;
            trueemail.RunWorkerAsync();

        }

        private void pbtn_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string cmd = "update bookrequests set processed='1' where id='" + id + "'";
                obj.nonQuery(cmd);
                con.Close();
                Cursor = Cursors.Arrow;
                MessageBox.Show("Updated.");
                dpnl.Visible = false;
                readreqs();
                booksdataview.DataSource = bsource;

            }catch { Cursor = Cursors.Arrow; }
        }

    }
}
