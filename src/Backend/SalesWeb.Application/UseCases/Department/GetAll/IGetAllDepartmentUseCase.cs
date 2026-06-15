using SalesWeb.Communication.Responses;

namespace SalesWeb.Application.UseCases.Department.GetAll;

public interface IGetAllDepartmentUseCase
{
    List<ResponseDepartmentJson> Execute();
}
