using Carlos.Dapper.UOW.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carlos.Dapper.UOW.Repositorios
{
    public interface IGatoRepository
    {
        void Novo(Gato entity);
        IEnumerable<Gato> Todos();
        Gato Encontrar(int id);
        IEnumerable<Gato> EncontrarPorRaca(int RacaId);
        void Remover(int id);
        void Remover(Gato entity);
        void Atualizar(Gato entity);
    }
}
