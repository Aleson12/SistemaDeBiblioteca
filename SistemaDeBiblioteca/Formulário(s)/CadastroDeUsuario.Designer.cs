namespace SistemaDeBiblioteca.Formulário_s_
{
    partial class CadastroDeUsuario
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
            comboBox1 = new ComboBox();
            label5 = new Label();
            button2 = new Button();
            button1 = new Button();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            textBox1 = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(textBox4);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 426);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Usuário Externo", "Aluno", "Professor", "Administrador" });
            comboBox1.Location = new Point(194, 226);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(491, 28);
            comboBox1.TabIndex = 8;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged_1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(71, 229);
            label5.Name = "label5";
            label5.Size = new Size(117, 20);
            label5.TabIndex = 7;
            label5.Text = "Tipo de Usuário:";
            label5.TextAlign = ContentAlignment.TopRight;
            // 
            // button2
            // 
            button2.Location = new Point(397, 338);
            button2.Name = "button2";
            button2.Size = new Size(123, 48);
            button2.TabIndex = 6;
            button2.Text = "Sair";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(234, 338);
            button1.Name = "button1";
            button1.Size = new Size(130, 48);
            button1.TabIndex = 5;
            button1.Text = "Cadastrar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(126, 117);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(559, 27);
            textBox4.TabIndex = 2;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(113, 175);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(573, 27);
            textBox3.TabIndex = 3;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(233, 275);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(452, 27);
            textBox2.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(71, 120);
            label4.Name = "label4";
            label4.Size = new Size(49, 20);
            label4.TabIndex = 4;
            label4.Text = "Email:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(71, 178);
            label3.Name = "label3";
            label3.Size = new Size(36, 20);
            label3.TabIndex = 3;
            label3.Text = "CPF:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(71, 275);
            label2.Name = "label2";
            label2.Size = new Size(157, 20);
            label2.TabIndex = 2;
            label2.Text = "Registro Alfanumérico";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(71, 65);
            label1.Name = "label1";
            label1.Size = new Size(53, 20);
            label1.TabIndex = 1;
            label1.Text = "Nome:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(127, 65);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(559, 27);
            textBox1.TabIndex = 1;
            // 
            // CadastroDeUsuario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Name = "CadastroDeUsuario";
            Text = "CadastroDeUsuario";
            TopMost = true;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox textBox1;
        private Button button2;
        private Button button1;
        private Label label5;
        private ComboBox comboBox1;
    }
}