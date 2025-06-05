namespace MyCompany.ERP.WinForms
{
    partial class frmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblUser = new Label();
            txtUser = new TextBox();
            txtPassword = new TextBox();
            lblPassword = new Label();
            btnLogin = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Location = new Point(22, 19);
            lblUser.Margin = new Padding(4, 0, 4, 0);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(73, 21);
            lblUser.TabIndex = 0;
            lblUser.Text = "Utilizator";
            // 
            // txtUser
            // 
            txtUser.Location = new Point(128, 16);
            txtUser.Margin = new Padding(4);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(172, 29);
            txtUser.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(128, 56);
            txtPassword.Margin = new Padding(4);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(172, 29);
            txtPassword.TabIndex = 3;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(22, 64);
            lblPassword.Margin = new Padding(4, 0, 4, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(53, 21);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Parola";
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(22, 116);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(109, 36);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Autentificare";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += this.btnLogin_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(191, 116);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(109, 36);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Renuntare";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(316, 172);
            Controls.Add(btnCancel);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtUser);
            Controls.Add(lblUser);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "frmLogin";
            Text = "Autentificare";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUser;
        private TextBox txtUser;
        private TextBox txtPassword;
        private Label lblPassword;
        private Button btnLogin;
        private Button btnCancel;
    }
}
