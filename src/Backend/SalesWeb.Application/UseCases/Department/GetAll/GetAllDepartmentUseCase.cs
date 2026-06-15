using SalesWeb.Communication.Responses;
using SalesWeb.Domain.Repositories;

namespace SalesWeb.Application.UseCases.Department.GetAll;

public class GetAllDepartmentUseCase : IGetAllDepartmentUseCase
{
    private readonly IDepartmentRepository _repository;
    public GetAllDepartmentUseCase(IDepartmentRepository repository)
    {
        _repository = repository;
    }

    public List<ResponseDepartmentJson> Execute()
    {
        var departments =  _repository.GetAll();
        return departments.Select(department => new ResponseDepartmentJson
        {
            Id = department.Id,
            Name = department.Name
        }).ToList();

    }   
}
