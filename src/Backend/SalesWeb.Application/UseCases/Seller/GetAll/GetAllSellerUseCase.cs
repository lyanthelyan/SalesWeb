using Mapster;
using SalesWeb.Communication.Responses;
using SalesWeb.Domain.Repositories;

namespace SalesWeb.Application.UseCases.Seller.GetAll;

    public class GetAllSellerUseCase : IGetAllSellerUseCase
    {
        private readonly ISellerRepository _repository;

        public GetAllSellerUseCase(ISellerRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ResponseSellerJson>> Execute()
        {
            var seller = await _repository.GetAll();

            return seller.Adapt<List<ResponseSellerJson>>();
        }
    }

