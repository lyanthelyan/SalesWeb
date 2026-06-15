using Microsoft.Extensions.DependencyInjection;
using SalesWeb.Application.UseCases.Department.GetAll;
using SalesWeb.Application.UseCases.Department.Register;

namespace SalesWeb.Application;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IRegisterDepartmentUseCase, RegisterDepartmentUseCase>();
        services.AddScoped<IGetAllDepartmentUseCase, GetAllDepartmentUseCase>();

        return services;
    }
}
