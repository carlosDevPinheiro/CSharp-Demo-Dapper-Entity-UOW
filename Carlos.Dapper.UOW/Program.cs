using Carlos.Dapper.UOW.Entidades;
using System;
using System.Configuration;
using static System.Console;

namespace Carlos.Dapper.UOW
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var uow = new UnitOfWork(ConfigurationManager.ConnectionStrings["LosGatos"].ConnectionString))
            {
                try
                {
                    var raca = new Raca { RacaId = 1, Nome = "Segunda Raca" };
                    uow.RacaRepository.Novo(raca);
                    uow.Commit();
                }
                catch (Exception ex)
                {
                    WriteLine(ex.Message.ToString());
                    throw;
                }
            }

            ReadKey();
        }
    }
}
