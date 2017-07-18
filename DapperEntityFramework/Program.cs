using DapperEntityFramework.ContextDapper;
using DapperEntityFramework.ContextEntity;
using DapperEntityFramework.Entidades;
using DapperEntityFramework.Repositorios;
using DapperEntityFramework.Servicos;
using DapperEntityFramework.UWO;
using System;
using static System.Console;
using static System.Convert;

namespace DapperEntityFramework
{
    class Program
    {

        static void Main(string[] args)
        {

            WriteLine("============  Digite o Teste que deseja Realizar \n");

            string[] opcoes = new[] { "Dapper = 1", "Entity Framework = 2", "Dapper RepositorioGenrico = 3 " };

            for (int i = 0; i < opcoes.Length; i++)
            {
                Console.WriteLine($" => {opcoes[i]}");
            }

            int opcao = ToInt32(ReadLine());

            switch (opcao)
            {
                case 1:
                    Dapper();
                    break;
                case 2:
                    Entity();
                    break;
                case 3:
                    DapperRepositoryGeneric();
                    break;
                default:
                    Console.WriteLine("Opção Invalida");
                    break;
            }

            ReadKey();
        }

        static void DapperRepositoryGeneric()
        {
            Cliente cliente = new Cliente { ID = 1, Documento = "28556811892", Idade = 40, Nome = $"JOana Pinheiro - {DateTime.Now.ToString()}" };
            DapperGenericoCRUD repositorio = new DapperGenericoCRUD();
            repositorio.NovoCliente(cliente);
        }

        static void Entity()
        {
            IConnectionContext _conn = new DbContextEF();

            IClienteRepository _repository = new ClienteRepositoryEF(_conn as DbContextEF);
            IUnitOfWork _uow = new UnityOfWorkEntity(_conn as DbContextEF);
            IService servico = new Service(_uow, _repository);
            var cliente = new Cliente { Nome = "Carlos EntitycomIConnection", Idade = 38, Documento = "28556811892" };

            var result = servico.AddNovoCliente(cliente);

            WriteLine(result);
            ReadKey();
        }

        static void Dapper()
        {
            IConnectionContext _conn = new DbContextDapper();

            IClienteRepository _repository = new ClienteRepositoryDapper(_conn as DbContextDapper);
            IUnitOfWork _uow = new UnityOfWorkDapper(_conn as DbContextDapper);
            IService servico = new Service(_uow, _repository);

            var cliente = new Cliente { Nome = $"Carlos Dapper {DateTime.Now.ToString()} ", Idade = 38, Documento = "28556811892" };

            var result = servico.AddNovoCliente(cliente);

            WriteLine(result);
            ReadKey();
        }
    }
}
