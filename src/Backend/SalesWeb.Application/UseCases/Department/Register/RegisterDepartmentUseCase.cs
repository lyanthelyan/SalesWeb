using Mapster;
using SalesWeb.Communication.Requests;
using SalesWeb.Domain.Repositories;
using SalesWeb.Exceptions.ExceptionBase;

namespace SalesWeb.Application.UseCases.Department.Register;

public class RegisterDepartmentUseCase
{
    private readonly IDepartmentRepository _repository;
    public RegisterDepartmentUseCase(IDepartmentRepository repository)
    {
        _repository = repository;
    }

    public void Execute(RequestRegisterDepartmentJson request)
    {
        ValidateAndThrownOnFailures(request);
        var department = request.Adapt<Domain.Entities.Department.Department>();
        _repository.Add(department);
    }

    public void ValidateAndThrownOnFailures(RequestRegisterDepartmentJson request)
    {
        var validator = new RegisterDepartmentValidator();
        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();
            
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
