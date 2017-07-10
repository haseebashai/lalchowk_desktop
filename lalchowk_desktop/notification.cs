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
    public partial class notification : Form
    {
        DBConnect obj = new DBConnect();
        MySqlDataReader dr;

        public notification(string email)
        {
         

            InitializeComponent();
            
            emailtxt.Text = email;
            
        }
        
        private void readorderid()
        {
            dr = obj.Query("Select orderid from orders where email='" + emailtxt.Text + "'");
            DataTable dt = new DataTable();
            dt.Columns.Add("orderid", typeof(String));
            dt.Load(dr);
            obj.closeConnection();
            orderidbox.DisplayMember = "orderid";
            orderidbox.DataSource = dt;
        }


        private void sendbtn_Click_1(object sender, EventArgs e)
        {
            try {
                string cmd;
                cmd = ("insert into notifications (email,title,subtitle,orderid) values ('" + emailtxt.Text + "','"+titletxt.Text+"','"+subtxt.Text+"','"+orderidbox.Text+"')");
                obj.nonQuery(cmd);
                MessageBox.Show("Notification sent sucessfully.");
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            obj.closeConnection();
            }

        private void close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void notification_Load(object sender, EventArgs e)
        {
            readorderid();
        }
    }
}
