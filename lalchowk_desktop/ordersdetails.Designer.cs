namespace Veiled_Kashmir_Admin_Panel
{
    partial class ordersdetails
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
            this.ordersdataview = new System.Windows.Forms.DataGridView();
            this.orderslbl = new System.Windows.Forms.Label();
            this.upbtn = new System.Windows.Forms.Button();
            this.bgworker = new System.ComponentModel.BackgroundWorker();
            this.bgworker1 = new System.ComponentModel.BackgroundWorker();
            this.bgworker2 = new System.ComponentModel.BackgroundWorker();
            this.bgworker3 = new System.ComponentModel.BackgroundWorker();
            this.bgworker4 = new System.ComponentModel.BackgroundWorker();
            this.bgworker5 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.ordersdataview)).BeginInit();
            this.SuspendLayout();
            // 
            // ordersdataview
            // 
            this.ordersdataview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ordersdataview.BackgroundColor = System.Drawing.Color.White;
            this.ordersdataview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ordersdataview.Location = new System.Drawing.Point(12, 36);
            this.ordersdataview.Name = "ordersdataview";
            this.ordersdataview.RowHeadersVisible = false;
            this.ordersdataview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ordersdataview.Size = new System.Drawing.Size(1114, 567);
            this.ordersdataview.TabIndex = 1;
            this.ordersdataview.Visible = false;
            // 
            // orderslbl
            // 
            this.orderslbl.AutoSize = true;
            this.orderslbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderslbl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.orderslbl.Location = new System.Drawing.Point(12, 3);
            this.orderslbl.Name = "orderslbl";
            this.orderslbl.Size = new System.Drawing.Size(153, 24);
            this.orderslbl.TabIndex = 2;
            this.orderslbl.Text = "Orders Delivered";
            // 
            // upbtn
            // 
            this.upbtn.Location = new System.Drawing.Point(1008, 622);
            this.upbtn.Name = "upbtn";
            this.upbtn.Size = new System.Drawing.Size(118, 48);
            this.upbtn.TabIndex = 4;
            this.upbtn.Text = "Update";
            this.upbtn.UseVisualStyleBackColor = true;
            this.upbtn.Visible = false;
            this.upbtn.Click += new System.EventHandler(this.upbtn_Click);
            // 
            // bgworker
            // 
            this.bgworker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgworker_DoWork);
            this.bgworker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgworker_RunWorkerCompleted);
            // 
            // bgworker1
            // 
            this.bgworker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgworker1_DoWork);
            this.bgworker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgworker1_RunWorkerCompleted);
            // 
            // bgworker2
            // 
            this.bgworker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgworker2_DoWork);
            this.bgworker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgworker2_RunWorkerCompleted);
            // 
            // bgworker3
            // 
            this.bgworker3.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgworker3_DoWork);
            this.bgworker3.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgworker3_RunWorkerCompleted);
            // 
            // bgworker4
            // 
            this.bgworker4.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgworker4_DoWork);
            this.bgworker4.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgworker4_RunWorkerCompleted);
            // 
            // bgworker5
            // 
            this.bgworker5.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgworker5_DoWork);
            this.bgworker5.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgworker5_RunWorkerCompleted);
            // 
            // ordersdetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1162, 722);
            this.Controls.Add(this.upbtn);
            this.Controls.Add(this.orderslbl);
            this.Controls.Add(this.ordersdataview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ordersdetails";
            this.Text = "messages";
            ((System.ComponentModel.ISupportInitialize)(this.ordersdataview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label orderslbl;
        public System.ComponentModel.BackgroundWorker bgworker;
        public System.ComponentModel.BackgroundWorker bgworker1;
        public System.ComponentModel.BackgroundWorker bgworker2;
        public System.ComponentModel.BackgroundWorker bgworker3;
        public System.ComponentModel.BackgroundWorker bgworker4;
        public System.ComponentModel.BackgroundWorker bgworker5;
        public System.Windows.Forms.DataGridView ordersdataview;
        public System.Windows.Forms.Button upbtn;
    }
}