using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SistemaDeBiblioteca.Formulário_s_
{
    public partial class CadastroDeUsuario : Form
    {
        public CadastroDeUsuario()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool CPFValido(string cpf)
        {
            // Expressão regular para o formato de CPF: XXX.XXX.XXX-XX
            string padraoCpf = @"^\d{3}\.\d{3}\.\d{3}-\d{2}$";
            return Regex.IsMatch(cpf, padraoCpf);
        }

        public static bool ValidarRegistroAlfaNum(string registro)
        {
            // Verifica se o registro não é vazio ou nulo
            if (string.IsNullOrWhiteSpace(registro))
                return false;

            // Verifica se o registro contém apenas caracteres alfanuméricos
            if (!registro.All(char.IsLetterOrDigit))
                return false;

            return true;
        }

        public static bool ValidarNomeUsuario(string nome)
        {
            // Verifica se o nome está vazio ou contém apenas espaços
            if (string.IsNullOrWhiteSpace(nome))
                return false;

            // Verifica se o nome contém apenas letras e espaços
            if (!nome.All(c => Char.IsLetter(c) || c == ' '))
                return false;

            return true;
        }




        // Função para formatar o CPF
        public string CPF_Formatacao(string cpf)
        {
            // Remove qualquer caractere não numérico
            cpf = Regex.Replace(cpf, @"\D", "");

            if (cpf.Length > 9)
                cpf = cpf.Insert(9, "-");
            if (cpf.Length > 6)
                cpf = cpf.Insert(6, ".");
            if (cpf.Length > 3)
                cpf = cpf.Insert(3, ".");

            return cpf;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string cpf = textBox3.Text;
            if (cpf.Length <= 14)
                textBox3.Text = CPF_Formatacao(cpf);
            textBox3.SelectionStart = textBox3.Text.Length;
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // Verifica se a opção selecionada é "usuário externo"
            if (comboBox1.SelectedItem.ToString() == "Usuário Externo")
            {
                // Torna o TextBox e o Label visíveis
                textBox2.Visible = true;
                label2.Visible = true;
            }
            else
            {
                label2.Visible = false;
                textBox2.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Obtém o tipo de usuário selecionado na ComboBox
            string tipoUsuario = comboBox1.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(tipoUsuario))
            {
                MessageBox.Show("Selecione o tipo de usuário.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Dados comuns a serem coletados das TextBox
            string nome = textBox1.Text;
            string cpf = textBox3.Text;
            string email = textBox4.Text;
            string senha = textBox5.Text;
            string nomeLogin = textBox1.Text;
            string matricula = textBox6.Text;
            string registroAlfanumerico = textBox2.Text;

            // Chama o método que insere os dados no banco
            bool sucesso = CadastrarUsuarioNoBanco(tipoUsuario, nome, cpf, email, senha, nomeLogin, matricula, registroAlfanumerico);

            // Exibe a mensagem de sucesso ou erro
            if (sucesso)
                MessageBox.Show("Usuário cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else    
                MessageBox.Show("Erro ao cadastrar usuário. Verifique os dados informados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool CadastrarUsuarioNoBanco(string tipoUsuario, string nome, string cpf, string email, string senha, string nomeLogin, string matricula, string registroAlfanumerico)
        {
            string stringDeConexao = "Server=localhost;Database=sistemabiblioteca;Uid=root;Pwd=28064212";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(stringDeConexao))
                {
                    connection.Open();

                    // Primeiro, insere os dados na tabela 'usuario'
                    string queryUsuario = "INSERT INTO usuario (cpf, email, nome) VALUES (@cpf, @email, @nome)";
                    MySqlCommand commandUsuario = new MySqlCommand(queryUsuario, connection);
                    commandUsuario.Parameters.AddWithValue("@cpf", cpf);
                    commandUsuario.Parameters.AddWithValue("@email", email);
                    commandUsuario.Parameters.AddWithValue("@nome", nome);

                    // Executa a inserção na tabela 'usuario'
                    commandUsuario.ExecuteNonQuery();

                    // Define a query específica com base no tipo de usuário
                    string query = "";
                    MySqlCommand command = new MySqlCommand();
                    command.Connection = connection;

                    switch (tipoUsuario.ToLower())
                    {
                        case "administrador":
                            query = "INSERT INTO administradordosistema (matricula, cpf_usuario, email, nome) VALUES (@matricula, @cpf, @email, @nome)";
                            command.Parameters.AddWithValue("@matricula", matricula);
                            command.Parameters.AddWithValue("@cpf", cpf);
                            command.Parameters.AddWithValue("@email", email);
                            command.Parameters.AddWithValue("@nome", nome);
                            break;

                        case "aluno":
                            query = "INSERT INTO aluno (senha, nomeLogin, email) VALUES (@senha, @nomeLogin, @email)";
                            command.Parameters.AddWithValue("@senha", senha);
                            command.Parameters.AddWithValue("@nomeLogin", nomeLogin);
                            command.Parameters.AddWithValue("@email", email);
                            break;

                        case "bibliotecário":
                            query = "INSERT INTO bibliotecario (senha, nomeLogin, cpf_usuario, email) VALUES (@senha, @nome, @cpf, @email)";
                            command.Parameters.AddWithValue("@senha", senha);
                            command.Parameters.AddWithValue("@nome", nome);
                            command.Parameters.AddWithValue("@cpf", cpf);
                            command.Parameters.AddWithValue("@email", email);
                            break;

                        case "professor":
                            query = "INSERT INTO professor (senha, nomeLogin, cpf_professor, email) VALUES (@senha, @nome, @cpf, @email)";
                            command.Parameters.AddWithValue("@senha", senha);
                            command.Parameters.AddWithValue("@nome", nome);
                            command.Parameters.AddWithValue("@cpf", cpf);
                            command.Parameters.AddWithValue("@email", email);
                            break;

                        case "usuário externo":
                            query = "INSERT INTO usuario_externo (cpf_usuario, registroNumerico, email, nome) VALUES (@cpf, @registroNumerico, @email, @nome)";
                            command.Parameters.AddWithValue("@cpf", cpf);
                            command.Parameters.AddWithValue("@registroNumerico", registroAlfanumerico);
                            command.Parameters.AddWithValue("@email", email);
                            command.Parameters.AddWithValue("@nome", nome);
                            break;

                        default:
                            MessageBox.Show("Tipo de usuário inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                    }

                    // Configura e executa a query para a tabela específica
                    command.CommandText = query;
                    command.ExecuteNonQuery();
                }

                return true; // Cadastro realizado com sucesso
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao acessar o banco de dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
