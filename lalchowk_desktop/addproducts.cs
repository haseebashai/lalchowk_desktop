﻿using System;
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
using System.Threading;

namespace Veiled_Kashmir_Admin_Panel
{
    public partial class addproducts : Form
    {
        bool fnameok = true, lnameok = true, emailok = true, passwordok = true, confirmok = true, phoneok = true, dobok = true;
        DBConnect obj = new DBConnect();
        MySqlDataReader dr,dr2;
        string filename, fileaddress, file1,file2,file3,file4,file5,fullpath, directory, uploaddir, categoryid;

        private container hp = null;
        private mainform mf = null;
        private dialogcontainer dg = null;
        string cmd;
        

        public addproducts(Form hpcopy, Form mfcopy, Form dgcopy)
        {
            hp = hpcopy as container;
            mf = mfcopy as mainform;
            dg = dgcopy as dialogcontainer;

            InitializeComponent();

            loadingdg();
            addppnl.Enabled = false;
            Cursor = Cursors.WaitCursor;
            bgworker.RunWorkerAsync();


      /*      
            String temp = dr[6].ToString();            
            daytxt.Text = temp.Substring(0, 2);
            montxt.Text = temp.Substring(3, 2);
            yeartxt.Text = temp.Substring(6, 4);
             */
        }

      

        private void bgworker_DoWork(object sender, DoWorkEventArgs e)
        {
            
            readfirst();
            readsecond();
            readsuppliers();
            
           
        }

        private void bgworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            firstcat.DisplayMember = "categoryname";
            seccat.DisplayMember = "categoryname";
            supplierlist.DisplayMember = "name";         
            addppnl.Enabled = true;
            dg.loadingimage.Visible = false;
            dg.lbl.ForeColor = SystemColors.Highlight;
            dg.lbl.Text = "Add Products";
            Cursor = Cursors.Arrow;
           
        }

       
        public void loadingdg()
        {

            dg.lbl.ForeColor = SystemColors.Highlight;
            dg.lbl.Text = "Loading";
            dg.loadingimage.SizeMode = PictureBoxSizeMode.StretchImage;
            dg.loadingimage.Visible = true;
        }


