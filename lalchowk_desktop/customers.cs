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
        String cmd,s, username;
        bool status, nametxtok, desctxtok, editnametxtok, editdesctxtok, parknametxtok, parkdesctxtok, editparktxtok, editparkdesctxtok, sancnametxtok, sancdesctxtok, editsanctnametxtok, editsancdesctxtok;
        MySqlDataReader dr,dr2,dr3;
        
        private container hp = null;
        DataTable dt;
        public customers(Form hpcopy)
        {
            hp = hpcopy as container;
            InitializeComponent();
        }

        private void readcustomers()
        {
            
            dr = obj.Query("select * from customer");
            
            dt = new DataTable();
            dt.Load(dr);
            BindingSource bsource = new BindingSource();

            bsource.DataSource = dt;
            customerdataview.DataSource = bsource;
            





         /*   dr = obj.Query("select email from customer");
            DataTable dt = new DataTable();
            dt.Columns.Add("email", typeof(String));
            dt.Load(dr);
            obj.closeConnection();
            customerlist.DisplayMember = "email";
            customerlist.DataSource = dt; */
        }

        private void readparks()
        {
            dr2 = obj.Query("select name from wildlife where class='2'");
            DataTable dt = new DataTable();
            dt.Columns.Add("name", typeof(String));
            dt.Load(dr2);
            obj.closeConnection();
            parkbox.DisplayMember = "name";
            parkbox.DataSource = dt;
        }

        private void readsanc()
        {
            dr3 = obj.Query("select name from wildlife where class='1'");
            DataTable dt = new DataTable();
            dt.Columns.Add("name", typeof(String));
            dt.Load(dr3);
            obj.closeConnection();
            sancbox.DisplayMember = "name";
            sancbox.DataSource = dt;
        }

        private void wildlife_Load(object sender, EventArgs e)
        {
            readcustomers();
        }

        private void addanimalsbtn_Click(object sender, EventArgs e)
        {
            animalpnl.Visible = true;
            parkpnl.Visible = false;
            sancpnl.Visible = false;

            readcustomers();


        }

        private void addparksbtn_Click(object sender, EventArgs e)
        {
            animalpnl.Visible = false;
            parkpnl.Visible = true;
            sancpnl.Visible = false;

            readparks();

        }

        private void addsanctuarybtn_Click(object sender, EventArgs e)
        {
            animalpnl.Visible = false;
            parkpnl.Visible = false;
            sancpnl.Visible = true;

            readsanc();
        }

        private void back_Click(object sender, EventArgs e)
        {
            mainform mf = new mainform(hp);
            mf.TopLevel = false;
            hp.mainpnl.Controls.Clear();
            hp.mainpnl.Controls.Add(mf);
            mf.Show();
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

        private void rvmanbtn_Click(object sender, EventArgs e)
        {
        //    cmd = ("delete from animals where name= '" + animalbox.Text + "';");
            obj.nonQuery(cmd);
            MessageBox.Show("selected animal removed sucessfully.");
            readcustomers();
        }

        private void parkbox_SelectedIndexChanged(object sender, EventArgs e)
        {

            dr2 = obj.Query("select * from wildlife where name='" + parkbox.Text + "'");
            dr2.Read();
    
            editparktxt.Text = dr2[1].ToString();
            editparkdesctxt.Text = dr2[2].ToString();
            epdpbox.BackgroundImage =new Bitmap(dr2[3].ToString());
            obj.closeConnection();
            inclblep.Visible = false;
        }

        private void rvmparkbtn_Click(object sender, EventArgs e)
        {
            cmd = ("delete from wildlife where name= '" + parkbox.Text + "';");
            obj.nonQuery(cmd);
            MessageBox.Show("selected park removed sucessfully.");
            readparks();
        }

        private void updateparkbtn_Click(object sender, EventArgs e)
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
          }

        private void parkcancelbtn_Click(object sender, EventArgs e)
        {
            parknametxt.Text = "";
            parkdesctxt.Text = "";
            pdpbox.BackgroundImage = null;
            inclblp.Visible = false;
        }

        private void addsancbtn_Click(object sender, EventArgs e)
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
        }

       

        private void orderbtn_Click(object sender, EventArgs e)
        {
            orderbtn.BackColor = Color.PaleTurquoise;
            cntbtn.BackColor = Color.White;
            
        }

        private void cntbtn_Click(object sender, EventArgs e)
        {
            orderbtn.BackColor = Color.White;
            cntbtn.BackColor = Color.PaleTurquoise;
            
        }

        private void usersearchtxt_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = string.Format("email LIKE '%{0}%'", usersearchtxt.Text);
            customerdataview.DataSource = dv;
        }

        private void customerdataview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.customerdataview.Rows[e.RowIndex];

            }
        }

        private void updbtn_Click(object sender, EventArgs e)
        {
            
        }

        private void banbtn_Click(object sender, EventArgs e)
        {

        }

        private void sanccancelbtn_Click(object sender, EventArgs e)
        {
            sancnametxt.Text = "";
            sancdesctxt.Text = "";
            sdpbox.BackgroundImage = null;
            inclbls.Visible = false;
        }

        private void sancrvmbtn_Click(object sender, EventArgs e)
        {
            cmd = ("delete from wildlife where name= '" + sancbox.Text + "';");
            obj.nonQuery(cmd);
            MessageBox.Show("selected sanctuary removed sucessfully.");
            readsanc();
        }

        private void sancbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            dr3 = obj.Query("select * from wildlife where name='" + sancbox.Text + "'");
            dr3.Read();

            editsanctnametxt.Text = dr3[1].ToString();
            editsancdesctxt.Text = dr3[2].ToString();
            sedpbox.BackgroundImage =new Bitmap(dr3[3].ToString());
            inclblse.Visible = false;
            obj.closeConnection();
        }

        private void updatesancbtn_Click(object sender, EventArgs e)
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

        private void customerlist_SelectedIndexChanged(object sender, EventArgs e)
        {
         //   dr = obj.Query("select * from customer where email='" + customerlist.Text + "'");
            dr.Read();
            username = dr[1].ToString();
            

            obj.closeConnection();
            
        }

        private void sancnametxt_Leave(object sender, EventArgs e)
        {
            if (sancnametxt.Text == "")
                sancnametxtok = false;
            else
                sancnametxtok = true;
            if (sancnametxt.Text.Contains("\\") || sancnametxt.Text.Contains("'"))
            {
                MessageBox.Show("Name cannot contain special characters");
                sancnametxt.Text = "";
                sancnametxt.Focus();
            }
        }

        private void sagree_CheckedChanged(object sender, EventArgs e)
        {
            if (editsanctnametxt.Text == "" && editsancdesctxt.Text == "")
            {
                editsanctnametxtok = false;
                editsancdesctxtok = false;
            }
            else
            {
                editparktxtok = true;
                editparkdesctxtok = true;
            }
        }

        private void sancdesctxt_Leave(object sender, EventArgs e)
        {
            if (sancdesctxt.Text == "")
                sancdesctxtok = false;
            else
                sancdesctxtok = true;
        }

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
        private void pagree_CheckedChanged(object sender, EventArgs e)
        {
            if (editparktxt.Text == "" && editparkdesctxt.Text == "")
            {
                editparktxtok = false;
                editparkdesctxtok = false;
            }
            else
            {
                editparktxtok = true;
                editparkdesctxtok = true;
            }
        }

        private void parkdesctxt_Leave(object sender, EventArgs e)
        {
            if (parkdesctxt.Text == "")
                parkdesctxtok = false;
            else
                parkdesctxtok = true;
        }

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
        private void sanceditcancelbtn_Click(object sender, EventArgs e)
        {
            editsanctnametxt.Text = "";
            editsancdesctxt.Text = "";
            sedpbox.BackgroundImage = null;
            sagree.Checked = false;
            
        }

        private void agree_CheckedChanged(object sender, EventArgs e)
        {
         /*   if (editnametxt.Text == "" && editdesctxt.Text == "")
            {
                editnametxtok = false;
                editdesctxtok = false;
            }
            else
            {
                editnametxtok = true;
                editdesctxtok = true;
            }
            */
        }

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

        private void desctxt_Leave(object sender, EventArgs e)
        {
         /*   if (desctxt.Text == "")
                desctxtok = false;
            else
                desctxtok = true; */
        }

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
        } */

        private void editparkcancelbtn_Click(object sender, EventArgs e)
        {
            editparktxt.Text = "";
            editparkdesctxt.Text = "";
            epdpbox.BackgroundImage = null;
            inclblep.Visible = false;
            
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
        }
    }
}
