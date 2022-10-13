using Projeto_Controle_Vendas.br.com.projeto.dao;
using Projeto_Controle_Vendas.br.com.projeto.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Controle_Vendas.br.com.projeto.view {
    public partial class FrmClientes : Form {
        public FrmClientes() {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            // 1 - Receber os dados dentro do objeto modelo de cliente
            Cliente obj = new Cliente();

            //obj.codigo = int.Parse(txtCodigo.Text);
            obj.nome = txtNome.Text;
            obj.rg = txtRG.Text;
            obj.cpf = txtCPF.Text;
            obj.email = txtEmail.Text;
            obj.telefone = txtTelefone.Text;
            obj.celular = txtCelular.Text;
            obj.cep = txtCep.Text;
            obj.endereco = txtEndereco.Text;
            obj.numero = int.Parse(txtNumero.Text);
            obj.complemento = txtComplemento.Text;
            obj.bairro = txtBairro.Text;
            obj.cidade = txtCidade.Text;
            obj.estado = txtEstado.Text;

            // 2 Instanciar um objeto da classo ClienteDAO e chamar o método de cadastro.
            ClienteDAO objDAO = new ClienteDAO();
            objDAO.cadastrarCliente(obj);

            // Chamando novamente a listagem do Grid para autualizar após a exclusão.
            gridCliente.DataSource = objDAO.listarClientes();

            // Alterar para a guia consulta.
            tabClientes.SelectedTab = tabPage2;

        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            ClienteDAO objDao = new ClienteDAO();
            gridCliente.DataSource = objDao.listarClientes();
        }

        private void gridCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Pegar os dados da linha selecionada.
            txtCodigo.Text = gridCliente.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = gridCliente.CurrentRow.Cells[1].Value.ToString();
            txtRG.Text = gridCliente.CurrentRow.Cells[2].Value.ToString();
            txtCPF.Text = gridCliente.CurrentRow.Cells[3].Value.ToString();
            txtEmail.Text = gridCliente.CurrentRow.Cells[4].Value.ToString();
            txtTelefone.Text = gridCliente.CurrentRow.Cells[5].Value.ToString();
            txtCelular.Text = gridCliente.CurrentRow.Cells[6].Value.ToString();
            txtCep.Text = gridCliente.CurrentRow.Cells[7].Value.ToString();
            txtEndereco.Text = gridCliente.CurrentRow.Cells[8].Value.ToString();
            txtNumero.Text = gridCliente.CurrentRow.Cells[9].Value.ToString();
            txtComplemento.Text = gridCliente.CurrentRow.Cells[10].Value.ToString();
            txtBairro.Text = gridCliente.CurrentRow.Cells[11].Value.ToString();
            txtCidade.Text = gridCliente.CurrentRow.Cells[12].Value.ToString();
            txtEstado.Text = gridCliente.CurrentRow.Cells[13].Value.ToString();

            
        }

        private void gridCliente_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Alterar para a guia Dados Pessoais.
            tabClientes.SelectedTab = tabPage1;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            // Instancia do model Cliente.
            Cliente obj = new Cliente();

            // Pegar o codigo do cliente e armazenar no objeto do model.
            obj.codigo = int.Parse(txtCodigo.Text);

            // Instancia do DAO e excluir.
            ClienteDAO objDao = new ClienteDAO();
            objDao.excluirCliente(obj);

            // Chamando novamente a listagem do Grid para autualizar após a exclusão.
            gridCliente.DataSource = objDao.listarClientes();

            // Alterar para a guia consulta.
            tabClientes.SelectedTab = tabPage2;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // 1 - Receber os dados dentro do objeto modelo de cliente
            Cliente obj = new Cliente();

            //obj.codigo = int.Parse(txtCodigo.Text);
            obj.codigo = int.Parse(txtCodigo.Text);
            obj.nome = txtNome.Text;
            obj.rg = txtRG.Text;
            obj.cpf = txtCPF.Text;
            obj.email = txtEmail.Text;
            obj.telefone = txtTelefone.Text;
            obj.celular = txtCelular.Text;
            obj.cep = txtCep.Text;
            obj.endereco = txtEndereco.Text;
            obj.numero = int.Parse(txtNumero.Text);
            obj.complemento = txtComplemento.Text;
            obj.bairro = txtBairro.Text;
            obj.cidade = txtCidade.Text;
            obj.estado = txtEstado.Text;

            // 2 Instanciar um objeto da classo ClienteDAO e chamar o método de cadastro.
            ClienteDAO objDAO = new ClienteDAO();
            objDAO.alterarCliente(obj);

            // Chamando novamente a listagem do Grid para autualizar após a exclusão.
            gridCliente.DataSource = objDAO.listarClientes();

            // Alterar para a guia consulta.
            tabClientes.SelectedTab = tabPage2;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            // Botão pesquisar
            string nome = txtConsultaNome.Text;

            ClienteDAO objDAO = new ClienteDAO();
            gridCliente.DataSource = objDAO.buscarClienteNome(nome);

            // Se na consulta não conter nenhum registro, carrega todos.
            if(gridCliente.Rows.Count == 0)
            {
                gridCliente.DataSource = objDAO.listarClientes();
            }


        }

        // Pesquisa por aproximação.
        private void txtConsultaNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            string nome = "%" + txtConsultaNome.Text + "%";
            ClienteDAO objDAO = new ClienteDAO();
            gridCliente.DataSource = objDAO.listarClienteNome(nome);

        }

        private void btnCep_Click(object sender, EventArgs e)
        {
            // Botão Consultar CEP
            try
            {
                string cep = txtCep.Text;
                string xml = $"https://viacep.com.br/ws/{cep}/xml/";
                
                // Intanciamos um obj da classe DataSet.
                DataSet dados = new DataSet();

                dados.ReadXml(xml);

                txtEndereco.Text = dados.Tables[0].Rows[0]["logradouro"].ToString();
                txtBairro.Text = dados.Tables[0].Rows[0]["bairro"].ToString();
                txtCidade.Text = dados.Tables[0].Rows[0]["localidade"].ToString();
                txtComplemento.Text = dados.Tables[0].Rows[0]["complemento"].ToString();
                txtEstado.Text = dados.Tables[0].Rows[0]["uf"].ToString();

            } catch (Exception)
            {
                MessageBox.Show("Endereço não encontrado!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Helpers().LimparTela(this);
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            new Helpers().LimparTela(this);
        }
    }
}
