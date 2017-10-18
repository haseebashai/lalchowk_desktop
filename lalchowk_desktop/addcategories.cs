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
    public partial class addcategories : Form
    {
        PictureBox loading = new PictureBox();
        DBConnect obj = new DBConnect();
        MySqlConnection con = new MySqlConnection("SERVER=182.50.133.78;DATABASE=lalchowk;USER=lalchowk;PASSWORD=Lalchowk@123uzmah");
        MySqlDataReader dr;
        MySqlDataAdapter adap;
        DataTable dt;
        MySqlCommandBuilder cmdbl;
        BindingSource bsource;


        private dialogcontainer dg = null;
        public addcategories(Form dgcopy)
        {
            dg = dgcopy as dialogcontainer;
            InitializeComponent();
            bgworker.RunWorkerAsync();
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
                Location = new Point(72, 0),
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

        private void bgworker_DoWork(object sender, DoWorkEventArgs e)
        {
            readfirstcat();
            
        }

        private void bgworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (ActiveForm == dg)
            {
                dg.loadingimage.Visible = false;
                dg.lbl.ForeColor = SystemColors.Highlight;
                dg.lbl.Text = "Categories";

            }
            else
            {
                loading.Visible = false;
                formlbl.Visible = false;

            }
            catdataview.DataSource = bsource;
            cpnl.Visible = true;
            panelshow();
        }

        public void readfirstcat()
        {
            
            adap = new MySqlDataAdapter("select * from firstcategory",con);
            dt = new DataTable();
            adap.Fill(dt);
            bsource = new BindingSource();
            bsource.DataSource = dt;

        }
        public void readsecondcat()
        {

            adap = new MySqlDataAdapter("select * from secondcategory", con);
            dt = new DataTable();
            adap.Fill(dt);
            bsource = new BindingSource();
            bsource.DataSource = dt;

        }
        public void readthirdcat()
        {

            adap = new MySqlDataAdapter("select * from thirdcategory", con);
            dt = new DataTable();
            adap.Fill(dt);
            bsource = new BindingSource();
            bsource.DataSource = dt;

        }

        private void bgworker2_DoWork(object sender, DoWorkEventArgs e)
        {
            readsecondcat();
        }

        private void bgworker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            catdataview.DataSource = bsource;
            cpnl.Visible = true;
            panelshow();
            
        }

        private void bgworker3_DoWork(object sender, DoWorkEventArgs e)
        {
            readthirdcat();
        }

        private void bgworker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
            catdataview.DataSource = bsource;
            cpnl.Visible = true;
            panelshow();

        }

        private void panelshow()
        {
            bpnl.Enabled = true;
            epnl.Visible = true;
            catdataview.Visible = true;
            
        }

        private void panelhide()
        {
            bpnl.Enabled = false;
            epnl.Visible = false;
            catdataview.Visible = false;
            
        }
        private void fcbtn_Click(object sender, EventArgs e)
        {
            panelhide();
            loadingshow();
            
            bgworker.RunWorkerAsync();


           fcpnl.Visible = true;
            scpnl.Visible = false;
            tcpnl.Visible = false;
        }

        private void scbtn_Click(object sender, EventArgs e)
        {
            panelhide();
            loadingshow();
            
            bgworker2.RunWorkerAsync();


            fcpnl.Visible = false;
            scpnl.Visible = true;
            tcpnl.Visible = false;
        }

        private void tcbtn_Click(object sender, EventArgs e)
        {
            panelhide();
            loadingshow();
            
            bgworker3.RunWorkerAsync();


            fcpnl.Visible = false;
            scpnl.Visible = false;
            tcpnl.Visible = true;
        }
    }
}
