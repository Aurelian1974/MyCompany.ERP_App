using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Json;
using MyCompany.Common.DTOs.Users;
using Microsoft.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace MyCompany.ERP.WinForms.Forms.Administrare
{
    public partial class frmUsers : Form
    {
        private readonly HttpClient _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7002/") };
        private readonly string _connectionString;

        // Fix for CS0103: The name 'txtPassword' does not exist in the current context
        // Ensure that the txtPassword TextBox is declared and initialized in the form
        //private TextBox txtPassword;

        /// <summary>
        /// private System.Windows.Forms.DataGridView dataGridViewUsers;
        /// </summary>

        public frmUsers()
        {
            InitializeComponent();
            this.Load += frmUsers_Load; // asociază evenimentul Load

            // Add this event handler in the frmUsers constructor after InitializeComponent():
            this.dataGridViewUsers.SelectionChanged += dataGridViewUsers_SelectionChanged;

            // Load connection string from appsettings.json
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        private async Task<List<UserDto>> GetUsersAsync()
        {
            try
            {
                var users = await _httpClient.GetFromJsonAsync<List<UserDto>>("api/users");
                return users ?? new List<UserDto>(); // Ensure a non-null list is returned
            }
            catch (HttpRequestException ex)
            {
                // Log the exception
                MessageBox.Show($"Failed to fetch users: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<UserDto>();
            }
        }

        private async Task AddUserAsync(UserDto user)
        {
            var response = await _httpClient.PostAsJsonAsync("api/users", user);
            response.EnsureSuccessStatusCode();
        }

        private async Task UpdateUserAsync(UserDto user)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/users/{user.UserId}", user);
            response.EnsureSuccessStatusCode();
        }

        private async Task DeleteUserAsync(int userId)
        {
            var response = await _httpClient.DeleteAsync($"api/users/{userId}");
            response.EnsureSuccessStatusCode();
        }

        private async void frmUsers_Load(object? sender, EventArgs e)
        {
            await RefreshUsersAsync();
        }

        private async Task RefreshUsersAsync()
        {
            var users = await GetUsersAsync();
            dataGridViewUsers.DataSource = users;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var user = new UserDto
            {
                UserName = txtUserName.Text.Trim(),
                Password = txtPassword.Text.Trim() // Implementează hashing-ul parolei!
            };

            await AddUserAsync(user);
            await RefreshUsersAsync();
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsers.CurrentRow?.DataBoundItem is UserDto user)
            {
                user.UserName = txtUserName.Text.Trim();
                user.Password = txtPassword.Text.Trim();

                await UpdateUserAsync(user);
                await RefreshUsersAsync();
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsers.CurrentRow?.DataBoundItem is UserDto user)
            {
                await DeleteUserAsync(user.UserId);
                await RefreshUsersAsync();
            }
        }
        // Fix for CS0103: The name 'HashPassword' does not exist in the current context
        private string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                return await connection.QueryAsync<UserDto>("spUser_GetAll", commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"Error fetching users: {ex.Message}");
                throw;
            }
        }

        // Add this method to the frmUsers class:
        private void dataGridViewUsers_SelectionChanged(object? sender, EventArgs e)
        {
            if (dataGridViewUsers.CurrentRow?.DataBoundItem is UserDto user)
            {
                txtUserName.Text = user.UserName;
                txtPassword.Text = user.Password;
            }
        }
    }
}
