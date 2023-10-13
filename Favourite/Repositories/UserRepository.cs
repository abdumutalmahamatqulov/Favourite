using Favourite.Data;
using Favourite.Entities;
using Favourite.Interface;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace Favourite.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _Context;
    public UserRepository(AppDbContext context) => _Context = context;

    public async Task<User> CreateUser(User user)
    {
        var users = new User()
        {
            Name = user.Name,
            Email = user.Email,
            Password = user.Password,
        };
        _Context.Users.Add(users);
        await _Context.SaveChangesAsync();
        return users;
    }

    public async Task DeleteUser(int id)
    {
        var finduser = await _Context.Users.FindAsync(id);
        _Context.Users.Remove(finduser);
    }

    public async Task<List<User>> GetAllUser()
    {
        var finduser = await _Context.Users.ToListAsync();
        return finduser;
    }

    public async Task<User> GetById(int id)
    {
        var findusers = await _Context.Users.FindAsync(id);
        return findusers;
    }

    public async Task<User> UpdateUser(int id, User user)
    {
        var finduser = await _Context.Users.FindAsync(id);
        finduser.Name = user.Name;
        finduser.Email = user.Email;
        finduser.Password = user.Password;
        _Context.Users.Update(finduser);
        await _Context.SaveChangesAsync();
        return finduser;
    }
}
