﻿using System;
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
    public partial class container : Form
    {

       
        public container()
        {
            
            InitializeComponent();
        }


        private void Homepage_Load(object sender, EventArgs e)
        {
            loginform lg = new loginform(this,this);
            lg.TopLevel = false;
            mainpnl.Controls.Clear();
            mainpnl.Controls.Add(lg);
            lg.Show();
        }


        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void container_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormCollection fc = Application.OpenForms;
            if (fc.Count > 3)
            {
                e.Cancel = true;
                MessageBox.Show("Some functions are running in other windows, close them first.","Warning!");
                e.Cancel = true;
            }
          
        }
    }
}
