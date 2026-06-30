using SalesWeb.Communication.Requests;
using SalesWeb.Communication.Responses.SellerResponses;

namespace SalesWeb.Application.UseCases.Seller.Update;

public interface IUpdateSellerUseCase
{
    Task<ResponseSellerJson> Execute(Guid id, RequestUpdateSellerJson request);
}
