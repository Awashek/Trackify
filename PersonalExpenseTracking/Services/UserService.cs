using PersonalExpenseTracking.Models;
using PersonalExpenseTracking.Services.Interface;
using PersonalExpenseTracking.Abstraction;
namespace PersonalExpenseTracking.Services;

public class UserService : BaseService<User>, IUserService
{
    private static readonly string AppUsersFilePath = Const.Const.UsersFilePath();
    private List<User> _users;

    public UserService()
    {
        _users = GetAll(AppUsersFilePath);

        if (!_users.Any())
        {
            _users.Add(new User { Username = Seeding.Seeding.SeedUsername, Password = Seeding.Seeding.SeedPassword});
            SaveAll(_users, AppUsersFilePath);
        }
    }

    // login logic
    public async Task<User> Login(User user)
    {
        if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
        {
            return null;
        }

        var loggedInUser = _users.FirstOrDefault(u => u.Username == user.Username && u.Password == HashPassword(user.Password));

        return loggedInUser;
    }

    private string HashPassword(string password)
    {
        using (var sha256 = System.Security.Cryptography.SHA256.Create())
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}