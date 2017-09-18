namespace Veiled_Kashmir_Admin_Panel
{
    partial class suppliers
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
            this.supplierdatagridview = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.emailtxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.suppliertxt = new System.Windows.Forms.TextBox();
            this.updatebtn = new System.Windows.Forms.Button();
            this.idlbl = new System.Windows.Forms.Label();
            this.supplierlbl = new System.Windows.Forms.Label();
            this.contactlbl = new System.Windows.Forms.Label();
            this.addresslbl = new System.Windows.Forms.Label();
            this.phonelbl = new System.Windows.Forms.Label();
            this.emaillbl = new System.Windows.Forms.Label();
            this.rmvbtn = new System.Windows.Forms.Button();
            this.countlbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.supplierdatagridview)).BeginInit();
            this.SuspendLayout();
            // 
            // supplierdatagridview
            // 
            this.supplierdatagridview.BackgroundColor = System.Drawing.Color.White;
            this.supplierdatagridview.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.supplierdatagridview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.supplierdatagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.supplierdatagridview.GridColor = System.Drawing.SystemColors.Control;
            this.supplierdatagridview.Location = new System.Drawing.Point(17, 80);
            this.supplierdatagridview.Name = "supplierdatagridview";
            this.supplierdatagridview.Size = new System.Drawing.Size(948, 470);
            this.supplierdatagridview.TabIndex = 0;
            this.supplierdatagridview.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.supplierdatagridview_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(12, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Supplier Information";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Filter by Email";
            // 
            // emailtxt
            // 
            this.emailtxt.Location = new System.Drawing.Point(262, 54);
            this.emailtxt.Name = "emailtxt";
            this.emailtxt.Size = new System.Drawing.Size(201, 20);
            this.emailtxt.TabIndex = 17;
            this.emailtxt.TextChanged += new System.EventHandler(this.emailtxt_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(490, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Filter by SupplierName";
            // 
            // suppliertxt
            // 
            this.suppliertxt.Location = new System.Drawing.Point(608, 54);
            this.suppliertxt.Name = "suppliertxt";
            this.suppliertxt.Size = new System.Drawing.Size(187, 20);
            this.suppliertxt.TabIndex = 19;
            this.suppliertxt.TextChanged += new System.EventHandler(this.suppliertxt_TextChanged);
            // 
            // updatebtn
            // 
            this.updatebtn.Location = new System.Drawing.Point(972, 232);
            this.updatebtn.Name = "updatebtn";
            this.updatebtn.Size = new System.Drawing.Size(162, 168);
            this.updatebtn.TabIndex = 23;
            this.updatebtn.Text = "Update Supplier Details";
            this.updatebtn.UseVisualStyleBackColor = true;
            this.updatebtn.Click += new System.EventHandler(this.updatebtn_Click);
            // 
            // idlbl
            // 
            this.idlbl.AutoSize = true;
            this.idlbl.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idlbl.Location = new System.Drawing.Point(33, 564);
            this.idlbl.Name = "idlbl";
            this.idlbl.Size = new System.Drawing.Size(22, 20);
            this.idlbl.TabIndex = 24;
            this.idlbl.Text = "ID";
            this.idlbl.Visible = false;
            this.idlbl.Click += new System.EventHandler(this.idlbl_Click);
            // 
            // supplierlbl
            // 
            this.supplierlbl.AutoSize = true;
            this.supplierlbl.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplierlbl.Location = new System.Drawing.Point(33, 583);
            this.supplierlbl.Name = "supplierlbl";
            this.supplierlbl.Size = new System.Drawing.Size(46, 20);
            this.supplierlbl.TabIndex = 25;
            this.supplierlbl.Text = "name";
            this.supplierlbl.Visible = false;
            this.supplierlbl.Click += new System.EventHandler(this.supplierlbl_Click);
            // 
            // contactlbl
            // 
            this.contactlbl.AutoSize = true;
            this.contactlbl.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contactlbl.Location = new System.Drawing.Point(33, 602);
            this.contactlbl.Name = "contactlbl";
            this.contactlbl.Size = new System.Drawing.Size(103, 20);
            this.contactlbl.TabIndex = 26;
            this.contactlbl.Text = "Contact name";
            this.contactlbl.Visible = false;
            // 
            // addresslbl
            // 
            this.addresslbl.AutoSize = true;
            this.addresslbl.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addresslbl.Location = new System.Drawing.Point(33, 621);
            this.addresslbl.Name = "addresslbl";
            this.addresslbl.Size = new System.Drawing.Size(59, 20);
            this.addresslbl.TabIndex = 27;
            this.addresslbl.Text = "address";
            this.addresslbl.Visible = false;
            // 
            // phonelbl
            // 
            this.phonelbl.AutoSize = true;
            this.phonelbl.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phonelbl.Location = new System.Drawing.Point(33, 640);
            this.phonelbl.Name = "phonelbl";
            this.phonelbl.Size = new System.Drawing.Size(48, 20);
            this.phonelbl.TabIndex = 28;
            this.phonelbl.Text = "Phone";
            this.phonelbl.Visible = false;
            // 
            // emaillbl
            // 
            this.emaillbl.AutoSize = true;
            this.emaillbl.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emaillbl.Location = new System.Drawing.Point(33, 659);
            this.emaillbl.Name = "emaillbl";
            this.emaillbl.Size = new System.Drawing.Size(45, 20);
            this.emaillbl.TabIndex = 29;
            this.emaillbl.Text = "email";
            this.emaillbl.Visible = false;
            // 
            // rmvbtn
            // 
            this.rmvbtn.BackColor = System.Drawing.Color.Red;
            this.rmvbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rmvbtn.ForeColor = System.Drawing.Color.White;
            this.rmvbtn.Location = new System.Drawing.Point(335, 642);
            this.rmvbtn.Name = "rmvbtn";
            this.rmvbtn.Size = new System.Drawing.Size(129, 36);
            this.rmvbtn.TabIndex = 30;
            this.rmvbtn.Text = "Remove Supplier";
            this.rmvbtn.UseVisualStyleBackColor = false;
            this.rmvbtn.Visible = false;
            this.rmvbtn.Click += new System.EventHandler(this.rmvbtn_Click);
            // 
            // countlbl
            // 
            this.countlbl.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countlbl.Location = new System.Drawing.Point(470, 640);
            this.countlbl.Name = "countlbl";
            this.countlbl.Size = new System.Drawing.Size(411, 58);
            this.countlbl.TabIndex = 31;
            this.countlbl.Text = "Count";
            this.countlbl.Visible = false;
            // 
            // suppliers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1162, 722);
            this.Controls.Add(this.countlbl);
            this.Controls.Add(this.rmvbtn);
            this.Controls.Add(this.emaillbl);
            this.Controls.Add(this.phonelbl);
            this.Controls.Add(this.addresslbl);
            this.Controls.Add(this.contactlbl);
            this.Controls.Add(this.supplierlbl);
            this.Controls.Add(this.idlbl);
            this.Controls.Add(this.updatebtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.suppliertxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.emailtxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.supplierdatagridview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "suppliers";
            this.Text = "contacts";
            this.Load += new System.EventHandler(this.suppliers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.supplierdatagridview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView supplierdatagridview;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox emailtxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox suppliertxt;
        private System.Windows.Forms.Button updatebtn;
        private System.Windows.Forms.Label idlbl;
        private System.Windows.Forms.Label supplierlbl;
        private System.Windows.Forms.Label contactlbl;
        private System.Windows.Forms.Label addresslbl;
        private System.Windows.Forms.Label phonelbl;
        private System.Windows.Forms.Label emaillbl;
        private System.Windows.Forms.Button rmvbtn;
        private System.Windows.Forms.Label countlbl;
    }
}