using FluentValidation.Results;
using Mapster;
using SalesWeb.Communication.Requests;
using SalesWeb.Communication.Responses.SellerResponses;
using SalesWeb.Domain.Repositories;
using SalesWeb.Exceptions;
using SalesWeb.Exceptions.ExceptionBase;

namespace SalesWeb.Application.UseCases.Seller.Update;

public class UpdateSellerUseCase : IUpdateSellerUseCase
{
    private readonly ISellerRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSellerUseCase(
        ISellerRepository repository,
        IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseSellerJson> Execute(Guid id, RequestUpdateSellerJson request)
    {
        await ValidateAndThrowOnFailures(request, id);
        var seller = await _repository.GetById(id);

        if (seller is null)
            throw new NotFoundException(ResourceMessagesExceptions.VALIDATION_SELLER_NOT_FOUND);

        seller.Update(
            request.Name,
            request.Email,
            request.BirthDate,
            request.BaseSalary,
            request.DepartmentId);

        await _unitOfWork.Commit();

        return seller.Adapt<ResponseSellerJson>();
    }

    private async Task ValidateAndThrowOnFailures(RequestUpdateSellerJson request, Guid id)
    {
        var validator = new UpdateSellerValidator();
        var result = validator.Validate(request);
        var emailExist = await _repository.ExistActiveSellerEmailExceptId(request.Email!,id);
        if (emailExist)
        {
            result.Errors.Add(new ValidationFailure("Email", ResourceMessagesExceptions.VALIDATION_EMAIL_ALREADY_EXISTS));
        }

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}