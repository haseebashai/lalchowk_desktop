namespace Veiled_Kashmir_Admin_Panel
{
    partial class dialogcontainer
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
            this.dialogpnl = new System.Windows.Forms.Panel();
            this.closebtn = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lbl = new System.Windows.Forms.Label();
            this.minimize = new System.Windows.Forms.PictureBox();
            this.loadingimage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.closebtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingimage)).BeginInit();
            this.SuspendLayout();
            // 
            // dialogpnl
            // 
            this.dialogpnl.AutoScroll = true;
            this.dialogpnl.Location = new System.Drawing.Point(1, 33);
            this.dialogpnl.Name = "dialogpnl";
            this.dialogpnl.Size = new System.Drawing.Size(1185, 678);
            this.dialogpnl.TabIndex = 0;
            // 
            // closebtn
            // 
            this.closebtn.BackgroundImage = global::Veiled_Kashmir_Admin_Panel.Properties.Resources.turn_on;
            this.closebtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.closebtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closebtn.Location = new System.Drawing.Point(1142, 4);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(25, 25);
            this.closebtn.TabIndex = 56;
            this.closebtn.TabStop = false;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 714);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1189, 1);
            this.panel3.TabIndex = 60;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1189, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 714);
            this.panel2.TabIndex = 59;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Location = new System.Drawing.Point(0, -19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 761);
            this.panel1.TabIndex = 58;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1190, 1);
            this.panel5.TabIndex = 57;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbl.Location = new System.Drawing.Point(4, 6);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(0, 24);
            this.lbl.TabIndex = 68;
            // 
            // minimize
            // 
            this.minimize.BackgroundImage = global::Veiled_Kashmir_Admin_Panel.Properties.Resources.diminish;
            this.minimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.minimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.minimize.ImageLocation = "";
            this.minimize.Location = new System.Drawing.Point(1116, 7);
            this.minimize.Name = "minimize";
            this.minimize.Size = new System.Drawing.Size(20, 20);
            this.minimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.minimize.TabIndex = 69;
            this.minimize.TabStop = false;
            this.minimize.Click += new System.EventHandler(this.minimize_Click);
            // 
            // loadingimage
            // 
            this.loadingimage.Image = global::Veiled_Kashmir_Admin_Panel.Properties.Resources.loading;
            this.loadingimage.Location = new System.Drawing.Point(78, 3);
            this.loadingimage.Name = "loadingimage";
            this.loadingimage.Size = new System.Drawing.Size(40, 29);
            this.loadingimage.TabIndex = 70;
            this.loadingimage.TabStop = false;
            this.loadingimage.Visible = false;
            // 
            // dialogcontainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1190, 715);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.loadingimage);
            this.Controls.Add(this.minimize);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.closebtn);
            this.Controls.Add(this.dialogpnl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "dialogcontainer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lalchowk Admin Panel";
            ((System.ComponentModel.ISupportInitialize)(this.closebtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingimage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Panel dialogpnl;
        private System.Windows.Forms.PictureBox closebtn;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        public System.Windows.Forms.Label lbl;
        private System.Windows.Forms.PictureBox minimize;
        public System.Windows.Forms.PictureBox loadingimage;
    }
}