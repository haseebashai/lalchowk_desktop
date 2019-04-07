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
    public partial class medorders : Form
    {

        DBConnect obj = new DBConnect();
        MySqlDataReader dr,dr1,dr2;
        string url = "http://lalchowk.in/uploads/";



        public medorders()
        {
            InitializeComponent();
            placeddataview.DoubleBuffered(true);

            PictureBox loading = new PictureBox()
            {
                Image = Properties.Resources.loading,
                Size = new Size(40, 30),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Location = new Point(73, 0),
            };
            this.Controls.Add(loading);

            BackgroundWorker medload = new BackgroundWorker();
            medload.WorkerReportsProgress = true;
           
            try
            {
                medload.DoWork += (o, a) => 
               {
                
                    dr = obj.Query("select customer.mail,medorders.email,medorders.orderid,medorders.timestamp,medorders.amount,medorders.shipping,medorders.itemcount,medorders.paymenttype,medorders.paymentconfirmed,medorders.status,medorders.name,medorders.address1,medorders.address2,medorders.pincode,medorders.contact,medorders.city from lalchowk.medorders inner join customer on customer.email=medorders.email where status='placed' or status='confirmed';");

                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    obj.closeConnection();
                    BindingSource bsource = new BindingSource();
                    bsource.DataSource = dt;
                   object[] arg = { bsource};

                   medload.ReportProgress(25,arg);


                   dr = obj.Query("select customer.mail,medorders.email,medorders.orderid,medorders.timestamp,medorders.amount,medorders.shipping,medorders.itemcount,medorders.paymenttype,medorders.paymentconfirmed,medorders.status,medorders.name,medorders.address1,medorders.address2,medorders.pincode,medorders.contact,medorders.city from lalchowk.medorders inner join customer on customer.email=medorders.email where status='shipped';");

                   DataTable dt3 = new DataTable();
                   dt3.Load(dr);
                   obj.closeConnection();
                   BindingSource bsource3 = new BindingSource();
                   bsource3.DataSource = dt3;
                   object[] arg3 = { bsource3 };

                   medload.ReportProgress(50, arg3);



                   dr1 = obj.Query("select customer.mail,medorders.email,medorders.orderid,medorders.timestamp,medorders.amount,medorders.shipping,medorders.itemcount,medorders.status,medorders.name,medorders.address1,medorders.address2,medorders.pincode,medorders.contact,medorders.city from lalchowk.medorders inner join customer on customer.email=medorders.email where status='delivered';");

                   DataTable dt1 = new DataTable();
                   dt1.Load(dr1);
                   obj.closeConnection();
                   BindingSource bsource1 = new BindingSource();
                   bsource1.DataSource = dt1;
                   object[] arg1 = { bsource1 };
                   medload.ReportProgress(75,arg1);

                   dr2 = obj.Query("select customer.mail,medorders.email,medorders.orderid,medorders.timestamp,medorders.amount,medorders.shipping,medorders.itemcount,medorders.status,medorders.name,medorders.address1,medorders.address2,medorders.pincode,medorders.contact,medorders.city from lalchowk.medorders inner join customer on customer.email=medorders.email ;");

                   DataTable dt2 = new DataTable();
                   dt2.Load(dr2);
                   obj.closeConnection();
                   BindingSource bsource2 = new BindingSource();
                   bsource2.DataSource = dt2;
                   object[] arg2 = { bsource2 };
                   medload.ReportProgress(90, arg2);
               };

                medload.ProgressChanged += (o, a) =>
                {
                    if (a.ProgressPercentage == 25)
                    {
                        Object[] arg = (object[])a.UserState;
                        BindingSource bsource = arg[0] as BindingSource;
                        placeddataview.DataSource = bsource;
                        loadlbl.Text="Health Orders";
                        placeddataview.Columns["email"].Visible = false;
                        placeddataview.Visible = true;
                        medcontrol.Visible = true;
                       

                    }
                    else
                    if (a.ProgressPercentage == 50)
                    {
                        Object[] arg = (object[])a.UserState;
                        BindingSource bsource = arg[0] as BindingSource;
                        deldataview.DataSource = bsource;
                        dellbl.Visible = false;
                        deldataview.Columns["email"].Visible = false;
                        deldataview.Visible = true;


                    }                   
                    else
                    if (a.ProgressPercentage == 75)
                    {
                        Object[] arg = (object[])a.UserState;
                        BindingSource bsource = arg[0] as BindingSource;
                        deldataview.DataSource = bsource;
                        dellbl.Visible = false;
                        deldataview.Columns["email"].Visible = false;
                        deldataview.Visible = true;
                       

                    }
                    else
                    if (a.ProgressPercentage == 90)
                    {
                        Object[] arg = (object[])a.UserState;
                        BindingSource bsource = arg[0] as BindingSource;
                        alldataview.DataSource = bsource;
                        alllbl.Visible = false;
                        alldataview.Columns["email"].Visible = false;
                        alldataview.Visible = true;
                       

                    }



                };

                medload.RunWorkerCompleted += (o, b) => 
                {
                    //BindingSource bsource = b.Result as BindingSource;
                    //placeddataview.DataSource = bsource;
                    //loadlbl.Visible = false;
                    //placeddataview.Columns["email"].Visible = false;
                    //placeddataview.Visible = true;
                    medcontrol.Visible = true;
                    loading.Visible = false;
                    loading.Dispose();

                    obj.closeConnection();

                };
                medload.RunWorkerAsync();
                
            }
            catch (Exception ex) { medcontrol.Visible = false; loadlbl.Text = "error, please reload"; loadlbl.Visible = true; MessageBox.Show(ex.Message); obj.closeConnection(); }

           

        }


        //private void tabPage2_Paint(object sender, PaintEventArgs e)
        //{
        //    dellbl.Visible = true;
        //    medcontrol.Enabled = false;
        //    BackgroundWorker delload = new BackgroundWorker();
        //    try
        //    {
        //        delload.DoWork += (o, a) =>
        //        {

        //            dr1 = obj.Query("select customer.mail,medorders.email,medorders.orderid,medorders.timestamp,medorders.amount,medorders.shipping,medorders.itemcount,medorders.status,medorders.name,medorders.address1,medorders.address2,medorders.pincode,medorders.contact,medorders.city from lalchowk.medorders inner join customer on customer.email=medorders.email where status='delivered';");

        //            DataTable dt1 = new DataTable();
        //            dt1.Load(dr1);
        //            obj.closeConnection();
        //            BindingSource bsource1 = new BindingSource();
        //            bsource1.DataSource = dt1;

        //            a.Result = bsource1;
        //        };
        //        delload.RunWorkerCompleted += (o, b) =>
        //        {
        //            BindingSource bsource1 = b.Result as BindingSource;
        //            deldataview.DataSource = bsource1;
        //            dellbl.Visible = false;
        //            deldataview.Columns["email"].Visible = false;
        //            deldataview.Visible = true;
        //            obj.closeConnection();


        //        };
        //        delload.RunWorkerAsync();

        //    }
        //    catch (Exception ex) { obj.closeConnection(); deldataview.Visible = false; dellbl.Text = "error, please reload"; dellbl.Visible = true; MessageBox.Show(ex.Message); }
        //    medcontrol.Enabled = true;
        //}

        //private void allorderspg_Paint(object sender, PaintEventArgs e)
        //{
        //    alllbl.Visible = true;
        //    medcontrol.Enabled = false;
        //    BackgroundWorker allload = new BackgroundWorker();
        //    try
        //    {
        //        allload.DoWork += (o, a) =>
        //        {

        //            dr2 = obj.Query("select customer.mail,medorders.email,medorders.orderid,medorders.timestamp,medorders.amount,medorders.shipping,medorders.itemcount,medorders.status,medorders.name,medorders.address1,medorders.address2,medorders.pincode,medorders.contact,medorders.city from lalchowk.medorders inner join customer on customer.email=medorders.email ;");

        //            DataTable dt2 = new DataTable();
        //            dt2.Load(dr2);
        //            obj.closeConnection();
        //            BindingSource bsource2 = new BindingSource();
        //            bsource2.DataSource = dt2;

        //            a.Result = bsource2;
        //        };
        //        allload.RunWorkerCompleted += (o, b) =>
        //        {
        //            BindingSource bsource2 = b.Result as BindingSource;
        //            alldataview.DataSource = bsource2;
        //            alllbl.Visible = false;
        //            alldataview.Columns["email"].Visible = false;
        //            alldataview.Visible = true;

        //            obj.closeConnection();

        //        };
        //        allload.RunWorkerAsync();

        //    }
        //    catch (Exception ex) { obj.closeConnection(); alldataview.Visible = false; alllbl.Text = "error, please reload"; alllbl.Visible = true; MessageBox.Show(ex.Message); }
        //    medcontrol.Enabled = true;
        //}

        private void placeddataview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {

                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.placeddataview.Rows[e.RowIndex];
                    string oid = row.Cells["orderid"].Value.ToString();
                    dr = obj.Query("select url from lalchowk.image_uploads where oid ='"+oid+"';");
                    dr.Read();
                    string file = dr[0].ToString();
                    obj.closeConnection();
                    
                    string imagename = file.Split('/')[3];
                    MessageBox.Show(url + imagename);
                    presdp.SizeMode = PictureBoxSizeMode.StretchImage;
                    presdp.ImageLocation = (url + imagename);
                    
                    presdp.Visible = true;

                }



            }
            catch(Exception ex) { MessageBox.Show(ex.Message); obj.closeConnection(); };


        }
    }
}
