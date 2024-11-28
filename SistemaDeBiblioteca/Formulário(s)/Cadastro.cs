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

namespace SistemaDeBiblioteca.Formulário_s_
{
    public partial class Cadastro : Form
    {
        TelaInicial telaInicial = new TelaInicial();
        private FirestoreDb db;

        public Cadastro()
        {
            InitializeComponent();
            ConexaoAoBanco();

            label3.Visible = false; // deixar invisível o texto
            textBox5.Visible = false; // deixar invisível a caixa de texto

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "C:/Users/feliz/source/repos/SistemaDeBiblioteca/JSON/sistemabiblioteca-46e43-firebase-adminsdk-qc25f-b7448b0e64.json");
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            if (FirebaseApp.DefaultInstance == null)
                FirebaseApp.Create(new AppOptions
                {
                    Credential = GoogleCredential.FromFile(path)
                });
            db = FirestoreDb.Create("sistemabiblioteca-46e43");
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

        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Configura visibilidade padrão (invisível)
            label3.Visible = false;
            textBox5.Visible = false;

            if (comboBox1.SelectedItem != null)
            {
                string tipoPerfil = comboBox1.SelectedItem.ToString();

                switch (tipoPerfil)
                {
                    case "Administrador":
                        label3.Visible = true; // Mostrar
                        textBox5.Visible = true; // Mostrar
                        MessageBox.Show("A tua senha é o teu CPF no formato 'XXX.XXX.XXX-XX'");
                        break;

                    case "Professor":
                        MessageBox.Show("A tua senha é o teu CPF no formato 'XXX.XXX.XXX-XX'");
                        break;

                    case "Aluno":
                        label3.Visible = true; // Mostrar
                        textBox5.Visible = true; // Mostrar
                        MessageBox.Show("A tua senha é o teu número de matrícula (13 dígitos consecutivos).");
                        break;

                    case "Usuário Externo":
                        MessageBox.Show("A tua senha é o teu CPF no formato 'XXX.XXX.XXX-XX'");
                        break;

                    case "Bibliotecário":
                        MessageBox.Show("A tua senha precisa de, no mínimo, 8 (oito) dígitos.");
                        break;

                    default:
                        MessageBox.Show("Selecione um perfil válido.");
                        break;
                }
            }

