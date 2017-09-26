﻿using System;
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
    public partial class viewproducts : Form
    {
        MySqlConnection con = new MySqlConnection("SERVER= 182.50.133.78; DATABASE=lalchowk;USER=lalchowk;PASSWORD=Lalchowk@123uzmah");
        MySqlDataAdapter adap;
        DataTable dt;
        string url = "http://lalchowk.in/lalchowk/pictures/";



        public viewproducts()
        {
            InitializeComponent();
            readproducts();
        }

        private void readproducts()
        {
            con.Open();
            adap = new MySqlDataAdapter("select productid, productname, groupid, mrp, price, dealerprice, stock, picture from products", con);
            dt = new DataTable();
            adap.Fill(dt);
            con.Close();
            BindingSource bsource = new BindingSource();
            bsource.DataSource = dt;
            productsdataview.DataSource = bsource;
        }

        private void productsdataview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.productsdataview.Rows[e.RowIndex];
                string piclocation = row.Cells["picture"].Value.ToString();
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.ImageLocation = (url + piclocation);
            }
        }
    }
}
