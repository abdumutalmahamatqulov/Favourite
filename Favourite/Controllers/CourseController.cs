using Favourite.Entities;
using Favourite.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Favourite.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CourseController : ControllerBase
{
    private readonly ICourseRepository _courseRepository;
    public CourseController(ICourseRepository courseRepository) => _courseRepository = courseRepository;
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _courseRepository.GetAllCourse());
    }
    [HttpGet("Id")]
    public async Task<IActionResult> GetById(int id) => Ok(await _courseRepository.GetById(id));
    [HttpPost]
    public async Task<IActionResult> CreateCourse(Course course) => Ok(await _courseRepository.CreateCourse(course));
    [HttpPut]
    public async Task<IActionResult> UpdateCourse(int id, Course course) => Ok(await _courseRepository.UpdateCourse(id, course));
    [HttpDelete]
    public async Task<IActionResult>DeleteCourse(int id)
    {
        await _courseRepository.DeleteCourse(id);
        return Ok();
    }
}
