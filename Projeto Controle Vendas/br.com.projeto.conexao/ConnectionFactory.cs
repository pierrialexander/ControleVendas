using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Projeto_Controle_Vendas.br.com.projeto.conexao
{
    
    // Classe responsável por estabelecer a conexão com o banco de dados.
    internal class ConnectionFactory
    {
        // Método que conecta o banco de dados.
        public MySqlConnection getConnection()
        {
            // Configuração que se conecta ao arquivo App.config.
            string conexao = ConfigurationManager.ConnectionStrings["bdvendas"].ConnectionString;
            
            // Retornamos a instancia da nova conexão, passando os dados coletados acima para ela.
            return new MySqlConnection(conexao);
        }
    }
}
