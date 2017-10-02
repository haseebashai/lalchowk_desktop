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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.productsdataview = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.pic = new System.Windows.Forms.PictureBox();
            this.updbtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.nametxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.idtxt = new System.Windows.Forms.TextBox();
            this.delbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.productsdataview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // productsdataview
            // 
            this.productsdataview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.productsdataview.BackgroundColor = System.Drawing.Color.White;
            this.productsdataview.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.productsdataview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.productsdataview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productsdataview.GridColor = System.Drawing.SystemColors.Control;
            this.productsdataview.Location = new System.Drawing.Point(107, 66);
            this.productsdataview.Name = "productsdataview";
            this.productsdataview.Size = new System.Drawing.Size(755, 485);
            this.productsdataview.TabIndex = 61;
            this.productsdataview.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.productsdataview_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 24);
            this.label1.TabIndex = 62;
            this.label1.Text = "Products Table";
            // 
            // pic
            // 
            this.pic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pic.Location = new System.Drawing.Point(868, 66);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(243, 318);
            this.pic.TabIndex = 63;
            this.pic.TabStop = false;
            // 
            // updbtn
            // 
            this.updbtn.Location = new System.Drawing.Point(868, 390);
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
            this.label3.Location = new System.Drawing.Point(377, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 13);
            this.label3.TabIndex = 68;
            this.label3.Text = "Filter by Product Name";
            // 
            // nametxt
            // 
            this.nametxt.Location = new System.Drawing.Point(495, 40);
            this.nametxt.Name = "nametxt";
            this.nametxt.Size = new System.Drawing.Size(187, 20);
            this.nametxt.TabIndex = 67;
            this.nametxt.TextChanged += new System.EventHandler(this.nametxt_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(161, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 66;
            this.label2.Text = "Filter by ID";
            // 
            // idtxt
            // 
            this.idtxt.Location = new System.Drawing.Point(224, 40);
            this.idtxt.Name = "idtxt";
            this.idtxt.Size = new System.Drawing.Size(104, 20);
            this.idtxt.TabIndex = 65;
            this.idtxt.TextChanged += new System.EventHandler(this.idtxt_TextChanged);
            // 
            // delbtn
            // 
            this.delbtn.Location = new System.Drawing.Point(868, 528);
            this.delbtn.Name = "delbtn";
            this.delbtn.Size = new System.Drawing.Size(54, 23);
            this.delbtn.TabIndex = 92;
            this.delbtn.Text = "Delete";
            this.delbtn.UseVisualStyleBackColor = true;
            this.delbtn.Click += new System.EventHandler(this.delbtn_Click);
            // 
            // viewproducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1162, 722);
            this.ControlBox = false;
            this.Controls.Add(this.delbtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nametxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.idtxt);
            this.Controls.Add(this.updbtn);
            this.Controls.Add(this.pic);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.productsdataview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "viewproducts";
            this.Text = "viewproducts";
            ((System.ComponentModel.ISupportInitialize)(this.productsdataview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView productsdataview;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.Button updbtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nametxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox idtxt;
        private System.Windows.Forms.Button delbtn;
    }
}