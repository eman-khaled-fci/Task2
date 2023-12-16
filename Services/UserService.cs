namespace WebApi.Services;

using WebApi.Entities;
using WebApi.Models;


public interface IUserService
{
    Task<User> AuthenticateLogin(AuthenticateLoginModel model);

    Task<User> AuthenticateRegister(AuthenticateRegisterModel model);
    Task<IEnumerable<User>> GetAll();
}

public class UserService : IUserService
{

    private static readonly object _lockObject = new object();
    private static readonly UserService _instance = new UserService();

    public static UserService Instance => _instance;  // singleton

    // users hardcoded for simplicity
    private static List<User> _users = new List<User>
    {
        new User { Id = 1, FirstName = "Test", LastName = "User", Username = "test", Password = "test" }
    };

    public async Task<User> AuthenticateLogin(AuthenticateLoginModel model)
    {

        var user = await Task.Run(() => _users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password));

        // on auth fail: null is returned because user is not found
        // on auth success: user object is returned
        return user;
    }

    public async Task<User> AuthenticateRegister(AuthenticateRegisterModel model)
    {
        lock (_lockObject)
        {
            // Check if the username is already taken
            if (_users.Any(u => u.Username == model.Username))
            {
                throw new ApplicationException("Username is already taken");
            }

            // Create a new user
            var newUser = new User
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Username = model.Username,
                Password = model.Password
            };

            // Add the new user to the list
            _users.Add(newUser);

            // Return the newly registered user
            return newUser;
        }
    }



    public async Task<IEnumerable<User>> GetAll()
    {

        return await Task.Run(() => _users);
    }
}
