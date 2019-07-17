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
        int sumtotal1 = 0;
        Bitmap bmp;
        List<int> pid1, pquan1, pmrp1, pdisc1, ptotal1;
        List<string> pname1;

        public receipt(string name, string address, string date, List<int> pid, List<string> pname, List<int> pquan, List<int> pmrp, List<int> pdisc,
            List<int> ptotal, int sumtotal, int orderid, string shipping)
        {
            InitializeComponent();
            ordidtxt.Text = "Bill for order " + orderid;
            nametxt.Text = name;
            addresstxt.Text = address;
            datetxt.Text = date;
            pid1 = pid;
            pname1 = pname; pquan1 = pquan; pmrp1 = pmrp; pdisc1 = pdisc; ptotal1 = ptotal;
            payabletxt.Text = sumtotal.ToString() + " ₹ ";
            if (shipping == "0")
                shippingtxt.Text = "FREE";
            else
                shippingtxt.Text = shipping + " ₹ ";
            sumtotal1 = sumtotal;


        }


        private void cancelbtn_Click(object sender, EventArgs e)
        {
            Close();
        }


        int xpage = 13, ypage = 20;
        private void printdoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, xpage, ypage);
        }


        private void printbtn_Click(object sender, EventArgs e)
        {
            receiptpnl.BackColor = Color.Transparent;
            bmp = new Bitmap(receiptpnl.Width, receiptpnl.Height, receiptpnl.CreateGraphics());
            receiptpnl.DrawToBitmap(bmp, new Rectangle(0, 0, receiptpnl.Width, receiptpnl.Height));
            ((Form)ppdialog).WindowState = FormWindowState.Maximized;
            ppdialog.Document = printdoc;
            ppdialog.ShowDialog();
            receiptpnl.BackColor = Color.Transparent;



        }


        private void receipt_Load(object sender, EventArgs e)
        {

            try
            {
                companytxt.SelectionStart = 0;


                int count = pid1.Count;
                for (int i = 0; i < count; i++)
                {

                    TextBox t1 = new TextBox()
                    {

                        Text = pid1[i].ToString(),
                        Multiline = false,
                        Size = new Size(90, 20),
                        Font = new Font(Font.FontFamily, 10, FontStyle.Regular),
                        BorderStyle = BorderStyle.None,
                        BackColor = Color.White,
                        ReadOnly = false,

                    };

                    cpid.Controls.Add(t1);
                }
                int count1 = pname1.Count;
                for (int i = 0; i < count1; i++)
                {

                    TextBox t1 = new TextBox()
                    {

                        Text = pname1[i],
                        Multiline = false,
                        Size = new Size(244, 20),
                        Font = new Font(Font.FontFamily, 10, FontStyle.Regular),
                        BorderStyle = BorderStyle.None,
                        BackColor = Color.White,
                        ReadOnly = false,

                    };

                    cname.Controls.Add(t1);
                }
                int count2 = pquan1.Count;
                for (int i = 0; i < count2; i++)
                {

                    TextBox t1 = new TextBox()
                    {

                        Text = pquan1[i].ToString(),
                        Multiline = false,
                        Size = new Size(55, 20),
                        Font = new Font(Font.FontFamily, 10, FontStyle.Regular),
                        BorderStyle = BorderStyle.None,
                        BackColor = Color.White,
                        ReadOnly = false,

                    };

                    cquan.Controls.Add(t1);
                }
                int count3 = pmrp1.Count, total = 0;
                for (int i = 0; i < count3; i++)
                {

                    TextBox t1 = new TextBox()
                    {

                        Text = pmrp1[i].ToString(),
                        Multiline = false,
                        Size = new Size(70, 20),
                        Font = new Font(Font.FontFamily, 10, FontStyle.Regular),
                        BorderStyle = BorderStyle.None,
                        BackColor = Color.White,
                        ReadOnly = false,

                    };

                    cunit.Controls.Add(t1);

                    total = total + (pmrp1[i] * pquan1[i]);
                }
                int count4 = pdisc1.Count, utotal = 0;
                for (int i = 0; i < count4; i++)
                {

                    TextBox t1 = new TextBox()
                    {

                        Text = pdisc1[i] + "%",
                        Multiline = false,
                        Size = new Size(60, 20),
                        Font = new Font(Font.FontFamily, 10, FontStyle.Regular),
                        BorderStyle = BorderStyle.None,
                        BackColor = Color.White,
                        ReadOnly = false,

                    };

                    cdisc.Controls.Add(t1);

                }
                int count5 = ptotal1.Count;
                for (int i = 0; i < count5; i++)
                {

                    TextBox t1 = new TextBox()
                    {

                        Text = (ptotal1[i] * pquan1[i]).ToString(),
                        Multiline = false,
                        Size = new Size(65, 20),
                        Font = new Font(Font.FontFamily, 10, FontStyle.Regular),
                        BorderStyle = BorderStyle.None,
                        BackColor = Color.White,
                        ReadOnly = false,

                    };

                    ctotal.Controls.Add(t1);
                    utotal = utotal + (ptotal1[i] * pquan1[i]);
                }
                mrptxt.Text = total.ToString() + " ₹ ";
                disctxt.Text = (total - utotal).ToString() + " ₹ ";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}