        private void readfirst()
        {try {
                
            dr = obj.Query("select * from firstcategory");            
            DataTable dt = new DataTable();          
            dt.Columns.Add("categoryname", typeof(String));            
            dt.Load(dr);
            obj.closeConnection();
                firstcat.DisplayMember = "categoryname";
                firstcat.DataSource = dt;
               
               
            }
            catch (Exception ex)
            {
                obj.closeConnection();
                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }

        string supplierid;
        private void supplierlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {

                supidtxt.Text = "Supplier:" + supplierlist.Text.Split(':')[1];
             
                //dr = obj.Query("select supplierid from suppliers where name='" + supplierlist.Text + "'");
                //dr.Read();   
                //    supplierid= dr[0].ToString();
                //    supidtxt.Text = dr[0].ToString();            
                //obj.closeConnection();

            }
            catch (Exception ex)
            {
                //obj.closeConnection();
                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }

        private void readsecond()
        {
            
            try {
              
                dr = obj.Query("select categoryname from secondcategory where firstcategoryid = '" + idlbl.Text +"'");
            DataTable dt = new DataTable();
            dt.Columns.Add("categoryname", typeof(String));
            dt.Load(dr);
            obj.closeConnection();
           
            seccat.DataSource = dt;
             
            }
            catch (Exception ex)
            {
                obj.closeConnection();
                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }

        }

      

        private void readthird()
        {
            
            try {
              
                dr = obj.Query("select categoryname from thirdcategory where secondcategoryid = '" + id2lbl.Text + "'");
            DataTable dt = new DataTable();
            dt.Columns.Add("categoryname", typeof(String));
            dt.Load(dr);
            obj.closeConnection();
            thirdcat.DisplayMember = "categoryname";
            thirdcat.DataSource = dt;
               
            }
            catch (Exception ex)
            {
                obj.closeConnection();
                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }

        }

        


        private void readsuppliers()
        {try {
               
                dr = obj.Query("select distinct concat(supplierid,':  ',name) as name from suppliers");
            DataTable dt = new DataTable();
            dt.Columns.Add("name", typeof(String));
            dt.Load(dr);
            obj.closeConnection();
            supplierlist.DisplayMember = "name";
            supplierlist.DataSource = dt;
               
            }
            catch (Exception ex)
            {
                obj.closeConnection();
                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
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
            dealertxt.Text = "";
            pidtxt.Text = "";           
            catbox.Text = "";
            pic1.BackgroundImage = null;
            pic2.BackgroundImage = null;
            pic3.BackgroundImage = null;
            pic4.BackgroundImage = null;
            pic5.BackgroundImage = null;
            pictxt.Text = "";
            p2txt.Text = "";
            p3txt.Text = "";
            p4txt.Text = "";
            p5txt.Text = "";

        }
        private void cancelbtn_Click(object sender, EventArgs e)
        {
            clearall();
            
        }


        private void readcategory()
        {
            if ( id3lbl.Text=="" || id2lbl.Text=="")

                catbox.Text = id2lbl.Text;
            else
            {
                catbox.Text = id3lbl.Text;
            }
        }
        
        private string picturedialog(TextBox name, PictureBox image)
        {
            try {
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
                    image.BackgroundImage = clone;
                    image.BackgroundImageLayout = ImageLayout.Stretch;
                    fullpath = Path.GetFullPath(fileaddress).TrimEnd(Path.DirectorySeparatorChar);
                    directory = Path.GetDirectoryName(fullpath) + "\\";
                    name.Text = Path.GetFileName(fullpath);
                    clearpicbtn.Visible = true;


                    return (fileaddress);
                }
                return null;
             
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
                return null;
            }
           
            

        }

        bool success = false;
        private string uploadpic(TextBox name, PictureBox image, string fileaddress)
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
                    if (image.BackgroundImage == null)
                    {
                        DialogResult dgr = MessageBox.Show("Do you want to update database only ?", "Warning!", MessageBoxButtons.YesNo);
                        if (dgr == DialogResult.Yes) {
                            cmd = "update products set picture='" + name.Text + "' where productid='" + pidtxt.Text + "'";
                            obj.nonQuery(cmd);
                            
                            MessageBox.Show("Image address added in database, please upload the picture seperately now.");
                            success = true;
                            return name.Text;
                        }
                        else
                        {
                            success = false;
                            return null;
                        }                       
                    }
                    else
                    {
                        try { 
                        File.Move(fileaddress, directory + name.Text);
                        uploaddir = directory + name.Text;

                        cmd = "update products set picture='" + name.Text + "' where productid='" + pidtxt.Text + "'";
                        obj.nonQuery(cmd);

                        UploadFileToFtp("ftp://lalchowk.in/httpdocs/lalchowk/pictures/", uploaddir);
                        bguploadpic.ReportProgress(100);
                        success = true;
                        return name.Text;
                    }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
                            success = false;
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                obj.closeConnection();
                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");


                return null;               
            }
        }
       
