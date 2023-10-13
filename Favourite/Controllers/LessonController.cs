using Favourite.Entities;
using Favourite.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Favourite.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LessonController : ControllerBase
{
    private readonly ILessonRepository _lessonRepository;
    public LessonController(ILessonRepository lessonRepository) => _lessonRepository = lessonRepository;
    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _lessonRepository.GetAllLesson());
    [HttpGet("Id")]
    public async Task<IActionResult>GetById(int id)
    {
        return Ok(await _lessonRepository.GetById(id));
    }
    [HttpPost]
    public async Task<IActionResult> CreateLesson(Lesson lesson) => Ok(await _lessonRepository.CreateLesson(lesson));
    [HttpPut]
    public async Task<IActionResult> UpdateLesson(int id, Lesson lesson) => Ok(await _lessonRepository.UpdateLesson(id, lesson));
    [HttpDelete]
    public async Task<IActionResult>DeleteLesson(int id)
    {
        await _lessonRepository.DeleteLesson(id);
        return Ok(); 
    }
}
