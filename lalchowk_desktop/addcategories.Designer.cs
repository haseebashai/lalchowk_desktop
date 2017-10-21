namespace Veiled_Kashmir_Admin_Panel
{
    partial class addcategories
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
            this.bgworker = new System.ComponentModel.BackgroundWorker();
            this.formlbl = new System.Windows.Forms.Label();
            this.cpnl = new System.Windows.Forms.Panel();
            this.updbtn = new System.Windows.Forms.Button();
            this.epnl = new System.Windows.Forms.Panel();
            this.tcpnl = new System.Windows.Forms.Panel();
            this.stcidtxt = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tyes = new System.Windows.Forms.CheckBox();
            this.tpicaddbtn = new System.Windows.Forms.Button();
            this.tpictxt = new System.Windows.Forms.TextBox();
            this.tpic = new System.Windows.Forms.PictureBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tcaddbtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.label15 = new System.Windows.Forms.Label();
            this.tcnametxt = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tidtxt = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.fcpnl = new System.Windows.Forms.Panel();
            this.fidtxt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.fno = new System.Windows.Forms.CheckBox();
            this.fyes = new System.Windows.Forms.CheckBox();
            this.faddpicbtn = new System.Windows.Forms.Button();
            this.fpictxt = new System.Windows.Forms.TextBox();
            this.fpic = new System.Windows.Forms.PictureBox();
            this.label13 = new System.Windows.Forms.Label();
            this.faddbtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.label3 = new System.Windows.Forms.Label();
            this.fnametxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.fcidtxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.scpnl = new System.Windows.Forms.Panel();
            this.fscidtxt = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.sidtxt = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.sno = new System.Windows.Forms.CheckBox();
            this.syes = new System.Windows.Forms.CheckBox();
            this.spicbtn = new System.Windows.Forms.Button();
            this.spictxt = new System.Windows.Forms.TextBox();
            this.spic = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.addscbtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.label5 = new System.Windows.Forms.Label();
            this.scnametxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.scidtxt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.loadingaccpic = new System.Windows.Forms.PictureBox();
            this.loadinglbl = new System.Windows.Forms.Label();
            this.catdataview = new System.Windows.Forms.DataGridView();
            this.bpnl = new System.Windows.Forms.Panel();
            this.tcbtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.scbtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.fcbtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.bgworker2 = new System.ComponentModel.BackgroundWorker();
            this.bgworker3 = new System.ComponentModel.BackgroundWorker();
            this.picdialog = new System.Windows.Forms.OpenFileDialog();
            this.cpnl.SuspendLayout();
            this.epnl.SuspendLayout();
            this.tcpnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tpic)).BeginInit();
            this.fcpnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpic)).BeginInit();
            this.scpnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingaccpic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.catdataview)).BeginInit();
            this.bpnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // bgworker
            // 
            this.bgworker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgworker_DoWork);
            this.bgworker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgworker_RunWorkerCompleted);
            // 
            // formlbl
            // 
            this.formlbl.AutoSize = true;
            this.formlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formlbl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.formlbl.Location = new System.Drawing.Point(-2, -1);
            this.formlbl.Name = "formlbl";
            this.formlbl.Size = new System.Drawing.Size(107, 25);
            this.formlbl.TabIndex = 0;
            this.formlbl.Text = "Categories";
            // 
            // cpnl
            // 
            this.cpnl.Controls.Add(this.updbtn);
            this.cpnl.Controls.Add(this.epnl);
            this.cpnl.Controls.Add(this.loadingaccpic);
            this.cpnl.Controls.Add(this.loadinglbl);
            this.cpnl.Controls.Add(this.catdataview);
            this.cpnl.Controls.Add(this.bpnl);
            this.cpnl.Location = new System.Drawing.Point(2, 0);
            this.cpnl.Name = "cpnl";
            this.cpnl.Size = new System.Drawing.Size(1159, 722);
            this.cpnl.TabIndex = 1;
            // 
            // updbtn
            // 
            this.updbtn.Location = new System.Drawing.Point(1018, 382);
            this.updbtn.Name = "updbtn";
            this.updbtn.Size = new System.Drawing.Size(120, 112);
            this.updbtn.TabIndex = 52;
            this.updbtn.Text = "Update Entry";
            this.updbtn.UseVisualStyleBackColor = true;
            this.updbtn.Visible = false;
            this.updbtn.Click += new System.EventHandler(this.updbtn_Click);
            // 
            // epnl
            // 
            this.epnl.Controls.Add(this.fcpnl);
            this.epnl.Controls.Add(this.scpnl);
            this.epnl.Controls.Add(this.tcpnl);
            this.epnl.Location = new System.Drawing.Point(3, 55);
            this.epnl.Name = "epnl";
            this.epnl.Size = new System.Drawing.Size(1159, 177);
            this.epnl.TabIndex = 51;
            this.epnl.Visible = false;
            // 
            // tcpnl
            // 
            this.tcpnl.Controls.Add(this.stcidtxt);
            this.tcpnl.Controls.Add(this.label11);
            this.tcpnl.Controls.Add(this.tyes);
            this.tcpnl.Controls.Add(this.tpicaddbtn);
            this.tcpnl.Controls.Add(this.tpictxt);
            this.tcpnl.Controls.Add(this.tpic);
            this.tcpnl.Controls.Add(this.label14);
            this.tcpnl.Controls.Add(this.tcaddbtn);
            this.tcpnl.Controls.Add(this.label15);
            this.tcpnl.Controls.Add(this.tcnametxt);
            this.tcpnl.Controls.Add(this.label16);
            this.tcpnl.Controls.Add(this.tidtxt);
            this.tcpnl.Controls.Add(this.label17);
            this.tcpnl.Location = new System.Drawing.Point(3, 3);
            this.tcpnl.Name = "tcpnl";
            this.tcpnl.Size = new System.Drawing.Size(1153, 170);
            this.tcpnl.TabIndex = 23;
            // 
            // stcidtxt
            // 
            this.stcidtxt.Location = new System.Drawing.Point(112, 30);
            this.stcidtxt.Name = "stcidtxt";
            this.stcidtxt.Size = new System.Drawing.Size(100, 20);
            this.stcidtxt.TabIndex = 104;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(109, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(103, 13);
            this.label11.TabIndex = 103;
            this.label11.Text = "Second Category ID";
            // 
            // tyes
            // 
            this.tyes.AutoSize = true;
            this.tyes.Checked = true;
            this.tyes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tyes.Location = new System.Drawing.Point(16, 130);
            this.tyes.Name = "tyes";
            this.tyes.Size = new System.Drawing.Size(44, 17);
            this.tyes.TabIndex = 99;
            this.tyes.Text = "Yes";
            this.tyes.UseVisualStyleBackColor = true;
            // 
            // tpicaddbtn
            // 
            this.tpicaddbtn.Location = new System.Drawing.Point(465, 99);
            this.tpicaddbtn.Name = "tpicaddbtn";
            this.tpicaddbtn.Size = new System.Drawing.Size(58, 34);
            this.tpicaddbtn.TabIndex = 96;
            this.tpicaddbtn.Text = "Upload";
            this.tpicaddbtn.UseVisualStyleBackColor = true;
            this.tpicaddbtn.Click += new System.EventHandler(this.tpicaddbtn_Click);
            // 
            // tpictxt
            // 
            this.tpictxt.Location = new System.Drawing.Point(373, 113);
            this.tpictxt.Name = "tpictxt";
            this.tpictxt.Size = new System.Drawing.Size(86, 20);
            this.tpictxt.TabIndex = 97;
            // 
            // tpic
            // 
            this.tpic.BackColor = System.Drawing.Color.Transparent;
            this.tpic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tpic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tpic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tpic.Location = new System.Drawing.Point(373, 33);
            this.tpic.Name = "tpic";
            this.tpic.Size = new System.Drawing.Size(86, 74);
            this.tpic.TabIndex = 98;
            this.tpic.TabStop = false;
            this.tpic.Click += new System.EventHandler(this.tpic_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(13, 113);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 13);
            this.label14.TabIndex = 29;
            this.label14.Text = "Final";
            // 
            // tcaddbtn
            // 
            this.tcaddbtn.AutoSize = true;
            this.tcaddbtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tcaddbtn.Depth = 0;
            this.tcaddbtn.Location = new System.Drawing.Point(595, 97);
            this.tcaddbtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tcaddbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.tcaddbtn.Name = "tcaddbtn";
            this.tcaddbtn.Primary = false;
            this.tcaddbtn.Size = new System.Drawing.Size(112, 36);
            this.tcaddbtn.TabIndex = 28;
            this.tcaddbtn.Text = "add category";
            this.tcaddbtn.UseVisualStyleBackColor = true;
            this.tcaddbtn.Click += new System.EventHandler(this.tcaddbtn_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(370, 14);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(88, 13);
            this.label15.TabIndex = 26;
            this.label15.Text = "Picture (Optional)";
            // 
            // tcnametxt
            // 
            this.tcnametxt.Location = new System.Drawing.Point(16, 80);
            this.tcnametxt.Name = "tcnametxt";
            this.tcnametxt.Size = new System.Drawing.Size(270, 20);
            this.tcnametxt.TabIndex = 25;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(13, 63);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(80, 13);
            this.label16.TabIndex = 24;
            this.label16.Text = "Category Name";
            // 
            // tidtxt
            // 
            this.tidtxt.Location = new System.Drawing.Point(19, 30);
            this.tidtxt.Name = "tidtxt";
            this.tidtxt.Size = new System.Drawing.Size(60, 20);
            this.tidtxt.TabIndex = 23;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(16, 13);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(63, 13);
            this.label17.TabIndex = 22;
            this.label17.Text = "Category ID";
            // 
            // fcpnl
            // 
            this.fcpnl.Controls.Add(this.fidtxt);
            this.fcpnl.Controls.Add(this.label8);
            this.fcpnl.Controls.Add(this.fno);
            this.fcpnl.Controls.Add(this.fyes);
            this.fcpnl.Controls.Add(this.faddpicbtn);
            this.fcpnl.Controls.Add(this.fpictxt);
            this.fcpnl.Controls.Add(this.fpic);
            this.fcpnl.Controls.Add(this.label13);
            this.fcpnl.Controls.Add(this.faddbtn);
            this.fcpnl.Controls.Add(this.label3);
            this.fcpnl.Controls.Add(this.fnametxt);
            this.fcpnl.Controls.Add(this.label2);
            this.fcpnl.Controls.Add(this.fcidtxt);
            this.fcpnl.Controls.Add(this.label1);
            this.fcpnl.Location = new System.Drawing.Point(3, 3);
            this.fcpnl.Name = "fcpnl";
            this.fcpnl.Size = new System.Drawing.Size(1153, 170);
            this.fcpnl.TabIndex = 0;
            // 
            // fidtxt
            // 
            this.fidtxt.Location = new System.Drawing.Point(16, 30);
            this.fidtxt.Name = "fidtxt";
            this.fidtxt.Size = new System.Drawing.Size(60, 20);
            this.fidtxt.TabIndex = 102;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(146, 13);
            this.label8.TabIndex = 101;
            this.label8.Text = "ID (corresponding with CatID)";
            // 
            // fno
            // 
            this.fno.AutoSize = true;
            this.fno.Location = new System.Drawing.Point(66, 130);
            this.fno.Name = "fno";
            this.fno.Size = new System.Drawing.Size(40, 17);
            this.fno.TabIndex = 100;
            this.fno.Text = "No";
            this.fno.UseVisualStyleBackColor = true;
            this.fno.CheckedChanged += new System.EventHandler(this.fno_CheckedChanged);
            // 
            // fyes
            // 
            this.fyes.AutoSize = true;
            this.fyes.Location = new System.Drawing.Point(16, 130);
            this.fyes.Name = "fyes";
            this.fyes.Size = new System.Drawing.Size(44, 17);
            this.fyes.TabIndex = 99;
            this.fyes.Text = "Yes";
            this.fyes.UseVisualStyleBackColor = true;
            this.fyes.CheckedChanged += new System.EventHandler(this.fyes_CheckedChanged);
            // 
            // faddpicbtn
            // 
            this.faddpicbtn.Location = new System.Drawing.Point(361, 99);
            this.faddpicbtn.Name = "faddpicbtn";
            this.faddpicbtn.Size = new System.Drawing.Size(58, 34);
            this.faddpicbtn.TabIndex = 96;
            this.faddpicbtn.Text = "Upload";
            this.faddpicbtn.UseVisualStyleBackColor = true;
            this.faddpicbtn.Click += new System.EventHandler(this.faddpicbtn_Click);
            // 
            // fpictxt
            // 
            this.fpictxt.Location = new System.Drawing.Point(269, 113);
            this.fpictxt.Name = "fpictxt";
            this.fpictxt.Size = new System.Drawing.Size(86, 20);
            this.fpictxt.TabIndex = 97;
            // 
            // fpic
            // 
            this.fpic.BackColor = System.Drawing.Color.Transparent;
            this.fpic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.fpic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fpic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.fpic.Location = new System.Drawing.Point(269, 33);
            this.fpic.Name = "fpic";
            this.fpic.Size = new System.Drawing.Size(86, 74);
            this.fpic.TabIndex = 98;
            this.fpic.TabStop = false;
            this.fpic.Click += new System.EventHandler(this.fpic_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 113);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 13);
            this.label13.TabIndex = 29;
            this.label13.Text = "Final";
            // 
            // faddbtn
            // 
            this.faddbtn.AutoSize = true;
            this.faddbtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.faddbtn.Depth = 0;
            this.faddbtn.Location = new System.Drawing.Point(487, 101);
            this.faddbtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.faddbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.faddbtn.Name = "faddbtn";
            this.faddbtn.Primary = false;
            this.faddbtn.Size = new System.Drawing.Size(112, 36);
            this.faddbtn.TabIndex = 28;
            this.faddbtn.Text = "add category";
            this.faddbtn.UseVisualStyleBackColor = true;
            this.faddbtn.Click += new System.EventHandler(this.faddbtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(266, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Picture (Optional)";
            // 
            // fnametxt
            // 
            this.fnametxt.Location = new System.Drawing.Point(16, 80);
            this.fnametxt.Name = "fnametxt";
            this.fnametxt.Size = new System.Drawing.Size(229, 20);
            this.fnametxt.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Category Name";
            // 
            // fcidtxt
            // 
            this.fcidtxt.Location = new System.Drawing.Point(185, 31);
            this.fcidtxt.Name = "fcidtxt";
            this.fcidtxt.Size = new System.Drawing.Size(60, 20);
            this.fcidtxt.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(182, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Category ID";
            // 
            // scpnl
            // 
            this.scpnl.Controls.Add(this.fscidtxt);
            this.scpnl.Controls.Add(this.label10);
            this.scpnl.Controls.Add(this.sidtxt);
            this.scpnl.Controls.Add(this.label9);
            this.scpnl.Controls.Add(this.sno);
            this.scpnl.Controls.Add(this.syes);
            this.scpnl.Controls.Add(this.spicbtn);
            this.scpnl.Controls.Add(this.spictxt);
            this.scpnl.Controls.Add(this.spic);
            this.scpnl.Controls.Add(this.label4);
            this.scpnl.Controls.Add(this.addscbtn);
            this.scpnl.Controls.Add(this.label5);
            this.scpnl.Controls.Add(this.scnametxt);
            this.scpnl.Controls.Add(this.label6);
            this.scpnl.Controls.Add(this.scidtxt);
            this.scpnl.Controls.Add(this.label7);
            this.scpnl.Location = new System.Drawing.Point(3, 3);
            this.scpnl.Name = "scpnl";
            this.scpnl.Size = new System.Drawing.Size(1153, 170);
            this.scpnl.TabIndex = 22;
            // 
            // fscidtxt
            // 
            this.fscidtxt.Location = new System.Drawing.Point(254, 31);
            this.fscidtxt.Name = "fscidtxt";
            this.fscidtxt.Size = new System.Drawing.Size(81, 20);
            this.fscidtxt.TabIndex = 104;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(251, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 13);
            this.label10.TabIndex = 103;
            this.label10.Text = "First Category ID";
            // 
            // sidtxt
            // 
            this.sidtxt.Location = new System.Drawing.Point(16, 31);
            this.sidtxt.Name = "sidtxt";
            this.sidtxt.Size = new System.Drawing.Size(60, 20);
            this.sidtxt.TabIndex = 102;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(136, 13);
            this.label9.TabIndex = 101;
            this.label9.Text = "ID (corresponding to CatID)";
            // 
            // sno
            // 
            this.sno.AutoSize = true;
            this.sno.Location = new System.Drawing.Point(66, 130);
            this.sno.Name = "sno";
            this.sno.Size = new System.Drawing.Size(40, 17);
            this.sno.TabIndex = 100;
            this.sno.Text = "No";
            this.sno.UseVisualStyleBackColor = true;
            this.sno.CheckedChanged += new System.EventHandler(this.sno_CheckedChanged);
            // 
            // syes
            // 
            this.syes.AutoSize = true;
            this.syes.Location = new System.Drawing.Point(16, 130);
            this.syes.Name = "syes";
            this.syes.Size = new System.Drawing.Size(44, 17);
            this.syes.TabIndex = 99;
            this.syes.Text = "Yes";
            this.syes.UseVisualStyleBackColor = true;
            this.syes.CheckedChanged += new System.EventHandler(this.syes_CheckedChanged);
            // 
            // spicbtn
            // 
            this.spicbtn.Location = new System.Drawing.Point(465, 99);
            this.spicbtn.Name = "spicbtn";
            this.spicbtn.Size = new System.Drawing.Size(58, 34);
            this.spicbtn.TabIndex = 96;
            this.spicbtn.Text = "Upload";
            this.spicbtn.UseVisualStyleBackColor = true;
            this.spicbtn.Click += new System.EventHandler(this.spicbtn_Click);
            // 
            // spictxt
            // 
            this.spictxt.Location = new System.Drawing.Point(373, 113);
            this.spictxt.Name = "spictxt";
            this.spictxt.Size = new System.Drawing.Size(86, 20);
            this.spictxt.TabIndex = 97;
            // 
            // spic
            // 
            this.spic.BackColor = System.Drawing.Color.Transparent;
            this.spic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.spic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.spic.Image = global::Veiled_Kashmir_Admin_Panel.Properties.Resources.industrial_safety_1492046_640;
            this.spic.Location = new System.Drawing.Point(373, 33);
            this.spic.Name = "spic";
            this.spic.Size = new System.Drawing.Size(86, 74);
            this.spic.TabIndex = 98;
            this.spic.TabStop = false;
            this.spic.Click += new System.EventHandler(this.spic_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Final";
            // 
            // addscbtn
            // 
            this.addscbtn.AutoSize = true;
            this.addscbtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addscbtn.Depth = 0;
            this.addscbtn.Location = new System.Drawing.Point(595, 97);
            this.addscbtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.addscbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.addscbtn.Name = "addscbtn";
            this.addscbtn.Primary = false;
            this.addscbtn.Size = new System.Drawing.Size(112, 36);
            this.addscbtn.TabIndex = 28;
            this.addscbtn.Text = "add category";
            this.addscbtn.UseVisualStyleBackColor = true;
            this.addscbtn.Click += new System.EventHandler(this.addscbtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(370, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Picture (Important)";
            // 
            // scnametxt
            // 
            this.scnametxt.Location = new System.Drawing.Point(16, 80);
            this.scnametxt.Name = "scnametxt";
            this.scnametxt.Size = new System.Drawing.Size(319, 20);
            this.scnametxt.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Category Name";
            // 
            // scidtxt
            // 
            this.scidtxt.Location = new System.Drawing.Point(161, 31);
            this.scidtxt.Name = "scidtxt";
            this.scidtxt.Size = new System.Drawing.Size(60, 20);
            this.scidtxt.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(158, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Category ID";
            // 
            // loadingaccpic
            // 
            this.loadingaccpic.Image = global::Veiled_Kashmir_Admin_Panel.Properties.Resources.loading;
            this.loadingaccpic.Location = new System.Drawing.Point(186, 99);
            this.loadingaccpic.Name = "loadingaccpic";
            this.loadingaccpic.Size = new System.Drawing.Size(140, 86);
            this.loadingaccpic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.loadingaccpic.TabIndex = 49;
            this.loadingaccpic.TabStop = false;
            this.loadingaccpic.Visible = false;
            // 
            // loadinglbl
            // 
            this.loadinglbl.AutoSize = true;
            this.loadinglbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadinglbl.Location = new System.Drawing.Point(186, 184);
            this.loadinglbl.Name = "loadinglbl";
            this.loadinglbl.Size = new System.Drawing.Size(140, 25);
            this.loadinglbl.TabIndex = 50;
            this.loadinglbl.Text = "Gathering data";
            this.loadinglbl.Visible = false;
            // 
            // catdataview
            // 
            this.catdataview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.catdataview.BackgroundColor = System.Drawing.Color.White;
            this.catdataview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.catdataview.Location = new System.Drawing.Point(3, 234);
            this.catdataview.Name = "catdataview";
            this.catdataview.Size = new System.Drawing.Size(1009, 400);
            this.catdataview.TabIndex = 21;
            this.catdataview.Visible = false;
            // 
            // bpnl
            // 
            this.bpnl.Controls.Add(this.tcbtn);
            this.bpnl.Controls.Add(this.scbtn);
            this.bpnl.Controls.Add(this.fcbtn);
            this.bpnl.Location = new System.Drawing.Point(3, 3);
            this.bpnl.Name = "bpnl";
            this.bpnl.Size = new System.Drawing.Size(1153, 50);
            this.bpnl.TabIndex = 1;
            this.bpnl.Visible = false;
            // 
            // tcbtn
            // 
            this.tcbtn.AutoSize = true;
            this.tcbtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tcbtn.Depth = 0;
            this.tcbtn.Location = new System.Drawing.Point(352, 8);
            this.tcbtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tcbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.tcbtn.Name = "tcbtn";
            this.tcbtn.Primary = false;
            this.tcbtn.Size = new System.Drawing.Size(125, 36);
            this.tcbtn.TabIndex = 21;
            this.tcbtn.Text = "third category";
            this.tcbtn.UseVisualStyleBackColor = true;
            this.tcbtn.Click += new System.EventHandler(this.tcbtn_Click);
            // 
            // scbtn
            // 
            this.scbtn.AutoSize = true;
            this.scbtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.scbtn.Depth = 0;
            this.scbtn.Location = new System.Drawing.Point(174, 8);
            this.scbtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.scbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.scbtn.Name = "scbtn";
            this.scbtn.Primary = false;
            this.scbtn.Size = new System.Drawing.Size(139, 36);
            this.scbtn.TabIndex = 20;
            this.scbtn.Text = "second category";
            this.scbtn.UseVisualStyleBackColor = true;
            this.scbtn.Click += new System.EventHandler(this.scbtn_Click);
            // 
            // fcbtn
            // 
            this.fcbtn.AutoSize = true;
            this.fcbtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.fcbtn.Depth = 0;
            this.fcbtn.Location = new System.Drawing.Point(8, 8);
            this.fcbtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.fcbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.fcbtn.Name = "fcbtn";
            this.fcbtn.Primary = false;
            this.fcbtn.Size = new System.Drawing.Size(122, 36);
            this.fcbtn.TabIndex = 19;
            this.fcbtn.Text = "first category";
            this.fcbtn.UseVisualStyleBackColor = true;
            this.fcbtn.Click += new System.EventHandler(this.fcbtn_Click);
            // 
            // bgworker2
            // 
            this.bgworker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgworker2_DoWork);
            this.bgworker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgworker2_RunWorkerCompleted);
            // 
            // bgworker3
            // 
            this.bgworker3.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgworker3_DoWork);
            this.bgworker3.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgworker3_RunWorkerCompleted);
            // 
            // picdialog
            // 
            this.picdialog.Filter = "All Files|*.*|JPG|*.jpg|PNG|*.png";
            // 
            // addcategories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1162, 722);
            this.Controls.Add(this.cpnl);
            this.Controls.Add(this.formlbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "addcategories";
            this.Text = "addcategories";
            this.cpnl.ResumeLayout(false);
            this.cpnl.PerformLayout();
            this.epnl.ResumeLayout(false);
            this.tcpnl.ResumeLayout(false);
            this.tcpnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tpic)).EndInit();
            this.fcpnl.ResumeLayout(false);
            this.fcpnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpic)).EndInit();
            this.scpnl.ResumeLayout(false);
            this.scpnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingaccpic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.catdataview)).EndInit();
            this.bpnl.ResumeLayout(false);
            this.bpnl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker bgworker;
        private System.Windows.Forms.Label formlbl;
        private System.Windows.Forms.Panel cpnl;
        private System.Windows.Forms.Panel bpnl;
        private System.Windows.Forms.Panel fcpnl;
        private MaterialSkin.Controls.MaterialFlatButton tcbtn;
        private MaterialSkin.Controls.MaterialFlatButton scbtn;
        private MaterialSkin.Controls.MaterialFlatButton fcbtn;
        private System.Windows.Forms.DataGridView catdataview;
        private System.Windows.Forms.Label label13;
        private MaterialSkin.Controls.MaterialFlatButton faddbtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox fnametxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox fcidtxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox fidtxt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox fno;
        private System.Windows.Forms.CheckBox fyes;
        private System.Windows.Forms.Button faddpicbtn;
        private System.Windows.Forms.TextBox fpictxt;
        private System.Windows.Forms.PictureBox fpic;
        private System.Windows.Forms.Panel tcpnl;
        private System.Windows.Forms.TextBox stcidtxt;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox tyes;
        private System.Windows.Forms.Button tpicaddbtn;
        private System.Windows.Forms.TextBox tpictxt;
        private System.Windows.Forms.PictureBox tpic;
        private System.Windows.Forms.Label label14;
        private MaterialSkin.Controls.MaterialFlatButton tcaddbtn;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tcnametxt;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tidtxt;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel scpnl;
        private System.Windows.Forms.TextBox fscidtxt;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox sidtxt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox sno;
        private System.Windows.Forms.CheckBox syes;
        private System.Windows.Forms.Button spicbtn;
        private System.Windows.Forms.TextBox spictxt;
        private System.Windows.Forms.PictureBox spic;
        private System.Windows.Forms.Label label4;
        private MaterialSkin.Controls.MaterialFlatButton addscbtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox scnametxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox scidtxt;
        private System.Windows.Forms.Label label7;
        private System.ComponentModel.BackgroundWorker bgworker2;
        private System.ComponentModel.BackgroundWorker bgworker3;
        private System.Windows.Forms.Panel epnl;
        private System.Windows.Forms.PictureBox loadingaccpic;
        private System.Windows.Forms.Label loadinglbl;
        private System.Windows.Forms.OpenFileDialog picdialog;
        private System.Windows.Forms.Button updbtn;
    }
}