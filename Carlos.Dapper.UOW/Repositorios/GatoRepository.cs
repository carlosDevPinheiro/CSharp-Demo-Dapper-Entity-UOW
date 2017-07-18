using Carlos.Dapper.UOW.Repositorios.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Carlos.Dapper.UOW.Entidades;
using Dapper;

namespace Carlos.Dapper.UOW.Repositorios
{
    public class GatoRepository : RepositoryBase, IGatoRepository
    {
        public GatoRepository(IDbTransaction transacao)
            : base(transacao)
        {
        }

        public void Atualizar(Gato entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            Conexao.Execute(
                "UPDATE Gato SET RacaId = @RacaId, Nome = @Nome, Idade = @Idade WHERE GatoId = @GatoId",
                param: new { GatoId = entity.GatoId, RacaId = entity.RacaId, Nome = entity.Nome, Idade = entity.Idade },
                transaction: Transacao
            );
        }

        public Gato Encontrar(int id)
        {
            return Conexao.Query<Gato>(
               "SELECT * FROM Gato WHERE GatoId = @GatoId",
               param: new { GatoId = id },
               transaction: Transacao
           ).FirstOrDefault();
        }

        public IEnumerable<Gato> EncontrarPorRaca(int RacaId)
        {
            return Conexao.Query<Gato>(
                "SELECT * FROM Gato WHERE RacaId = @RacaId",
                param: new { RacaId = RacaId },
                transaction: Transacao
            );
        }

        public void Novo(Gato entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            entity.GatoId = Conexao.ExecuteScalar<int>(
                "INSERT INTO Gato(RacaId, Nome, Idade) VALUES(@RacaId, @Nome, @Idade); SELECT SCOPE_IDENTITY()",
                param: new { RacaId = entity.RacaId, Nome = entity.Nome, Idade = entity.Idade },
                transaction: Transacao
            );
        }

        public void Remover(int id)
        {
            Conexao.Execute(
               "DELETE FROM Gato WHERE GatoId = @GatoId",
               param: new { GatoId = id },
               transaction: Transacao
           );
        }

        public void Remover(Gato entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            Remover(entity.GatoId);
        }

        public IEnumerable<Gato> Todos()
        {
            return Conexao.Query<Gato>(
                 "SELECT * FROM Gato"
             );
        }
    }
}
