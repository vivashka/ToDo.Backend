using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Contracts;
using ToDo.Domain.Models;
using ToDo.Presentation.Contracts.Mappers;
using ToDo.Presentation.Models.Requests;

namespace ToDo.Presentation.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ToDoItemsController : ControllerBase
{
    private readonly IToDoItemService _toDoItemService;
    private readonly IToDoItemMapper _toDoItemMapper;

    public ToDoItemsController(IToDoItemService toDoItemService, IToDoItemMapper toDoItemMapper)
    {
        _toDoItemService = toDoItemService;
        _toDoItemMapper = toDoItemMapper;
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetItems([FromQuery] Guid userId)
    {
        var response = await _toDoItemService.GetItems(userId);

        if (response.IsSuccess)
        {
            return Ok(response);
        }

        return BadRequest(response);
    }
    
    [HttpPost]
    [Route("")]
    public async Task<IActionResult> CreateItem([FromBody] ToDoItemRequest toDoItemRequest)
    {
        var item = _toDoItemMapper.ToDoItemRequestToModel(toDoItemRequest);
        
        var response = await _toDoItemService.CreateOrUpdateItem(item);

        if (response.IsSuccess)
        {
            return Ok(response);
        }

        return BadRequest(response);
    }
    
    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetItem(Guid id)
    {
        var response = await _toDoItemService.GetItems(id);

        if (response.IsSuccess)
        {
            return Ok(response);
        }

        return BadRequest(response);
    }
    
    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> UpdateItem([FromBody] ToDoItem toDoItem)
    {
        var response = await _toDoItemService.CreateOrUpdateItem(toDoItem);

        if (response.IsSuccess)
        {
            return Ok(response);
        }

        return BadRequest(response);
    }
    
    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> DeleteItem(Guid id)
    {
        var response = await _toDoItemService.DeleteItem(id);

        if (response.IsSuccess)
        {
            return Ok(response);
        }

        return BadRequest(response);
    }
}