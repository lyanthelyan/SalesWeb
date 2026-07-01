using SalesWeb.Communication.Requests.DepartmentRequests.Register;

namespace SalesWeb.Application.UseCases.Department.Register;

public interface IRegisterDepartmentUseCase
{
    Task Execute(RequestRegisterDepartmentJson request);
}
