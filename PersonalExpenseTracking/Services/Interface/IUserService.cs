using PersonalExpenseTracking.Models;

namespace PersonalExpenseTracking.Services.Interface;

public interface IUserService
{
    // Logs in a user. Returns true if login is successful, false otherwise.
    Task<User> Login(User user);

    // Retrieves a list of all registered users.

}