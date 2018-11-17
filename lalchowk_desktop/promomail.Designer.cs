namespace Veiled_Kashmir_Admin_Panel
{
    partial class promomail
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
            this.components = new System.ComponentModel.Container();
            this.label5 = new System.Windows.Forms.Label();
            this.frombox = new System.Windows.Forms.ComboBox();
            this.sendbtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.label4 = new System.Windows.Forms.Label();
            this.bodytxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.subtxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.totxt = new System.Windows.Forms.TextBox();
            this.bgworker = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tolbl = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.sendinglbl = new System.Windows.Forms.Label();
            this.emaillistpnl = new System.Windows.Forms.Panel();
            this.setrecno = new MaterialSkin.Controls.MaterialFlatButton();
            this.recno = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.setemailno = new MaterialSkin.Controls.MaterialFlatButton();
            this.emailno = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.elistlbl = new System.Windows.Forms.Label();
            this.emaillist = new System.Windows.Forms.ListBox();
            this.bgworker1 = new System.ComponentModel.BackgroundWorker();
            this.epnl = new System.Windows.Forms.Panel();
            this.opnl = new System.Windows.Forms.Panel();
            this.shippbtn = new System.Windows.Forms.Button();
            this.shiplbtn = new System.Windows.Forms.Button();
            this.feedbtn = new System.Windows.Forms.Button();
            this.checkhtml = new System.Windows.Forms.CheckBox();
            this.checkattach = new System.Windows.Forms.CheckBox();
            this.attachtxt = new System.Windows.Forms.TextBox();
            this.attachdialog = new System.Windows.Forms.OpenFileDialog();
            this.breqbtn = new System.Windows.Forms.Button();
            this.emaillistpnl.SuspendLayout();
            this.epnl.SuspendLayout();
            this.opnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label5.Location = new System.Drawing.Point(545, 553);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 16);
            this.label5.TabIndex = 75;
            this.label5.Text = "Send From:";
            // 
            // frombox
            // 
            this.frombox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.frombox.FormattingEnabled = true;
            this.frombox.Location = new System.Drawing.Point(628, 548);
            this.frombox.Name = "frombox";
            this.frombox.Size = new System.Drawing.Size(191, 21);
            this.frombox.TabIndex = 5;
            this.frombox.SelectedIndexChanged += new System.EventHandler(this.frombox_SelectedIndexChanged);
            // 
            // sendbtn
            // 
            this.sendbtn.AutoSize = true;
            this.sendbtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.sendbtn.Depth = 0;
            this.sendbtn.Location = new System.Drawing.Point(854, 539);
            this.sendbtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.sendbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.sendbtn.Name = "sendbtn";
            this.sendbtn.Primary = false;
            this.sendbtn.Size = new System.Drawing.Size(83, 36);
            this.sendbtn.TabIndex = 6;
            this.sendbtn.Text = "Send mail";
            this.sendbtn.UseVisualStyleBackColor = true;
            this.sendbtn.Click += new System.EventHandler(this.sendbtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(347, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 72;
            this.label4.Text = "Body";
            // 
            // bodytxt
            // 
            this.bodytxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bodytxt.Location = new System.Drawing.Point(350, 194);
            this.bodytxt.Multiline = true;
            this.bodytxt.Name = "bodytxt";
            this.bodytxt.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.bodytxt.Size = new System.Drawing.Size(587, 320);
            this.bodytxt.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(347, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 16);
            this.label3.TabIndex = 70;
            this.label3.Text = "Subject";
            // 
            // subtxt
            // 
            this.subtxt.Location = new System.Drawing.Point(350, 130);
            this.subtxt.Name = "subtxt";
            this.subtxt.Size = new System.Drawing.Size(587, 20);
            this.subtxt.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(347, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 16);
            this.label2.TabIndex = 79;
            this.label2.Text = "To";
            // 
            // totxt
            // 
            this.totxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totxt.Location = new System.Drawing.Point(350, 76);
            this.totxt.Name = "totxt";
            this.totxt.Size = new System.Drawing.Size(587, 20);
            this.totxt.TabIndex = 1;
            this.totxt.Text = "Enter single email here.";
            this.totxt.Enter += new System.EventHandler(this.totxt_Enter);
            this.totxt.Leave += new System.EventHandler(this.totxt_Leave);
            // 
            // bgworker
            // 
            this.bgworker.WorkerReportsProgress = true;
            this.bgworker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgworker_DoWork);
            this.bgworker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgworker_ProgressChanged);
            this.bgworker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgworker_RunWorkerCompleted);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(350, 609);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(587, 20);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 80;
            this.progressBar1.Visible = false;
            // 
            // tolbl
            // 
            this.tolbl.AutoSize = true;
            this.tolbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tolbl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.tolbl.Location = new System.Drawing.Point(347, 633);
            this.tolbl.Name = "tolbl";
            this.tolbl.Size = new System.Drawing.Size(0, 16);
            this.tolbl.TabIndex = 81;
            // 
            // timer
            // 
            this.timer.Interval = 600;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // sendinglbl
            // 
            this.sendinglbl.AutoSize = true;
            this.sendinglbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendinglbl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.sendinglbl.Location = new System.Drawing.Point(347, 590);
            this.sendinglbl.Name = "sendinglbl";
            this.sendinglbl.Size = new System.Drawing.Size(0, 16);
            this.sendinglbl.TabIndex = 82;
            // 
            // emaillistpnl
            // 
            this.emaillistpnl.Controls.Add(this.setrecno);
            this.emaillistpnl.Controls.Add(this.recno);
            this.emaillistpnl.Controls.Add(this.label7);
            this.emaillistpnl.Controls.Add(this.setemailno);
            this.emaillistpnl.Controls.Add(this.emailno);
            this.emaillistpnl.Controls.Add(this.label6);
            this.emaillistpnl.Controls.Add(this.elistlbl);
            this.emaillistpnl.Controls.Add(this.emaillist);
            this.emaillistpnl.Location = new System.Drawing.Point(12, 13);
            this.emaillistpnl.Name = "emaillistpnl";
            this.emaillistpnl.Size = new System.Drawing.Size(312, 516);
            this.emaillistpnl.TabIndex = 86;
            this.emaillistpnl.Visible = false;
            // 
            // setrecno
            // 
            this.setrecno.AutoSize = true;
            this.setrecno.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.setrecno.Depth = 0;
            this.setrecno.Location = new System.Drawing.Point(178, 9);
            this.setrecno.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.setrecno.MouseState = MaterialSkin.MouseState.HOVER;
            this.setrecno.Name = "setrecno";
            this.setrecno.Primary = false;
            this.setrecno.Size = new System.Drawing.Size(36, 36);
            this.setrecno.TabIndex = 93;
            this.setrecno.Text = "Set";
            this.setrecno.UseVisualStyleBackColor = true;
            this.setrecno.Click += new System.EventHandler(this.setrecno_Click);
            // 
            // recno
            // 
            this.recno.Location = new System.Drawing.Point(130, 16);
            this.recno.Name = "recno";
            this.recno.Size = new System.Drawing.Size(41, 20);
            this.recno.TabIndex = 92;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label7.Location = new System.Drawing.Point(5, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 13);
            this.label7.TabIndex = 91;
            this.label7.Text = "Set no. of recipients:";
            // 
            // setemailno
            // 
            this.setemailno.AutoSize = true;
            this.setemailno.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.setemailno.Depth = 0;
            this.setemailno.Location = new System.Drawing.Point(178, 40);
            this.setemailno.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.setemailno.MouseState = MaterialSkin.MouseState.HOVER;
            this.setemailno.Name = "setemailno";
            this.setemailno.Primary = false;
            this.setemailno.Size = new System.Drawing.Size(36, 36);
            this.setemailno.TabIndex = 90;
            this.setemailno.Text = "Set";
            this.setemailno.UseVisualStyleBackColor = true;
            this.setemailno.Click += new System.EventHandler(this.setemailno_Click);
            // 
            // emailno
            // 
            this.emailno.Location = new System.Drawing.Point(130, 47);
            this.emailno.Name = "emailno";
            this.emailno.Size = new System.Drawing.Size(41, 20);
            this.emailno.TabIndex = 89;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label6.Location = new System.Drawing.Point(5, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 13);
            this.label6.TabIndex = 88;
            this.label6.Text = "Set starting email id no.:";
            // 
            // elistlbl
            // 
            this.elistlbl.AutoSize = true;
            this.elistlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.elistlbl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.elistlbl.Location = new System.Drawing.Point(4, 83);
            this.elistlbl.Name = "elistlbl";
            this.elistlbl.Size = new System.Drawing.Size(282, 13);
            this.elistlbl.TabIndex = 87;
            this.elistlbl.Text = "Send email to 0 customers today or enter a single email ID.";
            // 
            // emaillist
            // 
            this.emaillist.FormattingEnabled = true;
            this.emaillist.Location = new System.Drawing.Point(8, 99);
            this.emaillist.Name = "emaillist";
            this.emaillist.Size = new System.Drawing.Size(298, 407);
            this.emaillist.TabIndex = 86;
            // 
            // bgworker1
            // 
            this.bgworker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgworker1_DoWork);
            this.bgworker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgworker1_RunWorkerCompleted);
            // 
            // epnl
            // 
            this.epnl.Controls.Add(this.opnl);
            this.epnl.Controls.Add(this.checkhtml);
            this.epnl.Controls.Add(this.checkattach);
            this.epnl.Controls.Add(this.attachtxt);
            this.epnl.Controls.Add(this.emaillistpnl);
            this.epnl.Controls.Add(this.subtxt);
            this.epnl.Controls.Add(this.sendinglbl);
            this.epnl.Controls.Add(this.label3);
            this.epnl.Controls.Add(this.tolbl);
            this.epnl.Controls.Add(this.bodytxt);
            this.epnl.Controls.Add(this.progressBar1);
            this.epnl.Controls.Add(this.label4);
            this.epnl.Controls.Add(this.label2);
            this.epnl.Controls.Add(this.sendbtn);
            this.epnl.Controls.Add(this.totxt);
            this.epnl.Controls.Add(this.frombox);
            this.epnl.Controls.Add(this.label5);
            this.epnl.Location = new System.Drawing.Point(0, 1);
            this.epnl.Name = "epnl";
            this.epnl.Size = new System.Drawing.Size(1029, 670);
            this.epnl.TabIndex = 87;
            this.epnl.Visible = false;
            // 
            // opnl
            // 
            this.opnl.Controls.Add(this.breqbtn);
            this.opnl.Controls.Add(this.shippbtn);
            this.opnl.Controls.Add(this.shiplbtn);
            this.opnl.Controls.Add(this.feedbtn);
            this.opnl.Location = new System.Drawing.Point(558, 159);
            this.opnl.Name = "opnl";
            this.opnl.Size = new System.Drawing.Size(383, 35);
            this.opnl.TabIndex = 91;
            this.opnl.Visible = false;
            // 
            // shippbtn
            // 
            this.shippbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.shippbtn.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.shippbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shippbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shippbtn.Location = new System.Drawing.Point(198, 6);
            this.shippbtn.Name = "shippbtn";
            this.shippbtn.Size = new System.Drawing.Size(93, 25);
            this.shippbtn.TabIndex = 92;
            this.shippbtn.Text = "Shipped Postal";
            this.shippbtn.UseVisualStyleBackColor = true;
            this.shippbtn.Click += new System.EventHandler(this.shippbtn_Click);
            // 
            // shiplbtn
            // 
            this.shiplbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.shiplbtn.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.shiplbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shiplbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shiplbtn.Location = new System.Drawing.Point(102, 6);
            this.shiplbtn.Name = "shiplbtn";
            this.shiplbtn.Size = new System.Drawing.Size(90, 25);
            this.shiplbtn.TabIndex = 91;
            this.shiplbtn.Text = "Shipped Local";
            this.shiplbtn.UseVisualStyleBackColor = true;
            this.shiplbtn.Click += new System.EventHandler(this.shiplbtn_Click);
            // 
            // feedbtn
            // 
            this.feedbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.feedbtn.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.feedbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.feedbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.feedbtn.Location = new System.Drawing.Point(297, 6);
            this.feedbtn.Name = "feedbtn";
            this.feedbtn.Size = new System.Drawing.Size(82, 25);
            this.feedbtn.TabIndex = 90;
            this.feedbtn.Text = "Feedback";
            this.feedbtn.UseVisualStyleBackColor = true;
            this.feedbtn.Click += new System.EventHandler(this.feedbtn_Click);
            // 
            // checkhtml
            // 
            this.checkhtml.AutoSize = true;
            this.checkhtml.ForeColor = System.Drawing.Color.Black;
            this.checkhtml.Location = new System.Drawing.Point(407, 173);
            this.checkhtml.Name = "checkhtml";
            this.checkhtml.Size = new System.Drawing.Size(78, 17);
            this.checkhtml.TabIndex = 3;
            this.checkhtml.Text = "Use HTML";
            this.checkhtml.UseVisualStyleBackColor = true;
            // 
            // checkattach
            // 
            this.checkattach.AutoSize = true;
            this.checkattach.ForeColor = System.Drawing.Color.Black;
            this.checkattach.Location = new System.Drawing.Point(350, 525);
            this.checkattach.Name = "checkattach";
            this.checkattach.Size = new System.Drawing.Size(80, 17);
            this.checkattach.TabIndex = 88;
            this.checkattach.Text = "Attachment";
            this.checkattach.UseVisualStyleBackColor = true;
            this.checkattach.CheckedChanged += new System.EventHandler(this.checkattach_CheckedChanged);
            // 
            // attachtxt
            // 
            this.attachtxt.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.attachtxt.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.attachtxt.Location = new System.Drawing.Point(350, 548);
            this.attachtxt.Name = "attachtxt";
            this.attachtxt.Size = new System.Drawing.Size(146, 20);
            this.attachtxt.TabIndex = 87;
            this.attachtxt.Text = "Add Attachment";
            this.attachtxt.Visible = false;
            this.attachtxt.Click += new System.EventHandler(this.attachtxt_Click);
            // 
            // attachdialog
            // 
            this.attachdialog.Filter = "All Files|*.*|PDF|*.pdf|Excel|*.xls";
            // 
            // breqbtn
            // 
            this.breqbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.breqbtn.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.breqbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.breqbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.breqbtn.Location = new System.Drawing.Point(3, 6);
            this.breqbtn.Name = "breqbtn";
            this.breqbtn.Size = new System.Drawing.Size(93, 25);
            this.breqbtn.TabIndex = 93;
            this.breqbtn.Text = "Book Request";
            this.breqbtn.UseVisualStyleBackColor = true;
            this.breqbtn.Click += new System.EventHandler(this.breqbtn_Click);
            // 
            // promomail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1162, 671);
            this.Controls.Add(this.epnl);
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "promomail";
            this.Text = "promomail";
            this.Load += new System.EventHandler(this.promomail_Load);
            this.emaillistpnl.ResumeLayout(false);
            this.emaillistpnl.PerformLayout();
            this.epnl.ResumeLayout(false);
            this.epnl.PerformLayout();
            this.opnl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox frombox;
        private MaterialSkin.Controls.MaterialFlatButton sendbtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox totxt;
        private System.ComponentModel.BackgroundWorker bgworker;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label tolbl;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label sendinglbl;
        private MaterialSkin.Controls.MaterialFlatButton setemailno;
        private System.Windows.Forms.TextBox emailno;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label elistlbl;
        public System.Windows.Forms.ListBox emaillist;
        private MaterialSkin.Controls.MaterialFlatButton setrecno;
        private System.Windows.Forms.TextBox recno;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Panel emaillistpnl;
        public System.ComponentModel.BackgroundWorker bgworker1;
        public System.Windows.Forms.Panel epnl;
        private System.Windows.Forms.OpenFileDialog attachdialog;
        public System.Windows.Forms.TextBox attachtxt;
        private System.Windows.Forms.CheckBox checkhtml;
        public System.Windows.Forms.CheckBox checkattach;
        public System.Windows.Forms.Panel opnl;
        private System.Windows.Forms.Button shippbtn;
        private System.Windows.Forms.Button shiplbtn;
        private System.Windows.Forms.Button feedbtn;
        private System.Windows.Forms.Button breqbtn;
        public System.Windows.Forms.TextBox bodytxt;
        public System.Windows.Forms.TextBox subtxt;
    }
}