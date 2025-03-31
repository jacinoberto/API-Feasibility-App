using Application.DTOs.OperatorDTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/operator")]
[ApiController]
public class OperatorController(IOperatorService service) : ControllerBase
{
    private readonly IOperatorService _service = service;

    /*[HttpPost("create")]
    public async Task<IActionResult> CreateAsync(CreateOperatorDto dto)
    {
        await _service.CreateOperatorAsync(dto);
        return StatusCode(201);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetOperatorByIdAsync(Guid id)
    {
        return Ok(await _service.GetByIdAsync(id));
    }*/
    
    /// <summary>
    /// Retorna todas as operadoras cadastradas no sistema.
    /// </summary>
    /// <returns>IActionResult</returns>
    /// <response code="200">Se a consulta for realizada com sucesso.</response>
    /// <response code="404">Caso não seja encontrada nenhuma operadora cadastrada no sistema.</response>
    /// <response code="401">Se o usuário não for autenticado.</response>
    [HttpGet("all")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> GetAllOperatosAsync()
    {
        return Ok(await _service.GetAllAsync());
    }
}