using Task = System.Threading.Tasks.Task;
using Tasks = Favourite.Entities.Task;

namespace Favourite.Interface;
public interface ITaskRepository
{
    Task<List<Tasks>> GetAllTask();
    Task<Tasks> GetById(int id);
    Task<Tasks> CreateTask(Tasks task);
    Task<Tasks> updateTask(int id, Tasks task);
    Task DeleteTask(int id);
}
