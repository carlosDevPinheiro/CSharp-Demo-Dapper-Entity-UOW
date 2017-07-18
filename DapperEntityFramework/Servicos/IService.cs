using DapperEntityFramework.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperEntityFramework.Servicos
{
    public interface IService
    {
        string AddNovoCliente(Cliente cliente);
        IEnumerable<Cliente> ObterTodos();
    }
}
