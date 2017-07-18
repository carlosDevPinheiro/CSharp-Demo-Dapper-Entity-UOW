using DapperEntityFramework.ContextEntity;
using DapperEntityFramework.Entidades;
using DapperEntityFramework.Servicos;
using System.Collections.Generic;
using System.Linq;

namespace DapperEntityFramework.Repositorios.RepositorioGenericoEF
{
    public class CRUDEF<T> : ICRUD<T> where T : BaseEntity
    {
        private DbContextEF _context;
        public CRUDEF(IConnectionContext context)
        {
            _context = (DbContextEF)context;
        }

        public IEnumerable<T> GetAll() => _context.Set<T>().ToList();
        public T GetId(int Id) => _context.Set<T>().FirstOrDefault(x => x.ID == Id);
        public void Remove(T entity) => _context.Set<T>().Remove(entity);       

        public void Save(T entity)
        {
            var exist = GetId(entity.ID);
            if (exist == null)
                _context.Set<T>().Add(entity);
            else
            {
                _context.Set<T>().Attach(entity);
                _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            }
        }

        
    }
}
