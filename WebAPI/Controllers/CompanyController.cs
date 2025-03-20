using Application.DTOs.CompanyDTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/company")]
[ApiController]
public class CompanyController(ICompanyService service) : ControllerBase
{
    private readonly ICompanyService _service = service;

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync([FromBody] CreateCompanyDto dto)
    {
        await _service.CreateAsync(dto);
        return StatusCode(201);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> ReturnById(Guid id)
    {
        return Ok(await _service.GetByIdAsync(id));
    }
}