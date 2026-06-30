using Mapster;
using SalesWeb.Communication.Responses.SellerResponses;
using SalesWeb.Domain.Repositories;
using SalesWeb.Exceptions;

namespace SalesWeb.Application.UseCases.Seller.GetById;

    public class GetSellerByIdUseCase : IGetSellerByIdUseCase
    {
        private readonly ISellerRepository _repository;

        public GetSellerByIdUseCase(ISellerRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseSellerJson> Execute(Guid id)
        {
            var seller = await _repository.GetById(id);
            if (seller is null)
            {
                throw new NotFoundException(
                ResourceMessagesExceptions.VALIDATION_SELLER_NOT_FOUND);
            }
            return seller.Adapt<ResponseSellerJson>();
        }
    }

