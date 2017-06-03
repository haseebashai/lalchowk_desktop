namespace Veiled_Kashmir_Admin_Panel
{
    partial class container
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(container));
            this.titlebar = new System.Windows.Forms.Panel();
            this.minimize = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.close = new System.Windows.Forms.PictureBox();
            this.title = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.mainpnl = new System.Windows.Forms.Panel();
            this.titlebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.close)).BeginInit();
            this.SuspendLayout();
            // 
            // titlebar
            // 
            this.titlebar.BackColor = System.Drawing.Color.SteelBlue;
            this.titlebar.Controls.Add(this.minimize);
            this.titlebar.Controls.Add(this.pictureBox3);
            this.titlebar.Controls.Add(this.close);
            this.titlebar.Controls.Add(this.title);
            this.titlebar.Location = new System.Drawing.Point(0, 1);
            this.titlebar.Name = "titlebar";
            this.titlebar.Size = new System.Drawing.Size(1376, 38);
            this.titlebar.TabIndex = 3;
            this.titlebar.Paint += new System.Windows.Forms.PaintEventHandler(this.titlebar_Paint);
            // 
            // minimize
            // 
            this.minimize.BackgroundImage = global::Veiled_Kashmir_Admin_Panel.Properties.Resources.diminish;
            this.minimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.minimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.minimize.ImageLocation = "";
            this.minimize.Location = new System.Drawing.Point(1297, 9);
            this.minimize.Name = "minimize";
            this.minimize.Size = new System.Drawing.Size(20, 20);
            this.minimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.minimize.TabIndex = 5;
            this.minimize.TabStop = false;
            this.minimize.Click += new System.EventHandler(this.minimize_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::Veiled_Kashmir_Admin_Panel.Properties.Resources.logoW2;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(3, 1);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(38, 33);
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // close
            // 
            this.close.BackgroundImage = global::Veiled_Kashmir_Admin_Panel.Properties.Resources.turn_on;
            this.close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.close.ImageLocation = "";
            this.close.Location = new System.Drawing.Point(1326, 6);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(25, 25);
            this.close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.close.TabIndex = 4;
            this.close.TabStop = false;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Trajan Pro", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(38, 6);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(300, 24);
            this.title.TabIndex = 0;
            this.title.Text = "Lalchowk - Desktop Client";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1366, 1);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 767);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1366, 1);
            this.panel2.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1, 766);
            this.panel3.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(1365, 1);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1, 766);
            this.panel4.TabIndex = 5;
            // 
            // mainpnl
            // 
            this.mainpnl.BackColor = System.Drawing.Color.White;
            this.mainpnl.Location = new System.Drawing.Point(1, 41);
            this.mainpnl.Name = "mainpnl";
            this.mainpnl.Size = new System.Drawing.Size(1363, 725);
            this.mainpnl.TabIndex = 6;
            // 
            // container
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.ControlBox = false;
            this.Controls.Add(this.mainpnl);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.titlebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "container";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Panel";
            this.Load += new System.EventHandler(this.Homepage_Load);
            this.titlebar.ResumeLayout(false);
            this.titlebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.close)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel titlebar;
        private System.Windows.Forms.PictureBox minimize;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox close;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.Panel mainpnl;
    }
}

