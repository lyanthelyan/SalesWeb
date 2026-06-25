namespace SalesWeb.Domain.Repositories;

public interface IUnitOfWork
{
    Task Commit();
}
