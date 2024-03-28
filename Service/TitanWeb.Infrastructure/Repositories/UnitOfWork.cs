using TitanWeb.Domain.Interfaces;
using TitanWeb.Infrastructure.Contexts;

namespace TitanWeb.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TitanWebContext _context;
        private bool _disposed;

        public UnitOfWork(TitanWebContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Func To Commit Database
        /// </summary>
        public async Task<int> Commit()
        {
           return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Func Dispose
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if(disposing)
                    _context.Dispose();
            _disposed = true;
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}
