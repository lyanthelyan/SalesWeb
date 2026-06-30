using SalesWeb.Communication.Responses.DepartmentResponses;

namespace SalesWeb.Application.UseCases.Department.GetAll;

public interface IGetAllDepartmentUseCase
{
     Task<List<ResponseDepartmentJson>> Execute();
}
