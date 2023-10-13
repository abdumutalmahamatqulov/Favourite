using Favourite.Entities;
using Task = System.Threading.Tasks.Task;

namespace Favourite.Interface;

public interface ICourseRepository
{
    Task<List<Course>> GetAllCourse();
    Task<Course> GetById(int id);
    Task<Course>CreateCourse(Course course);
    Task<Course> UpdateCourse(int id,Course course);
    Task DeleteCourse(int id);
}
