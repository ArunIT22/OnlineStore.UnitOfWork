using OnlineStore.UnitOfWork.WebAPI.Models;

namespace OnlineStore.UnitOfWork.WebAPI.Interfaces
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }

        Task SaveAsync();
    }
}
