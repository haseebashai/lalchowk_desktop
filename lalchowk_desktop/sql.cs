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
    public partial class sql : Form
    {
        DBConnect obj = new DBConnect();
        MySqlConnection aconn = new MySqlConnection("SERVER=182.50.133.78;DATABASE=lalchowk_ac;USER=lalchowkac;PASSWORD=Lalchowk@123uzmah");
        MySqlConnection conn = new MySqlConnection("SERVER=182.50.133.78;DATABASE=lalchowk;USER=lalchowk;PASSWORD=Lalchowk@123uzmah;");
        MySqlDataAdapter adap;
        MySqlCommandBuilder cmdbl;
        BindingSource bsource;
        DataTable dt;
        BackgroundWorker bw;
       
        private dialogcontainer dg = null;
        public sql(Form dgcopy)
        {
            dg = dgcopy as dialogcontainer;
            InitializeComponent();
            bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
           
            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;


        }

           
           
        

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (error)
            {
               
                pbar.Visible = false;
            }
            else
            {
               
                pbar.Value = 100;
                pbar.Style = ProgressBarStyle.Continuous;
            }
            execbtn.Enabled = true;
            execbtn.Text = "Execute Query";
            fetchlbl.Visible = false;          
            sqldataview.DataSource = bsource;
           
        }

       

     
        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
              
                            string arg = e.Argument as string;
                            if (arg == "lalchowk")
                            {              
                            execlalchowk();
                            }
                            else { execlalchowkac(); }                       
                         
        }

        string sqlquery;

        private void execbtn_Click(object sender, EventArgs e)
        {
            updbtn.Visible = false;
            pbar.Visible = false;
            execbtn.Enabled = false;
            execbtn.Text = "Executing Query";
            pbar.Style = ProgressBarStyle.Marquee;
          

              StringBuilder query = new StringBuilder(sqltxt.Text);

              query.Replace(@"\", @"\\");
              query.Replace("'", "\\'");
              sqlquery = query.ToString();

            try
            {
                if (sqltxt.Text == "")
                {
                    MessageBox.Show("Please enter a query.");
                    execbtn.Enabled = true;
                    execbtn.Text = "Execute Query";
                    pbar.Visible = false;
                }
               else if (!query.ToString().EndsWith(";"))
                {
                    MessageBox.Show("Terminator ' ; ' missing.\nPlease check for any space after ; if present.");
                    execbtn.Enabled = true;
                    execbtn.Text = "Execute Query";
                    pbar.Visible = false;
                }
                else
                {
                    if (lalchowkchk.Checked)
                    {
                        sqldataview.DataSource = null;
                        pbar.Visible = true;
                        bw.RunWorkerAsync("lalchowk");
                        fetchlbl.Visible = true;
                        
                    }

                    else if (lalacchk.Checked)
                    {
                        sqldataview.DataSource = null;
                        pbar.Visible = true;
                        bw.RunWorkerAsync("");
                        fetchlbl.Visible = true;
                        
                    }
                    else if (lalchowkchk.Checked == false && lalacchk.Checked == false)
                    {
                        MessageBox.Show("Please select database");
                        execbtn.Enabled = true;
                        execbtn.Text = "Execute Query";
                        pbar.Visible = false;
                    }
                }
            }
            catch (MySqlException ex)
            {
                var message = ex.ToString();
                string[] split = message.Split(new string[] { " at " }, StringSplitOptions.None);
                MessageBox.Show("Something happened, please try again.\n\n" + split[0], "Error!");
            }

        }   

        string use;
        private void lalchowkchk_CheckedChanged(object sender, EventArgs e)
        {
            if (lalchowkchk.Checked)
            {
                use = "use lalchowk;";
                lalacchk.Checked = false;
            }
        }

        private void lalacchk_CheckedChanged(object sender, EventArgs e)
        {
            if (lalacchk.Checked)
            {
                use = "use lalchowk_ac;";
                lalchowkchk.Checked = false;
            }
        }

        bool error = false;
        private void execlalchowk()
        {
            try
            {
                adap = new MySqlDataAdapter(use + sqlquery, conn);
                dt = new DataTable();
                adap.Fill(dt);
                conn.Close();
                bsource = new BindingSource();
                bsource.DataSource = dt;
            }
            catch (Exception ex)
            {
                error = true;
                var message = ex.ToString();
                string[] split = message.Split(new string[] { " at " }, StringSplitOptions.None);
                MessageBox.Show("Something happened, please try again.\n\n" + split[0], "Error!");
            }
        }

        private void execlalchowkac()
        {
            try
            {
                adap = new MySqlDataAdapter(use + sqlquery, aconn);
                dt = new DataTable();
                adap.Fill(dt);
                aconn.Close();
                bsource = new BindingSource();
                bsource.DataSource = dt;
            }
            catch (Exception ex)
            {
                error = true;
                var message = ex.ToString();
                string[] split = message.Split(new string[] { " at " }, StringSplitOptions.None);
                MessageBox.Show("Something happened, please try again.\n\n" + split[0], "Error!");
            }
        }

        private void sellbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
   
            sqltxt.Text = sqltxt.Text+"\n" + "SELECT (*) FROM db.table;";
        }

        private void inslbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            sqltxt.Text = sqltxt.Text + "\n" + "INSERT INTO tblname (`c1`,`c2`,`c3`) VALUES ('v1','v2','v3');";
        }

        private void updlbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            sqltxt.Text = sqltxt.Text + "\n" + "UPDATE tblname SET `c` = 'v' WHERE CONDITION;";
        }

        private void dellbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {        
            
            sqltxt.Text = sqltxt.Text + "\n" + "DELETE FROM tblname WHERE CONDITION;";
        }

        private void updbtn_Click(object sender, EventArgs e)
        {
            try
            {
                cmdbl = new MySqlCommandBuilder(adap);
                adap.Update(dt);
                MessageBox.Show("Entry Updated.");

            }
            catch (Exception ex)
            {
                var message = ex.ToString();
                string[] split = message.Split(new string[] { " at " }, StringSplitOptions.None);
                MessageBox.Show("Something happened, please try again.\n\n" + split[0], "Error!");
            }
        }

        private void sqldataview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.sqldataview.Rows[e.RowIndex];
                updbtn.Visible = true;
            }
            }

      
    }
}
