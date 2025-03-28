using Application.DTOs;
using Application.DTOs.FeasibilityDTO;
using Application.Services;
using Application.Utils.ReadCSVs.CSVs;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Util;

namespace WebAPI.Controllers;

[Route("api/feasibility")]
[ApiController]
public class FeasibilityController(IFeasibilityService service, IReadCvsUtil csv) : ControllerBase
{
    private readonly IFeasibilityService _service = service;
    private readonly IReadCvsUtil _csv = csv;
    
    /// <summary>
    /// Upload do arquivo CSV que contem as viabilidades de uma ou mais operadoras. Esse arquivo deve conter as seguintes
    /// colunas: Operadora, CEP, Rua, Numero, Bairro, Cidade e Estado/UF.
    /// </summary>
    /// <param name="file"></param>
    /// <returns>IActionResult</returns>
    [HttpPost("upload")]
    public async Task<IActionResult> UploadFeasibilityAsync([FromForm] ReceiverCsv file)
    {
        if (file.File == null || file.File.Length == 0)
            return BadRequest("Nenhum arquivo encontrado");
        
        using var stream = file.File.OpenReadStream();
        var plans = _csv.ReadCvsPlanFeasibility(stream);

        await _service.CreateAllAsync(plans.Select(plan => new CreateFeasibilityDto(plan.Operator, plan.ZipCode,
                plan.Street, plan.Number, plan.Area, plan.City, plan.State))
            .ToList());
        
        return StatusCode(201);
    }
    
    /// <summary>
    /// Consultar viabilidade através da cidade e estado, informando a qual operadora pertence.
    /// </summary>
    /// <param name="city"></param>
    /// <param name="state"></param>
    /// <param name="operatorId"></param>
    /// <returns></returns>
    [HttpGet("by-city-state")]
    public async Task<IActionResult> GetByCityAndState([FromQuery] string city, [FromQuery] string state, [FromQuery] Guid operatorId)
    {
        if (HttpContext.Items.TryGetValue("CompanyId", out var companyGuid))
        {
            var companyId = (Guid)companyGuid;
            var results = await _service.GetByCityAndStateAsync(city, state, companyId, operatorId);
            return Ok(results);
        }

        return Unauthorized("Token invalido.");
    }

    [HttpGet("by-zipcode")]
    public async Task<IActionResult> GetByZipCode([FromQuery] string zipCode, [FromQuery] Guid operatorId)
    {
        if (HttpContext.Items.TryGetValue("CompanyId", out var companyGuid))
        {
            var companyId = (Guid)companyGuid;
            var result = await _service.GetByZipCodeAsync(zipCode, companyId, operatorId);
            return Ok(result.ToList());
        }

        return Unauthorized("Token invalido.");
    }
    
    [HttpGet("by-city")]
    public async Task<IActionResult> GetByCity([FromQuery] string city, [FromQuery] Guid operatorId)
    {
        if (HttpContext.Items.TryGetValue("CompanyId", out var companyGuid))
        {
            var companyId = (Guid)companyGuid;
            return Ok(await _service.GetByCityAsync(city, companyId, operatorId));
        }

        return Unauthorized("Token invalido.");
    }
}