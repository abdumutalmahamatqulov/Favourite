using Favourite.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Favourite.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TaskController : ControllerBase
{
    private readonly ITaskRepository _taskRepository;

    public TaskController(ITaskRepository taskRepository) => _taskRepository = taskRepository;
    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _taskRepository.GetAllTask());
    [HttpGet("Id")]
    public async Task<IActionResult>GetById(int id)
    {
        return Ok(await _taskRepository.GetById(id));
    }
    [HttpPost]
    public async Task<IActionResult> CreateTask(Entities.Task task) => Ok(await _taskRepository.CreateTask(task));
    [HttpPut]
    public async Task<IActionResult> UpdateTask(int id, Entities.Task task)
    {
        return Ok(await _taskRepository.updateTask(id, task));
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteTask(int id)
    {
        await _taskRepository.DeleteTask(id);
        return Ok();
    }
}
