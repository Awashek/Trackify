using PersonalExpenseTracking.Models;

namespace PersonalExpenseTracking.Services.Interface;

public interface IUser
{
    bool Login(User user);
}

