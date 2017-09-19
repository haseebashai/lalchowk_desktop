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
    public partial class receipt : Form
    {

        DBConnect obj = new DBConnect();
        string cmd, order;

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

        private void printbtn_Click(object sender, EventArgs e)
        {
            cmd = "update orders set status='Shipped' where orderid='" + order + "'";
            obj.nonQuery(cmd);
        }
    }
}
