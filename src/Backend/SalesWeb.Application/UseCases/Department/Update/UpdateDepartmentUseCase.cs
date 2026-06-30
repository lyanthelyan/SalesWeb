using FluentValidation.Results;
using Mapster;
using SalesWeb.Application.UseCases.Seller.Update;
using SalesWeb.Communication.Requests.DepartmentRequests.Update;
using SalesWeb.Communication.Responses.DepartmentResponses;
using SalesWeb.Domain.Repositories;
using SalesWeb.Exceptions;
using SalesWeb.Exceptions.ExceptionBase;

namespace SalesWeb.Application.UseCases.Department.Update;

public class UpdateDepartmentUseCase : IUpdateDepartmentUseCase
{
    private readonly IDepartmentRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateDepartmentUseCase(IDepartmentRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
    public async Task<ResponseDepartmentJson> Execute(Guid id,RequestUpdateDepartmentJson request)
    {
        await ValidateAndThrowOnFailures(request, id);
        var department = await _repository.GetById(id);
        if (department is null)
            throw new NotFoundException(ResourceMessagesExceptions.VALIDATION_DEPARTMENT_NOT_FOUND);
        department.Update(request.Name);
        await _unitOfWork.Commit();

        return department.Adapt<ResponseDepartmentJson>();


    }
    private async Task ValidateAndThrowOnFailures(RequestUpdateDepartmentJson request, Guid id)
    {
        var validator = new UpdateDepartmentValidator();
        var result = validator.Validate(request);
        var nameExist = await _repository.ExistActiveDepartmentNameExceptId(request.Name, id);
        if (nameExist)
        {
            result.Errors.Add(new ValidationFailure("Name", ResourceMessagesExceptions.VALIDATION_NAME_ALREADY_EXISTS));
        }

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
