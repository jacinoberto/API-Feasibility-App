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
    /// <param name="file">Arquivo</param>
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
    /// <param name="city">Cidade</param>
    /// <param name="state">Estado</param>
    /// <param name="operatorId">Identificação da Operadora</param>
    /// <returns>IActionResult</returns>/// <response code="200">Se a consulta for realizada com sucesso.</response>
    /// <response code="404">Se não for encontrado nenhum resultado com os parâmetros fornecidos."</response>
    /// <response code="401">Se o usuário não for autenticado"</response>
    [HttpGet("by-city-state")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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

    /// <summary>
    /// Consultar viabilidade através da CEP, informando a qual operadora pertence.
    /// </summary>
    /// <param name="zipCode">CEP</param>
    /// <param name="operatorId">Identificação da Operadora</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Se a consulta for realizada com sucesso.</response>
    /// <response code="404">Se não for encontrado nenhum resultado com os parâmetros fornecidos."</response>
    /// <response code="401">Se o usuário não for autenticado."</response>
    [HttpGet("by-zipcode")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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
    
    /// <summary>
    /// Consultar viabilidade através da cidade, informando a qual operadora pertence.
    /// </summary>
    /// <param name="city">Cidade</param>
    /// <param name="operatorId">Identificação da Operadora</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Se a consulta for realizada com sucesso.</response>
    /// <response code="404">Se não for encontrado nenhum resultado com os parâmetros fornecidos."</response>
    /// <response code="401">Se o usuário não for autenticado"</response>
    [HttpGet("by-city")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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