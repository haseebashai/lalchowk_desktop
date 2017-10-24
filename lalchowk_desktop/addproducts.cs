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
            readsuppliers();
            readsecond();
        }

        private void bgworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            firstcat.DisplayMember = "categoryname";
            supplierlist.DisplayMember = "name";         
            addppnl.Enabled = true;
            dg.loadingimage.Visible = false;
            dg.lbl.ForeColor = SystemColors.Highlight;
            dg.lbl.Text = "Add Products";

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
           
            firstcat.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Something happened, please try again");
            }
        }

        private void supplierlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { 
            dr = obj.Query("select supplierid from suppliers where name='" + supplierlist.Text + "'");
            dr.Read();    
            supidtxt.Text = dr[0].ToString();            
            obj.closeConnection();
        }catch(Exception)
            {
                obj.closeConnection();
                MessageBox.Show("Error!\nPlease try again.");
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
            seccat.DisplayMember = "categoryname";
            seccat.DataSource = dt;
            
            }
            catch (Exception)
            {
                MessageBox.Show("Something happened, please try again");
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
            catch (Exception)
            {
                MessageBox.Show("Something happened, please try again");
            }
            
        }

        


        private void readsuppliers()
        {try { 
            dr = obj.Query("select distinct name from suppliers");
            DataTable dt = new DataTable();
            dt.Columns.Add("name", typeof(String));
            dt.Load(dr);
            obj.closeConnection();
            supplierlist.DisplayMember = "name";
            supplierlist.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Something happened, please try again");
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
                MessageBox.Show(ex.ToString());
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
                            MessageBox.Show("Cannot perform the operation, check the error description.\n\n\n" + ex.ToString());
                            success = false;
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("hi" +ex.ToString());
                success = false;
                return null;               
            }
        }
       
        private void bguploadpic_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            uptxt.Text = e.ProgressPercentage.ToString();
            picprogress.Value = e.ProgressPercentage;
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
            }else
            {

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
                            MessageBox.Show("Cannot perform the operation, check the error description.\n\n\n" + ex.ToString());
                            success = false;
                            return null;
                            
                        }


                    }
                }
            }
            catch (WebException ex)
            {
                success = false;
               
                MessageBox.Show(ex.ToString());
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
                int inc = int.Parse(pidtxt.Text) + 1;
                pidtxt.Text = inc.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Enter id first \n\n" + ex.ToString());               
            }
        }

        private void inclbl2_Click(object sender, EventArgs e)
        {
            try
            {
                int inc = int.Parse(gidtxt.Text) + 1;
                gidtxt.Text = inc.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Enter id first \n\n" + ex.ToString());
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

        private void pidtxt_TextChanged(object sender, EventArgs e)
        {
            pictxt.Text = pidtxt.Text + "-1.jpg";
            p2txt.Text= pidtxt.Text + "-2.jpg";
            p3txt.Text= pidtxt.Text + "-3.jpg";
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
                    MessageBox.Show(ex.ToString());
                    success = false;
                }
                    Cursor = Cursors.Arrow;
                p6txt.Text = "";
            }          
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
                

                //      var response = (FtpWebResponse)request.GetResponse();
                //    MessageBox.Show("Image uploaded successfully.\nSuccess Response code: " + response.StatusDescription);

                //  response.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
               
            }
        }

        private void fillbtn_Click(object sender, EventArgs e)
        {
            
                readdetails();
            
        }

        private void desctxt_Leave(object sender, EventArgs e)
        {
            
                if (!Regex.IsMatch(desctxt.Text, @"^([a-zA-Z0-9@#$%&*+\-_(),+':;?.,![\]\s\\/{}""|]+)$"))
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
            }catch(Exception)
            {
                obj.closeConnection();
                MessageBox.Show("Error!\nPlease try again.");
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
        }catch(Exception)
            {
                obj.closeConnection();
                MessageBox.Show("Error!\nPlease try again.");
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
        }catch(Exception)
            {
                obj.closeConnection();
                MessageBox.Show("Error!\nPlease try again.");
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
        }catch(Exception)
            {
                obj.closeConnection();
                MessageBox.Show("Error!\nPlease try again.");
            }


}

      

        private void picbtn_Click(object sender, EventArgs e)
        {
           

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
                s1.Replace(@"\", @"\\");
                s1.Replace("'", "\\'");


                if (sizetxt.Text =="")
                {
                    cmd = "insert into products (`productid`, `supplierid`, `productname`,`tags`, `groupid`,`categoryid`,`color`, `mrp`, `price`, `dealerprice`, `stock`, `description`, `detailname1`, `detailname2`, `detailname3`, `detailname4`,`detailname5`, `detail1`, `detail2`, `detail3`, `detail4`,`detail5`,`brand`,`size`,`requeststatus`,`picture`) " +
                       "values ('" + pidtxt.Text + "','" + supidtxt.Text + "', '" + s + "','"+ s + " " +tagstxt.Text+"','" + gidtxt.Text + "', '" + catbox.Text + "','" + colourtxt.Text + "','" + mrptxt.Text + "','" + pricetxt.Text + "','" + dealertxt.Text + "','" + stocktxt.Text + "','" + s2 + "','" + dname1txt.Text + "','" + dname2txt.Text + "','" + dname3txt.Text + "','" + dname4txt.Text + "','"+dname5txt.Text+"','" + dname1.Text + "','" + dname2.Text + "','" + dname3.Text + "','" + dname4.Text + "','"+dname5.Text+"','" + s1 + "',null,'Approved','" + pictxt.Text + "')";
                    obj.nonQuery(cmd);
                }
                else if(dname5txt.Text == "" || dname5.Text == "")
                {
                    cmd = "insert into products (`productid`, `supplierid`, `productname`,`tags`, `groupid`,`categoryid`,`color`, `mrp`, `price`, `dealerprice`, `stock`, `description`, `detailname1`, `detailname2`, `detailname3`, `detailname4`,`detailname5`, `detail1`, `detail2`, `detail3`, `detail4`,`detail5`,`brand`,`size`,`requeststatus`,`picture`) " +
                       "values ('" + pidtxt.Text + "','" + supidtxt.Text + "', '" + s + "','" + s + " " + tagstxt.Text + "','" + gidtxt.Text + "', '" + catbox.Text + "','" + colourtxt.Text + "','" + mrptxt.Text + "','" + pricetxt.Text + "','" + dealertxt.Text + "','" + stocktxt.Text + "','" + s2 + "','" + dname1txt.Text + "','" + dname2txt.Text + "','" + dname3txt.Text + "','" + dname4txt.Text + "',null,'" + dname1.Text + "','" + dname2.Text + "','" + dname3.Text + "','" + dname4.Text + "',null,'" + s1 + "','" + sizetxt.Text + "','Approved','" + pictxt.Text + "')";
                    obj.nonQuery(cmd);
                }
                else
                {
                    cmd = "insert into products (`productid`, `supplierid`, `productname`,`tags`, `groupid`,`categoryid`,`color`, `mrp`, `price`, `dealerprice`, `stock`, `description`, `detailname1`, `detailname2`, `detailname3`, `detailname4`, `detailname5`, `detail1`, `detail2`, `detail3`, `detail4`, `detail5`,`brand`,`size`,`requeststatus`,`picture`) " +
                          "values ('" + pidtxt.Text + "','" + supidtxt.Text + "', '" + s + "','" + s + " " + tagstxt.Text + "','" + gidtxt.Text + "', '" + catbox.Text + "','" + colourtxt.Text + "','" + mrptxt.Text + "','" + pricetxt.Text + "','" + dealertxt.Text + "','" + stocktxt.Text + "','" + s2 + "','" + dname1txt.Text + "','" + dname2txt.Text + "','" + dname3txt.Text + "','" + dname4txt.Text + "','" + dname5txt.Text + "','" + dname1.Text + "','" + dname2.Text + "','" + dname3.Text + "','" + dname4.Text + "','" + dname5.Text + "','" + s1 + "','" + sizetxt.Text + "','Approved','" + pictxt.Text + "')";
                    obj.nonQuery(cmd);
                }

                //   int productid = obj.Count("SELECT LAST_INSERT_ID()");



                obj.closeConnection();
                
                MessageBox.Show("Product successfully added.");




                
                //clearall();


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                obj.closeConnection();
            }
            Cursor = Cursors.Arrow;
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
