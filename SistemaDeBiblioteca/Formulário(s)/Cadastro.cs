using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using FirebaseAdmin;
using Google.Api;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using Microsoft.Extensions.DependencyInjection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Microsoft.Extensions.Hosting;
using MySql.Data.MySqlClient;
using FireSharp.Extensions;

namespace SistemaDeBiblioteca.Formulário_s_
{
    public partial class Cadastro : Form
    {
        TelaInicial telaInicial = new TelaInicial();

        public Cadastro()
        {
            InitializeComponent();
            ConexaoAoBanco();
        }

        public void ConexaoAoBanco()
        {
            string stringDeConexao = "Server=localhost;Database=sistemabiblioteca;Uid=root;Pwd=28064212";

            using (MySqlConnection connection = new MySqlConnection(stringDeConexao))
            {
                try
                {
                    connection.Open();
                    MessageBox.Show("Conexão com o Banco de Dados realizada com êxito");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }
        }
        // Função para validar o CPF no formato correto
        public bool CPFValido(string cpf)
        {
            // Expressão regular para o formato de CPF: XXX.XXX.XXX-XX
            string padraoCpf = @"^\d{3}\.\d{3}\.\d{3}-\d{2}$";
            return Regex.IsMatch(cpf, padraoCpf);
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

        private async void button1_Click(object sender, EventArgs e)
        {
            // Defina a string de conexão com as credenciais do banco
            string stringDeConexao0 = "Server=localhost;Database=sistemabiblioteca;Uid=root;Pwd=28064212";

            // Obtenha os valores dos campos de texto
            string nomeAluno = textBox1.Text;
            string emailAluno = textBox2.Text;
            string senhaAlunoCPF = textBox3.Text;
            string confirmarSenhaAlunoCPF = textBox4.Text;

            if (string.IsNullOrWhiteSpace(nomeAluno))
            {
                MessageBox.Show("Preencha o campo 'Senha' para poder se cadastrar");
                textBox1.Focus();
                return;
            }

            if (!EmailValido(emailAluno))
            {
                MessageBox.Show("O e-mail digitado não é válido. Por favor, insira um e-mail no formato correto (exemplo: usuario@dominio.com).",
                    "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }

            // Validação para garantir que as senhas sejam iguais
            if (senhaAlunoCPF != confirmarSenhaAlunoCPF)
            {
                MessageBox.Show("As senhas não coincidem. Por favor, verifique.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox4.Focus(); // Foca no campo de confirmação para correção
                return; // Interrompe a execução do código
            }

            // Validação do CPF (apenas números e formato correto)
            if (!CPFValido(senhaAlunoCPF))
            {
                MessageBox.Show("O CPF digitado está em um formato incorreto. Por favor, use o formato XXX.XXX.XXX-XX.", "Erro de Formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox3.Focus(); // Foca novamente no campo para corrigir o erro 
                return; // Interrompe a execução do código
            }

            using (MySqlConnection connection0 = new MySqlConnection(stringDeConexao0))
            {
                try
                {
                    connection0.Open();

                    // Verificar se o CPF ou matrícula já existe
                    string queryVerificar = "SELECT COUNT(*) FROM usuario WHERE cpf = @CPF OR nome = @Nome";

                    using (MySqlCommand verificarCommand = new MySqlCommand(queryVerificar, connection0))
                    {
                        verificarCommand.Parameters.AddWithValue("@CPF", Regex.Replace(confirmarSenhaAlunoCPF, @"\D", ""));
                        verificarCommand.Parameters.AddWithValue("@Nome", nomeAluno);

                        int count = Convert.ToInt32(verificarCommand.ExecuteScalar());
                        if(count > 0)
                        {
                            MessageBox.Show("Já existe um registro com este CPF ou Nome");
                            return;
                        }
                    }
                                                    
                    string queryInserir0 = "INSERT INTO aluno (senha, nomeLogin, email) VALUES (@Senha, @NomeLogin, @Email)";

                    using (MySqlCommand command0 = new MySqlCommand(queryInserir0, connection0))
                    {
                        // Usando parâmetros para evitar injeção de SQL
                        command0.Parameters.AddWithValue("@Senha", senhaAlunoCPF);
                        command0.Parameters.AddWithValue("@NomeLogin", nomeAluno);
                        command0.Parameters.AddWithValue("@Email", Regex.Replace(emailAluno, @"\D", ""));

                        command0.ExecuteNonQuery();
                    }

                    MessageBox.Show("Perfil de Aluno criado com sucesso");

                    TelaInicial telaInicial = new TelaInicial();
                    telaInicial.Show();
                    telaInicial.BringToFront();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }

            if (string.IsNullOrWhiteSpace(textBox1.Text))
                MessageBox.Show("Preencha o campo 'Nome' para poder se cadastrar");
            textBox1.Focus();

            if (textBox3.Text != textBox4.Text)
                MessageBox.Show("Os dois campos de Senha não correspondem");
        }

        public bool EmailValido(string email)
        {
            // Expressão regular para verificar o formato do e-mail
            string padraoEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, padraoEmail);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string textoOriginal = textBox3.Text;
            if (textoOriginal.Length <= 14)
                textBox3.Text = CPF_Formatacao(textoOriginal);
            textBox3.SelectionStart = textBox3.Text.Length;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            string textoOriginal = textBox4.Text;
            if (textoOriginal.Length <= 14)
                textBox4.Text = CPF_Formatacao(textoOriginal);
            textBox4.SelectionStart = textBox4.Text.Length;
        }
    }
}
