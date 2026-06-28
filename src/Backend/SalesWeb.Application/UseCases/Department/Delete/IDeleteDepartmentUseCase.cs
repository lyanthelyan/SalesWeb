using System;
using System.Threading.Tasks;

namespace SalesWeb.Application.UseCases.Department.Delete
{
    public interface IDeleteDepartmentUseCase
    {
        Task Execute(Guid id);
    }
}
