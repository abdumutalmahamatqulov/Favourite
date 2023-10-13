using Favourite.Entities;
using Favourite.Interface;
using Favourite.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Favourite.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    public readonly IUserRepository _userRepository;
    public UserController(IUserRepository userRepository) => _userRepository = userRepository;
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _userRepository.GetAllUser());
    }
    [HttpGet("Id")]
    public async Task<IActionResult> GetById(int id) => Ok(await _userRepository.GetById(id));
    [HttpPost]
    public async Task<IActionResult> CreateUser(User user) => Ok(await _userRepository.CreateUser(user));
    [HttpPut]
    public async Task<IActionResult> UpdateUser(int id, User user) => Ok(await _userRepository.UpdateUser(id, user));
    [HttpDelete]
    public async Task<IActionResult>DeleteUser(int id)
    {
        await _userRepository.DeleteUser(id);
        return Ok();
    }
}
