namespace Modest_Attires
{
    partial class notification
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(notification));
            this.formlbl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.emailtxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.titletxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.subtxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pic = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.sendbtn = new System.Windows.Forms.Button();
            this.orderidbox = new System.Windows.Forms.ComboBox();
            this.npnl = new System.Windows.Forms.Panel();
            this.picbtn = new System.Windows.Forms.Button();
            this.ptxt = new System.Windows.Forms.TextBox();
            this.chkbox = new System.Windows.Forms.CheckBox();
            this.bgworker = new System.ComponentModel.BackgroundWorker();
            this.picdialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.npnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // formlbl
            // 
            this.formlbl.AutoSize = true;
            this.formlbl.BackColor = System.Drawing.Color.White;
            this.formlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formlbl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.formlbl.Location = new System.Drawing.Point(7, 9);
            this.formlbl.Name = "formlbl";
            this.formlbl.Size = new System.Drawing.Size(175, 25);
            this.formlbl.TabIndex = 34;
            this.formlbl.Text = "Send Notification";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Location = new System.Drawing.Point(0, -20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 461);
            this.panel1.TabIndex = 54;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 419);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(573, 1);
            this.panel3.TabIndex = 53;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(573, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 419);
            this.panel2.TabIndex = 52;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(574, 1);
            this.panel5.TabIndex = 51;
            // 
            // emailtxt
            // 
            this.emailtxt.Location = new System.Drawing.Point(56, 5);
            this.emailtxt.Name = "emailtxt";
            this.emailtxt.Size = new System.Drawing.Size(296, 20);
            this.emailtxt.TabIndex = 55;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 56;
            this.label1.Text = "Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 58;
            this.label2.Text = "Title";
            // 
            // titletxt
            // 
            this.titletxt.Location = new System.Drawing.Point(56, 45);
            this.titletxt.Multiline = true;
            this.titletxt.Name = "titletxt";
            this.titletxt.Size = new System.Drawing.Size(296, 20);
            this.titletxt.TabIndex = 57;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 60;
            this.label3.Text = "Subtitle";
            // 
            // subtxt
            // 
            this.subtxt.Location = new System.Drawing.Point(56, 83);
            this.subtxt.Multiline = true;
            this.subtxt.Name = "subtxt";
            this.subtxt.Size = new System.Drawing.Size(296, 20);
            this.subtxt.TabIndex = 59;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 61;
            this.label4.Text = "Picture";
            // 
            // pic
            // 
            this.pic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic.Location = new System.Drawing.Point(51, 140);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(186, 132);
            this.pic.TabIndex = 62;
            this.pic.TabStop = false;
            this.pic.Click += new System.EventHandler(this.pic_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(259, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 64;
            this.label5.Text = "OrderID";
            // 
            // sendbtn
            // 
            this.sendbtn.Location = new System.Drawing.Point(432, 265);
            this.sendbtn.Name = "sendbtn";
            this.sendbtn.Size = new System.Drawing.Size(102, 33);
            this.sendbtn.TabIndex = 65;
            this.sendbtn.Text = "&Send";
            this.sendbtn.UseVisualStyleBackColor = true;
            this.sendbtn.Click += new System.EventHandler(this.sendbtn_Click_1);
            // 
            // orderidbox
            // 
            this.orderidbox.FormattingEnabled = true;
            this.orderidbox.Items.AddRange(new object[] {
            ""});
            this.orderidbox.Location = new System.Drawing.Point(310, 138);
            this.orderidbox.Name = "orderidbox";
            this.orderidbox.Size = new System.Drawing.Size(121, 21);
            this.orderidbox.TabIndex = 66;
            // 
            // npnl
            // 
            this.npnl.Controls.Add(this.picbtn);
            this.npnl.Controls.Add(this.ptxt);
            this.npnl.Controls.Add(this.chkbox);
            this.npnl.Controls.Add(this.label1);
            this.npnl.Controls.Add(this.orderidbox);
            this.npnl.Controls.Add(this.emailtxt);
            this.npnl.Controls.Add(this.sendbtn);
            this.npnl.Controls.Add(this.titletxt);
            this.npnl.Controls.Add(this.label5);
            this.npnl.Controls.Add(this.label2);
            this.npnl.Controls.Add(this.pic);
            this.npnl.Controls.Add(this.subtxt);
            this.npnl.Controls.Add(this.label4);
            this.npnl.Controls.Add(this.label3);
            this.npnl.Location = new System.Drawing.Point(12, 83);
            this.npnl.Name = "npnl";
            this.npnl.Size = new System.Drawing.Size(551, 325);
            this.npnl.TabIndex = 67;
            this.npnl.Visible = false;
            // 
            // picbtn
            // 
            this.picbtn.Location = new System.Drawing.Point(243, 265);
            this.picbtn.Name = "picbtn";
            this.picbtn.Size = new System.Drawing.Size(60, 33);
            this.picbtn.TabIndex = 69;
            this.picbtn.Text = "&Upload";
            this.picbtn.UseVisualStyleBackColor = true;
            this.picbtn.Click += new System.EventHandler(this.picbtn_Click);
            // 
            // ptxt
            // 
            this.ptxt.Location = new System.Drawing.Point(51, 278);
            this.ptxt.Multiline = true;
            this.ptxt.Name = "ptxt";
            this.ptxt.Size = new System.Drawing.Size(186, 20);
            this.ptxt.TabIndex = 68;
            // 
            // chkbox
            // 
            this.chkbox.AutoSize = true;
            this.chkbox.Location = new System.Drawing.Point(385, 236);
            this.chkbox.Name = "chkbox";
            this.chkbox.Size = new System.Drawing.Size(154, 17);
            this.chkbox.TabIndex = 67;
            this.chkbox.Text = "Send General notification ?";
            this.chkbox.UseVisualStyleBackColor = true;
            // 
            // bgworker
            // 
            this.bgworker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgworker_DoWork);
            this.bgworker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgworker_RunWorkerCompleted);
            // 
            // picdialog
            // 
            this.picdialog.FileName = "picdialog";
            // 
            // notification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(574, 420);
            this.Controls.Add(this.npnl);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.formlbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "notification";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notification";
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.npnl.ResumeLayout(false);
            this.npnl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label formlbl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox emailtxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox titletxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox subtxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button sendbtn;
        private System.Windows.Forms.ComboBox orderidbox;
        private System.Windows.Forms.Panel npnl;
        private System.ComponentModel.BackgroundWorker bgworker;
        private System.Windows.Forms.CheckBox chkbox;
        private System.Windows.Forms.OpenFileDialog picdialog;
        private System.Windows.Forms.TextBox ptxt;
        private System.Windows.Forms.Button picbtn;
    }
}