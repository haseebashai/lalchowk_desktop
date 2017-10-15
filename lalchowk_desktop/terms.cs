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
        BindingSource bsource;
        PictureBox loading = new PictureBox();

        private dialogcontainer dg = null;
        private container hp = null;
        public terms(Form hpcopy,Form dgcopy)
        {
            dg = dgcopy as dialogcontainer;
            hp = hpcopy as container;
            InitializeComponent();
            bgterms.RunWorkerAsync();
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

        private void bgterms_DoWork(object sender, DoWorkEventArgs e)
        {
            readterms();
        }

        private void bgterms_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (ActiveForm == dg)
            {
                dg.loadingimage.Visible = false;
                dg.lbl.ForeColor = SystemColors.Highlight;
                dg.lbl.Text = "Policies";

            }
            else
            {
                loading.Visible = false;
                formlbl.Text = "Policies";
                formlbl.Visible = true;
            }
            termsdataview.DataSource = bsource;
            bpnl.Visible = true;
            ppnl.Visible = true;
            bpnl.Enabled = true;
        }

        public void readterms()
        {
            con.Open();
            adap = new MySqlDataAdapter("select * from terms", con);
            dt = new DataTable();
            adap.Fill(dt);
            con.Close();
            bsource = new BindingSource();
            bsource.DataSource = dt;
            
        }

        public void readfaq()
        {
            con.Open();
            adap = new MySqlDataAdapter("select * from faq", con);
            dt = new DataTable();
            adap.Fill(dt);
            con.Close();
            bsource = new BindingSource();
            bsource.DataSource = dt;
            
        }

        public void readabout()
        {
            con.Open();
            adap = new MySqlDataAdapter("select * from about", con);
            dt = new DataTable();
            adap.Fill(dt);
            con.Close();
            bsource = new BindingSource();
            bsource.DataSource = dt;
            
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
                    readterms();
                    termsdataview.DataSource = bsource;
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
                    readfaq();
                    faqdataview.DataSource = bsource;
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
                    readabout();
                    aboutdataview.DataSource = bsource;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void loadingshow()
        {
            loadinglbl.Visible = true;
            loadingpic.Visible = true;
        }
        
        private void termsbtn_Click(object sender, EventArgs e)
        {
            loadingshow();
            bpnl.Enabled = false;
            ppnl.Visible = false;
            bgterms.RunWorkerAsync();
            termspnl.Visible = true;
            faqpnl.Visible = false;
            aboutpnl.Visible = false;
            
            
            
        }
        private void bgfaq_DoWork(object sender, DoWorkEventArgs e)
        {
            readfaq();
        }

        private void bgfaq_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            faqdataview.DataSource = bsource;
            bpnl.Visible = true;
            ppnl.Visible = true;
            bpnl.Enabled = true;
        }

        private void faqbtn_Click(object sender, EventArgs e)
        {
            loadingshow();
            bpnl.Enabled = false;
            ppnl.Visible = false;
            bgfaq.RunWorkerAsync();
            termspnl.Visible = false;
            faqpnl.Visible = true;
            aboutpnl.Visible = false;
            
        }

        private void aboutbtn_Click(object sender, EventArgs e)
        {
            loadingshow();
            bpnl.Enabled = false;
            ppnl.Visible = false;
            bgabout.RunWorkerAsync();
            termspnl.Visible = false;
            faqpnl.Visible = false;
            aboutpnl.Visible = true;
            
        }

        private void bgabout_DoWork(object sender, DoWorkEventArgs e)
        {
            readabout();
        }

        private void bgabout_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            aboutdataview.DataSource = bsource;
            bpnl.Visible = true;
            ppnl.Visible = true;
            bpnl.Enabled = true;
        }

        private void addtbtn_Click(object sender, EventArgs e)
        {
            try
            {
                cmdbl = new MySqlCommandBuilder(adap);
                adap.Update(dt);
                MessageBox.Show("Terms entry added.");
                readterms();
                termsdataview.DataSource = bsource;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void addfaqbtn_Click(object sender, EventArgs e)
        {
            try
            {
                cmdbl = new MySqlCommandBuilder(adap);
                adap.Update(dt);
                MessageBox.Show("FAQ entry added.");
                readfaq();
                faqdataview.DataSource = bsource;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void addabtn_Click(object sender, EventArgs e)
        {
            try
            {
                cmdbl = new MySqlCommandBuilder(adap);
                adap.Update(dt);
                MessageBox.Show("About entry added.");
                readabout();
                aboutdataview.DataSource = bsource;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

       
    }
}
