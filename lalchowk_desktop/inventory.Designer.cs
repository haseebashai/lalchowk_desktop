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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.inventorydatagridview = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.supidtxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pronametxt = new System.Windows.Forms.TextBox();
            this.catidtxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.brandtxt = new System.Windows.Forms.TextBox();
            this.rmvbtn = new System.Windows.Forms.Button();
            this.productlbl = new System.Windows.Forms.Label();
            this.idlbl = new System.Windows.Forms.Label();
            this.catidlbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.inventorydatagridview)).BeginInit();
            this.SuspendLayout();
            // 
            // inventorydatagridview
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.inventorydatagridview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.inventorydatagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.inventorydatagridview.Location = new System.Drawing.Point(2, 73);
            this.inventorydatagridview.Name = "inventorydatagridview";
            this.inventorydatagridview.Size = new System.Drawing.Size(1160, 517);
            this.inventorydatagridview.TabIndex = 0;
            this.inventorydatagridview.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.inventorydatagridview_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trajan Pro", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(431, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Product Inventory";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(237, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Filter by Product Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Filter by Supplier ID";
            // 
            // supidtxt
            // 
            this.supidtxt.Location = new System.Drawing.Point(141, 45);
            this.supidtxt.Name = "supidtxt";
            this.supidtxt.Size = new System.Drawing.Size(78, 20);
            this.supidtxt.TabIndex = 21;
            this.supidtxt.TextChanged += new System.EventHandler(this.supidtxt_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(557, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Filter by Category ID";
            // 
            // pronametxt
            // 
            this.pronametxt.Location = new System.Drawing.Point(355, 45);
            this.pronametxt.Name = "pronametxt";
            this.pronametxt.Size = new System.Drawing.Size(187, 20);
            this.pronametxt.TabIndex = 23;
            this.pronametxt.TextChanged += new System.EventHandler(this.pronametxt_TextChanged);
            // 
            // catidtxt
            // 
            this.catidtxt.Location = new System.Drawing.Point(665, 45);
            this.catidtxt.Name = "catidtxt";
            this.catidtxt.Size = new System.Drawing.Size(107, 20);
            this.catidtxt.TabIndex = 25;
            this.catidtxt.TextChanged += new System.EventHandler(this.catidtxt_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(797, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Filter by Brand";
            // 
            // brandtxt
            // 
            this.brandtxt.Location = new System.Drawing.Point(877, 45);
            this.brandtxt.Name = "brandtxt";
            this.brandtxt.Size = new System.Drawing.Size(187, 20);
            this.brandtxt.TabIndex = 27;
            this.brandtxt.TextChanged += new System.EventHandler(this.brandtxt_TextChanged);
            // 
            // rmvbtn
            // 
            this.rmvbtn.BackColor = System.Drawing.Color.Red;
            this.rmvbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rmvbtn.ForeColor = System.Drawing.Color.White;
            this.rmvbtn.Location = new System.Drawing.Point(312, 674);
            this.rmvbtn.Name = "rmvbtn";
            this.rmvbtn.Size = new System.Drawing.Size(129, 36);
            this.rmvbtn.TabIndex = 33;
            this.rmvbtn.Text = "Remove Product";
            this.rmvbtn.UseVisualStyleBackColor = false;
            this.rmvbtn.Visible = false;
            this.rmvbtn.Click += new System.EventHandler(this.rmvbtn_Click);
            // 
            // productlbl
            // 
            this.productlbl.AutoSize = true;
            this.productlbl.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productlbl.Location = new System.Drawing.Point(308, 613);
            this.productlbl.Name = "productlbl";
            this.productlbl.Size = new System.Drawing.Size(46, 20);
            this.productlbl.TabIndex = 32;
            this.productlbl.Text = "name";
            // 
            // idlbl
            // 
            this.idlbl.AutoSize = true;
            this.idlbl.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idlbl.Location = new System.Drawing.Point(308, 593);
            this.idlbl.Name = "idlbl";
            this.idlbl.Size = new System.Drawing.Size(22, 20);
            this.idlbl.TabIndex = 31;
            this.idlbl.Text = "ID";
            // 
            // catidlbl
            // 
            this.catidlbl.AutoSize = true;
            this.catidlbl.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.catidlbl.Location = new System.Drawing.Point(431, 593);
            this.catidlbl.Name = "catidlbl";
            this.catidlbl.Size = new System.Drawing.Size(50, 20);
            this.catidlbl.TabIndex = 34;
            this.catidlbl.Text = "Cat ID";
            // 
            // inventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1162, 722);
            this.Controls.Add(this.catidlbl);
            this.Controls.Add(this.rmvbtn);
            this.Controls.Add(this.productlbl);
            this.Controls.Add(this.idlbl);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.brandtxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.catidtxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pronametxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.supidtxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inventorydatagridview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "inventory";
            this.Text = "research";
            this.Load += new System.EventHandler(this.inventory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.inventorydatagridview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView inventorydatagridview;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox supidtxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox pronametxt;
        private System.Windows.Forms.TextBox catidtxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox brandtxt;
        private System.Windows.Forms.Button rmvbtn;
        private System.Windows.Forms.Label productlbl;
        private System.Windows.Forms.Label idlbl;
        private System.Windows.Forms.Label catidlbl;
    }
}