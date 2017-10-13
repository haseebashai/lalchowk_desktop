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
    public partial class loginform : Form
    {
        DBConnect obj = new DBConnect();
        private container hp = null;

        private mainform mf = null;

        public loginform(Form hpcopy, Form mfcopy)
        {

            mf = mfcopy as mainform;
            hp = hpcopy as container;
            InitializeComponent();
        }



        private void loginform_Load(object sender, EventArgs e)
        {

        }

        private void usrtxt_Enter(object sender, EventArgs e)
        {
            namelbl.Location = new Point(468, 180);
        }

        private void usernametxt_Leave(object sender, EventArgs e)
        {
            if (usernametxt.Text=="")
                namelbl.Location = new Point(468, 205);
        }

        private void pwdtxt_Enter(object sender, EventArgs e)
        {
            pwdlbl.Location = new Point(468, 236);
        }

        private void pwdtxt_Leave(object sender, EventArgs e)
        {
            if (pwdtxt.Text=="")
                pwdlbl.Location = new Point(468, 261);
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
          /*      if (usernametxt.Text.Contains("'") || pwdtxt.Text.Contains("'") || usernametxt.Text.Contains("\\") || pwdtxt.Text.Contains("\\"))
                 {

                     error.Text = "Is that a trick? Enter valid details";
                     error.Visible = true;
                     usernametxt.Text = "";
                     pwdtxt.Text = "";
                 }
                 else if (usernametxt.Text != "" && pwdtxt.Text != "")
                 {
                     int i;
                     i = obj.Count("Select Count(*) from admin where username='" + usernametxt.Text + "';");
                     if (i == 1)
                     {
                         MySqlDataReader dr;
                         dr = obj.Query("Select * from admin where username='" + usernametxt.Text + "';");
                         dr.Read();
                         if (dr[4].Equals(pwdtxt.Text))
                         {
                             userinfo.loggedin = true;
                             userinfo.username = dr[0].ToString(); */

                             mainform mf = new mainform(hp);
                             mf.changelabel("Welcome User");
                             mf.signout();

                             this.Close();

                             hp.mainpnl.Controls.Clear();                     
                             mf.TopLevel = false;                           
                             hp.mainpnl.Controls.Add(mf);
                             mf.Show();
            /*
                         }
                         else
                         {
                             error.Text = "Please Enter Correct Password";
                             error.Visible = true;
                             usernametxt.Text = "";
                             pwdtxt.Text = "";

                         }
                         obj.closeConnection();
                     }
                     else
                     {
                         error.Text = "Username does not exist";
                         error.Visible = true;
                         usernametxt.Text = "";
                         pwdtxt.Text = "";
                     }
                 }
                 else
                 {
                     error.Text = "Enter username and password";
                     error.Visible = true;
                     usernametxt.Text = "";
                     pwdtxt.Text = "";
                 }
           */
        }


        private void forgotbtn_Click(object sender, EventArgs e)
        {
           
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            promomail pm = new promomail("");
            pm.TopLevel = false;
            pm.readlist();
            pm.emaillistpnl.Visible=true;
           
            dialogcontainer dg = new dialogcontainer();
            dg.dialogpnl.Controls.Add(pm);
            dg.lbl.Text = "";

            dg.Show();

            pm.Show();
            
            
           
            Cursor = Cursors.Arrow;
        }

       
    }   
}
