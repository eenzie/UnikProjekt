﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UnikProjekt.Application.Commands;
using UnikProjekt.Application.Commands.Implementation;
using UnikProjekt.Application.Helpers;
using UnikProjekt.Application.Queries;
using UnikProjekt.Application.Repository;
using UnikProjekt.Domain.DomainService;
using UnikProjekt.Infrastructure.Database;
using UnikProjekt.Infrastructure.Database.EntityConfiguration;
using UnikProjekt.Infrastructure.DomainServices;
using UnikProjekt.Infrastructure.Queries;
using UnikProjekt.Infrastructure.Repositories;


namespace UnikProjekt.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<UnikDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
        x => x.MigrationsAssembly("UnikProjekt.DatabaseMigration")));

        //TODO: HUSK at tilføje domain services her når et interface er lavet
        services.AddScoped<IUserCommand, UserCommand>();
        services.AddScoped<IRoleCommand, RoleCommand>();
        services.AddScoped<IUserRoleCommand, UserRoleCommand>();
        services.AddScoped<IDocumentCommand, DocumentCommand>();
        services.AddScoped<IUserQueries, UserQueries>();
        services.AddScoped<IRoleQueries, RoleQueries>();
        services.AddScoped<IUserRoleQueries, UserRoleQueries>();
        services.AddScoped<IDocumentQueries, DocumentQueries>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IUserRoleRepository, UserRoleRepository>();
        services.AddScoped<IDocumentRepository, DocumentRepository>();
        services.AddScoped<IUserDomainService, UserDomainService>();
        services.AddScoped<IAddressDomainService, AddressDomainService>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
