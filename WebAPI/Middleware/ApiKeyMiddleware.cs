using Application.Interfaces;

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
            
            if (path.StartsWith("/api/key/create"))
            {
                Console.WriteLine($"Permitindo acesso a api key");
                
                await _next(context);
                return;
            }
            
            if (!context.Request.Headers.TryGetValue("Authorization", out var apiKey))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("API key é obrigatória.");
                return;
            }

            var isValid = await apiKeyService.ValidateApiKeyAsync(apiKey);
            if (!isValid)
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("API Key inválida.");
                return;
            }
            
            await _next(context);
        }
        
    }
}