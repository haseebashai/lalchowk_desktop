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
using System.Text.RegularExpressions;

namespace Veiled_Kashmir_Admin_Panel
{
    public partial class terms : Form
    {
        DBConnect obj = new DBConnect();
        string cmd;
        
        MySqlDataReader dr;
        MySqlConnection con = new MySqlConnection("SERVER=182.50.133.78;DATABASE=lalchowk;USER=lalchowk;PASSWORD=Lalchowk@123uzmah");
        MySqlDataAdapter adap;
        DataTable dt;
        MySqlCommandBuilder cmdbl;
        private container hp = null;
        public terms(Form hpcopy)
        {
            hp = hpcopy as container;
            InitializeComponent();
            readterms();
        }

        public void readterms()
        {
            con.Open();
            adap = new MySqlDataAdapter("select * from terms", con);
            dt = new DataTable();
            adap.Fill(dt);
            con.Close();
            BindingSource bsource = new BindingSource();
            bsource.DataSource = dt;
            termsdataview.DataSource = bsource;
        }

        public void readfaq()
        {
            con.Open();
            adap = new MySqlDataAdapter("select * from faq", con);
            dt = new DataTable();
            adap.Fill(dt);
            con.Close();
            BindingSource bsource = new BindingSource();
            bsource.DataSource = dt;
            faqdataview.DataSource = bsource;
        }

        public void readabout()
        {
            con.Open();
            adap = new MySqlDataAdapter("select * from about", con);
            dt = new DataTable();
            adap.Fill(dt);
            con.Close();
            BindingSource bsource = new BindingSource();
            bsource.DataSource = dt;
            aboutdataview.DataSource = bsource;
        }

        private void termsdataview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.termsdataview.Rows[e.RowIndex];
                headingtxt.Text = row.Cells["heading"].Value.ToString();
                desctxt.Text = row.Cells["description"].Value.ToString();
                termsidlbl.Text = row.Cells["termsid"].Value.ToString()+".";
            }
        }

        private void tupdbtn_Click(object sender, EventArgs e)
        {
            try
            {
               

                if (!Regex.IsMatch(desctxt.Text, @"^([a-zA-Z0-9@#$%&*+\-_(),+':;?.,![\]\s\\/{}""|]+)$"))
                {

                    MessageBox.Show("Abnormal Special Character found, Please remove it and proceed.");

                }
                else
                {
                    cmd = ("UPDATE terms SET `heading`= '"+headingtxt.Text+"', `description`= '"+desctxt.Text+"' WHERE `termsid`= '"+termsidlbl.Text+"'");
                     obj.nonQuery(cmd);

                    MessageBox.Show("Successfully Updated.");
                    // readterms();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        

        private void faqdataview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.faqdataview.Rows[e.RowIndex];
                qtxt.Text = row.Cells["question"].Value.ToString();
                anstxt.Text = row.Cells["answer"].Value.ToString();
                faqid.Text = row.Cells["faqid"].Value.ToString()+".";
            }
        }

        private void faqupdbtn_Click(object sender, EventArgs e)
        {
            try
            {


                if (!Regex.IsMatch(anstxt.Text, @"^([a-zA-Z0-9@#$%&*+\-_(),+':;?.,![\]\s\\/{}""|]+)$"))
                {

                    MessageBox.Show("Abnormal Special Character found, Please remove it and proceed.");

                }
                else
                {
                    cmd = ("UPDATE faq SET `question`= '" + qtxt.Text + "', `answer`= '" + anstxt.Text + "' WHERE `faqid`= '" + faqid.Text + "'");
                    obj.nonQuery(cmd);

                    MessageBox.Show("Successfully Updated.");
                    // readfaq();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

       

        private void aboutdataview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.aboutdataview.Rows[e.RowIndex];
                headingtxtbox.Text = row.Cells["heading"].Value.ToString();
                desctxtbox.Text = row.Cells["description"].Value.ToString();
                aboutid.Text = row.Cells["aboutid"].Value.ToString()+".";
            }
        }

        private void abtbtn_Click(object sender, EventArgs e)
        {
            try
            {


                if (!Regex.IsMatch(desctxtbox.Text, @"^([a-zA-Z0-9@#$%&*+\-_(),+':;?.,![\]\s\\/{}""|]+)$"))
                {

                    MessageBox.Show("Abnormal Special Character found, Please remove it and proceed.");

                }
                else
                {
                    cmd = ("UPDATE about SET `heading`= '" + headingtxtbox.Text + "', `description`= '" + desctxtbox.Text + "' WHERE `aboutid`= '" + aboutid.Text + "'");
                    obj.nonQuery(cmd);

                    MessageBox.Show("Successfully Updated.");
                    // readfaq();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        

        private void termsbtn_Click(object sender, EventArgs e)
        {
            termspnl.Visible = true;
            faqpnl.Visible = false;
            aboutpnl.Visible = false;
            readterms();
        }

        private void faqbtn_Click(object sender, EventArgs e)
        {
            termspnl.Visible = false;
            faqpnl.Visible = true;
            aboutpnl.Visible = false;
            readfaq();
        }

        private void aboutbtn_Click(object sender, EventArgs e)
        {
            termspnl.Visible = false;
            faqpnl.Visible = false;
            aboutpnl.Visible = true;
            readabout();
        }
    }
}
