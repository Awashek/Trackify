using PersonalExpenseTracking.Models;

namespace PersonalExpenseTracking.Services.Interface;

public interface IUserService
{
    Task<User> Login(User user);
}