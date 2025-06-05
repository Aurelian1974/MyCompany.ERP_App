using MyCompany.Common.DTOs.Login;


namespace MyCompany.Common.SharedInterfaces.Login;

public interface IAuthApiClient
{
    Task<LoginResponseDto> LoginAsync(LoginRequestDto request);
    Task<bool> IsApiAvailableAsync(); // Metodă nouă pentru verificarea conectivității
    //Task<LoginResponseDto> LoginAsync(LoginRequestDto request);
}
