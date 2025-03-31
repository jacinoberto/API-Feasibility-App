using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/state")]
[ApiController]
public class StateController(IStateService service) : ControllerBase
{
    private readonly IStateService _service = service;

    /*[HttpGet("{id:guid}")]
    public async Task<IActionResult> GetStateById(Guid id)
    {
        return Ok(await _service.GetStateByIdAsync(id));
    }*/
    
    /// <summary>
    /// Retorna todos os estados.
    /// </summary>
    /// <returns>IActionResult</returns>
    /// <response code="200">Se a consulta for realizada com sucesso.</response>
    /// <response code="404">Se não for encontrado nenhum estado cadastrado no sistema.</response>
    /// <response code="401">Se o usuário não for autenticado.</response>
    [HttpGet("all")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetStatesAllAsync());
    }
}