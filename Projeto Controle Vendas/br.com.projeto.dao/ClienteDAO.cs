using MySql.Data.MySqlClient;
using Projeto_Controle_Vendas.br.com.projeto.conexao;
using Projeto_Controle_Vendas.br.com.projeto.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Controle_Vendas.br.com.projeto.dao
{
    public class ClienteDAO
    {
        private MySqlConnection conexao;

        // Construtor da classe.
        public ClienteDAO()
        {
            // Instanciamos a classe de conexão e passamos para a variável conexao,
            // para ser usado pelos métodos.
            this.conexao = new ConnectionFactory().getConnection();

        }

        #region CadastrarCliente
        // Método para fazer o CADASTRO do Cliente.
        public void cadastrarCliente(Cliente obj)
        {
            try
            {
                // 1 - Definir o comando sql - insert.
                string sql = @"INSERT INTO tb_clientes (nome, rg, cpf, email, telefone, celular, cep,
                                                        endereco, numero, complemento, bairro, 
                                                        cidade, estado)
                                                VALUES (@nome, @rg, @cpf, @email, @telefone, @celular, @cep,
                                                        @endereco, @numero, @complemento, @bairro, 
                                                        @cidade, @estado)";
                // 2 - Organizar o comando sql.
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@nome", obj.nome);
                executacmd.Parameters.AddWithValue("@rg", obj.rg);
                executacmd.Parameters.AddWithValue("@cpf", obj.cpf);
                executacmd.Parameters.AddWithValue("@email", obj.email);
                executacmd.Parameters.AddWithValue("@telefone", obj.telefone);
                executacmd.Parameters.AddWithValue("@celular", obj.celular);
                executacmd.Parameters.AddWithValue("@cep", obj.cep);
                executacmd.Parameters.AddWithValue("@endereco", obj.endereco);
                executacmd.Parameters.AddWithValue("@numero", obj.numero);
                executacmd.Parameters.AddWithValue("@complemento", obj.complemento);
                executacmd.Parameters.AddWithValue("@bairro", obj.bairro);
                executacmd.Parameters.AddWithValue("@cidade", obj.cidade);
                executacmd.Parameters.AddWithValue("@estado", obj.estado);

                // 3 - Abrir a conexao e executar o script sql.
                conexao.Open();
                executacmd.ExecuteNonQuery();
                MessageBox.Show("Cliente cadastrado com sucesso!");
                conexao.Close();

            } 
            catch (Exception erro)
            {
                MessageBox.Show($"Aconteceu uma falha {erro}");
            }
        }
        #endregion

        #region ListarClientes
        // Método para LISTAR os Clientes no DataGrid   
        public DataTable listarClientes()
        {
            try
            {
                // 1 - Criar o DataTable e o comendo Sql.
                DataTable tabelaCliente = new DataTable();

                // Comando SQL que será executado
                string sql = "select * from tb_clientes";

                // 2 - Organizar o comando sql e executar.
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                conexao.Open();
                executacmd.ExecuteNonQuery();

                // 3 - Criar o MySqlDataAdapter para preencher os dados no DataTable.
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelaCliente); // O Adapter munido da execução do SQL, inclui no DataTable os dados.

                // 4 - Finaliza a conexão
                conexao.Close();

                // 5 - Retorna o DataTable com os dados
                return tabelaCliente;

            } 
            catch (Exception erro)
            {
                MessageBox.Show($"Erro ao executar comando SQL {erro}");
                return null;
            }
        }
        #endregion

        #region AlterarCliente
        // Método para ALTERAR o cadastro do Cliente.
        public void alterarCliente(Cliente obj)
        {
            try
            {
                // 1 - Definir o comando sql - ALTERAR.
                string sql = @"UPDATE tb_clientes set nome=@nome, rg=@rg, cpf=@cpf, email=@email, telefone=@telefone, celular=@celular, cep=@cep,
                                                        endereco=@endereco, numero=@numero, complemento=@complemento, bairro=@bairro, 
                                                        cidade=@cidade, estado=@estado
                                            WHERE id=@id";

                // 2 - Organizar o comando sql.
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@id", obj.codigo);
                executacmd.Parameters.AddWithValue("@nome", obj.nome);
                executacmd.Parameters.AddWithValue("@rg", obj.rg);
                executacmd.Parameters.AddWithValue("@cpf", obj.cpf);
                executacmd.Parameters.AddWithValue("@email", obj.email);
                executacmd.Parameters.AddWithValue("@telefone", obj.telefone);
                executacmd.Parameters.AddWithValue("@celular", obj.celular);
                executacmd.Parameters.AddWithValue("@cep", obj.cep);
                executacmd.Parameters.AddWithValue("@endereco", obj.endereco);
                executacmd.Parameters.AddWithValue("@numero", obj.numero);
                executacmd.Parameters.AddWithValue("@complemento", obj.complemento);
                executacmd.Parameters.AddWithValue("@bairro", obj.bairro);
                executacmd.Parameters.AddWithValue("@cidade", obj.cidade);
                executacmd.Parameters.AddWithValue("@estado", obj.estado);

                // 3 - Abrir a conexao e executar o script sql.
                conexao.Open();
                executacmd.ExecuteNonQuery();
                MessageBox.Show("Cliente alterado com sucesso!");
                conexao.Close();

            } catch (Exception erro)
            {
                MessageBox.Show($"Aconteceu uma falha {erro}");
            }
        }
        #endregion

        #region ExcluirCliente
        // Método para EXCLUIR o cadastro do Cliente.
        public void excluirCliente(Cliente obj)
        {
            try
            {
                // 1 - Definir o comando sql - DELETE.
                string sql = @"DELETE FROM tb_clientes where id = @id";
                // 2 - Organizar o comando sql.
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@id", obj.codigo);

                // 3 - Abrir a conexao e executar o script sql.
                conexao.Open();
                executacmd.ExecuteNonQuery();
                MessageBox.Show("Cliente excluído com sucesso!");
                conexao.Close();

            } catch (Exception erro)
            {
                MessageBox.Show($"Aconteceu uma falha {erro}");
            }
        }
        #endregion

        #region BuscarClientePorNome
        // Método para buscar um unico cliente na consulta.   
        public DataTable buscarClienteNome(string nome)
        {
            try
            {
                // 1 - Criar o DataTable e o comendo Sql.
                DataTable tabelaCliente = new DataTable();

                // Comando SQL que será executado
                string sql = "select * from tb_clientes where nome = @nome";
                
                // 2 - Organizar o comando sql e executar.
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@nome", nome);

                conexao.Open();
                executacmd.ExecuteNonQuery();

                // 3 - Criar o MySqlDataAdapter para preencher os dados no DataTable.
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelaCliente); // O Adapter munido da execução do SQL, inclui no DataTable os dados.

                // 4 - Finaliza a conexão
                conexao.Close();

                // 5 - Retorna o DataTable com os dados
                return tabelaCliente;

            } catch (Exception erro)
            {
                MessageBox.Show($"Erro ao executar comando SQL {erro}");
                return null;
            }
        }
        #endregion

        #region ListarClientePorNome
        // Método para buscar um unico cliente na consulta.   
        public DataTable listarClienteNome(string nome)
        {
            try
            {
                // 1 - Criar o DataTable e o comendo Sql.
                DataTable tabelaCliente = new DataTable();

                // Comando SQL que será executado
                string sql = "select * from tb_clientes where nome like @nome";

                // 2 - Organizar o comando sql e executar.
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@nome", nome);

                conexao.Open();
                executacmd.ExecuteNonQuery();

                // 3 - Criar o MySqlDataAdapter para preencher os dados no DataTable.
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelaCliente); // O Adapter munido da execução do SQL, inclui no DataTable os dados.

                // 4 - Finaliza a conexão
                conexao.Close();

                // 5 - Retorna o DataTable com os dados
                return tabelaCliente;

            } catch (Exception erro)
            {
                MessageBox.Show($"Erro ao executar comando SQL {erro}");
                return null;
            }
        }
        #endregion

    }
}
