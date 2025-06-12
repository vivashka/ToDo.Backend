using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Contracts;
using ToDo.Domain.Models;
using ToDo.Presentation.Contracts.Mappers;
using ToDo.Presentation.Models.Requests;
using ToDo.Shared.OperationResult;

namespace ToDo.Presentation.Controllers;


[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    
    private readonly IUserMapper _userMapper;

    public UserController(IUserService userService, IUserMapper userMapper)
    {
        _userService = userService;
        _userMapper = userMapper;
    }

    [HttpPost]
    [Route("register")]
    [ProducesResponseType(typeof(OperationResult<User>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(OperationResult<User>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register(RegisterRequest registerRequest)
    {
        var user = _userMapper.RegisterRequestToUser(registerRequest);

        var response = await _userService.Register(user);

        if (response.IsSuccess)
        {
            return Ok(response);
        }

        return BadRequest(response);
    }
    
    [HttpPost]
    [Route("auth")]
    [ProducesResponseType(typeof(OperationResult<User>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(OperationResult<User>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Authenticate(string login, string password)
    {
        var response = await _userService.Authenticate(login, password);

        if (response.IsSuccess)
        {
            return Ok(response);
        }

        return BadRequest(response);
    }
}