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
using System.IO;
using System.Net;

namespace Veiled_Kashmir_Admin_Panel
{
    public partial class addproducts : Form
    {
        bool fnameok = true, lnameok = true, emailok = true, passwordok = true, confirmok = true, phoneok = true, dobok = true;
        DBConnect obj = new DBConnect();

       

        MySqlDataReader dr,dr2;

        string filename, fileaddress, categoryid;


        private container hp = null;
        private mainform mf = null;
        string cmd;


        public addproducts(Form hpcopy, Form mfcopy)
        {
            hp = hpcopy as container;
            mf = mfcopy as mainform;

            InitializeComponent();
            readfirst();
            readsuppliers();


      /*      
            String temp = dr[6].ToString();            
            daytxt.Text = temp.Substring(0, 2);
            montxt.Text = temp.Substring(3, 2);
            yeartxt.Text = temp.Substring(6, 4);
             */
        }
        private void readfirst()
        {
            dr = obj.Query("select * from firstcategory");            
            DataTable dt = new DataTable();          
            dt.Columns.Add("categoryname", typeof(String));            
            dt.Load(dr);
            obj.closeConnection();
            firstcat.DisplayMember = "categoryname";           
            firstcat.DataSource = dt;
        }

        private void supplierlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            dr = obj.Query("select name from suppliers where supplierid='" + supplierlist.Text + "'");
            dr.Read();    
            supnametxt.Text = dr[0].ToString();            
            obj.closeConnection();
        }

        private void readsecond()
        {
            dr = obj.Query("select categoryname from secondcategory where firstcategoryid = '" + idlbl.Text +"'");
            DataTable dt = new DataTable();
            dt.Columns.Add("categoryname", typeof(String));
            dt.Load(dr);
            obj.closeConnection();
            seccat.DisplayMember = "categoryname";
            seccat.DataSource = dt;
        }

      

        private void readthird()
        {
            dr = obj.Query("select categoryname from thirdcategory where secondcategoryid = '" + id2lbl.Text + "'");
            DataTable dt = new DataTable();
            dt.Columns.Add("categoryname", typeof(String));
            dt.Load(dr);
            obj.closeConnection();
            thirdcat.DisplayMember = "categoryname";
            thirdcat.DataSource = dt;
        }

        private void pic1_Click(object sender, EventArgs e)
        {
            if (picdialog.ShowDialog() == DialogResult.OK)
            {
                fileaddress = picdialog.FileName;
                filename = picdialog.SafeFileName;
                Image myimage = new Bitmap(fileaddress);
                pic1.BackgroundImage = myimage;
                pic1.BackgroundImageLayout = ImageLayout.Stretch;               
            }
        }

        private void readsuppliers()
        {
            dr = obj.Query("select distinct supplierid from suppliers");
            DataTable dt = new DataTable();
            dt.Columns.Add("supplierid", typeof(String));
            dt.Load(dr);
            obj.closeConnection();
            supplierlist.DisplayMember = "supplierid";
            supplierlist.DataSource = dt;
        }

        private void clearall()
        {
            nametxt.Text = "";
            desctxt.Text = "";
            brandtxt.Text = "";
            colourtxt.Text = "";
            sizetxt.Text = "";
            stocktxt.Text = "";
            dname1.Text = "";
            dname1txt.Text = "";
            dname2.Text = "";
            dname2txt.Text = "";
            dname3.Text = "";
            dname3txt.Text = "";
            dname4.Text = "";
            dname4txt.Text = "";
            dname5.Text = "";
            dname5txt.Text = "";
            gidtxt.Text = "";
            mrptxt.Text = "";
            pricetxt.Text = "";
            discounttxt.Text = "";

        }
        private void cancelbtn_Click(object sender, EventArgs e)
        {
            clearall();
            pic1.BackgroundImage = null;

        }


        private void readcategory()
        {
            if (id3lbl.Text == "0")
                catlbl.Text = id2lbl.Text;
            else
            {
                catlbl.Text = id3lbl.Text;
                
            }
        }

