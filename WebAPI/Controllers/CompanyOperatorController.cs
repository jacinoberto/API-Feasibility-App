using Application.DTOs.CompanyOperatorDTOs;
using Application.Interfaces;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/company-operator")]
[ApiController]
public class CompanyOperatorController(ICompanyOperatorService service) : ControllerBase
{
    private readonly ICompanyOperatorService _service = service;
    
    /// <summary>
    /// Vincula uma empresa a uma operadora.
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(CreateCompanyOperatorDto dto)
    {
        await _service.CreateAsync(dto);
        return StatusCode(201);
    }

    /// <summary>
    /// Retorna todas as operadoras vinculadas a empresa que teve o ID informado.
    /// </summary>
    /// <param name="companyId"></param>
    /// <returns></returns>
    [HttpGet("by-company-id")]
    public async Task<IActionResult> GetByCompanyIdAsync()
    {
        if (HttpContext.Items.TryGetValue("CompanyId", out var companyGuid))
        {
            var companyId = (Guid)companyGuid;
            return Ok(await _service.GetByCompanyIdAsync(companyId));
        }
        return Unauthorized("Token invalido.");
    }
}