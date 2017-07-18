using Dapper;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace DapperEntityFramework
{
    public class DapperGenericoCRUD
    {
        public void NovoCliente<T>(T cliente) where T:class
        {            
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DapperEf"].ConnectionString))
            {
                var obj = typeof(T);                    // tipo do Objeto Recebido
                var tableName = obj.Name;               // Obtendo o nome do Objeto

                PropertyInfo[] props = cliente.GetType().GetProperties();   // Criando um array com nomes das propriedades
                string[] columns = props.Select(p => p.Name)  // criando um array com os campos que sera inseridos na tabela
                    .Where(s => s != "ID").ToArray();  //  o id nao sera setado, é o banco quem faz isso  


                string query = string.Format("INSERT INTO {0} ({1}) VALUES (@{2})",
                                      tableName, // 0                    --> nome da tabela
                                      string.Join(",", columns), // 1    --> campos 
                                      string.Join(",@", columns));

                DynamicParameters parametros = new DynamicParameters();

                // preenchendo os parametros com as propriedades da entidade
                foreach (var p in props)
                {
                    string key = "@" + p.Name;//                        --> concatenando @ + nome da propriedade
                    if (key != "@ID")//                                 --> campos diferebte de @ID
                    {
                        dynamic value = p.GetValue(cliente, null); //   --> Obtendo Valores das propriedades
                        parametros.Add(key, value);//                    --> add paramatros                  
                    }
                }

                conn.Query<T>(query, param: parametros);//              --> executando a query
            }
        }

       
    }


}
