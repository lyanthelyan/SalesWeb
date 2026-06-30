using FluentValidation;
using SalesWeb.Communication.Requests.DepartmentRequests.Register;
using SalesWeb.Exceptions;


namespace SalesWeb.Application.UseCases.Department.Register;

public class RegisterDepartmentValidator : AbstractValidator<RequestRegisterDepartmentJson>
{
    public RegisterDepartmentValidator()
    {
        RuleFor(department => department.Name).NotEmpty().WithMessage(ResourceMessagesExceptions.VALIDATION_NAME_REQUIRED);
         
    }

    
}
