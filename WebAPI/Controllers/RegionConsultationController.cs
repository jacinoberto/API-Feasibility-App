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
    /// <param name="dto">Dados para vículo entre a empresa os estados.</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Se o vinculo for realizado com sucesso.</response>
    /// <response code="404">Se algum parâmetro informado não for encontrado no sistema.</response>
    /// <response code="401">Se usuário não for autenticado.</response>
    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> CreateAllAsync(IEnumerable<CreateRegionConsultationDto> dto)
    {
        await _service.CreateAllAsync(dto);
        return StatusCode(201);
    }

    /// <summary>
    /// Retorna todos os estados disponíveis para consulta de viabilidade de uma determinada empresa.
    /// </summary>
    /// <returns>IActionResult</returns>
    /// <response code="200">Se a consulta for realizada com sucesso.</response>
    /// <response code="404">Se não for encontrado nenhum vínculo com a empresa informada.</response>
    /// <response code="401">Se o usuário não for autenticado</response>
    [HttpGet("regions")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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