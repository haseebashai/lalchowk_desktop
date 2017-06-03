namespace Veiled_Kashmir_Admin_Panel
{
    partial class reviews
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
            this.back = new System.Windows.Forms.PictureBox();
            this.addevpnl = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.placelbl = new System.Windows.Forms.Label();
            this.reviewbox = new System.Windows.Forms.ListBox();
            this.rvmrepbtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.label1 = new System.Windows.Forms.Label();
            this.userlist = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.back)).BeginInit();
            this.addevpnl.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // back
            // 
            this.back.BackgroundImage = global::Veiled_Kashmir_Admin_Panel.Properties.Resources._9895;
            this.back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.back.Location = new System.Drawing.Point(12, 11);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(64, 64);
            this.back.TabIndex = 27;
            this.back.TabStop = false;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // addevpnl
            // 
            this.addevpnl.Controls.Add(this.panel2);
            this.addevpnl.Controls.Add(this.label1);
            this.addevpnl.Controls.Add(this.userlist);
            this.addevpnl.Location = new System.Drawing.Point(12, 128);
            this.addevpnl.Name = "addevpnl";
            this.addevpnl.Size = new System.Drawing.Size(998, 420);
            this.addevpnl.TabIndex = 30;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.placelbl);
            this.panel2.Controls.Add(this.reviewbox);
            this.panel2.Controls.Add(this.rvmrepbtn);
            this.panel2.Location = new System.Drawing.Point(364, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(620, 387);
            this.panel2.TabIndex = 15;
            // 
            // placelbl
            // 
            this.placelbl.AutoSize = true;
            this.placelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.placelbl.Location = new System.Drawing.Point(507, 4);
            this.placelbl.Name = "placelbl";
            this.placelbl.Size = new System.Drawing.Size(32, 13);
            this.placelbl.TabIndex = 15;
            this.placelbl.Text = "place";
            // 
            // reviewbox
            // 
            this.reviewbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reviewbox.FormattingEnabled = true;
            this.reviewbox.ItemHeight = 16;
            this.reviewbox.Location = new System.Drawing.Point(3, 3);
            this.reviewbox.Name = "reviewbox";
            this.reviewbox.Size = new System.Drawing.Size(498, 372);
            this.reviewbox.TabIndex = 11;
            this.reviewbox.SelectedIndexChanged += new System.EventHandler(this.reviewbox_SelectedIndexChanged);
            // 
            // rvmrepbtn
            // 
            this.rvmrepbtn.Depth = 0;
            this.rvmrepbtn.Location = new System.Drawing.Point(507, 172);
            this.rvmrepbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.rvmrepbtn.Name = "rvmrepbtn";
            this.rvmrepbtn.Primary = true;
            this.rvmrepbtn.Size = new System.Drawing.Size(110, 41);
            this.rvmrepbtn.TabIndex = 8;
            this.rvmrepbtn.Text = "Delete review";
            this.rvmrepbtn.UseVisualStyleBackColor = true;
            this.rvmrepbtn.Click += new System.EventHandler(this.rvmrepbtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(128, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Select User";
            // 
            // userlist
            // 
            this.userlist.FormattingEnabled = true;
            this.userlist.Location = new System.Drawing.Point(14, 26);
            this.userlist.Name = "userlist";
            this.userlist.Size = new System.Drawing.Size(320, 381);
            this.userlist.TabIndex = 13;
            this.userlist.SelectedIndexChanged += new System.EventHandler(this.userlist_SelectedIndexChanged);
            // 
            // reviews
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1022, 558);
            this.Controls.Add(this.back);
            this.Controls.Add(this.addevpnl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "reviews";
            this.Text = "reviews";
            this.Load += new System.EventHandler(this.reviews_Load);
            ((System.ComponentModel.ISupportInitialize)(this.back)).EndInit();
            this.addevpnl.ResumeLayout(false);
            this.addevpnl.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox back;
        private System.Windows.Forms.Panel addevpnl;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox reviewbox;
        private MaterialSkin.Controls.MaterialRaisedButton rvmrepbtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox userlist;
        private System.Windows.Forms.Label placelbl;
    }
}