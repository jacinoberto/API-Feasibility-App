using Application.DTOs.CompanyDTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/company")]
[ApiController]
public class CompanyController(ICompanyService service) : ControllerBase
{
    private readonly ICompanyService _service = service;

    /// <summary>
    /// Realiza o cadastro de uma nova empresa no sistema.
    /// </summary>
    /// <param name="dto">Dados da Empresa</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Se o cadastro for realizado com sucesso.</response>
    /// <response code="400">Caso o usuário informe um dado invalido.</response>
    /// <response code="500">Caso seja informado o dado que viola as regras da aplicação.</response>
    /// <response code="401">Se o usuário não for autenticado.</response>
    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> CreateAsync([FromBody] CreateCompanyDto dto)
    {
        await _service.CreateAsync(dto);
        return StatusCode(201);
    }

    /// <summary>
    /// Retorna uma empresa pelo seu ID.
    /// </summary>
    /// <param name="id">Identificação da Empresa</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Se a consulta for realizada com sucesso.</response>
    /// <response code="404">Caso não seja encontrada nenhuma empresa com o ID informado.</response>
    /// <response code="401">Se o usuário não for autenticado.</response>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> ReturnById(Guid id)
    {
        return Ok(await _service.GetByIdAsync(id));
    }
}