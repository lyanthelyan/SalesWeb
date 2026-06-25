using SalesWeb.Communication.Requests;
using SalesWeb.Communication.Responses;

namespace SalesWeb.Application.UseCases.Department.Register;

public interface IRegisterDepartmentUseCase
{
    Task<ResponseRegisterDepartmentJson> Execute(RequestRegisterDepartmentJson request);
}
