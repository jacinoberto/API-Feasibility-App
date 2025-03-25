using Application.DTOs.RegionConsultationDTO;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/region-consultation")]
[ApiController]
public class RegionConsultationController(IRegionConsultationService service) : ControllerBase
{
    private readonly IRegionConsultationService _service = service;

    /// <summary>
    /// Define em quais estados uma empresa pode consultar viabilidade
    /// </summary>
    /// <param name="dto"></param>
    /// <returns>IActionResult</returns>
    [HttpPost("create")]
    public async Task<IActionResult> CreateAllAsync(IEnumerable<CreateRegionConsultationDto> dto)
    {
        await _service.CreateAllAsync(dto);
        return StatusCode(201);
    }

    /// <summary>
    /// Retorna todos os estados disponíveis para consulta de viabilidade.
    /// </summary>
    /// <returns>IActionResult</returns>
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