using Favourite.Data;
using Favourite.Entities;
using Favourite.Interface;
using Microsoft.EntityFrameworkCore;

namespace Favourite.Repositories;
public class TaskRepository : ITaskRepository
{
    private readonly AppDbContext _Context;
    public TaskRepository(AppDbContext context) => _Context = context;

    public async Task<Entities.Task> CreateTask(Entities.Task task)
    {
        var tasks = new Entities.Task();
        tasks.Name = task.Name;
        tasks.Title = task.Title;
        tasks.DedLine = task.DedLine;


        await _Context.Tasks.AddAsync(tasks);
        await _Context.SaveChangesAsync();
        return task;
    }

    public async System.Threading.Tasks.Task DeleteTask(int id)
    {
        var findTask = await _Context.Tasks.FindAsync(id);
        await _Context.SaveChangesAsync();
    }

    public async Task<List<Entities.Task>> GetAllTask()
    {
        var taskList = await _Context.Tasks.ToListAsync();
        return taskList;
    }

    public async Task<Entities.Task> GetById(int id)
    {
        var findTask = await _Context.Tasks.FindAsync(id);
        return findTask;
    }

    public async Task<Entities.Task> updateTask(int id, Entities.Task task)
    {
        var findTask = await _Context.Tasks.FindAsync(id);
        findTask.Name = task.Name;
        findTask.Title = task.Title;
        findTask.DedLine = task.DedLine;
        _Context.Tasks.Update(findTask);
        await _Context.SaveChangesAsync();
        return findTask;
    }
}
