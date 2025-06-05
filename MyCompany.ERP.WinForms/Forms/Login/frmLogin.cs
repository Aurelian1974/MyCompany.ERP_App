using MyCompany.Common.SharedInterfaces.Login;
using MyCompany.ERP.WinForms.Forms;
using MyCompany.ERP.WinForms.Forms.MainForm;

namespace MyCompany.ERP.WinForms;

public partial class frmLogin : Form
{
    private readonly IAuthService _authService;
    private bool _isProcessing = false;

    public frmLogin(IAuthService authService)
    {
        InitializeComponent();
        _authService = authService;

        // Configurare controale
        txtPassword.PasswordChar = '*';
        txtPassword.UseSystemPasswordChar = true;

        // Event handlers
        btnLogin.Click += btnLogin_Click;
        btnCancel.Click += btnCancel_Click;

        // Enter key pentru login
        this.AcceptButton = btnLogin;
        this.CancelButton = btnCancel;
    }

    private async void btnLogin_Click(object sender, EventArgs e)
    {
        if (_isProcessing) return;

        try
        {
            _isProcessing = true;
            btnLogin.Enabled = false;
            btnLogin.Text = "Se procesează...";

            var userName = txtUser.Text.Trim();
            var password = txtPassword.Text.Trim();

            var (success, message, user) = await _authService.LoginAsync(userName, password);

            if (success)
            {
                // Succes - deschide MainForm
                this.Hide();

                using (var mainForm = new MainForm())
                {
                    var result = mainForm.ShowDialog();
                }

                this.Close();
            }
            else
            {
                // Eroare - afișează mesajul
                MessageBox.Show(message, "Eroare autentificare",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Resetează câmpurile în caz de eroare
                txtPassword.Clear();
                txtUser.Focus();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Eroare neașteptată: {ex.Message}", "Eroare",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            _isProcessing = false;
            btnLogin.Enabled = true;
            btnLogin.Text = "Autentificare";
        }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        //Application.Exit();
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }

    private void frmLogin_Load(object sender, EventArgs e)
    {
        txtUser.Focus();
    }
}


