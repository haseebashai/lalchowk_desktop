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

namespace Modest_Attires
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
        MySqlDataReader dr;
       
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
                valuepnl.Visible = false;
            }
            else
            {
                
                pbar.Value = 100;
                pbar.Style = ProgressBarStyle.Continuous;             
            }
            if (valuepanel)
            {
                valuepnl.Visible = true;
            }
            execbtn.Enabled = true;
            execbtn.Text = "Execute Query";
            sqldataview.DoubleBuffered(true);
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
            valuepnl.Visible = false;
            updbtn.Visible = false;
            pbar.Visible = false;
            execbtn.Enabled = false;
            execbtn.Text = "Executing Query";
            pbar.Style = ProgressBarStyle.Marquee;
          

              StringBuilder query = new StringBuilder(sqltxt.Text);

             // query.Replace(@"\", @"\\");
             // query.Replace("'", "\\'");
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
            catch (Exception ex)
            {

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
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
                valuepanel = true;
            }
            catch (Exception ex)
            {
                error = true;
                MessageBox.Show(ex.Message.ToString());
           //     var message = ex.ToString();
             //   string[] split = message.Split(new string[] { " at " }, StringSplitOptions.None);
               // MessageBox.Show("Something happened, please try again.\n\n" + split[0], "Error!");
            }
        }

        bool valuepanel;
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
                valuepanel = true;
            }
            catch (Exception ex)
            {
                error = true;
                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
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

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
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

        private void copybtn_Click(object sender, EventArgs e)
        {
            try
            {
                string seperator = "";

                if (spacebox.Checked)
                {
                    seperator = " ";
                }
                else if (commabox.Checked)
                {
                    seperator = ",";
                }
                else if (linebox.Checked)
                {
                    seperator = "\r\n";
                }
                else if (colonbox.Checked)
                {
                    seperator = ";";
                }


                if (coltxt.Text == "")
                {
                    MessageBox.Show("Please enter a column");
                }
                else if (spacebox.Checked == false && commabox.Checked == false && linebox.Checked == false && colonbox.Checked == false)
                {
                    MessageBox.Show("Please select a seperator character.");
                }
                else
                {
                    int i = 0;
                    string numbers = "";
                    if (lalchowkchk.Checked)
                    {
                        dr = obj.Query(sqlquery);
                        while (dr.Read())
                        {
                            numbers += dr[coltxt.Text].ToString();
                            numbers += seperator;

                            i++;
                        }

                        obj.closeConnection();
                    }else if (lalacchk.Checked)
                    {
                        aconn.Open();
                        MySqlCommand cmd = new MySqlCommand(sqlquery, aconn);
                        dr= cmd.ExecuteReader();
                        while(dr.Read())
                         {
                            numbers += dr[coltxt.Text].ToString();
                            numbers += seperator;

                            i++;
                        }

                        aconn.Close();
                    }

                        Form values = new Form();
                    values.Size = new Size(600, 600);
                    values.Text = "Values";
                    
                    values.StartPosition = FormStartPosition.CenterScreen;
                    values.FormBorderStyle = FormBorderStyle.FixedSingle;
                    values.Controls.Add(new TextBox() {Location=new Point(1,1), Text = numbers, Multiline = true, ScrollBars = ScrollBars.Vertical,
                                        ForeColor = Color.Blue,Font=new Font("MS Sans Serif",10),Dock=DockStyle.Fill                 });
                    values.Show();
                }
            }
            catch (Exception ex)
            {
                obj.closeConnection();
                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }

        private void spacebox_CheckedChanged(object sender, EventArgs e)
        {
            if (spacebox.Checked)
           {
                commabox.Checked = false;
                linebox.Checked = false;
                colonbox.Checked = false;
            }
        }

        private void commabox_CheckedChanged(object sender, EventArgs e)
        {
            if (commabox.Checked)
            {
                linebox.Checked = false;
                colonbox.Checked = false;
                spacebox.Checked = false;
            }
        }

        private void linebox_CheckedChanged(object sender, EventArgs e)
        {
            if (linebox.Checked)
            {
                colonbox.Checked = false;
                spacebox.Checked = false;
                commabox.Checked = false;
            }
        }

        private void colonbox_CheckedChanged(object sender, EventArgs e)
        {
            if (colonbox.Checked)
            {
                spacebox.Checked = false;
                commabox.Checked = false;
                linebox.Checked = false;
            }
        }
    }
}
