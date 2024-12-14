using MySql.Data.MySqlClient;
using SistemaDeBiblioteca.Formulário_s_;
using System.Text.RegularExpressions;

namespace SistemaDeBiblioteca
{
    public partial class SistemaBiblioteca : Form
    {
        CadastroDeUsuarioAluno cadastro = new CadastroDeUsuarioAluno();

        public SistemaBiblioteca()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // toda vez em que o link for clicado, instanciar-se-á um novo objeto (o que se traduz aqui como um novo formulário).
            CadastroDeUsuarioAluno cadastro1 = new CadastroDeUsuarioAluno();
            cadastro1.Show();
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string textoOriginal = textBox2.Text;
            if (textoOriginal.Length <= 14)
                textBox2.Text = CPF_Formatacao(textoOriginal);
                textBox2.SelectionStart = textBox2.Text.Length;
        }       

        private bool VerificarUsuario(string nomeDeUsuario, string senha)
        {
            string conexaoString = "Server=localhost;Database=sistemabiblioteca;Uid=root;Pwd=28064212";

            using (MySqlConnection conexao = new MySqlConnection(conexaoString))
            {
                try
                {
                    conexao.Open();

                    string query = "SELECT COUNT(*) FROM usuarios WHERE username = @username AND senha = @senha";

                    using (MySqlCommand cmd = new MySqlCommand(query, conexao))
                    {
                        cmd.Parameters.AddWithValue("@nomeDeUsuario", nomeDeUsuario);
                        cmd.Parameters.AddWithValue("@senha", senha);

                        int resultado = Convert.ToInt32(cmd.ExecuteScalar());

                        return resultado > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao verificar usuário: " + ex.Message);
                    return false;
                }   
            }
        }

        public bool CPFValido(string cpf)
        {
            // Expressão regular para o formato de CPF: XXX.XXX.XXX-XX
            string padraoCpf = @"^\d{3}\.\d{3}\.\d{3}-\d{2}$";
            return Regex.IsMatch(cpf, padraoCpf);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nomeDoAdmin = textBox1.Text;
            string senhaDoAdmin = textBox2.Text;

            if (nomeDoAdmin != "admin@faeterj.com" && !(string.IsNullOrWhiteSpace(textBox1.Text)))
            {
                MessageBox.Show("Formato de email de Administrador incorreto.");
                return;
            } else if (string.IsNullOrWhiteSpace(textBox1.Text))
                MessageBox.Show("Preencha o campo de Email para acessar o sistema.");

            if (!CPFValido(senhaDoAdmin) && !(string.IsNullOrWhiteSpace(textBox1.Text)))
            {
                MessageBox.Show("Formato de Senha incorreto. A tua Senha é o teu CPF.");
                return;
            } else if (string.IsNullOrWhiteSpace(textBox2.Text))
                MessageBox.Show("Preencha o campo de Senha para acessar o sistema.");

            if (nomeDoAdmin == "admin@faeterj.com" && CPFValido(senhaDoAdmin)) 
            {
                TelaAdministrador telaAdministrador = new TelaAdministrador();
                telaAdministrador.Show();
                telaAdministrador.BringToFront();
            }

        }
    }
}
