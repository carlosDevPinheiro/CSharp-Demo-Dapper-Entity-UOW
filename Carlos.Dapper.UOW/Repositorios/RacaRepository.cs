using Carlos.Dapper.UOW.Repositorios.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carlos.Dapper.UOW.Entidades;
using System.Data;
using Dapper;

namespace Carlos.Dapper.UOW.Repositorios
{
    public class RacaRepository : RepositoryBase, IRacaRepository
    {
        public RacaRepository(IDbTransaction transacao)
            : base(transacao)
        {

        }

        public void Atualizar(Raca entity)
        {
            Conexao.Execute(
                "UPDATE Raca SET Name = @Name WHERE RacaId = @RacaId",
                param: new { Name = entity.Nome, RacaId = entity.RacaId },
                transaction: Transacao
            );
        }

        public Raca Encontrar(int id)
        {
            return Conexao.Query<Raca>(
                "SELECT * FROM Raca WHERE RacaId = @RacaId",
                param: new { RacaId = id },
                transaction: Transacao
            ).FirstOrDefault();
        }

        public Raca EncontrarPorNome(string nome)
        {
            return Conexao.Query<Raca>(
               "SELECT * FROM Raca WHERE Nome = @Nome",
               param: new { Nome = nome },
               transaction: Transacao
           ).FirstOrDefault();
        }

        public void Novo(Raca entity)
        {
            entity.RacaId = Conexao.ExecuteScalar<int>(
                "INSERT INTO Raca(Nome) VALUES(@Nome); SELECT SCOPE_IDENTITY()",
                param: new { Nome = entity.Nome },
                transaction: Transacao
            );
        }

        public void Remover(int id)
        {
            Conexao.Execute(
                "DELETE FROM Raca WHERE RacaId = @RacaId",
                param: new { RacaId = id },
                transaction: Transacao
            );
        }

        public void Remover(Raca entity)
        {
            Remover(entity.RacaId);
        }

        public IEnumerable<Raca> Todos()
        {
            return Conexao.Query<Raca>(
                 "SELECT * FROM Raca",
                 transaction: Transacao
             ).ToList();
        }
    }
}
