using System.Threading;
using System.Threading.Tasks;
using SalesWeb.Communication.Responses.DepartmentResponses;
using SalesWeb.Domain.Entities;

namespace SalesWeb.Application.UseCases.Department.GetById
{
    public interface IGetDepartmentByIdUseCase
    {
        Task<ResponseDepartmentJson> Execute(Guid id);
    }
}
