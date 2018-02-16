namespace Veiled_Kashmir_Admin_Panel
{
    partial class books
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bpnl = new System.Windows.Forms.Panel();
            this.delbtn = new System.Windows.Forms.Button();
            this.dpnl = new System.Windows.Forms.Panel();
            this.temailbtn = new System.Windows.Forms.Button();
            this.pbtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.label4 = new System.Windows.Forms.Label();
            this.detailstxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.booknametxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.contxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nametxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.emailtxt = new System.Windows.Forms.TextBox();
            this.booksdataview = new System.Windows.Forms.DataGridView();
            this.smsbtn = new System.Windows.Forms.Button();
            this.bpnl.SuspendLayout();
            this.dpnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.booksdataview)).BeginInit();
            this.SuspendLayout();
            // 
            // bpnl
            // 
            this.bpnl.Controls.Add(this.delbtn);
            this.bpnl.Controls.Add(this.dpnl);
            this.bpnl.Controls.Add(this.booksdataview);
            this.bpnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bpnl.Location = new System.Drawing.Point(0, 0);
            this.bpnl.Name = "bpnl";
            this.bpnl.Size = new System.Drawing.Size(834, 584);
            this.bpnl.TabIndex = 23;
            this.bpnl.Visible = false;
            // 
            // delbtn
            // 
            this.delbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.delbtn.Location = new System.Drawing.Point(779, 326);
            this.delbtn.Name = "delbtn";
            this.delbtn.Size = new System.Drawing.Size(53, 23);
            this.delbtn.TabIndex = 37;
            this.delbtn.Text = "Delete";
            this.delbtn.UseVisualStyleBackColor = true;
            this.delbtn.Click += new System.EventHandler(this.delbtn_Click);
            // 
            // dpnl
            // 
            this.dpnl.Controls.Add(this.smsbtn);
            this.dpnl.Controls.Add(this.temailbtn);
            this.dpnl.Controls.Add(this.pbtn);
            this.dpnl.Controls.Add(this.label4);
            this.dpnl.Controls.Add(this.detailstxt);
            this.dpnl.Controls.Add(this.label5);
            this.dpnl.Controls.Add(this.booknametxt);
            this.dpnl.Controls.Add(this.label3);
            this.dpnl.Controls.Add(this.contxt);
            this.dpnl.Controls.Add(this.label2);
            this.dpnl.Controls.Add(this.nametxt);
            this.dpnl.Controls.Add(this.label1);
            this.dpnl.Controls.Add(this.emailtxt);
            this.dpnl.Location = new System.Drawing.Point(3, 350);
            this.dpnl.Name = "dpnl";
            this.dpnl.Size = new System.Drawing.Size(828, 222);
            this.dpnl.TabIndex = 22;
            this.dpnl.Visible = false;
            // 
            // temailbtn
            // 
            this.temailbtn.Location = new System.Drawing.Point(202, 3);
            this.temailbtn.Name = "temailbtn";
            this.temailbtn.Size = new System.Drawing.Size(75, 23);
            this.temailbtn.TabIndex = 36;
            this.temailbtn.Text = "Check Email";
            this.temailbtn.UseVisualStyleBackColor = true;
            this.temailbtn.Visible = false;
            this.temailbtn.Click += new System.EventHandler(this.temailbtn_Click);
            // 
            // pbtn
            // 
            this.pbtn.AutoSize = true;
            this.pbtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pbtn.Depth = 0;
            this.pbtn.Location = new System.Drawing.Point(667, 122);
            this.pbtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.pbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.pbtn.Name = "pbtn";
            this.pbtn.Primary = false;
            this.pbtn.Size = new System.Drawing.Size(89, 36);
            this.pbtn.TabIndex = 35;
            this.pbtn.Text = "Processed";
            this.pbtn.UseVisualStyleBackColor = true;
            this.pbtn.Click += new System.EventHandler(this.pbtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(343, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Details";
            // 
            // detailstxt
            // 
            this.detailstxt.Location = new System.Drawing.Point(343, 100);
            this.detailstxt.Multiline = true;
            this.detailstxt.Name = "detailstxt";
            this.detailstxt.Size = new System.Drawing.Size(253, 84);
            this.detailstxt.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(343, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Book Name";
            // 
            // booknametxt
            // 
            this.booknametxt.Location = new System.Drawing.Point(343, 32);
            this.booknametxt.Name = "booknametxt";
            this.booknametxt.Size = new System.Drawing.Size(253, 20);
            this.booknametxt.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Contact";
            // 
            // contxt
            // 
            this.contxt.Location = new System.Drawing.Point(24, 164);
            this.contxt.Name = "contxt";
            this.contxt.Size = new System.Drawing.Size(253, 20);
            this.contxt.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name";
            // 
            // nametxt
            // 
            this.nametxt.Location = new System.Drawing.Point(24, 96);
            this.nametxt.Name = "nametxt";
            this.nametxt.Size = new System.Drawing.Size(253, 20);
            this.nametxt.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Requested by Email";
            // 
            // emailtxt
            // 
            this.emailtxt.Location = new System.Drawing.Point(24, 32);
            this.emailtxt.Name = "emailtxt";
            this.emailtxt.Size = new System.Drawing.Size(253, 20);
            this.emailtxt.TabIndex = 0;
            // 
            // booksdataview
            // 
            this.booksdataview.AllowUserToAddRows = false;
            this.booksdataview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.booksdataview.BackgroundColor = System.Drawing.Color.White;
            this.booksdataview.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.booksdataview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.booksdataview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.booksdataview.GridColor = System.Drawing.SystemColors.Control;
            this.booksdataview.Location = new System.Drawing.Point(3, 3);
            this.booksdataview.Name = "booksdataview";
            this.booksdataview.Size = new System.Drawing.Size(828, 322);
            this.booksdataview.TabIndex = 21;
            this.booksdataview.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.booksdataview_CellClick);
            this.booksdataview.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.booksdataview_CellClick);
            // 
            // smsbtn
            // 
            this.smsbtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.smsbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.smsbtn.Location = new System.Drawing.Point(667, 55);
            this.smsbtn.Name = "smsbtn";
            this.smsbtn.Size = new System.Drawing.Size(89, 35);
            this.smsbtn.TabIndex = 37;
            this.smsbtn.Text = "Send SMS";
            this.smsbtn.UseVisualStyleBackColor = true;
            this.smsbtn.Click += new System.EventHandler(this.smsbtn_Click);
            // 
            // books
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(834, 584);
            this.Controls.Add(this.bpnl);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "books";
            this.Text = "books";
            this.bpnl.ResumeLayout(false);
            this.dpnl.ResumeLayout(false);
            this.dpnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.booksdataview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel bpnl;
        private System.Windows.Forms.DataGridView booksdataview;
        private System.Windows.Forms.Panel dpnl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox detailstxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox booknametxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox contxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nametxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox emailtxt;
        private MaterialSkin.Controls.MaterialFlatButton pbtn;
        private System.Windows.Forms.Button temailbtn;
        private System.Windows.Forms.Button delbtn;
        private System.Windows.Forms.Button smsbtn;
    }
}