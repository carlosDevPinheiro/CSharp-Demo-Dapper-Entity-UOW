using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DapperEntityFramework
{
    class ProgramReflection
    {
        static void Main(string[] args)
        {
            Type humanoType = typeof(Humano);

            // criando a instancia do obeto
            object newHuman = Activator.CreateInstance(humanoType);

            PagarValorPropriedade(humanoType);            
            // ObterNomePropriedadesPublicas(humanoType);
            // PegandoOsTipos();
            Console.ReadKey();
        }

        private static void PagarValorPropriedade(Type humanoType)
        {
            var humano = new Humano() { Nome = "blbla", Altura = 2, Idade = 20, Peso = 1.5 };

            PropertyInfo property = humanoType.GetProperty("Idade");
            var idade = property.GetValue(humano, null);

            Console.WriteLine(idade);
        }

        private static void ObterNomePropriedadesPublicas(Type humanoType)
        {
            PropertyInfo[] properties = humanoType.GetProperties();
            foreach (var propertyInfo in properties)
            {
                Console.WriteLine(propertyInfo.Name);
            }
        }

        private static void PegandoOsTipos()
        {
            int inteiro = 10;
            string texto = "DevMedia";
            float Flutuante = 10.2f;

            System.Type Tipo = null;
            Tipo = inteiro.GetType();
            Console.WriteLine(Tipo.Name);
            Console.WriteLine(texto.GetType().Name);
            Console.WriteLine(Flutuante.GetType().Name);

            Console.Read();
        }
    }
    public class Humano
    {
        private string TipoSanguineo { get; set; }
        public int Idade { get; set; }
        public int Altura { get; set; }
        public Double Peso { get; set; }
        public string Nome { get; set; }
        public void Piscar()
        {
            Console.WriteLine("Piscar os olhos agora.");
        }
        public void Respirar()
        {
            Console.WriteLine("Repirar 1...2...3");
        }
        public void PensarAlgo(string pensamentos, DateTime quando)
        {
            Console.WriteLine("Estou pensando em : " + pensamentos + " pensei nisso agora : " + quando.ToShortTimeString());
        }

        public void SentirFome()
        {
            Console.WriteLine("Estou ficando com fome. Hora do Lanche.");
        }
        private void CantarNoBanheiro()
        {
            Console.WriteLine("Bla ... Bla ... Bla ...");
        }
    }



}