        private void fillbtn_Click(object sender, EventArgs e)
        {
            readdetails();
        }

        

        private void catlbl_TextChanged(object sender, EventArgs e)
        {
           //  MessageBox.Show(catlbl.Text.ToString());
            //   readdetails();
           
        }

        private void profile_Load(object sender, EventArgs e)
        {
           

        }

        private void readdetails()
        {
            dr = obj.Query("select detailname1,detailname2,detailname3,detailname4,detailname5 from products where categoryid='"+catlbl.Text+"'");
            dr.Read();
            
            dname1txt.Text = dr["detailname1"].ToString();
            dname2txt.Text = dr["detailname2"].ToString();
            dname3txt.Text = dr["detailname3"].ToString();
            dname4txt.Text = dr["detailname4"].ToString();
            dname5txt.Text = dr["detailname5"].ToString();
            obj.closeConnection();

        }

        private void thirdcat_SelectedIndexChanged(object sender, EventArgs e)
        {
            dr = obj.Query("select categoryid from thirdcategory where categoryname='" + thirdcat.Text + "' && secondcategoryid='" + id2lbl.Text + "'");
            if (dr.Read())
            {
                id3lbl.Text = dr[0].ToString();
                      
            }
           else 
            {
                id3lbl.Text = "0";
            }
            obj.closeConnection();
            readcategory();
            
        }

        private void seccat_SelectedIndexChanged(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder(seccat.Text);
            sb.Replace("'", "\\'");
            dr = obj.Query("select categoryid from secondcategory where categoryname='" + sb + "' && firstcategoryid='" +idlbl.Text+"'");
            if (dr.Read())
            {
                id2lbl.Text = dr[0].ToString();
            }
            obj.closeConnection();
            thirdcat.DataSource = null;
            foreach (DataRowView items in thirdcat.Items)
            {
                thirdcat.Items.Remove(items);                
            }
            readthird();
            readcategory();
           

        }

        private void firstcat_SelectedIndexChanged(object sender, EventArgs e)
        {

            dr = obj.Query("select categoryid from firstcategory where categoryname='" + firstcat.Text + "'");
            dr.Read();
            idlbl.Text = dr[0].ToString();
            obj.closeConnection();
            seccat.DataSource = null;
            foreach (DataRowView items in seccat.Items)
                seccat.Items.Remove(items);
            readsecond();
            

        }

