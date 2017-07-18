using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperEntityFramework.Entidades
{
    public class Cliente: BaseEntity
    {        
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Documento { get; set; }
    }
}
