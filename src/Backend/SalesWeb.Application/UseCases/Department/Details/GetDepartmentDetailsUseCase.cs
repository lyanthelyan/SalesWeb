using Mapster;
using SalesWeb.Communication.Responses.DepartmentResponses.Details;
using SalesWeb.Domain.Repositories;
using SalesWeb.Exceptions;

namespace SalesWeb.Application.UseCases.Department.Details;

public class GetDepartmentDetailsUseCase : IGetDepartmentDetailsUseCase
{
    private readonly IDepartmentRepository _repository;
    public GetDepartmentDetailsUseCase(IDepartmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResponseDepartmentDetailsJson> Execute(Guid id)
    {
        var department = await _repository.GetDetailsById(id);
        if (department is null)
        {
            throw new NotFoundException(
            ResourceMessagesExceptions.VALIDATION_DEPARTMENT_NOT_FOUND);
        }
        return department.Adapt<ResponseDepartmentDetailsJson>();
    }
}
