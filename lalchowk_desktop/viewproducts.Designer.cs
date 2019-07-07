namespace Modest_Attires
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
            this.ppnl = new System.Windows.Forms.Panel();
            this.variant1list = new System.Windows.Forms.ComboBox();
            this.addbtn = new System.Windows.Forms.Button();
            this.variantvaluetxt = new System.Windows.Forms.TextBox();
            this.bgworker = new System.ComponentModel.BackgroundWorker();
            this.variantdataview = new System.Windows.Forms.DataGridView();
            this.variantvaluedataview = new System.Windows.Forms.DataGridView();
            this.upbtn2 = new System.Windows.Forms.Button();
            this.upbtn1 = new System.Windows.Forms.Button();
            this.ppnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.variantdataview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.variantvaluedataview)).BeginInit();
            this.SuspendLayout();
            // 
            // ppnl
            // 
            this.ppnl.Controls.Add(this.upbtn1);
            this.ppnl.Controls.Add(this.upbtn2);
            this.ppnl.Controls.Add(this.variantvaluedataview);
            this.ppnl.Controls.Add(this.variantdataview);
            this.ppnl.Controls.Add(this.variant1list);
            this.ppnl.Controls.Add(this.addbtn);
            this.ppnl.Controls.Add(this.variantvaluetxt);
            this.ppnl.Location = new System.Drawing.Point(3, 2);
            this.ppnl.Name = "ppnl";
            this.ppnl.Size = new System.Drawing.Size(941, 610);
            this.ppnl.TabIndex = 93;
            // 
            // variant1list
            // 
            this.variant1list.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.variant1list.FormattingEnabled = true;
            this.variant1list.Location = new System.Drawing.Point(237, 473);
            this.variant1list.Name = "variant1list";
            this.variant1list.Size = new System.Drawing.Size(102, 21);
            this.variant1list.TabIndex = 125;
            // 
            // addbtn
            // 
            this.addbtn.Location = new System.Drawing.Point(407, 518);
            this.addbtn.Name = "addbtn";
            this.addbtn.Size = new System.Drawing.Size(116, 36);
            this.addbtn.TabIndex = 123;
            this.addbtn.Text = "Add Option";
            this.addbtn.UseVisualStyleBackColor = true;
            this.addbtn.Click += new System.EventHandler(this.addbtn_Click);
            // 
            // variantvaluetxt
            // 
            this.variantvaluetxt.Location = new System.Drawing.Point(389, 473);
            this.variantvaluetxt.Name = "variantvaluetxt";
            this.variantvaluetxt.Size = new System.Drawing.Size(134, 20);
            this.variantvaluetxt.TabIndex = 116;
            // 
            // variantdataview
            // 
            this.variantdataview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.variantdataview.BackgroundColor = System.Drawing.Color.White;
            this.variantdataview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.variantdataview.Location = new System.Drawing.Point(9, 95);
            this.variantdataview.Name = "variantdataview";
            this.variantdataview.Size = new System.Drawing.Size(435, 231);
            this.variantdataview.TabIndex = 126;
            // 
            // variantvaluedataview
            // 
            this.variantvaluedataview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.variantvaluedataview.BackgroundColor = System.Drawing.Color.White;
            this.variantvaluedataview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.variantvaluedataview.Location = new System.Drawing.Point(485, 96);
            this.variantvaluedataview.Name = "variantvaluedataview";
            this.variantvaluedataview.Size = new System.Drawing.Size(435, 231);
            this.variantvaluedataview.TabIndex = 127;
            // 
            // upbtn2
            // 
            this.upbtn2.Location = new System.Drawing.Point(804, 333);
            this.upbtn2.Name = "upbtn2";
            this.upbtn2.Size = new System.Drawing.Size(116, 36);
            this.upbtn2.TabIndex = 128;
            this.upbtn2.Text = "Update";
            this.upbtn2.UseVisualStyleBackColor = true;
            this.upbtn2.Click += new System.EventHandler(this.upbtn2_Click);
            // 
            // upbtn1
            // 
            this.upbtn1.Location = new System.Drawing.Point(328, 332);
            this.upbtn1.Name = "upbtn1";
            this.upbtn1.Size = new System.Drawing.Size(116, 36);
            this.upbtn1.TabIndex = 129;
            this.upbtn1.Text = "Update";
            this.upbtn1.UseVisualStyleBackColor = true;
            this.upbtn1.Click += new System.EventHandler(this.upbtn1_Click);
            // 
            // viewproducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(950, 616);
            this.ControlBox = false;
            this.Controls.Add(this.ppnl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "viewproducts";
            this.Text = "viewproducts";
            this.ppnl.ResumeLayout(false);
            this.ppnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.variantdataview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.variantvaluedataview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel ppnl;
        private System.ComponentModel.BackgroundWorker bgworker;
        private System.Windows.Forms.Button addbtn;
        private System.Windows.Forms.TextBox variantvaluetxt;
        private System.Windows.Forms.ComboBox variant1list;
        private System.Windows.Forms.DataGridView variantvaluedataview;
        private System.Windows.Forms.DataGridView variantdataview;
        private System.Windows.Forms.Button upbtn1;
        private System.Windows.Forms.Button upbtn2;
    }
}