            // Limpa os campos de texto ao alterar o tipo de perfil na ComboBox
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null && comboBox1.SelectedItem.ToString() == "Administrador" || comboBox1.SelectedItem.ToString() == "Professor" || comboBox1.SelectedItem.ToString() == "Usuário Externo")
                textBox3.Text = CPF_Formatacao(textBox3.Text);
            textBox3.SelectionStart = textBox3.Text.Length;
            if (comboBox1.SelectedItem != null && comboBox1.SelectedItem.ToString() == "Aluno")
                textBox3.SelectionStart = textBox3.Text.Length;
        }

        // Função para validar o CPF no formato correto
        public bool CPFValido(string cpf)
        {
            // Expressão regular para o formato de CPF: XXX.XXX.XXX-XX
            string padraoCpf = @"^\d{3}\.\d{3}\.\d{3}-\d{2}$";
            return Regex.IsMatch(cpf, padraoCpf);
        }

        public bool MatriculaValida(string matricula)
        {
            string padraoMatricula = @"^\d{13}$"; // definindo a quantidade padrão de dígitos do número de matrícula (13)
            return Regex.IsMatch(matricula, padraoMatricula);
        }

        public bool SenhaValida(string senha)
        {
            string padraoSenha = @"^\d{8,}$"; // definindo a quantidade mínima de dígitos para a senha
            return Regex.IsMatch(senha, padraoSenha);
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
            string nomeUsuario = textBox1.Text;
            string emailUsuario = textBox2.Text;
            string senhaUsuarioCPF = textBox3.Text;
            string confirmarSenhaUsuarioCPF = textBox4.Text;

            // Validação para garantir que as senhas sejam iguais
            if (senhaUsuarioCPF != confirmarSenhaUsuarioCPF)
            {
                MessageBox.Show("As senhas não coincidem. Por favor, verifique.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox4.Focus(); // Foca no campo de confirmação para correção
                return; // Interrompe a execução do código
            }

            // Validação do CPF (apenas números e formato correto)
            if (!CPFValido(senhaUsuarioCPF))
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
                    MySqlCommand verificarCommand = new MySqlCommand(queryVerificar, connection0);
                    verificarCommand.Parameters.AddWithValue("@CPF", Regex.Replace(confirmarSenhaUsuarioCPF, @"\D", ""));
                    verificarCommand.Parameters.AddWithValue("@Nome", nomeUsuario);

                    string queryInserir0 = "INSERT INTO usuario (email, cpf, nome) VALUES (@Email, @CPF, @Nome)";
                    MySqlCommand command0 = new MySqlCommand(queryInserir0, connection0);
                    // Use parâmetros para evitar injeção de SQL
                    command0.Parameters.AddWithValue("@Email", emailUsuario);
                    command0.Parameters.AddWithValue("@CPF", Regex.Replace(confirmarSenhaUsuarioCPF, @"\D", ""));
                    command0.Parameters.AddWithValue("@Nome", nomeUsuario);

                    command0.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }
            if (comboBox1.SelectedItem.ToString() == "Administrador")
            {

                // Obtenha os valores dos campos de texto
                string nomeAdmin = textBox1.Text;
                string emailAdmin = textBox2.Text;
                string senhaAdminCPF = textBox3.Text;
                string confirmarSenhaAdminCPF = textBox4.Text;
                string matriculaAdministrador = textBox5.Text;

                // Validação para garantir que as senhas sejam iguais
                if (senhaAdminCPF != confirmarSenhaAdminCPF)
                {
                    MessageBox.Show("As senhas não coincidem. Por favor, verifique.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox4.Focus(); // Foca no campo de confirmação para correção
                    return; // Interrompe a execução do código
                }
                    
                // Validação do CPF (apenas números e formato correto)
                if (!CPFValido(senhaAdminCPF))
                {
                    MessageBox.Show("O CPF digitado está em um formato incorreto. Por favor, use o formato XXX.XXX.XXX-XX.", "Erro de Formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox3.Focus(); // Foca novamente no campo para corrigir o erro 
                    return; // Interrompe a execução do código
                }

                using (MySqlConnection connection1 = new MySqlConnection(stringDeConexao0))
                {
                    try
                    {
                        connection1.Open();

                        // Verificar se o CPF ou matrícula já existe
                        string queryVerificar = "SELECT COUNT(*) FROM administradordosistema WHERE cpf_usuario = @CPF OR nome = @Nome OR matricula = @Matricula" ;
                        MySqlCommand verificarCommand1 = new MySqlCommand(queryVerificar, connection1);
                        verificarCommand1.Parameters.AddWithValue("@CPF", Regex.Replace(confirmarSenhaAdminCPF, @"\D", ""));
                        verificarCommand1.Parameters.AddWithValue("@Nome", nomeAdmin);
                        verificarCommand1.Parameters.AddWithValue("@Matricula", matriculaAdministrador);

                        string queryInserir1 = "INSERT INTO administradordosistema (matricula, cpf_usuario, email, nome) VALUES (@Matricula, @CPF, @Email, @Nome)";
                            MySqlCommand command1 = new MySqlCommand(queryInserir1, connection1);
                            // Use parâmetros para evitar injeção de SQL
                            command1.Parameters.AddWithValue("@Matricula", matriculaAdministrador);
                            command1.Parameters.AddWithValue("@CPF", Regex.Replace(confirmarSenhaAdminCPF, @"\D", ""));
                            command1.Parameters.AddWithValue("@Email", emailAdmin);
                            command1.Parameters.AddWithValue("@Nome", nomeAdmin);

                            command1.ExecuteNonQuery();

                            MessageBox.Show("Dados inseridos com sucesso!");

                            TelaInicial telaInicial = new TelaInicial();
                            telaInicial.ShowDialog();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro: " + ex.Message);
                    }
                }
            }

            else if (comboBox1.SelectedItem.ToString() == "Professor")
            {
                // Obtenha os valores dos campos de texto
                string nomeProfessor = textBox1.Text;
                string emailProfessor = textBox2.Text;
                string senhaCPFProfessor = textBox3.Text;
                string confirmarSenhaCPFProfessor = textBox4.Text;

                label3.Visible = false; // ocultar o texto "Matrícula"
                textBox5.Visible = false; // ocultar o campo de texto

                // Validação para garantir que as senhas sejam iguais
                if (senhaCPFProfessor != confirmarSenhaCPFProfessor)
                {
                    MessageBox.Show("As senhas não coincidem. Por favor, verifique.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox4.Focus(); // Foca no campo de confirmação para correção
                    return; // Interrompe a execução do código
                }

                // Validação do CPF (apenas números e formato correto)
                if (!CPFValido(senhaCPFProfessor))
                {
                    MessageBox.Show("O CPF digitado está em um formato incorreto. Por favor, use o formato XXX.XXX.XXX-XX.", "Erro de Formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox3.Focus(); // Foca novamente no campo para corrigir o erro 
                    return; // Interrompe a execução do código
                }

                using (MySqlConnection connection2 = new MySqlConnection(stringDeConexao0))
                {
                    try
                    {
                        connection2.Open();

                        string query2 = "INSERT INTO professor (senha, nomeLogin, cpf_professor, email) VALUES (@Senha, @NomeLogin, @CPF, @Email)";
                        MySqlCommand command2 = new MySqlCommand(query2, connection2);
                        // Use parâmetros para evitar injeção de SQL
                        command2.Parameters.AddWithValue("@Senha", senhaCPFProfessor);
                        command2.Parameters.AddWithValue("@NomeLogin", nomeProfessor);
                        command2.Parameters.AddWithValue("@CPF", Regex.Replace(confirmarSenhaCPFProfessor, @"\D", ""));
                        command2.Parameters.AddWithValue("@Email", emailProfessor);

                        command2.ExecuteNonQuery();

                        MessageBox.Show("Dados inseridos com sucesso!");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro: " + ex.Message);
                    }
                }
            }

            else if (comboBox1.SelectedItem.ToString() == "Aluno")
            {
                label3.Visible = true; // ocultar o texto "Matrícula"
                textBox5.Visible = true; // ocultar o campo de texto

                if (!MatriculaValida(textBox3.Text))
                    MessageBox.Show("A matrícula digitada não corresponde ao padrão da instituição (13 números consecutivos)", "Erro de Formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox3.Focus();
            }
            else if (comboBox1.SelectedItem.ToString() == "Usuário Externo")
            {
                label3.Visible = false; // ocultar o texto "Matrícula"
                textBox5.Visible = false; // ocultar o campo de texto

                string nomeUsuarioExterno = textBox1.Text;
                string emailUsuarioExterno = textBox2.Text;
                string regAlfaNumerico = GerarRegistroAlfanumerico(10);
                string confirmarSenhaUsuarioExternoCPF = textBox4.Text;



                // Validação básica (opcional)
                if (string.IsNullOrEmpty(nomeUsuarioExterno) || string.IsNullOrEmpty(nomeUsuarioExterno))
                {
                    MessageBox.Show("Preencha todos os campos.");
                    return;
                }

                using (MySqlConnection connection3 = new MySqlConnection(stringDeConexao0))
                {
                    try
                    {
                        connection3.Open();

                        string query3 = "INSERT INTO usuario_externo (cpf_usuario, registroNumerico, email, nome) VALUES (@Cpf_usuario, @RegistroNumerico, @Email, @Nome)";

                        MySqlCommand command3 = new MySqlCommand(query3, connection3);

                        command3.Parameters.AddWithValue("@Cpf_usuario", senhaUsuarioCPF);
                        command3.Parameters.AddWithValue("@RegistroNumerico", regAlfaNumerico);
                        command3.Parameters.AddWithValue("@Email", emailUsuarioExterno);
                        command3.Parameters.AddWithValue("@Nome", nomeUsuarioExterno);
                                                
                        command3.ExecuteNonQuery();

                        MessageBox.Show("Dados inseridos com sucesso!");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro: " + ex.Message);
                    }
                }
                /*
                if (!SenhaValida(textBox3.Text))
                    MessageBox.Show("A senha precisa de, no mínimo, 8 (oito) números.");
                textBox3.Focus();*/
            }
            else if (comboBox1.SelectedItem.ToString() == "Bibliotecário")
            {
                if (!SenhaValida(textBox3.Text))
                    MessageBox.Show("A senha precisa de, no mínimo, 8 (oito) números.");
                textBox3.Focus();
            }

            string email1 = textBox2.Text;

            if (!EmailValido(email1))
            {
                MessageBox.Show("O e-mail digitado não é válido. Por favor, insira um e-mail no formato correto (exemplo: usuario@dominio.com).",
                    "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox3.Text))
                MessageBox.Show("Preencha o campo 'Senha' para poder se cadastrar");
            textBox1.Focus();

            if (string.IsNullOrWhiteSpace(textBox1.Text))
                MessageBox.Show("Preencha o campo 'Nome' para poder se cadastrar");
            textBox1.Focus();

            if (textBox3.Text != textBox4.Text)
                MessageBox.Show("Os dois campos de Senha não correspondem");

        }

        public string GerarRegistroAlfanumerico(int comprimento)
        {
            const string caracteresPermitidos = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();

            return new string(Enumerable.Range(0, comprimento)
                .Select(_ => caracteresPermitidos[random.Next(caracteresPermitidos.Length)])
                .ToArray());
        }

        public bool EmailValido(string email)
        {
            // Expressão regular para verificar o formato do e-mail
            string padraoEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, padraoEmail);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null && comboBox1.SelectedItem.ToString() == "Administrador" || comboBox1.SelectedItem.ToString() == "Professor" || comboBox1.SelectedItem.ToString() == "Usuário Externo")
                textBox4.Text = CPF_Formatacao(textBox4.Text);
            textBox4.SelectionStart = textBox4.Text.Length;
        }

        private void TextBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        
        private void TextBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text.Length > 8)
                textBox5.Text = textBox5.Text.Substring(0, 8);
                textBox5.SelectionStart = textBox5.Text.Length;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox5.KeyPress += TextBox5_KeyPress;
            textBox5.TextChanged += TextBox5_TextChanged;
        }
    }
}
