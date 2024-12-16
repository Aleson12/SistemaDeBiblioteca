using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SistemaDeBiblioteca.Formulário_s_
{
    public partial class CadastroDeLivro : Form
    {
        public CadastroDeLivro()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string stringDeConexao = "Server=localhost;Database=sistemabiblioteca;Uid=root;Pwd=28064212";

            string autor = textBox1.Text;
            string assunto = textBox4.Text;
            string titulo = textBox7.Text;
            string isbn = textBox2.Text;
            string edicao = textBox5.Text;
            string editora = textBox3.Text;
            string dataInclusao = textBox6.Text;

            try
            {
                // Validação da Data
                if (!DateTime.TryParse(dataInclusao, out DateTime parsedData))
                {
                    MessageBox.Show("A data de inclusão está em um formato inválido. Use o formato yyyy-MM-dd.",
                                    "Erro de Validação",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                using (MySqlConnection connection = new MySqlConnection(stringDeConexao))
                {
                    connection.Open();

                    // Ajustando a query SQL
                    string queryLivro = @"INSERT INTO livro 
                                  (ISBN, AUTOR, TITULO, ASSUNTO, EDITORA, EDICAO, DATA_INCLUSAO) 
                                  VALUES (@isbn, @autor, @titulo, @assunto, @editora, @edicao, @data_inclusao)";

                    using (MySqlCommand commandLivro = new MySqlCommand(queryLivro, connection))
                    {
                        // Adicionando parâmetros
                        commandLivro.Parameters.AddWithValue("@isbn", isbn);
                        commandLivro.Parameters.AddWithValue("@autor", autor);
                        commandLivro.Parameters.AddWithValue("@titulo", titulo);
                        commandLivro.Parameters.AddWithValue("@assunto", assunto);
                        commandLivro.Parameters.AddWithValue("@editora", editora);
                        commandLivro.Parameters.AddWithValue("@edicao", edicao);
                        commandLivro.Parameters.AddWithValue("@data_inclusao", parsedData.ToString("yyyy-MM-dd"));

                        // Executando a query
                        commandLivro.ExecuteNonQuery();
                    }
                }

                // Exibindo mensagem de sucesso
                MessageBox.Show("Livro cadastrado com sucesso!",
                                "Cadastro Realizado",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                // Exibe erros específicos do MySQL
                MessageBox.Show($"Erro ao acessar o banco de dados: {ex.Message}",
                                "Erro",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Exibe erros gerais
                MessageBox.Show($"Erro inesperado: {ex.Message}",
                                "Erro",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}
