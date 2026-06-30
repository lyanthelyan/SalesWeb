using FluentValidation;
using SalesWeb.Communication.Requests.DepartmentRequests.Update;
using SalesWeb.Exceptions;


namespace SalesWeb.Application.UseCases.Department.Update;

public class UpdateDepartmentValidator : AbstractValidator<RequestUpdateDepartmentJson>
{
    public UpdateDepartmentValidator()
    {
        RuleFor(department => department.Name).NotEmpty().WithMessage(ResourceMessagesExceptions.VALIDATION_NAME_REQUIRED);

    }


}
