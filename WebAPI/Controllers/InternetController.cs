using Application.DTOs.InternetDTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/internet")]
[ApiController]
public class InternetController(IInternetService service) : ControllerBase
{
    private readonly IInternetService _service = service;

    /*[HttpPost("create")]
    public async Task<IActionResult> CreateInternetAsync(CreateInternetDto dto)
    {
        await _service.CreateAsync(dto);
        return StatusCode(201);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetInternetByIdAsync(Guid id)
    {
        return Ok(await _service.GetByIdAsync(id));
    }*/

    
    /// <summary>
    /// Retorna todas as velocidades de Internet disponíveis até o momento no sistema.
    /// </summary>
    /// <returns>IActionResult</returns>
    /// <response code="200">Se a consulta for realizada com sucesso.</response>
    /// <response code="404">Caso não seja encontado nenhuma velocidade de internet cadastrado no sistema.</response>
    /// <response code="401">Se o usuário não for autenticado.</response>
    [HttpGet("all")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> GetAllInternetAsync()
    {
        return Ok(await _service.GetAllAsync());
    }
}