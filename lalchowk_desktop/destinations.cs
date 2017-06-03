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
    public partial class destinations : Form
    {
        DBConnect obj = new DBConnect();
        String cmd,s;
        int exp;
        bool status, nametxtok, desctxtok, chkok, editnametxtok, editdesctxtok, chkok2, status2;
        MySqlDataReader dr;

        private container hp = null;
        public destinations(Form hpcopy)
        {
            hp = hpcopy as container;
            InitializeComponent();
        }

        private void destinations_Load(object sender, EventArgs e)
        {

        }

        private void back_Click(object sender, EventArgs e)
        {
            mainform mf = new mainform(hp);
            mf.TopLevel = false;
            hp.mainpnl.Controls.Clear();
            hp.mainpnl.Controls.Add(mf);
            mf.Show();
        }

        private void addplbtn_Click(object sender, EventArgs e)
        {
            if (hotspottxt.Text.Contains("\\") || hotspottxt.Text.Contains("'") || hoteltxt.Text.Contains("\\") || hoteltxt.Text.Contains("'"))
                MessageBox.Show("Details cannot contain ' & \\ ");

            if (nametxtok && desctxtok && chkok && status)
            {
                StringBuilder s1 = new StringBuilder(desctxt.Text);
                s1.Replace(@"\", @"\\");
                s1.Replace("'", "\\'");
                   
                cmd = "insert into places (`name`, `description`, `location`, `explored`, `hotspot`, `hotels`) values ('" + nametxt.Text + "', '" + s1 + @"', 'C:\\Vkashmir\\places\\"+nametxt.Text+ ".jpg', '" + exp + "', '" + hotspottxt.Text+"', '" + hoteltxt.Text +"')";
                dpbox.BackgroundImage.Save("C:\\Vkashmir\\places\\" + nametxt.Text + ".jpg");
                obj.nonQuery(cmd);
                

                MessageBox.Show("New Place added succesfully!");
                nametxt.Text = "";
                desctxt.Text = "";
                exbtn.Checked = false;
                unexbtn.Checked = false;
                inclbl.Visible = false;
                dpbox.BackgroundImage = null;
            }
            else
            {
                inclbl.Visible = true;
            }

        }

        private void exbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (exbtn.Checked)
            {
                exp = 1;
                chkok = true;
            }
            else
                chkok = false;
        }

        private void unexbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (unexbtn.Checked)
            {
                exp = 0;
                chkok = true;
            }
            else
                chkok = false;
        }
        private void readplaces()
        {
            dr = obj.Query("select name from places");
            DataTable dt = new DataTable();
            dt.Columns.Add("name", typeof(String));
            dt.Load(dr);
            obj.closeConnection();
            selectbox.DisplayMember = "name";
            selectbox.DataSource = dt;
            
        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            addpnl.Visible = false;
            editpnl.Visible = true;
            removepnl.Visible = false;

            readplaces();
            

           
        }

        private void addbtn_Click(object sender, EventArgs e)
        {

            editpnl.Visible = false;
            removepnl.Visible = false;
            addpnl.Visible = true;
        }

        private void readplaces2()
        {
            dr = obj.Query("select name from places");
            DataTable dt = new DataTable();
            dt.Columns.Add("name", typeof(String));
            dt.Load(dr);
            obj.closeConnection();
            selectbox2.DisplayMember = "name";
            selectbox2.DataSource = dt;
        }
        private void removebtn_Click(object sender, EventArgs e)
        {
            editpnl.Visible = false;
            addpnl.Visible = false;
            removepnl.Visible = true;

            readplaces2();

            

        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            nametxt.Text = "";
            desctxt.Text = "";
            hotspottxt.Text = "";
            hoteltxt.Text = "";
            dpbox.BackgroundImage = null;
            exbtn.Checked = false;
            unexbtn.Checked = false;

        }

        private void selectbox_SelectedIndexChanged(object sender, EventArgs e)
        {

            dr = obj.Query("select * from places where name='"+selectbox.Text+"'");
            dr.Read();
            editpanel.Visible = true;
            editnametxt.Text = dr[1].ToString();
            editdesctxt.Text = dr[2].ToString();
            edpbox.BackgroundImage = new Bitmap(dr[3].ToString());
            edithottxt.Text = dr[5].ToString();
            edithoteltxt.Text = dr[6].ToString();

                exp = Convert.ToInt32(dr[4]);
            if (exp == 1)
            {
                exbtn1.Checked = true;
                unexbtn1.Checked = false;
            }
            else
            {
                unexbtn1.Checked = true;
                exbtn1.Checked = false;
            }

            
            obj.closeConnection(); 
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
           
            if (editnametxt.Text.Contains("'") || editnametxt.Text.Contains("\\") || edithottxt.Text.Contains("'") || edithottxt.Text.Contains("\\") || edithoteltxt.Text.Contains("'") || edithoteltxt.Text.Contains("\\"))
                MessageBox.Show("Details cannot contain ' & \\");
            else
            {
                if (agree.Checked && editnametxtok && editdesctxtok && chkok2 == true)
                {
                    if (status2 == true)
                    {
                        StringBuilder s1 = new StringBuilder(editdesctxt.Text);
                        s1.Replace(@"\", @"\\");
                        s1.Replace("'", "\\'");
                        cmd = ("update places set `name`='" + editnametxt.Text + "', `description`='" + s1 + @"', `location`='C:\\Vkashmir\\places\\" + editnametxt.Text + ".jpg', `explored`='" + exp + "', `hotspot`='"+ edithottxt.Text+"', `hotels`='"+edithoteltxt.Text+"' where `name`='" + selectbox.Text + "';");
                        edpbox.BackgroundImage.Save("C:\\Vkashmir\\places\\" + editnametxt.Text + ".jpg");

                    }
                    else
                    {
                        StringBuilder s1 = new StringBuilder(editdesctxt.Text);
                        s1.Replace(@"\", @"\\");
                        s1.Replace("'", "\\'");
                        cmd = ("update places set `name`='" + editnametxt.Text + "', `description`='" + s1 + "', `explored`='" + exp + "', `hotspot`='" + edithottxt.Text + "', `hotels`='" + edithoteltxt.Text + "' where `name`='" + selectbox.Text + "';");
                    }

                    MessageBox.Show("Details updated for the selected place.");
                    editnametxt.Text = "";
                    editdesctxt.Text = "";
                    edithottxt.Text = "";
                    edithoteltxt.Text = "";
                    exbtn1.Checked = false;
                    unexbtn1.Checked = false;
                    inclbl2.Visible = false;
                    edpbox.BackgroundImage = null;
                    agree.Checked = false;
                    obj.nonQuery(cmd);
                }
                else
                {
                    inclbl2.Visible = true;
                }

            }
        }

        

        private void exbtn1_CheckedChanged(object sender, EventArgs e)
        {
            if (exbtn1.Checked)
            {
                exp = 1;
                chkok2 = true;
            }
            else
                chkok2 = false;
        }

        private void unexbtn1_CheckedChanged(object sender, EventArgs e)
        {

           if (unexbtn1.Checked)
           {
                 exp = 0;
                 chkok2 = true;
           }
           else
                 chkok2 = false;
        }

        private void agree_CheckedChanged(object sender, EventArgs e)
        {
            if (editnametxt.Text == "" && editdesctxt.Text == "")
            {
                editnametxtok = false;
                editdesctxtok = false;
            }
            else
            {
                editnametxtok = true;
                editdesctxtok = true;
            }
            

        }

        private void editnametxt_Leave(object sender, EventArgs e)
        {
            if (editnametxt.Text.Contains("\\") || editnametxt.Text.Contains("'"))
            {
                MessageBox.Show("Name cannot contain special characters");
                editnametxt.Text = "";
                editnametxt.Focus();
            }

        }

        

        private void editcancelbtn_Click(object sender, EventArgs e)
        {
            editnametxt.Text = "";
            editdesctxt.Text = "";
            edithoteltxt.Text = "";
            edithottxt.Text = "";
            exbtn1.Checked = false;
            unexbtn1.Checked = false;
        }

        private void nametxt_Leave(object sender, EventArgs e)
        {
            if (nametxt.Text == "")
                nametxtok = false;
            else
                nametxtok = true;
            if (nametxt.Text.Contains("\\")|| nametxt.Text.Contains("'"))
            {
                MessageBox.Show("Name cannot contain special characters");
                nametxt.Text = "";
                nametxt.Focus();
            }

        }

        private void desctxt_Leave(object sender, EventArgs e)
        {
            if (desctxt.Text == "")
                desctxtok = false;
            else
                desctxtok = true;
        }

        private void edpbox_Click(object sender, EventArgs e)
        {

            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                s = openFileDialog2.FileName;
                Image myimage = new Bitmap(s);
                edpbox.BackgroundImage = myimage;
                edpbox.BackgroundImageLayout = ImageLayout.Stretch;
                status2 = true;

            }
        }

        private void selectbox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            dr = obj.Query("select * from places where name='" + selectbox2.Text + "'");
            dr.Read();
            placelbl.Text = dr[1].ToString();
            picbox.BackgroundImage= new Bitmap(dr[3].ToString());
            rvmpnl.Visible = true;
            


            obj.closeConnection();
        }
        private void rmvbtn_Click(object sender, EventArgs e)
        {
            cmd = ("delete from places where name= '" + selectbox2.Text + "';");
            obj.nonQuery(cmd);
            MessageBox.Show("selected place removed sucessfully.");
            readplaces2();
            rvmpnl.Visible = false;

            

        }

        private void rvmcancel_Click(object sender, EventArgs e)
        {
            rvmpnl.Visible = false;

        }

        private void dpbox_Click(object sender, EventArgs e)
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
    }
}
