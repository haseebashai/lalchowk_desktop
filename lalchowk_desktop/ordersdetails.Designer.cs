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
            ((System.ComponentModel.ISupportInitialize)(this.ordersdataview)).BeginInit();
            this.SuspendLayout();
            // 
            // ordersdataview
            // 
            this.ordersdataview.BackgroundColor = System.Drawing.Color.White;
            this.ordersdataview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ordersdataview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ordersdataview.Location = new System.Drawing.Point(12, 36);
            this.ordersdataview.Name = "ordersdataview";
            this.ordersdataview.RowHeadersVisible = false;
            this.ordersdataview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ordersdataview.Size = new System.Drawing.Size(1138, 567);
            this.ordersdataview.TabIndex = 1;
            // 
            // orderslbl
            // 
            this.orderslbl.AutoSize = true;
            this.orderslbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderslbl.Location = new System.Drawing.Point(12, 13);
            this.orderslbl.Name = "orderslbl";
            this.orderslbl.Size = new System.Drawing.Size(127, 20);
            this.orderslbl.TabIndex = 2;
            this.orderslbl.Text = "Orders Delivered";
            // 
            // upbtn
            // 
            this.upbtn.Location = new System.Drawing.Point(1007, 622);
            this.upbtn.Name = "upbtn";
            this.upbtn.Size = new System.Drawing.Size(118, 48);
            this.upbtn.TabIndex = 4;
            this.upbtn.Text = "Update";
            this.upbtn.UseVisualStyleBackColor = true;
            this.upbtn.Click += new System.EventHandler(this.upbtn_Click);
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

        private System.Windows.Forms.DataGridView ordersdataview;
        public System.Windows.Forms.Label orderslbl;
        private System.Windows.Forms.Button upbtn;
    }
}