namespace Veiled_Kashmir_Admin_Panel
{
    partial class viewproducts
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
            this.productsdataview = new System.Windows.Forms.DataGridView();
            this.pic = new System.Windows.Forms.PictureBox();
            this.updbtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.nametxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.idtxt = new System.Windows.Forms.TextBox();
            this.delbtn = new System.Windows.Forms.Button();
            this.ppnl = new System.Windows.Forms.Panel();
            this.refresh = new System.Windows.Forms.PictureBox();
            this.bgworker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.productsdataview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.ppnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.refresh)).BeginInit();
            this.SuspendLayout();
            // 
            // productsdataview
            // 
            this.productsdataview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.productsdataview.BackgroundColor = System.Drawing.Color.White;
            this.productsdataview.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.productsdataview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.productsdataview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productsdataview.GridColor = System.Drawing.SystemColors.Control;
            this.productsdataview.Location = new System.Drawing.Point(1, 35);
            this.productsdataview.Name = "productsdataview";
            this.productsdataview.Size = new System.Drawing.Size(755, 485);
            this.productsdataview.TabIndex = 61;
            this.productsdataview.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.productsdataview_CellClick);
            this.productsdataview.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.productsdataview_CellClick);
            // 
            // pic
            // 
            this.pic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pic.Location = new System.Drawing.Point(762, 35);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(233, 318);
            this.pic.TabIndex = 63;
            this.pic.TabStop = false;
            // 
            // updbtn
            // 
            this.updbtn.Location = new System.Drawing.Point(762, 359);
            this.updbtn.Name = "updbtn";
            this.updbtn.Size = new System.Drawing.Size(157, 118);
            this.updbtn.TabIndex = 64;
            this.updbtn.Text = "Update";
            this.updbtn.UseVisualStyleBackColor = true;
            this.updbtn.Click += new System.EventHandler(this.updbtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(271, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 13);
            this.label3.TabIndex = 68;
            this.label3.Text = "Filter by Product Name";
            // 
            // nametxt
            // 
            this.nametxt.Location = new System.Drawing.Point(389, 9);
            this.nametxt.Name = "nametxt";
            this.nametxt.Size = new System.Drawing.Size(187, 20);
            this.nametxt.TabIndex = 67;
            this.nametxt.TextChanged += new System.EventHandler(this.nametxt_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 66;
            this.label2.Text = "Filter by ID";
            // 
            // idtxt
            // 
            this.idtxt.Location = new System.Drawing.Point(118, 9);
            this.idtxt.Name = "idtxt";
            this.idtxt.Size = new System.Drawing.Size(104, 20);
            this.idtxt.TabIndex = 65;
            this.idtxt.TextChanged += new System.EventHandler(this.idtxt_TextChanged);
            // 
            // delbtn
            // 
            this.delbtn.Location = new System.Drawing.Point(702, 526);
            this.delbtn.Name = "delbtn";
            this.delbtn.Size = new System.Drawing.Size(54, 23);
            this.delbtn.TabIndex = 92;
            this.delbtn.Text = "Delete";
            this.delbtn.UseVisualStyleBackColor = true;
            this.delbtn.Click += new System.EventHandler(this.delbtn_Click);
            // 
            // ppnl
            // 
            this.ppnl.Controls.Add(this.refresh);
            this.ppnl.Controls.Add(this.label2);
            this.ppnl.Controls.Add(this.delbtn);
            this.ppnl.Controls.Add(this.productsdataview);
            this.ppnl.Controls.Add(this.label3);
            this.ppnl.Controls.Add(this.pic);
            this.ppnl.Controls.Add(this.nametxt);
            this.ppnl.Controls.Add(this.updbtn);
            this.ppnl.Controls.Add(this.idtxt);
            this.ppnl.Location = new System.Drawing.Point(3, 2);
            this.ppnl.Name = "ppnl";
            this.ppnl.Size = new System.Drawing.Size(1042, 610);
            this.ppnl.TabIndex = 93;
            this.ppnl.Visible = false;
            // 
            // refresh
            // 
            this.refresh.BackgroundImage = global::Veiled_Kashmir_Admin_Panel.Properties.Resources.refresh;
            this.refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.refresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.refresh.Location = new System.Drawing.Point(735, 8);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(21, 21);
            this.refresh.TabIndex = 93;
            this.refresh.TabStop = false;
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // bgworker
            // 
            this.bgworker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgworker_DoWork);
            this.bgworker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgworker_RunWorkerCompleted);
            // 
            // viewproducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1162, 616);
            this.ControlBox = false;
            this.Controls.Add(this.ppnl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "viewproducts";
            this.Text = "viewproducts";
            ((System.ComponentModel.ISupportInitialize)(this.productsdataview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ppnl.ResumeLayout(false);
            this.ppnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.refresh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView productsdataview;
        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.Button updbtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nametxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox idtxt;
        private System.Windows.Forms.Button delbtn;
        private System.Windows.Forms.Panel ppnl;
        private System.ComponentModel.BackgroundWorker bgworker;
        private System.Windows.Forms.PictureBox refresh;
    }
}