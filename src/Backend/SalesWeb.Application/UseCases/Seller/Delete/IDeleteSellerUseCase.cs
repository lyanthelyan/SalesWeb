using System;
using System.Threading;
using System.Threading.Tasks;

namespace SalesWeb.Application.UseCases.Seller.Delete;

public interface IDeleteSellerUseCase
{
    Task ExecuteAsync(Guid sellerId, CancellationToken cancellationToken = default);
}
