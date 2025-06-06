using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;
using MyCompany.Common.SharedInterfaces.Login;
using MyCompany.Common.DTOs.Users;

public class UserRepository : IUserRepository
{
    private readonly string _connectionString;
    public UserRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public async Task AddUserAsync(string userName, string password)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.ExecuteAsync("spUser_Add", new { UserName = userName, Password = password }, commandType: CommandType.StoredProcedure);
    }

    public async Task UpdateUserAsync(int userId, string userName, string password)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.ExecuteAsync("spUser_Update", new { UserId = userId, UserName = userName, Password = password }, commandType: CommandType.StoredProcedure);
    }

    public async Task DeleteUserAsync(int userId)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.ExecuteAsync("spUser_Delete", new { UserId = userId }, commandType: CommandType.StoredProcedure);
    }

    public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
    {
        using var connection = new SqlConnection(_connectionString);
        return await connection.QueryAsync<UserDto>("spUser_GetAll", commandType: CommandType.StoredProcedure);
    }
}