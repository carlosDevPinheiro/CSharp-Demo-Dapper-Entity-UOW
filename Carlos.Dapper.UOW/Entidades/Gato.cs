using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carlos.Dapper.UOW.Entidades
{
    public class Gato
    {
        public int GatoId { get; set; }
        public int RacaId { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
    }
}
