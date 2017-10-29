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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.picdialog = new System.Windows.Forms.OpenFileDialog();
            this.updbtn = new System.Windows.Forms.Button();
            this.addbtn = new System.Windows.Forms.Button();
            this.picturesdataview = new System.Windows.Forms.DataGridView();
            this.label30 = new System.Windows.Forms.Label();
            this.ptxt = new System.Windows.Forms.TextBox();
            this.pic = new System.Windows.Forms.PictureBox();
            this.gidtxt = new System.Windows.Forms.TextBox();
            this.delbtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.gridtxt = new System.Windows.Forms.TextBox();
            this.ppnl = new System.Windows.Forms.Panel();
            this.refresh = new System.Windows.Forms.PictureBox();
            this.uploadlbl = new System.Windows.Forms.Label();
            this.dp = new System.Windows.Forms.PictureBox();
            this.bgworker = new System.ComponentModel.BackgroundWorker();
            this.picworker = new System.ComponentModel.BackgroundWorker();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picturesdataview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.ppnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.refresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dp)).BeginInit();
            this.SuspendLayout();
            // 
            // picdialog
            // 
            this.picdialog.Filter = "All Files|*.*|JPG|*.jpg|PNG|*.png";
            this.picdialog.Multiselect = true;
            this.picdialog.Title = "Select Images";
            // 
            // updbtn
            // 
            this.updbtn.Location = new System.Drawing.Point(583, 283);
            this.updbtn.Name = "updbtn";
            this.updbtn.Size = new System.Drawing.Size(125, 97);
            this.updbtn.TabIndex = 55;
            this.updbtn.Text = "Update";
            this.updbtn.UseVisualStyleBackColor = true;
            this.updbtn.Click += new System.EventHandler(this.updbtn_Click);
            // 
            // addbtn
            // 
            this.addbtn.Location = new System.Drawing.Point(466, 588);
            this.addbtn.Name = "addbtn";
            this.addbtn.Size = new System.Drawing.Size(91, 41);
            this.addbtn.TabIndex = 59;
            this.addbtn.Text = "Add Picture";
            this.addbtn.UseVisualStyleBackColor = true;
            this.addbtn.Click += new System.EventHandler(this.addbtn_Click);
            // 
            // picturesdataview
            // 
            this.picturesdataview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.picturesdataview.BackgroundColor = System.Drawing.Color.White;
            this.picturesdataview.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.picturesdataview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.picturesdataview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.picturesdataview.GridColor = System.Drawing.SystemColors.Control;
            this.picturesdataview.Location = new System.Drawing.Point(3, 30);
            this.picturesdataview.Name = "picturesdataview";
            this.picturesdataview.Size = new System.Drawing.Size(574, 485);
            this.picturesdataview.TabIndex = 60;
            this.picturesdataview.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.picturesdataview_CellClick);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(460, 517);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(81, 17);
            this.label30.TabIndex = 87;
            this.label30.Text = "Add Picture";
            // 
            // ptxt
            // 
            this.ptxt.Location = new System.Drawing.Point(325, 628);
            this.ptxt.Name = "ptxt";
            this.ptxt.Size = new System.Drawing.Size(115, 20);
            this.ptxt.TabIndex = 86;
            // 
            // pic
            // 
            this.pic.BackColor = System.Drawing.Color.Transparent;
            this.pic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic.Image = global::Veiled_Kashmir_Admin_Panel.Properties.Resources.industrial_safety_1492046_640;
            this.pic.Location = new System.Drawing.Point(325, 521);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(115, 101);
            this.pic.TabIndex = 88;
            this.pic.TabStop = false;
            this.pic.Click += new System.EventHandler(this.pic_Click);
            // 
            // gidtxt
            // 
            this.gidtxt.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.gidtxt.Location = new System.Drawing.Point(463, 537);
            this.gidtxt.Name = "gidtxt";
            this.gidtxt.Size = new System.Drawing.Size(113, 20);
            this.gidtxt.TabIndex = 89;
            this.gidtxt.Text = "Enter Group ID";
            this.gidtxt.Enter += new System.EventHandler(this.gidtxt_Enter);
            this.gidtxt.Leave += new System.EventHandler(this.gidtxt_Leave);
            // 
            // delbtn
            // 
            this.delbtn.Location = new System.Drawing.Point(3, 521);
            this.delbtn.Name = "delbtn";
            this.delbtn.Size = new System.Drawing.Size(51, 23);
            this.delbtn.TabIndex = 91;
            this.delbtn.Text = "Delete";
            this.delbtn.UseVisualStyleBackColor = true;
            this.delbtn.Click += new System.EventHandler(this.delbtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 93;
            this.label4.Text = "Filter by GroupID";
            // 
            // gridtxt
            // 
            this.gridtxt.Location = new System.Drawing.Point(95, 5);
            this.gridtxt.Name = "gridtxt";
            this.gridtxt.Size = new System.Drawing.Size(107, 20);
            this.gridtxt.TabIndex = 92;
            this.gridtxt.TextChanged += new System.EventHandler(this.gridtxt_TextChanged);
            // 
            // ppnl
            // 
            this.ppnl.Controls.Add(this.refresh);
            this.ppnl.Controls.Add(this.uploadlbl);
            this.ppnl.Controls.Add(this.dp);
            this.ppnl.Controls.Add(this.label4);
            this.ppnl.Controls.Add(this.updbtn);
            this.ppnl.Controls.Add(this.gridtxt);
            this.ppnl.Controls.Add(this.addbtn);
            this.ppnl.Controls.Add(this.delbtn);
            this.ppnl.Controls.Add(this.picturesdataview);
            this.ppnl.Controls.Add(this.gidtxt);
            this.ppnl.Controls.Add(this.ptxt);
            this.ppnl.Controls.Add(this.pic);
            this.ppnl.Controls.Add(this.label30);
            this.ppnl.Location = new System.Drawing.Point(12, 0);
            this.ppnl.Name = "ppnl";
            this.ppnl.Size = new System.Drawing.Size(795, 678);
            this.ppnl.TabIndex = 94;
            this.ppnl.Visible = false;
            // 
            // refresh
            // 
            this.refresh.BackgroundImage = global::Veiled_Kashmir_Admin_Panel.Properties.Resources.refresh;
            this.refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.refresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.refresh.Location = new System.Drawing.Point(555, 3);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(21, 21);
            this.refresh.TabIndex = 96;
            this.refresh.TabStop = false;
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // uploadlbl
            // 
            this.uploadlbl.AutoSize = true;
            this.uploadlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uploadlbl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.uploadlbl.Location = new System.Drawing.Point(468, 632);
            this.uploadlbl.Name = "uploadlbl";
            this.uploadlbl.Size = new System.Drawing.Size(0, 15);
            this.uploadlbl.TabIndex = 95;
            this.uploadlbl.Visible = false;
            // 
            // dp
            // 
            this.dp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.dp.Location = new System.Drawing.Point(583, 30);
            this.dp.Name = "dp";
            this.dp.Size = new System.Drawing.Size(186, 217);
            this.dp.TabIndex = 94;
            this.dp.TabStop = false;
            // 
            // bgworker
            // 
            this.bgworker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgworker_DoWork);
            this.bgworker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgworker_RunWorkerCompleted);
            // 
            // picworker
            // 
            this.picworker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.picworker_DoWork);
            this.picworker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.picworker_RunWorkerCompleted);
            // 
            // timer
            // 
            this.timer.Interval = 500;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // addpictures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1162, 722);
            this.Controls.Add(this.ppnl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "addpictures";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "forgotpwd";
            ((System.ComponentModel.ISupportInitialize)(this.picturesdataview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ppnl.ResumeLayout(false);
            this.ppnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.refresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog picdialog;
        private System.Windows.Forms.Button updbtn;
        private System.Windows.Forms.Button addbtn;
        private System.Windows.Forms.DataGridView picturesdataview;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox ptxt;
        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.TextBox gidtxt;
        private System.Windows.Forms.Button delbtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox gridtxt;
        private System.Windows.Forms.Panel ppnl;
        private System.ComponentModel.BackgroundWorker bgworker;
        private System.Windows.Forms.PictureBox dp;
        private System.ComponentModel.BackgroundWorker picworker;
        private System.Windows.Forms.Label uploadlbl;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.PictureBox refresh;
    }
}