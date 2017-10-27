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
    public partial class customers : Form
    {

        DBConnect obj = new DBConnect();
        String email, username,orderid,count,cmd;
        bool status, nametxtok, desctxtok, editnametxtok, editdesctxtok, parknametxtok, parkdesctxtok, editparktxtok, editparkdesctxtok, sancnametxtok, sancdesctxtok, editsanctnametxtok, editsancdesctxtok;
        BindingSource bsource;
        MySqlDataAdapter adap;
        MySqlDataReader dr,dr2,dr3;
        MySqlCommandBuilder cmdbl;
        MySqlConnection con= new MySqlConnection( "SERVER=182.50.133.78;DATABASE=lalchowk;USER=lalchowk;PASSWORD=Lalchowk@123uzmah");
        PictureBox loading = new PictureBox();

        private container hp = null;
        private dialogcontainer dg = null;
        DataTable dt,dt1;


        public customers(Form hpcopy,Form dgcopy)
        {
            dg = dgcopy as dialogcontainer;
            hp = hpcopy as container;
            InitializeComponent();
            
            bgworker.RunWorkerAsync();
        }

        private void deluserbtn_Click(object sender, EventArgs e)
        {
            DialogResult dgr = MessageBox.Show("You sure you want to delete the following user ?\n"+namelbl.Text,"Confirm!",MessageBoxButtons.YesNo);
            if (dgr == DialogResult.Yes)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    cmd = "delete from customer where email='"+email+"'";
                    obj.nonQuery(cmd);
                    obj.closeConnection();
                    readcustomers();
                    customerdataview.DataSource = bsource;
                    Cursor = Cursors.Arrow;
                }
                catch (Exception ex)
                {
                    var message = ex.ToString();
                    string[] split = message.Split(new string[] { "at" }, StringSplitOptions.None);
                    MessageBox.Show("Something happened, please try again.\n\n" + split[0], "Error!");
                }
            }
        }

        public void loadingnormal()
        {
            formlbl.Text = "Loading";

            loading = new PictureBox()
            {
                Image = Properties.Resources.loading,
                Size = new Size(40, 30),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Location = new Point(73, 0),
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

        private void bgworker_DoWork(object sender, DoWorkEventArgs e)
        {
            
            readcustomers();
            readcount();
        }

        private void bgworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (ActiveForm == dg)
            {
                dg.loadingimage.Visible = false;
                dg.lbl.ForeColor = SystemColors.Highlight;
                dg.lbl.Text = "Customers";

            }
            else
            {
                loading.Visible = false;
                
            }
            customerdataview.DataSource = bsource;
            formlbl.Visible = false;
            countlbl.Text="Total Registered Customers: " + count;
            pnl.Visible = true;

           
        }

    /*    int numberOfPoints = 0;
        private void timer_Tick(object sender, EventArgs e)
        {
            
            int maxPoints = 5;                                       //loading sign on timer
           
            dg.lbl.BorderStyle = BorderStyle.FixedSingle;
            dg.lbl.ForeColor = Color.Red;
            dg.lbl.Text = "Loading" + new string('.', numberOfPoints);
            numberOfPoints = (numberOfPoints + 1) % (maxPoints + 1);
        }
        */
      
        private void readcustomers()
        {
            try
            {
                dr = obj.Query("select * from customer");

                dt1 = new DataTable();
                dt1.Load(dr);
                obj.closeConnection();
                bsource = new BindingSource();

                bsource.DataSource = dt1;
            }
            catch (Exception ex)
            {
                var message = ex.ToString();
                string[] split = message.Split(new string[] { "at" }, StringSplitOptions.None);
                MessageBox.Show("Something happened, please try again.\n\n" + split[0], "Error!");
            }


        }

        private void mailbtn_Click(object sender, EventArgs e)
        {
            dialogcontainer dg = new dialogcontainer();
            promomail pm = new promomail(emaillbl.Text,dg);
            pm.TopLevel = false;
            dg.Size = new Size(700, 715);
            pm.epnl.Location = new Point(-300, 1);
            pm.elistlbl.Text = "";
            
            dg.dialogpnl.Controls.Add(pm);
            pm.loadingdg();
            dg.Text = "Send Email";

            dg.Show();

            pm.Show();
        }


        private void readcount()
        {try { 
            dr = obj.Query("select count(*) from customer");
            dr.Read();
            count = dr[0].ToString();
            obj.closeConnection();
        }
            catch (Exception ex)
            {
                var message = ex.ToString();
                string[] split = message.Split(new string[] { "at" }, StringSplitOptions.None);
                MessageBox.Show("Something happened, please try again.\n\n" + split[0], "Error!");
            }
        }
       

        private void readdetails()
        {
            try
            {
                dr = obj.Query("select * from cartitems where email='" + email + "'");
                dr.Read();
                dt = new DataTable();
                dt.Load(dr);
                obj.closeConnection();     
                BindingSource bsource = new BindingSource();
                bsource.DataSource = dt;
                cartdataview.DataSource = bsource;

                dr = obj.Query("select * from wishlist where email='" + email + "'");
                dr.Read();
                dt = new DataTable();
                dt.Load(dr);
                obj.closeConnection();
                BindingSource bsource2 = new BindingSource();
                bsource2.DataSource = dt;
                wishlistdataview.DataSource = bsource2;

                con.Open();
                adap = new MySqlDataAdapter("select * from orders where email='" + email + "'", con);
                dt = new DataTable();
                adap.Fill(dt);
                con.Close();
                BindingSource bsource3 = new BindingSource();
                bsource3.DataSource = dt;
                ordersdataview.DataSource = bsource3;

                con.Open();
                adap = new MySqlDataAdapter("select * from addresses where email='" + email + "'", con);
                dt = new DataTable();
                adap.Fill(dt);
                con.Close();
                BindingSource bsource4 = new BindingSource();
                bsource4.DataSource = dt;
                addressdataview.DataSource = bsource4;


            }
            catch (Exception ex)
            {
                var message = ex.ToString();
                string[] split = message.Split(new string[] { "at" }, StringSplitOptions.None);
                MessageBox.Show("Something happened, please try again.\n\n" + split[0], "Error!");
            }
            obj.closeConnection();
        }


        private void updbtn_Click_1(object sender, EventArgs e)
        {
            try
            {
                cmdbl = new MySqlCommandBuilder(adap);
                adap.Update(dt) ;
                MessageBox.Show("Updated Successfully.");
            }
            catch (Exception ex)
            {
                var message = ex.ToString();
                string[] split = message.Split(new string[] { "at" }, StringSplitOptions.None);
                MessageBox.Show("Something happened, please try again.\n\n" + split[0], "Error!");
            }
        }

        private void customerdataview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            inflbl.Visible = false;
            Cursor = Cursors.WaitCursor;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.customerdataview.Rows[e.RowIndex];               
                email = row.Cells["email"].Value.ToString();
                emaillbl.Text = row.Cells["mail"].Value.ToString();
                namelbl.Text= row.Cells["name"].Value.ToString();
                contactlbl.Text= row.Cells["contact"].Value.ToString();
                
                dpnl.Visible = true;
                readdetails();
                ppnl.Visible = true;
                apnl.Visible = true;
                Cursor = Cursors.Arrow;
               
            }
        }

        private void emailtxt_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dt1);
            dv.RowFilter = string.Format("mail LIKE '%{0}%'", emailtxt.Text);
            customerdataview.DataSource = dv;
        }




        private void usertxt_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dt1);
            dv.RowFilter = string.Format("name LIKE '%{0}%'", usertxt.Text);
            customerdataview.DataSource = dv;
        }

        private void notbtn_Click(object sender, EventArgs e)
        {
            notification nf = new notification(email,emaillbl.Text);
            nf.loadingnormal();
            nf.ShowDialog();
        }


        /*   private void addanbtn_Click(object sender, EventArgs e)
           {
               if (nametxtok && desctxtok && status == true)
               {
                   StringBuilder s1 = new StringBuilder(desctxt.Text);
                   s1.Replace(@"\", @"\\");
                   s1.Replace("'", "\\'");
                   cmd = "insert into animals (`name`, `description`, `pic`) values ('" + nametxt.Text + "', '" + s1 + @"', 'C:\\Vkashmir\\animals\\" + nametxt.Text + ".jpg')";
                   dpbox.BackgroundImage.Save("C:\\Vkashmir\\animals\\" + nametxt.Text + ".jpg");

                   obj.nonQuery(cmd);

                   MessageBox.Show("New Animal added succesfully!");
                   nametxt.Text = "";
                   desctxt.Text = "";
                   dpbox.BackgroundImage = null;
                   readcustomers();
               }
               else
               {
                   inclbl.Visible = true;
               }
           } 

           private void cancelbtn_Click(object sender, EventArgs e)
           {
               nametxt.Text = "";
               desctxt.Text = "";
               dpbox.BackgroundImage = null;

           }

           private void animalbox_SelectedIndexChanged(object sender, EventArgs e)
           {
               dr = obj.Query("select * from animals where name='" + animalbox.Text + "'");
               dr.Read();
               editnametxt.Text = dr[1].ToString();
               editdesctxt.Text = dr[2].ToString();
               edpbox.BackgroundImage = new Bitmap(dr[3].ToString());
               agree.Checked = false;
               obj.closeConnection();
           } 

           private void updateanbtn_Click(object sender, EventArgs e)
           {
               if (editnametxt.Text.Contains("'") || editnametxt.Text.Contains("\\"))
                   MessageBox.Show("Name cannot contain ' & \\");
               else
               {
                   if (agree.Checked && editnametxtok && editdesctxtok == true)
                   {
                       if (status == true)
                       {
                           StringBuilder s1 = new StringBuilder(editdesctxt.Text);
                           s1.Replace(@"\", @"\\");
                           s1.Replace("'", "\\'");
                           cmd = ("update animals set `name`='" + editnametxt.Text + "', `description`='" + s1 + @"', `pic`='C:\\Vkashmir\\animals\\" + editnametxt.Text + ".jpg' where `name`='" + animalbox.Text + "';");
                           dpbox.BackgroundImage.Save("C:\\Vkashmir\\animals\\" + editnametxt.Text + ".jpg");
                       }
                       else
                       {
                           StringBuilder s1 = new StringBuilder(editdesctxt.Text);
                           s1.Replace(@"\", @"\\");
                           s1.Replace("'", "\\'");
                           cmd = ("update animals set `name`='" + editnametxt.Text + "', `description`='" + s1 + "' where `name`='" + animalbox.Text + "';");

                       }
                       obj.nonQuery(cmd);
                       MessageBox.Show("Animal updated succesfully!");
                       editnametxt.Text = "";
                       editdesctxt.Text = "";
                       edpbox.BackgroundImage = null;
                       agree.Checked = false;
                       readcustomers();
                   }
                   else
                   {
                       inclbl2.Visible = true;
                   }

               }
           }

           private void editcancelbtn_Click(object sender, EventArgs e)
           {
               editnametxt.Text = "";
               editdesctxt.Text = "";
               agree.Checked = false;
               edpbox.BackgroundImage = null;

           } */





        /*    private void updateparkbtn_Click(object sender, EventArgs e)
            {
                if (editparktxt.Text.Contains("'") || editparktxt.Text.Contains("\\"))
                    MessageBox.Show("Name cannot contain ' & \\");
                else
                {
                    if (pagree.Checked && editparktxtok && editparkdesctxtok == true)
                    {
                        if (status == true)
                        {
                            StringBuilder s1 = new StringBuilder(editparkdesctxt.Text);
                            s1.Replace(@"\", @"\\");
                            s1.Replace("'", "\\'");
                            cmd = ("update wildlife set `name`='" + editparktxt.Text + "', `description`='" + s1 + @"', `pic`='C:\\Vkashmir\\wildlife\\" + editparktxt.Text + ".jpg', `class`='2' where `name`='" + parkbox.Text + "'");
                            epdpbox.BackgroundImage.Save("C:\\Vkashmir\\wildlife\\" + editparktxt.Text + ".jpg");
                        }
                        else
                        {
                            StringBuilder s1 = new StringBuilder(editparkdesctxt.Text);
                            s1.Replace(@"\", @"\\");
                            s1.Replace("'", "\\'");
                            cmd = ("update wildlife set `name`='" + editparktxt.Text + "', `description`='" + s1 + "', `class`='2' where `name`='" + parkbox.Text + "'");

                        }
                        obj.nonQuery(cmd);
                        MessageBox.Show("Details updated for the selected park.");
                        editparktxt.Text = "";
                        editparkdesctxt.Text = "";
                        epdpbox.BackgroundImage = null;
                        pagree.Checked = false;
                        readparks();
                    }
                    else
                    {
                        inclblep.Visible = true;
                    }

                }
              }*/



        /*   private void addsancbtn_Click(object sender, EventArgs e)
           {
               if (sancnametxtok && sancdesctxtok && status == true)
               {
                   StringBuilder s1 = new StringBuilder(sancdesctxt.Text);
                   s1.Replace(@"\", @"\\");
                   s1.Replace("'", "\\'");
                   cmd = "insert into wildlife (`name`, `description`, `pic`, `class`) values ('" + sancnametxt.Text + "', '" + s1 + @"', 'C:\\Vkashmir\\wildlife\\" + sancnametxt.Text + ".jpg', '1')";
               //    dpbox.BackgroundImage.Save("C:\\Vkashmir\\wildlife\\" + sancnametxt.Text + ".jpg");

                   obj.nonQuery(cmd);

                   MessageBox.Show("New Sanctuary added succesfully!");
                   sancnametxt.Text = "";
                   sancdesctxt.Text = "";
                   sdpbox.BackgroundImage = null;
                   readsanc();
               }
               else
                   inclbls.Visible = true;
           }*/














        /*     private void updatesancbtn_Click(object sender, EventArgs e)
             {
                 if (editsanctnametxt.Text.Contains("'") || editsanctnametxt.Text.Contains("\\"))
                     MessageBox.Show("Name cannot contain ' & \\");
                 else
                 {
                     if (sagree.Checked && editsanctnametxtok && editsancdesctxtok == true)
                     {
                         if (status == true)
                         {
                             StringBuilder s1 = new StringBuilder(editsancdesctxt.Text);
                             s1.Replace(@"\", @"\\");
                             s1.Replace("'", "\\'");
                             cmd = ("update wildlife set `name`='" + editsanctnametxt.Text + "', `description`='" + s1 + @"', `pic`='C:\\Vkashmir\\wildlife\\" + editsanctnametxt.Text + ".jpg', `class`='1' where `name`='" + sancbox.Text + "'");
                        //     dpbox.BackgroundImage.Save("C:\\Vkashmir\\wildlife\\" + editsanctnametxt.Text + ".jpg");
                         }
                         else
                         {
                             StringBuilder s1 = new StringBuilder(editsancdesctxt.Text);
                             s1.Replace(@"\", @"\\");
                             s1.Replace("'", "\\'");
                             cmd = ("update wildlife set `name`='" + editsanctnametxt.Text + "', `description`='" + s1 + "', `class`='1' where `name`='" + sancbox.Text + "'");

                         }
                         obj.nonQuery(cmd);
                         MessageBox.Show("Details updated for the selected sanctuary.");
                         editsanctnametxt.Text = "";
                         editsancdesctxt.Text = "";
                         sdpbox.BackgroundImage = null;
                         sagree.Checked = false;
                         readsanc();
                     }
                     else
                     {
                         inclblse.Visible = true;
                     }
                 }
             }

             private void parknametxt_Leave(object sender, EventArgs e)
             {

                 if (parknametxt.Text == "")
                     parknametxtok = false;
                 else
                     parknametxtok = true;
                 if (parknametxt.Text.Contains("\\") || parknametxt.Text.Contains("'"))
                 {
                     MessageBox.Show("Name cannot contain special characters");
                     parknametxt.Text = "";
                     parknametxt.Focus();
                 }
             }

           /*  private void sedpbox_Click(object sender, EventArgs e)
             {
                 if (openFileDialog1.ShowDialog() == DialogResult.OK)
                 {
                     s = openFileDialog1.FileName;
                     Image myimage = new Bitmap(s);
                     dpbox.BackgroundImage = myimage;
                     dpbox.BackgroundImageLayout = ImageLayout.Stretch;
                     status = true;

                 }
             } */




        /*     private void sdpbox_Click(object sender, EventArgs e)
             {
                 if (openFileDialog1.ShowDialog() == DialogResult.OK)
                 {
                     s = openFileDialog1.FileName;
                     Image myimage = new Bitmap(s);
                     dpbox.BackgroundImage = myimage;
                     dpbox.BackgroundImageLayout = ImageLayout.Stretch;
                     status = true;

                 }
             } 

             private void epdpbox_Click(object sender, EventArgs e)
             {
                 if (openFileDialog1.ShowDialog() == DialogResult.OK)
                 {
                     s = openFileDialog1.FileName;
                     Image myimage = new Bitmap(s);
                     dpbox.BackgroundImage = myimage;
                     dpbox.BackgroundImageLayout = ImageLayout.Stretch;
                     status = true;

                 }
             }
              */


        /*   private void pdpbox_Click(object sender, EventArgs e)
           {
               if (openFileDialog1.ShowDialog() == DialogResult.OK)
               {
                   s = openFileDialog1.FileName;
                   Image myimage = new Bitmap(s);
                   dpbox.BackgroundImage = myimage;
                   dpbox.BackgroundImageLayout = ImageLayout.Stretch;
                   status = true;

               }
           }
           */



        /*    private void nametxt_Leave(object sender, EventArgs e)
            {
                if (nametxt.Text == "")
                    nametxtok = false;
                else
                    nametxtok = true;
                if (nametxt.Text.Contains("\\") || nametxt.Text.Contains("'"))
                {
                    MessageBox.Show("Name cannot contain special characters");
                    nametxt.Text = "";
                    nametxt.Focus();
                }
            } */



        /*    private void dpbox_Click(object sender, EventArgs e)
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    s = openFileDialog1.FileName;
                    Image myimage = new Bitmap(s);
                    dpbox.BackgroundImage = myimage;
                    dpbox.BackgroundImageLayout = ImageLayout.Stretch;
                    status = true;

                }
            } 


            private void addparkbtn_Click(object sender, EventArgs e)
            {
                if (parknametxtok && parkdesctxtok && status == true)
                {
                    StringBuilder s1 = new StringBuilder(parkdesctxt.Text);
                    s1.Replace(@"\", @"\\");
                    s1.Replace("'", "\\'");
                    cmd = "insert into wildlife (`name`, `description`, `pic`, `class`) values ('" + parknametxt.Text + "', '" + s1 + @"', 'C:\\Vkashmir\\wildlife\\" + parknametxt.Text + ".jpg', '2')";
                 //   dpbox.BackgroundImage.Save("C:\\Vkashmir\\wildlife\\" + parknametxt.Text + ".jpg");
                    obj.nonQuery(cmd);

                    MessageBox.Show("New Park added succesfully!");
                    parknametxt.Text = "";
                    parkdesctxt.Text = "";
                    pdpbox.BackgroundImage = null;
                    readparks();
                }
                else
                    inclblp.Visible = true;
            }*/
    }
}
