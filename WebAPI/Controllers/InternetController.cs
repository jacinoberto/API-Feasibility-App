using Application.DTOs.InternetDTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/internet")]
[ApiController]
public class InternetController(IInternetService service) : ControllerBase
{
    private readonly IInternetService _service = service;

    [HttpPost("create")]
    public async Task<IActionResult> CreateInternetAsync(CreateInternetDto dto)
    {
        await _service.CreateAsync(dto);
        return StatusCode(201);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetInternetByIdAsync(Guid id)
    {
        return Ok(await _service.GetByIdAsync(id));
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllInternetAsync()
    {
        return Ok(await _service.GetAllAsync());
    }
}