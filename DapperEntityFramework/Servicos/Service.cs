using System;
using System.Collections.Generic;
using DapperEntityFramework.Entidades;
using DapperEntityFramework.Repositorios;
using DapperEntityFramework.UWO;

namespace DapperEntityFramework.Servicos
{
    public class Service : BaseService, IService
    {
        private IClienteRepository _repository;
        

        public Service(IUnitOfWork uow, IClienteRepository repository)
            : base(uow)
        {
            _repository = repository;
        }

       
        public string AddNovoCliente(Cliente cliente)
        {
            _repository.Save(cliente);

            if (Commit())
                return "Cliente Registrado com Successo !";
            else
                return "Nao foi possivel registrar um novo cliente !!!";
            
        }

        public IEnumerable<Cliente> ObterTodos()
        {
            return _repository.GetAll();
        }
    }
}
