namespace Veiled_Kashmir_Admin_Panel
{
    partial class forum
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
            this.label6 = new System.Windows.Forms.Label();
            this.threadbtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.addcancelbtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.repliesbtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.topicbtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.back = new System.Windows.Forms.PictureBox();
            this.threadbox = new System.Windows.Forms.ComboBox();
            this.rvmrepbtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.addpnl = new System.Windows.Forms.Panel();
            this.fagree = new System.Windows.Forms.CheckBox();
            this.inclblef = new System.Windows.Forms.Label();
            this.inclblf = new System.Windows.Forms.Label();
            this.rvmbtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.updatebtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.updatecancelbtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.updatethreadtxt = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.threadtxt = new System.Windows.Forms.TextBox();
            this.repliespnl = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.inclblr = new System.Windows.Forms.Label();
            this.replycancelbtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.addreply = new MaterialSkin.Controls.MaterialRaisedButton();
            this.label2 = new System.Windows.Forms.Label();
            this.replytxt = new System.Windows.Forms.TextBox();
            this.replybox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.threadlist = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.back)).BeginInit();
            this.addpnl.SuspendLayout();
            this.repliespnl.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(504, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Select Thread";
            // 
            // threadbtn
            // 
            this.threadbtn.Depth = 0;
            this.threadbtn.Location = new System.Drawing.Point(222, 294);
            this.threadbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.threadbtn.Name = "threadbtn";
            this.threadbtn.Primary = true;
            this.threadbtn.Size = new System.Drawing.Size(143, 35);
            this.threadbtn.TabIndex = 2;
            this.threadbtn.Text = "Add Thread";
            this.threadbtn.UseVisualStyleBackColor = true;
            this.threadbtn.Click += new System.EventHandler(this.threadbtn_Click);
            // 
            // addcancelbtn
            // 
            this.addcancelbtn.Depth = 0;
            this.addcancelbtn.Location = new System.Drawing.Point(73, 294);
            this.addcancelbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.addcancelbtn.Name = "addcancelbtn";
            this.addcancelbtn.Primary = true;
            this.addcancelbtn.Size = new System.Drawing.Size(143, 35);
            this.addcancelbtn.TabIndex = 3;
            this.addcancelbtn.Text = "cancel";
            this.addcancelbtn.UseVisualStyleBackColor = true;
            this.addcancelbtn.Click += new System.EventHandler(this.addcancelbtn_Click);
            // 
            // repliesbtn
            // 
            this.repliesbtn.AutoSize = true;
            this.repliesbtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.repliesbtn.Depth = 0;
            this.repliesbtn.Location = new System.Drawing.Point(554, 83);
            this.repliesbtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.repliesbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.repliesbtn.Name = "repliesbtn";
            this.repliesbtn.Primary = false;
            this.repliesbtn.Size = new System.Drawing.Size(64, 36);
            this.repliesbtn.TabIndex = 29;
            this.repliesbtn.Text = "replies";
            this.repliesbtn.UseVisualStyleBackColor = true;
            this.repliesbtn.Click += new System.EventHandler(this.repliesbtn_Click);
            // 
            // topicbtn
            // 
            this.topicbtn.AutoSize = true;
            this.topicbtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.topicbtn.Depth = 0;
            this.topicbtn.Location = new System.Drawing.Point(375, 83);
            this.topicbtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.topicbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.topicbtn.Name = "topicbtn";
            this.topicbtn.Primary = false;
            this.topicbtn.Size = new System.Drawing.Size(64, 36);
            this.topicbtn.TabIndex = 28;
            this.topicbtn.Text = "thread";
            this.topicbtn.UseVisualStyleBackColor = true;
            this.topicbtn.Click += new System.EventHandler(this.topicbtn_Click);
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
            // threadbox
            // 
            this.threadbox.FormattingEnabled = true;
            this.threadbox.Location = new System.Drawing.Point(591, 27);
            this.threadbox.Name = "threadbox";
            this.threadbox.Size = new System.Drawing.Size(365, 21);
            this.threadbox.TabIndex = 4;
            this.threadbox.SelectedIndexChanged += new System.EventHandler(this.threadbox_SelectedIndexChanged);
            // 
            // rvmrepbtn
            // 
            this.rvmrepbtn.Depth = 0;
            this.rvmrepbtn.Location = new System.Drawing.Point(507, 110);
            this.rvmrepbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.rvmrepbtn.Name = "rvmrepbtn";
            this.rvmrepbtn.Primary = true;
            this.rvmrepbtn.Size = new System.Drawing.Size(110, 35);
            this.rvmrepbtn.TabIndex = 8;
            this.rvmrepbtn.Text = "remove reply";
            this.rvmrepbtn.UseVisualStyleBackColor = true;
            this.rvmrepbtn.Click += new System.EventHandler(this.rvmrepbtn_Click);
            // 
            // addpnl
            // 
            this.addpnl.Controls.Add(this.fagree);
            this.addpnl.Controls.Add(this.inclblef);
            this.addpnl.Controls.Add(this.inclblf);
            this.addpnl.Controls.Add(this.rvmbtn);
            this.addpnl.Controls.Add(this.updatebtn);
            this.addpnl.Controls.Add(this.updatecancelbtn);
            this.addpnl.Controls.Add(this.updatethreadtxt);
            this.addpnl.Controls.Add(this.panel1);
            this.addpnl.Controls.Add(this.label4);
            this.addpnl.Controls.Add(this.threadtxt);
            this.addpnl.Controls.Add(this.threadbtn);
            this.addpnl.Controls.Add(this.addcancelbtn);
            this.addpnl.Controls.Add(this.threadbox);
            this.addpnl.Controls.Add(this.label6);
            this.addpnl.Location = new System.Drawing.Point(12, 128);
            this.addpnl.Name = "addpnl";
            this.addpnl.Size = new System.Drawing.Size(998, 420);
            this.addpnl.TabIndex = 31;
            // 
            // fagree
            // 
            this.fagree.AutoSize = true;
            this.fagree.Location = new System.Drawing.Point(774, 260);
            this.fagree.Name = "fagree";
            this.fagree.Size = new System.Drawing.Size(182, 17);
            this.fagree.TabIndex = 6;
            this.fagree.Text = "I have entered the correct details";
            this.fagree.UseVisualStyleBackColor = true;
            this.fagree.CheckedChanged += new System.EventHandler(this.fagree_CheckedChanged);
            // 
            // inclblef
            // 
            this.inclblef.AutoSize = true;
            this.inclblef.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inclblef.ForeColor = System.Drawing.Color.Red;
            this.inclblef.Location = new System.Drawing.Point(820, 335);
            this.inclblef.Name = "inclblef";
            this.inclblef.Size = new System.Drawing.Size(136, 20);
            this.inclblef.TabIndex = 71;
            this.inclblef.Text = "incomplete details";
            this.inclblef.Visible = false;
            // 
            // inclblf
            // 
            this.inclblf.AutoSize = true;
            this.inclblf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inclblf.ForeColor = System.Drawing.Color.Red;
            this.inclblf.Location = new System.Drawing.Point(229, 335);
            this.inclblf.Name = "inclblf";
            this.inclblf.Size = new System.Drawing.Size(136, 20);
            this.inclblf.TabIndex = 70;
            this.inclblf.Text = "incomplete details";
            this.inclblf.Visible = false;
            // 
            // rvmbtn
            // 
            this.rvmbtn.Depth = 0;
            this.rvmbtn.Location = new System.Drawing.Point(530, 294);
            this.rvmbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.rvmbtn.Name = "rvmbtn";
            this.rvmbtn.Primary = true;
            this.rvmbtn.Size = new System.Drawing.Size(76, 35);
            this.rvmbtn.TabIndex = 9;
            this.rvmbtn.Text = "remove";
            this.rvmbtn.UseVisualStyleBackColor = true;
            this.rvmbtn.Click += new System.EventHandler(this.rvmbtn_Click);
            // 
            // updatebtn
            // 
            this.updatebtn.Depth = 0;
            this.updatebtn.Location = new System.Drawing.Point(813, 294);
            this.updatebtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.updatebtn.Name = "updatebtn";
            this.updatebtn.Primary = true;
            this.updatebtn.Size = new System.Drawing.Size(143, 35);
            this.updatebtn.TabIndex = 7;
            this.updatebtn.Text = "update Thread";
            this.updatebtn.UseVisualStyleBackColor = true;
            this.updatebtn.Click += new System.EventHandler(this.updatebtn_Click);
            // 
            // updatecancelbtn
            // 
            this.updatecancelbtn.Depth = 0;
            this.updatecancelbtn.Location = new System.Drawing.Point(664, 294);
            this.updatecancelbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.updatecancelbtn.Name = "updatecancelbtn";
            this.updatecancelbtn.Primary = true;
            this.updatecancelbtn.Size = new System.Drawing.Size(143, 35);
            this.updatecancelbtn.TabIndex = 8;
            this.updatecancelbtn.Text = "cancel";
            this.updatecancelbtn.UseVisualStyleBackColor = true;
            this.updatecancelbtn.Click += new System.EventHandler(this.updatecancelbtn_Click);
            // 
            // updatethreadtxt
            // 
            this.updatethreadtxt.Location = new System.Drawing.Point(530, 80);
            this.updatethreadtxt.Multiline = true;
            this.updatethreadtxt.Name = "updatethreadtxt";
            this.updatethreadtxt.Size = new System.Drawing.Size(426, 165);
            this.updatethreadtxt.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(464, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 389);
            this.panel1.TabIndex = 60;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(185, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 59;
            this.label4.Text = "Thread topic";
            // 
            // threadtxt
            // 
            this.threadtxt.Location = new System.Drawing.Point(41, 80);
            this.threadtxt.Multiline = true;
            this.threadtxt.Name = "threadtxt";
            this.threadtxt.Size = new System.Drawing.Size(354, 165);
            this.threadtxt.TabIndex = 1;
            this.threadtxt.Leave += new System.EventHandler(this.threadtxt_Leave);
            // 
            // repliespnl
            // 
            this.repliespnl.Controls.Add(this.panel2);
            this.repliespnl.Controls.Add(this.label1);
            this.repliespnl.Controls.Add(this.threadlist);
            this.repliespnl.Location = new System.Drawing.Point(12, 128);
            this.repliespnl.Name = "repliespnl";
            this.repliespnl.Size = new System.Drawing.Size(998, 420);
            this.repliespnl.TabIndex = 30;
            this.repliespnl.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.inclblr);
            this.panel2.Controls.Add(this.replycancelbtn);
            this.panel2.Controls.Add(this.addreply);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.replytxt);
            this.panel2.Controls.Add(this.replybox);
            this.panel2.Controls.Add(this.rvmrepbtn);
            this.panel2.Location = new System.Drawing.Point(363, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(620, 387);
            this.panel2.TabIndex = 12;
            // 
            // inclblr
            // 
            this.inclblr.AutoSize = true;
            this.inclblr.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inclblr.ForeColor = System.Drawing.Color.Red;
            this.inclblr.Location = new System.Drawing.Point(507, 270);
            this.inclblr.Name = "inclblr";
            this.inclblr.Size = new System.Drawing.Size(105, 20);
            this.inclblr.TabIndex = 71;
            this.inclblr.Text = "Add reply first";
            this.inclblr.Visible = false;
            // 
            // replycancelbtn
            // 
            this.replycancelbtn.Depth = 0;
            this.replycancelbtn.Location = new System.Drawing.Point(507, 340);
            this.replycancelbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.replycancelbtn.Name = "replycancelbtn";
            this.replycancelbtn.Primary = true;
            this.replycancelbtn.Size = new System.Drawing.Size(110, 35);
            this.replycancelbtn.TabIndex = 15;
            this.replycancelbtn.Text = "cancel";
            this.replycancelbtn.UseVisualStyleBackColor = true;
            this.replycancelbtn.Click += new System.EventHandler(this.replycancelbtn_Click);
            // 
            // addreply
            // 
            this.addreply.Depth = 0;
            this.addreply.Location = new System.Drawing.Point(507, 299);
            this.addreply.MouseState = MaterialSkin.MouseState.HOVER;
            this.addreply.Name = "addreply";
            this.addreply.Primary = true;
            this.addreply.Size = new System.Drawing.Size(110, 35);
            this.addreply.TabIndex = 14;
            this.addreply.Text = "add reply";
            this.addreply.UseVisualStyleBackColor = true;
            this.addreply.Click += new System.EventHandler(this.addreply_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(206, 264);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Add your Reply";
            // 
            // replytxt
            // 
            this.replytxt.Location = new System.Drawing.Point(3, 292);
            this.replytxt.Multiline = true;
            this.replytxt.Name = "replytxt";
            this.replytxt.Size = new System.Drawing.Size(498, 88);
            this.replytxt.TabIndex = 12;
            this.replytxt.Leave += new System.EventHandler(this.replytxt_Leave);
            // 
            // replybox
            // 
            this.replybox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.replybox.FormattingEnabled = true;
            this.replybox.ItemHeight = 16;
            this.replybox.Location = new System.Drawing.Point(3, 3);
            this.replybox.Name = "replybox";
            this.replybox.Size = new System.Drawing.Size(498, 244);
            this.replybox.TabIndex = 11;
            this.replybox.SelectedIndexChanged += new System.EventHandler(this.replybox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(120, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Select Thread";
            // 
            // threadlist
            // 
            this.threadlist.FormattingEnabled = true;
            this.threadlist.Location = new System.Drawing.Point(13, 29);
            this.threadlist.Name = "threadlist";
            this.threadlist.Size = new System.Drawing.Size(320, 381);
            this.threadlist.TabIndex = 10;
            this.threadlist.SelectedIndexChanged += new System.EventHandler(this.threadlist_SelectedIndexChanged);
            // 
            // forum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1022, 558);
            this.Controls.Add(this.repliesbtn);
            this.Controls.Add(this.topicbtn);
            this.Controls.Add(this.back);
            this.Controls.Add(this.repliespnl);
            this.Controls.Add(this.addpnl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "forum";
            this.Text = "forum";
            this.Load += new System.EventHandler(this.forum_Load);
            ((System.ComponentModel.ISupportInitialize)(this.back)).EndInit();
            this.addpnl.ResumeLayout(false);
            this.addpnl.PerformLayout();
            this.repliespnl.ResumeLayout(false);
            this.repliespnl.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private MaterialSkin.Controls.MaterialRaisedButton threadbtn;
        private MaterialSkin.Controls.MaterialRaisedButton addcancelbtn;
        private MaterialSkin.Controls.MaterialFlatButton repliesbtn;
        private MaterialSkin.Controls.MaterialFlatButton topicbtn;
        private System.Windows.Forms.PictureBox back;
        private System.Windows.Forms.ComboBox threadbox;
        private MaterialSkin.Controls.MaterialRaisedButton rvmrepbtn;
        private System.Windows.Forms.Panel addpnl;
        private System.Windows.Forms.Panel repliespnl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox threadtxt;
        private MaterialSkin.Controls.MaterialRaisedButton rvmbtn;
        private MaterialSkin.Controls.MaterialRaisedButton updatebtn;
        private MaterialSkin.Controls.MaterialRaisedButton updatecancelbtn;
        private System.Windows.Forms.TextBox updatethreadtxt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox threadlist;
        private System.Windows.Forms.ListBox replybox;
        private MaterialSkin.Controls.MaterialRaisedButton replycancelbtn;
        private MaterialSkin.Controls.MaterialRaisedButton addreply;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox replytxt;
        private System.Windows.Forms.Label inclblf;
        private System.Windows.Forms.Label inclblef;
        private System.Windows.Forms.CheckBox fagree;
        private System.Windows.Forms.Label inclblr;
    }
}