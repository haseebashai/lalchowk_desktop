﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Modest_Attires
{
    public partial class books : Form
    {

        MySqlDataAdapter adap;
        DataTable dt;
        MySqlConnection con = new MySqlConnection("SERVER=182.50.133.78;DATABASE=lalchowk;USER=lalchowk;PASSWORD=Lalchowk@123uzmah;Convert Zero Datetime=True");
        DBConnect obj = new DBConnect();
        MySqlDataReader dr;
        MySqlCommandBuilder cmdbl;

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
            booksdataview.DoubleBuffered(true);
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
                adap = new MySqlDataAdapter("select * from bookrequests order by id desc", con);
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
                
                if (email == "")
                {
                    emailtxt.Text = "New customer";
                }
                else
                {
                    if (email == "null")
                    {

                        emailtxt.Text = "New customer";
                    }
                    else
                    {
                        temailbtn.Visible = true;
                        emailtxt.Text = email;
                      
                    }
                    dpnl.Visible = true;
                }
                dpnl.Visible = true;
                updbtn.Enabled = true;
                check = false;
            }
        }

        private void Trueemail_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {


            try
            {
                string mail = (string)e.Result;
                emailtxt.Text = mail;
                temailbtn.Enabled = true;
            }catch { temailbtn.Enabled = true; }
        }

        private void Trueemail_DoWork(object sender, DoWorkEventArgs e)
        {
            try {
                dr = obj.Query("select mail from customer where email='" + email + "'");
                dr.Read();
                string temail = dr[0].ToString();
                e.Result = temail;
                obj.closeConnection();
            }catch { obj.closeConnection();  }
        }

        bool check = false;
        private void temailbtn_Click(object sender, EventArgs e)
        {
            check = false;


            temailbtn.Enabled = false;
            BackgroundWorker trueemail = new BackgroundWorker();
            trueemail.DoWork += Trueemail_DoWork;
            trueemail.RunWorkerCompleted += Trueemail_RunWorkerCompleted;
            trueemail.RunWorkerAsync();
            check = true;
        }

        private void delbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (id == null)
                {
                    MessageBox.Show("Select a request first.", "Error!");
                }
                else
                {
                    DialogResult dgr = MessageBox.Show("Sure you want to delete this book request\n" + booknametxt.Text + "\nby\n" + nametxt.Text + " ?", "Confirm!", MessageBoxButtons.YesNo);
                    if (dgr == DialogResult.Yes)
                    {
                        Cursor = Cursors.WaitCursor;
                        string cmd = "delete from bookrequests where id='" + id + "'";
                        obj.nonQuery(cmd);
                        MessageBox.Show("Request deleted.", "Deleted");
                        id = null;
                        readreqs();
                        booksdataview.DataSource = bsource;
                        Cursor = Cursors.Arrow;
                        dpnl.Visible = false;
                    }
                }
            }catch { Cursor = Cursors.Arrow; }
        }

        private void smsbtn_Click(object sender, EventArgs e)
        {
            dialogcontainer dg = new dialogcontainer();
            sendsms sms = new sendsms(contxt.Text,booknametxt.Text,nametxt.Text);
            sms.TopLevel = false;
            dg.dialogpnl.Controls.Add(sms);
            dg.lbl.Text = "Send SMS";
            dg.Text = "Send SMS";
            dg.Size = new Size(600, 600);
            sms.numbertxt.Font = new Font("MS Sans Serif", 9, FontStyle.Regular);
            sms.smsnpnl.Visible = false;
            sms.txtpnl.Location = new Point(35, 10);
            dg.Show();
            sms.Show();
        }

        private void mailbtn_Click(object sender, EventArgs e)
        {
           
            if (emailtxt.Text == string.Empty || emailtxt.Text == "New customer")
            {
                MessageBox.Show("User not registered or email not given.", "Error");
            }
            else if (check==false)
            {
                MessageBox.Show("Please click on 'Check Email' and obtain the email first.", "Error");

            }
            else
            { 
            
                dialogcontainer dg = new dialogcontainer();
                promomail pm = new promomail(emailtxt.Text, dg, nametxt.Text, booknametxt.Text);
                pm.TopLevel = false;
                dg.Size = new Size(700, 715);
                pm.epnl.Location = new Point(-300, 1);
                pm.elistlbl.Text = "";

                dg.dialogpnl.Controls.Add(pm);
                pm.loadingdg();
                pm.opnl.Visible = true;
                dg.Text = "Send Email";

                dg.Show();

                pm.Show();
            }
        }

        private void updbtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                cmdbl = new MySqlCommandBuilder(adap);
                adap.Update(dt);
                MessageBox.Show(" Updated.");
                readreqs();
                booksdataview.DataSource = bsource;
                dpnl.Visible = false;
                updbtn.Enabled = false;

            }
            catch (Exception ex)
            {
                obj.closeConnection();
                MessageBox.Show( ex.Message, "Error!");
            }
            Cursor = Cursors.Arrow;
        }

    }
}
