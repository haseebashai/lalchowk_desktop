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
    public partial class usedbook : Form
    {

        MySqlDataAdapter adap,adap1;
        DataTable dt,dt2,dt3;
        MySqlConnection con = new MySqlConnection("SERVER=182.50.133.78;DATABASE=lalchowk;USER=lalchowk;PASSWORD=Lalchowk@123uzmah;Convert Zero Datetime=True");
        DBConnect obj = new DBConnect();
        MySqlDataReader dr;
        private dialogcontainer dg = null;
        BindingSource bsource,bsource2,bsource3;
        PictureBox loading = new PictureBox();


        public usedbook(Form dgcopy)
        {
            dg = dgcopy as dialogcontainer;
            InitializeComponent();
            BackgroundWorker load = new BackgroundWorker();
            load.RunWorkerCompleted += Load_RunWorkerCompleted;
            load.DoWork += Load_DoWork;
            load.RunWorkerAsync();
        }

        private void Load_DoWork(object sender, DoWorkEventArgs e)
        {
            readreqs();
        }

        private void Load_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            loading.Visible = false;
            formlbl.Text = "Used Books Section";
            selldataview.DataSource = bsource;
            selldataview.Visible = true;
            pnl1.Visible = true;
        }

        public void loadingnormal()
        {
            formlbl.Text = "Loading";
            formlbl.Visible = true;

            loading = new PictureBox()
            {
                Image = Properties.Resources.loading,
                Size = new Size(40, 30),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Location = new Point(76, 0)
            };
            this.Controls.Add(loading);
        }

        public void readreqs()
        {
            try
            {
                adap = new MySqlDataAdapter("select * from sellbookrequests order by id desc", con);
                dt = new DataTable();
                adap.Fill(dt);
                bsource = new BindingSource();
                bsource.DataSource = dt;
            }
            catch (Exception ex)
            {
                try {
                    con.Close();
                    MessageBox.Show(ex.Message.ToString(), "Error!");
                }catch { }
            }
        }

        string id, email;

        private void temailbtn_Click(object sender, EventArgs e)
        {
            temailbtn.Enabled = false;
            BackgroundWorker trueemail = new BackgroundWorker();
            trueemail.DoWork += Trueemail_DoWork;
            trueemail.RunWorkerCompleted += Trueemail_RunWorkerCompleted;
            trueemail.RunWorkerAsync();
        }
        private void Trueemail_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {


            try
            {
                string mail = (string)e.Result;
                emailtxt.Text = mail;
                temailbtn.Enabled = true;
            }
            catch { }
        }

        private void Trueemail_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                dr = obj.Query("select mail from customer where email='" + email + "'");
                dr.Read();
                string temail = dr[0].ToString();
                e.Result = temail;
                obj.closeConnection();
            }
            catch { obj.closeConnection(); temailbtn.Enabled = true; }
        }

        private void smsbtn_Click(object sender, EventArgs e)
        {
            dialogcontainer dg = new dialogcontainer();
            sendsms sms = new sendsms(contxt.Text);
            sms.TopLevel = false;
            dg.dialogpnl.Controls.Add(sms);
            dg.lbl.Text = "Send SMS";
            dg.Text = "Send SMS";
            dg.Size = new Size(800, 600);
            sms.numbertxt.Font = new Font("MS Sans Serif", 9, FontStyle.Regular);
            dg.Show();
            sms.Show();
        }

        private void pbtn_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string cmd = "update sellbookrequests set processed='1' where id='" + id + "'";
                obj.nonQuery(cmd);
                con.Close();
                Cursor = Cursors.Arrow;
                MessageBox.Show("Updated.");
                dpnl.Visible = false;
                readreqs();
                selldataview.DataSource = bsource;

            }
            catch { Cursor = Cursors.Arrow; }
        }

        private void reqbtn_Click(object sender, EventArgs e)
        {
            flag = false;
            loadingnormal();
            selldataview.Visible = false;
            dpnl.Visible = false;
            dpnl2.Visible =false;
            booklistview.Visible = false;
            uppnl.Visible = false;
            updatebtn.Visible = false;
            changebtn.Visible = false;
            countlbl.Visible = false;

            reqbtn.Enabled = false;
            sellerbtn.Enabled = false;
            upbookbtn.Enabled = false;
            BackgroundWorker reqs = new BackgroundWorker();
            reqs.DoWork += (o, a) =>
            {
                readreqs();

            };

            reqs.RunWorkerCompleted += (o, b) =>
            {
                loading.Visible = false;
                formlbl.Text = "Used Books Section";
                selldataview.DataSource = bsource;
                selldataview.Visible = true;
                reqbtn.Enabled = true;
                sellerbtn.Enabled = true;
                upbookbtn.Enabled = true;
            };

            reqs.RunWorkerAsync();
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            try {
                string cmd = "insert into booksellers (`name`,`phone1`,`phone2`,`address`,`additional`)values('"+snametxt.Text+"','"+scontacttxt.Text+"','"+salttxt.Text+"','"+saddtxt.Text+"','"+sadditxt.Text+"')";
                obj.nonQuery(cmd);
                obj.closeConnection();

                MessageBox.Show("Seller added.", "Success");
                snametxt.Text = ""; scontacttxt.Text = "";salttxt.Text = "";saddtxt.Text = "";sadditxt.Text = "";

                Cursor = Cursors.WaitCursor;
                readacc();
                selldataview.DataSource = bsource2;
                countlbl.Visible = false;
                Cursor = Cursors.Arrow;
            }
            catch(Exception ex) { obj.closeConnection(); MessageBox.Show(ex.Message.ToString()); }
        }

        private void readacc()
        {
            try
            {
                adap = new MySqlDataAdapter("select * from booksellers order by sellerid desc", con);
                dt2 = new DataTable();
                adap.Fill(dt2);
                bsource2 = new BindingSource();
                bsource2.DataSource = dt2;
            }
            catch (Exception ex)
            {
                try
                {
                    con.Close();
                    MessageBox.Show(ex.Message.ToString(), "Error!");
                }catch { }
             }


        }

        private void sellerbtn_Click(object sender, EventArgs e)
        {
            flag = true;
            loadingnormal();
            selldataview.Visible = false;
            dpnl.Visible = false;
            dpnl2.Visible = false;
            booklistview.Visible = false;
            uppnl.Visible = false;
            countlbl.Visible = false;
            changebtn.Visible = false;
            updatebtn.Visible = false;

            reqbtn.Enabled = false;
            sellerbtn.Enabled = false;
            upbookbtn.Enabled = false;
            BackgroundWorker sellers = new BackgroundWorker();
            sellers.DoWork += (o, a)=>
            {
                readacc();

            };

            sellers.RunWorkerCompleted += (o, b) => 
            {
                loading.Visible = false;
                formlbl.Text = "Used Books Section";
                selldataview.DataSource = bsource2;
                selldataview.Visible = true;
                dpnl2.Visible = true;
                reqbtn.Enabled = true;
                sellerbtn.Enabled = true;
                upbookbtn.Enabled = true;
            };

            sellers.RunWorkerAsync();
           
        }

        private void upbookbtn_Click(object sender, EventArgs e)
        {
            uppnl.Visible = true;
            loadingnormal();
            selldataview.Visible = false;
            changebtn.Visible = false;
            countlbl.Visible = false;
            reqbtn.Enabled = false;
            sellerbtn.Enabled = false;
            upbookbtn.Enabled = false;

            statusbox.DisplayMember = "Text";
            var items = new[]
            {
                new {Text="Processing"},
                new {Text ="Received|Listed"},
                new {Text="NotReceived|Listed"},
                 new {Text="Sold"},
               

            };
            statusbox.DataSource = items;

            BackgroundWorker sellers = new BackgroundWorker();
            sellers.DoWork += (o, a) => 
            {
                dr = obj.Query("select distinct concat(sellerid,':  ',name) as name from booksellers");
                DataTable dt = new DataTable();
                dt.Columns.Add("name", typeof(String));
                dt.Load(dr);
                obj.closeConnection();
                sellerbox.DataSource = dt;

            };
            sellers.RunWorkerCompleted += (o, b) => 
            {
                loading.Visible = false;
                formlbl.Text = "Used Books Section";
                sellerbox.DisplayMember = "name";
                reqbtn.Enabled = true;
                sellerbtn.Enabled = true;
                upbookbtn.Enabled = true;
            };
            sellers.RunWorkerAsync();

        }

        private void getpidbtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                dr = obj.Query("select productid from products order by productid desc limit 1");

                //     dr = obj.Query("select MAX(productid) from products");
                dr.Read();
                int id = int.Parse(dr[0].ToString()) + 1;
                obj.closeConnection();
                pidtxt.Text = id.ToString();
            }
            catch { obj.closeConnection(); }
            Cursor = Cursors.Arrow;
        }

        private void inclbl_Click(object sender, EventArgs e)
        {
            try
            {
                if (pidtxt.Text == "")
                {
                    Focus();
                }
                else
                {
                    int inc = int.Parse(pidtxt.Text) + 1;
                    pidtxt.Text = inc.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Enter ID first", "Error!");
            }
        }

        private void inclbl2_Click(object sender, EventArgs e)
        {
            try
            {
                if (pidtxt.Text == "")
                {
                    Focus();
                }
                else
                {
                    int inc = int.Parse(gidtxt.Text) + 1;
                    gidtxt.Text = inc.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Enter ID first", "Error!");
            }
        }

        private void fillbtn_Click(object sender, EventArgs e)
        {
            
            Cursor = Cursors.WaitCursor;
            try
            {
                dr = obj.Query("select detailname1,detailname2,detailname3,detailname4,detailname5 from products where categoryid='" + catbox.Text + "'");
                dr.Read();

                dname1txt.Text = dr["detailname1"].ToString();
                dname2txt.Text = dr["detailname2"].ToString();
                dname3txt.Text = dr["detailname3"].ToString();
                dname4txt.Text = dr["detailname4"].ToString();
                dname5txt.Text = dr["detailname5"].ToString();
                obj.closeConnection();
            }
            catch (Exception ex)
            {
                obj.closeConnection();
                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
            Cursor = Cursors.Arrow;
        
    }

        private void desctxt_Leave(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(desctxt.Text, @"^([a-zA-Z0-9@#$%&*+\-_(),+':;?.,![\]\s\\/{}""|]+)$") && desctxt.Text != "")
            {

                MessageBox.Show("Abnormal Special Character found, Please remove it and proceed.");

            }
        }

        private void dcbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(dctxt.Text) < 10)
                {
                    dctxt.Text = 0 + dctxt.Text;
                }

                string sub = "0." + dctxt.Text;

                double sub2 = double.Parse(sub);

                double n = double.Parse(pricetxt.Text);

                n = n - (n * sub2);
                dealertxt.Text = n.ToString();
            }
            catch { }
        }

        private void addprobtn_Click(object sender, EventArgs e)
        {
            
                if (nametxt2.Text == "" || pidtxt.Text == "" || sellidtxt.Text=="")
                {
                    MessageBox.Show("Enter details first.", "Error!");
                }
                else
                {
                    Cursor = Cursors.WaitCursor;
                    try
                    {
                        StringBuilder s = new StringBuilder(nametxt2.Text);
                        s.Replace(@"\", @"\\");
                        s.Replace("'", "\\'");
                        StringBuilder s1 = new StringBuilder(brandtxt.Text);
                        s1.Replace(@"\", @"\\");
                        s1.Replace("'", "\\'");
                        string brandname = s1.ToString();
                        StringBuilder s2 = new StringBuilder(desctxt.Text);
                        s2.Replace(@"\", @"\\");
                        s2.Replace("'", "\\'");
                        string descr = s2.ToString();

                     //   supplierid = supplierlist.Text.Split(':')[0];
                        string size, dn5, d5, bran, desc;
                        if (dname5txt.Text == "")
                        {
                            dn5 = "NULL";
                        }
                        else
                        {
                            dn5 = "'" + dname5txt.Text + "'";
                        }
                        if (dname5.Text == "")
                        {
                            d5 = "NULL";
                        }
                        else
                        {
                            d5 = "'" + dname5.Text + "'";
                        }
                        if (brandname == "")
                        {
                            bran = "NULL";
                        }
                        else
                        {
                            bran = "'" + brandname + "'";
                        }
                        if (descr == "")
                        {
                            desc = "NULL";
                        }
                        else
                        {
                            desc = "'" + descr + "'";
                        }

                        //if ( || dname5txt.Text == "" || dname5.Text == "")
                        //{
                        if (s == null || catbox.Text == "")
                        {
                            MessageBox.Show("Add details first.", "Error!");

                          

                        }
                        else
                        {
                          string  cmd = "insert into products (`productid`, `supplierid`, `productname`,`tags`, `groupid`,`categoryid`,`color`, `mrp`, `price`, `dealerprice`, `stock`, `description`, `detailname1`, `detailname2`, `detailname3`, `detailname4`,`detailname5`, `detail1`, `detail2`, `detail3`, `detail4`,`detail5`,`brand`,`requeststatus`,`usedid`) " +
                                "values ('" + pidtxt.Text + "','30', '" + s + "','" + s + " " + dname1.Text + " " + brandtxt.Text + " " + tagstxt.Text + "','" + gidtxt.Text + "', '" + catbox.Text + "',NULL,'" + mrptxt.Text + "','" + pricetxt.Text + "','" + dealertxt.Text + "','" + stocktxt.Text + "'," + desc + ",'" + dname1txt.Text + "','" + dname2txt.Text + "','" + dname3txt.Text + "','" + dname4txt.Text + "'," + dn5 + ",'" + dname1.Text + "','" + dname2.Text + "','" + dname3.Text + "','" + dname4.Text + "'," + d5 + "," + bran + ",'Approved',"+sellidtxt.Text+")";
                            obj.nonQuery(cmd);
                            obj.closeConnection();
                        string cmd1 = "insert into usedbooks(`name`,`price`,`mrp`,`bookcondition`,`sellerid`,`additional`,`status`,`timestamp`)values('"+s+"',"+pricetxt.Text+","+mrptxt.Text+",'"+dname3.Text+"',"+sellidtxt.Text+",'"+additxt.Text+"','"+statusbox.Text+ "',DATE_ADD(CURRENT_TIMESTAMP, INTERVAL 750 MINUTE))";
                        obj.nonQuery(cmd1);
                        obj.closeConnection();

                        MessageBox.Show("Product successfully added.");
                        }



                       


                    }
                    catch (Exception ex)
                    {
                        obj.closeConnection();
                        MessageBox.Show(ex.Message.ToString(), "Error!");
                    }
                }
                Cursor = Cursors.Arrow;
            }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            nametxt2.Text = "";
            desctxt.Text = "";
            brandtxt.Text = "";
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
            dealertxt.Text = "";
            pidtxt.Text = "";
            catbox.Text = "";
            pic1.BackgroundImage = null;
            dctxt.Text = "";
            sellidtxt.Text = "";
            additxt.Text = "";
        }

        string filename, fileaddress, file1, fullpath, directory, uploaddir;

        private void sellerbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sellerbox.SelectedIndex > -1)
            {
                sellidtxt.Text = sellerbox.Text.Split(':')[0];

            }
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                cmdbl = new MySqlCommandBuilder(adap);
                adap.Update(dt2);
                MessageBox.Show("Account Updated.");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "Error!");
            }
            Cursor = Cursors.Arrow;
        }

        private void upbtn_Click(object sender, EventArgs e)
        {

            upsuclbl.Visible =false;
            uploadpic(fileaddress);
            pictxt.Clear();
            pic1.BackgroundImage = null;
            upsuclbl.Visible = true;
           
        }

        MySqlCommandBuilder cmdbl;
        private void changebtn_Click(object sender, EventArgs e)
        {
            try
            {
                cmdbl = new MySqlCommandBuilder(adap1);
                adap1.Update(dt3);
                MessageBox.Show("Book listing Updated.");

            }
            catch (Exception ex)
            {

                MessageBox.Show( ex.ToString(), "Error!");
            }
        }

        private void pidtxt_TextChanged(object sender, EventArgs e)
        {
            gidtxt.Text = pidtxt.Text;
            pictxt.Text = pidtxt.Text + ".jpg";
        }

        private void pic1_Click(object sender, EventArgs e)
        {
            try
            {
                if (picdialog.ShowDialog() == DialogResult.OK)
                {
                    fileaddress = picdialog.FileName;
                    filename = picdialog.SafeFileName;
                    Image myimage = new Bitmap(fileaddress);
                    Bitmap clone = new Bitmap(myimage.Width, myimage.Height);
                    // get the object representing clone's currently empty drawing surface
                    Graphics g = Graphics.FromImage(clone);
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                    g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighSpeed;
                    // copy the original image onto this surface
                    g.DrawImage(myimage, 0, 0, myimage.Width, myimage.Height);
                    // free graphics and original image
                    g.Dispose();
                    myimage.Dispose();
                    pic1.BackgroundImage = clone;
                    pic1.BackgroundImageLayout = ImageLayout.Stretch;
                    fullpath = Path.GetFullPath(fileaddress).TrimEnd(Path.DirectorySeparatorChar);
                    directory = Path.GetDirectoryName(fullpath) + "\\";
                    pictxt.Text = Path.GetFileName(fullpath);
                   
                }
               

            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message.ToString(), "Error!");
               
            }
        }

        bool success = false;
        private string uploadpic(string fileaddress)
        {
            try
            {
                if (pidtxt.Text == "")
                {
                    MessageBox.Show("Product undefined!");
                    success = false;
                    return null;
                }
                else
                {
                    if (pic1.BackgroundImage == null)
                    {
                        DialogResult dgr = MessageBox.Show("Do you want to update database only ?", "Warning!", MessageBoxButtons.YesNo);
                        if (dgr == DialogResult.Yes)
                        {
                            string cmd = "update products set picture='" + pictxt.Text + "' where productid='" + pidtxt.Text + "'";
                            obj.nonQuery(cmd);

                            MessageBox.Show("Image address added in database, please upload the picture seperately now.");
                            success = true;
                            return pictxt.Text;
                        }
                        else
                        {
                            upsuclbl.Visible = false;
                            success = false;
                            return null;
                        }
                    }
                    else
                    {
                        try
                        {
                            Cursor = Cursors.WaitCursor;
                            File.Move(fileaddress, directory + pictxt.Text);
                            uploaddir = directory + pictxt.Text;

                           string cmd = "update products set picture='" + pictxt.Text + "' where productid='" + pidtxt.Text + "'";
                            obj.nonQuery(cmd);

                            UploadFileToFtp("ftp://lalchowk.in/httpdocs/lalchowk/pictures/", uploaddir);
                            Cursor = Cursors.Arrow;
                            success = true;
                            return pictxt.Text;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
                            success = false;
                            return null;
                            Cursor = Cursors.Arrow;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                obj.closeConnection();
                MessageBox.Show(ex.Message.ToString(), "Error!");
                Cursor = Cursors.Arrow;

                return null;
            }
        }

        public void UploadFileToFtp(string url, string filePath)
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


                Stream ftpStream = request.GetRequestStream();
                FileStream file = File.OpenRead(filePath);
                //picprogress.Invoke(
                // (MethodInvoker)delegate { picprogress.Value = 0; picprogress.Maximum = (int)file.Length / 1000; uptxt.Text = fileName; });


                byte[] buffer = new byte[10240];
                int bytesRead = 0;



                while ((bytesRead = file.Read(buffer, 0, buffer.Length)) > 0)
                {

                    ftpStream.Write(buffer, 0, bytesRead);
                    //picprogress.Invoke((MethodInvoker)delegate { picprogress.Value = (int)file.Position / 1000; sizelbl.Text = picprogress.Value.ToString() + "/" + picprogress.Maximum + " KB"; });

                }

                file.Close();
                ftpStream.Close();



            }
            catch (Exception ex)
            {
              //  uploadfailed = true;
                MessageBox.Show(ex.Message.ToString(), "Error!");
                Cursor = Cursors.Arrow;
            }
        }


        bool flag = false;
        int sid = 0;
        private void selldataview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (flag == false)
            {

                temailbtn.Visible = false;
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.selldataview.Rows[e.RowIndex];
                    id = row.Cells["id"].Value.ToString();
                    nametxt.Text = row.Cells["name"].Value.ToString();
                    contxt.Text = row.Cells["contact"].Value.ToString();
                    booknametxt.Text = row.Cells["bookname"].Value.ToString();
                    detailstxt.Text = row.Cells["details"].Value.ToString();
                    email = row.Cells["email"].Value.ToString();

                    if (email == "")
                    {
                        emailtxt.Text = "New customer";
                    }
                    else
                    {
                        if (email == "null")
                        {

                            emailtxt.Text = "New customer";
                        }
                        else
                        {
                            temailbtn.Visible = true;
                            emailtxt.Text = email;
                        }
                        dpnl.Visible = true;
                    }
                    dpnl.Visible = true;
                }
            } else if (flag)
            {
                if (e.RowIndex >= 0)
                {
                    countlbl.Visible = false;
                    
                    DataGridViewRow row = this.selldataview.Rows[e.RowIndex];
                    sid = int.Parse(row.Cells["sellerid"].Value.ToString());

                    Cursor = Cursors.WaitCursor;
                    adap1 = new MySqlDataAdapter("select bookid,name,price,mrp,status from usedbooks where sellerid="+sid+" order by bookid", con);
                    dt3 = new DataTable();
                    adap1.Fill(dt3);
                    bsource3 = new BindingSource();
                    bsource3.DataSource = dt3;
                    booklistview.DataSource = bsource3;
                    changebtn.Visible = true;
                    updatebtn.Visible = true;
                    int number,price,mrp;
                    BackgroundWorker count = new BackgroundWorker();
                    count.DoWork += (o, a) =>
                    {
                        try
                        {
                            dr = obj.Query("select count(bookid),sum(mrp),sum(price) from usedbooks where sellerid=" + sid + " ");
                            dr.Read();
                            number = int.Parse(dr[0].ToString());
                            mrp = int.Parse(dr[1].ToString());
                            price = int.Parse(dr[2].ToString());
                            obj.closeConnection();
                            object[] arg = {number,mrp,price };
                            a.Result = arg;

                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); obj.closeConnection(); }

                    };
                    count.RunWorkerCompleted += (o, b) =>
                    {
                        try
                        {
                            object[] arg = b.Result as object[];
                            int number1 = (int)arg[0];
                            int mrp1= (int)arg[1];
                            int price1= (int)arg[2];
                            double n = price1;
                            double result=0;
                            try
                            {
                                n = n - (n * 0.25);
                                result = price1 - n;
                              //  MessageBox.Show("price is: " + price1.ToString() + n.ToString() + "we get: " + result.ToString());
                            }
                            catch { }

                            countlbl.Text = "Seller has " + number1 + " books listed to his account. \nWhich amounts to MRP: " + mrp1 + "\nwe are selling it on: " + price1 +
                             "\nfrom which the seller gets: " + n.ToString()+ "\nand we get: " + result.ToString()+"" ;
                           
                            countlbl.Visible = true;
                        }
                        catch (Exception ex) { MessageBox.Show(ex.ToString()); }
                    };
                    count.RunWorkerAsync();

                    booklistview.Visible = true;
                    Cursor = Cursors.Arrow;

                   
                }

            }
        }
    }
}
