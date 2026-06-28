using SalesWeb.Communication.Responses;

namespace SalesWeb.Application.UseCases.Seller.GetById;

public interface IGetSellerByIdUseCase
{
    Task<ResponseSellerJson> Execute(Guid id);
}