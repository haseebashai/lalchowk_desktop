namespace Veiled_Kashmir_Admin_Panel
{
    partial class printaddresses
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(printaddresses));
            this.tpnl = new System.Windows.Forms.TableLayoutPanel();
            this.printbtn = new System.Windows.Forms.Button();
            this.printdoc = new System.Drawing.Printing.PrintDocument();
            this.SuspendLayout();
            // 
            // tpnl
            // 
            this.tpnl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tpnl.AutoSize = true;
            this.tpnl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tpnl.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tpnl.ColumnCount = 2;
            this.tpnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tpnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tpnl.Location = new System.Drawing.Point(13, 13);
            this.tpnl.Name = "tpnl";
            this.tpnl.RowCount = 4;
            this.tpnl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpnl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpnl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpnl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpnl.Size = new System.Drawing.Size(793, 5);
            this.tpnl.TabIndex = 0;
            // 
            // printbtn
            // 
            this.printbtn.Location = new System.Drawing.Point(669, 587);
            this.printbtn.Name = "printbtn";
            this.printbtn.Size = new System.Drawing.Size(120, 57);
            this.printbtn.TabIndex = 1;
            this.printbtn.Text = "&Print";
            this.printbtn.UseVisualStyleBackColor = true;
            this.printbtn.Click += new System.EventHandler(this.printbtn_Click);
            // 
            // printdoc
            // 
            this.printdoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printdoc_PrintPage);
            // 
            // printaddresses
            // 
            this.AcceptButton = this.printbtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(818, 667);
            this.Controls.Add(this.printbtn);
            this.Controls.Add(this.tpnl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "printaddresses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Print Addresses";
            this.Load += new System.EventHandler(this.printaddresses_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tpnl;
        private System.Windows.Forms.Button printbtn;
        private System.Drawing.Printing.PrintDocument printdoc;
    }
}