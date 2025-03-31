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
    /// <param name="dto">Dados para vínculo.</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Se o cadastro seja realizado com sucesso.</response>
    /// <response code="404">Caso não seja encontrado nenhum dos parãmetos informados.</response>
    /// <response code="401">Se o usuário não for autenticado.</response>
    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> CreateAsync(CreateCompanyOperatorDto dto)
    {
        await _service.CreateAsync(dto);
        return StatusCode(201);
    }

    /// <summary>
    /// Retorna todas as operadoras vinculadas a empresa que teve o ID informado.
    /// </summary>
    /// <param name="companyId"></param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Se a consulta for realizada com sucesso.</response>
    /// <response code="404">Caso não seja encontrada nenhuma empresa com o ID informado.</response>
    /// <response code="401">Se o usuário não for autenticado.</response>
    [HttpGet()]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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