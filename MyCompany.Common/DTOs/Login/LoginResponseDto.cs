namespace MyCompany.Common.DTOs.Login;

public class LoginResponseDto
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public ApplicationUserDto? User { get; set; }
}