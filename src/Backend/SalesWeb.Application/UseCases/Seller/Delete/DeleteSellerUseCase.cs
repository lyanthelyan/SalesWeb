
using SalesWeb.Domain.Repositories;
using SalesWeb.Exceptions;
using SalesWeb.Exceptions.ExceptionBase;

namespace SalesWeb.Application.UseCases.Seller.Delete;

public class DeleteSellerUseCase : IDeleteSellerUseCase
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly ISellerRepository _repository;

    public DeleteSellerUseCase(IUnitOfWork unitOfWork, ISellerRepository repository)
    {
        _unitOfWork = unitOfWork;
        _repository = repository;
    }
    public async Task Execute(Guid id)
    {
        await ValidateSellerExists(id);
        
        await _repository.Delete(id);
        await _unitOfWork.Commit(); 
    }
    private async Task ValidateSellerExists(Guid id)
    {
        var sellerId = await _repository.GetById(id);
        
        if (sellerId is null)
            throw new NotFoundException(ResourceMessagesExceptions.VALIDATION_SELLER_NOT_FOUND);
    }
}