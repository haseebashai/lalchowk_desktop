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
    public partial class expenditure : Form
    {
        DBConnect obj = new DBConnect();
        String cmd,s;
        bool status, nametxtok, desctxtok, editnametxtok, editdesctxtok, wordtxtok, meaningtxtok, editwordtxtok, editmeaningtxtok, phrasetxtok, phraseentxtok, editphrasetxtok, editphraseentxtok;
        MySqlDataReader dr, dr2, dr3;
        private container hp = null;
        private mainform mf = null;
        public expenditure(Form mfcopy,Form hpcopy)
        {
            mf = mfcopy as mainform;
            hp = hpcopy as container;

            InitializeComponent();
            readordersplaced();
            readordersdelivered();
            readpurchasecost();
            readshipping();
            readprofit();
            
        }

     /*   private void readfood()
        {
            dr = obj.Query("select name from food");
            DataTable dt = new DataTable();
            dt.Columns.Add("name", typeof(String));
            dt.Load(dr);
            obj.closeConnection();
            foodbox.DisplayMember = "name";
            foodbox.DataSource = dt;
        }

        private void readwords()
        {
            dr2 = obj.Query("select keyword from dictionary");
            DataTable dt = new DataTable();
            dt.Columns.Add("keyword", typeof(String));
            dt.Load(dr2);
            obj.closeConnection();
            wordbox.DisplayMember = "keyword";
            wordbox.DataSource = dt;
        }

        private void readphrases()
        {
            dr3 = obj.Query("select phrases from phrases");
            DataTable dt = new DataTable();
            dt.Columns.Add("phrases", typeof(String));
            dt.Load(dr3);
            obj.closeConnection();
            phrasebox.DisplayMember = "phrases";
            phrasebox.DataSource = dt;
        }

        private void foodbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            dr = obj.Query("select * from food where name='" + foodbox.Text + "'");
            dr.Read();
            editnametxt.Text = dr[1].ToString();
            editdesctxt.Text = dr[2].ToString();
            edpbox.BackgroundImage =new Bitmap(dr[3].ToString());
            obj.closeConnection();
        }

        private void addfoodbtn_Click(object sender, EventArgs e)
        {
            foodpnl.Visible = true;
            wordspnl.Visible = false;
            phrasespnl.Visible = false;

            readfood();
        }

        private void addwordsbtn_Click(object sender, EventArgs e)
        {
            foodpnl.Visible = false;
            wordspnl.Visible = true;
            phrasespnl.Visible = false;

            readwords();
        }

        private void addphrasesbtn_Click(object sender, EventArgs e)
        {
            foodpnl.Visible = false;
            wordspnl.Visible = false;
            phrasespnl.Visible = true;

            readphrases();
        }

        private void addfdbtn_Click(object sender, EventArgs e)
        {
            if (nametxtok && desctxtok && status == true)
            {
                StringBuilder s1 = new StringBuilder(desctxt.Text);
                s1.Replace(@"\", @"\\");
                s1.Replace("'", "\\'");
                cmd = "insert into food (`name`, `description`, `location`) values ('" + nametxt.Text + "', '" + s1 + @"', 'C:\\Vkashmir\\food\\" + nametxt.Text + ".jpg')";
                dpbox.BackgroundImage.Save("C:\\Vkashmir\\food\\" + nametxt.Text + ".jpg");

                obj.nonQuery(cmd);

                MessageBox.Show("New Food item added succesfully!");
                nametxt.Text = "";
                desctxt.Text = "";
                dpbox.BackgroundImage = null;
                readfood();
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
            inclbl.Visible = false;
            dpbox.BackgroundImage = null;


        }

        private void updatefdbtn_Click(object sender, EventArgs e)
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
                        cmd = ("update food set `name`='" + editnametxt.Text + "', `description`='" + s1 + @"', `pic`='C:\\Vkashmir\\food\\" + editnametxt.Text + ".jpg' where `name`='" + foodbox.Text + "';");
                        dpbox.BackgroundImage.Save("C:\\Vkashmir\\food\\" + editnametxt.Text + ".jpg");
                    }
                    else
                    {
                        StringBuilder s1 = new StringBuilder(editdesctxt.Text);
                        s1.Replace(@"\", @"\\");
                        s1.Replace("'", "\\'");
                        cmd = ("update food set `name`='" + editnametxt.Text + "', `description`='" + s1 + "' where `name`='" + foodbox.Text + "';");

                    }
                    obj.nonQuery(cmd);

                    MessageBox.Show("Food item updated succesfully!");
                    editnametxt.Text = "";
                    editdesctxt.Text = "";
                    edpbox.BackgroundImage = null;
                    agree.Checked = false;
                    readfood();
                }
                else
                    inclbl2.Visible = true;
            }
        }

        private void editcancelbtn_Click(object sender, EventArgs e)
        {
            editnametxt.Text = "";
            editdesctxt.Text = "";
            inclbl2.Visible = false;
            edpbox.BackgroundImage = null;
            agree.Checked = false;

            readfood();
        }

        private void rvmfdbtn_Click(object sender, EventArgs e)
        {
            cmd = ("delete from food where name= '" + foodbox.Text + "';");
            obj.nonQuery(cmd);
            MessageBox.Show("selected food item removed sucessfully.");
            readfood();
        }

        private void addwordbtn_Click(object sender, EventArgs e)
        {
            if (wordtxtok && meaningtxtok == true)
            {
                StringBuilder s1 = new StringBuilder(meaningtxt.Text);
                s1.Replace(@"\", @"\\");
                s1.Replace("'", "\\'");
                cmd = "insert into dictionary (`keyword`, `meaning`) values ('" + wordtxt.Text + "', '" + s1 + "')";
                obj.nonQuery(cmd);

                MessageBox.Show("New Word entry added succesfully!");
                wordtxt.Text = "";
                meaningtxt.Text = "";

                readwords();
            }
            else
                inclblw.Visible = true;
        }

        private void wordcancelbtn_Click(object sender, EventArgs e)
        {
            wordtxt.Text = "";
            meaningtxt.Text = "";
            inclblw.Visible = false;

            readwords();
        }

        private void wordbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            dr = obj.Query("select * from dictionary where keyword='" + wordbox.Text + "'");
            dr.Read();
            editwordtxt.Text = dr[1].ToString();
            editmeaningtxt.Text = dr[2].ToString();
            inclblew.Visible = false;
            obj.closeConnection();
        }

        private void updatewordbtn_Click(object sender, EventArgs e)
        {
            if (editwordtxt.Text.Contains("'") || editwordtxt.Text.Contains("\\"))
                MessageBox.Show("Word cannot contain ' & \\");
            else
            {
                if (wagree.Checked && editwordtxtok && editmeaningtxtok == true)
                {
                    StringBuilder s1 = new StringBuilder(editmeaningtxt.Text);
                    s1.Replace(@"\", @"\\");
                    s1.Replace("'", "\\'");
                    cmd = ("update dictionary set `keyword`='" + editwordtxt.Text + "', `meaning`='" + s1 + "' where `keyword`='" + wordbox.Text + "'");
                    obj.nonQuery(cmd);

                    MessageBox.Show("Word entry updated succesfully!");
                    editwordtxt.Text = "";
                    editmeaningtxt.Text = "";
                    wagree.Checked = false;
                    readwords();
                }
                else
                {
                    inclblew.Visible = true;
                }
            }
        }

        private void rvmwordbtn_Click(object sender, EventArgs e)
        {
            cmd = ("delete from dictionary where keyword= '" + wordbox.Text + "';");
            obj.nonQuery(cmd);
            MessageBox.Show("selected Word removed sucessfully.");
            readwords();
        }

        private void addphrasebtn_Click(object sender, EventArgs e)
        {
            if (phrasetxtok && phraseentxtok == true)
            {
                StringBuilder s1 = new StringBuilder(phraseentxt.Text);
                s1.Replace(@"\", @"\\");
                s1.Replace("'", "\\'");
                cmd = "insert into phrases (`phrases`, `meaning`) values ('" + phrasetxt.Text + "', '" + s1 + "')";
                obj.nonQuery(cmd);

                MessageBox.Show("New Phrase added succesfully!");
                phrasetxt.Text = "";
                phraseentxt.Text = "";
                inclblp.Visible = false;
                
                readphrases();
            }
            else
                inclblp.Visible = true;
        }

        private void phrasecancelbtn_Click(object sender, EventArgs e)
        {
            phrasetxt.Text = "";
            phraseentxt.Text = "";
            inclblp.Visible = false;
           
            readphrases();
        }

        private void phrasebox_SelectedIndexChanged(object sender, EventArgs e)
        {
            StringBuilder s1 = new StringBuilder(phrasebox.Text);
            s1.Replace(@"\", @"\\");
            s1.Replace("'", "\\'");
            dr = obj.Query("select * from phrases where phrases='" + s1 + "'");
            dr.Read();
            
            editphrasetxt.Text = dr[1].ToString();
            editphraseentxt.Text = dr[2].ToString();
            inclblep.Visible = false;
            obj.closeConnection();
        }

        private void updatephrasebtn_Click(object sender, EventArgs e)
        {
            if (editphrasetxt.Text.Contains("'") || editphrasetxt.Text.Contains("\\"))
                MessageBox.Show("Phrase cannot contain ' & \\");
            else
            {
                if (pagree.Checked && editphrasetxtok && editphraseentxtok == true)
                {
                    StringBuilder s1 = new StringBuilder(editphraseentxt.Text);
                    s1.Replace(@"\", @"\\");
                    s1.Replace("'", "\\'");
                    cmd = ("update phrases set `phrases`='" + editphrasetxt.Text + "', `meaning`='" + s1 + "' where `phrases`='" + phrasebox.Text + "'");
                    obj.nonQuery(cmd);

                    MessageBox.Show("Phrase updated succesfully!");
                    editphrasetxt.Text = "";
                    editphraseentxt.Text = "";
                    pagree.Checked = false;
                    readphrases();
                }
                else
                {
                    inclblep.Visible = true;
                }
            }
        }

        private void pagree_CheckedChanged(object sender, EventArgs e)
        {

            if (editphrasetxt.Text == "" && editphraseentxt.Text == "")
            {
                editphrasetxtok = false;
                editphraseentxtok = false;
            }
            else
            {
                editphrasetxtok = true;
                editphraseentxtok = true;
            }
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

        private void editwordcancelbtn_Click(object sender, EventArgs e)
        {
            editwordtxt.Text = "";
            editmeaningtxt.Text = "";
            wagree.Checked = false;
            inclblew.Visible = false;
            readwords();
        }

        private void phrasetxt_Leave(object sender, EventArgs e)
        {
            if (phrasetxt.Text == "")
                phrasetxtok = false;
            else
                phrasetxtok = true;
            if (phrasetxt.Text.Contains("\\") || phrasetxt.Text.Contains("'"))
            {
                MessageBox.Show("Phrase cannot contain special characters");
                phrasetxt.Text = "";
                phrasetxt.Focus();
            }
        }

        private void phraseentxt_Leave(object sender, EventArgs e)
        {
            if (phraseentxt.Text == "")
                phraseentxtok = false;
            else
                phraseentxtok = true;
        }

        private void edpbox_Click(object sender, EventArgs e)
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

        private void wagree_CheckedChanged(object sender, EventArgs e)
        {
            if (editwordtxt.Text == "" && editmeaningtxt.Text == "")
            {
                editwordtxtok = false;
                editmeaningtxtok = false;
            }
            else
            {
                editwordtxtok = true;
                editmeaningtxtok = true;
            }
        }

        private void wordtxt_Leave(object sender, EventArgs e)
        {
            if (wordtxt.Text == "")
                wordtxtok = false;
            else
                wordtxtok = true;
            if (wordtxt.Text.Contains("\\") || wordtxt.Text.Contains("'"))
            {
                MessageBox.Show("Word cannot contain special characters");
                wordtxt.Text = "";
                wordtxt.Focus();
            }
        }

        private void meaningtxt_Leave(object sender, EventArgs e)
        {
            if (meaningtxt.Text == "")
                meaningtxtok = false;
            else
                meaningtxtok = true;
        }

        private void editphrasecancelbtn_Click(object sender, EventArgs e)
        {
            editphrasetxt.Text = "";
            editphraseentxt.Text = "";
            pagree.Checked = false;
            readphrases();
        }

        private void rvmphrasebtn_Click(object sender, EventArgs e)
        {
            StringBuilder s1 = new StringBuilder(phrasebox.Text);
            s1.Replace(@"\", @"\\");
            s1.Replace("'", "\\'");
            cmd = ("delete from phrases where phrases= '" + s1 + "';");
            obj.nonQuery(cmd);
            MessageBox.Show("selected Phrase removed sucessfully.");
            editphraseentxt.Text = "";
            editphrasetxt.Text = "";
            readphrases();
        }

        private void nametxt_Leave(object sender, EventArgs e)
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
        }

        private void desctxt_Leave(object sender, EventArgs e)
        {
            if (desctxt.Text == "")
                desctxtok = false;
            else
                desctxtok = true;
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
        } */

        private void readordersdelivered()
        {
            dr = obj.Query("SELECT count(status),sum(amount+shipping) FROM orders where status='delivered'");
            dr.Read();
            ordersdlbl.Text = dr[0].ToString();
            ordersdvlbl.Text = dr[1].ToString();
            obj.closeConnection();
        }

        private void readordersplaced()
        {
            dr = obj.Query("SELECT count(status),sum(amount+shipping) FROM lalchowk.orders where status='placed';");
            dr.Read();
            ordersplbl.Text = dr[0].ToString();
            orderspvlbl.Text = dr[1].ToString();
            obj.closeConnection();
        }


        private void readpurchasecost()
        {
            dr = obj.Query("select sum(dealerprice*quantity) from lalchowk.orderdetails where productid in (SELECT productid FROM lalchowk.orderdetails where orderid in (SELECT orderid FROM lalchowk.orders where status = 'delivered'));");
            dr.Read();
            purlbl.Text = dr[0].ToString();
            
            obj.closeConnection();
        }

        private void readshipping()
        {
            dr = obj.Query("select sum(shipping) from lalchowk.orders where status ='delivered'");
            dr.Read();
            shiplbl.Text = dr[0].ToString();

            obj.closeConnection();
        }

        private void readprofit()
        {
          /*  int a = Int32.Parse(ordersdvlbl.Text);
            int b = Int32.Parse(purlbl.Text);
            int c = Int32.Parse(shiplbl.Text);
            profitlbl.Text = (a-b).ToString(); */
            profitlbl.Text= ((int.Parse(ordersdvlbl.Text) - int.Parse(purlbl.Text)) - int.Parse(shiplbl.Text)).ToString();
        }

        private void culture_Load(object sender, EventArgs e)
        {
            
        }

        private void orderslbl_Click(object sender, EventArgs e)
        {
            ordersdetails od = new ordersdetails(mf);
            od.TopLevel = false;
            mf.cntpnl.Controls.Clear();
           
            od.orderslbl.Text = "Orders Placed";
            od.readordersplaced();
            mf.cntpnl.Controls.Add(od);
            od.Show();
        }
        private void orderslbl2_Click(object sender, EventArgs e)
        {
            ordersdetails od = new ordersdetails(mf);
            od.TopLevel = false;
            mf.cntpnl.Controls.Clear();
            od.readordersdelivered();
            mf.cntpnl.Controls.Add(od);
            od.Show();
        }

        private void costlbl_Click(object sender, EventArgs e)
        {
            ordersdetails od = new ordersdetails(mf);
            od.TopLevel = false;
            mf.cntpnl.Controls.Clear();
            od.orderslbl.Text = "Purchased Products Cost";
            od.readpurchasecost();
            mf.cntpnl.Controls.Add(od);
            od.Show();
        }
        private void profitlbl2_Click(object sender, EventArgs e)
        {
            ordersdetails od = new ordersdetails(mf);
            od.TopLevel = false;
            mf.cntpnl.Controls.Clear();
            od.orderslbl.Text = "Profit Earned from these Orders";
            od.readprofit();
            mf.cntpnl.Controls.Add(od);
            od.Show();
        }
        private void ship_Click(object sender, EventArgs e)
        {
            ordersdetails od = new ordersdetails(mf);
            od.TopLevel = false;
            mf.cntpnl.Controls.Clear();
            od.orderslbl.Text = "Shipping Charges";
            od.readshipping();
            mf.cntpnl.Controls.Add(od);
            od.Show();
        }
    }
}
