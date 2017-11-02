namespace Veiled_Kashmir_Admin_Panel
{
    partial class sendsms
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
            this.sendsmsbtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.smstxt = new System.Windows.Forms.TextBox();
            this.numbertxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sentlbl = new System.Windows.Forms.Label();
            this.numlisttxt = new System.Windows.Forms.TextBox();
            this.getnumbersbtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sendertxt = new System.Windows.Forms.TextBox();
            this.arrow = new System.Windows.Forms.PictureBox();
            this.loopchk = new System.Windows.Forms.CheckBox();
            this.limittxt = new System.Windows.Forms.TextBox();
            this.dirbox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.arrow)).BeginInit();
            this.SuspendLayout();
            // 
            // sendsmsbtn
            // 
            this.sendsmsbtn.AutoSize = true;
            this.sendsmsbtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.sendsmsbtn.Depth = 0;
            this.sendsmsbtn.Location = new System.Drawing.Point(631, 431);
            this.sendsmsbtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.sendsmsbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.sendsmsbtn.Name = "sendsmsbtn";
            this.sendsmsbtn.Primary = false;
            this.sendsmsbtn.Size = new System.Drawing.Size(79, 36);
            this.sendsmsbtn.TabIndex = 4;
            this.sendsmsbtn.Text = "send sms";
            this.sendsmsbtn.UseVisualStyleBackColor = true;
            this.sendsmsbtn.Click += new System.EventHandler(this.sendsmsbtn_Click);
            // 
            // smstxt
            // 
            this.smstxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.smstxt.ForeColor = System.Drawing.SystemColors.Highlight;
            this.smstxt.Location = new System.Drawing.Point(348, 288);
            this.smstxt.Multiline = true;
            this.smstxt.Name = "smstxt";
            this.smstxt.Size = new System.Drawing.Size(362, 134);
            this.smstxt.TabIndex = 3;
            // 
            // numbertxt
            // 
            this.numbertxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numbertxt.ForeColor = System.Drawing.Color.Gray;
            this.numbertxt.Location = new System.Drawing.Point(348, 93);
            this.numbertxt.Multiline = true;
            this.numbertxt.Name = "numbertxt";
            this.numbertxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.numbertxt.Size = new System.Drawing.Size(362, 165);
            this.numbertxt.TabIndex = 2;
            this.numbertxt.Text = "Enter numbers seperated with comma";
            this.numbertxt.Enter += new System.EventHandler(this.numbertxt_Enter);
            this.numbertxt.Leave += new System.EventHandler(this.numbertxt_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(345, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Recievers";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(345, 270);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "Text to send";
            // 
            // sentlbl
            // 
            this.sentlbl.AutoSize = true;
            this.sentlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sentlbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.sentlbl.Location = new System.Drawing.Point(628, 473);
            this.sentlbl.Name = "sentlbl";
            this.sentlbl.Size = new System.Drawing.Size(103, 13);
            this.sentlbl.TabIndex = 40;
            this.sentlbl.Text = "MESSAGE SENT ✔";
            this.sentlbl.Visible = false;
            // 
            // numlisttxt
            // 
            this.numlisttxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numlisttxt.ForeColor = System.Drawing.SystemColors.Highlight;
            this.numlisttxt.Location = new System.Drawing.Point(75, 93);
            this.numlisttxt.Multiline = true;
            this.numlisttxt.Name = "numlisttxt";
            this.numlisttxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.numlisttxt.Size = new System.Drawing.Size(159, 329);
            this.numlisttxt.TabIndex = 41;
            this.numlisttxt.Text = "Generate numbers \r\nfrom database.";
            this.numlisttxt.TextChanged += new System.EventHandler(this.numlisttxt_TextChanged);
            // 
            // getnumbersbtn
            // 
            this.getnumbersbtn.AutoSize = true;
            this.getnumbersbtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.getnumbersbtn.Depth = 0;
            this.getnumbersbtn.Location = new System.Drawing.Point(129, 454);
            this.getnumbersbtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.getnumbersbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.getnumbersbtn.Name = "getnumbersbtn";
            this.getnumbersbtn.Primary = false;
            this.getnumbersbtn.Size = new System.Drawing.Size(105, 36);
            this.getnumbersbtn.TabIndex = 42;
            this.getnumbersbtn.Text = "Get numbers";
            this.getnumbersbtn.UseVisualStyleBackColor = true;
            this.getnumbersbtn.Click += new System.EventHandler(this.getnumbersbtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(72, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "Numbers";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(345, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 45;
            this.label4.Text = "Sender";
            // 
            // sendertxt
            // 
            this.sendertxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.sendertxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendertxt.ForeColor = System.Drawing.Color.Black;
            this.sendertxt.Location = new System.Drawing.Point(348, 36);
            this.sendertxt.Name = "sendertxt";
            this.sendertxt.Size = new System.Drawing.Size(140, 23);
            this.sendertxt.TabIndex = 1;
            this.sendertxt.Enter += new System.EventHandler(this.sendertxt_Enter);
            // 
            // arrow
            // 
            this.arrow.BackgroundImage = global::Veiled_Kashmir_Admin_Panel.Properties.Resources.arrow;
            this.arrow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.arrow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.arrow.Location = new System.Drawing.Point(254, 145);
            this.arrow.Name = "arrow";
            this.arrow.Size = new System.Drawing.Size(73, 66);
            this.arrow.TabIndex = 46;
            this.arrow.TabStop = false;
            this.arrow.Visible = false;
            this.arrow.Click += new System.EventHandler(this.arrow_Click);
            // 
            // loopchk
            // 
            this.loopchk.AutoSize = true;
            this.loopchk.Location = new System.Drawing.Point(520, 442);
            this.loopchk.Name = "loopchk";
            this.loopchk.Size = new System.Drawing.Size(94, 17);
            this.loopchk.TabIndex = 47;
            this.loopchk.Text = "Send in a loop";
            this.loopchk.UseVisualStyleBackColor = true;
            this.loopchk.CheckedChanged += new System.EventHandler(this.loopchk_CheckedChanged);
            // 
            // limittxt
            // 
            this.limittxt.BackColor = System.Drawing.Color.WhiteSmoke;
            this.limittxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.limittxt.ForeColor = System.Drawing.Color.Gray;
            this.limittxt.Location = new System.Drawing.Point(147, 428);
            this.limittxt.Name = "limittxt";
            this.limittxt.Size = new System.Drawing.Size(87, 20);
            this.limittxt.TabIndex = 48;
            this.limittxt.Text = "Enter LIMIT";
            this.limittxt.Enter += new System.EventHandler(this.limittxt_Enter);
            this.limittxt.Leave += new System.EventHandler(this.limittxt_Leave);
            // 
            // dirbox
            // 
            this.dirbox.FormattingEnabled = true;
            this.dirbox.Items.AddRange(new object[] {
            "ASC",
            "DESC"});
            this.dirbox.Location = new System.Drawing.Point(75, 427);
            this.dirbox.Name = "dirbox";
            this.dirbox.Size = new System.Drawing.Size(66, 21);
            this.dirbox.TabIndex = 49;
            // 
            // sendsms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(750, 600);
            this.Controls.Add(this.dirbox);
            this.Controls.Add(this.limittxt);
            this.Controls.Add(this.loopchk);
            this.Controls.Add(this.arrow);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.sendertxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.getnumbersbtn);
            this.Controls.Add(this.numlisttxt);
            this.Controls.Add(this.sentlbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numbertxt);
            this.Controls.Add(this.smstxt);
            this.Controls.Add(this.sendsmsbtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "sendsms";
            this.Text = "sendsms";
            ((System.ComponentModel.ISupportInitialize)(this.arrow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialFlatButton sendsmsbtn;
        private System.Windows.Forms.TextBox smstxt;
        private System.Windows.Forms.TextBox numbertxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label sentlbl;
        private System.Windows.Forms.TextBox numlisttxt;
        private MaterialSkin.Controls.MaterialFlatButton getnumbersbtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox sendertxt;
        private System.Windows.Forms.PictureBox arrow;
        private System.Windows.Forms.CheckBox loopchk;
        private System.Windows.Forms.TextBox limittxt;
        private System.Windows.Forms.ComboBox dirbox;
    }
}