namespace Veiled_Kashmir_Admin_Panel
{
    partial class mainform
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.signoutlbl = new System.Windows.Forms.Label();
            this.productsbtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.customersbtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.suppliersbtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.approvebtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.signinlbl = new System.Windows.Forms.Label();
            this.navpnl = new System.Windows.Forms.Panel();
            this.sendmailbtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.caboutbtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.homepagebtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.msgbtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.accbtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.expbtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.cobtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.ordersbtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.navtitle = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.navtxt = new System.Windows.Forms.Label();
            this.cntpnl = new System.Windows.Forms.Panel();
            this.loadinglbl = new System.Windows.Forms.Label();
            this.shippedlbl = new System.Windows.Forms.Label();
            this.placedlbl = new System.Windows.Forms.Label();
            this.attention = new System.Windows.Forms.PictureBox();
            this.costlbl = new System.Windows.Forms.Label();
            this.attentionlbl = new System.Windows.Forms.Label();
            this.orderslbl = new System.Windows.Forms.Label();
            this.ordersdlbl = new System.Windows.Forms.Label();
            this.deliveredh = new System.Windows.Forms.Label();
            this.shippeddataview = new System.Windows.Forms.DataGridView();
            this.shippedh = new System.Windows.Forms.Label();
            this.placeddataview = new System.Windows.Forms.DataGridView();
            this.placedh = new System.Windows.Forms.Label();
            this.bgworker = new System.ComponentModel.BackgroundWorker();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.navpnl.SuspendLayout();
            this.navtitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.cntpnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.attention)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shippeddataview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.placeddataview)).BeginInit();
            this.SuspendLayout();
            // 
            // signoutlbl
            // 
            this.signoutlbl.AutoSize = true;
            this.signoutlbl.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signoutlbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.signoutlbl.Location = new System.Drawing.Point(144, 691);
            this.signoutlbl.Name = "signoutlbl";
            this.signoutlbl.Size = new System.Drawing.Size(55, 16);
            this.signoutlbl.TabIndex = 16;
            this.signoutlbl.Text = "SIGN OUT";
            this.signoutlbl.Visible = false;
            this.signoutlbl.Click += new System.EventHandler(this.signoutlbl_Click);
            this.signoutlbl.MouseHover += new System.EventHandler(this.signoutlbl_Enter);
            // 
            // productsbtn
            // 
            this.productsbtn.AutoSize = true;
            this.productsbtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.productsbtn.Depth = 0;
            this.productsbtn.Location = new System.Drawing.Point(5, 56);
            this.productsbtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.productsbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.productsbtn.Name = "productsbtn";
            this.productsbtn.Primary = false;
            this.productsbtn.Size = new System.Drawing.Size(82, 36);
            this.productsbtn.TabIndex = 12;
            this.productsbtn.Text = "products";
            this.productsbtn.UseVisualStyleBackColor = true;
            this.productsbtn.Click += new System.EventHandler(this.productsbtn_Click);
            // 
            // customersbtn
            // 
            this.customersbtn.AutoSize = true;
            this.customersbtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.customersbtn.Depth = 0;
            this.customersbtn.Location = new System.Drawing.Point(5, 93);
            this.customersbtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.customersbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.customersbtn.Name = "customersbtn";
            this.customersbtn.Primary = false;
            this.customersbtn.Size = new System.Drawing.Size(93, 36);
            this.customersbtn.TabIndex = 14;
            this.customersbtn.Text = "customers";
            this.customersbtn.UseVisualStyleBackColor = true;
            this.customersbtn.Click += new System.EventHandler(this.customersbtn_Click);
            // 
            // suppliersbtn
            // 
            this.suppliersbtn.AutoSize = true;
            this.suppliersbtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.suppliersbtn.Depth = 0;
            this.suppliersbtn.Location = new System.Drawing.Point(4, 131);
            this.suppliersbtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.suppliersbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.suppliersbtn.Name = "suppliersbtn";
            this.suppliersbtn.Primary = false;
            this.suppliersbtn.Size = new System.Drawing.Size(83, 36);
            this.suppliersbtn.TabIndex = 13;
            this.suppliersbtn.Text = "suppliers";
            this.suppliersbtn.UseVisualStyleBackColor = true;
            this.suppliersbtn.Click += new System.EventHandler(this.suppliersbtn_Click);
            // 
            // approvebtn
            // 
            this.approvebtn.AutoSize = true;
            this.approvebtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.approvebtn.Depth = 0;
            this.approvebtn.Location = new System.Drawing.Point(5, 206);
            this.approvebtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.approvebtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.approvebtn.Name = "approvebtn";
            this.approvebtn.Primary = false;
            this.approvebtn.Size = new System.Drawing.Size(168, 36);
            this.approvebtn.TabIndex = 15;
            this.approvebtn.Text = "approve dealer price";
            this.approvebtn.UseVisualStyleBackColor = true;
            this.approvebtn.Click += new System.EventHandler(this.approvebtn_Click);
            // 
            // signinlbl
            // 
            this.signinlbl.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signinlbl.Location = new System.Drawing.Point(7, 668);
            this.signinlbl.Name = "signinlbl";
            this.signinlbl.Size = new System.Drawing.Size(192, 25);
            this.signinlbl.TabIndex = 9;
            this.signinlbl.Text = "Welcome, admin";
            this.signinlbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.signinlbl.Visible = false;
            // 
            // navpnl
            // 
            this.navpnl.BackColor = System.Drawing.Color.WhiteSmoke;
            this.navpnl.Controls.Add(this.sendmailbtn);
            this.navpnl.Controls.Add(this.caboutbtn);
            this.navpnl.Controls.Add(this.homepagebtn);
            this.navpnl.Controls.Add(this.msgbtn);
            this.navpnl.Controls.Add(this.accbtn);
            this.navpnl.Controls.Add(this.signoutlbl);
            this.navpnl.Controls.Add(this.signinlbl);
            this.navpnl.Controls.Add(this.expbtn);
            this.navpnl.Controls.Add(this.cobtn);
            this.navpnl.Controls.Add(this.productsbtn);
            this.navpnl.Controls.Add(this.approvebtn);
            this.navpnl.Controls.Add(this.customersbtn);
            this.navpnl.Controls.Add(this.suppliersbtn);
            this.navpnl.Controls.Add(this.ordersbtn);
            this.navpnl.Location = new System.Drawing.Point(0, 12);
            this.navpnl.Name = "navpnl";
            this.navpnl.Size = new System.Drawing.Size(200, 711);
            this.navpnl.TabIndex = 10;
            // 
            // sendmailbtn
            // 
            this.sendmailbtn.AutoSize = true;
            this.sendmailbtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.sendmailbtn.Depth = 0;
            this.sendmailbtn.Location = new System.Drawing.Point(4, 432);
            this.sendmailbtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.sendmailbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.sendmailbtn.Name = "sendmailbtn";
            this.sendmailbtn.Primary = false;
            this.sendmailbtn.Size = new System.Drawing.Size(91, 36);
            this.sendmailbtn.TabIndex = 25;
            this.sendmailbtn.Text = "Send Mails";
            this.sendmailbtn.UseVisualStyleBackColor = true;
            this.sendmailbtn.Click += new System.EventHandler(this.sendmailbtn_Click);
            // 
            // caboutbtn
            // 
            this.caboutbtn.AutoSize = true;
            this.caboutbtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.caboutbtn.Depth = 0;
            this.caboutbtn.Location = new System.Drawing.Point(5, 394);
            this.caboutbtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.caboutbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.caboutbtn.Name = "caboutbtn";
            this.caboutbtn.Primary = false;
            this.caboutbtn.Size = new System.Drawing.Size(70, 36);
            this.caboutbtn.TabIndex = 24;
            this.caboutbtn.Text = "Policies";
            this.caboutbtn.UseVisualStyleBackColor = true;
            this.caboutbtn.Click += new System.EventHandler(this.caboutbtn_Click);
            // 
            // homepagebtn
            // 
            this.homepagebtn.AutoSize = true;
            this.homepagebtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.homepagebtn.Depth = 0;
            this.homepagebtn.Location = new System.Drawing.Point(4, 356);
            this.homepagebtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.homepagebtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.homepagebtn.Name = "homepagebtn";
            this.homepagebtn.Primary = false;
            this.homepagebtn.Size = new System.Drawing.Size(118, 36);
            this.homepagebtn.TabIndex = 23;
            this.homepagebtn.Text = "Edit Homepage";
            this.homepagebtn.UseVisualStyleBackColor = true;
            this.homepagebtn.Click += new System.EventHandler(this.homepagebtn_Click);
            // 
            // msgbtn
            // 
            this.msgbtn.AutoSize = true;
            this.msgbtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.msgbtn.Depth = 0;
            this.msgbtn.Location = new System.Drawing.Point(5, 281);
            this.msgbtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.msgbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.msgbtn.Name = "msgbtn";
            this.msgbtn.Primary = false;
            this.msgbtn.Size = new System.Drawing.Size(130, 36);
            this.msgbtn.TabIndex = 22;
            this.msgbtn.Text = "Check Messages";
            this.msgbtn.UseVisualStyleBackColor = true;
            this.msgbtn.Click += new System.EventHandler(this.msgbtn_Click);
            // 
            // accbtn
            // 
            this.accbtn.AutoSize = true;
            this.accbtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.accbtn.Depth = 0;
            this.accbtn.Location = new System.Drawing.Point(5, 318);
            this.accbtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.accbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.accbtn.Name = "accbtn";
            this.accbtn.Primary = false;
            this.accbtn.Size = new System.Drawing.Size(84, 36);
            this.accbtn.TabIndex = 18;
            this.accbtn.Text = "Accounts";
            this.accbtn.UseVisualStyleBackColor = true;
            this.accbtn.Click += new System.EventHandler(this.chkbtn_Click);
            // 
            // expbtn
            // 
            this.expbtn.AutoSize = true;
            this.expbtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.expbtn.Depth = 0;
            this.expbtn.Location = new System.Drawing.Point(5, 169);
            this.expbtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.expbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.expbtn.Name = "expbtn";
            this.expbtn.Primary = false;
            this.expbtn.Size = new System.Drawing.Size(101, 36);
            this.expbtn.TabIndex = 11;
            this.expbtn.Text = "Expenditure";
            this.expbtn.UseVisualStyleBackColor = true;
            this.expbtn.Click += new System.EventHandler(this.expbtn_Click);
            // 
            // cobtn
            // 
            this.cobtn.AutoSize = true;
            this.cobtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cobtn.Depth = 0;
            this.cobtn.Location = new System.Drawing.Point(4, 244);
            this.cobtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cobtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.cobtn.Name = "cobtn";
            this.cobtn.Primary = false;
            this.cobtn.Size = new System.Drawing.Size(119, 36);
            this.cobtn.TabIndex = 17;
            this.cobtn.Text = "Cancel Orders";
            this.cobtn.UseVisualStyleBackColor = true;
            this.cobtn.Click += new System.EventHandler(this.cobtn_Click);
            // 
            // ordersbtn
            // 
            this.ordersbtn.AutoSize = true;
            this.ordersbtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ordersbtn.Depth = 0;
            this.ordersbtn.Location = new System.Drawing.Point(5, 19);
            this.ordersbtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.ordersbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.ordersbtn.Name = "ordersbtn";
            this.ordersbtn.Primary = false;
            this.ordersbtn.Size = new System.Drawing.Size(64, 36);
            this.ordersbtn.TabIndex = 10;
            this.ordersbtn.Text = "orders";
            this.ordersbtn.UseVisualStyleBackColor = true;
            this.ordersbtn.Click += new System.EventHandler(this.ordersbtn_Click);
            // 
            // navtitle
            // 
            this.navtitle.BackColor = System.Drawing.Color.Black;
            this.navtitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.navtitle.Controls.Add(this.pictureBox1);
            this.navtitle.Controls.Add(this.navtxt);
            this.navtitle.Location = new System.Drawing.Point(0, 1);
            this.navtitle.Name = "navtitle";
            this.navtitle.Size = new System.Drawing.Size(200, 22);
            this.navtitle.TabIndex = 11;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.BackgroundImage = global::Veiled_Kashmir_Admin_Panel.Properties.Resources._9895;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 20);
            this.pictureBox1.TabIndex = 41;
            this.pictureBox1.TabStop = false;
            // 
            // navtxt
            // 
            this.navtxt.AutoSize = true;
            this.navtxt.BackColor = System.Drawing.Color.Black;
            this.navtxt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.navtxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navtxt.ForeColor = System.Drawing.Color.White;
            this.navtxt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.navtxt.Location = new System.Drawing.Point(1, 1);
            this.navtxt.Name = "navtxt";
            this.navtxt.Size = new System.Drawing.Size(72, 20);
            this.navtxt.TabIndex = 0;
            this.navtxt.Text = "     Home";
            this.navtxt.Click += new System.EventHandler(this.navtxt_Click);
            // 
            // cntpnl
            // 
            this.cntpnl.BackColor = System.Drawing.Color.White;
            this.cntpnl.Controls.Add(this.loadinglbl);
            this.cntpnl.Controls.Add(this.shippedlbl);
            this.cntpnl.Controls.Add(this.placedlbl);
            this.cntpnl.Controls.Add(this.attention);
            this.cntpnl.Controls.Add(this.costlbl);
            this.cntpnl.Controls.Add(this.attentionlbl);
            this.cntpnl.Controls.Add(this.orderslbl);
            this.cntpnl.Controls.Add(this.ordersdlbl);
            this.cntpnl.Controls.Add(this.deliveredh);
            this.cntpnl.Controls.Add(this.shippeddataview);
            this.cntpnl.Controls.Add(this.shippedh);
            this.cntpnl.Controls.Add(this.placeddataview);
            this.cntpnl.Controls.Add(this.placedh);
            this.cntpnl.Location = new System.Drawing.Point(201, 1);
            this.cntpnl.Name = "cntpnl";
            this.cntpnl.Size = new System.Drawing.Size(1162, 722);
            this.cntpnl.TabIndex = 12;
            // 
            // loadinglbl
            // 
            this.loadinglbl.AutoSize = true;
            this.loadinglbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadinglbl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.loadinglbl.Location = new System.Drawing.Point(412, 263);
            this.loadinglbl.Name = "loadinglbl";
            this.loadinglbl.Size = new System.Drawing.Size(0, 31);
            this.loadinglbl.TabIndex = 42;
            this.loadinglbl.Visible = false;
            // 
            // shippedlbl
            // 
            this.shippedlbl.AutoSize = true;
            this.shippedlbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.shippedlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shippedlbl.ForeColor = System.Drawing.Color.Black;
            this.shippedlbl.Location = new System.Drawing.Point(177, 277);
            this.shippedlbl.Name = "shippedlbl";
            this.shippedlbl.Size = new System.Drawing.Size(82, 16);
            this.shippedlbl.TabIndex = 41;
            this.shippedlbl.Text = "View Details";
            this.shippedlbl.Visible = false;
            this.shippedlbl.Click += new System.EventHandler(this.shippedlbl_Click);
            // 
            // placedlbl
            // 
            this.placedlbl.AutoSize = true;
            this.placedlbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.placedlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.placedlbl.ForeColor = System.Drawing.Color.Black;
            this.placedlbl.Location = new System.Drawing.Point(99, 585);
            this.placedlbl.Name = "placedlbl";
            this.placedlbl.Size = new System.Drawing.Size(82, 16);
            this.placedlbl.TabIndex = 40;
            this.placedlbl.Text = "View Details";
            this.placedlbl.Visible = false;
            this.placedlbl.Click += new System.EventHandler(this.placedlbl_Click);
            // 
            // attention
            // 
            this.attention.BackgroundImage = global::Veiled_Kashmir_Admin_Panel.Properties.Resources.industrial_safety_1492046_640;
            this.attention.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.attention.Location = new System.Drawing.Point(19, 540);
            this.attention.Name = "attention";
            this.attention.Size = new System.Drawing.Size(73, 65);
            this.attention.TabIndex = 39;
            this.attention.TabStop = false;
            this.attention.Visible = false;
            // 
            // costlbl
            // 
            this.costlbl.AutoSize = true;
            this.costlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.costlbl.ForeColor = System.Drawing.Color.Red;
            this.costlbl.Location = new System.Drawing.Point(98, 560);
            this.costlbl.Name = "costlbl";
            this.costlbl.Size = new System.Drawing.Size(0, 20);
            this.costlbl.TabIndex = 38;
            // 
            // attentionlbl
            // 
            this.attentionlbl.AutoSize = true;
            this.attentionlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attentionlbl.ForeColor = System.Drawing.Color.Red;
            this.attentionlbl.Location = new System.Drawing.Point(98, 537);
            this.attentionlbl.Name = "attentionlbl";
            this.attentionlbl.Size = new System.Drawing.Size(0, 20);
            this.attentionlbl.TabIndex = 37;
            // 
            // orderslbl
            // 
            this.orderslbl.AutoSize = true;
            this.orderslbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.orderslbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderslbl.ForeColor = System.Drawing.Color.Black;
            this.orderslbl.Location = new System.Drawing.Point(682, 589);
            this.orderslbl.Name = "orderslbl";
            this.orderslbl.Size = new System.Drawing.Size(82, 16);
            this.orderslbl.TabIndex = 36;
            this.orderslbl.Text = "View Details";
            this.orderslbl.Visible = false;
            this.orderslbl.Click += new System.EventHandler(this.orderslbl_Click);
            // 
            // ordersdlbl
            // 
            this.ordersdlbl.AutoSize = true;
            this.ordersdlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ordersdlbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ordersdlbl.Location = new System.Drawing.Point(681, 556);
            this.ordersdlbl.Name = "ordersdlbl";
            this.ordersdlbl.Size = new System.Drawing.Size(0, 24);
            this.ordersdlbl.TabIndex = 35;
            // 
            // deliveredh
            // 
            this.deliveredh.AutoSize = true;
            this.deliveredh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deliveredh.ForeColor = System.Drawing.SystemColors.Highlight;
            this.deliveredh.Location = new System.Drawing.Point(681, 537);
            this.deliveredh.Name = "deliveredh";
            this.deliveredh.Size = new System.Drawing.Size(148, 16);
            this.deliveredh.TabIndex = 34;
            this.deliveredh.Text = "Total Orders Delivered:";
            this.deliveredh.Visible = false;
            // 
            // shippeddataview
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.shippeddataview.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.shippeddataview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.shippeddataview.BackgroundColor = System.Drawing.Color.White;
            this.shippeddataview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.shippeddataview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.shippeddataview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.shippeddataview.Location = new System.Drawing.Point(5, 296);
            this.shippeddataview.Name = "shippeddataview";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.shippeddataview.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.shippeddataview.RowHeadersVisible = false;
            this.shippeddataview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.shippeddataview.Size = new System.Drawing.Size(1145, 155);
            this.shippeddataview.TabIndex = 33;
            // 
            // shippedh
            // 
            this.shippedh.AutoSize = true;
            this.shippedh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shippedh.ForeColor = System.Drawing.SystemColors.Highlight;
            this.shippedh.Location = new System.Drawing.Point(4, 277);
            this.shippedh.Name = "shippedh";
            this.shippedh.Size = new System.Drawing.Size(167, 16);
            this.shippedh.TabIndex = 32;
            this.shippedh.Text = "Orders currently SHIPPED:";
            this.shippedh.Visible = false;
            // 
            // placeddataview
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.placeddataview.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.placeddataview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.placeddataview.BackgroundColor = System.Drawing.Color.White;
            this.placeddataview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.placeddataview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.placeddataview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.placeddataview.Location = new System.Drawing.Point(5, 30);
            this.placeddataview.Name = "placeddataview";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.placeddataview.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.placeddataview.RowHeadersVisible = false;
            this.placeddataview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.placeddataview.Size = new System.Drawing.Size(1145, 228);
            this.placeddataview.TabIndex = 31;
            // 
            // placedh
            // 
            this.placedh.AutoSize = true;
            this.placedh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.placedh.ForeColor = System.Drawing.Color.Red;
            this.placedh.Location = new System.Drawing.Point(4, 11);
            this.placedh.Name = "placedh";
            this.placedh.Size = new System.Drawing.Size(161, 16);
            this.placedh.TabIndex = 10;
            this.placedh.Text = "Orders currently PLACED:";
            this.placedh.Visible = false;
            // 
            // bgworker
            // 
            this.bgworker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgworker_DoWork);
            this.bgworker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgworker_RunWorkerCompleted);
            // 
            // timer
            // 
            this.timer.Interval = 600;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1363, 725);
            this.Controls.Add(this.navtitle);
            this.Controls.Add(this.cntpnl);
            this.Controls.Add(this.navpnl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "mainform";
            this.Text = "mainform";
            this.Load += new System.EventHandler(this.mainform_Load);
            this.navpnl.ResumeLayout(false);
            this.navpnl.PerformLayout();
            this.navtitle.ResumeLayout(false);
            this.navtitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.cntpnl.ResumeLayout(false);
            this.cntpnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.attention)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shippeddataview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.placeddataview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label signoutlbl;
        private MaterialSkin.Controls.MaterialFlatButton productsbtn;
        private MaterialSkin.Controls.MaterialFlatButton suppliersbtn;
        private MaterialSkin.Controls.MaterialFlatButton customersbtn;
        private MaterialSkin.Controls.MaterialFlatButton approvebtn;
        private System.Windows.Forms.Label signinlbl;
        private System.Windows.Forms.Panel navpnl;
        private MaterialSkin.Controls.MaterialFlatButton ordersbtn;
        private MaterialSkin.Controls.MaterialFlatButton expbtn;
        private MaterialSkin.Controls.MaterialFlatButton cobtn;
        private System.Windows.Forms.Panel navtitle;
        public System.Windows.Forms.Panel cntpnl;
        private MaterialSkin.Controls.MaterialFlatButton accbtn;
        private System.Windows.Forms.Label placedh;
        private System.Windows.Forms.DataGridView shippeddataview;
        private System.Windows.Forms.Label shippedh;
        private System.Windows.Forms.Label ordersdlbl;
        private System.Windows.Forms.Label deliveredh;
        private System.Windows.Forms.Label orderslbl;
        private System.Windows.Forms.Label attentionlbl;
        private System.Windows.Forms.Label costlbl;
        private System.Windows.Forms.PictureBox attention;
        private System.Windows.Forms.Label placedlbl;
        private MaterialSkin.Controls.MaterialFlatButton msgbtn;
        private MaterialSkin.Controls.MaterialFlatButton homepagebtn;
        private MaterialSkin.Controls.MaterialFlatButton caboutbtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label navtxt;
        private System.Windows.Forms.Label shippedlbl;
        public System.Windows.Forms.DataGridView placeddataview;
        private MaterialSkin.Controls.MaterialFlatButton sendmailbtn;
        private System.ComponentModel.BackgroundWorker bgworker;
        private System.Windows.Forms.Label loadinglbl;
        private System.Windows.Forms.Timer timer;
    }
}