using Application.DTOs.OperationPlanDTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/operator-plan")]
[ApiController]
public class OperatorPlanController(IOperatorPlanService service) : ControllerBase
{
    private readonly IOperatorPlanService _service = service;

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(CreateOperatorPlanDto dto)
    {
        await _service.CreateAsync(dto);
        return StatusCode(201);
    }

    [HttpGet("by-operator-id/{operatorId:guid}")]
    public async Task<IActionResult> GetByOperatorIdAsync(Guid operatorId)
    {
        return Ok(await _service.GetPlansByOperatorIdAsync(operatorId));
    }
}