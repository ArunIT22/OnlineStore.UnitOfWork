using OnlineStore.UnitOfWork.WebAPI.Models;

namespace OnlineStore.UnitOfWork.WebAPI.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository ProductRepository { get; }

        Task SaveAsync();
    }
}
