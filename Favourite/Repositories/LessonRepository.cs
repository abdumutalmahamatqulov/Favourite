using Favourite.Data;
using Favourite.Entities;
using Favourite.Interface;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace Favourite.Repositories;
public class LessonRepository : ILessonRepository
{
    private readonly AppDbContext _Context;
    public LessonRepository(AppDbContext context) => _Context = context;

    public async Task<Lesson> CreateLesson(Lesson lesson)
    {
        var lessons = new Lesson() { Name = lesson.Name, Number = lesson.Number, Title = lesson.Title, };
        _Context.Lessons.Add(lessons);
        await _Context.SaveChangesAsync();
        return lessons;
    }

    public async Task DeleteLesson(int id)
    {
        var findLesson = await _Context.Lessons.FindAsync(id);
        await _Context.SaveChangesAsync();
    }

    public async Task<List<Lesson>> GetAllLesson()
    {
        var LessonList = await _Context.Lessons.ToListAsync();
        return LessonList;
    }

    public async Task<Lesson> GetById(int id)
    {
        var findLesson = await _Context.Lessons.FindAsync(id);
        return findLesson;
    }

    public async Task<Lesson> UpdateLesson(int id, Lesson lesson)
    {
        var findLesson = await _Context.Lessons.FindAsync(id);
        findLesson.Title = lesson.Title;
        findLesson.Name = lesson.Name;
        findLesson.Number = lesson.Number;
        _Context.Lessons.Update(findLesson);
        await _Context.SaveChangesAsync();
        return findLesson;
    }
}
