namespace Veiled_Kashmir_Admin_Panel
{
    partial class addpictures
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.closebtn = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.picdialog = new System.Windows.Forms.OpenFileDialog();
            this.picbox = new System.Windows.Forms.PictureBox();
            this.proid = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.closebtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Location = new System.Drawing.Point(0, -8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 461);
            this.panel1.TabIndex = 50;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 441);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(737, 1);
            this.panel3.TabIndex = 49;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(737, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 441);
            this.panel2.TabIndex = 48;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(738, 1);
            this.panel5.TabIndex = 46;
            // 
            // closebtn
            // 
            this.closebtn.BackgroundImage = global::Veiled_Kashmir_Admin_Panel.Properties.Resources.turn_on;
            this.closebtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.closebtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closebtn.Location = new System.Drawing.Point(701, 12);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(25, 25);
            this.closebtn.TabIndex = 47;
            this.closebtn.TabStop = false;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myriad Hebrew", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(295, 25);
            this.label1.TabIndex = 51;
            this.label1.Text = "New Product Added Sucessfully!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Myriad Hebrew", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(248, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 25);
            this.label2.TabIndex = 52;
            this.label2.Text = "Add Multiple Pictures.";
            // 
            // picdialog
            // 
            this.picdialog.FileName = "openFileDialog1";
            this.picdialog.Filter = "JPG|*.jpg|PNG|*.png";
            this.picdialog.Multiselect = true;
            this.picdialog.Title = "Select Images";
            // 
            // picbox
            // 
            this.picbox.Location = new System.Drawing.Point(223, 168);
            this.picbox.Name = "picbox";
            this.picbox.Size = new System.Drawing.Size(266, 147);
            this.picbox.TabIndex = 53;
            this.picbox.TabStop = false;
            // 
            // proid
            // 
            this.proid.AutoSize = true;
            this.proid.Font = new System.Drawing.Font("Myriad Hebrew", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.proid.ForeColor = System.Drawing.Color.Red;
            this.proid.Location = new System.Drawing.Point(484, 109);
            this.proid.Name = "proid";
            this.proid.Size = new System.Drawing.Size(206, 25);
            this.proid.TabIndex = 54;
            this.proid.Text = "Add Multiple Pictures.";
            // 
            // addpictures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(738, 442);
            this.Controls.Add(this.proid);
            this.Controls.Add(this.picbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.closebtn);
            this.Controls.Add(this.panel5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "addpictures";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "forgotpwd";
            this.Load += new System.EventHandler(this.addpictures_Load);
            ((System.ComponentModel.ISupportInitialize)(this.closebtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox closebtn;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog picdialog;
        private System.Windows.Forms.PictureBox picbox;
        private System.Windows.Forms.Label proid;
    }
}