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
                BackgroundWorker search = new BackgroundWorker();
                search.DoWork += (o, a) =>
                {


                    AutoCompleteStringCollection col1 = new AutoCompleteStringCollection();

                    cmd = new MySqlCommand("Select concat(productname,' @',mrp) as tags from products", con);

                    con.Open();
                    MySqlDataReader data = cmd.ExecuteReader();
                    try
                    {
                        while (data.Read())
                        {
                            string sname = data.GetString("tags");
                            col1.Add(sname);
                        }
                    }catch(Exception ex) { MessageBox.Show(ex.Message); }
                    con.Close();
                    a.Result = col1;

                };
                search.RunWorkerCompleted += (o, b) => {
                    userinfo.col = b.Result as AutoCompleteStringCollection;                
                };
                search.RunWorkerAsync();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }


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
