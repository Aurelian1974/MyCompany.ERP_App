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
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblUser
            // 
            lblUser.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblUser.AutoSize = true;
            lblUser.Location = new Point(4, 8);
            lblUser.Margin = new Padding(4, 0, 4, 0);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(107, 21);
            lblUser.TabIndex = 0;
            lblUser.Text = "Utilizator";
            // 
            // txtUser
            // 
            txtUser.Location = new Point(119, 4);
            txtUser.Margin = new Padding(4);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(213, 29);
            txtUser.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(119, 41);
            txtPassword.Margin = new Padding(4);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(213, 29);
            txtPassword.TabIndex = 3;
            // 
            // lblPassword
            // 
            lblPassword.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(4, 45);
            lblPassword.Margin = new Padding(4, 0, 4, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(107, 21);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Parola";
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnLogin.Location = new Point(3, 79);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(109, 36);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Autentificare";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Right;
            btnCancel.Location = new Point(225, 79);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(109, 36);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Renuntare";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(lblUser, 0, 0);
            tableLayoutPanel1.Controls.Add(btnCancel, 1, 2);
            tableLayoutPanel1.Controls.Add(txtUser, 1, 0);
            tableLayoutPanel1.Controls.Add(btnLogin, 0, 2);
            tableLayoutPanel1.Controls.Add(txtPassword, 1, 1);
            tableLayoutPanel1.Controls.Add(lblPassword, 0, 1);
            tableLayoutPanel1.Location = new Point(12, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(337, 120);
            tableLayoutPanel1.TabIndex = 7;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(362, 144);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "frmLogin";
            Text = "Autentificare";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblUser;
        private TextBox txtUser;
        private TextBox txtPassword;
        private Label lblPassword;
        private Button btnLogin;
        private Button btnCancel;
        private TableLayoutPanel tableLayoutPanel1;
    }
}
