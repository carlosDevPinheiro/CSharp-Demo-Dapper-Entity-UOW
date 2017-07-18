using DapperEntityFramework.ContextDapper;
using System.Data;

namespace DapperEntityFramework.UWO
{
    public class UnityOfWorkDapper : IUnitOfWork
    {
        IDbTransaction _transaction;
        IDbConnection _connection;
        public UnityOfWorkDapper(DbContextDapper context)
        {
            _connection = context._connection;
            _transaction = context._transaction;
        }
        public void Commit()
        {          
            _transaction.Commit();
        }

        public void Dispose()
        {
            _transaction.Dispose();
        }

        public void Roolback()
        {
            _transaction.Rollback();
        }
    }
}
