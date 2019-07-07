using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modest_Attires
{
    public partial class printaddresses : Form
    {
        List<string> addresses1;
        Bitmap bmp;
    //    PrintDocument printdoc = new PrintDocument();
        PrintPreviewDialog ppdialog = new PrintPreviewDialog();
        

        public printaddresses(List<string> addresses)
        {
            InitializeComponent();
            addresses1 = addresses;
      //      printdoc.PrintPage+= new PrintPageEventHandler(printdoc_PrintPage);
        }

        //Rest of the code
        //Bitmap MemoryImage;
        //public void GetPrintArea(Panel pnl)
        //{
        //    MemoryImage = new Bitmap(pnl.Width, pnl.Height);
        //    pnl.DrawToBitmap(MemoryImage, new Rectangle(0, 0, pnl.Width, pnl.Height));
        //}
        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    if (MemoryImage != null)
        //    {
        //        e.Graphics.DrawImage(MemoryImage, 0, 0);
        //        base.OnPaint(e);
        //    }
        //}

        int xpage=15, ypage = 24;
        void printdoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, xpage, ypage);
        }

        //public void Print(Panel pnl)
        //{
        //    pannel = pnl;
        //    GetPrintArea(pnl);
        //    ppdialog.Document = printdoc;
        //    ppdialog.ShowDialog();
        //}
     
        private void printaddresses_Load(object sender, EventArgs e)
        {
            int count = addresses1.Count;
            for (int i=0; i < count ; i++)
            {
                TextBox t1 = new TextBox()
                {
                    Text = addresses1[i],
                    Multiline = true,
                    Size = new Size(380, 175),
                    Font = new Font(Font.FontFamily, 13, FontStyle.Regular),
                    BorderStyle = BorderStyle.None,
                    BackColor = Color.White,
                    ReadOnly = false,
                    
                };
               
                tpnl.Controls.Add(t1);

                xtxt.Text = t1.Width.ToString();
                ytxt.Text = t1.Height.ToString();
                ftxt.Text = t1.Font.SizeInPoints.ToString();
                pxtxt.Text = xpage.ToString();
                pytxt.Text = ypage.ToString();

            //    MessageBox.Show(addresses1[i] + "1"+ " " +addresses1.Count);


            }
        }

        private void printbtn_Click(object sender, EventArgs e)
        {
             
            // Print(this.tpnl);
            tpnl.BackColor = Color.Transparent;
            bmp = new Bitmap(tpnl.Width, tpnl.Height, tpnl.CreateGraphics());
            tpnl.DrawToBitmap(bmp, new Rectangle(0, 0, tpnl.Width, tpnl.Height));
            ((Form)ppdialog).WindowState = FormWindowState.Maximized;
            ppdialog.Document = printdoc;
            ppdialog.ShowDialog();
            tpnl.BackColor = Color.WhiteSmoke;
        }

        private void psetbtn_Click(object sender, EventArgs e)
        {
            xpage = int.Parse(pxtxt.Text);
            ypage = int.Parse(pytxt.Text);
        }

        private void bbox_CheckedChanged(object sender, EventArgs e)
        {
            if(bbox.Checked)
                tpnl.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            else
                tpnl.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            TextBox t1 = new TextBox()
            {
                Text ="",
                Multiline = true,
                Size = new Size(int.Parse(xtxt.Text), int.Parse(ytxt.Text)),
                Font = new Font(Font.FontFamily, int.Parse(ftxt.Text), FontStyle.Regular),
                BorderStyle = BorderStyle.None,
                BackColor = Color.White,
                ReadOnly = false,

            };

            tpnl.Controls.Add(t1);
        }

        private void frbtn_Click(object sender, EventArgs e)
        {
            TextBox t1 = new TextBox()
            {
                Text = "From:\r\nAsif\r\nLalchowk LLP\r\nHotel Bombay Gujrat\r\nLalchowk, 190001\r\n9906523492",
                Multiline = true,
                Size = new Size(int.Parse(xtxt.Text), int.Parse(ytxt.Text)),
                Font = new Font(Font.FontFamily, 14, FontStyle.Regular),
                BorderStyle = BorderStyle.None,
                BackColor = Color.White,
                ReadOnly = false,

            };

            tpnl.Controls.Add(t1);
        }

        private void setbtn_Click(object sender, EventArgs e)
        {
            tpnl.Controls.Clear();
            int count = addresses1.Count;
            for (int i = 0; i < count; i++)
            {
                TextBox t1 = new TextBox()
                {
                    Text = addresses1[i],
                    Multiline = true,
                    Size = new Size(int.Parse(xtxt.Text),int.Parse(ytxt.Text)),
                    Font = new Font(Font.FontFamily, int.Parse(ftxt.Text), FontStyle.Regular),
                    BorderStyle = BorderStyle.None,
                    BackColor = Color.White,
                    ReadOnly = false,

                };

                tpnl.Controls.Add(t1);
            }
        }
    }
}
