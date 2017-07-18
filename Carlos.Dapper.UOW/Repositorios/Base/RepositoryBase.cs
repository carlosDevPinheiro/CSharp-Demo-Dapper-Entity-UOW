using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carlos.Dapper.UOW.Repositorios.Base
{
    public abstract class RepositoryBase
    {
        protected IDbTransaction Transacao { get; private set; }
        protected IDbConnection Conexao { get { return Transacao.Connection; } }

        public RepositoryBase(IDbTransaction transacao)
        {
            Transacao = transacao;
        }
    }
}
