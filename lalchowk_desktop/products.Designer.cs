namespace Veiled_Kashmir_Admin_Panel
{
    partial class products
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
            this.components = new System.ComponentModel.Container();
            this.tplbl = new System.Windows.Forms.Label();
            this.eleclbl = new System.Windows.Forms.Label();
            this.clothlbl = new System.Windows.Forms.Label();
            this.footlbl = new System.Windows.Forms.Label();
            this.mobilelbl = new System.Windows.Forms.Label();
            this.complbl = new System.Windows.Forms.Label();
            this.cacclbl = new System.Windows.Forms.Label();
            this.coslbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.booklbl = new System.Windows.Forms.Label();
            this.ppnl = new System.Windows.Forms.Panel();
            this.bgworker = new System.ComponentModel.BackgroundWorker();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.addpics = new MaterialSkin.Controls.MaterialFlatButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.viewpbtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.newbtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.chkbtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.loadinglbl = new System.Windows.Forms.Label();
            this.ppnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tplbl
            // 
            this.tplbl.AutoSize = true;
            this.tplbl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.tplbl.Location = new System.Drawing.Point(239, 16);
            this.tplbl.Name = "tplbl";
            this.tplbl.Size = new System.Drawing.Size(104, 13);
            this.tplbl.TabIndex = 17;
            this.tplbl.Text = "total products added";
            // 
            // eleclbl
            // 
            this.eleclbl.AutoSize = true;
            this.eleclbl.ForeColor = System.Drawing.Color.Gray;
            this.eleclbl.Location = new System.Drawing.Point(17, 73);
            this.eleclbl.Name = "eleclbl";
            this.eleclbl.Size = new System.Drawing.Size(84, 13);
            this.eleclbl.TabIndex = 18;
            this.eleclbl.Text = "total electronics ";
            // 
            // clothlbl
            // 
            this.clothlbl.AutoSize = true;
            this.clothlbl.ForeColor = System.Drawing.Color.Gray;
            this.clothlbl.Location = new System.Drawing.Point(17, 94);
            this.clothlbl.Name = "clothlbl";
            this.clothlbl.Size = new System.Drawing.Size(67, 13);
            this.clothlbl.TabIndex = 19;
            this.clothlbl.Text = "total clothing";
            // 
            // footlbl
            // 
            this.footlbl.AutoSize = true;
            this.footlbl.ForeColor = System.Drawing.Color.Gray;
            this.footlbl.Location = new System.Drawing.Point(17, 116);
            this.footlbl.Name = "footlbl";
            this.footlbl.Size = new System.Drawing.Size(71, 13);
            this.footlbl.TabIndex = 20;
            this.footlbl.Text = "total footwear";
            // 
            // mobilelbl
            // 
            this.mobilelbl.AutoSize = true;
            this.mobilelbl.ForeColor = System.Drawing.Color.Gray;
            this.mobilelbl.Location = new System.Drawing.Point(412, 73);
            this.mobilelbl.Name = "mobilelbl";
            this.mobilelbl.Size = new System.Drawing.Size(65, 13);
            this.mobilelbl.TabIndex = 21;
            this.mobilelbl.Text = "total mobiles";
            // 
            // complbl
            // 
            this.complbl.AutoSize = true;
            this.complbl.ForeColor = System.Drawing.Color.Gray;
            this.complbl.Location = new System.Drawing.Point(412, 95);
            this.complbl.Name = "complbl";
            this.complbl.Size = new System.Drawing.Size(79, 13);
            this.complbl.TabIndex = 22;
            this.complbl.Text = "total computers";
            // 
            // cacclbl
            // 
            this.cacclbl.AutoSize = true;
            this.cacclbl.ForeColor = System.Drawing.Color.Gray;
            this.cacclbl.Location = new System.Drawing.Point(412, 116);
            this.cacclbl.Name = "cacclbl";
            this.cacclbl.Size = new System.Drawing.Size(86, 13);
            this.cacclbl.TabIndex = 23;
            this.cacclbl.Text = "total accessories";
            // 
            // coslbl
            // 
            this.coslbl.AutoSize = true;
            this.coslbl.ForeColor = System.Drawing.Color.Gray;
            this.coslbl.Location = new System.Drawing.Point(17, 138);
            this.coslbl.Name = "coslbl";
            this.coslbl.Size = new System.Drawing.Size(77, 13);
            this.coslbl.TabIndex = 24;
            this.coslbl.Text = "total cosmetics";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 24);
            this.label1.TabIndex = 25;
            this.label1.Text = "Products";
            // 
            // booklbl
            // 
            this.booklbl.AutoSize = true;
            this.booklbl.ForeColor = System.Drawing.Color.Gray;
            this.booklbl.Location = new System.Drawing.Point(17, 160);
            this.booklbl.Name = "booklbl";
            this.booklbl.Size = new System.Drawing.Size(59, 13);
            this.booklbl.TabIndex = 30;
            this.booklbl.Text = "total books";
            // 
            // ppnl
            // 
            this.ppnl.Controls.Add(this.booklbl);
            this.ppnl.Controls.Add(this.tplbl);
            this.ppnl.Controls.Add(this.eleclbl);
            this.ppnl.Controls.Add(this.clothlbl);
            this.ppnl.Controls.Add(this.footlbl);
            this.ppnl.Controls.Add(this.coslbl);
            this.ppnl.Controls.Add(this.mobilelbl);
            this.ppnl.Controls.Add(this.cacclbl);
            this.ppnl.Controls.Add(this.complbl);
            this.ppnl.Location = new System.Drawing.Point(12, 342);
            this.ppnl.Name = "ppnl";
            this.ppnl.Size = new System.Drawing.Size(646, 192);
            this.ppnl.TabIndex = 31;
            this.ppnl.Visible = false;
            // 
            // bgworker
            // 
            this.bgworker.WorkerSupportsCancellation = true;
            this.bgworker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgworker_DoWork);
            this.bgworker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgworker_RunWorkerCompleted);
            // 
            // timer
            // 
            this.timer.Interval = 600;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // addpics
            // 
            this.addpics.AutoSize = true;
            this.addpics.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addpics.Depth = 0;
            this.addpics.Location = new System.Drawing.Point(517, 80);
            this.addpics.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.addpics.MouseState = MaterialSkin.MouseState.HOVER;
            this.addpics.Name = "addpics";
            this.addpics.Primary = false;
            this.addpics.Size = new System.Drawing.Size(106, 36);
            this.addpics.TabIndex = 26;
            this.addpics.Text = "add pictures";
            this.addpics.UseVisualStyleBackColor = true;
            this.addpics.Click += new System.EventHandler(this.addpics_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Location = new System.Drawing.Point(457, 70);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 50);
            this.panel2.TabIndex = 27;
            // 
            // viewpbtn
            // 
            this.viewpbtn.AutoSize = true;
            this.viewpbtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.viewpbtn.Depth = 0;
            this.viewpbtn.Location = new System.Drawing.Point(277, 191);
            this.viewpbtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.viewpbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.viewpbtn.Name = "viewpbtn";
            this.viewpbtn.Primary = false;
            this.viewpbtn.Size = new System.Drawing.Size(118, 36);
            this.viewpbtn.TabIndex = 28;
            this.viewpbtn.Text = "View Products";
            this.viewpbtn.UseVisualStyleBackColor = true;
            this.viewpbtn.Click += new System.EventHandler(this.viewpbtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Location = new System.Drawing.Point(219, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 50);
            this.panel1.TabIndex = 16;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Silver;
            this.panel3.Location = new System.Drawing.Point(293, 158);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(85, 1);
            this.panel3.TabIndex = 29;
            // 
            // newbtn
            // 
            this.newbtn.AutoSize = true;
            this.newbtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.newbtn.Depth = 0;
            this.newbtn.Location = new System.Drawing.Point(14, 80);
            this.newbtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.newbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.newbtn.Name = "newbtn";
            this.newbtn.Primary = false;
            this.newbtn.Size = new System.Drawing.Size(146, 36);
            this.newbtn.TabIndex = 15;
            this.newbtn.Text = "Add New products";
            this.newbtn.UseVisualStyleBackColor = true;
            this.newbtn.Click += new System.EventHandler(this.newbtn_Click);
            // 
            // chkbtn
            // 
            this.chkbtn.AutoSize = true;
            this.chkbtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.chkbtn.Depth = 0;
            this.chkbtn.Location = new System.Drawing.Point(277, 80);
            this.chkbtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.chkbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.chkbtn.Name = "chkbtn";
            this.chkbtn.Primary = false;
            this.chkbtn.Size = new System.Drawing.Size(119, 36);
            this.chkbtn.TabIndex = 14;
            this.chkbtn.Text = "Edit Inventory";
            this.chkbtn.UseVisualStyleBackColor = true;
            this.chkbtn.Click += new System.EventHandler(this.chkbtn_Click);
            // 
            // loadinglbl
            // 
            this.loadinglbl.AutoSize = true;
            this.loadinglbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadinglbl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.loadinglbl.Location = new System.Drawing.Point(12, 305);
            this.loadinglbl.Name = "loadinglbl";
            this.loadinglbl.Size = new System.Drawing.Size(0, 25);
            this.loadinglbl.TabIndex = 32;
            this.loadinglbl.Visible = false;
            // 
            // products
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1162, 722);
            this.Controls.Add(this.loadinglbl);
            this.Controls.Add(this.chkbtn);
            this.Controls.Add(this.ppnl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.newbtn);
            this.Controls.Add(this.viewpbtn);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.addpics);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "products";
            this.Text = "admin";
            this.ppnl.ResumeLayout(false);
            this.ppnl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label tplbl;
        private System.Windows.Forms.Label eleclbl;
        private System.Windows.Forms.Label clothlbl;
        private System.Windows.Forms.Label footlbl;
        private System.Windows.Forms.Label mobilelbl;
        private System.Windows.Forms.Label complbl;
        private System.Windows.Forms.Label cacclbl;
        private System.Windows.Forms.Label coslbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label booklbl;
        private System.Windows.Forms.Panel ppnl;
        private System.ComponentModel.BackgroundWorker bgworker;
        private System.Windows.Forms.Timer timer;
        private MaterialSkin.Controls.MaterialFlatButton addpics;
        private System.Windows.Forms.Panel panel2;
        private MaterialSkin.Controls.MaterialFlatButton viewpbtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private MaterialSkin.Controls.MaterialFlatButton newbtn;
        private MaterialSkin.Controls.MaterialFlatButton chkbtn;
        private System.Windows.Forms.Label loadinglbl;
    }
}