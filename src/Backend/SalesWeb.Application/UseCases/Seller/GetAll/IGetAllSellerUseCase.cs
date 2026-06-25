using SalesWeb.Communication.Responses;

namespace SalesWeb.Application.UseCases.Seller.GetAll;

public interface IGetAllSellerUseCase
{
    Task<List<ResponseSellerJson>> Execute();
}