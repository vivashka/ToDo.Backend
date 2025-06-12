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
    [ProducesResponseType(typeof(OperationResult<ToDoItem[]>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(OperationResult<ToDoItem[]>), StatusCodes.Status400BadRequest)]
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
    [ProducesResponseType(typeof(OperationResult<bool>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(OperationResult<bool>), StatusCodes.Status400BadRequest)]
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
    [ProducesResponseType(typeof(OperationResult<ToDoItem>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(OperationResult<ToDoItem>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetItem(Guid id)
    {
        var response = await _toDoItemService.GetItem(id);

        if (response.IsSuccess)
        {
            return Ok(response);
        }

        return BadRequest(response);
    }
    
    [HttpPut]
    [ProducesResponseType(typeof(OperationResult<bool>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(OperationResult<bool>), StatusCodes.Status400BadRequest)]
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
    [ProducesResponseType(typeof(OperationResult<bool>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(OperationResult<bool>), StatusCodes.Status400BadRequest)]
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