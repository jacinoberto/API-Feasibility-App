using Application.Interfaces;
using Application.Services;
using Application.Utils.ReadCSVs.CSVs;
using Domain.Interfaces;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseMySQL(configuration.GetConnectionString("FeasibilityConnection") ?? string.Empty,
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
        services.AddScoped<IOperatorPlanRepository, OperatorPlanRepositoryImpl>();
        services.AddScoped<IPlanFeasibilityRepository, PlanFeasibilityRepositoryImpl>();
        
        /*__Registering Services__*/
        services.AddScoped<IStateService, StateServiceImpl>();
        services.AddScoped<IAddressService, AddressServiceImpl>();
        services.AddScoped<ICompanyService, CompanyServiceImpl>();
        services.AddScoped<IOperatorService, OperatorServiceImpl>();
        services.AddScoped<IInternetService, InternetServiceImpl>();
        services.AddScoped<IPlanService, PlanServiceImpl>();
        services.AddScoped<IOperatorPlanService, OperatorPlanServiceImpl>();
        services.AddScoped<IPlanFeasibilityService, PlanFeasibilityServiceImpl>();
        services.AddScoped<ICompanyOperatorService, CompanyOperatorServiceImpl>();
        
        services.AddScoped<IReadCvsUtil, ReadCsvUtil>();
        
        return services;
    }
}