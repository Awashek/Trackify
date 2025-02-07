using PersonalExpenseTracking.Models;

namespace PersonalExpenseTracking.Services.Interface;

public interface IUserService
{
    bool Login(User user);

    // Registers a new user with the given details.
    // Returns true if the registration is successful, or false if the username already exists.
    bool Register(User user);

    // Deletes a user identified by their username.
    // Returns true if the user is successfully deleted, or false if the user does not exist.
    bool DeleteUser(string username);
    List<User> GetAllUsers();
}

