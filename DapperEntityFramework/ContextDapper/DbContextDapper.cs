using DapperEntityFramework.Servicos;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DapperEntityFramework.ContextDapper
{
    public class DbContextDapper :  IConnectionContext
    {
        public IDbConnection _connection;
        public IDbTransaction _transaction;
        public DbContextDapper()
        {
            _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DapperEf"].ConnectionString);
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }       
    }
}
