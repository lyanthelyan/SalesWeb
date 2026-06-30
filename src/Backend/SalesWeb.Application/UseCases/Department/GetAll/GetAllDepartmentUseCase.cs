using Mapster;
using SalesWeb.Communication.Responses.DepartmentResponses;
using SalesWeb.Domain.Repositories;

namespace SalesWeb.Application.UseCases.Department.GetAll;

public class GetAllDepartmentUseCase : IGetAllDepartmentUseCase
{
    private readonly IDepartmentRepository _repository;

    public GetAllDepartmentUseCase(IDepartmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ResponseDepartmentJson>> Execute()
    {
        var departments = await _repository.GetAll();

        return departments.Adapt<List<ResponseDepartmentJson>>();
    }
}