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
    public partial class container : Form
    {

        MySqlConnection con = new MySqlConnection("SERVER=182.50.133.78;DATABASE=lalchowk;USER=lalchowk;PASSWORD=Lalchowk@123uzmah");
        MySqlCommand cmd;

        public container()
        {
            
            InitializeComponent();
        }


        private void Homepage_Load(object sender, EventArgs e)
        {
            loginform lg = new loginform(this,this);
            lg.TopLevel = false;
            mainpnl.Controls.Clear();
            mainpnl.Controls.Add(lg);
            lg.Show();

            try
            {
                mainform mf = new mainform(this);
                BackgroundWorker search = new BackgroundWorker();
                search.WorkerReportsProgress = true;
                search.DoWork += (o, a) =>
                {


                    AutoCompleteStringCollection col1 = new AutoCompleteStringCollection();

                    cmd = new MySqlCommand("Select concat_ws(' ',productname,'(',detail1,detail2,')','(',stock,')','@',mrp,'#',productid) as tag from products where productid>9999", con);
                    try
                    {
                        
                        con.Open();
                        cmd.CommandTimeout = 60;
                        int i = 0;
                        MySqlDataReader data = cmd.ExecuteReader();
                        try
                        {
                            while (data.Read())
                            {
                                string sname = data.GetString("tag");
                                col1.Add(sname);
                                i++;
                                search.ReportProgress(i / 200);
                            }
                        }
                        catch (Exception ex) { MessageBox.Show("Network too slow. Product data download interrupted.\r\nUse old mode in Add Order page to add a new order","Error!"); }
                        con.Close();
                        a.Result = col1;
                    }catch(Exception ex) { MessageBox.Show(ex.Message); }

                };
                search.ProgressChanged += (o, c) => 
                {
                    
             //    plistlbl.Text = "Products list loading..." + c.ProgressPercentage + "%";

                };
                search.RunWorkerCompleted += (o, b) =>
                {
                    userinfo.col = b.Result as AutoCompleteStringCollection;
                 //   mf.plistlbl.Visible = false;
                };
                search.RunWorkerAsync();
            }
            catch (Exception ex) { con.Close(); }// MessageBox.Show(ex.Message);


        }


        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void container_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dgr = MessageBox.Show("Make sure that no other functions are running before closing.", "Warning!", MessageBoxButtons.OKCancel);
            if (dgr == DialogResult.OK)
            {
                e.Cancel=false;
            }
            else
                e.Cancel = true;
          
        }
    }
}
