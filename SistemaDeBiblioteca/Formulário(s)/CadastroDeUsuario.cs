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

        private void button1_Click(object sender, EventArgs e)
        {
            string nomeUsuario = textBox1.Text;
            string email = textBox4.Text;
            string cpfUsuario = textBox3.Text;
            string registroAlfanumerico = textBox2.Text;

            bool cpfInvalido = !CPFValido(cpfUsuario) && !string.IsNullOrWhiteSpace(cpfUsuario);
            bool entradaNumericaInvalida = !ValidarRegistroAlfaNum(registroAlfanumerico);
            bool nomeUsuarioInvalido = !ValidarNomeUsuario(nomeUsuario);
            bool nomeUsuarioVazio = string.IsNullOrWhiteSpace(nomeUsuario);

            if (cpfInvalido)
            {
                MessageBox.Show("Formato de Senha incorreto. A tua Senha é o teu CPF.");
                return;
            }

            if (nomeUsuarioInvalido)
            {
                MessageBox.Show("O nome de usuário deve conter apenas letras.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (nomeUsuarioVazio)
            {
                MessageBox.Show("O nome de usuário não pode estar vazio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Realiza o cadastro no banco de dados
            if (CadastrarUsuario(nomeUsuario, cpfUsuario, registroAlfanumerico, email))
                MessageBox.Show("Usuário cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Erro ao cadastrar usuário. Verifique os dados e tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool CadastrarUsuario(string nome, string cpf, string registroAlfanumerico, string email)
        {
            string stringDeConexao0 = "Server=localhost;Database=sistemabiblioteca;Uid=root;Pwd=28064212";

            // Primeira query para inserir o CPF na tabela 'usuario'
            string queryInserirUsuario = "INSERT INTO usuario (cpf, nome) VALUES (@cpf_usuario, @nome)";

            // Query para inserir na tabela 'usuario_externo'
            string queryInserirUsuarioExterno = "INSERT INTO usuario_externo (cpf_usuario, RegistroNumerico, Email, Nome) VALUES (@cpf_usuario, @registroNumerico, @email, @nome)";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(stringDeConexao0))
                {
                    connection.Open();

                    // Inserir o CPF na tabela 'usuario'
                    using (MySqlCommand commandInserirUsuario = new MySqlCommand(queryInserirUsuario, connection))
                    {
                        commandInserirUsuario.Parameters.AddWithValue("@cpf_usuario", cpf);
                        commandInserirUsuario.Parameters.AddWithValue("@nome", nome);

                        // Executa a inserção na tabela 'usuario'
                        int rowsAffectedUsuario = commandInserirUsuario.ExecuteNonQuery();
                        if (rowsAffectedUsuario == 0)
                        {
                            // Se não conseguiu inserir, retorna erro
                            MessageBox.Show("Erro ao inserir o CPF na tabela 'usuario'.");
                            return false;
                        }
                    }

                    // Após inserir na tabela 'usuario', inserir na tabela 'usuario_externo'
                    using (MySqlCommand commandInserirUsuarioExterno = new MySqlCommand(queryInserirUsuarioExterno, connection))
                    {
                        commandInserirUsuarioExterno.Parameters.AddWithValue("@cpf_usuario", cpf);
                        commandInserirUsuarioExterno.Parameters.AddWithValue("@registroNumerico", registroAlfanumerico);
                        commandInserirUsuarioExterno.Parameters.AddWithValue("@email", email);
                        commandInserirUsuarioExterno.Parameters.AddWithValue("@nome", nome);

                        // Executa a inserção na tabela 'usuario_externo'
                        commandInserirUsuarioExterno.ExecuteNonQuery();
                    }
                }

                // Se tudo foi bem-sucedido, retorna verdadeiro
                return true;
            }
            catch (Exception ex)
            {
                // Caso algum erro ocorra, exibe a mensagem de erro
                MessageBox.Show($"Erro de banco de dados: {ex.Message}");
                return false;
            }
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
                textBox1.Visible = true;
                label1.Visible = true;
            }
            else
            {
                // Torna o TextBox e o Label invisíveis
                textBox1.Visible = false;
                label1.Visible = false;
            }
        }
    }
}
