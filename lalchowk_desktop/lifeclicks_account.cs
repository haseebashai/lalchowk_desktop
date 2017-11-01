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
    public partial class lifeclicks_account : Form
    {

        PictureBox loading = new PictureBox();
        BindingSource bsource;
        DBConnect obj = new DBConnect();
        MySqlCommandBuilder cmdbl;
        MySqlDataAdapter adap;
        MySqlConnection aconn = new MySqlConnection("SERVER=182.50.133.78;DATABASE=lalchowk_ac;USER=lalchowkac;PASSWORD=Lalchowk@123uzmah");
        DataTable dt;
        MySqlCommand mysqlcmd;
        MySqlDataReader dr;
        string clientlbl;


        private dialogcontainer dg = null;
        public lifeclicks_account(Form dgcopy)
        {
            dg = dgcopy as dialogcontainer;
            InitializeComponent();
            bgworker.RunWorkerAsync();
        }




        public void loadingnormal()
        {
            formlbl.Text = "Loading";

            loading = new PictureBox()
            {
                Image = Properties.Resources.loading,
                Size = new Size(40, 30),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Location = new Point(72, 0),
            };
            this.Controls.Add(loading);
        }


        public void loadingdg()
        {
            formlbl.Visible = false;
            dg.lbl.ForeColor = SystemColors.Highlight;
            dg.lbl.Text = "Loading";
            dg.loadingimage.SizeMode = PictureBoxSizeMode.StretchImage;
            dg.loadingimage.Visible = true;
        }
        private void loadingshow()
        {
            loadingaccpic.Visible = true;
            loadinglbl.Visible = true;
        }

        private void btndisable()
        {
            bpnl.Enabled = false;
        }

        private void btnenable()
        {
            bpnl.Enabled = true;
        }

        private void panelshow()
        {

            accountdataview.Visible = true;
            uppnl.Visible = true;
            epnl.Visible = true;


        }

        private void panelhide()
        {

            accountdataview.Visible = false;
            uppnl.Visible = false;
            epnl.Visible = false;


        }


        public void readclients()
        {
            try
            {
                aconn.Open();
                adap = new MySqlDataAdapter("select * from client_accounts", aconn);
                dt = new DataTable();
                adap.Fill(dt);
                
                bsource = new BindingSource();
                bsource.DataSource = dt;
                aconn.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
            aconn.Close();


        }
       
        private void bgworker_DoWork(object sender, DoWorkEventArgs e)
        {
            readclients();
            
        }


        private void bgworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (dg!=null)
            {
                dg.loadingimage.Visible = false;
                dg.lbl.ForeColor = SystemColors.Highlight;
                dg.lbl.Text = "Client Accounts";

            }
            else
            {
                loading.Visible = false;
                formlbl.Visible = false;

            }
            btnenable();
            panelshow();
            bpnl.Visible = true;
        
            accountdataview.DataSource = bsource;

        }

        private void clientbtn_Click(object sender, EventArgs e)
        {
            panelhide();
            loadingshow();
            btndisable();
            bgworker.RunWorkerAsync();
            aballbl.Text = "Select a client for balance info.";
            abaltxt.Visible = false;
            cexppnl.Visible = false;
            clientpnl.Visible = true;

           
        }

        private void cliententrybtn_Click(object sender, EventArgs e)
        {
            try
            {
                aconn.Open();
                mysqlcmd = new MySqlCommand("insert into client_accounts(`client`, `email`, `amount`,`date`,`balance`,`comments`,`spent_on`) values ('" + clientnametxt.Text + "','" + clientemailtxt.Text + "','" + clientamounttxt.Text + "','" + clientdatetxt.Text + "','"+clientbaltxt.Text+"','" + clientcmtstxt.Text + "','" + clientspenttxt.Text + "')", aconn);
                mysqlcmd.ExecuteNonQuery();
                MessageBox.Show("Entry added.");
                aconn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
            clientnametxt.Text = "";
            clientemailtxt.Text = "";
            clientamounttxt.Text = "";
            clientdatetxt.Text = "";
            clientbaltxt.Text = "";
            clientcmtstxt.Text = "";
            clientspenttxt.Text = "";
            readclients();
            accountdataview.DataSource = bsource;

        }

        public void readclientexp()
        {try { 
            aconn.Open();
            adap = new MySqlDataAdapter("select * from client_expenses", aconn);
            dt = new DataTable();
            adap.Fill(dt);
            aconn.Close();
            bsource = new BindingSource();
            bsource.DataSource = dt;
        }
            catch (Exception ex)
            {

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }

        }
        private void bgworker2_DoWork(object sender, DoWorkEventArgs e)
        {
            readclientexp();
        }

        private void bgworker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnenable();
            panelshow();
            accountdataview.DataSource = bsource;
        }

        private void cexpbtn_Click(object sender, EventArgs e)
        {
            panelhide();
            loadingshow();
            btndisable();
            bgworker2.RunWorkerAsync();
            clientpnl.Visible = false;
            cexppnl.Visible = true;
        }

        private void ceentrybtn_Click(object sender, EventArgs e)
        {
            try
            {
                aconn.Open();
                mysqlcmd = new MySqlCommand("insert into client_expenses(`client`, `amount`,`date`,`comments`,`spent_on`) values ('" + cenametxt.Text + "','" + ceamounttxt.Text + "','" + cedatetxt.Text + "','" + cecmtstxt.Text + "','" + cespenttxt.Text + "')", aconn);
                mysqlcmd.ExecuteNonQuery();
                MessageBox.Show("Entry added.");
                aconn.Close();
                cenametxt.Text = "";
                ceamounttxt.Text = "";
                cedatetxt.Text = "";
                cecmtstxt.Text = "";
                cespenttxt.Text = "";
            }

            catch (Exception ex)
            {

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }

            readclientexp();
            accountdataview.DataSource = bsource;

        }


      

        string balance,spent;
        private void bgworker3_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                aconn.Open();
                mysqlcmd = new MySqlCommand("SELECT balance FROM lalchowk_ac.client_accounts where client='" + clientlbl + "' order by balance desc limit 1", aconn);
                dr = mysqlcmd.ExecuteReader();
                dr.Read();                
                balance = dr[0].ToString();              
                aconn.Close();

                aconn.Open();
                mysqlcmd = new MySqlCommand("SELECT sum(amount) FROM lalchowk_ac.client_expenses where client='" + clientlbl + "'", aconn);
                dr = mysqlcmd.ExecuteReader();
                dr.Read();
                spent = dr[0].ToString();
                aconn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
            aconn.Close();
        }

        private void updbtn_Click(object sender, EventArgs e)
        {
            try
            {
                cmdbl = new MySqlCommandBuilder(adap);
                adap.Update(dt);
                MessageBox.Show("Updated.");

            }
            catch (Exception ex)
            {

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }

        private void accountdataview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (clientpnl.Visible)
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.accountdataview.Rows[e.RowIndex];
                    clientlbl = row.Cells["client"].Value.ToString();
                    aballbl.Text = "Available balance for " + clientlbl + " is";
                    abaltxt.Visible = true;
                    abaltxt.Text = "calculating...";
                    try
                    {
                        bgworker3.RunWorkerAsync();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
                    }
                }
            }
        }

        private void bgworker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try {
                abaltxt.Text = (int.Parse(balance) - int.Parse(spent)).ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }
    }
}
