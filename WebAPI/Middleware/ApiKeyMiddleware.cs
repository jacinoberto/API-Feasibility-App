﻿using Application.Interfaces;

namespace WebAPI.Middleware;

public class ApiKeyMiddleware(RequestDelegate next, IServiceProvider serviceProvider)
{
    private readonly RequestDelegate _next = next;
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    public async Task InvokeAsync(HttpContext context)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var apiKeyService = scope.ServiceProvider.GetRequiredService<IApiKeyService>();
            
            var path = context.Request.Path.Value?.ToLower();
            
            Console.WriteLine($"Middleware interceptou: {path}");
            
            if (path.StartsWith("/api/key/create") || path.StartsWith("/api/company/create"))
            {
                Console.WriteLine($"Permitindo acesso a api key");
                
                await _next(context);
                return;
            }
            
            if (!context.Request.Headers.TryGetValue("Authorization", out var apiKey))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("O token não foi fornecido.");
                return;
            }
    
            var companyId = await apiKeyService.GetCompanyIdFromApiKeyAsync(apiKey);
            context.Items["CompanyId"] = companyId;
            
            var isValid = await apiKeyService.ValidateApiKeyAsync(apiKey);
            if (!isValid)
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("Token invalido.");
                return;
            }
            
            await _next(context);
        }
        
    }
}