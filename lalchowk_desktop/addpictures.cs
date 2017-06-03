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
using System.Net.Mail;
using System.Net;

namespace Veiled_Kashmir_Admin_Panel
{
    public partial class addpictures : Form
    {
        DBConnect obj = new DBConnect();

        public addpictures(int productid)
        {
            InitializeComponent();
            proid.Text = productid.ToString();

        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addpictures_Load(object sender, EventArgs e)
        {
            
        }
    }
}
