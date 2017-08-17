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
    public partial class messages : Form
    {

        DBConnect obj = new DBConnect();
        MySqlDataReader dr;
        DataTable dt;

        public messages()
        {
            InitializeComponent();
        }

        private void readmsgs()
        {
            dr = obj.Query("SELECT customer.mail,messages.*  FROM lalchowk.messages inner join customer on customer.email=messages.email");
            dt = new DataTable();
            dt.Load(dr);
            obj.closeConnection();
            BindingSource bsource = new BindingSource();
            bsource.DataSource = dt;
            messagesdataview.DataSource = bsource;
        }

        private void messages_Load(object sender, EventArgs e)
        {
            readmsgs();
        }

        private void messagesdataview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.messagesdataview.Rows[e.RowIndex];
                midlbl.Text = row.Cells["messageid"].Value.ToString();
                emaillbl.Text = row.Cells["mail"].Value.ToString();
                sublbl.Text = row.Cells["subject"].Value.ToString();
                msgtxt.Text = row.Cells["message"].Value.ToString();
                mpnl.Visible = true;



            }
        }

        private void sendbtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Does not work yet.");
          //  mail ml = new mail(emaillbl.Text,sublbl.Text,msgtxt.Text,midlbl.Text);
          //  ml.ShowDialog();
        }
    }
}
