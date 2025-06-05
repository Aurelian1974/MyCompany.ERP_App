using MyCompany.Common.DTOs.Login;
using System.Threading.Tasks;

namespace MyCompany.Common.SharedInterfaces.Login;

public interface IAuthService
{
    Task<(bool Success, string Message, ApplicationUserDto User)> LoginAsync(string userName, string password);
}