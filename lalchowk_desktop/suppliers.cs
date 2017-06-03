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
using System.Text.RegularExpressions;

namespace Veiled_Kashmir_Admin_Panel
{
    public partial class suppliers : Form
    {

        DBConnect obj = new DBConnect();
        String cmd;

        MySqlDataReader dr,dr2,dr3,dr4,dr5;

        private void suppliers_Load(object sender, EventArgs e)
        {
            readsuppliers();
        }

        DataTable dt;
        private container hp = null;
        public suppliers(Form hpcopy)
        {
            hp = hpcopy as container;
            InitializeComponent();
        }

        private void readsuppliers()
        {
            dr = obj.Query("select * from suppliers");

            dt = new DataTable();
            dt.Load(dr);
            BindingSource bsource = new BindingSource();

            bsource.DataSource = dt;
            supplierdatagridview.DataSource = bsource;

        }

        
    }
}
