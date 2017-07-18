using Carlos.Dapper.UOW.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carlos.Dapper.UOW.Repositorios
{
    public interface IRacaRepository
    {
        void Novo(Raca entity);
        IEnumerable<Raca> Todos();
        void Remover(int id);
        void Remover(Raca entity);
        Raca Encontrar(int id);
        Raca EncontrarPorNome(string name);
        void Atualizar(Raca entity);
    }
}
