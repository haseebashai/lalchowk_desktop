namespace Veiled_Kashmir_Admin_Panel
{
    partial class inventory
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
            this.inventorydatagridview = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.supidtxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pronametxt = new System.Windows.Forms.TextBox();
            this.proidtxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.brandtxt = new System.Windows.Forms.TextBox();
            this.productlbl = new System.Windows.Forms.Label();
            this.idlbl = new System.Windows.Forms.Label();
            this.desctxtbox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.updatebtn = new System.Windows.Forms.Button();
            this.upbtn = new System.Windows.Forms.Button();
            this.ipnl = new System.Windows.Forms.Panel();
            this.refresh = new System.Windows.Forms.PictureBox();
            this.cattxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.descpnl = new System.Windows.Forms.Panel();
            this.bgworker = new System.ComponentModel.BackgroundWorker();
            this.fetchlbl = new System.Windows.Forms.Label();
            this.pbar = new System.Windows.Forms.ProgressBar();
            this.updlbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.inventorydatagridview)).BeginInit();
            this.ipnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.refresh)).BeginInit();
            this.descpnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // inventorydatagridview
            // 
            this.inventorydatagridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.inventorydatagridview.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.inventorydatagridview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.inventorydatagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.inventorydatagridview.Location = new System.Drawing.Point(4, 32);
            this.inventorydatagridview.Name = "inventorydatagridview";
            this.inventorydatagridview.Size = new System.Drawing.Size(1148, 389);
            this.inventorydatagridview.TabIndex = 0;
            this.inventorydatagridview.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.inventorydatagridview_CellClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(251, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Product Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(552, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Supplier ID";
            // 
            // supidtxt
            // 
            this.supidtxt.Location = new System.Drawing.Point(617, 4);
            this.supidtxt.Name = "supidtxt";
            this.supidtxt.Size = new System.Drawing.Size(78, 20);
            this.supidtxt.TabIndex = 21;
            this.supidtxt.TextChanged += new System.EventHandler(this.supidtxt_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Filter by ProductID";
            // 
            // pronametxt
            // 
            this.pronametxt.Location = new System.Drawing.Point(332, 4);
            this.pronametxt.Name = "pronametxt";
            this.pronametxt.Size = new System.Drawing.Size(187, 20);
            this.pronametxt.TabIndex = 23;
            this.pronametxt.TextChanged += new System.EventHandler(this.pronametxt_TextChanged);
            // 
            // proidtxt
            // 
            this.proidtxt.Location = new System.Drawing.Point(126, 4);
            this.proidtxt.Name = "proidtxt";
            this.proidtxt.Size = new System.Drawing.Size(107, 20);
            this.proidtxt.TabIndex = 25;
            this.proidtxt.TextChanged += new System.EventHandler(this.catidtxt_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(716, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Brand";
            // 
            // brandtxt
            // 
            this.brandtxt.Location = new System.Drawing.Point(757, 4);
            this.brandtxt.Name = "brandtxt";
            this.brandtxt.Size = new System.Drawing.Size(109, 20);
            this.brandtxt.TabIndex = 27;
            this.brandtxt.TextChanged += new System.EventHandler(this.brandtxt_TextChanged);
            // 
            // productlbl
            // 
            this.productlbl.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productlbl.Location = new System.Drawing.Point(6, 29);
            this.productlbl.Name = "productlbl";
            this.productlbl.Size = new System.Drawing.Size(213, 59);
            this.productlbl.TabIndex = 32;
            // 
            // idlbl
            // 
            this.idlbl.AutoSize = true;
            this.idlbl.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idlbl.Location = new System.Drawing.Point(7, 9);
            this.idlbl.Name = "idlbl";
            this.idlbl.Size = new System.Drawing.Size(0, 20);
            this.idlbl.TabIndex = 31;
            // 
            // desctxtbox
            // 
            this.desctxtbox.AcceptsTab = true;
            this.desctxtbox.Location = new System.Drawing.Point(225, 1);
            this.desctxtbox.Multiline = true;
            this.desctxtbox.Name = "desctxtbox";
            this.desctxtbox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.desctxtbox.Size = new System.Drawing.Size(371, 260);
            this.desctxtbox.TabIndex = 36;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(136, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 20);
            this.label7.TabIndex = 37;
            this.label7.Text = "Description";
            // 
            // updatebtn
            // 
            this.updatebtn.Location = new System.Drawing.Point(599, 62);
            this.updatebtn.Name = "updatebtn";
            this.updatebtn.Size = new System.Drawing.Size(61, 122);
            this.updatebtn.TabIndex = 38;
            this.updatebtn.Text = "Update";
            this.updatebtn.UseVisualStyleBackColor = true;
            this.updatebtn.Click += new System.EventHandler(this.updatebtn_Click);
            // 
            // upbtn
            // 
            this.upbtn.Location = new System.Drawing.Point(1033, 429);
            this.upbtn.Name = "upbtn";
            this.upbtn.Size = new System.Drawing.Size(122, 36);
            this.upbtn.TabIndex = 40;
            this.upbtn.Text = "Update";
            this.upbtn.UseVisualStyleBackColor = true;
            this.upbtn.Click += new System.EventHandler(this.upbtn_Click);
            // 
            // ipnl
            // 
            this.ipnl.Controls.Add(this.refresh);
            this.ipnl.Controls.Add(this.cattxt);
            this.ipnl.Controls.Add(this.label1);
            this.ipnl.Controls.Add(this.inventorydatagridview);
            this.ipnl.Controls.Add(this.supidtxt);
            this.ipnl.Controls.Add(this.label2);
            this.ipnl.Controls.Add(this.pronametxt);
            this.ipnl.Controls.Add(this.label3);
            this.ipnl.Controls.Add(this.proidtxt);
            this.ipnl.Controls.Add(this.label4);
            this.ipnl.Controls.Add(this.brandtxt);
            this.ipnl.Controls.Add(this.label5);
            this.ipnl.Location = new System.Drawing.Point(3, 2);
            this.ipnl.Name = "ipnl";
            this.ipnl.Size = new System.Drawing.Size(1156, 424);
            this.ipnl.TabIndex = 41;
            this.ipnl.Visible = false;
            // 
            // refresh
            // 
            this.refresh.BackgroundImage = global::Veiled_Kashmir_Admin_Panel.Properties.Resources.refresh;
            this.refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.refresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.refresh.Location = new System.Drawing.Point(1132, 3);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(21, 21);
            this.refresh.TabIndex = 31;
            this.refresh.TabStop = false;
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // cattxt
            // 
            this.cattxt.Location = new System.Drawing.Point(952, 4);
            this.cattxt.Name = "cattxt";
            this.cattxt.Size = new System.Drawing.Size(109, 20);
            this.cattxt.TabIndex = 29;
            this.cattxt.TextChanged += new System.EventHandler(this.cattxt_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(886, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "CategoryID";
            // 
            // descpnl
            // 
            this.descpnl.Controls.Add(this.idlbl);
            this.descpnl.Controls.Add(this.productlbl);
            this.descpnl.Controls.Add(this.updatebtn);
            this.descpnl.Controls.Add(this.desctxtbox);
            this.descpnl.Controls.Add(this.label7);
            this.descpnl.Location = new System.Drawing.Point(3, 427);
            this.descpnl.Name = "descpnl";
            this.descpnl.Size = new System.Drawing.Size(671, 265);
            this.descpnl.TabIndex = 42;
            this.descpnl.Visible = false;
            // 
            // bgworker
            // 
            this.bgworker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgworker_DoWork);
            this.bgworker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgworker_RunWorkerCompleted);
            // 
            // fetchlbl
            // 
            this.fetchlbl.AutoSize = true;
            this.fetchlbl.BackColor = System.Drawing.Color.Transparent;
            this.fetchlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fetchlbl.ForeColor = System.Drawing.Color.Black;
            this.fetchlbl.Location = new System.Drawing.Point(889, 455);
            this.fetchlbl.Name = "fetchlbl";
            this.fetchlbl.Size = new System.Drawing.Size(76, 13);
            this.fetchlbl.TabIndex = 57;
            this.fetchlbl.Text = "Fetching Rows";
            this.fetchlbl.Visible = false;
            // 
            // pbar
            // 
            this.pbar.Location = new System.Drawing.Point(839, 447);
            this.pbar.MarqueeAnimationSpeed = 30;
            this.pbar.Name = "pbar";
            this.pbar.Size = new System.Drawing.Size(165, 5);
            this.pbar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbar.TabIndex = 56;
            this.pbar.Visible = false;
            // 
            // updlbl
            // 
            this.updlbl.AutoSize = true;
            this.updlbl.BackColor = System.Drawing.Color.Transparent;
            this.updlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updlbl.ForeColor = System.Drawing.Color.Black;
            this.updlbl.Location = new System.Drawing.Point(899, 431);
            this.updlbl.Name = "updlbl";
            this.updlbl.Size = new System.Drawing.Size(47, 13);
            this.updlbl.TabIndex = 58;
            this.updlbl.Text = "Updated";
            this.updlbl.Visible = false;
            // 
            // inventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1162, 722);
            this.Controls.Add(this.updlbl);
            this.Controls.Add(this.fetchlbl);
            this.Controls.Add(this.pbar);
            this.Controls.Add(this.descpnl);
            this.Controls.Add(this.ipnl);
            this.Controls.Add(this.upbtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "inventory";
            this.Text = "research";
            ((System.ComponentModel.ISupportInitialize)(this.inventorydatagridview)).EndInit();
            this.ipnl.ResumeLayout(false);
            this.ipnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.refresh)).EndInit();
            this.descpnl.ResumeLayout(false);
            this.descpnl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView inventorydatagridview;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox supidtxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox pronametxt;
        private System.Windows.Forms.TextBox proidtxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox brandtxt;
        private System.Windows.Forms.Label productlbl;
        private System.Windows.Forms.Label idlbl;
        private System.Windows.Forms.TextBox desctxtbox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button updatebtn;
        private System.Windows.Forms.Button upbtn;
        private System.Windows.Forms.Panel ipnl;
        private System.Windows.Forms.Panel descpnl;
        private System.ComponentModel.BackgroundWorker bgworker;
        private System.Windows.Forms.TextBox cattxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label fetchlbl;
        private System.Windows.Forms.ProgressBar pbar;
        private System.Windows.Forms.Label updlbl;
        private System.Windows.Forms.PictureBox refresh;
    }
}