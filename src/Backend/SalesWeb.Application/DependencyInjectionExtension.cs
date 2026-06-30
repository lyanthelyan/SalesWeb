using Microsoft.Extensions.DependencyInjection;
using SalesWeb.Application.UseCases.Department.Delete;
using SalesWeb.Application.UseCases.Department.Details;
using SalesWeb.Application.UseCases.Department.GetAll;
using SalesWeb.Application.UseCases.Department.GetById;
using SalesWeb.Application.UseCases.Department.Register;
using SalesWeb.Application.UseCases.Department.Update;
using SalesWeb.Application.UseCases.Seller.Delete;
using SalesWeb.Application.UseCases.Seller.GetAll;
using SalesWeb.Application.UseCases.Seller.GetById;
using SalesWeb.Application.UseCases.Seller.Register;
using SalesWeb.Application.UseCases.Seller.Update;

namespace SalesWeb.Application;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IRegisterDepartmentUseCase, RegisterDepartmentUseCase>();
        services.AddScoped<IGetAllDepartmentUseCase, GetAllDepartmentUseCase>();
        services.AddScoped<IRegisterSellerUseCase, RegisterSellerUseCase>();
        services.AddScoped<IGetAllSellerUseCase, GetAllSellerUseCase>();
        services.AddScoped<IDeleteSellerUseCase, DeleteSellerUseCase>();
        services.AddScoped<IGetSellerByIdUseCase, GetSellerByIdUseCase>();
        services.AddScoped<IDeleteDepartmentUseCase, DeleteDepartmentUseCase>();
        services.AddScoped<IGetDepartmentByIdUseCase, GetDepartmentByIdUseCase>();
        services.AddScoped<IUpdateSellerUseCase, UpdateSellerUseCase>();
        services.AddScoped<IUpdateDepartmentUseCase, UpdateDepartmentUseCase>();
        services.AddScoped<IGetDepartmentDetailsUseCase, GetDepartmentDetailsUseCase>();

        return services;
    }
}
