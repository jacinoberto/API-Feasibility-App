using Application.Interfaces;
using Application.Services;
using Application.Utils.Formatting;
using Application.Utils.Formatting.Impl;
using Application.Utils.ReadCSVs.CSVs;
using Application.Utils.ValidationErrors;
using Application.Utils.ValidationErrors.Impl;
using Domain.Interfaces;
using Infrastructure.Context;
using Infrastructure.EntityConfiguration;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = Environment.GetEnvironmentVariable("FEASIBILITY_DB_CONNECTION") 
                               ?? configuration.GetConnectionString("FeasibilityConnection") 
                               ?? string.Empty;
        
        services.AddDbContext<AppDbContext>(options =>
            options.UseMySQL(connectionString ?? string.Empty,
                b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

        var muHandlers = AppDomain.CurrentDomain.Load("Application");
        services.AddMediatR(config => config.RegisterServicesFromAssemblies(muHandlers));
        
        /*__Registering Services__*/
        services.AddScoped<IStateRepository, StateRepositoryImpl>();
        services.AddScoped<IAddressRepository, AddressRepositoryImpl>();
        services.AddScoped<ICompanyRepository, CompanyRepositoryImpl>();
        services.AddScoped<IInternetRepository, InternetRepositoryImpl>();
        services.AddScoped<IOperatorRepository, OperatorRepositoryImpl>();
        services.AddScoped<IPlanRepository, PlanRepositoryImpl>();
        services.AddScoped<ICompanyOperatorRepository, CompanyOperatorRepositoryImpl>();
        services.AddScoped<IApiKeyRepository, ApiKeyRepositoryImpl>();
        services.AddScoped<IRegionConsultationRepository, RegionConsultationRepositoryImpl>();
        services.AddScoped<IFeasibilityRepository, FeasibilityRepositoryImpl>();
        services.AddScoped<IFeasibilityTypeRepository, FeasibilityTypeRepositoryImpl>();
        services.AddScoped<IViabilityRuleRepository, ViabilityRuleRepositoryImpl>();
        services.AddScoped<IViabilityStateRepository, ViabilityStateRepositoryImpl>();
        services.AddScoped<IViabilityCityRepository, ViabilityCityRepositoryImpl>();
        
        /*__Registering Services__*/
        services.AddScoped<IStateService, StateServiceImpl>();
        services.AddScoped<IAddressService, AddressServiceImpl>();
        services.AddScoped<ICompanyService, CompanyServiceImpl>();
        services.AddScoped<IOperatorService, OperatorServiceImpl>();
        services.AddScoped<IInternetService, InternetServiceImpl>();
        services.AddScoped<IPlanService, PlanServiceImpl>();
        services.AddScoped<ICompanyOperatorService, CompanyOperatorServiceImpl>();
        services.AddScoped<IApiKeyService, ApiKeyServiceImpl>();
        services.AddScoped<IRegionConsultationService, RegionConsultationServiceImpl>();
        services.AddScoped<IFeasibilityService, FeasibilityServiceImpl>();
        
        services.AddScoped<IReadCvsUtil, ReadCsvUtil>();
        services.AddScoped<ITextFormattingUtil, TextFormattingUtil>();

        services.AddSingleton<IValidationErrorStrategy, ValidateDataInvalidError>();
        services.AddSingleton<IValidationErrorStrategy, ValidateNotFoundError>();
        services.AddSingleton<IValidationErrorStrategy, ValidateInternalErrorError>();
        
        return services;
    }
}