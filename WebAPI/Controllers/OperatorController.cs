using Application.DTOs.OperatorDTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/operator")]
[ApiController]
public class OperatorController(IOperatorService service) : ControllerBase
{
    private readonly IOperatorService _service = service;

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(CreateOperatorDto dto)
    {
        await _service.CreateOperatorAsync(dto);
        return StatusCode(201);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetOperatorByIdAsync(Guid id)
    {
        return Ok(await _service.GetByIdAsync(id));
    }
    
    [HttpGet("all")]
    public async Task<IActionResult> GetAllOperatosAsync()
    {
        return Ok(await _service.GetAllAsync());
    }
}