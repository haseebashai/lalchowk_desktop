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
    public partial class revdetails : Form
    {
        MySqlConnection aconn = new MySqlConnection("SERVER=182.50.133.78;DATABASE=lalchowk_ac;USER=lalchowkac;PASSWORD=Lalchowk@123uzmah");
        MySqlCommand cmd;
        DataTable dt,dt2;
        MySqlDataAdapter adap,adap2;
        BindingSource bsource,bsource2;
        MySqlDataReader dr;
        DBConnect obj = new DBConnect();

        public revdetails(string month,string petrol,string purchase, string sale, string profit)
        {
            InitializeComponent();
            string originalmonth = month;
            monthlydataview.DoubleBuffered(true);
            expensesview.DoubleBuffered(true);
            BackgroundWorker load = new BackgroundWorker();
            load.DoWork += (a, b) =>
            {
                string mon = month.Split('-')[0];
                string year = month.Split('-')[1];
                switch (mon)
                {
                    case "01":
                        month = "January";
                        break;
                    case "02":
                        month = "February";
                        break;
                    case "03":
                        month = "March";
                        break;
                    case "04":
                        month = "April";
                        break;
                    case "05":
                        month = "May";
                        break;
                    case "06":
                        month = "June";
                        break;
                    case "07":
                        month = "July";
                        break;
                    case "08":
                        month = "August";
                        break;
                    case "09":
                        month = "September";
                        break;
                    case "10":
                        month = "October";
                        break;
                    case "11":
                        month = "November";
                        break;
                    case "12":
                        month = "December";
                        break;
                    default:
                        break;
                }
                string headline = "Details for the month of " + month + " " + year;
                try
                {

                    aconn.Open();
                    adap = new MySqlDataAdapter("select * from deliveries where date like '%-" + originalmonth + "'", aconn);
                    dt = new DataTable();
                    adap.Fill(dt);
                    aconn.Close();
                    bsource = new BindingSource();
                    bsource.DataSource = dt;

                    object[] arg = { headline, bsource };
                    load.ReportProgress(10, arg);

                    aconn.Open();
                    adap2 = new MySqlDataAdapter("select item,amount,purchasedate,reason from expenses where purchasedate like '%-" + originalmonth + "'", aconn);
                    dt2 = new DataTable();
                    adap2.Fill(dt2);
                    aconn.Close();
                    bsource2 = new BindingSource();
                    bsource2.DataSource = dt2;

                    object[] arg2 = { bsource2 };
                    load.ReportProgress(20, arg2);

                    aconn.Open();
                    cmd = new MySqlCommand("SELECT count(orderid) from deliveries where date  like '%-" + originalmonth + "'", aconn);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    int orders = int.Parse(dr[0].ToString());
                    aconn.Close();

                    //aconn.Open();
                    //cmd = new MySqlCommand("SELECT sum(amount) from deliveries where date  like '%-" + originalmonth + "'", aconn);
                    //dr = cmd.ExecuteReader();
                    //dr.Read();
                    //int sale = int.Parse(dr[0].ToString());
                    //aconn.Close();

                    object[] arg3 = { orders };
                    load.ReportProgress(40, arg3);

                    //aconn.Open();
                    //cmd = new MySqlCommand(" SELECT sum(dealerprice*count) from dealing where pickupdate like '%-" + originalmonth + "'", aconn);
                    //dr = cmd.ExecuteReader();
                    //dr.Read();
                    //int purchase = int.Parse(dr[0].ToString());
                    //aconn.Close();

                    object[] arg4 = { purchase };
                    load.ReportProgress(60, arg4);

                    
                    aconn.Open();
                    cmd = new MySqlCommand("SELECT sum(shipping) from deliveries where date  like '%-" + originalmonth + "'", aconn);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    int shipping = int.Parse(dr[0].ToString());
                    aconn.Close();

                    aconn.Open();
                    cmd = new MySqlCommand("SELECT sum(amount) from expenses where purchasedate like '%-" + originalmonth + "'", aconn);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    int expe = int.Parse(dr[0].ToString());
                    aconn.Close();


                    aconn.Open();
                    cmd = new MySqlCommand("SELECT sum(count) from dealing where pickupdate like '%-" + originalmonth + "'", aconn);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    int sold = int.Parse(dr[0].ToString());
                    aconn.Close();

                    object[] arg5 = { shipping, expe, sold };
                    load.ReportProgress(80, arg5);

                    aconn.Open();
                    cmd = new MySqlCommand("select count(distinct date) from deliveries where date like '%-" + originalmonth + "'", aconn);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    int days = int.Parse(dr[0].ToString());
                    aconn.Close();

                    
                    dr = obj.Query("SELECT sum(giftcharges) from orders where status='Delivered' and deliverdate like '" + year +"-"+mon+ "-%'");
                    dr.Read();
                   
                    int    giftch = int.Parse(dr[0].ToString());
                    
                    
                    obj.closeConnection();
               //     MessageBox.Show(year + "-" + mon);

                    dr = obj.Query("SELECT sum(amount-dp) from medorders where status='Delivered' and deliverdate like '" + year+"-"+mon + "-%'");
                    dr.Read();
                    //  MessageBox.Show(dr[0].ToString()  );
                    int medp = 0;
                    if (dr[0].ToString() == null || dr[0].ToString() == "")
                    {
                         medp = 0;
                    }
                    else
                     medp = int.Parse(dr[0].ToString());      
                               
                    obj.closeConnection();
                  //  MessageBox.Show(giftch.ToString() + "    " + medp.ToString());


                    object[] arg6 = { days,giftch,medp };
                    load.ReportProgress(90, arg6);

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }



            };

            load.WorkerReportsProgress = true;
            load.ProgressChanged += (a, c) => 
            {
                try
                {
                    if (c.ProgressPercentage == 10)
                    {
                        loadinglbl.Text = "Loading 10%";
                        object[] arg = (object[])c.UserState;
                        string mon = (string)arg[0];
                        BindingSource bsource = arg[1] as BindingSource;
                        headlbl.Text = mon;
                        monthlydataview.DataSource = bsource;
                        monthlydataview.Columns["did"].Visible = false;
                    }
                    else if (c.ProgressPercentage == 20)
                    {
                        loadinglbl.Text = "Loading 20%";
                        object[] arg2 = (object[])c.UserState;
                        BindingSource bsource2 = arg2[0] as BindingSource;
                        expensesview.DataSource = bsource2;
                    }
                    else if (c.ProgressPercentage == 40)
                    {
                        loadinglbl.Text = "Loading 40%";
                        object[] arg3 = (object[])c.UserState;
                        orderstxt.Text = arg3[0].ToString();
                        saletxt.Text = "Rs. " + sale;

                    }
                    else if (c.ProgressPercentage == 60)
                    {
                        loadinglbl.Text = "Loading 60%";
                        object[] arg4 = (object[])c.UserState;
                        purchasetxt.Text = "Rs. " + purchase;
                        profittxt.Text = "Rs. " + (int.Parse(sale) - int.Parse(purchase)).ToString();
                    }
                    else if (c.ProgressPercentage == 80)
                    {
                        loadinglbl.Text = "Loading 80%";
                        object[] arg5 = (object[])c.UserState;
                        shiptxt.Text = "Rs. " + arg5[0].ToString();
                        exptxt.Text = "Rs. " + arg5[1].ToString();
                        booksoldtxt.Text = arg5[2].ToString() + " units";
                        try
                        {
                            string shipp = shiptxt.Text.Split(' ')[1];
                            int proship = ((int.Parse(sale) - int.Parse(purchase)) + int.Parse(shipp));
                            pstxt.Text = "Rs. " + proship;
                            //pstxt.Text = "Rs. "+((int.Parse(sale) - int.Parse(purchase)) + int.Parse(shipp)).ToString();
                            ppctxt.Text = "Rs. " + ((proship) - int.Parse(petrol));
                            pctxt.Text = "Rs. " + petrol;
                        }
                        catch { }
                    }
                    else if (c.ProgressPercentage == 90)
                    {
                        loadinglbl.Text = "Loading 90%";
                        object[] arg6 = (object[])c.UserState;
                        string expenses = exptxt.Text.Split(' ')[1];
                        string pt = ppctxt.Text.Split(' ')[1];
                        petxt.Text = "Rs. " + ((int.Parse(pt) - (int.Parse(expenses))));


                        workdaystxt.Text = arg6[0].ToString() + " Days";
                        giftxt.Text = "Rs. " + arg6[1].ToString();
                        medtxt.Text = "Rs. "+arg6[2].ToString();
                       

                    }

                }catch { }

            };
            load.RunWorkerCompleted += (a, d) => 
            {
                loadinglbl.Visible = false;
            };
            load.RunWorkerAsync();



        }
    }
}