        public static void UploadFileToFtp(string url, string filePath)
        {
            try
            {
                var fileName = Path.GetFileName(filePath);
                var request = (FtpWebRequest)WebRequest.Create(url + fileName);

                request.Method = WebRequestMethods.Ftp.UploadFile;                
                request.Credentials = new NetworkCredential("lalchowk", "Lalchowk@123");
                request.UsePassive = true;
                request.UseBinary = true;
                request.KeepAlive = true;

                using (var fileStream = File.OpenRead(filePath))
                {
                    using (var requestStream = request.GetRequestStream())
                    {
                        fileStream.CopyTo(requestStream);
                        requestStream.Close();
                    }
                }

                var response = (FtpWebResponse)request.GetResponse();
                MessageBox.Show("Upload done: " + response.StatusDescription, "Upload Successful.");

                response.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        private void picbtn_Click(object sender, EventArgs e)
        {
           

        }

        private void addbtn_Click(object sender, EventArgs e)
        {
           
            /*    try
                {
                    UploadFileToFtp("ftp://182.50.151.83/lalchowk/pictures/", fileaddress);
                }
                catch (WebException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    pic1.BackgroundImage = null;
                }
                */
            cmd = "insert into products (`productid`, `supplierid`, `productname`, `groupid`,`categoryid`,`color`, `mrp`, `price`, `discount`, `stock`, `description`, `detailname1`, `detailname2`, `detailname3`, `detailname4`, `detailname5`, `detail1`, `detail2`, `detail3`, `detail4`, `detail5`,`brand`,`size`,`picture`) " +
                  "values ('"+pidtxt.Text+"','" + supplierlist.Text + "', '" + nametxt.Text + "','"+gidtxt.Text+"', '" + catlbl.Text +"','"+ colourtxt.Text + "','"+mrptxt.Text+ "','" +pricetxt.Text+ "','" +discounttxt.Text+ "','" + stocktxt.Text + "','" + desctxt.Text + "','" + dname1txt.Text+ "','" + dname2txt.Text + "','" + dname3txt.Text + "','" + dname4txt.Text + "','" + dname5txt.Text + "','" + dname1.Text + "','" + dname2.Text + "','" + dname3.Text + "','" + dname4.Text + "','" + dname5.Text + "','" + brandtxt.Text + "','" + sizetxt.Text + @"','" + filename +"')";
            obj.nonQuery(cmd);

            
         //   int productid = obj.Count("SELECT LAST_INSERT_ID()");
          
            
            
            obj.closeConnection();


            


         //   addpictures adp = new addpictures(gidtxt.Text);
         //   adp.ShowDialog();
            clearall();


        }


        /*    private void fnametxt_Leave(object sender, EventArgs e)
              {
                  flbl.Visible = false;
                  fnameok = true;
                  if (Regex.IsMatch(fnametxt.Text, @"[0-9]"))
                  {
                      flbl.Text = "That can't possibly be your first name";
                      flbl.Visible = true;
                      fnameok = false;
                  }
                  if (fnametxt.Text.Length > 25 || fnametxt.Text.Length < 2)

                  {
                      flbl.Text = "Thats not even a name";
                      flbl.Visible = true;
                      fnameok = false;
                  }
                  if (fnametxt.Text.Contains("'"))
                  {

                      flbl.Text = "Don't try to trick me";
                      flbl.Visible = true;
                      fnameok = false;
                  }

              }

              private void lnametxt_Leave(object sender, EventArgs e)
              {
                  llbl.Visible = false;
                  lnameok = true;
                  if (Regex.IsMatch(lnametxt.Text, @"[0-9]"))
                  {
                      llbl.Text = "Write your real last name";
                      llbl.Visible = true;
                      lnameok = false;
                  }
                  if (lnametxt.Text.Length > 25 || lnametxt.Text.Length < 2)

                  {
                      llbl.Text = "I don't believe it";
                      llbl.Visible = true;
                      lnameok = false;
                  }
                  if (lnametxt.Text.Contains("'"))
                  {

                      llbl.Text = "Enter a valid last name";
                      llbl.Visible = true;
                      lnameok = false;
                  }
              }



              private void updatebtn_Click(object sender, EventArgs e)
              {

                  if (fnameok && lnameok && emailok && passwordok && confirmok && phoneok && dobok == true)
                  {
                      String cmd;
                      inclbl.Visible = false;
                      cmd = "Update admin set fname='" + fnametxt.Text + "',lname='" + lnametxt.Text + "',email='" + emailtxt.Text + "',password='" + pwdtxt.Text + "',contact='" + phonetxt.Text + "',DOB='" + yeartxt.Text + "//" + montxt.Text + "//" + daytxt.Text + "' where username='" + userinfo.username + "';";
                      obj.nonQuery(cmd);
                      MessageBox.Show("Details Successfully Updated.");

                       }
                  else
                            {
                                  inclbl.Visible = true;
                            } 
                      }



              private void daytxt_Leave(object sender, EventArgs e)
              {
                  dlbl.Visible = false;
                  dobok = true;
                  DateTime dt;
                  if (!DateTime.TryParse(daytxt.Text + "/" + montxt.Text + "/" + yeartxt.Text, new System.Globalization.CultureInfo("en-GB"), System.Globalization.DateTimeStyles.None, out dt))
                  {
                      dlbl.Visible = true;
                      dobok = false;
                  }
                  if (dt > System.DateTime.Today)
                  {
                      dlbl.Visible = true;
                      dobok = false;
                  }
              }

              private void cancelbtn_Click(object sender, EventArgs e)
              {
                  mainform mf = new mainform(hp);
                  mf.TopLevel = false;
                  hp.mainpnl.Controls.Clear();
                  hp.mainpnl.Controls.Add(mf);
                  mf.Show();
              }



              private void montxt_Leave(object sender, EventArgs e)
              {
                  dlbl.Visible = false;
                  dobok = true;
                  DateTime dt;
                  if (!DateTime.TryParse(daytxt.Text + "/" + montxt.Text + "/" + yeartxt.Text, new System.Globalization.CultureInfo("en-GB"), System.Globalization.DateTimeStyles.None, out dt))
                  {
                      dlbl.Visible = true;
                      dobok = false;
                  }
                  if (dt > System.DateTime.Today)
                  {
                      dlbl.Visible = true;
                      dobok = false;
                  }
              }

              private void yeartxt_Leave(object sender, EventArgs e)
              {
                  dlbl.Visible = false;
                  dobok = true;
                  DateTime dt;
                  if (!DateTime.TryParse(daytxt.Text + "/" + montxt.Text + "/" + yeartxt.Text, new System.Globalization.CultureInfo("en-GB"), System.Globalization.DateTimeStyles.None, out dt))
                  {
                      dlbl.Visible = true;
                      dobok = false;
                  }
                  if (dt > System.DateTime.Today)
                  {
                      dlbl.Visible = true;
                      dobok = false;
                  }
              }

              private void pwdtxt_Leave(object sender, EventArgs e)
              {
                  passlbl.Visible = false;
                  passwordok = true;
                  if (!Regex.IsMatch(pwdtxt.Text, @"(?!^[0-9]*$)(?!^[a-zA-Z]*$)^(.{8,15})$"))
                  {

                      passlbl.Visible = true;
                      passwordok = false;
                  }

                  if (!pwdtxt.Text.Equals(confirmtxt.Text))

                  {
                      if (!confirmtxt.Text.Equals(""))
                      {
                          confirmlbl.Visible = true;
                          confirmok = false;
                      }
                  }
                  else
                  {
                      confirmlbl.Visible = false;
                      confirmok = true;
                  }
                  if (pwdtxt.Text.Contains("'"))
                  {

                      passlbl.Visible = true;
                      passwordok = false;
                  }
              }

              private void confirmtxt_Leave(object sender, EventArgs e)
              {
                  confirmlbl.Visible = false;
                  confirmok = true;
                  if (!pwdtxt.Text.Equals(confirmtxt.Text))
                  {
                      confirmlbl.Visible = true;
                      confirmok = false;
                  }
              }

              private void phonetxt_Leave(object sender, EventArgs e)
              {
                  plbl.Visible = false;
                  phoneok = true;
                  if (!Regex.IsMatch(phonetxt.Text, @"^[0-9]{10}$"))
                  {
                      plbl.Text = "I won't call, I promise";
                      plbl.Visible = true;
                      phoneok = false;
                  }
              }


              private void emailtxt_Leave(object sender, EventArgs e)
              {
                  elbl.Visible = false;
                  emailok = true;
                  if (!Regex.IsMatch(emailtxt.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,4})+)$"))
                  {

                      elbl.Visible = true;
                      emailok = false;
                  }
                  else
                  {
                      int i = obj.Count("Select Count(*) from admin where email='" + emailtxt.Text + "';");
                      if (i != 0)
                      {
                          dr = obj.Query("Select * from admin where email='" + emailtxt.Text + "';");
                          dr.Read();
                          if (!dr[0].ToString().Equals(userinfo.username))
                          {
                              elbl.Text = "Email already exists";
                              elbl.Visible = true;
                              emailok = false;
                          }
                          obj.closeConnection();
                      }
                  }
              } */
    }
}
