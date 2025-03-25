using Application.DTOs.RegionConsultationDTO;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/region-consultation")]
[ApiController]
public class RegionConsultationController(IRegionConsultationService service) : ControllerBase
{
    private readonly IRegionConsultationService _service = service;

    [HttpPost("create")]
    public async Task<IActionResult> CreateAllAsync(IEnumerable<CreateRegionConsultationDto> dto)
    {
        await _service.CreateAllAsync(dto);
        return StatusCode(201);
    }

    [HttpGet("regions")]
    public async Task<IActionResult> GetRegionsByCompanyIdAsync()
    {
        if (HttpContext.Items.TryGetValue("CompanyId", out var companyGuid))
        {
            var companyId = (Guid)companyGuid;
            return Ok(await _service.GetByCompanyIdAsync(companyId));
        }
        return Unauthorized("Token invalido.");
    }
}