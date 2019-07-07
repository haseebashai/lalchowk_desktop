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

namespace Modest_Attires
{
    public partial class viewproducts : Form
    {
        MySqlConnection con = new MySqlConnection("SERVER=103.53.43.82;DATABASE=modes43i_db;USER=modes43i;PASSWORD=Modest__123;Convert Zero Datetime=True");
        MySqlDataAdapter adap,adap1;
        DataTable dt,dt1,dt2;
        string pid,pname, cmd, url = "http://lalchowk.in/lalchowk/pictures/";
        MySqlCommandBuilder cmdbl;
        DBConnect obj=new DBConnect();
        BindingSource bsource,bsource1;
        MySqlDataReader dr;

        private dialogcontainer dg = null;
        public viewproducts(Form dgcopy)
        {
            dg = dgcopy as dialogcontainer;
            InitializeComponent();

       //     loadingdg();
            try
            {

                BackgroundWorker variants = new BackgroundWorker();
                variants.DoWork += (o, a) =>
                {

                    
                        adap = new MySqlDataAdapter("select * from variantnames", con);
                        dt1 = new DataTable();
                        adap.Fill(dt1);
                        bsource = new BindingSource();
                        bsource.DataSource = dt1;

                    adap1 = new MySqlDataAdapter("select * from variantvalues", con);
                    dt2 = new DataTable();
                    adap1.Fill(dt2);
                    bsource1 = new BindingSource();
                    bsource1.DataSource = dt2;



                    dr = obj.Query("select concat(id,': ',name) as name from variantnames ");
                    DataTable dt = new DataTable();
                    dt.Columns.Add("name", typeof(String));
                    dt.Load(dr);
                    obj.closeConnection();

                    variant1list.DataSource = dt;


                    obj.closeConnection();

                   



                };
                variants.RunWorkerCompleted += (o, b) =>
                {
                    variant1list.DisplayMember = "name";
                    variantdataview.DataSource = bsource;
                    variantvaluedataview.DataSource = bsource1;

                   
                };
                variants.RunWorkerAsync();
            }
            catch (Exception ex) { MessageBox.Show("Could not load the variant list, Please reopen the page.", "Error"); obj.closeConnection(); }


        }

        private void upbtn1_Click(object sender, EventArgs e)
        {
            try
            {
                cmdbl = new MySqlCommandBuilder(adap);
                adap.Update(dt1);
                MessageBox.Show("Entry Updated.");

            }
            catch (Exception ex)
            {

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }


        private void upbtn2_Click(object sender, EventArgs e)
        {
            try
            {
                cmdbl = new MySqlCommandBuilder(adap1);
                adap1.Update(dt2);
                MessageBox.Show("Entry Updated.");

            }
            catch (Exception ex)
            {

                MessageBox.Show("Something happened, please try again.\n\n" + ex.Message.ToString(), "Error!");
            }
        }


        private void addbtn_Click(object sender, EventArgs e)
        {
            try
            {
                string id = variant1list.Text.Split(':')[0];
                string cmd = "insert into variantvalues (`variantname_id`,`variantvalue`)values('" + id + "','" + variantvaluetxt.Text + "')";
                obj.nonQuery(cmd);
                MessageBox.Show("Option added.");
                obj.closeConnection();
            }
            catch { }
        }

        public void loadingdg()
        {

            dg.lbl.ForeColor = SystemColors.Highlight;
            dg.lbl.Text = "Loading";
            dg.loadingimage.SizeMode = PictureBoxSizeMode.StretchImage;
            dg.loadingimage.Visible = true;
        }



     

    
        
    }
}
