namespace Veiled_Kashmir_Admin_Panel
{
    partial class medorders
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(medorders));
            this.placeddataview = new System.Windows.Forms.DataGridView();
            this.loadlbl = new System.Windows.Forms.Label();
            this.presdp = new System.Windows.Forms.PictureBox();
            this.medcontrol = new System.Windows.Forms.TabControl();
            this.placedpg = new System.Windows.Forms.TabPage();
            this.deliveredpg = new System.Windows.Forms.TabPage();
            this.deldataview = new System.Windows.Forms.DataGridView();
            this.dellbl = new System.Windows.Forms.Label();
            this.allorderspg = new System.Windows.Forms.TabPage();
            this.alldataview = new System.Windows.Forms.DataGridView();
            this.alllbl = new System.Windows.Forms.Label();
            this.shippedpg = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.placeddataview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.presdp)).BeginInit();
            this.medcontrol.SuspendLayout();
            this.placedpg.SuspendLayout();
            this.deliveredpg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deldataview)).BeginInit();
            this.allorderspg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alldataview)).BeginInit();
            this.shippedpg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // placeddataview
            // 
            this.placeddataview.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.placeddataview.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.placeddataview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.placeddataview.BackgroundColor = System.Drawing.Color.White;
            this.placeddataview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.placeddataview.Location = new System.Drawing.Point(6, 6);
            this.placeddataview.Name = "placeddataview";
            this.placeddataview.RowHeadersVisible = false;
            this.placeddataview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.placeddataview.Size = new System.Drawing.Size(1089, 217);
            this.placeddataview.TabIndex = 32;
            this.placeddataview.Visible = false;
            this.placeddataview.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.placeddataview_CellContentClick);
            // 
            // loadlbl
            // 
            this.loadlbl.AutoSize = true;
            this.loadlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadlbl.Location = new System.Drawing.Point(12, 9);
            this.loadlbl.Name = "loadlbl";
            this.loadlbl.Size = new System.Drawing.Size(61, 15);
            this.loadlbl.TabIndex = 33;
            this.loadlbl.Text = "Loading...";
            // 
            // presdp
            // 
            this.presdp.Location = new System.Drawing.Point(314, 340);
            this.presdp.Name = "presdp";
            this.presdp.Size = new System.Drawing.Size(503, 344);
            this.presdp.TabIndex = 34;
            this.presdp.TabStop = false;
            this.presdp.Visible = false;
            // 
            // medcontrol
            // 
            this.medcontrol.Controls.Add(this.placedpg);
            this.medcontrol.Controls.Add(this.shippedpg);
            this.medcontrol.Controls.Add(this.deliveredpg);
            this.medcontrol.Controls.Add(this.allorderspg);
            this.medcontrol.Location = new System.Drawing.Point(12, 37);
            this.medcontrol.Name = "medcontrol";
            this.medcontrol.Padding = new System.Drawing.Point(80, 10);
            this.medcontrol.SelectedIndex = 0;
            this.medcontrol.Size = new System.Drawing.Size(1117, 269);
            this.medcontrol.TabIndex = 35;
            this.medcontrol.Visible = false;
            // 
            // placedpg
            // 
            this.placedpg.Controls.Add(this.placeddataview);
            this.placedpg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.placedpg.Location = new System.Drawing.Point(4, 36);
            this.placedpg.Name = "placedpg";
            this.placedpg.Padding = new System.Windows.Forms.Padding(3);
            this.placedpg.Size = new System.Drawing.Size(1109, 229);
            this.placedpg.TabIndex = 0;
            this.placedpg.Text = "Placed Orders";
            this.placedpg.UseVisualStyleBackColor = true;
            // 
            // deliveredpg
            // 
            this.deliveredpg.Controls.Add(this.deldataview);
            this.deliveredpg.Controls.Add(this.dellbl);
            this.deliveredpg.Location = new System.Drawing.Point(4, 36);
            this.deliveredpg.Name = "deliveredpg";
            this.deliveredpg.Padding = new System.Windows.Forms.Padding(3);
            this.deliveredpg.Size = new System.Drawing.Size(1109, 229);
            this.deliveredpg.TabIndex = 1;
            this.deliveredpg.Text = "Delivered Orders";
            this.deliveredpg.UseVisualStyleBackColor = true;
            // 
            // deldataview
            // 
            this.deldataview.AllowUserToAddRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            this.deldataview.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.deldataview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.deldataview.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.deldataview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.deldataview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.deldataview.Location = new System.Drawing.Point(6, 6);
            this.deldataview.Name = "deldataview";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.deldataview.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.deldataview.RowHeadersVisible = false;
            this.deldataview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.deldataview.Size = new System.Drawing.Size(1089, 217);
            this.deldataview.TabIndex = 33;
            this.deldataview.Visible = false;
            // 
            // dellbl
            // 
            this.dellbl.AutoSize = true;
            this.dellbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dellbl.Location = new System.Drawing.Point(524, 107);
            this.dellbl.Name = "dellbl";
            this.dellbl.Size = new System.Drawing.Size(61, 15);
            this.dellbl.TabIndex = 34;
            this.dellbl.Text = "Loading...";
            this.dellbl.Visible = false;
            // 
            // allorderspg
            // 
            this.allorderspg.Controls.Add(this.alldataview);
            this.allorderspg.Controls.Add(this.alllbl);
            this.allorderspg.Location = new System.Drawing.Point(4, 36);
            this.allorderspg.Name = "allorderspg";
            this.allorderspg.Size = new System.Drawing.Size(1109, 229);
            this.allorderspg.TabIndex = 2;
            this.allorderspg.Text = "All Orders";
            this.allorderspg.UseVisualStyleBackColor = true;
            // 
            // alldataview
            // 
            this.alldataview.AllowUserToAddRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            this.alldataview.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.alldataview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.alldataview.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.alldataview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.alldataview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.alldataview.Location = new System.Drawing.Point(6, 6);
            this.alldataview.Name = "alldataview";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.alldataview.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.alldataview.RowHeadersVisible = false;
            this.alldataview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.alldataview.Size = new System.Drawing.Size(1089, 217);
            this.alldataview.TabIndex = 34;
            this.alldataview.Visible = false;
            // 
            // alllbl
            // 
            this.alllbl.AutoSize = true;
            this.alllbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alllbl.Location = new System.Drawing.Point(524, 107);
            this.alllbl.Name = "alllbl";
            this.alllbl.Size = new System.Drawing.Size(61, 15);
            this.alllbl.TabIndex = 35;
            this.alllbl.Text = "Loading...";
            this.alllbl.Visible = false;
            // 
            // shippedpg
            // 
            this.shippedpg.Controls.Add(this.dataGridView1);
            this.shippedpg.Location = new System.Drawing.Point(4, 36);
            this.shippedpg.Name = "shippedpg";
            this.shippedpg.Size = new System.Drawing.Size(1109, 229);
            this.shippedpg.TabIndex = 3;
            this.shippedpg.Text = "Shipped Orders";
            this.shippedpg.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1089, 217);
            this.dataGridView1.TabIndex = 33;
            this.dataGridView1.Visible = false;
            // 
            // medorders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1162, 687);
            this.Controls.Add(this.medcontrol);
            this.Controls.Add(this.presdp);
            this.Controls.Add(this.loadlbl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "medorders";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lalchowk Health";
            ((System.ComponentModel.ISupportInitialize)(this.placeddataview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.presdp)).EndInit();
            this.medcontrol.ResumeLayout(false);
            this.placedpg.ResumeLayout(false);
            this.deliveredpg.ResumeLayout(false);
            this.deliveredpg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deldataview)).EndInit();
            this.allorderspg.ResumeLayout(false);
            this.allorderspg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alldataview)).EndInit();
            this.shippedpg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView placeddataview;
        private System.Windows.Forms.Label loadlbl;
        private System.Windows.Forms.PictureBox presdp;
        private System.Windows.Forms.TabControl medcontrol;
        private System.Windows.Forms.TabPage placedpg;
        private System.Windows.Forms.TabPage deliveredpg;
        public System.Windows.Forms.DataGridView deldataview;
        private System.Windows.Forms.TabPage allorderspg;
        public System.Windows.Forms.DataGridView alldataview;
        private System.Windows.Forms.Label dellbl;
        private System.Windows.Forms.Label alllbl;
        private System.Windows.Forms.TabPage shippedpg;
        public System.Windows.Forms.DataGridView dataGridView1;
    }
}