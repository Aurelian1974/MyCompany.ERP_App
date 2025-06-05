using MyCompany.Common.DTOs.Login;
using MyCompany.Common.SharedInterfaces.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.ERP.WinForms.Services.Login;

public class WinFormsAuthService : IAuthService
{
    private readonly IAuthApiClient _apiClient;

    public WinFormsAuthService(IAuthApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<(bool Success, string Message, ApplicationUserDto User)> LoginAsync(string userName, string password)
    {
        // Validare de bază
        if (string.IsNullOrWhiteSpace(userName))
        {
            return (false, "Numele de utilizator este obligatoriu", null);
        }

        if (string.IsNullOrWhiteSpace(password))
        {
            return (false, "Parola este obligatorie", null);
        }

        try
        {
            // Verifică dacă API-ul este disponibil (dacă AuthApiClient are această metodă)
            if (_apiClient is AuthApiClient apiClient && !await apiClient.IsApiAvailableAsync())
            {
                return (false, "API-ul nu este disponibil. Verifică dacă serverul rulează.", null);
            }

            var request = new LoginRequestDto
            {
                UserName = userName.Trim(),
                Password = password
            };

            var response = await _apiClient.LoginAsync(request);

            return (response.Success, response.Message, response.User);
        }
        catch (Exception ex)
        {
            return (false, $"Eroare în procesul de autentificare: {ex.Message}", null);
        }
    }
}

//using MyCompany.Common.DTOs.Login;
//using MyCompany.Common.SharedInterfaces.Login;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MyCompany.ERP.WinForms.Services.Login;

//public class WinFormsAuthService : IAuthService
//{
//    private readonly IAuthApiClient _apiClient;

//    public WinFormsAuthService(IAuthApiClient apiClient)
//    {
//        _apiClient = apiClient;
//    }

//    public async Task<(bool Success, string Message, ApplicationUserDto User)> LoginAsync(string userName, string password)
//    {
//        var request = new LoginRequestDto
//        {
//            UserName = userName,
//            Password = password
//        };

//        var response = await _apiClient.LoginAsync(request);

//        return (response.Success, response.Message, response.User);
//    }
//}
