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

namespace Modest_Attires
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
            if (dg!=null)
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
            try { 
            con.Open();
            adap = new MySqlDataAdapter("select * from terms", con);
            dt = new DataTable();
            adap.Fill(dt);
            con.Close();
            bsource = new BindingSource();
            bsource.DataSource = dt;
            }

            catch (Exception ex)
            {

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }

        public void readfaq()
        {
            try { 
            con.Open();
            adap = new MySqlDataAdapter("select * from faq", con);
            dt = new DataTable();
            adap.Fill(dt);
            con.Close();
            bsource = new BindingSource();
            bsource.DataSource = dt;
            }

            catch (Exception ex)
            {

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }

        public void readabout()
        {
            try { 
            con.Open();
            adap = new MySqlDataAdapter("select * from about", con);
            dt = new DataTable();
            adap.Fill(dt);
            con.Close();
            bsource = new BindingSource();
            bsource.DataSource = dt;
            }

            catch (Exception ex)
            {

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }

     

        private void tupdbtn_Click(object sender, EventArgs e)
        {
            try
            {
               

                if (!Regex.IsMatch(desctxt.Text, @"^([a-zA-Z0-9@#$%&*+\-_(),+':;?.,![\]\s\\/{}""|]+)$")&& desctxt.Text!="")
                {

                    MessageBox.Show("Abnormal Special Character found, Please remove it and proceed.");

                }
                else
                {
                    try { 
                    cmd = ("UPDATE terms SET `heading`= '"+headingtxt.Text+"', `description`= '"+desctxt.Text+"' WHERE `termsid`= '"+termsidlbl.Text+"'");
                    obj.nonQuery(cmd);

                    MessageBox.Show("Successfully Updated.");
                    }

                    catch (Exception)
                    {
                        MessageBox.Show("Something happened, please try again");
                    }
                    readterms();
                    termsdataview.DataSource = bsource;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }

        

     

        private void faqupdbtn_Click(object sender, EventArgs e)
        {
                if (!Regex.IsMatch(anstxt.Text, @"^([a-zA-Z0-9@#$%&*+\-_(),+':;?.,![\]\s\\/{}""|]+)$")&& anstxt.Text!="")
                {

                    MessageBox.Show("Abnormal Special Character found, Please remove it and proceed.");

                }
                else
                {
                    try { 
                    cmd = ("UPDATE faq SET `question`= '" + qtxt.Text + "', `answer`= '" + anstxt.Text + "' WHERE `faqid`= '" + faqid.Text + "'");
                    obj.nonQuery(cmd);

                    MessageBox.Show("Successfully Updated.");
                    }

                catch (Exception ex)
                {

                    MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
                }
                readfaq();
                    faqdataview.DataSource = bsource;
                }
        }


        private void abtbtn_Click(object sender, EventArgs e)
        {
                if (!Regex.IsMatch(desctxtbox.Text, @"^([a-zA-Z0-9@#$%&*+\-_(),+':;?.,![\]\s\\/{}""|]+)$")&& desctxtbox.Text!="")
                {

                    MessageBox.Show("Abnormal Special Character found, Please remove it and proceed.");

                }
                else
                {
                    try { 
                    cmd = ("UPDATE about SET `heading`= '" + headingtxtbox.Text + "', `description`= '" + desctxtbox.Text + "' WHERE `aboutid`= '" + aboutid.Text + "'");
                    obj.nonQuery(cmd);

                    MessageBox.Show("Successfully Updated.");
                    }

                catch (Exception ex)
                {

                    MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
                }
                readabout();
                    aboutdataview.DataSource = bsource;

                }

        }

        private void loadingshow()
        {
            loadinglbl.Visible = true;
            loadingpic.Visible = true;
        }
        
        private void termsbtn_Click(object sender, EventArgs e)
        {
            termsidlbl.Visible = false;
            tupdbtn.Visible = false;
            headingtxt.Visible = false;
            desctxt.Visible = false;
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
            faqupdbtn.Visible = false;
            qtxt.Visible = false;
            anstxt.Visible = false;
            faqid.Visible = false;
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
            aboutid.Visible = false;
            headingtxtbox.Visible = false;
            desctxtbox.Visible = false;
            abtbtn.Visible = false;
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

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
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

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
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

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }

        private void termsdataview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.termsdataview.Rows[e.RowIndex];
                headingtxt.Text = row.Cells["heading"].Value.ToString();
                desctxt.Text = row.Cells["description"].Value.ToString();
                termsidlbl.Text = row.Cells["termsid"].Value.ToString() + ".";
                tupdbtn.Visible = true;
                headingtxt.Visible = true;
                desctxt.Visible = true;
                termsidlbl.Visible = true;
                
            }
        }

        private void faqdataview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.faqdataview.Rows[e.RowIndex];
                qtxt.Text = row.Cells["question"].Value.ToString();
                anstxt.Text = row.Cells["answer"].Value.ToString();
                faqid.Text = row.Cells["faqid"].Value.ToString() + ".";
                faqupdbtn.Visible = true;
                qtxt.Visible = true;
                anstxt.Visible = true;
                faqid.Visible = true;
            }
        }

        private void aboutdataview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.aboutdataview.Rows[e.RowIndex];
                headingtxtbox.Text = row.Cells["heading"].Value.ToString();
                desctxtbox.Text = row.Cells["description"].Value.ToString();
                aboutid.Text = row.Cells["aboutid"].Value.ToString() + ".";
                headingtxtbox.Visible = true;
                desctxtbox.Visible = true;
                abtbtn.Visible = true;
                aboutid.Visible = true;
            }
        }
    }
}
