﻿using Application.DTOs;
using Application.Interfaces;
using Application.Utils.ReadCSVs.CSVs;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Util;

namespace WebAPI.Controllers;

[Route("api/feasibility")]
[ApiController]
public class PlanFeasibilityController(IPlanFeasibilityService service, IReadCvsUtil csv) : ControllerBase
{
    private readonly IPlanFeasibilityService _service = service;
    private readonly IReadCvsUtil _csv = csv;

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(CreatePlanFeasibilityDto dto)
    {
        await _service.CreateAsync(dto);
        return StatusCode(201);
    }

    /// <summary>
    /// Consulta a viabilidade de uma empresa através da cidade e estado - UF.
    /// </summary>
    /// <param name="city"></param>
    /// <param name="state"></param>
    /// <param name="companyId"></param>
    /// <returns></returns>
    [HttpGet("by-city-and-state/{companyId:guid}")]
    public async Task<IActionResult> GetByCityAndStateAsync([FromQuery] string city, [FromQuery] string state,
        Guid companyId)
    {
        return Ok(await _service.GetByCityAndStateAsync(city, state, companyId));
    }
    
    /// <summary>
    /// Consulta viabilidade de uma empresa através do CEP.
    /// </summary>
    /// <param name="zipCode"></param>
    /// <param name="companyId"></param>
    /// <returns></returns>
    [HttpGet("by-zipcode/{companyId:guid}")]
    public async Task<IActionResult> GetByZipCodeAsync([FromQuery] string zipCode, Guid companyId)
    {
        return Ok(await _service.GetByZipCodeAsync(companyId, zipCode));
    }
    
    /// <summary>
    /// Consulta a viabilidade de uma empresa através da cidade.
    /// </summary>
    /// <param name="city"></param>
    /// <param name="companyId"></param>
    /// <returns></returns>
    [HttpGet("by-city/{companyId:guid}")]
    public async Task<IActionResult> GetByCityAsync([FromQuery] string city, Guid companyId)
    {
        return Ok(await _service.GetByZipCodeAsync(companyId, city));
    }

    //[HttpGet("by-parameters")]
    //public async Task<IActionResult> GetByParametersAsync([FromQuery] string? zipCode, [FromQuery] string? city, [FromQuery] string? state)
    //{
    //    return Ok(await _service.GetByParametersAsync(zipCode, city, state));
    //}
    
    /// <summary>
    /// Realiza o Upload do arquivo CSV contendo as informaçoes sobre os planos de uma ou mais operadoras. O arquivo
    /// deve conter as colunas: Operadora, Plano, Valor, Internet/Velocidade, Internet/Tipo de Velocidade, CEP, Rua,
    /// Número, Bairro, Cidade, Estado/UF.
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    [HttpPost("upload")]
    public async Task<IActionResult> UploadCsv([FromForm] ReceiverCsv file)
    {
        if (file.File == null || file.File.Length == 0)
            return BadRequest("Nenhum arquivo encontrado");
        
        using var stream = file.File.OpenReadStream();
        var plans = _csv.ReadCvsPlanFeasibility(stream);

        await _service.CreateAllAsync(plans.Select(
            csvReturn => new CreatePlanFeasibilityDto(csvReturn.Operator, csvReturn.PlanName,
                csvReturn.InternetSpeed, csvReturn.SpeedType,
                csvReturn.Value, csvReturn.ZipCode, csvReturn.Street, csvReturn.Number,
                csvReturn.Area, csvReturn.City, csvReturn.State)).ToList());
        
        return StatusCode(201);
    }
}