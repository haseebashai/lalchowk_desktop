﻿namespace Veiled_Kashmir_Admin_Panel
{
    partial class mainform
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.signoutlbl = new System.Windows.Forms.Label();
            this.productsbtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.customersbtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.suppliersbtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.sendmsgbtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.signinlbl = new System.Windows.Forms.Label();
            this.navpnl = new System.Windows.Forms.Panel();
            this.expbtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.rptbtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.ordersbtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.navtitle = new System.Windows.Forms.Panel();
            this.navtxt = new System.Windows.Forms.Label();
            this.cntpnl = new System.Windows.Forms.Panel();
            this.navpnl.SuspendLayout();
            this.navtitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // signoutlbl
            // 
            this.signoutlbl.AutoSize = true;
            this.signoutlbl.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signoutlbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.signoutlbl.Location = new System.Drawing.Point(144, 691);
            this.signoutlbl.Name = "signoutlbl";
            this.signoutlbl.Size = new System.Drawing.Size(55, 16);
            this.signoutlbl.TabIndex = 16;
            this.signoutlbl.Text = "SIGN OUT";
            this.signoutlbl.Visible = false;
            this.signoutlbl.Click += new System.EventHandler(this.signoutlbl_Click);
            this.signoutlbl.MouseHover += new System.EventHandler(this.signoutlbl_Enter);
            // 
            // productsbtn
            // 
            this.productsbtn.AutoSize = true;
            this.productsbtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.productsbtn.Depth = 0;
            this.productsbtn.Location = new System.Drawing.Point(8, 67);
            this.productsbtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.productsbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.productsbtn.Name = "productsbtn";
            this.productsbtn.Primary = false;
            this.productsbtn.Size = new System.Drawing.Size(82, 36);
            this.productsbtn.TabIndex = 12;
            this.productsbtn.Text = "products";
            this.productsbtn.UseVisualStyleBackColor = true;
            this.productsbtn.Click += new System.EventHandler(this.productsbtn_Click);
            // 
            // customersbtn
            // 
            this.customersbtn.AutoSize = true;
            this.customersbtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.customersbtn.Depth = 0;
            this.customersbtn.Location = new System.Drawing.Point(8, 115);
            this.customersbtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.customersbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.customersbtn.Name = "customersbtn";
            this.customersbtn.Primary = false;
            this.customersbtn.Size = new System.Drawing.Size(93, 36);
            this.customersbtn.TabIndex = 14;
            this.customersbtn.Text = "customers";
            this.customersbtn.UseVisualStyleBackColor = true;
            this.customersbtn.Click += new System.EventHandler(this.customersbtn_Click);
            // 
            // suppliersbtn
            // 
            this.suppliersbtn.AutoSize = true;
            this.suppliersbtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.suppliersbtn.Depth = 0;
            this.suppliersbtn.Location = new System.Drawing.Point(8, 163);
            this.suppliersbtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.suppliersbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.suppliersbtn.Name = "suppliersbtn";
            this.suppliersbtn.Primary = false;
            this.suppliersbtn.Size = new System.Drawing.Size(83, 36);
            this.suppliersbtn.TabIndex = 13;
            this.suppliersbtn.Text = "suppliers";
            this.suppliersbtn.UseVisualStyleBackColor = true;
            this.suppliersbtn.Click += new System.EventHandler(this.suppliersbtn_Click);
            // 
            // sendmsgbtn
            // 
            this.sendmsgbtn.AutoSize = true;
            this.sendmsgbtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.sendmsgbtn.Depth = 0;
            this.sendmsgbtn.Location = new System.Drawing.Point(8, 259);
            this.sendmsgbtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.sendmsgbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.sendmsgbtn.Name = "sendmsgbtn";
            this.sendmsgbtn.Primary = false;
            this.sendmsgbtn.Size = new System.Drawing.Size(143, 36);
            this.sendmsgbtn.TabIndex = 15;
            this.sendmsgbtn.Text = "send Notification";
            this.sendmsgbtn.UseVisualStyleBackColor = true;
            // 
            // signinlbl
            // 
            this.signinlbl.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signinlbl.Location = new System.Drawing.Point(7, 668);
            this.signinlbl.Name = "signinlbl";
            this.signinlbl.Size = new System.Drawing.Size(192, 25);
            this.signinlbl.TabIndex = 9;
            this.signinlbl.Text = "Welcome, admin";
            this.signinlbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.signinlbl.Visible = false;
            // 
            // navpnl
            // 
            this.navpnl.BackColor = System.Drawing.Color.White;
            this.navpnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.navpnl.Controls.Add(this.signoutlbl);
            this.navpnl.Controls.Add(this.signinlbl);
            this.navpnl.Controls.Add(this.expbtn);
            this.navpnl.Controls.Add(this.rptbtn);
            this.navpnl.Controls.Add(this.productsbtn);
            this.navpnl.Controls.Add(this.sendmsgbtn);
            this.navpnl.Controls.Add(this.customersbtn);
            this.navpnl.Controls.Add(this.suppliersbtn);
            this.navpnl.Controls.Add(this.ordersbtn);
            this.navpnl.Location = new System.Drawing.Point(0, 12);
            this.navpnl.Name = "navpnl";
            this.navpnl.Size = new System.Drawing.Size(200, 711);
            this.navpnl.TabIndex = 10;
            // 
            // expbtn
            // 
            this.expbtn.AutoSize = true;
            this.expbtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.expbtn.Depth = 0;
            this.expbtn.Location = new System.Drawing.Point(8, 211);
            this.expbtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.expbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.expbtn.Name = "expbtn";
            this.expbtn.Primary = false;
            this.expbtn.Size = new System.Drawing.Size(101, 36);
            this.expbtn.TabIndex = 11;
            this.expbtn.Text = "Expenditure";
            this.expbtn.UseVisualStyleBackColor = true;
            this.expbtn.Click += new System.EventHandler(this.expbtn_Click);
            // 
            // rptbtn
            // 
            this.rptbtn.AutoSize = true;
            this.rptbtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.rptbtn.Depth = 0;
            this.rptbtn.Location = new System.Drawing.Point(8, 307);
            this.rptbtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.rptbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.rptbtn.Name = "rptbtn";
            this.rptbtn.Primary = false;
            this.rptbtn.Size = new System.Drawing.Size(144, 36);
            this.rptbtn.TabIndex = 17;
            this.rptbtn.Text = "Generate Reports";
            this.rptbtn.UseVisualStyleBackColor = true;
            // 
            // ordersbtn
            // 
            this.ordersbtn.AutoSize = true;
            this.ordersbtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ordersbtn.Depth = 0;
            this.ordersbtn.Location = new System.Drawing.Point(8, 19);
            this.ordersbtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.ordersbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.ordersbtn.Name = "ordersbtn";
            this.ordersbtn.Primary = false;
            this.ordersbtn.Size = new System.Drawing.Size(64, 36);
            this.ordersbtn.TabIndex = 10;
            this.ordersbtn.Text = "orders";
            this.ordersbtn.UseVisualStyleBackColor = true;
            this.ordersbtn.Click += new System.EventHandler(this.ordersbtn_Click);
            // 
            // navtitle
            // 
            this.navtitle.BackColor = System.Drawing.Color.LightGray;
            this.navtitle.Controls.Add(this.navtxt);
            this.navtitle.Location = new System.Drawing.Point(0, 1);
            this.navtitle.Name = "navtitle";
            this.navtitle.Size = new System.Drawing.Size(200, 22);
            this.navtitle.TabIndex = 11;
            // 
            // navtxt
            // 
            this.navtxt.AutoSize = true;
            this.navtxt.BackColor = System.Drawing.Color.Transparent;
            this.navtxt.Font = new System.Drawing.Font("Myriad Hebrew", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navtxt.ForeColor = System.Drawing.Color.White;
            this.navtxt.Location = new System.Drawing.Point(51, 1);
            this.navtxt.Name = "navtxt";
            this.navtxt.Size = new System.Drawing.Size(84, 19);
            this.navtxt.TabIndex = 0;
            this.navtxt.Text = "Navigation";
            // 
            // cntpnl
            // 
            this.cntpnl.BackColor = System.Drawing.Color.White;
            this.cntpnl.Location = new System.Drawing.Point(201, 1);
            this.cntpnl.Name = "cntpnl";
            this.cntpnl.Size = new System.Drawing.Size(1162, 722);
            this.cntpnl.TabIndex = 12;
            // 
            // mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1363, 725);
            this.Controls.Add(this.cntpnl);
            this.Controls.Add(this.navtitle);
            this.Controls.Add(this.navpnl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "mainform";
            this.Text = "mainform";
            this.Load += new System.EventHandler(this.mainform_Load);
            this.navpnl.ResumeLayout(false);
            this.navpnl.PerformLayout();
            this.navtitle.ResumeLayout(false);
            this.navtitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label signoutlbl;
        private MaterialSkin.Controls.MaterialFlatButton productsbtn;
        private MaterialSkin.Controls.MaterialFlatButton suppliersbtn;
        private MaterialSkin.Controls.MaterialFlatButton customersbtn;
        private MaterialSkin.Controls.MaterialFlatButton sendmsgbtn;
        private System.Windows.Forms.Label signinlbl;
        private System.Windows.Forms.Panel navpnl;
        private MaterialSkin.Controls.MaterialFlatButton ordersbtn;
        private MaterialSkin.Controls.MaterialFlatButton expbtn;
        private MaterialSkin.Controls.MaterialFlatButton rptbtn;
        private System.Windows.Forms.Panel navtitle;
        private System.Windows.Forms.Label navtxt;
        public System.Windows.Forms.Panel cntpnl;
    }
}