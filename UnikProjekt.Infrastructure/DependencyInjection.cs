using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UnikProjekt.Application.Commands;
using UnikProjekt.Application.Commands.Implementation;
using UnikProjekt.Application.Queries;
using UnikProjekt.Domain.DomainService;
using UnikProjekt.Infrastructure.Database;
using UnikProjekt.Infrastructure.DomainServices;
using UnikProjekt.Infrastructure.Queries;


namespace UnikProjekt.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<UnikDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
        x => x.MigrationsAssembly("UnikProjekt.DatabaseMigration")));

        //TODO: HUSK at tilføje domain services her når et interface er lavet
        services.AddScoped<IUserDomainService, UserDomainService>();
        services.AddScoped<IUserCommand, UserCommand>();
        services.AddScoped<IUserQueries, UserQueries>();
        //services.AddScoped<IUserRepository>, UserRepository>();

        return services;
    }

}
