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
using System.IO;
using System.Net;

namespace Veiled_Kashmir_Admin_Panel
{
    public partial class Settings : Form
    {

        PictureBox loading = new PictureBox();
        DBConnect obj = new DBConnect();
        MySqlConnection con = new MySqlConnection("SERVER=182.50.133.78;DATABASE=lalchowk;USER=lalchowk;PASSWORD=Lalchowk@123uzmah");
        MySqlDataReader dr;
        MySqlDataAdapter adap;
        DataTable dt;
        MySqlCommandBuilder cmdbl;
        BindingSource bsource;
        string cmd;


        private dialogcontainer dg = null;
        public Settings(Form dgcopy)
        {
            dg = dgcopy as dialogcontainer;
            InitializeComponent();
            bgotp.RunWorkerAsync();
        }

        public void loadingnormal()
        {
            formlbl.Text = "Loading";
            formlbl.BringToFront();
            loading = new PictureBox()
            {
                Image = Properties.Resources.loading,
                Size = new Size(40, 30),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Location = new Point(76, 0),
            };
            this.Controls.Add(loading);
            loading.BringToFront();
        }

        public void loadingdg()
        {
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

        private void panelshow()
        {

            bpnl.Enabled = true;
            epnl.Visible = true;
            updbtn.Visible = true;
            settingsdataview.Visible = true;

        }

        private void panelhide()
        {
            bpnl.Enabled = false;
            epnl.Visible = false;
            updbtn.Visible = false;
            settingsdataview.Visible = false;

        }

        public void readotp()
        {
            try { 
            adap = new MySqlDataAdapter("select * from otp", con);
            dt = new DataTable();
            adap.Fill(dt);
            bsource = new BindingSource();
            bsource.DataSource = dt;
                }
            catch (Exception ex)
            {

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }

        }
        public void readpincodes()
        {
            try { 
            adap = new MySqlDataAdapter("select * from pincodes", con);
            dt = new DataTable();
            adap.Fill(dt);
            bsource = new BindingSource();
            bsource.DataSource = dt;
        }
            catch (Exception ex)
            {

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }

        }
        public void readverification()
        {
            try { 
            adap = new MySqlDataAdapter("select * from verification", con);
            dt = new DataTable();
            adap.Fill(dt);
            bsource = new BindingSource();
            bsource.DataSource = dt;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }

        private void bgotp_DoWork(object sender, DoWorkEventArgs e)
        {
            readotp();
        }

        private void bgotp_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (dg!=null)
            {
                dg.loadingimage.Visible = false;
                dg.lbl.ForeColor = SystemColors.Highlight;
                dg.lbl.Text = "OTP/Pincodes";

            }
            else
            {
                loading.Visible = false;
                formlbl.Visible = false;

            }
            bpnl.Visible = true;
            settingsdataview.DataSource = bsource;
            
            settingsdataview.Location = new Point(3, 134);
            updbtn.Location = new Point(1018, 282);
            ppnl.Visible = false;
            settingsdataview.BringToFront();
            spnl.Visible = true;
            panelshow(); loadingaccpic.Visible = false;
            epnl.Visible = false;
        }

        private void bgpincodes_DoWork(object sender, DoWorkEventArgs e)
        {
            readpincodes();
        }

        private void bgpincodes_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            settingsdataview.DataSource = bsource;
            settingsdataview.Location = new Point(3, 234);
            updbtn.Location = new Point(1018, 382);
            spnl.Visible = true;
            panelshow();
        }

        private void bgverification_DoWork(object sender, DoWorkEventArgs e)
        {
            readverification();
        }

        private void bgverification_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            settingsdataview.DataSource = bsource;
            settingsdataview.Location = new Point(3, 134);
            updbtn.Location = new Point(1018, 282);
            spnl.Visible = true;
            panelshow();
            loadingaccpic.Visible = false;
        }

        private void otpbtn_Click(object sender, EventArgs e)
        {
            panelhide();
            loadingshow();

            bgotp.RunWorkerAsync();


            ppnl.Visible = false;
            loadingaccpic.SendToBack();
            settingsdataview.BringToFront();
        }

