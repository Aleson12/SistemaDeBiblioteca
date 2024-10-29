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

namespace SistemaDeBiblioteca.Formulário_s_
{
    public partial class Cadastro : Form
    {
        public Cadastro()
        {
            InitializeComponent();
        }
        
        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null && comboBox1.SelectedItem.ToString() == "Administrador" || comboBox1.SelectedItem.ToString() == "Professor")
                MessageBox.Show("A tua senha é o teu CPF no formato 'XXX.XXX.XXX-XX'");
            else if (comboBox1.SelectedItem != null && comboBox1.SelectedItem.ToString() == "Aluno")
                MessageBox.Show("A tua senha é o teu número de matrícula (13 dígitos consecutivos).");
            else
                MessageBox.Show("A tua senha deve ter 8 (oito) dígitos, no mínimo.");

            // limpa os campos de texto ao alterar o tipo de perfil na ComboBox:
            textBox1.Clear(); 
            textBox2.Clear();
            textBox3.Clear();
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null && comboBox1.SelectedItem.ToString() == "Administrador" || comboBox1.SelectedItem.ToString() == "Professor")
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Administrador" || comboBox1.SelectedItem.ToString() == "Professor")
            {
                if (!CPFValido(textBox3.Text))
                    MessageBox.Show("O CPF digitado está em um formato incorreto. Por favor, use o formato XXX.XXX.XXX-XX.", "Erro de Formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox3.Focus(); // Foca novamente no campo para corrigir o erro 
            } else if (comboBox1.SelectedItem.ToString() == "Aluno")
            {
                if (!MatriculaValida(textBox3.Text))
                    MessageBox.Show("A matrícula digitada não corresponde ao padrão da instituição (13 números consecutivos)", "Erro de Formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox3.Focus();
            } else if (comboBox1.SelectedItem.ToString() == "Usuário Externo" || comboBox1.SelectedItem.ToString() == "Bibliotecário")
                if (!SenhaValida(textBox3.Text))
                    MessageBox.Show("A senha precisa de, no mínimo, 8 (oito) números.");
                    textBox3.Focus();                     

            if (string.IsNullOrWhiteSpace(textBox3.Text))
                MessageBox.Show("Preencha o campo 'Senha' para poder se cadastrar");
                textBox1.Focus();

            if (string.IsNullOrWhiteSpace(textBox1.Text))
                MessageBox.Show("Preencha o campo 'Nome' para poder se cadastrar");
                textBox1.Focus();

            if (textBox3.Text != textBox2.Text)
                MessageBox.Show("Os dois campos de Senha não correspondem");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null && comboBox1.SelectedItem.ToString() == "Administrador" ||  comboBox1.SelectedItem.ToString() == "Professor")
                textBox2.Text = CPF_Formatacao(textBox2.Text);
                textBox2.SelectionStart = textBox2.Text.Length;        
        }
    }
}
