using Favourite.Entities;
using Task = System.Threading.Tasks.Task;
namespace Favourite.Interface;

public interface ILessonRepository
{
    Task<List<Lesson>> GetAllLesson();
    Task<Lesson> GetById(int id);
    Task<Lesson>CreateLesson(Lesson lesson);
    Task<Lesson> UpdateLesson(int id,Lesson lesson);
    Task DeleteLesson(int id);

}
