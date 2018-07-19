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
        PictureBox loading;

        private dialogcontainer dg = null;

        

      

        private container hp = null;
        private mainform mf = null;
        public expenditure(Form mfcopy,Form hpcopy, Form dgcopy)
        {
            dg = dgcopy as dialogcontainer;
            mf = mfcopy as mainform;
            hp = hpcopy as container;

            InitializeComponent();
            bgworker.RunWorkerAsync();
            
            
        }
        private void bgworker_DoWork(object sender, DoWorkEventArgs e)
        {
            readexpenditure();
           
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
            dg.lbl.ForeColor = SystemColors.Highlight;
            dg.lbl.Text = "Loading";
            dg.loadingimage.SizeMode = PictureBoxSizeMode.StretchImage;
            dg.loadingimage.Visible = true;
        }

        private void bgworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (dg!=null)
            {
                dg.loadingimage.Visible = false;
                dg.lbl.ForeColor = SystemColors.Highlight;
                dg.lbl.Text = "Expenditure";
                formlbl.Visible = false;
            }
            else
            {
                loading.Visible = false;
                formlbl.Text = "Expenditure";
            }

            
            ordersdlbl.Text = ordersd;
            ordersdvlbl.Text = ordersdv;
            ordersplbl.Text = ordersp;
            orderspvlbl.Text = orderspv;
           // purlbl.Text = pur;
            shiplbl.Text = shipvar;
           // readprofit();
            epnl.Visible = true;


        }
        string ordersd, ordersdv, ordersp, orderspv, pur, shipvar,profit;
        private void readexpenditure()
        {
            try { 
            dr = obj.Query("SELECT count(status),sum(amount+shipping) FROM orders where status='delivered'");
            dr.Read();
            ordersd = dr[0].ToString();
            ordersdv = dr[1].ToString();
            obj.closeConnection();

            dr = obj.Query("SELECT count(status),sum(amount+shipping) FROM lalchowk.orders where status='placed';");
            dr.Read();
            ordersp = dr[0].ToString();
            orderspv = dr[1].ToString();
            obj.closeConnection();

            //dr = obj.Query("select sum(dealerprice * quantity) from lalchowk.orderdetails where orderid in (SELECT orderid FROM lalchowk.orders where status = 'delivered');");
            //dr.Read();
            //pur = dr[0].ToString();
            //obj.closeConnection();

            dr = obj.Query("select sum(shipping) from lalchowk.orders where status ='delivered'");
            dr.Read();
            shipvar = dr[0].ToString();
            obj.closeConnection();
        }
            catch (Exception ex)
            {

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }

        }

        private void readprofit()
        {
            try
            {
           //     profitlbl.Text = ((int.Parse(ordersdvlbl.Text) - int.Parse(purlbl.Text)) - int.Parse(shiplbl.Text)).ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }

       
        private void orderslbl_Click(object sender, EventArgs e)
        {

            dialogcontainer dg = new dialogcontainer();
            ordersdetails od = new ordersdetails(mf,dg);
                od.TopLevel = false;
                
                dg.dialogpnl.Controls.Add(od);
                dg.Text = "Orders placed";
            od.loadingdg();
            od.bgworker.RunWorkerAsync();
            
                dg.Show();
                od.Show();
               
            
        }
        private void orderslbl2_Click(object sender, EventArgs e)
        {

            dialogcontainer dg = new dialogcontainer();
            ordersdetails od = new ordersdetails(mf,dg);
                od.TopLevel = false;
                
                dg.dialogpnl.Controls.Add(od);
                dg.Text = "Orders delivered";
            od.loadingdg();
            od.bgworker1.RunWorkerAsync();

            dg.Show();
                od.Show();

            
        }

        private void costlbl_Click(object sender, EventArgs e)
        {
            dialogcontainer dg = new dialogcontainer();
            ordersdetails od = new ordersdetails(mf,dg);
                od.TopLevel = false;
                
                dg.dialogpnl.Controls.Add(od);
            od.loadingdg();
            od.bgworker5.RunWorkerAsync();
                dg.Text = "Purchasing Cost";
                
                
                dg.Show();
                od.Show();

            
        }

        private void profitlbl2_Click(object sender, EventArgs e)
        {
            dialogcontainer dg = new dialogcontainer();
            ordersdetails od = new ordersdetails(mf,dg);
            od.TopLevel = false;
            
            dg.dialogpnl.Controls.Add(od);
            dg.Text = "Profit Earned";
            od.loadingdg();
            od.bgworker4.RunWorkerAsync();
            dg.Show();
            od.Show();
        }

        private void ship_Click(object sender, EventArgs e)
        {

            dialogcontainer dg = new dialogcontainer();
            ordersdetails od = new ordersdetails(mf,dg);
                od.TopLevel = false;
                
                dg.dialogpnl.Controls.Add(od);
            od.loadingdg();
            od.bgworker3.RunWorkerAsync();
                dg.Text = "Shipping Charges";
                
                
                dg.Show();
                od.Show();

            
        }
    }
}
