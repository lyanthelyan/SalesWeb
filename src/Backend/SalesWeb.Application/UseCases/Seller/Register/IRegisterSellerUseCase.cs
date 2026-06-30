using SalesWeb.Communication.Requests.SellerRequests.Register;
using SalesWeb.Communication.Responses.SellerResponses.Register;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesWeb.Application.UseCases.Seller.Register;

public interface IRegisterSellerUseCase
{
    Task<ResponseRegisterSellerJson> Execute(RequestRegisterSellerJson request);
}
