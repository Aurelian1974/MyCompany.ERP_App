namespace MyCompany.ERP.WinForms.Forms.Administrare
{
    partial class frmUsers
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
            lblUserName = new Label();
            lblPassword = new Label();
            txtUserName = new TextBox();
            txtPaswoerd = new TextBox();
            btnAdd = new Button();
            btnModify = new Button();
            btnDelete = new Button();
            dgwAllUser = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgwAllUser).BeginInit();
            SuspendLayout();
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Location = new Point(36, 42);
            lblUserName.Margin = new Padding(4, 0, 4, 0);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(73, 21);
            lblUserName.TabIndex = 0;
            lblUserName.Text = "Utilizator";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(36, 97);
            lblPassword.Margin = new Padding(4, 0, 4, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(53, 21);
            lblPassword.TabIndex = 1;
            lblPassword.Text = "Parola";
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(123, 43);
            txtUserName.Margin = new Padding(4, 4, 4, 4);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(127, 29);
            txtUserName.TabIndex = 2;
            // 
            // txtPaswoerd
            // 
            txtPaswoerd.Location = new Point(123, 97);
            txtPaswoerd.Margin = new Padding(4, 4, 4, 4);
            txtPaswoerd.Name = "txtPaswoerd";
            txtPaswoerd.Size = new Size(127, 29);
            txtPaswoerd.TabIndex = 3;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(15, 161);
            btnAdd.Margin = new Padding(4, 4, 4, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(96, 32);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Adaugare";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnModify
            // 
            btnModify.Location = new Point(120, 161);
            btnModify.Margin = new Padding(4, 4, 4, 4);
            btnModify.Name = "btnModify";
            btnModify.Size = new Size(96, 32);
            btnModify.TabIndex = 5;
            btnModify.Text = "Modificare";
            btnModify.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(224, 161);
            btnDelete.Margin = new Padding(4, 4, 4, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(96, 32);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "Stergere";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // dgwAllUser
            // 
            dgwAllUser.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwAllUser.Location = new Point(15, 202);
            dgwAllUser.Margin = new Padding(4, 4, 4, 4);
            dgwAllUser.Name = "dgwAllUser";
            dgwAllUser.Size = new Size(531, 210);
            dgwAllUser.TabIndex = 7;
            // 
            // frmUsers
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(705, 496);
            Controls.Add(dgwAllUser);
            Controls.Add(btnDelete);
            Controls.Add(btnModify);
            Controls.Add(btnAdd);
            Controls.Add(txtPaswoerd);
            Controls.Add(txtUserName);
            Controls.Add(lblPassword);
            Controls.Add(lblUserName);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 4, 4, 4);
            Name = "frmUsers";
            Text = "Users";
            ((System.ComponentModel.ISupportInitialize)dgwAllUser).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUserName;
        private Label lblPassword;
        private TextBox txtUserName;
        private TextBox txtPaswoerd;
        private Button btnAdd;
        private Button btnModify;
        private Button btnDelete;
        private DataGridView dgwAllUser;
    }
}