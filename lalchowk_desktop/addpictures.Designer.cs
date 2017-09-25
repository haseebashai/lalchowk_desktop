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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.picdialog = new System.Windows.Forms.OpenFileDialog();
            this.updbtn = new System.Windows.Forms.Button();
            this.addbtn = new System.Windows.Forms.Button();
            this.picturesdataview = new System.Windows.Forms.DataGridView();
            this.label30 = new System.Windows.Forms.Label();
            this.ptxt = new System.Windows.Forms.TextBox();
            this.pic = new System.Windows.Forms.PictureBox();
            this.gidtxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picturesdataview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 24);
            this.label1.TabIndex = 51;
            this.label1.Text = "Picture Table";
            // 
            // picdialog
            // 
            this.picdialog.Filter = "All Files|*.*|JPG|*.jpg|PNG|*.png";
            this.picdialog.Multiselect = true;
            this.picdialog.Title = "Select Images";
            // 
            // updbtn
            // 
            this.updbtn.Location = new System.Drawing.Point(913, 252);
            this.updbtn.Name = "updbtn";
            this.updbtn.Size = new System.Drawing.Size(125, 97);
            this.updbtn.TabIndex = 55;
            this.updbtn.Text = "Update";
            this.updbtn.UseVisualStyleBackColor = true;
            this.updbtn.Click += new System.EventHandler(this.updbtn_Click);
            // 
            // addbtn
            // 
            this.addbtn.Location = new System.Drawing.Point(800, 602);
            this.addbtn.Name = "addbtn";
            this.addbtn.Size = new System.Drawing.Size(106, 68);
            this.addbtn.TabIndex = 59;
            this.addbtn.Text = "Add Picture";
            this.addbtn.UseVisualStyleBackColor = true;
            this.addbtn.Click += new System.EventHandler(this.addbtn_Click);
            // 
            // picturesdataview
            // 
            this.picturesdataview.BackgroundColor = System.Drawing.Color.White;
            this.picturesdataview.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.picturesdataview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.picturesdataview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.picturesdataview.GridColor = System.Drawing.SystemColors.Control;
            this.picturesdataview.Location = new System.Drawing.Point(250, 29);
            this.picturesdataview.Name = "picturesdataview";
            this.picturesdataview.Size = new System.Drawing.Size(657, 485);
            this.picturesdataview.TabIndex = 60;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(525, 653);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(88, 17);
            this.label30.TabIndex = 87;
            this.label30.Text = "Add Pictures";
            // 
            // ptxt
            // 
            this.ptxt.Location = new System.Drawing.Point(648, 650);
            this.ptxt.Name = "ptxt";
            this.ptxt.Size = new System.Drawing.Size(146, 20);
            this.ptxt.TabIndex = 86;
            // 
            // pic
            // 
            this.pic.BackColor = System.Drawing.Color.Transparent;
            this.pic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic.Image = global::Veiled_Kashmir_Admin_Panel.Properties.Resources.industrial_safety_1492046_640;
            this.pic.Location = new System.Drawing.Point(648, 520);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(146, 124);
            this.pic.TabIndex = 88;
            this.pic.TabStop = false;
            this.pic.Click += new System.EventHandler(this.pic_Click);
            // 
            // gidtxt
            // 
            this.gidtxt.Location = new System.Drawing.Point(800, 540);
            this.gidtxt.Name = "gidtxt";
            this.gidtxt.Size = new System.Drawing.Size(106, 20);
            this.gidtxt.TabIndex = 89;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(800, 520);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 90;
            this.label2.Text = "Group ID";
            // 
            // addpictures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1162, 722);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gidtxt);
            this.Controls.Add(this.pic);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.ptxt);
            this.Controls.Add(this.picturesdataview);
            this.Controls.Add(this.addbtn);
            this.Controls.Add(this.updbtn);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "addpictures";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "forgotpwd";
            ((System.ComponentModel.ISupportInitialize)(this.picturesdataview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog picdialog;
        private System.Windows.Forms.Button updbtn;
        private System.Windows.Forms.Button addbtn;
        private System.Windows.Forms.DataGridView picturesdataview;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox ptxt;
        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.TextBox gidtxt;
        private System.Windows.Forms.Label label2;
    }
}