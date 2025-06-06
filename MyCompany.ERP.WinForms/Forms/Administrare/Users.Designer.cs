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
            components = new System.ComponentModel.Container();
            dataGridViewUsers = new DataGridView();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            txtPassword = new TextBox();
            lblPassword = new Label();
            txtUserName = new TextBox();
            lblUserName = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            //gridBagLayout1 = new Syncfusion.Windows.Forms.Tools.GridBagLayout(components);
            //((System.ComponentModel.ISupportInitialize)dataGridViewUsers).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            //((System.ComponentModel.ISupportInitialize)gridBagLayout1).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewUsers
            // 
            dataGridViewUsers.AllowUserToAddRows = false;
            dataGridViewUsers.AllowUserToDeleteRows = false;
            dataGridViewUsers.AllowUserToOrderColumns = true;
            dataGridViewUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUsers.Location = new Point(1016, 0);
            dataGridViewUsers.Margin = new Padding(4);
            dataGridViewUsers.Name = "dataGridViewUsers";
            dataGridViewUsers.ReadOnly = true;
            dataGridViewUsers.Size = new Size(203, 616);
            dataGridViewUsers.TabIndex = 7;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(813, 0);
            btnAdd.Margin = new Padding(4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(203, 616);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Adaugare";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(610, 0);
            btnEdit.Margin = new Padding(4);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(203, 616);
            btnEdit.TabIndex = 5;
            btnEdit.Text = "Modificare";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(407, 0);
            btnDelete.Margin = new Padding(4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(203, 616);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "Stergere";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(85, 41);
            txtPassword.Margin = new Padding(4);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(92, 29);
            txtPassword.TabIndex = 3;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(4, 37);
            lblPassword.Margin = new Padding(4, 0, 4, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(53, 21);
            lblPassword.TabIndex = 1;
            lblPassword.Text = "Parola";
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(85, 4);
            txtUserName.Margin = new Padding(4);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(92, 29);
            txtUserName.TabIndex = 2;
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Location = new Point(4, 0);
            lblUserName.Margin = new Padding(4, 0, 4, 0);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(73, 21);
            lblUserName.TabIndex = 0;
            lblUserName.Text = "Utilizator";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(lblUserName, 0, 0);
            tableLayoutPanel1.Controls.Add(txtUserName, 1, 0);
            tableLayoutPanel1.Controls.Add(lblPassword, 0, 1);
            tableLayoutPanel1.Controls.Add(txtPassword, 1, 1);
            tableLayoutPanel1.Location = new Point(204, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(203, 616);
            tableLayoutPanel1.TabIndex = 8;
            // 
            // frmUsers
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1219, 616);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(dataGridViewUsers);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "frmUsers";
            Text = "Users";
           // ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            //((System.ComponentModel.ISupportInitialize)gridBagLayout1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewUsers;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private TextBox txtPassword;
        private Label lblPassword;
        private TextBox txtUserName;
        private Label lblUserName;
        private TableLayoutPanel tableLayoutPanel1;
        //private Syncfusion.Windows.Forms.Tools.GridBagLayout gridBagLayout1;
    }
}