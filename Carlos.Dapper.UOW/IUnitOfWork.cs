using Carlos.Dapper.UOW.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carlos.Dapper.UOW
{
    public interface IUnitOfWork: IDisposable
    {
        IRacaRepository RacaRepository { get; }
        IGatoRepository GatoRepository { get; }

        void Commit();
    }
}
