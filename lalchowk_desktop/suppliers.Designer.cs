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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.supplierdatagridview = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.emailtxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.suppliertxt = new System.Windows.Forms.TextBox();
            this.updatebtn = new System.Windows.Forms.Button();
            this.supplierlbl = new System.Windows.Forms.Label();
            this.contactlbl = new System.Windows.Forms.Label();
            this.addresslbl = new System.Windows.Forms.Label();
            this.phonelbl = new System.Windows.Forms.Label();
            this.emaillbl = new System.Windows.Forms.Label();
            this.rmvbtn = new System.Windows.Forms.Button();
            this.countlbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.supnametxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.supemailtxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.suppwdtxt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.contxt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.posttxt = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.conaddtxt = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.desctxt = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.phonetxt = new System.Windows.Forms.TextBox();
            this.addbtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.dpnl = new System.Windows.Forms.Panel();
            this.suppnl = new System.Windows.Forms.Panel();
            this.bgworker = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.supplierdatagridview)).BeginInit();
            this.dpnl.SuspendLayout();
            this.suppnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // supplierdatagridview
            // 
            this.supplierdatagridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.supplierdatagridview.BackgroundColor = System.Drawing.Color.White;
            this.supplierdatagridview.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.supplierdatagridview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.supplierdatagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.supplierdatagridview.GridColor = System.Drawing.SystemColors.Control;
            this.supplierdatagridview.Location = new System.Drawing.Point(8, 107);
            this.supplierdatagridview.Name = "supplierdatagridview";
            this.supplierdatagridview.Size = new System.Drawing.Size(948, 431);
            this.supplierdatagridview.TabIndex = 0;
            this.supplierdatagridview.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.supplierdatagridview_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(959, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Filter by Email";
            // 
            // emailtxt
            // 
            this.emailtxt.Location = new System.Drawing.Point(962, 198);
            this.emailtxt.Name = "emailtxt";
            this.emailtxt.Size = new System.Drawing.Size(162, 20);
            this.emailtxt.TabIndex = 17;
            this.emailtxt.TextChanged += new System.EventHandler(this.emailtxt_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(959, 230);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Filter by SupplierName";
            // 
            // suppliertxt
            // 
            this.suppliertxt.Location = new System.Drawing.Point(962, 246);
            this.suppliertxt.Name = "suppliertxt";
            this.suppliertxt.Size = new System.Drawing.Size(162, 20);
            this.suppliertxt.TabIndex = 19;
            this.suppliertxt.TextChanged += new System.EventHandler(this.suppliertxt_TextChanged);
            // 
            // updatebtn
            // 
            this.updatebtn.Location = new System.Drawing.Point(962, 312);
            this.updatebtn.Name = "updatebtn";
            this.updatebtn.Size = new System.Drawing.Size(162, 168);
            this.updatebtn.TabIndex = 23;
            this.updatebtn.Text = "Update Supplier Details";
            this.updatebtn.UseVisualStyleBackColor = true;
            this.updatebtn.Click += new System.EventHandler(this.updatebtn_Click);
            // 
            // supplierlbl
            // 
            this.supplierlbl.AutoSize = true;
            this.supplierlbl.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplierlbl.Location = new System.Drawing.Point(6, -25);
            this.supplierlbl.Name = "supplierlbl";
            this.supplierlbl.Size = new System.Drawing.Size(46, 20);
            this.supplierlbl.TabIndex = 25;
            this.supplierlbl.Text = "name";
            // 
            // contactlbl
            // 
            this.contactlbl.AutoSize = true;
            this.contactlbl.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contactlbl.Location = new System.Drawing.Point(6, 2);
            this.contactlbl.Name = "contactlbl";
            this.contactlbl.Size = new System.Drawing.Size(103, 20);
            this.contactlbl.TabIndex = 26;
            this.contactlbl.Text = "Contact name";
            // 
            // addresslbl
            // 
            this.addresslbl.AutoSize = true;
            this.addresslbl.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addresslbl.Location = new System.Drawing.Point(6, 21);
            this.addresslbl.Name = "addresslbl";
            this.addresslbl.Size = new System.Drawing.Size(59, 20);
            this.addresslbl.TabIndex = 27;
            this.addresslbl.Text = "address";
            // 
            // phonelbl
            // 
            this.phonelbl.AutoSize = true;
            this.phonelbl.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phonelbl.Location = new System.Drawing.Point(6, 40);
            this.phonelbl.Name = "phonelbl";
            this.phonelbl.Size = new System.Drawing.Size(48, 20);
            this.phonelbl.TabIndex = 28;
            this.phonelbl.Text = "Phone";
            // 
            // emaillbl
            // 
            this.emaillbl.AutoSize = true;
            this.emaillbl.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emaillbl.Location = new System.Drawing.Point(6, 59);
            this.emaillbl.Name = "emaillbl";
            this.emaillbl.Size = new System.Drawing.Size(45, 20);
            this.emaillbl.TabIndex = 29;
            this.emaillbl.Text = "email";
            // 
            // rmvbtn
            // 
            this.rmvbtn.BackColor = System.Drawing.Color.Black;
            this.rmvbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rmvbtn.ForeColor = System.Drawing.Color.White;
            this.rmvbtn.Location = new System.Drawing.Point(308, 31);
            this.rmvbtn.Name = "rmvbtn";
            this.rmvbtn.Size = new System.Drawing.Size(129, 36);
            this.rmvbtn.TabIndex = 30;
            this.rmvbtn.Text = "Remove Supplier";
            this.rmvbtn.UseVisualStyleBackColor = false;
            this.rmvbtn.Click += new System.EventHandler(this.rmvbtn_Click);
            // 
            // countlbl
            // 
            this.countlbl.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countlbl.Location = new System.Drawing.Point(443, 27);
            this.countlbl.Name = "countlbl";
            this.countlbl.Size = new System.Drawing.Size(411, 58);
            this.countlbl.TabIndex = 31;
            this.countlbl.Text = "Count";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Supplier Name";
            // 
            // supnametxt
            // 
            this.supnametxt.Location = new System.Drawing.Point(7, 21);
            this.supnametxt.Name = "supnametxt";
            this.supnametxt.Size = new System.Drawing.Size(179, 20);
            this.supnametxt.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "Supplier Email";
            // 
            // supemailtxt
            // 
            this.supemailtxt.Location = new System.Drawing.Point(7, 67);
            this.supemailtxt.Name = "supemailtxt";
            this.supemailtxt.Size = new System.Drawing.Size(179, 20);
            this.supemailtxt.TabIndex = 34;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(227, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 37;
            this.label6.Text = "Password";
            // 
            // suppwdtxt
            // 
            this.suppwdtxt.Location = new System.Drawing.Point(230, 21);
            this.suppwdtxt.Name = "suppwdtxt";
            this.suppwdtxt.Size = new System.Drawing.Size(179, 20);
            this.suppwdtxt.TabIndex = 36;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(227, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 39;
            this.label7.Text = "Contact Name";
            // 
            // contxt
            // 
            this.contxt.Location = new System.Drawing.Point(230, 67);
            this.contxt.Name = "contxt";
            this.contxt.Size = new System.Drawing.Size(179, 20);
            this.contxt.TabIndex = 38;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(462, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 43;
            this.label8.Text = "Postal Code";
            // 
            // posttxt
            // 
            this.posttxt.Location = new System.Drawing.Point(465, 67);
            this.posttxt.Name = "posttxt";
            this.posttxt.Size = new System.Drawing.Size(179, 20);
            this.posttxt.TabIndex = 42;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(462, 5);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 41;
            this.label9.Text = "Address";
            // 
            // conaddtxt
            // 
            this.conaddtxt.Location = new System.Drawing.Point(465, 21);
            this.conaddtxt.Name = "conaddtxt";
            this.conaddtxt.Size = new System.Drawing.Size(179, 20);
            this.conaddtxt.TabIndex = 40;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(703, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 47;
            this.label10.Text = "Description";
            // 
            // desctxt
            // 
            this.desctxt.Location = new System.Drawing.Point(706, 67);
            this.desctxt.Name = "desctxt";
            this.desctxt.Size = new System.Drawing.Size(179, 20);
            this.desctxt.TabIndex = 46;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(703, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 45;
            this.label11.Text = "Phone";
            // 
            // phonetxt
            // 
            this.phonetxt.Location = new System.Drawing.Point(706, 21);
            this.phonetxt.Name = "phonetxt";
            this.phonetxt.Size = new System.Drawing.Size(179, 20);
            this.phonetxt.TabIndex = 44;
            // 
            // addbtn
            // 
            this.addbtn.AutoSize = true;
            this.addbtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addbtn.Depth = 0;
            this.addbtn.Location = new System.Drawing.Point(935, 39);
            this.addbtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.addbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.addbtn.Name = "addbtn";
            this.addbtn.Primary = false;
            this.addbtn.Size = new System.Drawing.Size(105, 36);
            this.addbtn.TabIndex = 59;
            this.addbtn.Text = "Add supplier";
            this.addbtn.UseVisualStyleBackColor = true;
            this.addbtn.Click += new System.EventHandler(this.addbtn_Click);
            // 
            // dpnl
            // 
            this.dpnl.Controls.Add(this.rmvbtn);
            this.dpnl.Controls.Add(this.supplierlbl);
            this.dpnl.Controls.Add(this.contactlbl);
            this.dpnl.Controls.Add(this.addresslbl);
            this.dpnl.Controls.Add(this.phonelbl);
            this.dpnl.Controls.Add(this.emaillbl);
            this.dpnl.Controls.Add(this.countlbl);
            this.dpnl.Location = new System.Drawing.Point(3, 539);
            this.dpnl.Name = "dpnl";
            this.dpnl.Size = new System.Drawing.Size(870, 126);
            this.dpnl.TabIndex = 60;
            this.dpnl.Visible = false;
            // 
            // suppnl
            // 
            this.suppnl.Controls.Add(this.dpnl);
            this.suppnl.Controls.Add(this.supplierdatagridview);
            this.suppnl.Controls.Add(this.addbtn);
            this.suppnl.Controls.Add(this.emailtxt);
            this.suppnl.Controls.Add(this.label10);
            this.suppnl.Controls.Add(this.label2);
            this.suppnl.Controls.Add(this.desctxt);
            this.suppnl.Controls.Add(this.suppliertxt);
            this.suppnl.Controls.Add(this.label11);
            this.suppnl.Controls.Add(this.label3);
            this.suppnl.Controls.Add(this.phonetxt);
            this.suppnl.Controls.Add(this.updatebtn);
            this.suppnl.Controls.Add(this.label8);
            this.suppnl.Controls.Add(this.supnametxt);
            this.suppnl.Controls.Add(this.posttxt);
            this.suppnl.Controls.Add(this.label4);
            this.suppnl.Controls.Add(this.label9);
            this.suppnl.Controls.Add(this.supemailtxt);
            this.suppnl.Controls.Add(this.conaddtxt);
            this.suppnl.Controls.Add(this.label5);
            this.suppnl.Controls.Add(this.label7);
            this.suppnl.Controls.Add(this.suppwdtxt);
            this.suppnl.Controls.Add(this.contxt);
            this.suppnl.Controls.Add(this.label6);
            this.suppnl.Location = new System.Drawing.Point(2, 30);
            this.suppnl.Name = "suppnl";
            this.suppnl.Size = new System.Drawing.Size(1163, 680);
            this.suppnl.TabIndex = 61;
            this.suppnl.Visible = false;
            // 
            // bgworker
            // 
            this.bgworker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgworker_DoWork);
            this.bgworker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgworker_RunWorkerCompleted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 25);
            this.label1.TabIndex = 62;
            this.label1.Visible = false;
            // 
            // suppliers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1162, 722);
            this.Controls.Add(this.suppnl);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "suppliers";
            this.Text = "contacts";
            ((System.ComponentModel.ISupportInitialize)(this.supplierdatagridview)).EndInit();
            this.dpnl.ResumeLayout(false);
            this.dpnl.PerformLayout();
            this.suppnl.ResumeLayout(false);
            this.suppnl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView supplierdatagridview;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox emailtxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox suppliertxt;
        private System.Windows.Forms.Button updatebtn;
        private System.Windows.Forms.Label supplierlbl;
        private System.Windows.Forms.Label contactlbl;
        private System.Windows.Forms.Label addresslbl;
        private System.Windows.Forms.Label phonelbl;
        private System.Windows.Forms.Label emaillbl;
        private System.Windows.Forms.Button rmvbtn;
        private System.Windows.Forms.Label countlbl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox supnametxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox supemailtxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox suppwdtxt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox contxt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox posttxt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox conaddtxt;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox desctxt;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox phonetxt;
        private MaterialSkin.Controls.MaterialFlatButton addbtn;
        private System.Windows.Forms.Panel dpnl;
        private System.Windows.Forms.Panel suppnl;
        private System.ComponentModel.BackgroundWorker bgworker;
        private System.Windows.Forms.Label label1;
    }
}