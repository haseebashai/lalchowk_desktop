namespace Modest_Attires
{
    partial class sql
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tplbl = new System.Windows.Forms.Label();
            this.sqltxt = new System.Windows.Forms.RichTextBox();
            this.sqldataview = new System.Windows.Forms.DataGridView();
            this.execbtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.lalchowkchk = new System.Windows.Forms.CheckBox();
            this.lalacchk = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sellbl = new System.Windows.Forms.LinkLabel();
            this.inslbl = new System.Windows.Forms.LinkLabel();
            this.updlbl = new System.Windows.Forms.LinkLabel();
            this.dellbl = new System.Windows.Forms.LinkLabel();
            this.updbtn = new System.Windows.Forms.Button();
            this.pbar = new System.Windows.Forms.ProgressBar();
            this.fetchlbl = new System.Windows.Forms.Label();
            this.copybtn = new System.Windows.Forms.Button();
            this.coltxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.spacebox = new System.Windows.Forms.CheckBox();
            this.commabox = new System.Windows.Forms.CheckBox();
            this.linebox = new System.Windows.Forms.CheckBox();
            this.colonbox = new System.Windows.Forms.CheckBox();
            this.valuepnl = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.sqldataview)).BeginInit();
            this.valuepnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tplbl
            // 
            this.tplbl.AutoSize = true;
            this.tplbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tplbl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.tplbl.Location = new System.Drawing.Point(12, 95);
            this.tplbl.Name = "tplbl";
            this.tplbl.Size = new System.Drawing.Size(132, 17);
            this.tplbl.TabIndex = 18;
            this.tplbl.Text = "Enter SQL Queries ";
            // 
            // sqltxt
            // 
            this.sqltxt.AutoWordSelection = true;
            this.sqltxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sqltxt.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.sqltxt.Location = new System.Drawing.Point(15, 116);
            this.sqltxt.Name = "sqltxt";
            this.sqltxt.Size = new System.Drawing.Size(588, 102);
            this.sqltxt.TabIndex = 19;
            this.sqltxt.Text = "";
            // 
            // sqldataview
            // 
            this.sqldataview.BackgroundColor = System.Drawing.Color.White;
            this.sqldataview.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.sqldataview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.sqldataview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sqldataview.GridColor = System.Drawing.SystemColors.Control;
            this.sqldataview.Location = new System.Drawing.Point(15, 224);
            this.sqldataview.Name = "sqldataview";
            this.sqldataview.Size = new System.Drawing.Size(957, 322);
            this.sqldataview.TabIndex = 20;
            this.sqldataview.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.sqldataview_CellContentClick);
            // 
            // execbtn
            // 
            this.execbtn.AutoSize = true;
            this.execbtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.execbtn.Depth = 0;
            this.execbtn.Location = new System.Drawing.Point(668, 134);
            this.execbtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.execbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.execbtn.Name = "execbtn";
            this.execbtn.Primary = false;
            this.execbtn.Size = new System.Drawing.Size(117, 36);
            this.execbtn.TabIndex = 34;
            this.execbtn.Text = "execute query";
            this.execbtn.UseVisualStyleBackColor = true;
            this.execbtn.Click += new System.EventHandler(this.execbtn_Click);
            // 
            // lalchowkchk
            // 
            this.lalchowkchk.AutoSize = true;
            this.lalchowkchk.Location = new System.Drawing.Point(15, 56);
            this.lalchowkchk.Name = "lalchowkchk";
            this.lalchowkchk.Size = new System.Drawing.Size(72, 17);
            this.lalchowkchk.TabIndex = 35;
            this.lalchowkchk.Text = "Lalchowk";
            this.lalchowkchk.UseVisualStyleBackColor = true;
            this.lalchowkchk.CheckedChanged += new System.EventHandler(this.lalchowkchk_CheckedChanged);
            // 
            // lalacchk
            // 
            this.lalacchk.AutoSize = true;
            this.lalacchk.Location = new System.Drawing.Point(119, 56);
            this.lalacchk.Name = "lalacchk";
            this.lalacchk.Size = new System.Drawing.Size(129, 17);
            this.lalacchk.TabIndex = 36;
            this.lalacchk.Text = "Lalchowk Accounting";
            this.lalacchk.UseVisualStyleBackColor = true;
            this.lalacchk.CheckedChanged += new System.EventHandler(this.lalacchk_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 17);
            this.label1.TabIndex = 37;
            this.label1.Text = "Select Database";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(400, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "Syntax:";
            // 
            // sellbl
            // 
            this.sellbl.AutoSize = true;
            this.sellbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sellbl.Location = new System.Drawing.Point(450, 97);
            this.sellbl.Name = "sellbl";
            this.sellbl.Size = new System.Drawing.Size(35, 13);
            this.sellbl.TabIndex = 43;
            this.sellbl.TabStop = true;
            this.sellbl.Text = "select";
            this.sellbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.sellbl_LinkClicked);
            // 
            // inslbl
            // 
            this.inslbl.AutoSize = true;
            this.inslbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.inslbl.Location = new System.Drawing.Point(489, 97);
            this.inslbl.Name = "inslbl";
            this.inslbl.Size = new System.Drawing.Size(32, 13);
            this.inslbl.TabIndex = 44;
            this.inslbl.TabStop = true;
            this.inslbl.Text = "insert";
            this.inslbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.inslbl_LinkClicked);
            // 
            // updlbl
            // 
            this.updlbl.AutoSize = true;
            this.updlbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.updlbl.Location = new System.Drawing.Point(524, 97);
            this.updlbl.Name = "updlbl";
            this.updlbl.Size = new System.Drawing.Size(40, 13);
            this.updlbl.TabIndex = 45;
            this.updlbl.TabStop = true;
            this.updlbl.Text = "update";
            this.updlbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.updlbl_LinkClicked);
            // 
            // dellbl
            // 
            this.dellbl.AutoSize = true;
            this.dellbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dellbl.Location = new System.Drawing.Point(567, 97);
            this.dellbl.Name = "dellbl";
            this.dellbl.Size = new System.Drawing.Size(36, 13);
            this.dellbl.TabIndex = 46;
            this.dellbl.TabStop = true;
            this.dellbl.Text = "delete";
            this.dellbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.dellbl_LinkClicked);
            // 
            // updbtn
            // 
            this.updbtn.Location = new System.Drawing.Point(889, 552);
            this.updbtn.Name = "updbtn";
            this.updbtn.Size = new System.Drawing.Size(83, 28);
            this.updbtn.TabIndex = 53;
            this.updbtn.Text = "Update";
            this.updbtn.UseVisualStyleBackColor = true;
            this.updbtn.Visible = false;
            this.updbtn.Click += new System.EventHandler(this.updbtn_Click);
            // 
            // pbar
            // 
            this.pbar.Location = new System.Drawing.Point(645, 173);
            this.pbar.MarqueeAnimationSpeed = 30;
            this.pbar.Name = "pbar";
            this.pbar.Size = new System.Drawing.Size(165, 3);
            this.pbar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbar.TabIndex = 54;
            this.pbar.Visible = false;
            // 
            // fetchlbl
            // 
            this.fetchlbl.AutoSize = true;
            this.fetchlbl.BackColor = System.Drawing.Color.Transparent;
            this.fetchlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fetchlbl.ForeColor = System.Drawing.Color.Black;
            this.fetchlbl.Location = new System.Drawing.Point(687, 179);
            this.fetchlbl.Name = "fetchlbl";
            this.fetchlbl.Size = new System.Drawing.Size(76, 13);
            this.fetchlbl.TabIndex = 55;
            this.fetchlbl.Text = "Fetching Rows";
            this.fetchlbl.Visible = false;
            // 
            // copybtn
            // 
            this.copybtn.Location = new System.Drawing.Point(341, 19);
            this.copybtn.Name = "copybtn";
            this.copybtn.Size = new System.Drawing.Size(129, 48);
            this.copybtn.TabIndex = 56;
            this.copybtn.Text = "Copy values to String";
            this.copybtn.UseVisualStyleBackColor = true;
            this.copybtn.Click += new System.EventHandler(this.copybtn_Click);
            // 
            // coltxt
            // 
            this.coltxt.Location = new System.Drawing.Point(3, 19);
            this.coltxt.Name = "coltxt";
            this.coltxt.Size = new System.Drawing.Size(332, 20);
            this.coltxt.TabIndex = 57;
            this.coltxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(127, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 58;
            this.label3.Text = "Column Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(3, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 59;
            this.label4.Text = "Seperate by:";
            // 
            // spacebox
            // 
            this.spacebox.AutoSize = true;
            this.spacebox.Location = new System.Drawing.Point(76, 52);
            this.spacebox.Name = "spacebox";
            this.spacebox.Size = new System.Drawing.Size(57, 17);
            this.spacebox.TabIndex = 60;
            this.spacebox.Text = "Space";
            this.spacebox.UseVisualStyleBackColor = true;
            this.spacebox.CheckedChanged += new System.EventHandler(this.spacebox_CheckedChanged);
            // 
            // commabox
            // 
            this.commabox.AutoSize = true;
            this.commabox.Location = new System.Drawing.Point(139, 52);
            this.commabox.Name = "commabox";
            this.commabox.Size = new System.Drawing.Size(60, 17);
            this.commabox.TabIndex = 61;
            this.commabox.Text = "comma";
            this.commabox.UseVisualStyleBackColor = true;
            this.commabox.CheckedChanged += new System.EventHandler(this.commabox_CheckedChanged);
            // 
            // linebox
            // 
            this.linebox.AutoSize = true;
            this.linebox.Location = new System.Drawing.Point(205, 52);
            this.linebox.Name = "linebox";
            this.linebox.Size = new System.Drawing.Size(71, 17);
            this.linebox.TabIndex = 62;
            this.linebox.Text = "New Line";
            this.linebox.UseVisualStyleBackColor = true;
            this.linebox.CheckedChanged += new System.EventHandler(this.linebox_CheckedChanged);
            // 
            // colonbox
            // 
            this.colonbox.AutoSize = true;
            this.colonbox.Location = new System.Drawing.Point(282, 52);
            this.colonbox.Name = "colonbox";
            this.colonbox.Size = new System.Drawing.Size(53, 17);
            this.colonbox.TabIndex = 63;
            this.colonbox.Text = "Colon";
            this.colonbox.UseVisualStyleBackColor = true;
            this.colonbox.CheckedChanged += new System.EventHandler(this.colonbox_CheckedChanged);
            // 
            // valuepnl
            // 
            this.valuepnl.Controls.Add(this.coltxt);
            this.valuepnl.Controls.Add(this.colonbox);
            this.valuepnl.Controls.Add(this.copybtn);
            this.valuepnl.Controls.Add(this.linebox);
            this.valuepnl.Controls.Add(this.label3);
            this.valuepnl.Controls.Add(this.commabox);
            this.valuepnl.Controls.Add(this.label4);
            this.valuepnl.Controls.Add(this.spacebox);
            this.valuepnl.Location = new System.Drawing.Point(15, 547);
            this.valuepnl.Name = "valuepnl";
            this.valuepnl.Size = new System.Drawing.Size(491, 74);
            this.valuepnl.TabIndex = 64;
            this.valuepnl.Visible = false;
            // 
            // sql
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 643);
            this.Controls.Add(this.valuepnl);
            this.Controls.Add(this.fetchlbl);
            this.Controls.Add(this.pbar);
            this.Controls.Add(this.updbtn);
            this.Controls.Add(this.dellbl);
            this.Controls.Add(this.updlbl);
            this.Controls.Add(this.inslbl);
            this.Controls.Add(this.sellbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lalacchk);
            this.Controls.Add(this.lalchowkchk);
            this.Controls.Add(this.execbtn);
            this.Controls.Add(this.sqldataview);
            this.Controls.Add(this.sqltxt);
            this.Controls.Add(this.tplbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "sql";
            this.Text = "sql";
            ((System.ComponentModel.ISupportInitialize)(this.sqldataview)).EndInit();
            this.valuepnl.ResumeLayout(false);
            this.valuepnl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label tplbl;
        private System.Windows.Forms.RichTextBox sqltxt;
        private System.Windows.Forms.DataGridView sqldataview;
        private MaterialSkin.Controls.MaterialFlatButton execbtn;
        private System.Windows.Forms.CheckBox lalchowkchk;
        private System.Windows.Forms.CheckBox lalacchk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel sellbl;
        private System.Windows.Forms.LinkLabel inslbl;
        private System.Windows.Forms.LinkLabel updlbl;
        private System.Windows.Forms.LinkLabel dellbl;
        private System.Windows.Forms.Button updbtn;
        private System.Windows.Forms.ProgressBar pbar;
        private System.Windows.Forms.Label fetchlbl;
        private System.Windows.Forms.Button copybtn;
        private System.Windows.Forms.TextBox coltxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox spacebox;
        private System.Windows.Forms.CheckBox commabox;
        private System.Windows.Forms.CheckBox linebox;
        private System.Windows.Forms.CheckBox colonbox;
        private System.Windows.Forms.Panel valuepnl;
    }
}