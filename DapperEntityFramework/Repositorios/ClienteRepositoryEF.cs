using DapperEntityFramework.Entidades;
using DapperEntityFramework.Repositorios.RepositorioGenericoEF;
using DapperEntityFramework.Servicos;

namespace DapperEntityFramework.Repositorios
{
    public class ClienteRepositoryEF : CRUDEF<Cliente>, IClienteRepository
    {
        public ClienteRepositoryEF(IConnectionContext _context) 
            : base(_context)
        {
        }
    }
}
