using Application.DTOs.FeasibilityDTO;
using Application.DTOs.PlanDTOs;
using Application.DTOs.ViabilityRuleDTOs;
using Application.Interfaces;
using Application.Utils.ReadCSVs.CSVs;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Util;

namespace WebAPI.Controllers;

[Route("api/plan")]
[ApiController]
public class PlanController(IPlanService service, IReadCvsUtil csv) : ControllerBase
{
    private readonly IPlanService _service = service;
    private readonly IReadCvsUtil _csv = csv;

    //[HttpPost("create")]
    //public async Task<IActionResult> CreatePlanAsync([FromBody] CreatePlanDto dto)
    //{
    //    await _service.CreatePlan(dto);
    //    return StatusCode(201);
    //}

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
    
    /// <summary>
    /// Upload do arquivo CSV dos planos ofertados pela empresa por estado. Os campos necessários no CSV são: Plano,
    /// Internet/Velocidade, Internet/Tipo de Velocidade, Valor e Estado/UF.
    /// </summary>
    /// <param name="file"></param>
    /// <param name="feasibilityTypeId"></param>
    /// <returns>IActionResult</returns>
    [HttpPost("upload/state")]
    public async Task<IActionResult> UploadPlanByStateAsync([FromForm] ReceiverCsv file, [FromQuery] Guid feasibilityTypeId)
    {
        if (file.File == null || file.File.Length == 0)
            return BadRequest("Nenhum arquivo encontrado");
        
        using var stream = file.File.OpenReadStream();
        var plans = _csv.ReadCvsPlanByState(stream);

        if (HttpContext.Items.TryGetValue("CompanyId", out var companyGuid))
        {
            var companyId = (Guid)companyGuid;
            await _service.CreateAllPlanByStateAsync(plans.Select(plan => new CreateViabilityRuleByStateDto(
                    plan.Plan, plan.InternetSpeed, plan.SpeedType, plan.Value, plan.State, companyId, feasibilityTypeId))
                .ToList());
        
            return StatusCode(201);
        }

        return Unauthorized("Token invalido ou inexistente!");
    }
    
    /// <summary>
    /// Upload do arquivo CSV dos planos ofertados pela empresa por cidade. Os campos necessários no CSV são: Plano,
    /// Internet/Velocidade, Internet/Tipo de Velocidade, Valor, Cidade e Estado/UF.
    /// </summary>
    /// <param name="file"></param>
    /// <param name="feasibilityTypeId"></param>
    /// <returns>IActionResult</returns>
    [HttpPost("upload/city")]
    public async Task<IActionResult> UploadPlanByCityAsync([FromForm] ReceiverCsv file, [FromQuery] Guid feasibilityTypeId)
    {
        if (file.File == null || file.File.Length == 0)
            return BadRequest("Nenhum arquivo encontrado");
        
        using var stream = file.File.OpenReadStream();
        var plans = _csv.ReadCvsPlanByCity(stream);

        if (HttpContext.Items.TryGetValue("CompanyId", out var companyGuid))
        {
            var companyId = (Guid)companyGuid;
            await _service.CreateAllPlanByCityAsync(plans.Select(plan => new CreateViabilityRuleByCityDto(
                    plan.Plan, plan.InternetSpeed, plan.SpeedType, plan.Value, plan.City, plan.State, companyId, feasibilityTypeId))
                .ToList());
        
            return StatusCode(201);
        }

        return Unauthorized("Token invalido ou inexistente!");
    }

    [HttpDelete("disable")]
    public async Task<IActionResult> DisabePlansAsync()
    {
        if (HttpContext.Items.TryGetValue("CompanyId", out var companyGuid))
        {
            var companyId = (Guid)companyGuid;
            await _service.DisablePlansAsync(companyId);
        
            return NoContent();
        } 
        
        return Unauthorized("Token invalido ou inexistente!");
    }
}