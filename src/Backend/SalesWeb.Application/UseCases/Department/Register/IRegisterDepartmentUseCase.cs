using SalesWeb.Communication.Requests.DepartmentRequests.Register;
using SalesWeb.Communication.Responses.DepartmentResponses.Register;

namespace SalesWeb.Application.UseCases.Department.Register;

public interface IRegisterDepartmentUseCase
{
    Task<ResponseRegisterDepartmentJson> Execute(RequestRegisterDepartmentJson request);
}
