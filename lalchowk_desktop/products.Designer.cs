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
            this.SuspendLayout();
            // 
            // chkbtn
            // 
            this.chkbtn.AutoSize = true;
            this.chkbtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.chkbtn.Depth = 0;
            this.chkbtn.Location = new System.Drawing.Point(332, 182);
            this.chkbtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.chkbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.chkbtn.Name = "chkbtn";
            this.chkbtn.Primary = false;
            this.chkbtn.Size = new System.Drawing.Size(134, 36);
            this.chkbtn.TabIndex = 14;
            this.chkbtn.Text = "Check Inventory";
            this.chkbtn.UseVisualStyleBackColor = true;
            this.chkbtn.Click += new System.EventHandler(this.chkbtn_Click);
            // 
            // newbtn
            // 
            this.newbtn.AutoSize = true;
            this.newbtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.newbtn.Depth = 0;
            this.newbtn.Location = new System.Drawing.Point(138, 182);
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
            // products
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1162, 722);
            this.Controls.Add(this.newbtn);
            this.Controls.Add(this.chkbtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "products";
            this.Text = "admin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialFlatButton chkbtn;
        private MaterialSkin.Controls.MaterialFlatButton newbtn;
    }
}