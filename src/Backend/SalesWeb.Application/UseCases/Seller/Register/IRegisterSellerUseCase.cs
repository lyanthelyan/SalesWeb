using SalesWeb.Communication.Requests;
using SalesWeb.Communication.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesWeb.Application.UseCases.Seller.Register;

public interface IRegisterSellerUseCase
{
    Task<ResponseRegisterSellerJson> Execute(RequestRegisterSellerJson request);
}
