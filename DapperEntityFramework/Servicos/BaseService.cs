using DapperEntityFramework.UWO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperEntityFramework.Servicos
{
    public abstract class BaseService
    {
        public IUnitOfWork _uow;
        bool TemErros { get; set; }
        public BaseService(IUnitOfWork uow)
        {
            _uow = uow;
            TemErros = true;
        }

        public bool Commit()
        {
            if (TemErros)
            {
                _uow.Commit();
                return true;
            }           
                _uow.Roolback();

            return false;
        }
       
    }
}
