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
        var request = new LoginRequestDto
        {
            UserName = userName,
            Password = password
        };

        var response = await _apiClient.LoginAsync(request);

        return (response.Success, response.Message, response.User);
    }
}
