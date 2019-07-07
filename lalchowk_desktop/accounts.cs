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

namespace Modest_Attires
{
    public partial class accounts : Form
    {
        DBConnect obj = new DBConnect();
        MySqlConnection con= new MySqlConnection("SERVER = 182.50.133.78; DATABASE=lalchowk;USER=lalchowk;PASSWORD=Lalchowk@123uzmah;Convert Zero Datetime=True");
        MySqlCommand mysqlcmd, cmd;
        DataTable dt;
        MySqlDataReader dr,dr1;
        MySqlCommandBuilder cmdbl;
        MySqlDataAdapter adap,adap1;
        MySqlConnection aconn = new MySqlConnection("SERVER=182.50.133.78;DATABASE=lalchowk_ac;USER=lalchowkac;PASSWORD=Lalchowk@123uzmah");
        string date, month,bal,total;
        PictureBox loading = new PictureBox();
        BindingSource bsource;


        private dialogcontainer dg = null;
        private container hp = null;
        public accounts(Form hpcopy,Form dgcopy)
        {
            dg = dgcopy as dialogcontainer;
            hp = hpcopy as container;
            InitializeComponent();
            accountdataview.DoubleBuffered(true);
            bgworker.RunWorkerAsync();
            
            
        }

        private void bgworker_DoWork(object sender, DoWorkEventArgs e)
        {
            readdetails();
            readexpenses();
        }

        private void bgworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (dg!=null)
            {
                dg.loadingimage.Visible = false;
                dg.lbl.ForeColor = SystemColors.Highlight;
                dg.lbl.Text = "Accounts";

            }
            else
            {
                loading.Visible = false;
                formlbl.Visible = false;
                
            }
            Cursor = Cursors.Arrow;
            refresh.Enabled = true;
            try
            {
                accountdataview.Columns.Remove("Details");
            }catch { }
            accountdataview.DataSource = bsource;
           
            btnenable();
            bpnl.Visible = true;
            panelshow();
            
        }
        private void panelshow()
        {
            epnl.Visible = true;
            accountdataview.Visible = true;
            uppnl.Visible = true;
            dpnl.Visible = true;
        }

        private void panelhide()
        {
            epnl.Visible = false;
            accountdataview.Visible = false;
            uppnl.Visible = false;
            dpnl.Visible =false;
            revdetpnl.Visible = false;
        }

        private void btndisable()
        {
            expbtn.Enabled = false;
            moneybtn.Enabled = false;
      //      bankbtn.Enabled = false;
        //    miscbtn.Enabled = false;
            billbtn.Enabled = false;
            dealbtn.Enabled = false;
            delbtn.Enabled = false;
            revbtn.Enabled = false;
        }

