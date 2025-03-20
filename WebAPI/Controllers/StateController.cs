using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/state")]
[ApiController]
public class StateController(IStateService service) : ControllerBase
{
    private readonly IStateService _service = service;

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetStateById(Guid id)
    {
        return Ok(await _service.GetStateByIdAsync(id));
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetStatesAllAsync());
    }
}