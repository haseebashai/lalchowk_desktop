namespace Veiled_Kashmir_Admin_Panel
{
    partial class loginform
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
            this.usernametxt = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.pwdtxt = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.forgotbtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.loginbtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.label1 = new System.Windows.Forms.Label();
            this.error = new System.Windows.Forms.Label();
            this.namelbl = new System.Windows.Forms.Label();
            this.pwdlbl = new System.Windows.Forms.Label();
            this.materialRaisedButton1 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.SuspendLayout();
            // 
            // usernametxt
            // 
            this.usernametxt.Depth = 0;
            this.usernametxt.Hint = "";
            this.usernametxt.Location = new System.Drawing.Point(471, 205);
            this.usernametxt.MouseState = MaterialSkin.MouseState.HOVER;
            this.usernametxt.Name = "usernametxt";
            this.usernametxt.PasswordChar = '\0';
            this.usernametxt.SelectedText = "";
            this.usernametxt.SelectionLength = 0;
            this.usernametxt.SelectionStart = 0;
            this.usernametxt.Size = new System.Drawing.Size(248, 23);
            this.usernametxt.TabIndex = 1;
            this.usernametxt.TabStop = false;
            this.usernametxt.UseSystemPasswordChar = false;
            this.usernametxt.Enter += new System.EventHandler(this.usrtxt_Enter);
            this.usernametxt.Leave += new System.EventHandler(this.usernametxt_Leave);
            // 
            // pwdtxt
            // 
            this.pwdtxt.Depth = 0;
            this.pwdtxt.Hint = "";
            this.pwdtxt.Location = new System.Drawing.Point(471, 261);
            this.pwdtxt.MouseState = MaterialSkin.MouseState.HOVER;
            this.pwdtxt.Name = "pwdtxt";
            this.pwdtxt.PasswordChar = '*';
            this.pwdtxt.SelectedText = "";
            this.pwdtxt.SelectionLength = 0;
            this.pwdtxt.SelectionStart = 0;
            this.pwdtxt.Size = new System.Drawing.Size(248, 23);
            this.pwdtxt.TabIndex = 2;
            this.pwdtxt.TabStop = false;
            this.pwdtxt.UseSystemPasswordChar = false;
            this.pwdtxt.Enter += new System.EventHandler(this.pwdtxt_Enter);
            this.pwdtxt.Leave += new System.EventHandler(this.pwdtxt_Leave);
            // 
            // forgotbtn
            // 
            this.forgotbtn.AutoSize = true;
            this.forgotbtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.forgotbtn.Depth = 0;
            this.forgotbtn.Location = new System.Drawing.Point(471, 333);
            this.forgotbtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.forgotbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.forgotbtn.Name = "forgotbtn";
            this.forgotbtn.Primary = false;
            this.forgotbtn.Size = new System.Drawing.Size(148, 36);
            this.forgotbtn.TabIndex = 5;
            this.forgotbtn.Text = "FORGOT PASSWORD?";
            this.forgotbtn.UseVisualStyleBackColor = true;
            this.forgotbtn.Click += new System.EventHandler(this.forgotbtn_Click);
            // 
            // loginbtn
            // 
            this.loginbtn.Depth = 0;
            this.loginbtn.Location = new System.Drawing.Point(644, 340);
            this.loginbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.loginbtn.Name = "loginbtn";
            this.loginbtn.Primary = true;
            this.loginbtn.Size = new System.Drawing.Size(75, 23);
            this.loginbtn.TabIndex = 3;
            this.loginbtn.Text = "login";
            this.loginbtn.UseVisualStyleBackColor = true;
            this.loginbtn.Click += new System.EventHandler(this.loginbtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(517, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "LOGIN TO YOUR ACCOUNT.";
            // 
            // error
            // 
            this.error.AutoSize = true;
            this.error.ForeColor = System.Drawing.Color.Coral;
            this.error.Location = new System.Drawing.Point(537, 299);
            this.error.Name = "error";
            this.error.Size = new System.Drawing.Size(123, 13);
            this.error.TabIndex = 8;
            this.error.Text = "Username does not exist";
            this.error.Visible = false;
            // 
            // namelbl
            // 
            this.namelbl.AutoSize = true;
            this.namelbl.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namelbl.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.namelbl.Location = new System.Drawing.Point(468, 205);
            this.namelbl.Name = "namelbl";
            this.namelbl.Size = new System.Drawing.Size(38, 18);
            this.namelbl.TabIndex = 9;
            this.namelbl.Text = "Name";
            // 
            // pwdlbl
            // 
            this.pwdlbl.AutoSize = true;
            this.pwdlbl.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pwdlbl.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.pwdlbl.Location = new System.Drawing.Point(468, 261);
            this.pwdlbl.Name = "pwdlbl";
            this.pwdlbl.Size = new System.Drawing.Size(58, 18);
            this.pwdlbl.TabIndex = 10;
            this.pwdlbl.Text = "Password";
            // 
            // materialRaisedButton1
            // 
            this.materialRaisedButton1.Depth = 0;
            this.materialRaisedButton1.Location = new System.Drawing.Point(813, 340);
            this.materialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton1.Name = "materialRaisedButton1";
            this.materialRaisedButton1.Primary = true;
            this.materialRaisedButton1.Size = new System.Drawing.Size(75, 23);
            this.materialRaisedButton1.TabIndex = 11;
            this.materialRaisedButton1.Text = "login";
            this.materialRaisedButton1.UseVisualStyleBackColor = true;
            this.materialRaisedButton1.Click += new System.EventHandler(this.materialRaisedButton1_Click);
            // 
            // loginform
            // 
            this.AcceptButton = this.loginbtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1198, 608);
            this.Controls.Add(this.materialRaisedButton1);
            this.Controls.Add(this.pwdlbl);
            this.Controls.Add(this.namelbl);
            this.Controls.Add(this.error);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loginbtn);
            this.Controls.Add(this.forgotbtn);
            this.Controls.Add(this.pwdtxt);
            this.Controls.Add(this.usernametxt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "loginform";
            this.Text = "loginform";
            this.Load += new System.EventHandler(this.loginform_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialSingleLineTextField usernametxt;
        private MaterialSkin.Controls.MaterialSingleLineTextField pwdtxt;
        private MaterialSkin.Controls.MaterialFlatButton forgotbtn;
        private MaterialSkin.Controls.MaterialRaisedButton loginbtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label error;
        private System.Windows.Forms.Label namelbl;
        private System.Windows.Forms.Label pwdlbl;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
    }
}