namespace Veiled_Kashmir_Admin_Panel
{
    partial class products
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
            this.chkbtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.newbtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tplbl = new System.Windows.Forms.Label();
            this.eleclbl = new System.Windows.Forms.Label();
            this.clothlbl = new System.Windows.Forms.Label();
            this.footlbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chkbtn
            // 
            this.chkbtn.AutoSize = true;
            this.chkbtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.chkbtn.Depth = 0;
            this.chkbtn.Location = new System.Drawing.Point(593, 182);
            this.chkbtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.chkbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.chkbtn.Name = "chkbtn";
            this.chkbtn.Primary = false;
            this.chkbtn.Size = new System.Drawing.Size(123, 36);
            this.chkbtn.TabIndex = 14;
            this.chkbtn.Text = "View Inventory";
            this.chkbtn.UseVisualStyleBackColor = true;
            this.chkbtn.Click += new System.EventHandler(this.chkbtn_Click);
            // 
            // newbtn
            // 
            this.newbtn.AutoSize = true;
            this.newbtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.newbtn.Depth = 0;
            this.newbtn.Location = new System.Drawing.Point(95, 182);
            this.newbtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.newbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.newbtn.Name = "newbtn";
            this.newbtn.Primary = false;
            this.newbtn.Size = new System.Drawing.Size(146, 36);
            this.newbtn.TabIndex = 15;
            this.newbtn.Text = "Add New products";
            this.newbtn.UseVisualStyleBackColor = true;
            this.newbtn.Click += new System.EventHandler(this.newbtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Location = new System.Drawing.Point(414, 172);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 100);
            this.panel1.TabIndex = 16;
            // 
            // tplbl
            // 
            this.tplbl.AutoSize = true;
            this.tplbl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.tplbl.Location = new System.Drawing.Point(92, 455);
            this.tplbl.Name = "tplbl";
            this.tplbl.Size = new System.Drawing.Size(104, 13);
            this.tplbl.TabIndex = 17;
            this.tplbl.Text = "total products added";
            // 
            // eleclbl
            // 
            this.eleclbl.AutoSize = true;
            this.eleclbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.eleclbl.Location = new System.Drawing.Point(92, 512);
            this.eleclbl.Name = "eleclbl";
            this.eleclbl.Size = new System.Drawing.Size(84, 13);
            this.eleclbl.TabIndex = 18;
            this.eleclbl.Text = "total electronics ";
            // 
            // clothlbl
            // 
            this.clothlbl.AutoSize = true;
            this.clothlbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.clothlbl.Location = new System.Drawing.Point(92, 534);
            this.clothlbl.Name = "clothlbl";
            this.clothlbl.Size = new System.Drawing.Size(67, 13);
            this.clothlbl.TabIndex = 19;
            this.clothlbl.Text = "total clothing";
            // 
            // footlbl
            // 
            this.footlbl.AutoSize = true;
            this.footlbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.footlbl.Location = new System.Drawing.Point(92, 555);
            this.footlbl.Name = "footlbl";
            this.footlbl.Size = new System.Drawing.Size(67, 13);
            this.footlbl.TabIndex = 20;
            this.footlbl.Text = "total clothing";
            // 
            // products
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1162, 722);
            this.Controls.Add(this.footlbl);
            this.Controls.Add(this.clothlbl);
            this.Controls.Add(this.eleclbl);
            this.Controls.Add(this.tplbl);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.newbtn);
            this.Controls.Add(this.chkbtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "products";
            this.Text = "admin";
            this.Load += new System.EventHandler(this.products_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialFlatButton chkbtn;
        private MaterialSkin.Controls.MaterialFlatButton newbtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label tplbl;
        private System.Windows.Forms.Label eleclbl;
        private System.Windows.Forms.Label clothlbl;
        private System.Windows.Forms.Label footlbl;
    }
}