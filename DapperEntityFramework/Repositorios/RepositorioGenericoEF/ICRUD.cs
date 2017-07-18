using System.Collections.Generic;

namespace DapperEntityFramework.Repositorios.RepositorioGenericoEF
{
    public interface ICRUD<T> where T: class
    {

        void Save(T entity);        
        void Remove(T entity);
        T GetId(int Id);
        IEnumerable<T> GetAll();
    }
}
