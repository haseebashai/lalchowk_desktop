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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.inventorydatagridview = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.supidtxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pronametxt = new System.Windows.Forms.TextBox();
            this.proidtxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.brandtxt = new System.Windows.Forms.TextBox();
            this.productlbl = new System.Windows.Forms.Label();
            this.idlbl = new System.Windows.Forms.Label();
            this.desctxtbox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.updatebtn = new System.Windows.Forms.Button();
            this.upbtn = new System.Windows.Forms.Button();
            this.ipnl = new System.Windows.Forms.Panel();
            this.cattxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.descpnl = new System.Windows.Forms.Panel();
            this.dp = new System.Windows.Forms.PictureBox();
            this.bgworker = new System.ComponentModel.BackgroundWorker();
            this.pbar = new System.Windows.Forms.ProgressBar();
            this.refreshlbl = new System.Windows.Forms.Label();
            this.invpnl = new System.Windows.Forms.Panel();
            this.spnl = new System.Windows.Forms.Panel();
            this.searchlbl = new System.Windows.Forms.Label();
            this.searchtxt = new System.Windows.Forms.TextBox();
            this.plbl = new System.Windows.Forms.Label();
            this.pidtxt = new System.Windows.Forms.TextBox();
            this.loadinglbl = new System.Windows.Forms.Label();
            this.catsuplbl = new System.Windows.Forms.Label();
            this.catidtxt = new System.Windows.Forms.TextBox();
            this.allinvbtn = new System.Windows.Forms.Button();
            this.clearbtn = new System.Windows.Forms.Button();
            this.listbtn = new System.Windows.Forms.Button();
            this.suplbl = new System.Windows.Forms.Label();
            this.thirdlbl = new System.Windows.Forms.Label();
            this.seclbl = new System.Windows.Forms.Label();
            this.supbox = new System.Windows.Forms.ComboBox();
            this.thirdbox = new System.Windows.Forms.ComboBox();
            this.secbox = new System.Windows.Forms.ComboBox();
            this.dldpic = new System.Windows.Forms.Label();
            this.progresspc = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.inventorydatagridview)).BeginInit();
            this.ipnl.SuspendLayout();
            this.descpnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dp)).BeginInit();
            this.invpnl.SuspendLayout();
            this.spnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // inventorydatagridview
            // 
            this.inventorydatagridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.inventorydatagridview.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.inventorydatagridview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.inventorydatagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.inventorydatagridview.Location = new System.Drawing.Point(4, 28);
            this.inventorydatagridview.Name = "inventorydatagridview";
            this.inventorydatagridview.Size = new System.Drawing.Size(1148, 364);
            this.inventorydatagridview.TabIndex = 0;
            this.inventorydatagridview.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.inventorydatagridview_CellClick);
            this.inventorydatagridview.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.inventorydatagridview_CellClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(251, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Product Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(552, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Supplier ID";
            // 
            // supidtxt
            // 
            this.supidtxt.Location = new System.Drawing.Point(617, 4);
            this.supidtxt.Name = "supidtxt";
            this.supidtxt.Size = new System.Drawing.Size(78, 20);
            this.supidtxt.TabIndex = 21;
            this.supidtxt.TextChanged += new System.EventHandler(this.supidtxt_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Filter by ProductID";
            // 
            // pronametxt
            // 
            this.pronametxt.Location = new System.Drawing.Point(332, 4);
            this.pronametxt.Name = "pronametxt";
            this.pronametxt.Size = new System.Drawing.Size(187, 20);
            this.pronametxt.TabIndex = 23;
            this.pronametxt.TextChanged += new System.EventHandler(this.pronametxt_TextChanged);
            // 
            // proidtxt
            // 
            this.proidtxt.Location = new System.Drawing.Point(126, 4);
            this.proidtxt.Name = "proidtxt";
            this.proidtxt.Size = new System.Drawing.Size(107, 20);
            this.proidtxt.TabIndex = 25;
            this.proidtxt.TextChanged += new System.EventHandler(this.catidtxt_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(716, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Brand";
            // 
            // brandtxt
            // 
            this.brandtxt.Location = new System.Drawing.Point(757, 4);
            this.brandtxt.Name = "brandtxt";
            this.brandtxt.Size = new System.Drawing.Size(109, 20);
            this.brandtxt.TabIndex = 27;
            this.brandtxt.TextChanged += new System.EventHandler(this.brandtxt_TextChanged);
            // 
            // productlbl
            // 
            this.productlbl.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productlbl.Location = new System.Drawing.Point(6, 29);
            this.productlbl.Name = "productlbl";
            this.productlbl.Size = new System.Drawing.Size(213, 49);
            this.productlbl.TabIndex = 32;
            // 
            // idlbl
            // 
            this.idlbl.AutoSize = true;
            this.idlbl.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idlbl.Location = new System.Drawing.Point(7, 9);
            this.idlbl.Name = "idlbl";
            this.idlbl.Size = new System.Drawing.Size(0, 20);
            this.idlbl.TabIndex = 31;
            // 
            // desctxtbox
            // 
            this.desctxtbox.AcceptsTab = true;
            this.desctxtbox.Location = new System.Drawing.Point(225, 1);
            this.desctxtbox.Multiline = true;
            this.desctxtbox.Name = "desctxtbox";
            this.desctxtbox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.desctxtbox.Size = new System.Drawing.Size(371, 199);
            this.desctxtbox.TabIndex = 36;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(136, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 20);
            this.label7.TabIndex = 37;
            this.label7.Text = "Description";
            // 
            // updatebtn
            // 
            this.updatebtn.Location = new System.Drawing.Point(602, 70);
            this.updatebtn.Name = "updatebtn";
            this.updatebtn.Size = new System.Drawing.Size(61, 62);
            this.updatebtn.TabIndex = 38;
            this.updatebtn.Text = "Update";
            this.updatebtn.UseVisualStyleBackColor = true;
            this.updatebtn.Click += new System.EventHandler(this.updatebtn_Click);
            // 
            // upbtn
            // 
            this.upbtn.Location = new System.Drawing.Point(1033, 461);
            this.upbtn.Name = "upbtn";
            this.upbtn.Size = new System.Drawing.Size(122, 36);
            this.upbtn.TabIndex = 40;
            this.upbtn.Text = "Update";
            this.upbtn.UseVisualStyleBackColor = true;
            this.upbtn.Click += new System.EventHandler(this.upbtn_Click);
            // 
            // ipnl
            // 
            this.ipnl.Controls.Add(this.cattxt);
            this.ipnl.Controls.Add(this.label1);
            this.ipnl.Controls.Add(this.inventorydatagridview);
            this.ipnl.Controls.Add(this.supidtxt);
            this.ipnl.Controls.Add(this.label2);
            this.ipnl.Controls.Add(this.pronametxt);
            this.ipnl.Controls.Add(this.label3);
            this.ipnl.Controls.Add(this.proidtxt);
            this.ipnl.Controls.Add(this.label4);
            this.ipnl.Controls.Add(this.brandtxt);
            this.ipnl.Controls.Add(this.label5);
            this.ipnl.Location = new System.Drawing.Point(3, 66);
            this.ipnl.Name = "ipnl";
            this.ipnl.Size = new System.Drawing.Size(1156, 394);
            this.ipnl.TabIndex = 41;
            this.ipnl.Visible = false;
            // 
            // cattxt
            // 
            this.cattxt.Location = new System.Drawing.Point(952, 4);
            this.cattxt.Name = "cattxt";
            this.cattxt.Size = new System.Drawing.Size(109, 20);
            this.cattxt.TabIndex = 29;
            this.cattxt.TextChanged += new System.EventHandler(this.cattxt_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(886, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "CategoryID";
            // 
            // descpnl
            // 
            this.descpnl.Controls.Add(this.progresspc);
            this.descpnl.Controls.Add(this.dldpic);
            this.descpnl.Controls.Add(this.dp);
            this.descpnl.Controls.Add(this.idlbl);
            this.descpnl.Controls.Add(this.productlbl);
            this.descpnl.Controls.Add(this.updatebtn);
            this.descpnl.Controls.Add(this.desctxtbox);
            this.descpnl.Controls.Add(this.label7);
            this.descpnl.Location = new System.Drawing.Point(3, 459);
            this.descpnl.Name = "descpnl";
            this.descpnl.Size = new System.Drawing.Size(883, 203);
            this.descpnl.TabIndex = 42;
            this.descpnl.Visible = false;
            // 
            // dp
            // 
            this.dp.Location = new System.Drawing.Point(9, 90);
            this.dp.Name = "dp";
            this.dp.Size = new System.Drawing.Size(103, 110);
            this.dp.TabIndex = 39;
            this.dp.TabStop = false;
            // 
            // bgworker
            // 
            this.bgworker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgworker_DoWork);
            this.bgworker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgworker_RunWorkerCompleted);
            // 
            // pbar
            // 
            this.pbar.Location = new System.Drawing.Point(892, 487);
            this.pbar.Name = "pbar";
            this.pbar.Size = new System.Drawing.Size(135, 10);
            this.pbar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbar.TabIndex = 43;
            this.pbar.Visible = false;
            // 
            // refreshlbl
            // 
            this.refreshlbl.AutoSize = true;
            this.refreshlbl.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshlbl.Location = new System.Drawing.Point(920, 464);
            this.refreshlbl.Name = "refreshlbl";
            this.refreshlbl.Size = new System.Drawing.Size(79, 20);
            this.refreshlbl.TabIndex = 44;
            this.refreshlbl.Text = "Refreshing";
            this.refreshlbl.Visible = false;
            // 
            // invpnl
            // 
            this.invpnl.Controls.Add(this.spnl);
            this.invpnl.Controls.Add(this.ipnl);
            this.invpnl.Controls.Add(this.refreshlbl);
            this.invpnl.Controls.Add(this.upbtn);
            this.invpnl.Controls.Add(this.pbar);
            this.invpnl.Controls.Add(this.descpnl);
            this.invpnl.Location = new System.Drawing.Point(1, -1);
            this.invpnl.Name = "invpnl";
            this.invpnl.Size = new System.Drawing.Size(1159, 662);
            this.invpnl.TabIndex = 45;
            this.invpnl.Visible = false;
            // 
            // spnl
            // 
            this.spnl.BackColor = System.Drawing.Color.LightYellow;
            this.spnl.Controls.Add(this.searchlbl);
            this.spnl.Controls.Add(this.searchtxt);
            this.spnl.Controls.Add(this.plbl);
            this.spnl.Controls.Add(this.pidtxt);
            this.spnl.Controls.Add(this.loadinglbl);
            this.spnl.Controls.Add(this.catsuplbl);
            this.spnl.Controls.Add(this.catidtxt);
            this.spnl.Controls.Add(this.allinvbtn);
            this.spnl.Controls.Add(this.clearbtn);
            this.spnl.Controls.Add(this.listbtn);
            this.spnl.Controls.Add(this.suplbl);
            this.spnl.Controls.Add(this.thirdlbl);
            this.spnl.Controls.Add(this.seclbl);
            this.spnl.Controls.Add(this.supbox);
            this.spnl.Controls.Add(this.thirdbox);
            this.spnl.Controls.Add(this.secbox);
            this.spnl.Location = new System.Drawing.Point(3, 7);
            this.spnl.Name = "spnl";
            this.spnl.Size = new System.Drawing.Size(1152, 57);
            this.spnl.TabIndex = 45;
            this.spnl.Visible = false;
            // 
            // searchlbl
            // 
            this.searchlbl.AutoSize = true;
            this.searchlbl.Location = new System.Drawing.Point(716, 1);
            this.searchlbl.Name = "searchlbl";
            this.searchlbl.Size = new System.Drawing.Size(80, 13);
            this.searchlbl.TabIndex = 51;
            this.searchlbl.Text = "Search product";
            // 
            // searchtxt
            // 
            this.searchtxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.searchtxt.Location = new System.Drawing.Point(719, 21);
            this.searchtxt.Name = "searchtxt";
            this.searchtxt.Size = new System.Drawing.Size(140, 20);
            this.searchtxt.TabIndex = 50;
            this.searchtxt.TextChanged += new System.EventHandler(this.searchtxt_TextChanged);
            // 
            // plbl
            // 
            this.plbl.AutoSize = true;
            this.plbl.Location = new System.Drawing.Point(641, 1);
            this.plbl.Name = "plbl";
            this.plbl.Size = new System.Drawing.Size(58, 13);
            this.plbl.TabIndex = 49;
            this.plbl.Text = "Product ID";
            // 
            // pidtxt
            // 
            this.pidtxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pidtxt.Location = new System.Drawing.Point(644, 21);
            this.pidtxt.Name = "pidtxt";
            this.pidtxt.Size = new System.Drawing.Size(69, 20);
            this.pidtxt.TabIndex = 48;
            this.pidtxt.TextChanged += new System.EventHandler(this.pidtxt_TextChanged);
            // 
            // loadinglbl
            // 
            this.loadinglbl.AutoSize = true;
            this.loadinglbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadinglbl.ForeColor = System.Drawing.Color.Red;
            this.loadinglbl.Location = new System.Drawing.Point(864, 41);
            this.loadinglbl.Name = "loadinglbl";
            this.loadinglbl.Size = new System.Drawing.Size(54, 13);
            this.loadinglbl.TabIndex = 47;
            this.loadinglbl.Text = "Loading...";
            this.loadinglbl.Visible = false;
            // 
            // catsuplbl
            // 
            this.catsuplbl.AutoSize = true;
            this.catsuplbl.Location = new System.Drawing.Point(568, 1);
            this.catsuplbl.Name = "catsuplbl";
            this.catsuplbl.Size = new System.Drawing.Size(61, 13);
            this.catsuplbl.TabIndex = 46;
            this.catsuplbl.Text = "Cat/Sup ID";
            // 
            // catidtxt
            // 
            this.catidtxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.catidtxt.Location = new System.Drawing.Point(571, 21);
            this.catidtxt.Name = "catidtxt";
            this.catidtxt.Size = new System.Drawing.Size(69, 20);
            this.catidtxt.TabIndex = 45;
            this.catidtxt.TextChanged += new System.EventHandler(this.catidtxt_TextChanged_1);
            // 
            // allinvbtn
            // 
            this.allinvbtn.Location = new System.Drawing.Point(1077, 7);
            this.allinvbtn.Name = "allinvbtn";
            this.allinvbtn.Size = new System.Drawing.Size(72, 36);
            this.allinvbtn.TabIndex = 44;
            this.allinvbtn.Text = "Download all inventory";
            this.allinvbtn.UseVisualStyleBackColor = true;
            this.allinvbtn.Click += new System.EventHandler(this.allinvbtn_Click);
            // 
            // clearbtn
            // 
            this.clearbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clearbtn.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.clearbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearbtn.Location = new System.Drawing.Point(960, 10);
            this.clearbtn.Name = "clearbtn";
            this.clearbtn.Size = new System.Drawing.Size(89, 31);
            this.clearbtn.TabIndex = 42;
            this.clearbtn.Text = "Clear";
            this.clearbtn.UseVisualStyleBackColor = true;
            this.clearbtn.Click += new System.EventHandler(this.clearbtn_Click);
            // 
            // listbtn
            // 
            this.listbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listbtn.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.listbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.listbtn.Location = new System.Drawing.Point(867, 10);
            this.listbtn.Name = "listbtn";
            this.listbtn.Size = new System.Drawing.Size(87, 31);
            this.listbtn.TabIndex = 41;
            this.listbtn.Text = "List Products";
            this.listbtn.UseVisualStyleBackColor = true;
            this.listbtn.Click += new System.EventHandler(this.listbtn_Click);
            // 
            // suplbl
            // 
            this.suplbl.AutoSize = true;
            this.suplbl.Location = new System.Drawing.Point(391, 1);
            this.suplbl.Name = "suplbl";
            this.suplbl.Size = new System.Drawing.Size(45, 13);
            this.suplbl.TabIndex = 31;
            this.suplbl.Text = "Supplier";
            // 
            // thirdlbl
            // 
            this.thirdlbl.AutoSize = true;
            this.thirdlbl.Location = new System.Drawing.Point(206, 1);
            this.thirdlbl.Name = "thirdlbl";
            this.thirdlbl.Size = new System.Drawing.Size(75, 13);
            this.thirdlbl.TabIndex = 29;
            this.thirdlbl.Text = "Third category";
            // 
            // seclbl
            // 
            this.seclbl.AutoSize = true;
            this.seclbl.Location = new System.Drawing.Point(2, 1);
            this.seclbl.Name = "seclbl";
            this.seclbl.Size = new System.Drawing.Size(88, 13);
            this.seclbl.TabIndex = 27;
            this.seclbl.Text = "Second category";
            // 
            // supbox
            // 
            this.supbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.supbox.FormattingEnabled = true;
            this.supbox.Location = new System.Drawing.Point(394, 20);
            this.supbox.Name = "supbox";
            this.supbox.Size = new System.Drawing.Size(162, 21);
            this.supbox.TabIndex = 2;
            this.supbox.SelectedIndexChanged += new System.EventHandler(this.supbox_SelectedIndexChanged);
            // 
            // thirdbox
            // 
            this.thirdbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.thirdbox.FormattingEnabled = true;
            this.thirdbox.Location = new System.Drawing.Point(209, 20);
            this.thirdbox.Name = "thirdbox";
            this.thirdbox.Size = new System.Drawing.Size(181, 21);
            this.thirdbox.TabIndex = 1;
            this.thirdbox.SelectedIndexChanged += new System.EventHandler(this.thirdbox_SelectedIndexChanged);
            // 
            // secbox
            // 
            this.secbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.secbox.FormattingEnabled = true;
            this.secbox.Location = new System.Drawing.Point(5, 20);
            this.secbox.Name = "secbox";
            this.secbox.Size = new System.Drawing.Size(200, 21);
            this.secbox.TabIndex = 0;
            this.secbox.SelectedIndexChanged += new System.EventHandler(this.secbox_SelectedIndexChanged);
            // 
            // dldpic
            // 
            this.dldpic.AutoSize = true;
            this.dldpic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dldpic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dldpic.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dldpic.Location = new System.Drawing.Point(114, 182);
            this.dldpic.Name = "dldpic";
            this.dldpic.Size = new System.Drawing.Size(55, 13);
            this.dldpic.TabIndex = 40;
            this.dldpic.Text = "Download";
            this.dldpic.Click += new System.EventHandler(this.dldpic_Click);
            // 
            // progresspc
            // 
            this.progresspc.AutoSize = true;
            this.progresspc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.progresspc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progresspc.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.progresspc.Location = new System.Drawing.Point(118, 155);
            this.progresspc.Name = "progresspc";
            this.progresspc.Size = new System.Drawing.Size(0, 13);
            this.progresspc.TabIndex = 41;
            this.progresspc.Visible = false;
            // 
            // inventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1162, 660);
            this.Controls.Add(this.invpnl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "inventory";
            this.Text = "research";
            ((System.ComponentModel.ISupportInitialize)(this.inventorydatagridview)).EndInit();
            this.ipnl.ResumeLayout(false);
            this.ipnl.PerformLayout();
            this.descpnl.ResumeLayout(false);
            this.descpnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dp)).EndInit();
            this.invpnl.ResumeLayout(false);
            this.invpnl.PerformLayout();
            this.spnl.ResumeLayout(false);
            this.spnl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView inventorydatagridview;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox supidtxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox pronametxt;
        private System.Windows.Forms.TextBox proidtxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox brandtxt;
        private System.Windows.Forms.Label productlbl;
        private System.Windows.Forms.Label idlbl;
        private System.Windows.Forms.TextBox desctxtbox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button updatebtn;
        private System.Windows.Forms.Button upbtn;
        private System.Windows.Forms.Panel ipnl;
        private System.Windows.Forms.Panel descpnl;
        private System.ComponentModel.BackgroundWorker bgworker;
        private System.Windows.Forms.TextBox cattxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar pbar;
        private System.Windows.Forms.Label refreshlbl;
        private System.Windows.Forms.Panel invpnl;
        private System.Windows.Forms.Panel spnl;
        private System.Windows.Forms.Button clearbtn;
        private System.Windows.Forms.Button listbtn;
        private System.Windows.Forms.Label suplbl;
        private System.Windows.Forms.Label thirdlbl;
        private System.Windows.Forms.Label seclbl;
        private System.Windows.Forms.ComboBox supbox;
        private System.Windows.Forms.ComboBox thirdbox;
        private System.Windows.Forms.ComboBox secbox;
        private System.Windows.Forms.Button allinvbtn;
        private System.Windows.Forms.Label catsuplbl;
        private System.Windows.Forms.TextBox catidtxt;
        private System.Windows.Forms.Label loadinglbl;
        private System.Windows.Forms.Label plbl;
        private System.Windows.Forms.TextBox pidtxt;
        private System.Windows.Forms.Label searchlbl;
        private System.Windows.Forms.TextBox searchtxt;
        private System.Windows.Forms.PictureBox dp;
        private System.Windows.Forms.Label dldpic;
        private System.Windows.Forms.Label progresspc;
    }
}