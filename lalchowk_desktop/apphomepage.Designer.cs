namespace Veiled_Kashmir_Admin_Panel
{
    partial class apphomepage
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
            this.formlbl = new System.Windows.Forms.Label();
            this.bgworker = new System.ComponentModel.BackgroundWorker();
            this.label11 = new System.Windows.Forms.Label();
            this.p2pic = new System.Windows.Forms.TextBox();
            this.p3 = new System.Windows.Forms.PictureBox();
            this.p1pic = new System.Windows.Forms.TextBox();
            this.p4 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.p3title = new System.Windows.Forms.TextBox();
            this.p2sub = new System.Windows.Forms.TextBox();
            this.p4title = new System.Windows.Forms.TextBox();
            this.p1sub = new System.Windows.Forms.TextBox();
            this.p3link = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.p4link = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.p2link = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.p1link = new System.Windows.Forms.TextBox();
            this.p3sub = new System.Windows.Forms.TextBox();
            this.p2title = new System.Windows.Forms.TextBox();
            this.p4sub = new System.Windows.Forms.TextBox();
            this.p1title = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.p2 = new System.Windows.Forms.PictureBox();
            this.p3pic = new System.Windows.Forms.TextBox();
            this.p1 = new System.Windows.Forms.PictureBox();
            this.p4pic = new System.Windows.Forms.TextBox();
            this.fcattxt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.itemsdataview = new System.Windows.Forms.DataGridView();
            this.updbbtn = new System.Windows.Forms.Button();
            this.productsdataview = new System.Windows.Forms.DataGridView();
            this.upd4btn = new System.Windows.Forms.Button();
            this.upddpbtn = new System.Windows.Forms.Button();
            this.u1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.u2 = new System.Windows.Forms.Label();
            this.rightlink = new System.Windows.Forms.TextBox();
            this.u3 = new System.Windows.Forms.Label();
            this.leftlink = new System.Windows.Forms.TextBox();
            this.u4 = new System.Windows.Forms.Label();
            this.righttxt = new System.Windows.Forms.TextBox();
            this.offersdataview = new System.Windows.Forms.DataGridView();
            this.lefttxt = new System.Windows.Forms.TextBox();
            this.updoffers = new System.Windows.Forms.Button();
            this.rightpic = new System.Windows.Forms.PictureBox();
            this.leftpic = new System.Windows.Forms.PictureBox();
            this.ppic = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.randbtn = new System.Windows.Forms.Button();
            this.randlist = new System.Windows.Forms.Button();
            this.idtxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.upofferbtn = new System.Windows.Forms.Button();
            this.opictxt = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.hpnl = new System.Windows.Forms.Panel();
            this.rcat2 = new System.Windows.Forms.TextBox();
            this.rcat1 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.cat2btn = new System.Windows.Forms.Button();
            this.cat1btn = new System.Windows.Forms.Button();
            this.catbtn = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cat1txt = new System.Windows.Forms.TextBox();
            this.cat2txt = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.p3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsdataview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsdataview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.offersdataview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightpic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftpic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ppic)).BeginInit();
            this.hpnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // formlbl
            // 
            this.formlbl.AutoSize = true;
            this.formlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formlbl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.formlbl.Location = new System.Drawing.Point(-1, -1);
            this.formlbl.Name = "formlbl";
            this.formlbl.Size = new System.Drawing.Size(131, 24);
            this.formlbl.TabIndex = 0;
            this.formlbl.Text = "Change Offers";
            // 
            // bgworker
            // 
            this.bgworker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgworker_DoWork);
            this.bgworker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgworker_RunWorkerCompleted);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(439, 402);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 76;
            this.label11.Text = "Picture";
            // 
            // p2pic
            // 
            this.p2pic.Location = new System.Drawing.Point(596, 399);
            this.p2pic.Name = "p2pic";
            this.p2pic.Size = new System.Drawing.Size(108, 20);
            this.p2pic.TabIndex = 75;
            this.p2pic.TextChanged += new System.EventHandler(this.p2pic_TextChanged);
            // 
            // p3
            // 
            this.p3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.p3.Location = new System.Drawing.Point(484, 451);
            this.p3.Name = "p3";
            this.p3.Size = new System.Drawing.Size(106, 97);
            this.p3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p3.TabIndex = 77;
            this.p3.TabStop = false;
            // 
            // p1pic
            // 
            this.p1pic.Location = new System.Drawing.Point(484, 399);
            this.p1pic.Name = "p1pic";
            this.p1pic.Size = new System.Drawing.Size(106, 20);
            this.p1pic.TabIndex = 74;
            this.p1pic.TextChanged += new System.EventHandler(this.p1pic_TextChanged);
            // 
            // p4
            // 
            this.p4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.p4.Location = new System.Drawing.Point(596, 451);
            this.p4.Name = "p4";
            this.p4.Size = new System.Drawing.Size(108, 97);
            this.p4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p4.TabIndex = 78;
            this.p4.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(439, 378);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 73;
            this.label10.Text = "Subtitle";
            // 
            // p3title
            // 
            this.p3title.Location = new System.Drawing.Point(484, 554);
            this.p3title.Name = "p3title";
            this.p3title.Size = new System.Drawing.Size(106, 20);
            this.p3title.TabIndex = 79;
            // 
            // p2sub
            // 
            this.p2sub.Location = new System.Drawing.Point(596, 375);
            this.p2sub.Name = "p2sub";
            this.p2sub.Size = new System.Drawing.Size(108, 20);
            this.p2sub.TabIndex = 72;
            // 
            // p4title
            // 
            this.p4title.Location = new System.Drawing.Point(596, 554);
            this.p4title.Name = "p4title";
            this.p4title.Size = new System.Drawing.Size(108, 20);
            this.p4title.TabIndex = 80;
            // 
            // p1sub
            // 
            this.p1sub.Location = new System.Drawing.Point(484, 375);
            this.p1sub.Name = "p1sub";
            this.p1sub.Size = new System.Drawing.Size(106, 20);
            this.p1sub.TabIndex = 71;
            // 
            // p3link
            // 
            this.p3link.Location = new System.Drawing.Point(530, 629);
            this.p3link.Name = "p3link";
            this.p3link.Size = new System.Drawing.Size(60, 20);
            this.p3link.TabIndex = 81;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(439, 351);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 17);
            this.label9.TabIndex = 70;
            this.label9.Text = "Title";
            // 
            // p4link
            // 
            this.p4link.Location = new System.Drawing.Point(596, 629);
            this.p4link.Name = "p4link";
            this.p4link.Size = new System.Drawing.Size(61, 20);
            this.p4link.TabIndex = 82;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(492, 426);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 17);
            this.label7.TabIndex = 62;
            this.label7.Text = "Link";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(492, 630);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(34, 17);
            this.label14.TabIndex = 83;
            this.label14.Text = "Link";
            // 
            // p2link
            // 
            this.p2link.Location = new System.Drawing.Point(596, 425);
            this.p2link.Name = "p2link";
            this.p2link.Size = new System.Drawing.Size(61, 20);
            this.p2link.TabIndex = 61;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(439, 555);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 17);
            this.label13.TabIndex = 84;
            this.label13.Text = "Title";
            // 
            // p1link
            // 
            this.p1link.Location = new System.Drawing.Point(530, 425);
            this.p1link.Name = "p1link";
            this.p1link.Size = new System.Drawing.Size(60, 20);
            this.p1link.TabIndex = 60;
            // 
            // p3sub
            // 
            this.p3sub.Location = new System.Drawing.Point(484, 579);
            this.p3sub.Name = "p3sub";
            this.p3sub.Size = new System.Drawing.Size(106, 20);
            this.p3sub.TabIndex = 85;
            // 
            // p2title
            // 
            this.p2title.Location = new System.Drawing.Point(596, 350);
            this.p2title.Name = "p2title";
            this.p2title.Size = new System.Drawing.Size(108, 20);
            this.p2title.TabIndex = 59;
            // 
            // p4sub
            // 
            this.p4sub.Location = new System.Drawing.Point(596, 579);
            this.p4sub.Name = "p4sub";
            this.p4sub.Size = new System.Drawing.Size(108, 20);
            this.p4sub.TabIndex = 86;
            // 
            // p1title
            // 
            this.p1title.Location = new System.Drawing.Point(484, 350);
            this.p1title.Name = "p1title";
            this.p1title.Size = new System.Drawing.Size(106, 20);
            this.p1title.TabIndex = 58;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(439, 582);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 13);
            this.label12.TabIndex = 87;
            this.label12.Text = "Subtitle";
            // 
            // p2
            // 
            this.p2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.p2.Location = new System.Drawing.Point(596, 244);
            this.p2.Name = "p2";
            this.p2.Size = new System.Drawing.Size(108, 100);
            this.p2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p2.TabIndex = 57;
            this.p2.TabStop = false;
            // 
            // p3pic
            // 
            this.p3pic.Location = new System.Drawing.Point(484, 603);
            this.p3pic.Name = "p3pic";
            this.p3pic.Size = new System.Drawing.Size(106, 20);
            this.p3pic.TabIndex = 88;
            this.p3pic.TextChanged += new System.EventHandler(this.p3pic_TextChanged);
            // 
            // p1
            // 
            this.p1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.p1.Location = new System.Drawing.Point(484, 244);
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(106, 100);
            this.p1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p1.TabIndex = 56;
            this.p1.TabStop = false;
            // 
            // p4pic
            // 
            this.p4pic.Location = new System.Drawing.Point(596, 603);
            this.p4pic.Name = "p4pic";
            this.p4pic.Size = new System.Drawing.Size(108, 20);
            this.p4pic.TabIndex = 89;
            this.p4pic.TextChanged += new System.EventHandler(this.p4pic_TextChanged);
            // 
            // fcattxt
            // 
            this.fcattxt.Location = new System.Drawing.Point(821, 218);
            this.fcattxt.Name = "fcattxt";
            this.fcattxt.Size = new System.Drawing.Size(135, 20);
            this.fcattxt.TabIndex = 55;
            this.fcattxt.TextChanged += new System.EventHandler(this.fcattxt_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(439, 606);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 90;
            this.label8.Text = "Picture";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(722, 219);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 17);
            this.label6.TabIndex = 54;
            this.label6.Text = "Filter by Name";
            // 
            // itemsdataview
            // 
            this.itemsdataview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.itemsdataview.BackgroundColor = System.Drawing.Color.White;
            this.itemsdataview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.itemsdataview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemsdataview.Location = new System.Drawing.Point(3, 344);
            this.itemsdataview.Name = "itemsdataview";
            this.itemsdataview.Size = new System.Drawing.Size(405, 166);
            this.itemsdataview.TabIndex = 91;
            // 
            // updbbtn
            // 
            this.updbbtn.Location = new System.Drawing.Point(281, 521);
            this.updbbtn.Name = "updbbtn";
            this.updbbtn.Size = new System.Drawing.Size(127, 25);
            this.updbbtn.TabIndex = 92;
            this.updbbtn.Text = "Update individual";
            this.updbbtn.UseVisualStyleBackColor = true;
            this.updbbtn.Click += new System.EventHandler(this.updbbtn_Click);
            // 
            // productsdataview
            // 
            this.productsdataview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.productsdataview.BackgroundColor = System.Drawing.Color.White;
            this.productsdataview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productsdataview.Location = new System.Drawing.Point(725, 244);
            this.productsdataview.Name = "productsdataview";
            this.productsdataview.Size = new System.Drawing.Size(424, 441);
            this.productsdataview.TabIndex = 52;
            this.productsdataview.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.productsdataview_CellClick);
            // 
            // upd4btn
            // 
            this.upd4btn.Location = new System.Drawing.Point(474, 660);
            this.upd4btn.Name = "upd4btn";
            this.upd4btn.Size = new System.Drawing.Size(230, 25);
            this.upd4btn.TabIndex = 93;
            this.upd4btn.Text = "Update All 4 Products";
            this.upd4btn.UseVisualStyleBackColor = true;
            this.upd4btn.Click += new System.EventHandler(this.upd4btn_Click);
            // 
            // upddpbtn
            // 
            this.upddpbtn.Location = new System.Drawing.Point(26, 251);
            this.upddpbtn.Name = "upddpbtn";
            this.upddpbtn.Size = new System.Drawing.Size(230, 25);
            this.upddpbtn.TabIndex = 51;
            this.upddpbtn.Text = "Update/Upload Display Images";
            this.upddpbtn.UseVisualStyleBackColor = true;
            this.upddpbtn.Click += new System.EventHandler(this.upddpbtn_Click);
            // 
            // u1
            // 
            this.u1.AutoSize = true;
            this.u1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.u1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.u1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.u1.Location = new System.Drawing.Point(445, 429);
            this.u1.Name = "u1";
            this.u1.Size = new System.Drawing.Size(41, 13);
            this.u1.TabIndex = 94;
            this.u1.Text = "Update";
            this.u1.Click += new System.EventHandler(this.u1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(31, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 17);
            this.label4.TabIndex = 50;
            this.label4.Text = "Left";
            // 
            // u2
            // 
            this.u2.AutoSize = true;
            this.u2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.u2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.u2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.u2.Location = new System.Drawing.Point(666, 429);
            this.u2.Name = "u2";
            this.u2.Size = new System.Drawing.Size(41, 13);
            this.u2.TabIndex = 95;
            this.u2.Text = "Update";
            this.u2.Click += new System.EventHandler(this.u2_Click);
            // 
            // rightlink
            // 
            this.rightlink.Location = new System.Drawing.Point(78, 225);
            this.rightlink.Name = "rightlink";
            this.rightlink.Size = new System.Drawing.Size(178, 20);
            this.rightlink.TabIndex = 49;
            // 
            // u3
            // 
            this.u3.AutoSize = true;
            this.u3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.u3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.u3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.u3.Location = new System.Drawing.Point(445, 634);
            this.u3.Name = "u3";
            this.u3.Size = new System.Drawing.Size(41, 13);
            this.u3.TabIndex = 96;
            this.u3.Text = "Update";
            this.u3.Click += new System.EventHandler(this.u3_Click);
            // 
            // leftlink
            // 
            this.leftlink.Location = new System.Drawing.Point(78, 201);
            this.leftlink.Name = "leftlink";
            this.leftlink.Size = new System.Drawing.Size(178, 20);
            this.leftlink.TabIndex = 48;
            // 
            // u4
            // 
            this.u4.AutoSize = true;
            this.u4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.u4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.u4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.u4.Location = new System.Drawing.Point(666, 634);
            this.u4.Name = "u4";
            this.u4.Size = new System.Drawing.Size(41, 13);
            this.u4.TabIndex = 97;
            this.u4.Text = "Update";
            this.u4.Click += new System.EventHandler(this.u4_Click);
            // 
            // righttxt
            // 
            this.righttxt.Location = new System.Drawing.Point(144, 175);
            this.righttxt.Name = "righttxt";
            this.righttxt.Size = new System.Drawing.Size(112, 20);
            this.righttxt.TabIndex = 45;
            this.righttxt.TextChanged += new System.EventHandler(this.righttxt_TextChanged);
            // 
            // offersdataview
            // 
            this.offersdataview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.offersdataview.BackgroundColor = System.Drawing.Color.White;
            this.offersdataview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.offersdataview.Location = new System.Drawing.Point(356, 27);
            this.offersdataview.Name = "offersdataview";
            this.offersdataview.Size = new System.Drawing.Size(413, 166);
            this.offersdataview.TabIndex = 98;
            this.offersdataview.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.offersdataview_CellClick);
            // 
            // lefttxt
            // 
            this.lefttxt.Location = new System.Drawing.Point(26, 175);
            this.lefttxt.Name = "lefttxt";
            this.lefttxt.Size = new System.Drawing.Size(112, 20);
            this.lefttxt.TabIndex = 44;
            this.lefttxt.TextChanged += new System.EventHandler(this.lefttxt_TextChanged);
            // 
            // updoffers
            // 
            this.updoffers.Location = new System.Drawing.Point(775, 131);
            this.updoffers.Name = "updoffers";
            this.updoffers.Size = new System.Drawing.Size(75, 62);
            this.updoffers.TabIndex = 99;
            this.updoffers.Text = "Update Offers";
            this.updoffers.UseVisualStyleBackColor = true;
            this.updoffers.Click += new System.EventHandler(this.updoffers_Click);
            // 
            // rightpic
            // 
            this.rightpic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rightpic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rightpic.Location = new System.Drawing.Point(140, 56);
            this.rightpic.Name = "rightpic";
            this.rightpic.Size = new System.Drawing.Size(112, 112);
            this.rightpic.TabIndex = 43;
            this.rightpic.TabStop = false;
            this.rightpic.Click += new System.EventHandler(this.rightpic_Click);
            // 
            // leftpic
            // 
            this.leftpic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.leftpic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.leftpic.Location = new System.Drawing.Point(29, 56);
            this.leftpic.Name = "leftpic";
            this.leftpic.Size = new System.Drawing.Size(112, 112);
            this.leftpic.TabIndex = 42;
            this.leftpic.TabStop = false;
            this.leftpic.Click += new System.EventHandler(this.leftpic_Click);
            // 
            // ppic
            // 
            this.ppic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ppic.Location = new System.Drawing.Point(993, 27);
            this.ppic.Name = "ppic";
            this.ppic.Size = new System.Drawing.Size(156, 167);
            this.ppic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ppic.TabIndex = 101;
            this.ppic.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Silver;
            this.panel3.Location = new System.Drawing.Point(356, 207);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(650, 1);
            this.panel3.TabIndex = 41;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Location = new System.Drawing.Point(355, 207);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 80);
            this.panel1.TabIndex = 102;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(31, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Change Homepage Picture";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(484, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 18);
            this.label3.TabIndex = 103;
            this.label3.Text = "Featured Items";
            // 
            // randbtn
            // 
            this.randbtn.Location = new System.Drawing.Point(633, 221);
            this.randbtn.Name = "randbtn";
            this.randbtn.Size = new System.Drawing.Size(71, 19);
            this.randbtn.TabIndex = 104;
            this.randbtn.Text = "Randomize";
            this.randbtn.UseVisualStyleBackColor = true;
            this.randbtn.Click += new System.EventHandler(this.randbtn_Click);
            // 
            // randlist
            // 
            this.randlist.Location = new System.Drawing.Point(4, 521);
            this.randlist.Name = "randlist";
            this.randlist.Size = new System.Drawing.Size(82, 25);
            this.randlist.TabIndex = 105;
            this.randlist.Text = "Randomize";
            this.randlist.UseVisualStyleBackColor = true;
            this.randlist.Click += new System.EventHandler(this.randlist_Click);
            // 
            // idtxt
            // 
            this.idtxt.Location = new System.Drawing.Point(1087, 218);
            this.idtxt.Name = "idtxt";
            this.idtxt.Size = new System.Drawing.Size(62, 20);
            this.idtxt.TabIndex = 107;
            this.idtxt.TextChanged += new System.EventHandler(this.idtxt_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(962, 218);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 17);
            this.label1.TabIndex = 106;
            this.label1.Text = "Filter by Category";
            // 
            // upofferbtn
            // 
            this.upofferbtn.Location = new System.Drawing.Point(775, 53);
            this.upofferbtn.Name = "upofferbtn";
            this.upofferbtn.Size = new System.Drawing.Size(156, 23);
            this.upofferbtn.TabIndex = 112;
            this.upofferbtn.Text = "Upload Picture";
            this.upofferbtn.UseVisualStyleBackColor = true;
            this.upofferbtn.Click += new System.EventHandler(this.upofferbtn_Click);
            // 
            // opictxt
            // 
            this.opictxt.Location = new System.Drawing.Point(775, 27);
            this.opictxt.Name = "opictxt";
            this.opictxt.ReadOnly = true;
            this.opictxt.Size = new System.Drawing.Size(156, 20);
            this.opictxt.TabIndex = 113;
            this.opictxt.Click += new System.EventHandler(this.opictxt_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(31, 228);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 17);
            this.label16.TabIndex = 114;
            this.label16.Text = "Right";
            // 
            // hpnl
            // 
            this.hpnl.Controls.Add(this.rcat2);
            this.hpnl.Controls.Add(this.rcat1);
            this.hpnl.Controls.Add(this.label18);
            this.hpnl.Controls.Add(this.cat2btn);
            this.hpnl.Controls.Add(this.cat1btn);
            this.hpnl.Controls.Add(this.catbtn);
            this.hpnl.Controls.Add(this.label17);
            this.hpnl.Controls.Add(this.label5);
            this.hpnl.Controls.Add(this.cat1txt);
            this.hpnl.Controls.Add(this.cat2txt);
            this.hpnl.Controls.Add(this.label15);
            this.hpnl.Controls.Add(this.label16);
            this.hpnl.Controls.Add(this.opictxt);
            this.hpnl.Controls.Add(this.upofferbtn);
            this.hpnl.Controls.Add(this.label1);
            this.hpnl.Controls.Add(this.idtxt);
            this.hpnl.Controls.Add(this.randlist);
            this.hpnl.Controls.Add(this.randbtn);
            this.hpnl.Controls.Add(this.label3);
            this.hpnl.Controls.Add(this.label2);
            this.hpnl.Controls.Add(this.panel1);
            this.hpnl.Controls.Add(this.panel3);
            this.hpnl.Controls.Add(this.ppic);
            this.hpnl.Controls.Add(this.leftpic);
            this.hpnl.Controls.Add(this.rightpic);
            this.hpnl.Controls.Add(this.updoffers);
            this.hpnl.Controls.Add(this.lefttxt);
            this.hpnl.Controls.Add(this.offersdataview);
            this.hpnl.Controls.Add(this.righttxt);
            this.hpnl.Controls.Add(this.u4);
            this.hpnl.Controls.Add(this.leftlink);
            this.hpnl.Controls.Add(this.u3);
            this.hpnl.Controls.Add(this.rightlink);
            this.hpnl.Controls.Add(this.u2);
            this.hpnl.Controls.Add(this.label4);
            this.hpnl.Controls.Add(this.u1);
            this.hpnl.Controls.Add(this.upddpbtn);
            this.hpnl.Controls.Add(this.upd4btn);
            this.hpnl.Controls.Add(this.productsdataview);
            this.hpnl.Controls.Add(this.updbbtn);
            this.hpnl.Controls.Add(this.itemsdataview);
            this.hpnl.Controls.Add(this.label6);
            this.hpnl.Controls.Add(this.label8);
            this.hpnl.Controls.Add(this.fcattxt);
            this.hpnl.Controls.Add(this.p4pic);
            this.hpnl.Controls.Add(this.p1);
            this.hpnl.Controls.Add(this.p3pic);
            this.hpnl.Controls.Add(this.p2);
            this.hpnl.Controls.Add(this.label12);
            this.hpnl.Controls.Add(this.p1title);
            this.hpnl.Controls.Add(this.p4sub);
            this.hpnl.Controls.Add(this.p2title);
            this.hpnl.Controls.Add(this.p3sub);
            this.hpnl.Controls.Add(this.p1link);
            this.hpnl.Controls.Add(this.label13);
            this.hpnl.Controls.Add(this.p2link);
            this.hpnl.Controls.Add(this.label14);
            this.hpnl.Controls.Add(this.label7);
            this.hpnl.Controls.Add(this.p4link);
            this.hpnl.Controls.Add(this.label9);
            this.hpnl.Controls.Add(this.p3link);
            this.hpnl.Controls.Add(this.p1sub);
            this.hpnl.Controls.Add(this.p4title);
            this.hpnl.Controls.Add(this.p2sub);
            this.hpnl.Controls.Add(this.p3title);
            this.hpnl.Controls.Add(this.label10);
            this.hpnl.Controls.Add(this.p4);
            this.hpnl.Controls.Add(this.p1pic);
            this.hpnl.Controls.Add(this.p3);
            this.hpnl.Controls.Add(this.p2pic);
            this.hpnl.Controls.Add(this.label11);
            this.hpnl.Location = new System.Drawing.Point(0, 1);
            this.hpnl.Name = "hpnl";
            this.hpnl.Size = new System.Drawing.Size(1158, 687);
            this.hpnl.TabIndex = 104;
            this.hpnl.Visible = false;
            // 
            // rcat2
            // 
            this.rcat2.Location = new System.Drawing.Point(100, 661);
            this.rcat2.Name = "rcat2";
            this.rcat2.Size = new System.Drawing.Size(60, 20);
            this.rcat2.TabIndex = 125;
            // 
            // rcat1
            // 
            this.rcat1.Location = new System.Drawing.Point(100, 633);
            this.rcat1.Name = "rcat1";
            this.rcat1.Size = new System.Drawing.Size(60, 20);
            this.rcat1.TabIndex = 124;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label18.Location = new System.Drawing.Point(17, 641);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(79, 17);
            this.label18.TabIndex = 123;
            this.label18.Text = "Randomize";
            // 
            // cat2btn
            // 
            this.cat2btn.Location = new System.Drawing.Point(160, 659);
            this.cat2btn.Name = "cat2btn";
            this.cat2btn.Size = new System.Drawing.Size(82, 25);
            this.cat2btn.TabIndex = 122;
            this.cat2btn.Text = "Category2";
            this.cat2btn.UseVisualStyleBackColor = true;
            this.cat2btn.Click += new System.EventHandler(this.cat2btn_Click);
            // 
            // cat1btn
            // 
            this.cat1btn.Location = new System.Drawing.Point(160, 630);
            this.cat1btn.Name = "cat1btn";
            this.cat1btn.Size = new System.Drawing.Size(82, 25);
            this.cat1btn.TabIndex = 121;
            this.cat1btn.Text = "Category1";
            this.cat1btn.UseVisualStyleBackColor = true;
            this.cat1btn.Click += new System.EventHandler(this.cat1btn_Click);
            // 
            // catbtn
            // 
            this.catbtn.Location = new System.Drawing.Point(327, 622);
            this.catbtn.Name = "catbtn";
            this.catbtn.Size = new System.Drawing.Size(81, 25);
            this.catbtn.TabIndex = 120;
            this.catbtn.Text = "Update Links";
            this.catbtn.UseVisualStyleBackColor = true;
            this.catbtn.Click += new System.EventHandler(this.catbtn_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label17.Location = new System.Drawing.Point(22, 317);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(156, 24);
            this.label17.TabIndex = 119;
            this.label17.Text = "Change Products";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(17, 600);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 17);
            this.label5.TabIndex = 118;
            this.label5.Text = "Category 2";
            // 
            // cat1txt
            // 
            this.cat1txt.Location = new System.Drawing.Point(100, 573);
            this.cat1txt.Name = "cat1txt";
            this.cat1txt.Size = new System.Drawing.Size(308, 20);
            this.cat1txt.TabIndex = 115;
            // 
            // cat2txt
            // 
            this.cat2txt.Location = new System.Drawing.Point(100, 597);
            this.cat2txt.Name = "cat2txt";
            this.cat2txt.Size = new System.Drawing.Size(308, 20);
            this.cat2txt.TabIndex = 116;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(17, 574);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 17);
            this.label15.TabIndex = 117;
            this.label15.Text = "Category 1";
            // 
            // apphomepage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1162, 693);
            this.Controls.Add(this.hpnl);
            this.Controls.Add(this.formlbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "apphomepage";
            this.Text = "apphomepage";
            ((System.ComponentModel.ISupportInitialize)(this.p3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsdataview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsdataview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.offersdataview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightpic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftpic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ppic)).EndInit();
            this.hpnl.ResumeLayout(false);
            this.hpnl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label formlbl;
        private System.ComponentModel.BackgroundWorker bgworker;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox p2pic;
        private System.Windows.Forms.PictureBox p3;
        private System.Windows.Forms.TextBox p1pic;
        private System.Windows.Forms.PictureBox p4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox p3title;
        private System.Windows.Forms.TextBox p2sub;
        private System.Windows.Forms.TextBox p4title;
        private System.Windows.Forms.TextBox p1sub;
        private System.Windows.Forms.TextBox p3link;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox p4link;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox p2link;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox p1link;
        private System.Windows.Forms.TextBox p3sub;
        private System.Windows.Forms.TextBox p2title;
        private System.Windows.Forms.TextBox p4sub;
        private System.Windows.Forms.TextBox p1title;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox p2;
        private System.Windows.Forms.TextBox p3pic;
        private System.Windows.Forms.PictureBox p1;
        private System.Windows.Forms.TextBox p4pic;
        private System.Windows.Forms.TextBox fcattxt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView itemsdataview;
        private System.Windows.Forms.Button updbbtn;
        private System.Windows.Forms.DataGridView productsdataview;
        private System.Windows.Forms.Button upd4btn;
        private System.Windows.Forms.Button upddpbtn;
        private System.Windows.Forms.Label u1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label u2;
        private System.Windows.Forms.TextBox rightlink;
        private System.Windows.Forms.Label u3;
        private System.Windows.Forms.TextBox leftlink;
        private System.Windows.Forms.Label u4;
        private System.Windows.Forms.TextBox righttxt;
        private System.Windows.Forms.DataGridView offersdataview;
        private System.Windows.Forms.TextBox lefttxt;
        private System.Windows.Forms.Button updoffers;
        private System.Windows.Forms.PictureBox rightpic;
        private System.Windows.Forms.PictureBox leftpic;
        private System.Windows.Forms.PictureBox ppic;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button randbtn;
        private System.Windows.Forms.Button randlist;
        private System.Windows.Forms.TextBox idtxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button upofferbtn;
        private System.Windows.Forms.TextBox opictxt;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel hpnl;
        private System.Windows.Forms.TextBox rcat2;
        private System.Windows.Forms.TextBox rcat1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button cat2btn;
        private System.Windows.Forms.Button cat1btn;
        private System.Windows.Forms.Button catbtn;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox cat1txt;
        private System.Windows.Forms.TextBox cat2txt;
        private System.Windows.Forms.Label label15;
    }
}