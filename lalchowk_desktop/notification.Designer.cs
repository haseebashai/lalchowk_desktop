namespace Veiled_Kashmir_Admin_Panel
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
            this.back = new System.Windows.Forms.PictureBox();
            this.cancelbtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.sendbtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.addevpnl = new System.Windows.Forms.Panel();
            this.inclblem = new System.Windows.Forms.Label();
            this.inclblm = new System.Windows.Forms.Label();
            this.msgupdatebtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.msgbox = new System.Windows.Forms.ComboBox();
            this.msgcancelbtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.msgboxtxt = new System.Windows.Forms.TextBox();
            this.rvmbtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.msgtxt = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.back)).BeginInit();
            this.addevpnl.SuspendLayout();
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
            // cancelbtn
            // 
            this.cancelbtn.Depth = 0;
            this.cancelbtn.Location = new System.Drawing.Point(80, 301);
            this.cancelbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.cancelbtn.Name = "cancelbtn";
            this.cancelbtn.Primary = true;
            this.cancelbtn.Size = new System.Drawing.Size(143, 35);
            this.cancelbtn.TabIndex = 3;
            this.cancelbtn.Text = "cancel";
            this.cancelbtn.UseVisualStyleBackColor = true;
            this.cancelbtn.Click += new System.EventHandler(this.cancelbtn_Click);
            // 
            // sendbtn
            // 
            this.sendbtn.Depth = 0;
            this.sendbtn.Location = new System.Drawing.Point(229, 301);
            this.sendbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.sendbtn.Name = "sendbtn";
            this.sendbtn.Primary = true;
            this.sendbtn.Size = new System.Drawing.Size(143, 35);
            this.sendbtn.TabIndex = 2;
            this.sendbtn.Text = "send";
            this.sendbtn.UseVisualStyleBackColor = true;
            this.sendbtn.Click += new System.EventHandler(this.sendbtn_Click);
            // 
            // addevpnl
            // 
            this.addevpnl.Controls.Add(this.inclblem);
            this.addevpnl.Controls.Add(this.inclblm);
            this.addevpnl.Controls.Add(this.msgupdatebtn);
            this.addevpnl.Controls.Add(this.msgbox);
            this.addevpnl.Controls.Add(this.msgcancelbtn);
            this.addevpnl.Controls.Add(this.msgboxtxt);
            this.addevpnl.Controls.Add(this.rvmbtn);
            this.addevpnl.Controls.Add(this.label2);
            this.addevpnl.Controls.Add(this.label1);
            this.addevpnl.Controls.Add(this.msgtxt);
            this.addevpnl.Controls.Add(this.panel1);
            this.addevpnl.Controls.Add(this.cancelbtn);
            this.addevpnl.Controls.Add(this.sendbtn);
            this.addevpnl.Location = new System.Drawing.Point(12, 128);
            this.addevpnl.Name = "addevpnl";
            this.addevpnl.Size = new System.Drawing.Size(998, 420);
            this.addevpnl.TabIndex = 30;
            // 
            // inclblem
            // 
            this.inclblem.AutoSize = true;
            this.inclblem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inclblem.ForeColor = System.Drawing.Color.Red;
            this.inclblem.Location = new System.Drawing.Point(795, 339);
            this.inclblem.Name = "inclblem";
            this.inclblem.Size = new System.Drawing.Size(136, 20);
            this.inclblem.TabIndex = 71;
            this.inclblem.Text = "incomplete details";
            this.inclblem.Visible = false;
            // 
            // inclblm
            // 
            this.inclblm.AutoSize = true;
            this.inclblm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inclblm.ForeColor = System.Drawing.Color.Red;
            this.inclblm.Location = new System.Drawing.Point(236, 339);
            this.inclblm.Name = "inclblm";
            this.inclblm.Size = new System.Drawing.Size(136, 20);
            this.inclblm.TabIndex = 70;
            this.inclblm.Text = "incomplete details";
            this.inclblm.Visible = false;
            // 
            // msgupdatebtn
            // 
            this.msgupdatebtn.Depth = 0;
            this.msgupdatebtn.Location = new System.Drawing.Point(788, 301);
            this.msgupdatebtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.msgupdatebtn.Name = "msgupdatebtn";
            this.msgupdatebtn.Primary = true;
            this.msgupdatebtn.Size = new System.Drawing.Size(143, 35);
            this.msgupdatebtn.TabIndex = 6;
            this.msgupdatebtn.Text = "update ";
            this.msgupdatebtn.UseVisualStyleBackColor = true;
            this.msgupdatebtn.Click += new System.EventHandler(this.msgupdatebtn_Click);
            // 
            // msgbox
            // 
            this.msgbox.FormattingEnabled = true;
            this.msgbox.Location = new System.Drawing.Point(544, 31);
            this.msgbox.Name = "msgbox";
            this.msgbox.Size = new System.Drawing.Size(387, 21);
            this.msgbox.TabIndex = 4;
            this.msgbox.SelectedIndexChanged += new System.EventHandler(this.msgbox_SelectedIndexChanged);
            // 
            // msgcancelbtn
            // 
            this.msgcancelbtn.Depth = 0;
            this.msgcancelbtn.Location = new System.Drawing.Point(639, 301);
            this.msgcancelbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.msgcancelbtn.Name = "msgcancelbtn";
            this.msgcancelbtn.Primary = true;
            this.msgcancelbtn.Size = new System.Drawing.Size(143, 35);
            this.msgcancelbtn.TabIndex = 7;
            this.msgcancelbtn.Text = "cancel";
            this.msgcancelbtn.UseVisualStyleBackColor = true;
            this.msgcancelbtn.Click += new System.EventHandler(this.msgcancelbtn_Click);
            // 
            // msgboxtxt
            // 
            this.msgboxtxt.Location = new System.Drawing.Point(544, 70);
            this.msgboxtxt.Multiline = true;
            this.msgboxtxt.Name = "msgboxtxt";
            this.msgboxtxt.Size = new System.Drawing.Size(387, 187);
            this.msgboxtxt.TabIndex = 5;
            // 
            // rvmbtn
            // 
            this.rvmbtn.Depth = 0;
            this.rvmbtn.Location = new System.Drawing.Point(544, 301);
            this.rvmbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.rvmbtn.Name = "rvmbtn";
            this.rvmbtn.Primary = true;
            this.rvmbtn.Size = new System.Drawing.Size(65, 35);
            this.rvmbtn.TabIndex = 8;
            this.rvmbtn.Text = "remove";
            this.rvmbtn.UseVisualStyleBackColor = true;
            this.rvmbtn.Click += new System.EventHandler(this.rvmbtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(688, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Select Message";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(193, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Send Message";
            // 
            // msgtxt
            // 
            this.msgtxt.Location = new System.Drawing.Point(39, 70);
            this.msgtxt.Multiline = true;
            this.msgtxt.Name = "msgtxt";
            this.msgtxt.Size = new System.Drawing.Size(387, 187);
            this.msgtxt.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(476, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 397);
            this.panel1.TabIndex = 10;
            // 
            // notification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1022, 558);
            this.Controls.Add(this.back);
            this.Controls.Add(this.addevpnl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "notification";
            this.Text = "notification";
            this.Load += new System.EventHandler(this.notification_Load);
            ((System.ComponentModel.ISupportInitialize)(this.back)).EndInit();
            this.addevpnl.ResumeLayout(false);
            this.addevpnl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox back;
        private MaterialSkin.Controls.MaterialRaisedButton cancelbtn;
        private MaterialSkin.Controls.MaterialRaisedButton sendbtn;
        private System.Windows.Forms.Panel addevpnl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox msgtxt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox msgboxtxt;
        private MaterialSkin.Controls.MaterialRaisedButton rvmbtn;
        private MaterialSkin.Controls.MaterialRaisedButton msgcancelbtn;
        private System.Windows.Forms.ComboBox msgbox;
        private MaterialSkin.Controls.MaterialRaisedButton msgupdatebtn;
        private System.Windows.Forms.Label inclblm;
        private System.Windows.Forms.Label inclblem;
    }
}