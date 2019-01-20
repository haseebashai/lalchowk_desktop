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
    public partial class messages : Form
    {

        DBConnect obj = new DBConnect();
        MySqlDataReader dr;
        DataTable dt;
        PictureBox loading = new PictureBox();
        BindingSource bsource;


        private dialogcontainer dg = null;

        public messages(Form dgcopy)
        {
            dg = dgcopy as dialogcontainer;
            InitializeComponent();
            bgworker.RunWorkerAsync();
        }

        private void readmsgs()
        {try {
            dr = obj.Query("SELECT customer.mail,messages.*  FROM lalchowk.messages inner join customer on customer.email=messages.email order by messageid desc");
            dt = new DataTable();
            dt.Load(dr);
            obj.closeConnection();
            bsource = new BindingSource();
            bsource.DataSource = dt;
        }
            catch (Exception ex)
            {

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }


        private void messagesdataview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.messagesdataview.Rows[e.RowIndex];
                midlbl.Text = row.Cells["messageid"].Value.ToString();
                emaillbl.Text = row.Cells["mail"].Value.ToString();
                sublbl.Text = row.Cells["subject"].Value.ToString();
                msgtxt.Text = row.Cells["message"].Value.ToString();
                if (row.Cells["reply"].Value.ToString() == "")
                {
                    replybox.Visible = false;
                    sendbtn.Location = new Point(468, 94);
                    sendbtn.Text = "send reply mail";
                }
                else
                {
                    replybox.Visible = true;
                    replybox.Text = row.Cells["reply"].Value.ToString();
                    sendbtn.Text = "Already replied";
                    sendbtn.Location = new Point(468, 24);
                }
                
                mpnl.Visible = true;



            }
        }

        private void sendbtn_Click(object sender, EventArgs e)
        {
         
            mail ml = new mail(emaillbl.Text,sublbl.Text,msgtxt.Text,midlbl.Text);
            ml.ShowDialog();

            BackgroundWorker msg = new BackgroundWorker();
            msg.DoWork += (o, a) => 
            {
                readmsgs();
            };

            msg.RunWorkerCompleted += (o, b) => 
            {
                try
                {
                    messagesdataview.DoubleBuffered(true);
                    messagesdataview.DataSource = bsource;
                }catch { }
            };
            msg.RunWorkerAsync();
            
        }

        private void bgworker_DoWork(object sender, DoWorkEventArgs e)
        {
            readmsgs();
        }

        private void bgworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (dg!=null)
            {
                dg.loadingimage.Visible = false;
                dg.lbl.ForeColor = SystemColors.Highlight;
                dg.lbl.Text = "User Messages";

            }
            else
            {
                loading.Visible = false;
                formlbl.Text="User Messages";
                formlbl.BringToFront();
            }
            messagesdataview.DoubleBuffered(true);
            messagesdataview.DataSource = bsource;
            msgpnl.Visible = true;
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

        private void delbtn_Click(object sender, EventArgs e)
        {
           
                DialogResult dgr = MessageBox.Show("Do you want to delete this message from \n "+emaillbl.Text+" ?", "Confirm!", MessageBoxButtons.YesNo);
                if (dgr == DialogResult.Yes)
                {
                    try
                    {
                        string cmd = "delete from messages where messageid='" + midlbl.Text + "'";
                        obj.nonQuery(cmd);
                        obj.closeConnection();
                        MessageBox.Show("Message deleted.");
                        Cursor = Cursors.WaitCursor;
                        readmsgs();
                        messagesdataview.DataSource = bsource;
                        Cursor = Cursors.Arrow;
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
                    }
                }
            
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            DialogResult dgr = MessageBox.Show("Have you replied to this message seperately ? \n " + emaillbl.Text + " ?", "Confirm!", MessageBoxButtons.YesNo);
            if (dgr == DialogResult.Yes)
            {
                try
                {
                    string cmd = "update messages set reply ='Replied in mail.' where messageid='" + midlbl.Text + "'";
                    obj.nonQuery(cmd);
                    obj.closeConnection();
                    MessageBox.Show("Updated.");
                    Cursor = Cursors.WaitCursor;
                    readmsgs();
                    messagesdataview.DoubleBuffered(true);
                    messagesdataview.DataSource = bsource;
                    Cursor = Cursors.Arrow;
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
                }
            }
        }

    }
}
