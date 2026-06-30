using SalesWeb.Communication.Responses.SellerResponses;

namespace SalesWeb.Application.UseCases.Seller.GetAll;

public interface IGetAllSellerUseCase
{
    Task<List<ResponseSellerJson>> Execute();
}