﻿namespace SistemaDeBiblioteca.Formulário_s_
{
    partial class Cadastro
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
            textBox1 = new TextBox();
            button1 = new Button();
            textBox2 = new TextBox();
            label5 = new Label();
            comboBox1 = new ComboBox();
            label4 = new Label();
            textBox3 = new TextBox();
            Senha = new Label();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.None;
            groupBox1.AutoSize = true;
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(Senha);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(800, 450);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Cadastro";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(102, 136);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(632, 27);
            textBox1.TabIndex = 2;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            button1.Cursor = Cursors.Hand;
            button1.Location = new Point(337, 335);
            button1.Name = "button1";
            button1.Size = new Size(128, 47);
            button1.TabIndex = 5;
            button1.Text = "Criar conta";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(169, 268);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(565, 27);
            textBox2.TabIndex = 4;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(43, 271);
            label5.Name = "label5";
            label5.Size = new Size(120, 20);
            label5.TabIndex = 14;
            label5.Text = "Confirmar senha:";
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Administrador", "Bibliotecário", "Professor", "Aluno", "Usuário Externo" });
            comboBox1.Location = new Point(149, 63);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(585, 28);
            comboBox1.TabIndex = 1;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(43, 66);
            label4.Name = "label4";
            label4.Size = new Size(100, 20);
            label4.TabIndex = 12;
            label4.Text = "Tipo de Perfil:";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(102, 203);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(634, 27);
            textBox3.TabIndex = 3;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // Senha
            // 
            Senha.AutoSize = true;
            Senha.Location = new Point(43, 206);
            Senha.Name = "Senha";
            Senha.Size = new Size(52, 20);
            Senha.TabIndex = 4;
            Senha.Text = "Senha:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(43, 139);
            label1.Name = "label1";
            label1.Size = new Size(53, 20);
            label1.TabIndex = 0;
            label1.Text = "Nome:";
            // 
            // Cadastro
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Name = "Cadastro";
            Text = "Cadastro";
            TopMost = true;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Label Senha;
        private Label label1;
        private TextBox textBox3;
        private Label label4;
        private ComboBox comboBox1;
        private TextBox textBox2;
        private Label label5;
        private Button button1;
        private TextBox textBox1;
    }
}