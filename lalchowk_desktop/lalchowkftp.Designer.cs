namespace Veiled_Kashmir_Admin_Panel
{
    partial class lalchowkftp
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
            this.ftpdataview = new System.Windows.Forms.DataGridView();
            this.ftpdelbtn = new System.Windows.Forms.Button();
            this.ftpdldbtn = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.dirtxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dirbtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.progresspc = new System.Windows.Forms.Label();
            this.ftpupbtn = new System.Windows.Forms.Button();
            this.uptxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.filetxt = new System.Windows.Forms.TextBox();
            this.fpnl = new System.Windows.Forms.Panel();
            this.fetchpnl = new System.Windows.Forms.Panel();
            this.fetchlbl = new System.Windows.Forms.Label();
            this.pbar = new System.Windows.Forms.ProgressBar();
            this.ftppic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ftpdataview)).BeginInit();
            this.fpnl.SuspendLayout();
            this.fetchpnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ftppic)).BeginInit();
            this.SuspendLayout();
            // 
            // ftpdataview
            // 
            this.ftpdataview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ftpdataview.BackgroundColor = System.Drawing.Color.White;
            this.ftpdataview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ftpdataview.Location = new System.Drawing.Point(3, 114);
            this.ftpdataview.Name = "ftpdataview";
            this.ftpdataview.Size = new System.Drawing.Size(613, 501);
            this.ftpdataview.TabIndex = 0;
            this.ftpdataview.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ftpdelbtn
            // 
            this.ftpdelbtn.BackColor = System.Drawing.Color.Black;
            this.ftpdelbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ftpdelbtn.ForeColor = System.Drawing.Color.White;
            this.ftpdelbtn.Location = new System.Drawing.Point(633, 527);
            this.ftpdelbtn.Name = "ftpdelbtn";
            this.ftpdelbtn.Size = new System.Drawing.Size(51, 23);
            this.ftpdelbtn.TabIndex = 1;
            this.ftpdelbtn.Text = "Delete";
            this.ftpdelbtn.UseVisualStyleBackColor = false;
            this.ftpdelbtn.Click += new System.EventHandler(this.ftpdelbtn_Click);
            // 
            // ftpdldbtn
            // 
            this.ftpdldbtn.Location = new System.Drawing.Point(808, 506);
            this.ftpdldbtn.Name = "ftpdldbtn";
            this.ftpdldbtn.Size = new System.Drawing.Size(80, 44);
            this.ftpdldbtn.TabIndex = 3;
            this.ftpdldbtn.Text = "Download";
            this.ftpdldbtn.UseVisualStyleBackColor = true;
            this.ftpdldbtn.Click += new System.EventHandler(this.ftpdldbtn_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(633, 590);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(255, 3);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 4;
            this.progressBar1.Visible = false;
            // 
            // dirtxt
            // 
            this.dirtxt.Location = new System.Drawing.Point(6, 40);
            this.dirtxt.Name = "dirtxt";
            this.dirtxt.Size = new System.Drawing.Size(191, 20);
            this.dirtxt.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(3, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Enter Directory ( httpdocs/lalchowk/... )";
            // 
            // dirbtn
            // 
            this.dirbtn.AutoSize = true;
            this.dirbtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.dirbtn.Depth = 0;
            this.dirbtn.Location = new System.Drawing.Point(216, 31);
            this.dirbtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.dirbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.dirbtn.Name = "dirbtn";
            this.dirbtn.Primary = false;
            this.dirbtn.Size = new System.Drawing.Size(130, 36);
            this.dirbtn.TabIndex = 29;
            this.dirbtn.Text = "Enter Directory";
            this.dirbtn.UseVisualStyleBackColor = true;
            this.dirbtn.Click += new System.EventHandler(this.dirbtn_Click);
            // 
            // progresspc
            // 
            this.progresspc.AutoSize = true;
            this.progresspc.BackColor = System.Drawing.Color.Transparent;
            this.progresspc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progresspc.ForeColor = System.Drawing.SystemColors.Highlight;
            this.progresspc.Location = new System.Drawing.Point(630, 601);
            this.progresspc.Name = "progresspc";
            this.progresspc.Size = new System.Drawing.Size(25, 13);
            this.progresspc.TabIndex = 30;
            this.progresspc.Text = "size";
            this.progresspc.Visible = false;
            // 
            // ftpupbtn
            // 
            this.ftpupbtn.Location = new System.Drawing.Point(813, 112);
            this.ftpupbtn.Name = "ftpupbtn";
            this.ftpupbtn.Size = new System.Drawing.Size(75, 23);
            this.ftpupbtn.TabIndex = 31;
            this.ftpupbtn.Text = "Upload";
            this.ftpupbtn.UseVisualStyleBackColor = true;
            this.ftpupbtn.Click += new System.EventHandler(this.ftpupbtn_Click);
            // 
            // uptxt
            // 
            this.uptxt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uptxt.Location = new System.Drawing.Point(633, 114);
            this.uptxt.Name = "uptxt";
            this.uptxt.ReadOnly = true;
            this.uptxt.Size = new System.Drawing.Size(174, 20);
            this.uptxt.TabIndex = 84;
            this.uptxt.Text = "Select File";
            this.uptxt.Click += new System.EventHandler(this.uptxt_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(630, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(264, 13);
            this.label2.TabIndex = 85;
            this.label2.Text = "DO NOT UPLOAD FILES WITH SPACES IN FILENAME";
            // 
            // filetxt
            // 
            this.filetxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filetxt.ForeColor = System.Drawing.SystemColors.Highlight;
            this.filetxt.Location = new System.Drawing.Point(633, 466);
            this.filetxt.Multiline = true;
            this.filetxt.Name = "filetxt";
            this.filetxt.ReadOnly = true;
            this.filetxt.Size = new System.Drawing.Size(255, 34);
            this.filetxt.TabIndex = 87;
            // 
            // fpnl
            // 
            this.fpnl.Controls.Add(this.ftppic);
            this.fpnl.Controls.Add(this.fetchpnl);
            this.fpnl.Controls.Add(this.label1);
            this.fpnl.Controls.Add(this.filetxt);
            this.fpnl.Controls.Add(this.ftpdataview);
            this.fpnl.Controls.Add(this.ftpdelbtn);
            this.fpnl.Controls.Add(this.label2);
            this.fpnl.Controls.Add(this.ftpdldbtn);
            this.fpnl.Controls.Add(this.uptxt);
            this.fpnl.Controls.Add(this.progressBar1);
            this.fpnl.Controls.Add(this.ftpupbtn);
            this.fpnl.Controls.Add(this.dirtxt);
            this.fpnl.Controls.Add(this.progresspc);
            this.fpnl.Controls.Add(this.dirbtn);
            this.fpnl.Enabled = false;
            this.fpnl.Location = new System.Drawing.Point(1, 1);
            this.fpnl.Name = "fpnl";
            this.fpnl.Size = new System.Drawing.Size(1191, 683);
            this.fpnl.TabIndex = 88;
            // 
            // fetchpnl
            // 
            this.fetchpnl.Controls.Add(this.fetchlbl);
            this.fetchpnl.Controls.Add(this.pbar);
            this.fetchpnl.Location = new System.Drawing.Point(163, 299);
            this.fetchpnl.Name = "fetchpnl";
            this.fetchpnl.Size = new System.Drawing.Size(281, 127);
            this.fetchpnl.TabIndex = 88;
            this.fetchpnl.Visible = false;
            // 
            // fetchlbl
            // 
            this.fetchlbl.AutoSize = true;
            this.fetchlbl.BackColor = System.Drawing.Color.Transparent;
            this.fetchlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fetchlbl.ForeColor = System.Drawing.Color.Black;
            this.fetchlbl.Location = new System.Drawing.Point(86, 60);
            this.fetchlbl.Name = "fetchlbl";
            this.fetchlbl.Size = new System.Drawing.Size(105, 15);
            this.fetchlbl.TabIndex = 57;
            this.fetchlbl.Text = "Fetching Directory";
            // 
            // pbar
            // 
            this.pbar.Location = new System.Drawing.Point(56, 54);
            this.pbar.MarqueeAnimationSpeed = 30;
            this.pbar.Name = "pbar";
            this.pbar.Size = new System.Drawing.Size(165, 3);
            this.pbar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbar.TabIndex = 56;
            // 
            // ftppic
            // 
            this.ftppic.Location = new System.Drawing.Point(668, 207);
            this.ftppic.Name = "ftppic";
            this.ftppic.Size = new System.Drawing.Size(182, 244);
            this.ftppic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ftppic.TabIndex = 89;
            this.ftppic.TabStop = false;
            // 
            // lalchowkftp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1166, 722);
            this.Controls.Add(this.fpnl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "lalchowkftp";
            this.Text = "lalchowkftp";
            ((System.ComponentModel.ISupportInitialize)(this.ftpdataview)).EndInit();
            this.fpnl.ResumeLayout(false);
            this.fpnl.PerformLayout();
            this.fetchpnl.ResumeLayout(false);
            this.fetchpnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ftppic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ftpdataview;
        private System.Windows.Forms.Button ftpdelbtn;
        private System.Windows.Forms.Button ftpdldbtn;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox dirtxt;
        private System.Windows.Forms.Label label1;
        private MaterialSkin.Controls.MaterialFlatButton dirbtn;
        private System.Windows.Forms.Label progresspc;
        private System.Windows.Forms.Button ftpupbtn;
        private System.Windows.Forms.TextBox uptxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox filetxt;
        private System.Windows.Forms.Panel fpnl;
        private System.Windows.Forms.Panel fetchpnl;
        private System.Windows.Forms.Label fetchlbl;
        private System.Windows.Forms.ProgressBar pbar;
        private System.Windows.Forms.PictureBox ftppic;
    }
}