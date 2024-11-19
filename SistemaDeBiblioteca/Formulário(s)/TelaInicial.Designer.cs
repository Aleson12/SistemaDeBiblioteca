namespace SistemaDeBiblioteca.Formulário_s_
{
    partial class TelaInicial
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
            button1 = new Button();
            label8 = new Label();
            textBox7 = new TextBox();
            textBox6 = new TextBox();
            textBox5 = new TextBox();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            label7 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(textBox7);
            groupBox1.Controls.Add(textBox6);
            groupBox1.Controls.Add(textBox5);
            groupBox1.Controls.Add(textBox4);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(800, 450);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Sistema de Biblioteca";
            // 
            // button1
            // 
            button1.Location = new Point(15, 338);
            button1.Name = "button1";
            button1.Size = new Size(696, 39);
            button1.TabIndex = 7;
            button1.Text = "Reservar";
            button1.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 20F, FontStyle.Bold | FontStyle.Italic);
            label8.Location = new Point(255, 23);
            label8.Name = "label8";
            label8.Size = new Size(252, 46);
            label8.TabIndex = 14;
            label8.Text = "Bem-vindo(a)!";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(70, 198);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(273, 27);
            textBox7.TabIndex = 2;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(70, 268);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(273, 27);
            textBox6.TabIndex = 3;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(435, 126);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(273, 27);
            textBox5.TabIndex = 4;
            textBox5.TextChanged += textBox5_TextChanged;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(438, 198);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(273, 27);
            textBox4.TabIndex = 5;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(438, 272);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(273, 27);
            textBox3.TabIndex = 6;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(15, 271);
            label7.Name = "label7";
            label7.Size = new Size(44, 20);
            label7.TabIndex = 7;
            label7.Text = "ISBN:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(372, 130);
            label5.Name = "label5";
            label5.Size = new Size(60, 20);
            label5.TabIndex = 5;
            label5.Text = "Editora:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(372, 201);
            label4.Name = "label4";
            label4.Size = new Size(64, 20);
            label4.TabIndex = 4;
            label4.Text = "Assunto:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(375, 275);
            label3.Name = "label3";
            label3.Size = new Size(57, 20);
            label3.TabIndex = 3;
            label3.Text = "Edição:";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 205);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 2;
            label2.Text = "Título:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(70, 127);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(273, 27);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 130);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 0;
            label1.Text = "Autor:";
            // 
            // TelaInicial
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Name = "TelaInicial";
            Text = "TelaInicial";
            TopMost = true;
            Load += TelaInicial_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private TextBox textBox1;
        private TextBox textBox7;
        private TextBox textBox6;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox3;
        private Label label7;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label8;
        private Button button1;
    }
}