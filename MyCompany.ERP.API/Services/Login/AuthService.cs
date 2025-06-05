using Dapper;
using Microsoft.Data.SqlClient;
using MyCompany.Common.DTOs.Login;
using MyCompany.Common.SharedInterfaces.Login;

namespace MyCompany.ERP.API.Services.Login;

public class AuthService : IAuthService
{
    private readonly IConfiguration _config;
    private readonly string _connectionString;

    public AuthService(IConfiguration config)
    {
        _config = config;
        _connectionString = _config.GetConnectionString("DefaultConnection");
    }

    public async Task<(bool Success, string Message, Common.DTOs.Login.ApplicationUserDto User)> LoginAsync(string userName, string password)
    {
        // Validări de input
        if (string.IsNullOrWhiteSpace(userName) && string.IsNullOrWhiteSpace(password))
            return (false, "Completati UserName si Password", null);

        if (string.IsNullOrWhiteSpace(userName))
            return (false, "Completati UserName", null);

        if (string.IsNullOrWhiteSpace(password))
            return (false, "Completati Password", null);

        try
        {
            using var connection = new SqlConnection(_connectionString);

            // Verifică utilizatorul cu username și password
            var user = await connection.QueryFirstOrDefaultAsync<ApplicationUserDto>(
                @"SELECT UserId, UserGuid, UserName, CreatedAt 
                      FROM ApplicationUser 
                      WHERE UserName = @UserName AND Password = @Password",
                new { UserName = userName, Password = password });

            if (user != null)
                return (true, "Autentificare reușită", user);

            // Verifică dacă există username-ul
            var userExists = await connection.ExecuteScalarAsync<int>(
                "SELECT COUNT(1) FROM ApplicationUser WHERE UserName = @UserName",
                new { UserName = userName });

            // Verifică dacă există password-ul
            var passwordExists = await connection.ExecuteScalarAsync<int>(
                "SELECT COUNT(1) FROM ApplicationUser WHERE Password = @Password",
                new { Password = password });

            // Logica pentru mesajele de eroare
            if (userExists > 0 && passwordExists == 0)
                return (false, "Password gresita", null);

            if (userExists == 0 && passwordExists > 0)
                return (false, "UserName gresit", null);

            // Ambele greșite
            return (false, "UserName gresit, Password gresita", null);
        }
        catch (SqlException ex)
        {
            // Log error here
            return (false, "Eroare de conectare la baza de date", null);
        }
        catch (Exception ex)
        {
            // Log error here
            return (false, "Eroare neașteptată", null);
        }
    }
}

