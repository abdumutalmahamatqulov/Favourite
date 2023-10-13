using Favourite.Entities;
using Task = System.Threading.Tasks.Task;

namespace Favourite.Interface;

public interface IUserRepository
{
    Task<List<User>> GetAllUser();
    Task<User> GetById(int id);
    Task<User>CreateUser(User user);
    Task<User> UpdateUser(int id,User user);
    Task DeleteUser(int id);
}
