using SalesWeb.Communication.Requests;

namespace SalesWeb.Application.UseCases.Department.Register;

public interface IRegisterDepartmentUseCase
{
    void Execute(RequestRegisterDepartmentJson request);
}
