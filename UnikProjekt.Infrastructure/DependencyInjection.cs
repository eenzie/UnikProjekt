using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UnikProjekt.Domain.DomainService;
using UnikProjekt.Infrastructure.DomainServices;

namespace UnikProjekt.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        //TODO: INA: Fix issue with DbContect
        //services.AddDbContext<UnikDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
        //x => x.MigrationsAssembly("UnikProjekt.DatabaseMigration")));

        //HUSK at tilføje domain services her når et interface er lavet
        services.AddScoped<IUserDomainService, UserDomainService>();

        return services;
    }

}