        private void pinbtn_Click(object sender, EventArgs e)
        {
            panelhide();
            loadingshow();

            bgpincodes.RunWorkerAsync();


            ppnl.Visible = true;
        }

        private void verbtn_Click(object sender, EventArgs e)
        {
            panelhide();
            loadingshow();

            bgverification.RunWorkerAsync();


            ppnl.Visible = false;
            settingsdataview.BringToFront();
        }

        private void addpbtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if (pyes.Checked)
                {
                    cmd = ("insert into pincodes(`pincode`, `deliverytime`,`cod`,`area`,`extracharges`) values ('" + pintxt.Text + "','" + deltxt.Text + "','1','" + areatxt.Text + "','"+delchtxt.Text+"')");
                    obj.nonQuery(cmd);
                    obj.closeConnection();
                }
                else
                {
                    cmd = ("insert into pincodes(`pincode`, `deliverytime`,`cod`,`area`,`extracharges`) values ('" + pintxt.Text + "','" + deltxt.Text + "','0','" + areatxt.Text + "','" + delchtxt.Text + "')");
                    obj.nonQuery(cmd);
                    obj.closeConnection();
                }
                MessageBox.Show("Pincode added.");

                pintxt.Text = "";
                deltxt.Text = "";
                areatxt.Text = "";
                delchtxt.Text = "";
                pyes.Checked = false;
                pno.Checked = false;

                readpincodes();
                settingsdataview.DataSource = bsource;
            }
            catch (Exception ex)
            {
                obj.closeConnection();
                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
            Cursor = Cursors.Arrow;

        }

        private void delbtn_Click(object sender, EventArgs e)
        {
            panelhide();
            loadingshow();

            BackgroundWorker charges = new BackgroundWorker();
            charges.DoWork += (o, a) => 
            {
                try
                {
                    adap = new MySqlDataAdapter("select * from del", con);
                    dt = new DataTable();
                    adap.Fill(dt);
                    bsource = new BindingSource();
                    bsource.DataSource = dt;
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
                }
            };
            charges.RunWorkerCompleted += (o, b) => 
            {
                settingsdataview.DataSource = bsource;
               
                settingsdataview.Location = new Point(3, 134);
                updbtn.Location = new Point(1018, 282);
                spnl.Visible = true;
                panelshow();
                loadingaccpic.Visible = false;
            };
            charges.RunWorkerAsync();


            ppnl.Visible = false;
            settingsdataview.BringToFront();
        }

        private void appverbtn_Click(object sender, EventArgs e)
        {
            panelhide();
            loadingshow();

            BackgroundWorker versions = new BackgroundWorker();
            versions.DoWork += (o, a) =>
            {
                try
                {
                    adap = new MySqlDataAdapter("select * from versions", con);
                    dt = new DataTable();
                    adap.Fill(dt);
                    bsource = new BindingSource();
                    bsource.DataSource = dt;
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
                }
            };
            versions.RunWorkerCompleted += (o, b) =>
            {
                settingsdataview.DataSource = bsource;

                settingsdataview.Location = new Point(3, 134);
                updbtn.Location = new Point(1018, 282);
                spnl.Visible = true;
                panelshow();
                loadingaccpic.Visible = false;
            };
            versions.RunWorkerAsync();


            ppnl.Visible = false;
            settingsdataview.BringToFront();
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

        private void pyes_CheckedChanged(object sender, EventArgs e)
        {
            if (pyes.Checked)
                pno.Checked = false;
        }

        private void pno_CheckedChanged(object sender, EventArgs e)
        {
            if (pno.Checked)
                pyes.Checked = false;
        }

        private void pintxt_Click(object sender, EventArgs e)
        {
            pintxt.SelectionStart = 0;
        }

        private void caboutbtn_Click(object sender, EventArgs e)
        {
            dialogcontainer dg = new dialogcontainer();
            terms tr = new terms(this,dg);
            tr.TopLevel = false;
            dg.Size = new Size(900, 715);
            dg.dialogpnl.Controls.Add(tr);
            tr.loadingdg();
            dg.Text = "Policies";


            dg.Show();
            tr.Show();
        }
    }
}
