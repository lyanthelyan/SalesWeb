using SalesWeb.Communication.Requests.DepartmentRequests.Update;
using SalesWeb.Communication.Responses.DepartmentResponses;

namespace SalesWeb.Application.UseCases.Department.Update;

public interface IUpdateDepartmentUseCase
{
    Task<ResponseDepartmentJson> Execute(Guid id, RequestUpdateDepartmentJson request);
}
