namespace Veiled_Kashmir_Admin_Panel
{
    partial class wishlist
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.emailbtn = new System.Windows.Forms.Button();
            this.smspnl = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.sendsmsbtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.charlbl = new System.Windows.Forms.Label();
            this.smstxt = new System.Windows.Forms.TextBox();
            this.numbertxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sentlbl = new System.Windows.Forms.Label();
            this.sendertxt = new System.Windows.Forms.TextBox();
            this.pnl = new System.Windows.Forms.Panel();
            this.refresh = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cartdataview = new System.Windows.Forms.DataGridView();
            this.emailtxt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nametxt = new System.Windows.Forms.TextBox();
            this.producttxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.contacttxt = new System.Windows.Forms.TextBox();
            this.smspnl.SuspendLayout();
            this.pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.refresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cartdataview)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Location = new System.Drawing.Point(360, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 316);
            this.panel1.TabIndex = 71;
            // 
            // emailbtn
            // 
            this.emailbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.emailbtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.emailbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.emailbtn.Location = new System.Drawing.Point(682, 153);
            this.emailbtn.Name = "emailbtn";
            this.emailbtn.Size = new System.Drawing.Size(108, 34);
            this.emailbtn.TabIndex = 99;
            this.emailbtn.Text = "Send Email";
            this.emailbtn.UseVisualStyleBackColor = true;
            this.emailbtn.Click += new System.EventHandler(this.emailbtn_Click);
            // 
            // smspnl
            // 
            this.smspnl.Controls.Add(this.panel1);
            this.smspnl.Controls.Add(this.label4);
            this.smspnl.Controls.Add(this.sendsmsbtn);
            this.smspnl.Controls.Add(this.charlbl);
            this.smspnl.Controls.Add(this.smstxt);
            this.smspnl.Controls.Add(this.numbertxt);
            this.smspnl.Controls.Add(this.label1);
            this.smspnl.Controls.Add(this.label2);
            this.smspnl.Controls.Add(this.sentlbl);
            this.smspnl.Controls.Add(this.sendertxt);
            this.smspnl.Location = new System.Drawing.Point(6, 307);
            this.smspnl.Name = "smspnl";
            this.smspnl.Size = new System.Drawing.Size(784, 335);
            this.smspnl.TabIndex = 90;
            this.smspnl.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 63;
            this.label4.Text = "Sender";
            // 
            // sendsmsbtn
            // 
            this.sendsmsbtn.AutoSize = true;
            this.sendsmsbtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.sendsmsbtn.Depth = 0;
            this.sendsmsbtn.Location = new System.Drawing.Point(222, 290);
            this.sendsmsbtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.sendsmsbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.sendsmsbtn.Name = "sendsmsbtn";
            this.sendsmsbtn.Primary = false;
            this.sendsmsbtn.Size = new System.Drawing.Size(79, 36);
            this.sendsmsbtn.TabIndex = 59;
            this.sendsmsbtn.Text = "send sms";
            this.sendsmsbtn.UseVisualStyleBackColor = true;
            this.sendsmsbtn.Click += new System.EventHandler(this.sendsmsbtn_Click);
            // 
            // charlbl
            // 
            this.charlbl.AutoSize = true;
            this.charlbl.Location = new System.Drawing.Point(271, 159);
            this.charlbl.Name = "charlbl";
            this.charlbl.Size = new System.Drawing.Size(30, 13);
            this.charlbl.TabIndex = 68;
            this.charlbl.Text = "(1/1)";
            this.charlbl.Visible = false;
            // 
            // smstxt
            // 
            this.smstxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.smstxt.ForeColor = System.Drawing.SystemColors.Highlight;
            this.smstxt.Location = new System.Drawing.Point(24, 177);
            this.smstxt.MaxLength = 160;
            this.smstxt.Multiline = true;
            this.smstxt.Name = "smstxt";
            this.smstxt.Size = new System.Drawing.Size(277, 109);
            this.smstxt.TabIndex = 58;
            // 
            // numbertxt
            // 
            this.numbertxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numbertxt.ForeColor = System.Drawing.Color.Gray;
            this.numbertxt.Location = new System.Drawing.Point(24, 74);
            this.numbertxt.Multiline = true;
            this.numbertxt.Name = "numbertxt";
            this.numbertxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.numbertxt.Size = new System.Drawing.Size(277, 70);
            this.numbertxt.TabIndex = 57;
            this.numbertxt.Text = "Enter numbers seperated with comma";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 60;
            this.label1.Text = "Recievers";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 61;
            this.label2.Text = "Text to send";
            // 
            // sentlbl
            // 
            this.sentlbl.AutoSize = true;
            this.sentlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sentlbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.sentlbl.Location = new System.Drawing.Point(90, 302);
            this.sentlbl.Name = "sentlbl";
            this.sentlbl.Size = new System.Drawing.Size(103, 13);
            this.sentlbl.TabIndex = 62;
            this.sentlbl.Text = "MESSAGE SENT ✔";
            this.sentlbl.Visible = false;
            // 
            // sendertxt
            // 
            this.sendertxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.sendertxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendertxt.ForeColor = System.Drawing.Color.Black;
            this.sendertxt.Location = new System.Drawing.Point(24, 26);
            this.sendertxt.Name = "sendertxt";
            this.sendertxt.Size = new System.Drawing.Size(140, 23);
            this.sendertxt.TabIndex = 56;
            this.sendertxt.Text = "LALCHK";
            // 
            // pnl
            // 
            this.pnl.Controls.Add(this.emailbtn);
            this.pnl.Controls.Add(this.refresh);
            this.pnl.Controls.Add(this.smspnl);
            this.pnl.Controls.Add(this.label5);
            this.pnl.Controls.Add(this.cartdataview);
            this.pnl.Controls.Add(this.emailtxt);
            this.pnl.Controls.Add(this.label7);
            this.pnl.Controls.Add(this.label3);
            this.pnl.Controls.Add(this.nametxt);
            this.pnl.Controls.Add(this.producttxt);
            this.pnl.Controls.Add(this.label6);
            this.pnl.Controls.Add(this.contacttxt);
            this.pnl.Location = new System.Drawing.Point(1, 3);
            this.pnl.Name = "pnl";
            this.pnl.Size = new System.Drawing.Size(798, 645);
            this.pnl.TabIndex = 91;
            this.pnl.Visible = false;
            // 
            // refresh
            // 
            this.refresh.BackgroundImage = global::Veiled_Kashmir_Admin_Panel.Properties.Resources.refresh;
            this.refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.refresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.refresh.Location = new System.Drawing.Point(769, 6);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(21, 21);
            this.refresh.TabIndex = 98;
            this.refresh.TabStop = false;
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 70;
            this.label5.Text = "Filter by Email:";
            // 
            // cartdataview
            // 
            this.cartdataview.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cartdataview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.cartdataview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cartdataview.Location = new System.Drawing.Point(4, 42);
            this.cartdataview.Name = "cartdataview";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cartdataview.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.cartdataview.Size = new System.Drawing.Size(672, 263);
            this.cartdataview.TabIndex = 27;
            this.cartdataview.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.cartdataview_CellContentClick);
            // 
            // emailtxt
            // 
            this.emailtxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.emailtxt.Location = new System.Drawing.Point(4, 16);
            this.emailtxt.Name = "emailtxt";
            this.emailtxt.Size = new System.Drawing.Size(159, 20);
            this.emailtxt.TabIndex = 69;
            this.emailtxt.TextChanged += new System.EventHandler(this.emailtxt_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(168, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 76;
            this.label7.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(473, -1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 71;
            this.label3.Text = "Product Name";
            // 
            // nametxt
            // 
            this.nametxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.nametxt.Location = new System.Drawing.Point(169, 16);
            this.nametxt.Name = "nametxt";
            this.nametxt.Size = new System.Drawing.Size(159, 20);
            this.nametxt.TabIndex = 75;
            this.nametxt.TextChanged += new System.EventHandler(this.nametxt_TextChanged);
            // 
            // producttxt
            // 
            this.producttxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.producttxt.Location = new System.Drawing.Point(476, 16);
            this.producttxt.Name = "producttxt";
            this.producttxt.Size = new System.Drawing.Size(157, 20);
            this.producttxt.TabIndex = 72;
            this.producttxt.TextChanged += new System.EventHandler(this.producttxt_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(333, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 74;
            this.label6.Text = "Contact";
            // 
            // contacttxt
            // 
            this.contacttxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.contacttxt.Location = new System.Drawing.Point(334, 16);
            this.contacttxt.Name = "contacttxt";
            this.contacttxt.Size = new System.Drawing.Size(136, 20);
            this.contacttxt.TabIndex = 73;
            this.contacttxt.TextChanged += new System.EventHandler(this.contacttxt_TextChanged);
            // 
            // wishlist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 650);
            this.Controls.Add(this.pnl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "wishlist";
            this.Text = "wishlist";
            this.smspnl.ResumeLayout(false);
            this.smspnl.PerformLayout();
            this.pnl.ResumeLayout(false);
            this.pnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.refresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cartdataview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button emailbtn;
        private System.Windows.Forms.PictureBox refresh;
        private System.Windows.Forms.Panel smspnl;
        private System.Windows.Forms.Label label4;
        private MaterialSkin.Controls.MaterialFlatButton sendsmsbtn;
        private System.Windows.Forms.Label charlbl;
        private System.Windows.Forms.TextBox smstxt;
        public System.Windows.Forms.TextBox numbertxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label sentlbl;
        private System.Windows.Forms.TextBox sendertxt;
        private System.Windows.Forms.Panel pnl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView cartdataview;
        private System.Windows.Forms.TextBox emailtxt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nametxt;
        private System.Windows.Forms.TextBox producttxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox contacttxt;
    }
}