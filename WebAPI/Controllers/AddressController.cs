using Application.DTOs.AddressDTOs;
using Application.Interfaces;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/address")]
[ApiController]
public class AddressController(IAddressService service) : ControllerBase
{
    private readonly IAddressService _service = service;

    
    /*/// <summary>
    ///  Cadastrar um novo endereço
    /// </summary>
    /// <param name="Address"></param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso o cadastro ocorra com sucesso.</response>
    /// <response code="400">Caso o cliente preencha o cadastro com algum dado invalido ou fora dos parâmetros.</response>
    /// <response code="401">Se o usuário tiver o login recusado ou Chave de Api invalida.</response>
    /// <response code="403">Se o usuário não tiver permissão de acesso a requisição</response>
    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> CreateAddressAsync(CreateAddressDto dto)
    {
        await _service.CreateAddressAsync(dto);
        return StatusCode(201);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetAddressByIdAsync(Guid id)
    {
        return Ok(await _service.GetAddressByIdAsync(id));
    }

    /// <summary>
    /// Retorna todas as cidades de um determinado estado
    /// </summary>
    /// <param name="state">Estado/UF</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Se a consulta for realizada com sucesso.</response>
    /// <response code="404">Caso não seja encontrada nenhuma cidade para o estado informado.</response>
    /// <response code="401">Caso o usuário não tenha sido autenticado.</response>
    [HttpGet("cities")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> GetByStateAsync(string state)
    {
        return Ok(_service.GetCitiesAsync(state));
    }*/
}