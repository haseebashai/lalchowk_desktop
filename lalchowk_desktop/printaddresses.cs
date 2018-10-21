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

namespace Veiled_Kashmir_Admin_Panel
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

        void printdoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 9, 3);
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
                    Size = new Size(380, 230),
                    Font = new Font(Font.FontFamily, 17, FontStyle.Regular),
                    BorderStyle = BorderStyle.None,
                    BackColor = Color.White,
                    ReadOnly = false,
                    
                };
               
                tpnl.Controls.Add(t1);
                

            //    MessageBox.Show(addresses1[i] + "1"+ " " +addresses1.Count);


            }
        }

        private void printbtn_Click(object sender, EventArgs e)
        {
           // Print(this.tpnl);
            bmp = new Bitmap(tpnl.Width, tpnl.Height, tpnl.CreateGraphics());
            tpnl.DrawToBitmap(bmp, new Rectangle(0, 0, tpnl.Width, tpnl.Height));
            ((Form)ppdialog).WindowState = FormWindowState.Maximized;
            ppdialog.Document = printdoc;
            ppdialog.ShowDialog();
           
        }

    }
}
