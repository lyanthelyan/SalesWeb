using SalesWeb.Communication.Responses.SellerResponses;

namespace SalesWeb.Application.UseCases.Seller.GetById;

public interface IGetSellerByIdUseCase
{
    Task<ResponseSellerJson> Execute(Guid id);
}