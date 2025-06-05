using MyCompany.Common.DTOs.Login;


namespace MyCompany.Common.SharedInterfaces.Login;

public interface IAuthApiClient
{
    Task<LoginResponseDto> LoginAsync(LoginRequestDto request);
}
