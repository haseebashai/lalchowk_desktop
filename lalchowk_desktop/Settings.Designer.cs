﻿namespace Veiled_Kashmir_Admin_Panel
{
    partial class Settings
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
            this.spnl = new System.Windows.Forms.Panel();
            this.updbtn = new System.Windows.Forms.Button();
            this.epnl = new System.Windows.Forms.Panel();
            this.ppnl = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.areatxt = new System.Windows.Forms.TextBox();
            this.addpbtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.deltxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.loadingaccpic = new System.Windows.Forms.PictureBox();
            this.loadinglbl = new System.Windows.Forms.Label();
            this.settingsdataview = new System.Windows.Forms.DataGridView();
            this.bpnl = new System.Windows.Forms.Panel();
            this.verbtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.pinbtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.otpbtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.pyes = new System.Windows.Forms.CheckBox();
            this.pno = new System.Windows.Forms.CheckBox();
            this.bgotp = new System.ComponentModel.BackgroundWorker();
            this.bgpincodes = new System.ComponentModel.BackgroundWorker();
            this.bgverification = new System.ComponentModel.BackgroundWorker();
            this.formlbl = new System.Windows.Forms.Label();
            this.pintxt = new System.Windows.Forms.MaskedTextBox();
            this.spnl.SuspendLayout();
            this.epnl.SuspendLayout();
            this.ppnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadingaccpic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingsdataview)).BeginInit();
            this.bpnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // spnl
            // 
            this.spnl.Controls.Add(this.updbtn);
            this.spnl.Controls.Add(this.epnl);
            this.spnl.Controls.Add(this.loadingaccpic);
            this.spnl.Controls.Add(this.loadinglbl);
            this.spnl.Controls.Add(this.settingsdataview);
            this.spnl.Controls.Add(this.bpnl);
            this.spnl.Location = new System.Drawing.Point(2, 0);
            this.spnl.Name = "spnl";
            this.spnl.Size = new System.Drawing.Size(1159, 722);
            this.spnl.TabIndex = 2;
            // 
            // updbtn
            // 
            this.updbtn.Location = new System.Drawing.Point(1018, 382);
            this.updbtn.Name = "updbtn";
            this.updbtn.Size = new System.Drawing.Size(120, 112);
            this.updbtn.TabIndex = 52;
            this.updbtn.Text = "Update Entry";
            this.updbtn.UseVisualStyleBackColor = true;
            this.updbtn.Visible = false;
            this.updbtn.Click += new System.EventHandler(this.updbtn_Click);
            // 
            // epnl
            // 
            this.epnl.Controls.Add(this.ppnl);
            this.epnl.Location = new System.Drawing.Point(3, 55);
            this.epnl.Name = "epnl";
            this.epnl.Size = new System.Drawing.Size(1159, 177);
            this.epnl.TabIndex = 51;
            this.epnl.Visible = false;
            // 
            // ppnl
            // 
            this.ppnl.Controls.Add(this.pintxt);
            this.ppnl.Controls.Add(this.label8);
            this.ppnl.Controls.Add(this.pno);
            this.ppnl.Controls.Add(this.pyes);
            this.ppnl.Controls.Add(this.areatxt);
            this.ppnl.Controls.Add(this.addpbtn);
            this.ppnl.Controls.Add(this.label3);
            this.ppnl.Controls.Add(this.label2);
            this.ppnl.Controls.Add(this.deltxt);
            this.ppnl.Controls.Add(this.label1);
            this.ppnl.Location = new System.Drawing.Point(3, 3);
            this.ppnl.Name = "ppnl";
            this.ppnl.Size = new System.Drawing.Size(1153, 170);
            this.ppnl.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 101;
            this.label8.Text = "Pincode";
            // 
            // areatxt
            // 
            this.areatxt.Location = new System.Drawing.Point(214, 113);
            this.areatxt.Name = "areatxt";
            this.areatxt.Size = new System.Drawing.Size(169, 20);
            this.areatxt.TabIndex = 106;
            // 
            // addpbtn
            // 
            this.addpbtn.AutoSize = true;
            this.addpbtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addpbtn.Depth = 0;
            this.addpbtn.Location = new System.Drawing.Point(421, 104);
            this.addpbtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.addpbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.addpbtn.Name = "addpbtn";
            this.addpbtn.Primary = false;
            this.addpbtn.Size = new System.Drawing.Size(100, 36);
            this.addpbtn.TabIndex = 28;
            this.addpbtn.Text = "add pincode";
            this.addpbtn.UseVisualStyleBackColor = true;
            this.addpbtn.Click += new System.EventHandler(this.addpbtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(211, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Area";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(211, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "COD";
            // 
            // deltxt
            // 
            this.deltxt.Location = new System.Drawing.Point(16, 113);
            this.deltxt.Name = "deltxt";
            this.deltxt.Size = new System.Drawing.Size(143, 20);
            this.deltxt.TabIndex = 103;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Delivery Time";
            // 
            // loadingaccpic
            // 
            this.loadingaccpic.Image = global::Veiled_Kashmir_Admin_Panel.Properties.Resources.loading;
            this.loadingaccpic.Location = new System.Drawing.Point(186, 99);
            this.loadingaccpic.Name = "loadingaccpic";
            this.loadingaccpic.Size = new System.Drawing.Size(140, 86);
            this.loadingaccpic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.loadingaccpic.TabIndex = 49;
            this.loadingaccpic.TabStop = false;
            this.loadingaccpic.Visible = false;
            // 
            // loadinglbl
            // 
            this.loadinglbl.AutoSize = true;
            this.loadinglbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadinglbl.Location = new System.Drawing.Point(186, 184);
            this.loadinglbl.Name = "loadinglbl";
            this.loadinglbl.Size = new System.Drawing.Size(140, 25);
            this.loadinglbl.TabIndex = 50;
            this.loadinglbl.Text = "Gathering data";
            this.loadinglbl.Visible = false;
            // 
            // settingsdataview
            // 
            this.settingsdataview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.settingsdataview.BackgroundColor = System.Drawing.Color.White;
            this.settingsdataview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.settingsdataview.Location = new System.Drawing.Point(3, 234);
            this.settingsdataview.Name = "settingsdataview";
            this.settingsdataview.Size = new System.Drawing.Size(1009, 400);
            this.settingsdataview.TabIndex = 21;
            this.settingsdataview.Visible = false;
            // 
            // bpnl
            // 
            this.bpnl.Controls.Add(this.verbtn);
            this.bpnl.Controls.Add(this.pinbtn);
            this.bpnl.Controls.Add(this.otpbtn);
            this.bpnl.Location = new System.Drawing.Point(3, 3);
            this.bpnl.Name = "bpnl";
            this.bpnl.Size = new System.Drawing.Size(1153, 50);
            this.bpnl.TabIndex = 1;
            this.bpnl.Visible = false;
            // 
            // verbtn
            // 
            this.verbtn.AutoSize = true;
            this.verbtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.verbtn.Depth = 0;
            this.verbtn.Location = new System.Drawing.Point(200, 8);
            this.verbtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.verbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.verbtn.Name = "verbtn";
            this.verbtn.Primary = false;
            this.verbtn.Size = new System.Drawing.Size(139, 36);
            this.verbtn.TabIndex = 21;
            this.verbtn.Text = "User Verification";
            this.verbtn.UseVisualStyleBackColor = true;
            this.verbtn.Click += new System.EventHandler(this.verbtn_Click);
            // 
            // pinbtn
            // 
            this.pinbtn.AutoSize = true;
            this.pinbtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pinbtn.Depth = 0;
            this.pinbtn.Location = new System.Drawing.Point(84, 8);
            this.pinbtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.pinbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.pinbtn.Name = "pinbtn";
            this.pinbtn.Primary = false;
            this.pinbtn.Size = new System.Drawing.Size(78, 36);
            this.pinbtn.TabIndex = 20;
            this.pinbtn.Text = "Pincodes";
            this.pinbtn.UseVisualStyleBackColor = true;
            this.pinbtn.Click += new System.EventHandler(this.pinbtn_Click);
            // 
            // otpbtn
            // 
            this.otpbtn.AutoSize = true;
            this.otpbtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.otpbtn.Depth = 0;
            this.otpbtn.Location = new System.Drawing.Point(8, 8);
            this.otpbtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.otpbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.otpbtn.Name = "otpbtn";
            this.otpbtn.Primary = false;
            this.otpbtn.Size = new System.Drawing.Size(39, 36);
            this.otpbtn.TabIndex = 19;
            this.otpbtn.Text = "OTP";
            this.otpbtn.UseVisualStyleBackColor = true;
            this.otpbtn.Click += new System.EventHandler(this.otpbtn_Click);
            // 
            // pyes
            // 
            this.pyes.AutoSize = true;
            this.pyes.Location = new System.Drawing.Point(214, 59);
            this.pyes.Name = "pyes";
            this.pyes.Size = new System.Drawing.Size(44, 17);
            this.pyes.TabIndex = 104;
            this.pyes.Text = "Yes";
            this.pyes.UseVisualStyleBackColor = true;
            this.pyes.CheckedChanged += new System.EventHandler(this.pyes_CheckedChanged);
            // 
            // pno
            // 
            this.pno.AutoSize = true;
            this.pno.Location = new System.Drawing.Point(264, 59);
            this.pno.Name = "pno";
            this.pno.Size = new System.Drawing.Size(40, 17);
            this.pno.TabIndex = 105;
            this.pno.Text = "No";
            this.pno.UseVisualStyleBackColor = true;
            this.pno.CheckedChanged += new System.EventHandler(this.pno_CheckedChanged);
            // 
            // bgotp
            // 
            this.bgotp.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgotp_DoWork);
            this.bgotp.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgotp_RunWorkerCompleted);
            // 
            // bgpincodes
            // 
            this.bgpincodes.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgpincodes_DoWork);
            this.bgpincodes.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgpincodes_RunWorkerCompleted);
            // 
            // bgverification
            // 
            this.bgverification.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgverification_DoWork);
            this.bgverification.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgverification_RunWorkerCompleted);
            // 
            // formlbl
            // 
            this.formlbl.AutoSize = true;
            this.formlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formlbl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.formlbl.Location = new System.Drawing.Point(-1, 0);
            this.formlbl.Name = "formlbl";
            this.formlbl.Size = new System.Drawing.Size(141, 25);
            this.formlbl.TabIndex = 102;
            this.formlbl.Text = "OTP/Pincodes";
            // 
            // pintxt
            // 
            this.pintxt.Culture = new System.Globalization.CultureInfo("en-IN");
            this.pintxt.Location = new System.Drawing.Point(16, 56);
            this.pintxt.Mask = "000000";
            this.pintxt.Name = "pintxt";
            this.pintxt.PromptChar = ' ';
            this.pintxt.Size = new System.Drawing.Size(143, 20);
            this.pintxt.TabIndex = 102;
            this.pintxt.Click += new System.EventHandler(this.pintxt_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1162, 722);
            this.Controls.Add(this.spnl);
            this.Controls.Add(this.formlbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Settings";
            this.Text = "Settings";
            this.spnl.ResumeLayout(false);
            this.spnl.PerformLayout();
            this.epnl.ResumeLayout(false);
            this.ppnl.ResumeLayout(false);
            this.ppnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadingaccpic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingsdataview)).EndInit();
            this.bpnl.ResumeLayout(false);
            this.bpnl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel spnl;
        private System.Windows.Forms.Button updbtn;
        private System.Windows.Forms.Panel epnl;
        private System.Windows.Forms.Panel ppnl;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox pno;
        private System.Windows.Forms.CheckBox pyes;
        private System.Windows.Forms.TextBox areatxt;
        private MaterialSkin.Controls.MaterialFlatButton addpbtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox deltxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox loadingaccpic;
        private System.Windows.Forms.Label loadinglbl;
        private System.Windows.Forms.DataGridView settingsdataview;
        private System.Windows.Forms.Panel bpnl;
        private MaterialSkin.Controls.MaterialFlatButton verbtn;
        private MaterialSkin.Controls.MaterialFlatButton pinbtn;
        private MaterialSkin.Controls.MaterialFlatButton otpbtn;
        private System.ComponentModel.BackgroundWorker bgotp;
        private System.ComponentModel.BackgroundWorker bgpincodes;
        private System.ComponentModel.BackgroundWorker bgverification;
        private System.Windows.Forms.Label formlbl;
        private System.Windows.Forms.MaskedTextBox pintxt;
    }
}