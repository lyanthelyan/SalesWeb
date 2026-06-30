using FluentValidation;
using SalesWeb.Communication.Requests;
using SalesWeb.Exceptions;

namespace SalesWeb.Application.UseCases.Seller.Update;

public class UpdateSellerValidator : AbstractValidator<RequestUpdateSellerJson>
{
    public UpdateSellerValidator()
    {
        RuleFor(seller => seller.Name)
            .NotEmpty()
            .WithMessage(ResourceMessagesExceptions.VALIDATION_NAME_REQUIRED);

        RuleFor(seller => seller.Email)
            .NotEmpty()
            .WithMessage(ResourceMessagesExceptions.VALIDATION_EMAIL_REQUIRED)
            .EmailAddress()
            .WithMessage(ResourceMessagesExceptions.VALIDATION_EMAIL_INVALID);

        RuleFor(seller => seller.BirthDate)
            .LessThan(DateTime.UtcNow)
            .WithMessage(ResourceMessagesExceptions.VALIDATION_BIRTHDATE_INVALID);

        RuleFor(seller => seller.BaseSalary)
            .GreaterThan(0)
            .WithMessage(ResourceMessagesExceptions.VALIDATION_BASESALARY_INVALID);

        RuleFor(seller => seller.DepartmentId)
            .NotEmpty()
            .WithMessage(ResourceMessagesExceptions.VALIDATION_DEPARTMENT_REQUIRED);
    }
}
