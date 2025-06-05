using Microsoft.Extensions.Configuration;
using MyCompany.Common.DTOs.Login;
using MyCompany.Common.SharedInterfaces.Login;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyCompany.ERP.WinForms.Services.Login;

public class AuthApiClient : IAuthApiClient
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;

    public AuthApiClient(HttpClient httpClient, IConfiguration config)
    {
        _httpClient = httpClient;
        // Actualizat portul pentru host-ul unificat
        _baseUrl = config["ApiSettings:BaseUrl"] ?? "https://localhost:7002";
    }

    public async Task<LoginResponseDto> LoginAsync(LoginRequestDto request)
    {
        try
        {
            var json = JsonSerializer.Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{_baseUrl}/api/auth/login", content);

            if (response.IsSuccessStatusCode)
            {
                var responseJson = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<LoginResponseDto>(responseJson, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
            else
            {
                // Îmbunătățită gestionarea erorilor
                var errorContent = await response.Content.ReadAsStringAsync();
                return new LoginResponseDto
                {
                    Success = false,
                    Message = $"Eroare de comunicare cu serverul: {response.StatusCode} - {errorContent}"
                };
            }
        }
        catch (HttpRequestException httpEx)
        {
            return new LoginResponseDto
            {
                Success = false,
                Message = $"Eroare de rețea: {httpEx.Message}. Verifică dacă API-ul rulează pe {_baseUrl}"
            };
        }
        catch (TaskCanceledException tcEx)
        {
            return new LoginResponseDto
            {
                Success = false,
                Message = $"Timeout la conectare: {tcEx.Message}"
            };
        }
        catch (Exception ex)
        {
            return new LoginResponseDto
            {
                Success = false,
                Message = $"Eroare neașteptată: {ex.Message}"
            };
        }
    }

    // Metodă pentru verificarea conectivității
    public async Task<bool> IsApiAvailableAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/health");
            return response.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }
}


//using Microsoft.Extensions.Configuration;
//using MyCompany.Common.DTOs.Login;
//using MyCompany.Common.SharedInterfaces.Login;
//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Linq;
//using System.Text;
//using System.Text.Json;
//using System.Threading.Tasks;

//namespace MyCompany.ERP.WinForms.Services.Login;

//public class AuthApiClient : IAuthApiClient
//{
//    private readonly HttpClient _httpClient;
//    private readonly string _baseUrl;

//    public AuthApiClient(HttpClient httpClient, IConfiguration config)
//    {
//        _httpClient = httpClient;
//        _baseUrl = config["ApiSettings:BaseUrl"] ?? "https://localhost:7001";
//    }

//    public async Task<LoginResponseDto> LoginAsync(LoginRequestDto request)
//    {
//        try
//        {
//            var json = JsonSerializer.Serialize(request);
//            var content = new StringContent(json, Encoding.UTF8, "application/json");

//            var response = await _httpClient.PostAsync($"{_baseUrl}/api/auth/login", content);

//            if (response.IsSuccessStatusCode)
//            {
//                var responseJson = await response.Content.ReadAsStringAsync();
//                return JsonSerializer.Deserialize<LoginResponseDto>(responseJson, new JsonSerializerOptions
//                {
//                    PropertyNameCaseInsensitive = true
//                });
//            }
//            else
//            {
//                return new LoginResponseDto
//                {
//                    Success = false,
//                    Message = "Eroare de comunicare cu serverul"
//                };
//            }
//        }
//        catch (Exception ex)
//        {
//            return new LoginResponseDto
//            {
//                Success = false,
//                Message = $"Eroare de conectare: {ex.Message}"
//            };
//        }
//    }
//}