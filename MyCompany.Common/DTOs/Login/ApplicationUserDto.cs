namespace MyCompany.Common.DTOs.Login;

public class ApplicationUserDto
{
    public int UserId { get; set; }
    public Guid UserGuid { get; set; }
    public string ? UserName { get; set; }
    public DateTime CreatedAt { get; set; }
}
