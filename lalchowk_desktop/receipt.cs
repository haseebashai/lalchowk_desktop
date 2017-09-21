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
using System.Diagnostics;

namespace Veiled_Kashmir_Admin_Panel
{
    public partial class receipt : Form
    {

        DBConnect obj = new DBConnect();
        string cmd, order;
        Bitmap bmp;


        public receipt(string orderid)
        {
            InitializeComponent();
            order = orderid;

        }

        private void close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void datetxt_TextChanged(object sender, EventArgs e)
        {
            datetxt1.Text = datetxt.Text;
        }

     
        private void printdoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }

      
        private void printbtn_Click(object sender, EventArgs e)
        {
          /*  bmp = new Bitmap(receiptpnl.Width, receiptpnl.Height, receiptpnl.CreateGraphics());
            receiptpnl.DrawToBitmap(bmp, new Rectangle(0, 0, receiptpnl.Width, receiptpnl.Height));
            ((Form)ppdialog).WindowState = FormWindowState.Maximized;
            ppdialog.ShowDialog(); 

            
            cmd = "update orders set status='Shipped' where orderid='" + order + "'";
            obj.nonQuery(cmd); */
        }

        private void nametxt_Click(object sender, EventArgs e)
        {
            nametxt.Text = "";
        }

        private void addresstxt_Click(object sender, EventArgs e)
        {
            addresstxt.Text = "";
        }

        private void soldbytxt_Click(object sender, EventArgs e)
        {
            soldbytxt.Text = "";
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox4.Text = "";
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox5.Text = "";
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            textBox6.Text = "";

        }

        private void textBox30_TextChanged(object sender, EventArgs e)
        {
            textBox30.Text = "";

        }

        private void textBox28_TextChanged(object sender, EventArgs e)
        {
            textBox28.Text = "";
        }

        private void textBox31_TextChanged(object sender, EventArgs e)
        {
            textBox31.Text = "";
        }

        private void textBox29_TextChanged(object sender, EventArgs e)
        {
            textBox29.Text = "";
        }

        private void textBox33_TextChanged(object sender, EventArgs e)
        {
            textBox33.Text = "";
        }

        private void textBox35_TextChanged(object sender, EventArgs e)
        {
            textBox35.Text = "";
        }

        private void textBox32_TextChanged(object sender, EventArgs e)
        {
            textBox32.Text = "";
        }

        private void textBox34_TextChanged(object sender, EventArgs e)
        {
            textBox34.Text = "";
        }

        private void textBox37_TextChanged(object sender, EventArgs e)
        {
            textBox37.Text = "";
        }

        private void textBox39_TextChanged(object sender, EventArgs e)
        {
            textBox39.Text = "";
        }

        private void datetxt_Click(object sender, EventArgs e)
        {
            datetxt.Text = "";
        }

       

     
    }
}
