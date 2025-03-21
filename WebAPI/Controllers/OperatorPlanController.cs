using Application.DTOs.OperationPlanDTOs;
using Application.DTOs.OperatorDTOs;
using Application.Interfaces;
using Application.Utils.ReadCSVs.CSVs;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Util;

namespace WebAPI.Controllers;

[Route("api/operator-plan")]
[ApiController]
public class OperatorPlanController(IOperatorPlanService service, IReadCvsUtil csv) : ControllerBase
{
    private readonly IOperatorPlanService _service = service;
    private readonly IReadCvsUtil _csv = csv;

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

    /// <summary>
    /// Realiza o Upload do arquivo CSV contendo as informaçoes sobre os planos de uma ou mais operadoras. O arquivo
    /// deve conter as colunas: Operadora, Plano, Internet/Velocidade, Internet/Tipo de Velocidade e Valor.
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    [HttpPost("upload")]
    public async Task<IActionResult> UploadCsv([FromForm] ReceiverCsv file)
    {
        if (file.File == null || file.File.Length == 0)
            return BadRequest("Nenhum arquivo encontrado");
        
        using var stream = file.File.OpenReadStream();
        var plans = _csv.ReadCvsInternetPlan(stream);

        await _service.CreateAllByUploadAsync(plans.Select(
            csvReturn => new CreateOperatorPlanDto(csvReturn.PlanName, csvReturn.InternetSpeed, csvReturn.SpeedType,
                csvReturn.Value, new CreateOperatorDto(csvReturn.Operator))).ToList());
        
        return StatusCode(201);
    }
}