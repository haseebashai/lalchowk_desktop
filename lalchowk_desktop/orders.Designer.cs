namespace Veiled_Kashmir_Admin_Panel
{
    partial class orders
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.delbtn = new System.Windows.Forms.Button();
            this.orlbl = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.statustxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.paymenttxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.emailtxt = new System.Windows.Forms.TextBox();
            this.orderpnl = new System.Windows.Forms.Panel();
            this.dpnl = new System.Windows.Forms.Panel();
            this.deupdbtn = new System.Windows.Forms.Button();
            this.updbtn = new System.Windows.Forms.Button();
            this.billbtn = new System.Windows.Forms.Button();
            this.cnfbtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.orderlbl = new System.Windows.Forms.Label();
            this.contactlbl = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.namelbl = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.amountlbl = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.proname = new System.Windows.Forms.ListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.address1lbl = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.billlbl = new System.Windows.Forms.Label();
            this.orderdetailview = new System.Windows.Forms.DataGridView();
            this.ordergridview = new System.Windows.Forms.DataGridView();
            this.loadinglbl = new System.Windows.Forms.Label();
            this.formlbl = new System.Windows.Forms.Label();
            this.bgworker = new System.ComponentModel.BackgroundWorker();
            this.ordttxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ordidtxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.orderpnl.SuspendLayout();
            this.dpnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderdetailview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordergridview)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ordidtxt);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.ordttxt);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.delbtn);
            this.panel1.Controls.Add(this.orlbl);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.statustxt);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.paymenttxt);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.emailtxt);
            this.panel1.Location = new System.Drawing.Point(2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1162, 49);
            this.panel1.TabIndex = 0;
            this.panel1.Visible = false;
            // 
            // delbtn
            // 
            this.delbtn.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.delbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delbtn.Location = new System.Drawing.Point(1085, 22);
            this.delbtn.Name = "delbtn";
            this.delbtn.Size = new System.Drawing.Size(69, 23);
            this.delbtn.TabIndex = 13;
            this.delbtn.Text = "Delete";
            this.delbtn.UseVisualStyleBackColor = true;
            this.delbtn.Click += new System.EventHandler(this.delbtn_Click);
            // 
            // orlbl
            // 
            this.orlbl.AutoSize = true;
            this.orlbl.BackColor = System.Drawing.Color.Transparent;
            this.orlbl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.orlbl.Location = new System.Drawing.Point(72, 22);
            this.orlbl.Name = "orlbl";
            this.orlbl.Size = new System.Drawing.Size(0, 13);
            this.orlbl.TabIndex = 11;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label12.Location = new System.Drawing.Point(3, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 13);
            this.label12.TabIndex = 10;
            this.label12.Text = "Total Orders:";
            // 
            // statustxt
            // 
            this.statustxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.statustxt.Location = new System.Drawing.Point(842, 22);
            this.statustxt.Name = "statustxt";
            this.statustxt.Size = new System.Drawing.Size(115, 20);
            this.statustxt.TabIndex = 9;
            this.statustxt.TextChanged += new System.EventHandler(this.statustxt_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(839, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Status:";
            // 
            // paymenttxt
            // 
            this.paymenttxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.paymenttxt.Location = new System.Drawing.Point(334, 22);
            this.paymenttxt.Name = "paymenttxt";
            this.paymenttxt.Size = new System.Drawing.Size(157, 20);
            this.paymenttxt.TabIndex = 7;
            this.paymenttxt.TextChanged += new System.EventHandler(this.paymenttxt_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(331, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(171, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Filter by Email:";
            // 
            // emailtxt
            // 
            this.emailtxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.emailtxt.Location = new System.Drawing.Point(172, 22);
            this.emailtxt.Name = "emailtxt";
            this.emailtxt.Size = new System.Drawing.Size(136, 20);
            this.emailtxt.TabIndex = 1;
            this.emailtxt.TextChanged += new System.EventHandler(this.emailtxt_TextChanged);
            // 
            // orderpnl
            // 
            this.orderpnl.Controls.Add(this.dpnl);
            this.orderpnl.Controls.Add(this.orderdetailview);
            this.orderpnl.Controls.Add(this.ordergridview);
            this.orderpnl.Controls.Add(this.loadinglbl);
            this.orderpnl.Location = new System.Drawing.Point(0, 49);
            this.orderpnl.Name = "orderpnl";
            this.orderpnl.Size = new System.Drawing.Size(1162, 616);
            this.orderpnl.TabIndex = 1;
            // 
            // dpnl
            // 
            this.dpnl.Controls.Add(this.deupdbtn);
            this.dpnl.Controls.Add(this.updbtn);
            this.dpnl.Controls.Add(this.billbtn);
            this.dpnl.Controls.Add(this.cnfbtn);
            this.dpnl.Controls.Add(this.label5);
            this.dpnl.Controls.Add(this.orderlbl);
            this.dpnl.Controls.Add(this.contactlbl);
            this.dpnl.Controls.Add(this.label7);
            this.dpnl.Controls.Add(this.panel2);
            this.dpnl.Controls.Add(this.namelbl);
            this.dpnl.Controls.Add(this.label8);
            this.dpnl.Controls.Add(this.amountlbl);
            this.dpnl.Controls.Add(this.panel5);
            this.dpnl.Controls.Add(this.label10);
            this.dpnl.Controls.Add(this.proname);
            this.dpnl.Controls.Add(this.panel3);
            this.dpnl.Controls.Add(this.label11);
            this.dpnl.Controls.Add(this.label9);
            this.dpnl.Controls.Add(this.address1lbl);
            this.dpnl.Controls.Add(this.panel4);
            this.dpnl.Controls.Add(this.billlbl);
            this.dpnl.Location = new System.Drawing.Point(3, 374);
            this.dpnl.Name = "dpnl";
            this.dpnl.Size = new System.Drawing.Size(1156, 238);
            this.dpnl.TabIndex = 26;
            this.dpnl.Visible = false;
            // 
            // deupdbtn
            // 
            this.deupdbtn.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.deupdbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deupdbtn.Location = new System.Drawing.Point(1101, 2);
            this.deupdbtn.Name = "deupdbtn";
            this.deupdbtn.Size = new System.Drawing.Size(54, 23);
            this.deupdbtn.TabIndex = 28;
            this.deupdbtn.Text = "Update";
            this.deupdbtn.UseVisualStyleBackColor = true;
            this.deupdbtn.Visible = false;
            this.deupdbtn.Click += new System.EventHandler(this.deupdbtn_Click);
            // 
            // updbtn
            // 
            this.updbtn.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.updbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updbtn.Location = new System.Drawing.Point(944, 59);
            this.updbtn.Name = "updbtn";
            this.updbtn.Size = new System.Drawing.Size(152, 42);
            this.updbtn.TabIndex = 14;
            this.updbtn.Text = "Update Details";
            this.updbtn.UseVisualStyleBackColor = true;
            this.updbtn.Click += new System.EventHandler(this.updbtn_Click);
            // 
            // billbtn
            // 
            this.billbtn.Location = new System.Drawing.Point(944, 165);
            this.billbtn.Name = "billbtn";
            this.billbtn.Size = new System.Drawing.Size(152, 52);
            this.billbtn.TabIndex = 26;
            this.billbtn.Text = "Confirm Delivery and Add Bill";
            this.billbtn.UseVisualStyleBackColor = true;
            this.billbtn.Click += new System.EventHandler(this.billbtn_Click);
            // 
            // cnfbtn
            // 
            this.cnfbtn.Location = new System.Drawing.Point(944, 107);
            this.cnfbtn.Name = "cnfbtn";
            this.cnfbtn.Size = new System.Drawing.Size(152, 52);
            this.cnfbtn.TabIndex = 15;
            this.cnfbtn.Text = "Make Reciept";
            this.cnfbtn.UseVisualStyleBackColor = true;
            this.cnfbtn.Click += new System.EventHandler(this.cnfbtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "OrderID";
            // 
            // orderlbl
            // 
            this.orderlbl.AutoSize = true;
            this.orderlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderlbl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.orderlbl.Location = new System.Drawing.Point(15, 33);
            this.orderlbl.Name = "orderlbl";
            this.orderlbl.Size = new System.Drawing.Size(43, 20);
            this.orderlbl.TabIndex = 3;
            this.orderlbl.Text = "OrID";
            // 
            // contactlbl
            // 
            this.contactlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contactlbl.ForeColor = System.Drawing.Color.Red;
            this.contactlbl.Location = new System.Drawing.Point(682, 101);
            this.contactlbl.Name = "contactlbl";
            this.contactlbl.Size = new System.Drawing.Size(150, 19);
            this.contactlbl.TabIndex = 23;
            this.contactlbl.Text = "contact";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(245, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 12);
            this.label7.TabIndex = 4;
            this.label7.Text = "Product Name";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Location = new System.Drawing.Point(94, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 178);
            this.panel2.TabIndex = 5;
            // 
            // namelbl
            // 
            this.namelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namelbl.ForeColor = System.Drawing.Color.Blue;
            this.namelbl.Location = new System.Drawing.Point(682, 77);
            this.namelbl.Name = "namelbl";
            this.namelbl.Size = new System.Drawing.Size(210, 20);
            this.namelbl.TabIndex = 20;
            this.namelbl.Text = "name";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(530, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 12);
            this.label8.TabIndex = 8;
            this.label8.Text = "Grand Total";
            // 
            // amountlbl
            // 
            this.amountlbl.AutoSize = true;
            this.amountlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amountlbl.ForeColor = System.Drawing.Color.Red;
            this.amountlbl.Location = new System.Drawing.Point(530, 120);
            this.amountlbl.Name = "amountlbl";
            this.amountlbl.Size = new System.Drawing.Size(85, 25);
            this.amountlbl.TabIndex = 9;
            this.amountlbl.Text = "Amount";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.LightGray;
            this.panel5.Location = new System.Drawing.Point(461, 50);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1, 178);
            this.panel5.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(503, 127);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 16);
            this.label10.TabIndex = 10;
            this.label10.Text = "Rs.";
            // 
            // proname
            // 
            this.proname.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.proname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.proname.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.proname.FormattingEnabled = true;
            this.proname.HorizontalScrollbar = true;
            this.proname.ItemHeight = 16;
            this.proname.Location = new System.Drawing.Point(116, 33);
            this.proname.Name = "proname";
            this.proname.Size = new System.Drawing.Size(319, 192);
            this.proname.TabIndex = 17;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.Location = new System.Drawing.Point(654, 50);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1, 178);
            this.panel3.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(997, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 12);
            this.label11.TabIndex = 16;
            this.label11.Text = "Confirm";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(747, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 12);
            this.label9.TabIndex = 12;
            this.label9.Text = "Address Detail";
            // 
            // address1lbl
            // 
            this.address1lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.address1lbl.ForeColor = System.Drawing.Color.Red;
            this.address1lbl.Location = new System.Drawing.Point(682, 124);
            this.address1lbl.Name = "address1lbl";
            this.address1lbl.Size = new System.Drawing.Size(210, 89);
            this.address1lbl.TabIndex = 13;
            this.address1lbl.Text = "address1";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightGray;
            this.panel4.Location = new System.Drawing.Point(922, 50);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1, 178);
            this.panel4.TabIndex = 14;
            // 
            // billlbl
            // 
            this.billlbl.AutoSize = true;
            this.billlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.billlbl.ForeColor = System.Drawing.Color.Blue;
            this.billlbl.Location = new System.Drawing.Point(988, 221);
            this.billlbl.Name = "billlbl";
            this.billlbl.Size = new System.Drawing.Size(68, 15);
            this.billlbl.TabIndex = 29;
            this.billlbl.Text = "Bills added";
            this.billlbl.Visible = false;
            // 
            // orderdetailview
            // 
            this.orderdetailview.AllowUserToAddRows = false;
            this.orderdetailview.BackgroundColor = System.Drawing.Color.White;
            this.orderdetailview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.orderdetailview.Location = new System.Drawing.Point(3, 240);
            this.orderdetailview.Name = "orderdetailview";
            this.orderdetailview.Size = new System.Drawing.Size(1156, 134);
            this.orderdetailview.TabIndex = 1;
            this.orderdetailview.Visible = false;
            this.orderdetailview.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.orderdetailview_CellClick);
            // 
            // ordergridview
            // 
            this.ordergridview.AllowUserToAddRows = false;
            this.ordergridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ordergridview.BackgroundColor = System.Drawing.Color.White;
            this.ordergridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ordergridview.Location = new System.Drawing.Point(3, 3);
            this.ordergridview.Name = "ordergridview";
            this.ordergridview.Size = new System.Drawing.Size(1156, 231);
            this.ordergridview.TabIndex = 0;
            this.ordergridview.Visible = false;
            this.ordergridview.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ordergridview_CellClick);
            // 
            // loadinglbl
            // 
            this.loadinglbl.AutoSize = true;
            this.loadinglbl.BackColor = System.Drawing.Color.Transparent;
            this.loadinglbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadinglbl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.loadinglbl.Location = new System.Drawing.Point(506, 293);
            this.loadinglbl.Name = "loadinglbl";
            this.loadinglbl.Size = new System.Drawing.Size(118, 17);
            this.loadinglbl.TabIndex = 27;
            this.loadinglbl.Text = "Loading Details...";
            this.loadinglbl.Visible = false;
            // 
            // formlbl
            // 
            this.formlbl.AutoSize = true;
            this.formlbl.BackColor = System.Drawing.Color.Transparent;
            this.formlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formlbl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.formlbl.Location = new System.Drawing.Point(-2, -1);
            this.formlbl.Name = "formlbl";
            this.formlbl.Size = new System.Drawing.Size(72, 25);
            this.formlbl.TabIndex = 14;
            this.formlbl.Text = "Orders";
            this.formlbl.Visible = false;
            // 
            // bgworker
            // 
            this.bgworker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgworker_DoWork);
            this.bgworker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgworker_RunWorkerCompleted);
            // 
            // ordttxt
            // 
            this.ordttxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ordttxt.Location = new System.Drawing.Point(680, 22);
            this.ordttxt.Name = "ordttxt";
            this.ordttxt.Size = new System.Drawing.Size(135, 20);
            this.ordttxt.TabIndex = 15;
            this.ordttxt.TextChanged += new System.EventHandler(this.ordttxt_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(677, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Order Date:";
            // 
            // ordidtxt
            // 
            this.ordidtxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ordidtxt.Location = new System.Drawing.Point(517, 22);
            this.ordidtxt.Name = "ordidtxt";
            this.ordidtxt.Size = new System.Drawing.Size(135, 20);
            this.ordidtxt.TabIndex = 17;
            this.ordidtxt.TextChanged += new System.EventHandler(this.ordidtxt_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(514, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Order ID:";
            // 
            // orders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1162, 666);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.orderpnl);
            this.Controls.Add(this.formlbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "orders";
            this.Text = "orders";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.orderpnl.ResumeLayout(false);
            this.orderpnl.PerformLayout();
            this.dpnl.ResumeLayout(false);
            this.dpnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderdetailview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordergridview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox emailtxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel orderpnl;
        private System.Windows.Forms.DataGridView ordergridview;
        private System.Windows.Forms.DataGridView orderdetailview;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label orderlbl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button cnfbtn;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label address1lbl;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label amountlbl;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ListBox proname;
        private System.Windows.Forms.Label namelbl;
        private System.Windows.Forms.Label contactlbl;
        private System.Windows.Forms.TextBox paymenttxt;
        private System.Windows.Forms.TextBox statustxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel dpnl;
        private System.Windows.Forms.Button billbtn;
        private System.Windows.Forms.Label orlbl;
        private System.Windows.Forms.Button delbtn;
        private System.ComponentModel.BackgroundWorker bgworker;
        public System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label formlbl;
        private System.Windows.Forms.Button updbtn;
        private System.Windows.Forms.Label loadinglbl;
        private System.Windows.Forms.Button deupdbtn;
        private System.Windows.Forms.Label billlbl;
        private System.Windows.Forms.TextBox ordidtxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ordttxt;
        private System.Windows.Forms.Label label1;
    }
}