﻿namespace Veiled_Kashmir_Admin_Panel
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
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.frombox = new System.Windows.Forms.ComboBox();
            this.sendbtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.label4 = new System.Windows.Forms.Label();
            this.bodytxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.subtxt = new System.Windows.Forms.TextBox();
            this.emaillist = new System.Windows.Forms.ListBox();
            this.elistlbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.totxt = new System.Windows.Forms.TextBox();
            this.bgworker = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tolbl = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.sendinglbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Send Promotional email";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label5.Location = new System.Drawing.Point(537, 567);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 16);
            this.label5.TabIndex = 75;
            this.label5.Text = "Send From:";
            // 
            // frombox
            // 
            this.frombox.FormattingEnabled = true;
            this.frombox.Location = new System.Drawing.Point(620, 562);
            this.frombox.Name = "frombox";
            this.frombox.Size = new System.Drawing.Size(191, 21);
            this.frombox.TabIndex = 74;
            this.frombox.SelectedIndexChanged += new System.EventHandler(this.frombox_SelectedIndexChanged);
            // 
            // sendbtn
            // 
            this.sendbtn.AutoSize = true;
            this.sendbtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.sendbtn.Depth = 0;
            this.sendbtn.Location = new System.Drawing.Point(846, 553);
            this.sendbtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.sendbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.sendbtn.Name = "sendbtn";
            this.sendbtn.Primary = false;
            this.sendbtn.Size = new System.Drawing.Size(83, 36);
            this.sendbtn.TabIndex = 73;
            this.sendbtn.Text = "Send mail";
            this.sendbtn.UseVisualStyleBackColor = true;
            this.sendbtn.Click += new System.EventHandler(this.sendbtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(339, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 72;
            this.label4.Text = "Body";
            // 
            // bodytxt
            // 
            this.bodytxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bodytxt.Location = new System.Drawing.Point(342, 208);
            this.bodytxt.Multiline = true;
            this.bodytxt.Name = "bodytxt";
            this.bodytxt.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.bodytxt.Size = new System.Drawing.Size(587, 320);
            this.bodytxt.TabIndex = 71;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(339, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 16);
            this.label3.TabIndex = 70;
            this.label3.Text = "Subject";
            // 
            // subtxt
            // 
            this.subtxt.Location = new System.Drawing.Point(342, 153);
            this.subtxt.Name = "subtxt";
            this.subtxt.Size = new System.Drawing.Size(587, 20);
            this.subtxt.TabIndex = 69;
            // 
            // emaillist
            // 
            this.emaillist.FormattingEnabled = true;
            this.emaillist.Location = new System.Drawing.Point(16, 74);
            this.emaillist.Name = "emaillist";
            this.emaillist.Size = new System.Drawing.Size(298, 459);
            this.emaillist.TabIndex = 76;
            this.emaillist.Visible = false;
            // 
            // elistlbl
            // 
            this.elistlbl.AutoSize = true;
            this.elistlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.elistlbl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.elistlbl.Location = new System.Drawing.Point(12, 51);
            this.elistlbl.Name = "elistlbl";
            this.elistlbl.Size = new System.Drawing.Size(288, 13);
            this.elistlbl.TabIndex = 77;
            this.elistlbl.Text = "Send email to 90 customers today or enter a single email ID.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(339, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 16);
            this.label2.TabIndex = 79;
            this.label2.Text = "To";
            // 
            // totxt
            // 
            this.totxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totxt.Location = new System.Drawing.Point(342, 97);
            this.totxt.Name = "totxt";
            this.totxt.Size = new System.Drawing.Size(587, 20);
            this.totxt.TabIndex = 78;
            this.totxt.Text = "Enter single email here.";
            this.totxt.Enter += new System.EventHandler(this.totxt_Enter);
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
            this.progressBar1.Location = new System.Drawing.Point(342, 623);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(587, 20);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 80;
            // 
            // tolbl
            // 
            this.tolbl.AutoSize = true;
            this.tolbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tolbl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.tolbl.Location = new System.Drawing.Point(339, 647);
            this.tolbl.Name = "tolbl";
            this.tolbl.Size = new System.Drawing.Size(0, 16);
            this.tolbl.TabIndex = 81;
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // sendinglbl
            // 
            this.sendinglbl.AutoSize = true;
            this.sendinglbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendinglbl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.sendinglbl.Location = new System.Drawing.Point(339, 604);
            this.sendinglbl.Name = "sendinglbl";
            this.sendinglbl.Size = new System.Drawing.Size(0, 16);
            this.sendinglbl.TabIndex = 82;
            // 
            // promomail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1162, 722);
            this.Controls.Add(this.sendinglbl);
            this.Controls.Add(this.tolbl);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.totxt);
            this.Controls.Add(this.elistlbl);
            this.Controls.Add(this.emaillist);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.frombox);
            this.Controls.Add(this.sendbtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bodytxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.subtxt);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "promomail";
            this.Text = "promomail";
            this.Load += new System.EventHandler(this.promomail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox frombox;
        private MaterialSkin.Controls.MaterialFlatButton sendbtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox bodytxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox subtxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox totxt;
        private System.ComponentModel.BackgroundWorker bgworker;
        private System.Windows.Forms.ProgressBar progressBar1;
        public System.Windows.Forms.ListBox emaillist;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label tolbl;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label sendinglbl;
        public System.Windows.Forms.Label elistlbl;
    }
}