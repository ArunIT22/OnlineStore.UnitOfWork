using OnlineStore.UnitOfWork.WebAPI.Interfaces;
using OnlineStore.UnitOfWork.WebAPI.Models;

namespace OnlineStore.UnitOfWork.WebAPI.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;
        public IProductRepository ProductRepository { get; }

        public UnitOfWork(ApplicationDbContext context, ILoggerFactory logger)
        {
            _context = context;
            _logger = logger.CreateLogger("Log");
            ProductRepository = new ProductRepository(context, _logger);
        }
      

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
