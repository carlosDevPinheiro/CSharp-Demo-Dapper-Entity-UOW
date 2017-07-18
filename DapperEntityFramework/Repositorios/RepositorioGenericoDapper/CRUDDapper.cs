using DapperEntityFramework.ContextDapper;
using DapperEntityFramework.Entidades;
using DapperEntityFramework.Repositorios.RepositorioGenericoEF;
using DapperEntityFramework.Servicos;
using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace DapperEntityFramework.Repositorios.RepositorioGenericoDapper
{
    public class CRUDDapper<T> : ICRUD<T> where T: BaseEntity
    {
        IDbConnection _connection;
        IDbTransaction _transaction;
        public CRUDDapper(IConnectionContext conn)
        {
            _connection = ((DbContextDapper)conn)._connection;            
            _transaction = ((DbContextDapper)conn)._transaction;
        }

        public IEnumerable<T> GetAll()
        {
            var obj = typeof(T);
            var tabela = obj.Name;
            
            string query = $"SELECT * FROM [dbo].[{tabela}]";
            return _connection.Query<T>(query, null, transaction: _transaction);
        }

        public T GetId(int Id)
        {
            throw new NotImplementedException();
        }

        public void Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public void Save(T entity)
        {
            var obj = typeof(T);
            var tableName = obj.Name;
            
            

            PropertyInfo[] props = entity.GetType().GetProperties();
            List<string> campos = new List<string>();
            List<string> values = new List<string>();

            foreach (var p in props)
            {
                var tipo = p.PropertyType == typeof(string);
                if (tipo)
                {
                    values.Add($"'{p.Name}'");
                }
                else if (p.Name != "ID")
                {
                    values.Add(p.Name);
                }
                if (p.Name != "ID")
                {
                    campos.Add(p.Name);
                }
            }

            string[] camp = campos.OrderBy(x => x).Select(p => p).ToArray();
            string[] val = values.OrderBy(x => x).Select(p => p).ToArray();
            var query = string.Format("INSERT INTO [dbo].[{0}] ({1}) Values ({2})",
                                 tableName,
                                 string.Join(",", camp),
                                 string.Join(",", val));

            //var obj = typeof(T);
            //var tableName = obj.Name;           

            //// pego as propriedades
            //PropertyInfo[] props = entity.GetType().GetProperties();
            //// cria um array de nomes das propriedades
            //// string[] columns = props.Select(p => p.Name).ToArray();
            //string[] columns = props.Select(p => p.Name).Where(s => s != "ID").ToArray();


            //var query = string.Format("INSERT INTO [dbo].[{0}] ({1}) Values (@{2})",
            //                    tableName,
            //                    string.Join(",", columns), // campos
            //                    string.Join(",@", columns)); // values

            _connection.Execute(query, null, transaction: _transaction);
        }
    }
}