        private void bguploadpic_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
      //      picprogress.Value = e.ProgressPercentage;
        }

        string displayname;
        private void bguploadpic_DoWork(object sender, DoWorkEventArgs e)
        {
            Object[] arg = e.Argument as Object[];
            TextBox pictext = (TextBox)arg[0];
            PictureBox picture = (PictureBox)arg[1];
            String file = (string)arg[2];
            string check = (string)arg[3];
            
            

            if (check == "")
            {
                
                    displayname = uploadpic(pictext, picture, file);
            }
            else
            {
                if (check == "table")
                {
                    
                    displayname= uploadpictable(pictext, picture, file);
                }
            }
            e.Result = arg;
        }
        private void bguploadpic_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictimer.Stop();
            enableup();
           

            object[] arg = (object[])e.Result;
            TextBox pictext = (TextBox)arg[0];
            PictureBox picture = (PictureBox)arg[1];
            
            if (success)
            {
                uptxt.Font = new Font("MS Sans serif", 9, FontStyle.Regular);
                uptxt.ForeColor = Color.Green;
                uptxt.Text = "Upload Successful. " + displayname ;
                pictext.Clear();
                picture.BackgroundImage = null;
                sizelbl.Text = "";
            }else if (uploadfailed)
            {
                uptxt.ForeColor = Color.Red;
                uptxt.Text = "Upload Failed " + displayname;
            }
            else
            {
                sizelbl.Visible = false;
                uptxt.Visible = false;
                picprogress.Visible = false;
              
            }
        }


        private void pic1_Click(object sender, EventArgs e)
        {

            file1=picturedialog(pictxt, pic1);
                     
        }
        private void up1_Click(object sender, EventArgs e)
        {
            pictimer.Start();
            disableup();
            
            Object[] args = { pictxt, pic1, file1,"" };
            bguploadpic.RunWorkerAsync(args);
        
        }

        private void disableup()
        {
            up1.Enabled = false;
            up2.Enabled = false;
            up3.Enabled = false;
            up4.Enabled = false;
            up5.Enabled = false;
            up6.Enabled = false;
        }
        private void enableup()
        {
            up1.Enabled = true;
            up2.Enabled = true;
            up3.Enabled = true;
            up4.Enabled = true;
            up5.Enabled = true;
            up6.Enabled = true;
        }

      
        
    int numberOfPoints = 0;
        private void pictimer_Tick(object sender, EventArgs e)
        {
            picprogress.Value = 0;
            uptxt.Visible = true;
            sizelbl.Visible = true;
            

            picprogress.Visible = true;
            int maxPoints = 5;
            uptxt.Text = "Uploading" + new string('.', numberOfPoints);
            numberOfPoints = (numberOfPoints + 1) % (maxPoints + 1);
        }


        private string uploadpictable(TextBox name, PictureBox image, string fileaddress)
        {
            try
            {
                if (gidtxt.Text == "")
                {
                    MessageBox.Show("Product undefined!");
                    success = false;
                    return null;
                }
                else
                {
                    if (image.BackgroundImage == null)
                    {
                        DialogResult dgr = MessageBox.Show("Do you want to update database only ?", "Warning!", MessageBoxButtons.YesNo);
                        if (dgr == DialogResult.Yes)
                        {
                            cmd = "insert into pictures (`groupid`, `picture`) " +
                             "values ('" + gidtxt.Text + @"','" + name.Text + "')";
                            obj.nonQuery(cmd);
                            bguploadpic.ReportProgress(100);
                            MessageBox.Show("Image address added in database, please upload the picture seperately now.");
                            success = true;
                            return name.Text;
                        }
                        else
                        {
                            success = false;
                            return null;
                        }

                    }
                    else
                    {
                        try
                        {
                            File.Move(fileaddress, directory + name.Text);
                            uploaddir = directory + name.Text;
                       
                            cmd = "insert into pictures (`groupid`, `picture`) " +
                                 "values ('" + gidtxt.Text + @"','" + name.Text + "')";
                            obj.nonQuery(cmd);

                            UploadFileToFtp("ftp://lalchowk.in/httpdocs/lalchowk/pictures/", uploaddir);
                        bguploadpic.ReportProgress(100);

                        success = true;
                        return name.Text;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");

                            success = false;
                            return null;
                            
                        }


                    }
                }
            }
            catch (WebException ex)
            {
                obj.closeConnection();
                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");

                return null;
            }
        }


        private void pic2_Click(object sender, EventArgs e)
        {


            file2= picturedialog(p2txt, pic2);

           
        }

        private void up2_Click(object sender, EventArgs e)
        {
            pictimer.Start();
            disableup();          
            Object[] args = { p2txt, pic2, file2,"table" };
            bguploadpic.RunWorkerAsync(args);


        }

        private void pic3_Click(object sender, EventArgs e)
        {
            file3=picturedialog(p3txt, pic3);
        }

        private void up3_Click(object sender, EventArgs e)
        {
            pictimer.Start();
            disableup();
            Object[] args = { p3txt, pic3, file3, "table" };
            bguploadpic.RunWorkerAsync(args);
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

        private void clearpicbtn_Click(object sender, EventArgs e)
        {
            pic1.BackgroundImage = null;
            pic2.BackgroundImage = null;
            pic3.BackgroundImage = null;
            pic4.BackgroundImage = null;
            pic5.BackgroundImage = null;

            clearpicbtn.Visible = false;

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
            }catch { obj.closeConnection(); }
            Cursor = Cursors.Arrow;
        }

        private void pidtxt_TextChanged(object sender, EventArgs e)
        {
            gidtxt.Text = pidtxt.Text;
            pictxt.Text = pidtxt.Text + ".jpg";
            p2txt.Text= pidtxt.Text + "-2.jpg";
            p3txt.Text= pidtxt.Text + "-3.jpg";
            p4txt.Text = pidtxt.Text + "-4.jpg";
            p5txt.Text = pidtxt.Text + "-5.jpg";
        }

        private void pic4_Click(object sender, EventArgs e)
        {
           file4= picturedialog(p4txt, pic4);
        }

        private void up4_Click(object sender, EventArgs e)
        {
            pictimer.Start();
            disableup();
            Object[] args = { p4txt, pic4, file4, "table" };
            bguploadpic.RunWorkerAsync(args);
        }

        private void pic5_Click(object sender, EventArgs e)
        {
           file5= picturedialog(p5txt, pic5);
        }

        private void up5_Click(object sender, EventArgs e)
        {
            pictimer.Start();
            disableup();
            Object[] args = { p5txt, pic5, file5, "table" };
            bguploadpic.RunWorkerAsync(args);
        }

        private void p6txt_Click(object sender, EventArgs e)
        {
            if (p6txt.Text == "") {
                if (picdialog.ShowDialog() == DialogResult.OK)
                {
                    fileaddress = picdialog.FileName;
                    filename = picdialog.SafeFileName;
                    fullpath = Path.GetFullPath(fileaddress).TrimEnd(Path.DirectorySeparatorChar);
                    directory = Path.GetDirectoryName(fullpath) + "\\";
                    p6txt.Text = Path.GetFileName(fullpath);
                }
                else
                {
                    p6txt.Focus();
                }
            }
        }

        private void up6_Click(object sender, EventArgs e)
        {
            if (gidtxt.Text == "")
            {
                MessageBox.Show("Product undefined!");
                success = false;
            }
            else
            {
                    Cursor = Cursors.WaitCursor;
                    try
                    {
                   
                        File.Move(fileaddress, directory + p6txt.Text);
                        uploaddir = directory + p6txt.Text;

                            UploadFileToFtp("ftp://lalchowk.in/httpdocs/lalchowk/pictures/", uploaddir);

                        cmd = "insert into pictures (`groupid`, `picture`) " +
                             "values ('" + gidtxt.Text + @"','" + p6txt.Text + "')";
                        obj.nonQuery(cmd);

                        obj.closeConnection();
                    success = true;
                    MessageBox.Show("Picture Uploaded.");

                    
                    }
                catch (WebException ex)
                {
                    obj.closeConnection();
                    MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");


                }
                Cursor = Cursors.Arrow;
                p6txt.Text = "";
            }          
        }

        bool uploadfailed = false;
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
                picprogress.Invoke(
                  (MethodInvoker)delegate { picprogress.Value = 0; picprogress.Maximum = (int)file.Length / 1000; uptxt.Text = fileName; });

                byte[] buffer = new byte[10240];
                int bytesRead = 0;



                while ((bytesRead = file.Read(buffer, 0, buffer.Length)) > 0)
                {

                    ftpStream.Write(buffer, 0, bytesRead);
                    picprogress.Invoke((MethodInvoker)delegate { picprogress.Value = (int)file.Position / 1000; sizelbl.Text = picprogress.Value.ToString() + "/" + picprogress.Maximum + " KB"; });
                }

                file.Close();
                ftpStream.Close();
              
        
                
                //using (var fileStream = File.OpenRead(filePath))
                //{
                //    using (var requestStream = request.GetRequestStream())
                //    {
                //        fileStream.CopyTo(requestStream);
                //        requestStream.Close();
                //    }
                //}
                

                ////      var response = (FtpWebResponse)request.GetResponse();
                ////    MessageBox.Show("Image uploaded successfully.\nSuccess Response code: " + response.StatusDescription);

                ////  response.Close();


            }
            catch (Exception ex)
            {
                uploadfailed = true;
                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }

        private void fillbtn_Click(object sender, EventArgs e)
        {
            
                readdetails();
            
        }

        private void desctxt_Leave(object sender, EventArgs e)
        {
            
                if (!Regex.IsMatch(desctxt.Text, @"^([a-zA-Z0-9@#$%&*+\-_(),+':;?.,![\]\s\\/{}""|]+)$") && desctxt.Text!="")
                {

                    MessageBox.Show("Abnormal Special Character found, Please remove it and proceed.");

                }
    
        }

        
        private void catlbl_TextChanged(object sender, EventArgs e)
        {
           //  MessageBox.Show(catlbl.Text.ToString());
            //   readdetails();
           
        }

        private void readdetails()
        {
            try { 
            dr = obj.Query("select detailname1,detailname2,detailname3,detailname4,detailname5 from products where categoryid='"+catbox.Text+"'");
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

        }

        private void thirdcat_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { 
            dr = obj.Query("select categoryid from thirdcategory where categoryname='" + thirdcat.Text + "' && secondcategoryid='" + id2lbl.Text + "'");
            if (dr.Read())
            {
                id3lbl.Text = dr[0].ToString();
                      
            }
           else 
            {
                id3lbl.Text = "";
            }
            obj.closeConnection();
            readcategory();
            }
            catch (Exception ex)
            {
                obj.closeConnection();
                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }

        }

        private void seccat_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
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
            catch (Exception ex)
            {
                obj.closeConnection();
                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }


        }

        private void firstcat_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
            dr = obj.Query("select categoryid from firstcategory where categoryname='" + firstcat.Text + "'");
            dr.Read();
            idlbl.Text = dr[0].ToString();
            obj.closeConnection();
            seccat.DataSource = null;
            foreach (DataRowView items in seccat.Items)
                seccat.Items.Remove(items);
            readsecond();
                seccat.DisplayMember = "categoryname";
            }
            catch (Exception ex)
            {
                obj.closeConnection();
                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }


        }

  

        private void addbtn_Click(object sender, EventArgs e)
        {

            Cursor = Cursors.WaitCursor;
            try
            {
                StringBuilder s = new StringBuilder(nametxt.Text);
                s.Replace(@"\", @"\\");
                s.Replace("'", "\\'");
                StringBuilder s1 = new StringBuilder(brandtxt.Text);
                s1.Replace(@"\", @"\\");
                s1.Replace("'", "\\'");
                StringBuilder s2 = new StringBuilder(desctxt.Text);
                s2.Replace(@"\", @"\\");
                s2.Replace("'", "\\'");

                supplierid= supplierlist.Text.Split(':')[0];

                if (sizetxt.Text =="")
                {
                    cmd = "insert into products (`productid`, `supplierid`, `productname`,`tags`, `groupid`,`categoryid`,`color`, `mrp`, `price`, `dealerprice`, `stock`, `description`, `detailname1`, `detailname2`, `detailname3`, `detailname4`,`detailname5`, `detail1`, `detail2`, `detail3`, `detail4`,`detail5`,`brand`,`size`,`requeststatus`) " +
                       "values ('" + pidtxt.Text + "','" + supplierid+ "', '" + s + "','"+ s + " " +tagstxt.Text+"','" + gidtxt.Text + "', '" + catbox.Text + "','" + colourtxt.Text + "','" + mrptxt.Text + "','" + pricetxt.Text + "','" + dealertxt.Text + "','" + stocktxt.Text + "','" + s2 + "','" + dname1txt.Text + "','" + dname2txt.Text + "','" + dname3txt.Text + "','" + dname4txt.Text + "','"+dname5txt.Text+"','" + dname1.Text + "','" + dname2.Text + "','" + dname3.Text + "','" + dname4.Text + "','"+dname5.Text+"','" + s1 + "',null,'Approved')";
                    obj.nonQuery(cmd);
                }
                else if(dname5txt.Text == "" || dname5.Text == "")
                {
                    cmd = "insert into products (`productid`, `supplierid`, `productname`,`tags`, `groupid`,`categoryid`,`color`, `mrp`, `price`, `dealerprice`, `stock`, `description`, `detailname1`, `detailname2`, `detailname3`, `detailname4`,`detailname5`, `detail1`, `detail2`, `detail3`, `detail4`,`detail5`,`brand`,`size`,`requeststatus`) " +
                       "values ('" + pidtxt.Text + "','" + supplierid + "', '" + s + "','" + s + " " + tagstxt.Text + "','" + gidtxt.Text + "', '" + catbox.Text + "','" + colourtxt.Text + "','" + mrptxt.Text + "','" + pricetxt.Text + "','" + dealertxt.Text + "','" + stocktxt.Text + "','" + s2 + "','" + dname1txt.Text + "','" + dname2txt.Text + "','" + dname3txt.Text + "','" + dname4txt.Text + "',null,'" + dname1.Text + "','" + dname2.Text + "','" + dname3.Text + "','" + dname4.Text + "',null,'" + s1 + "','" + sizetxt.Text + "','Approved')";
                    obj.nonQuery(cmd);
                }
                else
                {
                    cmd = "insert into products (`productid`, `supplierid`, `productname`,`tags`, `groupid`,`categoryid`,`color`, `mrp`, `price`, `dealerprice`, `stock`, `description`, `detailname1`, `detailname2`, `detailname3`, `detailname4`, `detailname5`, `detail1`, `detail2`, `detail3`, `detail4`, `detail5`,`brand`,`size`,`requeststatus`) " +
                          "values ('" + pidtxt.Text + "','" + supplierid + "', '" + s + "','" + s + " " + tagstxt.Text + "','" + gidtxt.Text + "', '" + catbox.Text + "','" + colourtxt.Text + "','" + mrptxt.Text + "','" + pricetxt.Text + "','" + dealertxt.Text + "','" + stocktxt.Text + "','" + s2 + "','" + dname1txt.Text + "','" + dname2txt.Text + "','" + dname3txt.Text + "','" + dname4txt.Text + "','" + dname5txt.Text + "','" + dname1.Text + "','" + dname2.Text + "','" + dname3.Text + "','" + dname4.Text + "','" + dname5.Text + "','" + s1 + "','" + sizetxt.Text + "','Approved')";
                    obj.nonQuery(cmd);
                }

                //   int productid = obj.Count("SELECT LAST_INSERT_ID()");



                obj.closeConnection();
                
                MessageBox.Show("Product successfully added.");




                
                //clearall();


            }
            catch (Exception ex)
            {
                obj.closeConnection();
                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
            Cursor = Cursors.Arrow;
        }

    }
}
