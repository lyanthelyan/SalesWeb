using Mapster;
using SalesWeb.Communication.Requests;
using SalesWeb.Communication.Responses;
using SalesWeb.Domain.Extensions;
using SalesWeb.Domain.Repositories;
using SalesWeb.Exceptions;
using SalesWeb.Exceptions.ExceptionBase;

namespace SalesWeb.Application.UseCases.Seller.Register;

public class RegisterSellerUseCase : IRegisterSellerUseCase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISellerRepository _repository;

    public RegisterSellerUseCase(IUnitOfWork unitOfWork, ISellerRepository repository)
    {
        _unitOfWork = unitOfWork;
        _repository = repository;
    }

    public async Task<ResponseRegisterSellerJson> Execute(RequestRegisterSellerJson request)
    {
        await ValidateAndThrownOnFailures(request);
        
        request.Name = request.Name!.RemoveExtraSpaces();
        request.Email = request.Email!.RemoveExtraSpaces();
        
        var seller = new Domain.Entities.Seller.Seller(
            request.Name!,
            request.Email!,
            request.BirthDate!.Value,
            request.BaseSalary!.Value,
            request.DepartmentId!.Value);

        await _repository.Add(seller);
        await _unitOfWork.Commit();

        return seller.Adapt<ResponseRegisterSellerJson>();
    }

    private async Task ValidateAndThrownOnFailures(RequestRegisterSellerJson request)
    {
        var validator = new RegisterSellerValidator();
        var result = validator.Validate(request);
        var emailExist = await _repository.ExistActiveSellerEmail(request.Email);
        if (emailExist)
        {
            result.Errors.Add(new FluentValidation.Results.ValidationFailure("Email", ResourceMessagesExceptions.VALIDATION_EMAIL_ALREADY_EXISTS));
        }

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
