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
        MySqlDataReader dr,dr1;
        string url = "http://lalchowk.in/uploads/";



        public medorders()
        {
            InitializeComponent();
            placeddataview.DoubleBuffered(true);

            BackgroundWorker medload = new BackgroundWorker();
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

                   a.Result = bsource;         
               };
                medload.RunWorkerCompleted += (o, b) => 
                {
                    BindingSource bsource = b.Result as BindingSource;
                    placeddataview.DataSource = bsource;
                    loadlbl.Visible = false;
                    placeddataview.Visible = true;



                };
                medload.RunWorkerAsync();
                
            }
            catch (Exception ex) { placeddataview.Visible = false; loadlbl.Text = "error, please reload"; loadlbl.Visible = true; MessageBox.Show(ex.Message); }

           

        }

        private void tabPage2_Paint(object sender, PaintEventArgs e)
        {
            BackgroundWorker delload = new BackgroundWorker();
            try
            {
                delload.DoWork += (o, a) =>
                {

                    dr1 = obj.Query("select customer.mail,medorders.email,medorders.orderid,medorders.timestamp,medorders.amount,medorders.shipping,medorders.itemcount,medorders.status,medorders.name,medorders.address1,medorders.address2,medorders.pincode,medorders.contact,medorders.city from lalchowk.medorders inner join customer on customer.email=medorders.email where status='delivered';");

                    DataTable dt1 = new DataTable();
                    dt1.Load(dr1);
                    obj.closeConnection();
                    BindingSource bsource1 = new BindingSource();
                    bsource1.DataSource = dt1;

                    a.Result = bsource1;
                };
                delload.RunWorkerCompleted += (o, b) =>
                {
                    BindingSource bsource1 = b.Result as BindingSource;
                    deldataview.DataSource = bsource1;
                    loadlbl.Visible = false;
                    deldataview.Visible = true;



                };
                delload.RunWorkerAsync();

            }
            catch (Exception ex) { deldataview.Visible = false; loadlbl.Text = "error, please reload"; loadlbl.Visible = true; MessageBox.Show(ex.Message); }

        }

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
