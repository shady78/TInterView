using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TInterView.Application.DTOs.Request;
using TInterView.Application.DTOs.Response;
using TInterView.Application.Interfaces;

namespace TInterView.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppTasksController : ControllerBase
{
    private readonly ITaskService _taskService;

    public AppTasksController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(TaskResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TaskResponse>> Post([FromBody] CreateAppTaskRequest request)
    {
        var result = await _taskService.CreateTaskAsync(request);
        return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
    }


    [HttpGet]
    [ProducesResponseType(typeof(PagedResponse<TaskResponse>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PagedResponse<TaskResponse>>> Get([FromQuery] AppTaskFilterRequest filter)
    {
        var result = await _taskService.GetTasksAsync(filter);
        return Ok(result);
    }


    [HttpGet("{id}")]
    [ProducesResponseType(typeof(TaskResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TaskResponse>> Get(int id)
    {
        var result = await _taskService.GetTaskByIdAsync(id);

        if (result is null)
            return NotFound(new { message = $"Task with ID {id} not found" });

        return Ok(result);
    }


    [HttpPut("{id}")]
    [ProducesResponseType(typeof(TaskResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TaskResponse>> Update(int id, [FromBody] UpdateAppTaskRequest request)
    {
        var result = await _taskService.UpdateTaskAsync(id, request);

        if (result is null)
            return NotFound(new { message = $"Task with ID {id} not found" });

        return Ok(result);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _taskService.DeleteTaskAsync(id);

        if (!success)
            return NotFound(new { message = $"Task with ID {id} not found" });

        return NoContent();
    }
}
