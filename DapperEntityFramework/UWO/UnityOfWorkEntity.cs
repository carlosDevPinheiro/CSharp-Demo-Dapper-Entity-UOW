using DapperEntityFramework.ContextEntity;

namespace DapperEntityFramework.UWO
{
    public class UnityOfWorkEntity : IUnitOfWork
    {
        private DbContextEF _context;
        public UnityOfWorkEntity(DbContextEF context)
        {
            _context = context;
        }
        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Roolback()
        {           
           // rollback
        }
    }
}
