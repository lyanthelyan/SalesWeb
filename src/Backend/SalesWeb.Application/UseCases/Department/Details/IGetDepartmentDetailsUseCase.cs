using SalesWeb.Communication.Responses.DepartmentResponses.Details;

namespace SalesWeb.Application.UseCases.Department.Details;

public interface IGetDepartmentDetailsUseCase
{
    Task<ResponseDepartmentDetailsJson> Execute(Guid id);
}
