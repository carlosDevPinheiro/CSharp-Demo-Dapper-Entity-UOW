using DapperEntityFramework.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperEntityFramework.ContextEntity
{
    public class ClienteMap: EntityTypeConfiguration<Cliente>
    {
        public ClienteMap()
        {
            ToTable("CLIENTE");
            HasKey(x => x.ID);
        }
    }
}
