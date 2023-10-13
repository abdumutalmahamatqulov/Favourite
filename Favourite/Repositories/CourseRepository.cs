using Favourite.Data;
using Favourite.Entities;
using Favourite.Interface;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace Favourite.Repositories;
public class CourseRepository : ICourseRepository
{
    private readonly AppDbContext _Context;
    public CourseRepository(AppDbContext context) => _Context = context;

    public async Task<Course> CreateCourse(Course course)
    {
        var courses = new Course()
        {
            Name = course.Name,
            Description = course.Description,
            Price = course.Price,
        };
        _Context.Courses.Add(courses);
        await _Context.SaveChangesAsync();
        return course;
    }

    public async Task DeleteCourse(int id)
    {
        var findCourse = await _Context.Courses.FindAsync(id);
        await _Context.SaveChangesAsync();
    }

    public async Task<List<Course>> GetAllCourse()
    {
        var CourseList = await _Context.Courses.ToListAsync();
        return CourseList;
    }

    public async Task<Course> GetById(int id)
    {
        var findCourse = await _Context.Courses.FindAsync(id);
        return findCourse;
    }

    public async Task<Course> UpdateCourse(int id, Course course)
    {
        var findCourse = await _Context.Courses.FindAsync(id);
        findCourse.Name = course.Name;
        findCourse.Description = course.Description;
        findCourse.Price = course.Price;
        _Context.Courses.Update(findCourse);
        await _Context.SaveChangesAsync();
        return findCourse;
    }
}
