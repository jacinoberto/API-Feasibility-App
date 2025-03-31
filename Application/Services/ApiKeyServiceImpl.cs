using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.CQRS.ApiKeyCQRS.Commands;
using Application.CQRS.ApiKeyCQRS.Queries;
using Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services;

public class ApiKeyServiceImpl(IMediator mediator, IConfiguration configuration) : IApiKeyService
{
    private readonly IMediator _mediator = mediator;
    private readonly IConfiguration _configuration = configuration;
    
    public async Task<string> CreateApiKeyAsync(Guid companyId)
    {
        var secret = _configuration["JwtSettings:Secret"];
        
        var jwtSecret = Environment.GetEnvironmentVariable("FEASIBILITY_JWT_SECRET")
                        ?? _configuration["JwtSettings:Secret"]
                        ?? throw new ArgumentException("A secret JWT está vazia.");
        
        Console.WriteLine(secret);
        if (string.IsNullOrEmpty(jwtSecret))
            throw new ArgumentException("A secret JWT está vazio.");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim("companyId", companyId.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = new JwtSecurityToken(
            _configuration["JwtSettings:Issuer"],
            _configuration["JwtSettings:Audience"],
            claims,
            expires: null,
            signingCredentials: credentials
        );
        
        return await _mediator.Send(new CreateApiKeyCommand(companyId, new JwtSecurityTokenHandler().WriteToken(token)));
    }

    public async Task<bool> ValidateApiKeyAsync(string key)
    {
        return await _mediator.Send(new IsValidApiKeyQuery(key));
    }

    public async Task<Guid> GetCompanyIdFromApiKeyAsync(string key)
    {
        var apiKey = await _mediator.Send(new ReturnApiKeyByKeyQuery(key));

        if (apiKey == null) throw new UnauthorizedAccessException("Token invalido.");

        return apiKey.CompanyId;
    }
}