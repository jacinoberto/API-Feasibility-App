using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[Route("api/key")]
[ApiController]
public class ApiKeyController(IApiKeyService service) : ControllerBase
{
    private readonly IApiKeyService _service = service;

    /// <summary>
    /// Gera Chave de Api para a empresa que teve o ID informado.
    /// </summary>
    /// <param name="companyId"></param>
    /// <returns>IActionResulr</returns>
    /// <response code="200">Se a criação da Chave de Api ocorrer com sucesso.</response>
    [HttpPost("create/{companyId:guid}")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateApiKeyAsync(Guid companyId)
    {
        return Ok(await _service.CreateApiKeyAsync(companyId));
    }
}