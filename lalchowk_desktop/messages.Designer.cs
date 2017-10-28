namespace Veiled_Kashmir_Admin_Panel
{
    partial class messages
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
            this.messagesdataview = new System.Windows.Forms.DataGridView();
            this.formlbl = new System.Windows.Forms.Label();
            this.mpnl = new System.Windows.Forms.Panel();
            this.msgtxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.midlbl = new System.Windows.Forms.Label();
            this.emaillbl = new System.Windows.Forms.Label();
            this.sublbl = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.sendbtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.msgpnl = new System.Windows.Forms.Panel();
            this.bgworker = new System.ComponentModel.BackgroundWorker();
            this.delbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.messagesdataview)).BeginInit();
            this.mpnl.SuspendLayout();
            this.msgpnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // messagesdataview
            // 
            this.messagesdataview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.messagesdataview.BackgroundColor = System.Drawing.Color.White;
            this.messagesdataview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.messagesdataview.Location = new System.Drawing.Point(3, 37);
            this.messagesdataview.Name = "messagesdataview";
            this.messagesdataview.Size = new System.Drawing.Size(843, 414);
            this.messagesdataview.TabIndex = 1;
            this.messagesdataview.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.messagesdataview_CellClick);
            // 
            // formlbl
            // 
            this.formlbl.AutoSize = true;
            this.formlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formlbl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.formlbl.Location = new System.Drawing.Point(-1, 0);
            this.formlbl.Name = "formlbl";
            this.formlbl.Size = new System.Drawing.Size(140, 24);
            this.formlbl.TabIndex = 2;
            this.formlbl.Text = "User Messages";
            // 
            // mpnl
            // 
            this.mpnl.Controls.Add(this.delbtn);
            this.mpnl.Controls.Add(this.msgtxt);
            this.mpnl.Controls.Add(this.label2);
            this.mpnl.Controls.Add(this.midlbl);
            this.mpnl.Controls.Add(this.emaillbl);
            this.mpnl.Controls.Add(this.sublbl);
            this.mpnl.Controls.Add(this.label7);
            this.mpnl.Controls.Add(this.label8);
            this.mpnl.Controls.Add(this.label9);
            this.mpnl.Controls.Add(this.sendbtn);
            this.mpnl.Location = new System.Drawing.Point(1, 453);
            this.mpnl.Name = "mpnl";
            this.mpnl.Size = new System.Drawing.Size(845, 246);
            this.mpnl.TabIndex = 30;
            this.mpnl.Visible = false;
            // 
            // msgtxt
            // 
            this.msgtxt.Location = new System.Drawing.Point(253, 29);
            this.msgtxt.Multiline = true;
            this.msgtxt.Name = "msgtxt";
            this.msgtxt.ReadOnly = true;
            this.msgtxt.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.msgtxt.Size = new System.Drawing.Size(344, 171);
            this.msgtxt.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(400, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Message";
            // 
            // midlbl
            // 
            this.midlbl.AutoSize = true;
            this.midlbl.ForeColor = System.Drawing.Color.Black;
            this.midlbl.Location = new System.Drawing.Point(5, 32);
            this.midlbl.Name = "midlbl";
            this.midlbl.Size = new System.Drawing.Size(23, 13);
            this.midlbl.TabIndex = 2;
            this.midlbl.Text = "mid";
            // 
            // emaillbl
            // 
            this.emaillbl.AutoSize = true;
            this.emaillbl.ForeColor = System.Drawing.Color.Black;
            this.emaillbl.Location = new System.Drawing.Point(48, 32);
            this.emaillbl.Name = "emaillbl";
            this.emaillbl.Size = new System.Drawing.Size(31, 13);
            this.emaillbl.TabIndex = 3;
            this.emaillbl.Text = "email";
            // 
            // sublbl
            // 
            this.sublbl.ForeColor = System.Drawing.Color.Black;
            this.sublbl.Location = new System.Drawing.Point(5, 94);
            this.sublbl.Name = "sublbl";
            this.sublbl.Size = new System.Drawing.Size(188, 106);
            this.sublbl.TabIndex = 4;
            this.sublbl.Text = "mrp";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(3, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Subject";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(48, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Email";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Blue;
            this.label9.Location = new System.Drawing.Point(5, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Mid";
            // 
            // sendbtn
            // 
            this.sendbtn.AutoSize = true;
            this.sendbtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.sendbtn.Depth = 0;
            this.sendbtn.Location = new System.Drawing.Point(617, 94);
            this.sendbtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.sendbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.sendbtn.Name = "sendbtn";
            this.sendbtn.Primary = false;
            this.sendbtn.Size = new System.Drawing.Size(127, 36);
            this.sendbtn.TabIndex = 20;
            this.sendbtn.Text = "Send Reply mail";
            this.sendbtn.UseVisualStyleBackColor = true;
            this.sendbtn.Click += new System.EventHandler(this.sendbtn_Click);
            // 
            // msgpnl
            // 
            this.msgpnl.Controls.Add(this.messagesdataview);
            this.msgpnl.Controls.Add(this.mpnl);
            this.msgpnl.Location = new System.Drawing.Point(1, 1);
            this.msgpnl.Name = "msgpnl";
            this.msgpnl.Size = new System.Drawing.Size(1042, 709);
            this.msgpnl.TabIndex = 31;
            this.msgpnl.Visible = false;
            // 
            // bgworker
            // 
            this.bgworker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgworker_DoWork);
            this.bgworker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgworker_RunWorkerCompleted);
            // 
            // delbtn
            // 
            this.delbtn.Location = new System.Drawing.Point(796, 1);
            this.delbtn.Name = "delbtn";
            this.delbtn.Size = new System.Drawing.Size(48, 19);
            this.delbtn.TabIndex = 26;
            this.delbtn.Text = "Delete";
            this.delbtn.UseVisualStyleBackColor = true;
            this.delbtn.Click += new System.EventHandler(this.delbtn_Click);
            // 
            // messages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1162, 722);
            this.Controls.Add(this.msgpnl);
            this.Controls.Add(this.formlbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "messages";
            this.Text = "messages";
            ((System.ComponentModel.ISupportInitialize)(this.messagesdataview)).EndInit();
            this.mpnl.ResumeLayout(false);
            this.mpnl.PerformLayout();
            this.msgpnl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView messagesdataview;
        private System.Windows.Forms.Label formlbl;
        private System.Windows.Forms.Panel mpnl;
        private System.Windows.Forms.Label midlbl;
        private System.Windows.Forms.Label emaillbl;
        private System.Windows.Forms.Label sublbl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private MaterialSkin.Controls.MaterialFlatButton sendbtn;
        private System.Windows.Forms.TextBox msgtxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel msgpnl;
        private System.ComponentModel.BackgroundWorker bgworker;
        private System.Windows.Forms.Button delbtn;
    }
}