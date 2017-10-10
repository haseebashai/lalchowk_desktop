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
        String email, username,orderid;
        bool status, nametxtok, desctxtok, editnametxtok, editdesctxtok, parknametxtok, parkdesctxtok, editparktxtok, editparkdesctxtok, sancnametxtok, sancdesctxtok, editsanctnametxtok, editsancdesctxtok;

        MySqlConnection con;
        MySqlDataAdapter adap;
        MySqlDataReader dr,dr2,dr3;
        MySqlCommandBuilder cmdbl;


        private container hp = null;
        DataTable dt,dt1;

        public customers(Form hpcopy)
        {
            hp = hpcopy as container;
            InitializeComponent();
        }

        private void readcustomers()
        {
            
            dr = obj.Query("select * from customer");
            
            dt1 = new DataTable();
            dt1.Load(dr);
            obj.closeConnection();
            BindingSource bsource = new BindingSource();

            bsource.DataSource = dt1;
            customerdataview.DataSource = bsource;

         /*   dr = obj.Query("select email from customer");
            DataTable dt = new DataTable();
            dt.Columns.Add("email", typeof(String));
            dt.Load(dr);
            obj.closeConnection();
            customerlist.DisplayMember = "email";
            customerlist.DataSource = dt; */
        }

        private void mailbtn_Click(object sender, EventArgs e)
        {
            promomail pm = new promomail(emaillbl.Text);
            pm.TopLevel = false;
            pm.label1.Text = "Send Mail";
            dialogcontainer dg = new dialogcontainer();
            dg.dialogpnl.Controls.Add(pm);
            dg.lbl.Text = "";

            dg.Show();

            pm.Show();
        }


        private void readcount()
        {
            dr = obj.Query("select count(*) from customer");
            dr.Read();
            countlbl.Text = "Total Registered Customers: " + dr[0].ToString();
            obj.closeConnection();
        }
       


        private void customers_Load(object sender, EventArgs e)
        {
            readcustomers();
            readcount();
        }


        private void readcart()
        {
            try
            {
                dr = obj.Query("select * from cartitems where email='" + email + "'");
                dr.Read();
                dt = new DataTable();
                dt.Load(dr);
                
                BindingSource bsource = new BindingSource();

                bsource.DataSource = dt;
                cartdataview.DataSource = bsource;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            obj.closeConnection();
        }

        private void readwishlist()
        {
            try
            {
                dr = obj.Query("select * from wishlist where email='" + email + "'");
                dr.Read();
                dt = new DataTable();
                dt.Load(dr);

                BindingSource bsource = new BindingSource();

                bsource.DataSource = dt;
                wishlistdataview.DataSource = bsource;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            obj.closeConnection();
        }

        private void readorders()
        {
            try
            {
                con = new MySqlConnection();
                con.ConnectionString = "SERVER=182.50.133.78;DATABASE=lalchowk;USER=lalchowk;PASSWORD=Lalchowk@123uzmah";
                con.Open();
                adap = new MySqlDataAdapter("select * from orders where email='" + email + "'", con);
                dt = new DataTable();
                adap.Fill(dt);
                BindingSource bsource = new BindingSource();
                bsource.DataSource = dt;
                ordersdataview.DataSource = bsource;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            obj.closeConnection();
        }

        private void readaddress()
        {
            try
            {

                con = new MySqlConnection();
                con.ConnectionString = "SERVER=182.50.133.78;DATABASE=lalchowk;USER=lalchowk;PASSWORD=Lalchowk@123uzmah";
                con.Open();
                adap = new MySqlDataAdapter("select * from addresses where email='" + email + "'", con);
                dt = new DataTable();
                adap.Fill(dt);
                BindingSource bsource = new BindingSource();
                bsource.DataSource = dt;
                addressdataview.DataSource = bsource;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
                MessageBox.Show(ex.ToString());
            }
        }

        private void customerdataview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.customerdataview.Rows[e.RowIndex];               
                email = row.Cells["email"].Value.ToString();
                emaillbl.Text= row.Cells["mail"].Value.ToString();
                namelbl.Text= row.Cells["name"].Value.ToString();
                contactlbl.Text= row.Cells["contact"].Value.ToString();
                readcart();
                readwishlist();
                readaddress();
                readorders();
            }
        }

        private void emailtxt_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dt1);
            dv.RowFilter = string.Format("mail LIKE '%{0}%'", emailtxt.Text);
            customerdataview.DataSource = dv;
        }



        private void updbtn_Click(object sender, EventArgs e)
        {

        }

        private void banbtn_Click(object sender, EventArgs e)
        {

        }

        private void usertxt_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dt1);
            dv.RowFilter = string.Format("name LIKE '%{0}%'", usertxt.Text);
            customerdataview.DataSource = dv;
        }

        private void notbtn_Click(object sender, EventArgs e)
        {
            notification nf = new notification(email);
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
