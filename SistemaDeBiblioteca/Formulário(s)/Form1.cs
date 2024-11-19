using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using MySql.Data.MySqlClient;
using SistemaDeBiblioteca.Formul�rio_s_;

namespace SistemaDeBiblioteca
{
    public partial class SistemaBiblioteca : Form
    {
        Cadastro cadastro = new Cadastro();

        // configurando o fireBase
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "yepU2F5YRZzSRME36uT4mGAvkhCOOA6OIgHySLmm", // senha de acesso ao meu banco de dados
            BasePath = "https://sistemabiblioteca-46e43-default-rtdb.firebaseio.com/" // onde est� o meu banco de dados 
        };

        IFirebaseClient cliente;

        public SistemaBiblioteca()
        {
            InitializeComponent();
            cliente = new FireSharp.FirebaseClient(config); // instanciando um cliente com as informa��o contidas no objeto 'config' (para que seja poss�vel a ele acessar o Banco)
            /*if (cliente != null)
                MessageBox.Show("a");*/
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cadastro.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Administrador" || comboBox1.SelectedItem.ToString() == "Professor")
                MessageBox.Show("A tua senha � o teu CPF no formato 'XXX.XXX.XXX-XX'");
            else if (comboBox1.SelectedItem != null && comboBox1.SelectedItem.ToString() == "Aluno")
                MessageBox.Show("A tua senha � o teu n�mero de matr�cula (13 d�gitos consecutivos).");
            else
                MessageBox.Show("A tua senha deve ter 8 (oito) d�gitos, no m�nimo.");

            // limpa os campos de texto ao alterar o tipo de perfil na ComboBox:
            textBox1.Clear();
            textBox2.Clear();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null && comboBox1.SelectedItem.ToString() == "Administrador" || comboBox1.SelectedItem.ToString() == "Professor")
                textBox2.Text = cadastro.CPF_Formatacao(textBox2.Text);
            textBox2.SelectionStart = textBox2.Text.Length;
        }

        private void button1_Click(object sender, EventArgs e)
        {



            if (comboBox1.SelectedItem.ToString() == "Administrador" || comboBox1.SelectedItem.ToString() == "Professor")
            {
                if (!cadastro.CPFValido(textBox2.Text))
                    MessageBox.Show("O CPF digitado est� em um formato incorreto. Por favor, use o formato XXX.XXX.XXX-XX.", "Erro de Formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus(); // Foca novamente no campo para corrigir o erro 
            }
            else if (comboBox1.SelectedItem.ToString() == "Aluno")
            {
                if (!cadastro.MatriculaValida(textBox2.Text))
                    MessageBox.Show("A matr�cula digitada n�o corresponde ao padr�o da institui��o (13 n�meros consecutivos)", "Erro de Formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
            }
            else if (comboBox1.SelectedItem.ToString() == "Usu�rio Externo" || comboBox1.SelectedItem.ToString() == "Bibliotec�rio")
                if (!cadastro.SenhaValida(textBox2.Text))
                    MessageBox.Show("A senha precisa de, no m�nimo, 8 (oito) n�meros.");
            textBox2.Focus();

            if (string.IsNullOrWhiteSpace(textBox1.Text))
                MessageBox.Show("Preencha o campo 'Nome' para poder se cadastrar");
            textBox1.Focus();

            if (string.IsNullOrWhiteSpace(textBox2.Text))
                MessageBox.Show("Preencha o campo 'Senha' para poder se cadastrar");
            textBox2.Focus();


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
