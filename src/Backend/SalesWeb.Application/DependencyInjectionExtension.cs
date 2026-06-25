using Microsoft.Extensions.DependencyInjection;
using SalesWeb.Application.UseCases.Department.GetAll;
using SalesWeb.Application.UseCases.Department.Register;
using SalesWeb.Application.UseCases.Seller.GetAll;
using SalesWeb.Application.UseCases.Seller.Register;

namespace SalesWeb.Application;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IRegisterDepartmentUseCase, RegisterDepartmentUseCase>();
        services.AddScoped<IGetAllDepartmentUseCase, GetAllDepartmentUseCase>();
        services.AddScoped<IRegisterSellerUseCase, RegisterSellerUseCase>();
        services.AddScoped<IGetAllSellerUseCase, GetAllSellerUseCase>();

        return services;
    }
}
