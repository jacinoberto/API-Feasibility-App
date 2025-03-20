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

    [HttpPost("create")]
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

}