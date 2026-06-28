using System;
using System.Threading;
using System.Threading.Tasks;
using SalesWeb.Communication.Requests;
using SalesWeb.Communication.Responses;

namespace SalesWeb.Application.UseCases.Seller.Delete;

public interface IDeleteSellerUseCase
{
    Task Execute(Guid id);
}
