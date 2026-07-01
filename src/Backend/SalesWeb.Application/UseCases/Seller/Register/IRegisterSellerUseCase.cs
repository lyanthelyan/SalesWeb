using SalesWeb.Communication.Requests.SellerRequests.Register;

namespace SalesWeb.Application.UseCases.Seller.Register;

public interface IRegisterSellerUseCase
{
    Task Execute(RequestRegisterSellerJson request);
}
