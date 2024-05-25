using NetArchTest.Rules;
using UnikProjekt.Application.Queries.DTOs;
using UnikProjekt.Domain.Entities;
using UnikProjekt.Infrastructure.Repositories;

namespace UnikProjekt.Domain.Test.ArchitectureTest;

public class ProjectReferenceTests
{
    [Fact]
    public void Domain_ShouldNotReference_Infrastructure_or_Application_or_Api()
    {
        var result = Types
            .InAssembly(typeof(User).Assembly)
            .That()
            .ResideInNamespace("UnikProjekt.Domain")
            .ShouldNot()
            .HaveDependencyOnAny("UnikProjekt.Infrastructure", "UnikProjekt.Application", "UnikProjekt.Api")
            .GetResult();

        Assert.True(result.IsSuccessful);
    }

    [Fact]
    public void Application_ShouldNotReference_Infrastructure_or_Api()
    {
        var result = Types
            .InAssembly(typeof(UserDto).Assembly)
            .That()
            .ResideInNamespace("UnikProjekt.Application")
            .ShouldNot()
            .HaveDependencyOnAny("UnikProjekt.Infrastructure", "UnikProjekt.Api")
            .GetResult();

        Assert.True(result.IsSuccessful);
    }

    [Fact]
    public void Infrastructure_ShouldNotReference_Api()
    {
        var result = Types.InAssembly(typeof(UserRepository).Assembly)
            .That()
            .ResideInNamespace("UnikProjekt.Infrastructure")
            .ShouldNot()
            .HaveDependencyOn("UnikProjekt.Api")
            .GetResult();

        Assert.True(result.IsSuccessful);
    }
}
