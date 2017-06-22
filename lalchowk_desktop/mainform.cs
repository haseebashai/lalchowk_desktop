using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Veiled_Kashmir_Admin_Panel
{
    public partial class mainform : Form
    {
        private container hp = null;
        public mainform(Form hpcopy)
        {
            hp = hpcopy as container;
            InitializeComponent();
        }

        private void mainform_Load(object sender, EventArgs e)
        {
            if (userinfo.loggedin == true)
                signout();
                changelabel("Welcome, " + userinfo.username +"");

        }

   
   
        private void ordersbtn_Click(object sender, EventArgs e)
        {
            orders or = new orders(hp);
            or.TopLevel = false;
            cntpnl.Controls.Clear();
            cntpnl.Controls.Add(or);           
            or.Show();
        }
        public void changelabel(String welcome)
        {
            signinlbl.Text = welcome;

            signinlbl.Visible = true;

        }
        public void signout()
        {
            signoutlbl.Visible = true;
        }

        private void signoutlbl_Click(object sender, EventArgs e)
        {
            userinfo.loggedin = false;
            userinfo.username = "";           
            this.Close();
            MessageBox.Show("Logged out sucessfully.\nPlease Log in to continue");

            loginform lg = new loginform(hp,this);
            hp.mainpnl.Controls.Clear();
            lg.TopLevel = false;
            hp.mainpnl.Controls.Add(lg);
            lg.Show();
        }

        private void signoutlbl_Enter(object sender, EventArgs e)
        {
            signoutlbl.Cursor = Cursors.Hand;
        }

        private void productsbtn_Click(object sender, EventArgs e)
        {
            products pr = new products(hp,this);
            pr.TopLevel = false;
            cntpnl.Controls.Clear();
            cntpnl.Controls.Add(pr);           
            pr.Show();
        }

       

        private void customersbtn_Click(object sender, EventArgs e)
        {
            customers cus = new customers(hp);
            cus.TopLevel = false;
            cntpnl.Controls.Clear();
            cntpnl.Controls.Add(cus);
            cus.Show();
        }

        


        private void expbtn_Click(object sender, EventArgs e)
        {
            expenditure exp = new expenditure(hp);
            exp.TopLevel = false;
            cntpnl.Controls.Clear();
            cntpnl.Controls.Add(exp);
            exp.Show();
        }

        private void suppliersbtn_Click(object sender, EventArgs e)
        {
            suppliers sup = new suppliers(hp);
            sup.TopLevel = false;
            cntpnl.Controls.Clear();
            cntpnl.Controls.Add(sup);
            sup.Show();
        }

        private void chkbtn_Click(object sender, EventArgs e)
        {
            inventory inv = new inventory(hp);
            inv.TopLevel = false;
            cntpnl.Controls.Clear();
            cntpnl.Controls.Add(inv);
            inv.Show();
        }
    }
}
