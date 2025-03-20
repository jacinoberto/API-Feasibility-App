using Application.DTOs.PlanDTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/plan")]
[ApiController]
public class PlanController(IPlanService service) : ControllerBase
{
    private readonly IPlanService _service = service;

    [HttpPost("create")]
    public async Task<IActionResult> CreatePlanAsync([FromBody] CreatePlanDto dto)
    {
        await _service.CreatePlan(dto);
        return StatusCode(201);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetPlanByIdAsync(Guid id)
    {
        return Ok(await _service.GetPlanByIdAsync(id));
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllPlansAsync()
    {
        return Ok(await _service.GetAllPlansAsync());
    }
}