        private void btnenable()
        {
            expbtn.Enabled = true;
            moneybtn.Enabled = true;
         //   bankbtn.Enabled = true;
           // miscbtn.Enabled = true;
            billbtn.Enabled = true;
            dealbtn.Enabled = true;
            delbtn.Enabled = true;
            revbtn.Enabled = true;
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

        public void readexpenses()
        {
            try
            {
                aconn.Open();
                adap = new MySqlDataAdapter("select * from expenses order by eid desc", aconn);
                dt = new DataTable();
                adap.Fill(dt);
                aconn.Close();
                bsource = new BindingSource();
                bsource.DataSource = dt;


            }
            catch (Exception ex)
            {
                aconn.Close();
                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }

        public void readmoneypool()
        {
            try { 
            aconn.Open();
            adap = new MySqlDataAdapter("select * from moneypool order by mid desc", aconn);
            dt = new DataTable();
            adap.Fill(dt);
            aconn.Close();
            bsource = new BindingSource();
            bsource.DataSource = dt;
        }
            catch (Exception ex)
            {
                aconn.Close();
                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }

        public void readbank()
        {try {
            aconn.Open();
            adap = new MySqlDataAdapter("select * from bankdetails order by bid desc", aconn);
            dt = new DataTable();
            adap.Fill(dt);
            aconn.Close();
            bsource = new BindingSource();
            bsource.DataSource = dt;
        }
            catch (Exception ex)
            {
                aconn.Close();
                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }

        public void readmisc()
        {try { 
            aconn.Open();
            adap = new MySqlDataAdapter("select * from misc order by mid desc", aconn);
            dt = new DataTable();
            adap.Fill(dt);
            aconn.Close();
            bsource = new BindingSource();
            bsource.DataSource = dt;
        }
            catch (Exception ex)
            {
                aconn.Close();
                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }

        public void readbilling()
        {try { 
            aconn.Open();
            adap = new MySqlDataAdapter("select * from billing order by orderid desc", aconn);
            dt = new DataTable();
            adap.Fill(dt);
            aconn.Close();
            bsource = new BindingSource();
            bsource.DataSource = dt;
            

            //aconn.Open();
            //cmd = new MySqlCommand("select count(bid) from billing", aconn);
            //dr = cmd.ExecuteReader();
            //dr.Read();
            //total =  dr[0].ToString();
            
            aconn.Close();
        }
            catch (Exception ex)
            {
                aconn.Close();

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }

        public void readdeliveries()
        {try { 
            aconn.Open();
            adap = new MySqlDataAdapter("select * from deliveries where status='delivered' order by orderid desc", aconn);
            dt = new DataTable();
            adap.Fill(dt);
            aconn.Close();
            bsource = new BindingSource();
            bsource.DataSource = dt;
           

            //aconn.Open();
            //cmd = new MySqlCommand("select count(did) from deliveries where status='delivered'", aconn);
            //dr = cmd.ExecuteReader();
            //dr.Read();
            //total= dr[0].ToString();
            
            aconn.Close();
        }
            catch (Exception ex)
            {
                aconn.Close();
                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }

        public void readdealings()
        {try { 
            aconn.Open();
            adap = new MySqlDataAdapter("select did,orderid,suppliername,productid,productname,amount,count,dealerprice,pickupdate from dealing order by orderid desc", aconn);
            dt = new DataTable();
            adap.Fill(dt);
            aconn.Close();
            bsource = new BindingSource();
            bsource.DataSource = dt;
           

            aconn.Open();
            cmd = new MySqlCommand("select sum(count) from dealing", aconn);
            dr = cmd.ExecuteReader();
            dr.Read();
            total= dr[0].ToString();
            
            aconn.Close();
        }
            catch (Exception ex)
            {
                aconn.Close();
                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }

        
        public void readrevenue()
        {try { 
            aconn.Open();
            adap = new MySqlDataAdapter("select * from revenue", aconn);
            dt = new DataTable();
            adap.Fill(dt);
            aconn.Close();
            bsource = new BindingSource();
            bsource.DataSource = dt;
            

            //aconn.Open();
            //cmd = new MySqlCommand("SELECT date FROM lalchowk_ac.deliveries ORDER BY orderid DESC LIMIT 1;", aconn);
            //dr = cmd.ExecuteReader();
            //dr.Read();
            
            //date = dr[0].ToString();           
            //month = date.Substring(3, 2);
            //aconn.Close();
        }
            catch (Exception ex)
            {
                aconn.Close();
                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }

        }


        private void readdetails()
        {
            try { 
            aconn.Open();
            cmd = new MySqlCommand("select sum(amount)-3000 from moneypool",aconn);
            dr = cmd.ExecuteReader();
            dr.Read();
            moneylbl.Text = "Total Money pooled: Rs. " + dr[0].ToString(); 
            aconn.Close();

            aconn.Open();
            cmd = new MySqlCommand("select sum(amount) from expenses", aconn);
            dr = cmd.ExecuteReader();
            dr.Read();
            costlbl.Text = "Total Cost spent: Rs. " + dr[0].ToString();
            aconn.Close();

            //aconn.Open();
            //cmd = new MySqlCommand(" SELECT balance FROM expenses ORDER BY eid DESC LIMIT 1", aconn);
            //dr = cmd.ExecuteReader();
            //dr.Read();
            //ballbl.Text = "Balance in hand: Rs. " + dr[0].ToString();
            //aconn.Close();

            //aconn.Open();
            //cmd = new MySqlCommand(" SELECT closingbal FROM bankdetails ORDER BY bid DESC LIMIT 1", aconn);
            //dr = cmd.ExecuteReader();
            //dr.Read();
            //banklbl.Text = "Bank balance: Rs. " + dr[0].ToString();
            //aconn.Close();
        }
            catch (Exception ex)
            {
                aconn.Close();
                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }

       
        private void expbtn_Click(object sender, EventArgs e)
        {
            rev = false;
            panelhide();
            btndisable();
            bgworker.RunWorkerAsync();

            
            fsuptxt.Visible = false;
            fsuplbl.Visible = false;
            pboxtxt.Visible = false;
            splbl.Visible = false;
            countlbl.Visible = false;
            exppnl.Visible = true;
            moneypnl.Visible = false;
            bankpnl.Visible = false;
            miscpnl.Visible = false;
            billpnl.Visible = false;
            delpnl.Visible = false;
            rpnl.Visible = false;
            dealpnl.Visible = false;
            totallbl.Visible = false;
        }

        private void bgworker2_DoWork(object sender, DoWorkEventArgs e)
        {
            readmoneypool();
        }

        private void bgworker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnenable();
            panelshow();
            accountdataview.DataSource = bsource;
            try
            {
               
                    accountdataview.Columns.Remove("Details");
                
            }
            catch { };


        }
        private void loadingshow()
        {
            loadingaccpic.Visible = true;
            loadinglbl.Visible = true;
        }

        private void moneybtn_Click(object sender, EventArgs e)
        {
            rev = false;
            panelhide();
            loadingshow();
            btndisable();
            bgworker2.RunWorkerAsync();
            
            fsuptxt.Visible = false;
            fsuplbl.Visible = false;
            pboxtxt.Visible = false;
            splbl.Visible = false;
            countlbl.Visible = false;
            moneypnl.Visible = true;
            exppnl.Visible = false;
            bankpnl.Visible = false;
            miscpnl.Visible = false;
            rpnl.Visible = false;
            billpnl.Visible = false;
            delpnl.Visible = false;
            dealpnl.Visible = false;
            totallbl.Visible = false;
        }

        private void bgworker3_DoWork(object sender, DoWorkEventArgs e)
        {
            readbank();
        }

        private void bgworker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnenable();
            panelshow();
            accountdataview.DataSource = bsource;
            try
            {
                accountdataview.Columns.Remove("Details");
            }
            catch { }
        }

        private void bankbtn_Click(object sender, EventArgs e)
        {
            rev = false;
            panelhide();
            loadingshow();
            btndisable();
            bgworker3.RunWorkerAsync();

            fsuptxt.Visible = false;
            fsuplbl.Visible = false;
            pboxtxt.Visible = false;
            splbl.Visible = false;
            countlbl.Visible = false;
            bankpnl.Visible = true;
            moneypnl.Visible = false;
            exppnl.Visible = false;
            miscpnl.Visible = false;
            rpnl.Visible = false;
            billpnl.Visible = false;
            delpnl.Visible = false;
            dealpnl.Visible = false;
            totallbl.Visible = false;
        }



        private void bgworker4_DoWork(object sender, DoWorkEventArgs e)
        {
            readmisc();
        }

        private void bgworker4_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnenable();
            panelshow();
            accountdataview.DataSource = bsource;
            try
            {
                accountdataview.Columns.Remove("Details");
            }
            catch { }
        }
        private void miscbtn_Click(object sender, EventArgs e)
        {
            rev = false;
            panelhide();
            loadingshow();
            btndisable();
            bgworker4.RunWorkerAsync();

            fsuptxt.Visible = false;
            fsuplbl.Visible = false;
            pboxtxt.Visible = false;
            splbl.Visible = false;
            countlbl.Visible = false;
            miscpnl.Visible = true;
            bankpnl.Visible = false;
            moneypnl.Visible = false;
            exppnl.Visible = false;
            rpnl.Visible = false;
            billpnl.Visible = false;
            delpnl.Visible = false;
            dealpnl.Visible = false;
            totallbl.Visible = false;
        }


        private void updatebtn_Click(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(datetxt.Text, @"^([0-9-]+)$") && datetxt.Text != "")
            {

                MessageBox.Show("Please enter date in the following format DD-MM-YYYY");

            }
            else
            {

                try
                {
                    aconn.Open();
                    mysqlcmd = new MySqlCommand("insert into expenses(`item`, `amount`, `purchasedate`,`reason`) values ('" + itemtxt.Text + "','" + amounttxt.Text + "','" + datetxt.Text + "','" + reasontxt1.Text + "')", aconn);
                    mysqlcmd.ExecuteNonQuery();
                    MessageBox.Show("Entry added.");
                    aconn.Close();
                    itemtxt.Text = "";
                    amounttxt.Text = "";
                    datetxt.Text = "";

                    reasontxt1.Text = "";

                    readexpenses();
                    accountdataview.DataSource = bsource;

                }
                catch (Exception ex)
                {
                    aconn.Close();
                    MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
                }

            }
        }

        private void addbtn_Click(object sender, EventArgs e)
        {try { 
            aconn.Open();
            mysqlcmd = new MySqlCommand("INSERT INTO moneypool(`name`, `amount`, `pooldate`, `reason`, `entry_by`) VALUES ('"+nametxt.Text+"', '"+amounttxt2.Text+"', '"+datetxt2.Text+"', '"+reasontxt.Text+"', 'haseeb')", aconn);
            mysqlcmd.ExecuteNonQuery();
            MessageBox.Show("Entry added.");
            aconn.Close();
            nametxt.Text = "";
            amounttxt2.Text = "";
            datetxt2.Text = "";
            reasontxt.Text = "";
            readmoneypool();
            accountdataview.DataSource = bsource;
        }
            catch (Exception ex)
            {
                aconn.Close();
                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }

        private void addmbtn_Click(object sender, EventArgs e)
        {try { 
            aconn.Open();
            mysqlcmd = new MySqlCommand("insert into misc(`name`, `amount`,`reason`) values ('" + nametxt4.Text + "','" + amounttxt4.Text + "','" + reasontxt4.Text + "')",aconn);
            mysqlcmd.ExecuteNonQuery();
            MessageBox.Show("Entry added.");
            aconn.Close();
            nametxt4.Text = "";
            amounttxt4.Text = "";
            reasontxt4.Text = "";
            readmisc();
            accountdataview.DataSource = bsource;
        }
            catch (Exception ex)
            {
                aconn.Close();
                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }

        private void addbbtn_Click(object sender, EventArgs e)
        {try { 
            aconn.Open();
            mysqlcmd = new MySqlCommand("insert into bankdetails(`date`, `openingbal`, `closingbal`,`reason`) values ('" + datetxt3.Text + "','" + obaltxt.Text + "','" + cbaltxt.Text + "','" + reasontxt2.Text + "')",aconn);
            mysqlcmd.ExecuteNonQuery();
            MessageBox.Show("Entry added.");
            aconn.Close();
            datetxt3.Text = "";
            obaltxt.Text = "";
            cbaltxt.Text = "";
            reasontxt2.Text = "";
            readbank();
            accountdataview.DataSource = bsource;
        }
            catch (Exception ex)
            {
                aconn.Close();
                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }

        private void bgworker5_DoWork(object sender, DoWorkEventArgs e)
        {
            readbilling();
        }

        private void bgworker5_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnenable();
            panelshow();
            accountdataview.DataSource = bsource;
            try
            {
                accountdataview.Columns.Remove("Details");
            }
            catch { }
            //try
            //{
            //    if (rev==false) {
            //        accountdataview.Columns["Details"].Visible = false;
            //}
            //}
            //catch(Exception ex) { MessageBox.Show(ex.Message+"here2"); }
            totallbl.Text = "Total bills: " + accountdataview.RowCount ;
            totallbl.Visible = true;
        }


        private void billbtn_Click(object sender, EventArgs e)
        {

            rev = false;
            panelhide();
            loadingshow();
            btndisable();
            bgworker5.RunWorkerAsync();

            fsuptxt.Visible = false;
            fsuplbl.Visible = false;
            pboxtxt.Visible = false;
            splbl.Visible = false;
            countlbl.Visible = false;
            billpnl.Visible = true;
            dealpnl.Visible = false;           
            miscpnl.Visible = false;
            bankpnl.Visible = false;
            moneypnl.Visible = false;
            exppnl.Visible = false;
            delpnl.Visible = false;
            rpnl.Visible = false;
        }

        private void billaddbtn_Click(object sender, EventArgs e)
        {try { 
            aconn.Open();
            mysqlcmd = new MySqlCommand("insert into billing(`orderid`, `user`, `amount`,`deliverydate`,`billno`) values ('" + otxt.Text + "','" + utxt.Text + "','" + atxt.Text + "','" + dtxt.Text + "','bill" + btxt.Text + "')", aconn);
            mysqlcmd.ExecuteNonQuery();
            MessageBox.Show("Entry added.");
            aconn.Close();
            atxt.Text = "";
            btxt.Text = "";
            dtxt.Text = "";
            utxt.Text = "";
            otxt.Text = "";
            readbilling();
            accountdataview.DataSource = bsource;
        }
            catch (Exception ex)
            {
                aconn.Close();
                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }

        private void bgworker6_DoWork(object sender, DoWorkEventArgs e)
        {
            readdeliveries();
        }

        private void bgworker6_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnenable();
            panelshow();
            accountdataview.DataSource = bsource;
            try
            {
                accountdataview.Columns.Remove("Details");
            }
            catch { }
            totallbl.Text = "Total deliveries: " + accountdataview.RowCount;
            totallbl.Visible = true;
        }

        private void delbtn_Click(object sender, EventArgs e)
        {
            rev = false;
            panelhide();
            loadingshow();
            btndisable();
            bgworker6.RunWorkerAsync();

            fsuptxt.Visible = false;
            fsuplbl.Visible = false;
            pboxtxt.Visible = false;
            splbl.Visible = false;
            countlbl.Visible = false;
            delpnl.Visible = true;
            dealpnl.Visible = false;
            exppnl.Visible = false;
            moneypnl.Visible = false;
            bankpnl.Visible = false;
            miscpnl.Visible = false;
            billpnl.Visible = false;
            rpnl.Visible = false;

        }

        private void adddbtn_Click(object sender, EventArgs e)
        {try { 
            aconn.Open();
            mysqlcmd = new MySqlCommand("insert into deliveries(`orderid`, `email`, `amount`,`status`) values ('" + otxt2.Text + "','" + etxt2.Text + "','" + atxt2.Text + "','" + stxt.Text + "')", aconn);
            mysqlcmd.ExecuteNonQuery();
            MessageBox.Show("Entry added.");
            aconn.Close();
            otxt2.Text = "";
            etxt2.Text = "";
            atxt2.Text = "";
            stxt.Text = "";
            
            readdeliveries();
            accountdataview.DataSource = bsource;
        }
            catch (Exception ex)
            {
                aconn.Close();
                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }

        private void bgworker7_DoWork(object sender, DoWorkEventArgs e)
        {
            readdealings();
        }

        private void bgworker7_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnenable();
            panelshow();
            accountdataview.DataSource = bsource;
            try
            {
                accountdataview.Columns.Remove("Details");
            }
            catch { }
            totallbl.Text = "Total dealings: " + total; //+ accountdataview.RowCount;
            totallbl.Visible = true;
        }

        private void dealbtn_Click(object sender, EventArgs e)
        {
            rev = false;
            panelhide();
            loadingshow();
            btndisable();
            bgworker7.RunWorkerAsync();

            fsuptxt.Visible = true;
            fsuplbl.Visible = true;
            pboxtxt.Visible = true;
            splbl.Visible = true;
            dealpnl.Visible = true;
            delpnl.Visible = false;
            exppnl.Visible = false;
            moneypnl.Visible = false;
            bankpnl.Visible = false;
            miscpnl.Visible = false;
            billpnl.Visible = false;
            rpnl.Visible = false;
        }

        private void dealaddbtn_Click(object sender, EventArgs e)
        {
            try { 
            if (yes.Checked)
            {
                aconn.Open();
                mysqlcmd = new MySqlCommand("insert into dealing(`supplierid`, `suppliername`, `productid`,`productname`,`size`,`count`,`amount`,`pickupdate`,`paymentdone`,`paymentdate`,`comments`) values ('" + suptxt.Text + "','" + supnametxt.Text + "','" + proidtxt.Text + "','" + pronametxt.Text + "','" + sizetxt.Text + "','" + counttxt.Text + "','" + atxt3.Text + "','" + pickuptxt.Text + "','1','" + paymentdatetxt.Text + "','" + commentstxt.Text + "')", aconn);
                mysqlcmd.ExecuteNonQuery();
                MessageBox.Show("Entry added.");
                aconn.Close();
            }
            else
            {
                aconn.Open();
                mysqlcmd = new MySqlCommand("insert into dealing(`supplierid`, `suppliername`, `productid`,`productname`,`size`,`count`,`amount`,`pickupdate`,`paymentdone`,`paymentdate`,`comments`) values ('" + suptxt.Text + "','" + supnametxt.Text + "','" + proidtxt.Text + "','" + pronametxt.Text + "','" + sizetxt.Text + "','" + counttxt.Text + "','" + atxt3.Text + "','" + pickuptxt.Text + "','0','" + paymentdatetxt.Text + "','" + commentstxt.Text + "')", aconn);
                mysqlcmd.ExecuteNonQuery();
                MessageBox.Show("Entry added.");
                aconn.Close();
            }
            suptxt.Text = "";
            supnametxt.Text = "";
            proidtxt.Text = "";
            pronametxt.Text = "";
            sizetxt.Text = "";
            counttxt.Text = "";
            atxt3.Text = "";
            pickuptxt.Text = "";
            paymentdatetxt.Text = "";
            paymentdatetxt.Text = "";
            commentstxt.Text = "";
            readdealings();
            accountdataview.DataSource = bsource;
                accountdataview.Columns["Details"].Visible = false;
        }
            catch (Exception ex)
            {
                aconn.Close();
                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }

        private void yes_CheckedChanged(object sender, EventArgs e)
        {
            if (yes.Checked)
                no.Checked = false;
        }

        private void no_CheckedChanged(object sender, EventArgs e)
        {
            if (no.Checked)
                yes.Checked = false;
        }

       

        private void refresh_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            readdetails();
            Cursor = Cursors.Arrow;
        }

        private void fsuptxt_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = string.Format("suppliername LIKE '%{0}%'", fsuptxt.Text);
            accountdataview.DataSource = dv;
        }

        
        private void bgworker8_DoWork(object sender, DoWorkEventArgs e)
        {
            try { 
            readrevenue();
            

            }
            catch (Exception ex)
            {
                aconn.Close();
                
                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }

        
        private void bgworker8_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnenable();
            panelshow();
           
            accountdataview.DataSource = bsource;
            try
            {
                accountdataview.Columns.Remove("Details");
            }
            catch { }
            DataGridViewButtonColumn accdetails = new DataGridViewButtonColumn();
            accdetails.UseColumnTextForButtonValue = true;
            accdetails.Name = "Details";
            accdetails.DataPropertyName = "View";
            accdetails.Text = "View";
            accountdataview.Columns.Add(accdetails);

        }

        private void ticketbtn_Click(object sender, EventArgs e)
        {
            ticketlbl.Visible = false;
            Cursor = Cursors.WaitCursor;
            int amount, count;
            try {

                aconn.Open();
                cmd = new MySqlCommand("select count(did) from deliveries where status='delivered'", aconn);
                dr = cmd.ExecuteReader();
                dr.Read();
                count = int.Parse(dr[0].ToString());

                aconn.Close();

                aconn.Open();
                cmd = new MySqlCommand("select sum(amount) from deliveries where status='delivered'", aconn);
                dr = cmd.ExecuteReader();
                dr.Read();
                amount = int.Parse(dr[0].ToString());

                aconn.Close();



                ticketlbl.Visible = true;
                ticketlbl.Text = "Total orders delivered: "+count+", amounts to: "+amount+"\nTicket size: Rs. "+(amount / count).ToString();

            }
            catch(Exception ex) {

                MessageBox.Show(ex.Message);
                ticketlbl.Visible = false;
            }
            Cursor = Cursors.Arrow;
        }

        private void accountdataview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try {
                
                if (rev)
                {
                    
                    if(e.ColumnIndex ==12)
                    {
                        string month = accountdataview.Rows[e.RowIndex].Cells["month"].Value.ToString();
                      
                        int year= int.Parse(accountdataview.Rows[e.RowIndex].Cells["year"].Value.ToString());
                        string petrol = accountdataview.Rows[e.RowIndex].Cells["petrol_cost"].Value.ToString();
                        string purchase = accountdataview.Rows[e.RowIndex].Cells["purchase_cost"].Value.ToString();
                        string sale = accountdataview.Rows[e.RowIndex].Cells["sale"].Value.ToString();
                        string profit = accountdataview.Rows[e.RowIndex].Cells["profit"].Value.ToString();
                      
                        string mon="";
                        switch (month)
                        {
                            case "January":
                                mon = "01";
                                break;
                            case "February":
                                mon="02";
                               
                                break;
                            case "March":
                                mon="03";
                                break;
                            case "April":
                                mon="04";
                                break;
                            case "May":
                                mon="05";
                                break;
                            case "June":
                                mon="06";
                                break;
                            case "July":
                                mon="07";
                                break;
                            case "August":
                                mon="08";
                                break;
                            case "September":
                                mon="09";
                                break;
                            case "October":
                                mon="10";
                                break;
                            case "November":
                                mon="11";
                                break;
                            case "December":
                                mon="12";
                                break;
                            default:
                                mon = "02";                             
                                break;
                        }
                        
                        revdetails rev = new revdetails(mon +"-"+ year,petrol,purchase,sale,profit);
                        rev.Show();
                       
                    }
                }

            }
            catch {


            }
        }


        int sale, purchase, invest, order,medp,giftch,meds,medo,shipping,medsh;

        private void pboxtxt_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = string.Format("productname LIKE '%{0}%'", pboxtxt.Text);
            accountdataview.DataSource = dv;

            countlbl.Text = "Row Count: " + (accountdataview.RowCount - 1).ToString();
            countlbl.Visible = true;
        }

        private void revgobtn_Click(object sender, EventArgs e)
        {
            revdetpnl.Visible = false;
            Cursor = Cursors.WaitCursor;
           
                string mon = "";
                switch (mbox.Text)
                {
                    case "January":
                        mon = "01";
                        break;
                    case "February":
                        mon = "02";

                        break;
                    case "March":
                        mon = "03";
                        break;
                    case "April":
                        mon = "04";
                        break;
                    case "May":
                        mon = "05";
                        break;
                    case "June":
                        mon = "06";
                        break;
                    case "July":
                        mon = "07";
                        break;
                    case "August":
                        mon = "08";
                        break;
                    case "September":
                        mon = "09";
                        break;
                    case "October":
                        mon = "10";
                        break;
                    case "November":
                        mon = "11";
                        break;
                    case "December":
                        mon = "12";
                        break;
                    default:
                        mon = "02";
                        break;
                }

                string date =mon + "-" + ybox.Text;
            string datemed = ybox.Text + "-" + mon;


                BackgroundWorker revd = new BackgroundWorker();
                revd.DoWork += (a, b) =>
                {
                    try
                    {
                        aconn.Open();
                        cmd = new MySqlCommand(" SELECT sum(amount),sum(shipping) from deliveries where status='delivered' and date like '%-" + date + "'", aconn); //" + mbox.Text + "-" + ybox.Text + "'     
                        dr = cmd.ExecuteReader();
                        dr.Read();
                        sale = int.Parse(dr[0].ToString());
                        shipping = int.Parse(dr[1].ToString());
                        aconn.Close();
                   //     MessageBox.Show(sale.ToString());


                        aconn.Open();
                        cmd = new MySqlCommand(" SELECT sum(dealerprice*count) from dealing where pickupdate like '%-" + date + "'", aconn); //' %-" + month + "-2018'
                        dr = cmd.ExecuteReader();
                        dr.Read();
                        purchase = int.Parse(dr[0].ToString());
                        aconn.Close();

                        try
                        {
                            aconn.Open();
                            cmd = new MySqlCommand(" SELECT sum(amount) from expenses where purchasedate like '%-" + date + "'", aconn);
                            dr = cmd.ExecuteReader();
                            dr.Read();
                            invest = int.Parse(dr[0].ToString());
                            aconn.Close();
                        }
                        catch { }

                        aconn.Open();
                        cmd = new MySqlCommand(" SELECT count(did) from deliveries where date like '%-" + date + "'", aconn); //" + month + "
                        dr = cmd.ExecuteReader();
                        dr.Read();
                        order = int.Parse(dr[0].ToString());
                        aconn.Close();

                        dr = obj.Query("SELECT sum(giftcharges) from orders where status='Delivered' and deliverdate like '" + datemed + "-%'");
                        dr.Read();
                        giftch = int.Parse(dr[0].ToString());
                        obj.closeConnection();


                        dr = obj.Query("SELECT sum(dp),sum(amount),count(orderid),sum(shipping) from medorders where status='Delivered' and deliverdate like '" + datemed + "-%'");
                        dr.Read();
                        
                        if (dr[0].ToString() == null || dr[0].ToString() == "")
                        {
                            medp = 0;
                        }
                        else
                            medp = int.Parse(dr[0].ToString());
                       
                        if (dr[1].ToString() == null || dr[1].ToString() == "")
                        {
                            meds = 0;
                        }
                        else                          
                        meds = int.Parse(dr[1].ToString());
                        if (dr[2].ToString() == null || dr[2].ToString() == "")
                        {
                            medo = 0;
                        }
                        else
                            medo = int.Parse(dr[2].ToString());
                        if (dr[3].ToString() == null || dr[3].ToString() == "")
                        {
                            medsh = 0;
                        }
                        else
                            medsh = int.Parse(dr[3].ToString());
                        obj.closeConnection();
                        //  MessageBox.Show(medp.ToString());



                    }
                    catch (Exception ex) { obj.closeConnection(); MessageBox.Show(ex.ToString()); }
                   
                };
                revd.RunWorkerCompleted += (a, c) => 
                {

                    try
                    {
                       
                        salebox.Text = (sale+meds+giftch).ToString();
                        purchasebox.Text = (purchase+medp).ToString();
                        investbox.Text = invest.ToString();                    
                        orlbl.Text = (order+medo).ToString();
                        shiptxt.Text = (shipping+medsh).ToString();
                        
                            profitbox.Text = (int.Parse(salebox.Text) - int.Parse(purchasebox.Text)).ToString();

                        //  MessageBox.Show("Please check for the correct date in deliveries and dealings.");

                        monlbl.Text = mbox.Text +" "+ ybox.Text;
                        
                        
                        revdetpnl.Visible = true;
                    }
                    catch(Exception ex) { MessageBox.Show(ex.ToString()); revdetpnl.Visible = false; MessageBox.Show("Please select the correct date.","Error!"); }
                    
                    Cursor = Cursors.Arrow;
                };
                revd.RunWorkerAsync();
               


           
        }

        bool rev = false;
        private void revbtn_Click(object sender, EventArgs e)
        {

            ybox.DisplayMember = "Text";
            var years = new[]
            {
                new {Text="2017"},
                new {Text="2018"},
                new {Text ="2019"},
                 new {Text ="2020"},
                 new {Text ="2021"},
                };
            ybox.DataSource = years;


            mbox.DisplayMember = "Text";
            var months = new[]
            {
                new {Text="January"},
                new {Text ="February"},
                new {Text="March"},
                new {Text ="April"},
                new {Text="May"},
                new {Text ="June"},
                new {Text="July"},
                new {Text ="August"},
                new {Text="September"},
                new {Text ="October"},
                new {Text="November"},
                new {Text ="December"},
                };
            mbox.DataSource = months;



            rev = true;
            panelhide();
            loadingshow();
            btndisable();
            bgworker8.RunWorkerAsync();

            fsuptxt.Visible = false;
            fsuplbl.Visible = false;
            rpnl.Visible = true;
            delpnl.Visible = false;
            dealpnl.Visible = false;
            exppnl.Visible = false;
            moneypnl.Visible = false;
            bankpnl.Visible = false;
            miscpnl.Visible = false;
            billpnl.Visible = false;
            totallbl.Visible = false;

            


        }

       

        private void addrbtn_Click(object sender, EventArgs e)
        {try { 
            aconn.Open();
            mysqlcmd = new MySqlCommand("insert into revenue(`month`, `year`,`sale`,`profit`,`invested`,`reason`,`gross_profit`,`purchase_cost`,`orders`,`shipping_taken`,`petrol_cost`) values ('" + monthtxt.Text + "','" + yeartxt.Text + "','" + saletxt.Text + "','" + profittxt.Text + "','"+investedtxt.Text+"','"+ireasontxt.Text+"','"+gprofittxt.Text+"','"+pcosttxt.Text+"','"+ordtxt.Text+"','"+shiptxt.Text+"','"+petroltxt.Text+"')", aconn);
            mysqlcmd.ExecuteNonQuery();
            MessageBox.Show("Entry added.");
            aconn.Close();
            monthtxt.Text = "";
            yeartxt.Text = "";
            saletxt.Text = "";
            profittxt.Text = "";
            investedtxt.Text = "";
            ireasontxt.Text = "";
            gprofittxt.Text = "";
            pcosttxt.Text = "";
            ordtxt.Text = "";
                petroltxt.Text = "";

                readrevenue();
            accountdataview.DataSource = bsource;
        }
            catch (Exception ex)
            {
                aconn.Close();
                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }



        private void investedtxt_TextChanged(object sender, EventArgs e)
        {
            if (investedtxt.Text == "")
            {
                Focus();
            }
            else if (pcosttxt.Text == "")
            {
                Focus();
            }
            else
            {
                try
                {
                    gprofittxt.Text = (int.Parse(profittxt.Text) - int.Parse(investedtxt.Text)).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }       
        }

        private void pcosttxt_TextChanged(object sender, EventArgs e)
        {
            if (saletxt.Text == "")
            {
                Focus();
            }
            else if (pcosttxt.Text == "")
            {
                Focus();
            }
            else
            {
                try
                {
                    profittxt.Text = (int.Parse(saletxt.Text) - int.Parse(pcosttxt.Text) + int.Parse(shiptxt.Text)).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
          
         }


        private void updbtn_Click(object sender, EventArgs e)
        {
            try
            {
                cmdbl = new MySqlCommandBuilder(adap);
                adap.Update(dt);
                MessageBox.Show("Entry Updated.");

            }
            catch (Exception ex)
            {

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }

        
    }
}
