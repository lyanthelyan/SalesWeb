using SalesWeb.Domain.Entities.Seller;

namespace SalesWeb.Domain.Repositories;

public interface ISellerRepository
{
    Task Add(Seller seller);
    Task<List<Seller>> GetAll();
    Task<Seller?> GetById(Guid id);
    Task<bool> ExistActiveSellerEmail(string email);
    Task Delete(Guid Id);
}
