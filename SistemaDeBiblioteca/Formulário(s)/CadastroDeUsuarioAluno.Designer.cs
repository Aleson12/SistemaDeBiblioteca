namespace SistemaDeBiblioteca.Formulário_s_
{
    partial class CadastroDeUsuarioAluno
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            label3 = new Label();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            label2 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            textBox2 = new TextBox();
            label4 = new Label();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.None;
            groupBox1.AutoSize = true;
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(textBox4);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(800, 464);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Cadastro de Usuário Aluno";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(91, 203);
            label3.Name = "label3";
            label3.Size = new Size(52, 20);
            label3.TabIndex = 17;
            label3.Text = "Senha:";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(149, 196);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(585, 27);
            textBox3.TabIndex = 3;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(149, 262);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(585, 27);
            textBox4.TabIndex = 4;
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(94, 133);
            label2.Name = "label2";
            label2.Size = new Size(49, 20);
            label2.TabIndex = 15;
            label2.Text = "Email:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(149, 53);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(585, 27);
            textBox1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            button1.Cursor = Cursors.Hand;
            button1.Location = new Point(324, 334);
            button1.Name = "button1";
            button1.Size = new Size(128, 47);
            button1.TabIndex = 7;
            button1.Text = "Criar conta";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(149, 126);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(585, 27);
            textBox2.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(23, 265);
            label4.Name = "label4";
            label4.Size = new Size(120, 20);
            label4.TabIndex = 14;
            label4.Text = "Confirmar senha:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(90, 60);
            label1.Name = "label1";
            label1.Size = new Size(53, 20);
            label1.TabIndex = 0;
            label1.Text = "Nome:";
            // 
            // CadastroDeUsuarioAluno
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Name = "CadastroDeUsuarioAluno";
            Text = "Cadastro";
            TopMost = true;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private TextBox textBox2;
        private Label label4;
        private Button button1;
        private TextBox textBox1;
        private Label label2;
        private TextBox textBox4;
        private TextBox textBox3;
        private Label label3;
    }
}