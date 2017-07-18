using Dapper;
using DapperEntityFramework.ContextDapper;
using DapperEntityFramework.Entidades;
using DapperEntityFramework.Repositorios.RepositorioGenericoDapper;
using System;
using System.Collections.Generic;
using DapperEntityFramework.Servicos;

namespace DapperEntityFramework.Repositorios
{
    public class ClienteRepositoryDapper : CRUDDapper<Cliente>, IClienteRepository
    {

        public ClienteRepositoryDapper(IConnectionContext conn) : base(conn)
        {
        }



        //private DbContextDapper _context;

        //public ClienteRepositoryDapper(DbContextDapper context)
        //{
        //    _context = context;           
        //}

        //public void novoCliente(Cliente cliente)
        //{
        //    string query = $"INSERT INTO [dbo].[CLIENTE]([Nome],[Idade],[Documento]) VALUES('{cliente.Nome}',{ cliente.Idade},'{cliente.Documento}')";

        //    _context._connection.Execute(query, param: null, transaction: _context._transaction);
        //}

        //public Cliente ObterCliente(int clienteId)
        //{
        //    throw new NotImplementedException();
        //}

        //public void RemoveCliente(int clienteId)
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<Cliente> Todos()
        //{
        //    throw new NotImplementedException();
        //}

    }
}
