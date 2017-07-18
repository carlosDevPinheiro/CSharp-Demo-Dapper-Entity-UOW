using DapperEntityFramework.Entidades;
using DapperEntityFramework.Servicos;
using System.Data.Entity;

namespace DapperEntityFramework.ContextEntity
{
    public class DbContextEF: DbContext, IConnectionContext
    {
        public DbContextEF()
            :base("DapperEf")
        {

        }

        public DbSet<Cliente>  DbSetCliente { get; set; }
       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ClienteMap());
        }
    }
}
