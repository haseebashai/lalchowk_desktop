namespace Modest_Attires
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
            this.label1 = new System.Windows.Forms.Label();
            this.xtxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ytxt = new System.Windows.Forms.TextBox();
            this.setbtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.ftxt = new System.Windows.Forms.TextBox();
            this.pytxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pxtxt = new System.Windows.Forms.TextBox();
            this.psetbtn = new System.Windows.Forms.Button();
            this.bbox = new System.Windows.Forms.CheckBox();
            this.addbtn = new System.Windows.Forms.Button();
            this.frbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tpnl
            // 
            this.tpnl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tpnl.AutoSize = true;
            this.tpnl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tpnl.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tpnl.ColumnCount = 2;
            this.tpnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tpnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tpnl.ForeColor = System.Drawing.Color.Transparent;
            this.tpnl.Location = new System.Drawing.Point(13, 76);
            this.tpnl.Name = "tpnl";
            this.tpnl.RowCount = 4;
            this.tpnl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpnl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpnl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpnl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpnl.Size = new System.Drawing.Size(792, 0);
            this.tpnl.TabIndex = 0;
            // 
            // printbtn
            // 
            this.printbtn.Location = new System.Drawing.Point(250, 34);
            this.printbtn.Name = "printbtn";
            this.printbtn.Size = new System.Drawing.Size(118, 36);
            this.printbtn.TabIndex = 1;
            this.printbtn.Text = "&Print";
            this.printbtn.UseVisualStyleBackColor = true;
            this.printbtn.Click += new System.EventHandler(this.printbtn_Click);
            // 
            // printdoc
            // 
            this.printdoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printdoc_PrintPage);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(10, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = ">> Please edit the addresses accordingly here.";
            // 
            // xtxt
            // 
            this.xtxt.Location = new System.Drawing.Point(511, 12);
            this.xtxt.Name = "xtxt";
            this.xtxt.Size = new System.Drawing.Size(39, 21);
            this.xtxt.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(399, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Textbox Values:  X";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(561, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Y";
            // 
            // ytxt
            // 
            this.ytxt.Location = new System.Drawing.Point(578, 12);
            this.ytxt.Name = "ytxt";
            this.ytxt.Size = new System.Drawing.Size(39, 21);
            this.ytxt.TabIndex = 2;
            // 
            // setbtn
            // 
            this.setbtn.Location = new System.Drawing.Point(728, 12);
            this.setbtn.Name = "setbtn";
            this.setbtn.Size = new System.Drawing.Size(75, 23);
            this.setbtn.TabIndex = 4;
            this.setbtn.Text = "Set";
            this.setbtn.UseVisualStyleBackColor = true;
            this.setbtn.Click += new System.EventHandler(this.setbtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(633, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Font:";
            // 
            // ftxt
            // 
            this.ftxt.Location = new System.Drawing.Point(669, 12);
            this.ftxt.Name = "ftxt";
            this.ftxt.Size = new System.Drawing.Size(39, 21);
            this.ftxt.TabIndex = 3;
            // 
            // pytxt
            // 
            this.pytxt.Location = new System.Drawing.Point(578, 42);
            this.pytxt.Name = "pytxt";
            this.pytxt.Size = new System.Drawing.Size(39, 21);
            this.pytxt.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(561, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "Y";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(385, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Print Page Values:  X";
            // 
            // pxtxt
            // 
            this.pxtxt.Location = new System.Drawing.Point(511, 42);
            this.pxtxt.Name = "pxtxt";
            this.pxtxt.Size = new System.Drawing.Size(39, 21);
            this.pxtxt.TabIndex = 5;
            // 
            // psetbtn
            // 
            this.psetbtn.Location = new System.Drawing.Point(728, 41);
            this.psetbtn.Name = "psetbtn";
            this.psetbtn.Size = new System.Drawing.Size(75, 23);
            this.psetbtn.TabIndex = 8;
            this.psetbtn.Text = "Set";
            this.psetbtn.UseVisualStyleBackColor = true;
            this.psetbtn.Click += new System.EventHandler(this.psetbtn_Click);
            // 
            // bbox
            // 
            this.bbox.AutoSize = true;
            this.bbox.Location = new System.Drawing.Point(639, 44);
            this.bbox.Name = "bbox";
            this.bbox.Size = new System.Drawing.Size(69, 19);
            this.bbox.TabIndex = 7;
            this.bbox.Text = "Borders";
            this.bbox.UseVisualStyleBackColor = true;
            this.bbox.CheckedChanged += new System.EventHandler(this.bbox_CheckedChanged);
            // 
            // addbtn
            // 
            this.addbtn.Location = new System.Drawing.Point(13, 41);
            this.addbtn.Name = "addbtn";
            this.addbtn.Size = new System.Drawing.Size(105, 23);
            this.addbtn.TabIndex = 16;
            this.addbtn.Text = "Add blank box";
            this.addbtn.UseVisualStyleBackColor = true;
            this.addbtn.Click += new System.EventHandler(this.addbtn_Click);
            // 
            // frbtn
            // 
            this.frbtn.Location = new System.Drawing.Point(124, 41);
            this.frbtn.Name = "frbtn";
            this.frbtn.Size = new System.Drawing.Size(104, 23);
            this.frbtn.TabIndex = 17;
            this.frbtn.Text = "Add FROM box";
            this.frbtn.UseVisualStyleBackColor = true;
            this.frbtn.Click += new System.EventHandler(this.frbtn_Click);
            // 
            // printaddresses
            // 
            this.AcceptButton = this.printbtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(818, 667);
            this.Controls.Add(this.frbtn);
            this.Controls.Add(this.addbtn);
            this.Controls.Add(this.bbox);
            this.Controls.Add(this.psetbtn);
            this.Controls.Add(this.pytxt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pxtxt);
            this.Controls.Add(this.ftxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.setbtn);
            this.Controls.Add(this.ytxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.xtxt);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox xtxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ytxt;
        private System.Windows.Forms.Button setbtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ftxt;
        private System.Windows.Forms.TextBox pytxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox pxtxt;
        private System.Windows.Forms.Button psetbtn;
        private System.Windows.Forms.CheckBox bbox;
        private System.Windows.Forms.Button addbtn;
        private System.Windows.Forms.Button frbtn;
    }
}