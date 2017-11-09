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
    public partial class accounts : Form
    {
        DBConnect obj = new DBConnect();
        MySqlConnection con;
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
            accountdataview.DataSource = bsource;
            baltxt.Text = bal;
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
        }

        private void btndisable()
        {
            expbtn.Enabled = false;
            moneybtn.Enabled = false;
            bankbtn.Enabled = false;
            miscbtn.Enabled = false;
            billbtn.Enabled = false;
            dealbtn.Enabled = false;
            delbtn.Enabled = false;
            revbtn.Enabled = false;
        }

        private void btnenable()
        {
            expbtn.Enabled = true;
            moneybtn.Enabled = true;
            bankbtn.Enabled = true;
            miscbtn.Enabled = true;
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
                adap = new MySqlDataAdapter("select * from expenses", aconn);
                dt = new DataTable();
                adap.Fill(dt);
                aconn.Close();
                bsource = new BindingSource();
                bsource.DataSource = dt;


                aconn.Open();
                cmd = new MySqlCommand("SELECT balance FROM lalchowk_ac.expenses order by eid desc limit 1", aconn);
                dr = cmd.ExecuteReader();
                dr.Read();
                bal = dr[0].ToString();
                aconn.Close();
            }
            catch (Exception ex)
            {
               
                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }

        public void readmoneypool()
        {
            try { 
            aconn.Open();
            adap = new MySqlDataAdapter("select * from moneypool", aconn);
            dt = new DataTable();
            adap.Fill(dt);
            aconn.Close();
            bsource = new BindingSource();
            bsource.DataSource = dt;
        }
            catch (Exception ex)
            {

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }

        public void readbank()
        {try {
            aconn.Open();
            adap = new MySqlDataAdapter("select * from bankdetails", aconn);
            dt = new DataTable();
            adap.Fill(dt);
            aconn.Close();
            bsource = new BindingSource();
            bsource.DataSource = dt;
        }
            catch (Exception ex)
            {

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }

        public void readmisc()
        {try { 
            aconn.Open();
            adap = new MySqlDataAdapter("select * from misc", aconn);
            dt = new DataTable();
            adap.Fill(dt);
            aconn.Close();
            bsource = new BindingSource();
            bsource.DataSource = dt;
        }
            catch (Exception ex)
            {

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }

        public void readbilling()
        {try { 
            aconn.Open();
            adap = new MySqlDataAdapter("select * from billing", aconn);
            dt = new DataTable();
            adap.Fill(dt);
            aconn.Close();
            bsource = new BindingSource();
            bsource.DataSource = dt;
            

            aconn.Open();
            cmd = new MySqlCommand("select count(bid) from billing", aconn);
            dr = cmd.ExecuteReader();
            dr.Read();
            total =  dr[0].ToString();
            
            aconn.Close();
        }
            catch (Exception ex)
            {

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }

        public void readdeliveries()
        {try { 
            aconn.Open();
            adap = new MySqlDataAdapter("select * from deliveries", aconn);
            dt = new DataTable();
            adap.Fill(dt);
            aconn.Close();
            bsource = new BindingSource();
            bsource.DataSource = dt;
           

            aconn.Open();
            cmd = new MySqlCommand("select count(did) from deliveries", aconn);
            dr = cmd.ExecuteReader();
            dr.Read();
            total= dr[0].ToString();
            
            aconn.Close();
        }
            catch (Exception ex)
            {

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }

        public void readdealings()
        {try { 
            aconn.Open();
            adap = new MySqlDataAdapter("select * from dealing", aconn);
            dt = new DataTable();
            adap.Fill(dt);
            aconn.Close();
            bsource = new BindingSource();
            bsource.DataSource = dt;
           

            aconn.Open();
            cmd = new MySqlCommand("select count(did) from dealing", aconn);
            dr = cmd.ExecuteReader();
            dr.Read();
            total= dr[0].ToString();
            
            aconn.Close();
        }
            catch (Exception ex)
            {

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
            

            aconn.Open();
            cmd = new MySqlCommand("SELECT date FROM lalchowk_ac.deliveries ORDER BY did DESC LIMIT 1;", aconn);
            dr = cmd.ExecuteReader();
            dr.Read();
            
            date = dr[0].ToString();           
            month = date.Substring(3, 2);
            aconn.Close();
        }
            catch (Exception ex)
            {

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

            aconn.Open();
            cmd = new MySqlCommand(" SELECT balance FROM expenses ORDER BY eid DESC LIMIT 1", aconn);
            dr = cmd.ExecuteReader();
            dr.Read();
            ballbl.Text = "Balance in hand: Rs. " + dr[0].ToString();
            aconn.Close();

            aconn.Open();
            cmd = new MySqlCommand(" SELECT closingbal FROM bankdetails ORDER BY bid DESC LIMIT 1", aconn);
            dr = cmd.ExecuteReader();
            dr.Read();
            banklbl.Text = "Bank balance: Rs. " + dr[0].ToString();
            aconn.Close();
        }
            catch (Exception ex)
            {

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }

       
        private void expbtn_Click(object sender, EventArgs e)
        {
            panelhide();
            btndisable();
            bgworker.RunWorkerAsync();

            
            fsuptxt.Visible = false;
            fsuplbl.Visible = false;
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
            

        }
        private void loadingshow()
        {
            loadingaccpic.Visible = true;
            loadinglbl.Visible = true;
        }

        private void moneybtn_Click(object sender, EventArgs e)
        {
            panelhide();
            loadingshow();
            btndisable();
            bgworker2.RunWorkerAsync();
            
            fsuptxt.Visible = false;
            fsuplbl.Visible = false;
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
        }

        private void bankbtn_Click(object sender, EventArgs e)
        {

            panelhide();
            loadingshow();
            btndisable();
            bgworker3.RunWorkerAsync();

            fsuptxt.Visible = false;
            fsuplbl.Visible = false;
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
        }
        private void miscbtn_Click(object sender, EventArgs e)
        {

            panelhide();
            loadingshow();
            btndisable();
            bgworker4.RunWorkerAsync();

            fsuptxt.Visible = false;
            fsuplbl.Visible = false;
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
        {try { 
            aconn.Open();
            mysqlcmd = new MySqlCommand ("insert into expenses(`item`, `amount`, `purchasedate`,`balance`,`reason`) values ('" + itemtxt.Text + "','"+amounttxt.Text+"','"+datetxt.Text+"','"+baltxt.Text+"','"+reasontxt1.Text+"')",aconn);
            mysqlcmd.ExecuteNonQuery();
            MessageBox.Show("Entry added.");
            aconn.Close();
            itemtxt.Text = "";
            amounttxt.Text="";
            datetxt.Text = "";
            
            reasontxt1.Text = "";
            
            readexpenses();
            accountdataview.DataSource = bsource;
            baltxt.Text = bal;
        }
            catch (Exception ex)
            {

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
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
            totallbl.Text = "Total bills: " + total;
            totallbl.Visible = true;
        }


        private void billbtn_Click(object sender, EventArgs e)
        {


            panelhide();
            loadingshow();
            btndisable();
            bgworker5.RunWorkerAsync();

            fsuptxt.Visible = false;
            fsuplbl.Visible = false;
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
            totallbl.Text = "Total deliveries: " + total;
            totallbl.Visible = true;
        }

        private void delbtn_Click(object sender, EventArgs e)
        {

            panelhide();
            loadingshow();
            btndisable();
            bgworker6.RunWorkerAsync();

            fsuptxt.Visible = false;
            fsuplbl.Visible = false;
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
            totallbl.Text = "Total dealings: " + total;
            totallbl.Visible = true;
        }

        private void dealbtn_Click(object sender, EventArgs e)
        {

            panelhide();
            loadingshow();
            btndisable();
            bgworker7.RunWorkerAsync();

            fsuptxt.Visible = true;
            fsuplbl.Visible = true;
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
        }
            catch (Exception ex)
            {

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

        private void amounttxt_Leave(object sender, EventArgs e)
        {
            try {
                int amount = int.Parse(amounttxt.Text);
                int balance = int.Parse(baltxt.Text);
                baltxt.Text = (balance - amount).ToString();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
            aconn.Open();
            cmd = new MySqlCommand(" SELECT sum(amount) from deliveries where status='delivered' and date like '%-" + month + "-%'", aconn);
            dr = cmd.ExecuteReader();
            dr.Read();
            sale = dr[0].ToString();
            aconn.Close();

            aconn.Open();
            cmd = new MySqlCommand(" SELECT sum(dealerprice) from dealing where pickupdate like '%-" + month + "-%'", aconn);
            dr = cmd.ExecuteReader();
            dr.Read();
            purchase = dr[0].ToString();
            aconn.Close();

            aconn.Open();
            cmd = new MySqlCommand(" SELECT sum(amount) from expenses where purchasedate like '%-" + month + "-%'", aconn);
            dr = cmd.ExecuteReader();
            dr.Read();
            invest = dr[0].ToString();
            aconn.Close();
        }
            catch (Exception ex)
            {

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }

        private void bgworker8_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnenable();
            panelshow();
            accountdataview.DataSource = bsource;
            salebox.Text = sale;
            purchasebox.Text = purchase;
            investbox.Text = invest;
            try
            {
                profitbox.Text = (int.Parse(salebox.Text) - int.Parse(purchasebox.Text)).ToString();
            }
            catch
            {
                MessageBox.Show("Please check for the correct date in deliveries and dealings.");
            }
           
            switch (month)
            {
                case "01":
                    monlbl.Text = "January";
                    break;
                case "02":
                    monlbl.Text = "February";
                    break;
                case "03":
                    monlbl.Text = "March";
                    break;
                case "04":
                    monlbl.Text = "April";
                    break;
                case "05":
                    monlbl.Text = "May";
                    break;
                case "06":
                    monlbl.Text = "June";
                    break;
                case "07":
                    monlbl.Text = "July";
                    break;
                case "08":
                    monlbl.Text = "August";
                    break;
                case "09":
                    monlbl.Text = "September";
                    break;
                case "10":
                    monlbl.Text = "October";
                    break;
                case "11":
                    monlbl.Text = "November";
                    break;
                case "12":
                    monlbl.Text = "December";
                    break;
                default:
                    monlbl.Visible = false;
                    break;
            }
            
                   
        }

        string sale, purchase, invest;
        private void revbtn_Click(object sender, EventArgs e)
        {

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
            mysqlcmd = new MySqlCommand("insert into revenue(`month`, `year`,`sale`,`profit`,`invested`,`reason`,`gross_profit`,`purchase_cost`) values ('" + monthtxt.Text + "','" + yeartxt.Text + "','" + saletxt.Text + "','" + profittxt.Text + "','"+investedtxt.Text+"','"+ireasontxt.Text+"','"+gprofittxt.Text+"','"+pcosttxt.Text+"')", aconn);
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

            readrevenue();
            accountdataview.DataSource = bsource;
        }
            catch (Exception ex)
            {

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
                    profittxt.Text = (int.Parse(saletxt.Text) - int.Parse(pcosttxt.Text)).ToString();
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
