using Mapster;
using SalesWeb.Communication.Requests.DepartmentRequests.Register;
using SalesWeb.Communication.Responses.DepartmentResponses.Register;
using SalesWeb.Domain.Extensions;
using SalesWeb.Domain.Repositories;
using SalesWeb.Exceptions;
using SalesWeb.Exceptions.ExceptionBase;

namespace SalesWeb.Application.UseCases.Department.Register;

public class RegisterDepartmentUseCase: IRegisterDepartmentUseCase
{
    private readonly IDepartmentRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    public RegisterDepartmentUseCase(IDepartmentRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseRegisterDepartmentJson> Execute(RequestRegisterDepartmentJson request)
    {
        
        await ValidateAndThrownOnFailures(request);
        request.Name = request.Name.RemoveExtraSpaces();

        var department = new Domain.Entities.Department.Department(request.Name);

        await _repository.Add(department);

        await _unitOfWork.Commit();

        return department.Adapt<ResponseRegisterDepartmentJson>();
    }

    private async Task ValidateAndThrownOnFailures(RequestRegisterDepartmentJson request)
    {
        var validator = new RegisterDepartmentValidator();
        var result = validator.Validate(request);
        var nameExist = await _repository.ExistActiveDepartmentName(request.Name);
        if (nameExist) 
        {
            result.Errors.Add(new FluentValidation.Results.ValidationFailure("Name", ResourceMessagesExceptions.VALIDATION_NAME_ALREADY_EXISTS));
        }

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();
            
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
