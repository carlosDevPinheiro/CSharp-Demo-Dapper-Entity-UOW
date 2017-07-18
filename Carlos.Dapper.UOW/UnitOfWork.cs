using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carlos.Dapper.UOW.Repositorios;
using System.Data;
using System.Data.SqlClient;

namespace Carlos.Dapper.UOW
{
    public class UnitOfWork : IUnitOfWork
    {

        private IDbConnection _connection;
        private IDbTransaction _transaction;
        private IRacaRepository _racaRepository;
        private IGatoRepository _catRepository;
        private bool _disposed;


        public UnitOfWork(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        public IRacaRepository RacaRepository =>  _racaRepository ?? (_racaRepository = new RacaRepository(_transaction));

        public IGatoRepository GatoRepository => _catRepository ?? (_catRepository = new GatoRepository(_transaction));

        


        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch 
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _connection.BeginTransaction();
                ResetarRepositorios();
            }
        }

        private void ResetarRepositorios()
        {
            _racaRepository = null;
            _catRepository = null;
        }
        public void Dispose()
        {
            EncerrarConexoes(true);
            GC.SuppressFinalize(this);
        }

        private void EncerrarConexoes(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_transaction == null)
                    {
                        _transaction.Dispose();
                        _transaction = null;
                    }
                    if (_connection == null)
                    {
                        _connection.Dispose();
                        _connection = null;
                    }
                }

                _disposed = true;
            }
        }
    }
}
