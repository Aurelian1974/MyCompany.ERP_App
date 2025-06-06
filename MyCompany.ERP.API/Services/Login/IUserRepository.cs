using MyCompany.Common.DTOs.Users;
using System.Threading.Tasks;

public interface IUserRepository
{
    Task AddUserAsync(string userName, string password);
    Task UpdateUserAsync(int userId, string userName, string password);
    Task DeleteUserAsync(int userId);

    // Add the missing method definition to fix the error
    Task<IEnumerable<UserDto>> GetAllUsersAsync();
}