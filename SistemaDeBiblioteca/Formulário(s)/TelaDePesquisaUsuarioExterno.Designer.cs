namespace SistemaDeBiblioteca.Formulário_s_
{
    partial class TelaDePesquisaUsuarioExterno
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
            textBox4 = new TextBox();
            label4 = new Label();
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
            groupBox1.Controls.Add(textBox4);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 426);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Sistema de Biblioteca";
            // 
            // button1
            // 
            button1.Location = new Point(15, 299);
            button1.Name = "button1";
            button1.Size = new Size(708, 39);
            button1.TabIndex = 15;
            button1.Text = "Pesquisar";
            button1.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 20F, FontStyle.Bold | FontStyle.Italic);
            label8.Location = new Point(259, 35);
            label8.Name = "label8";
            label8.Size = new Size(252, 46);
            label8.TabIndex = 14;
            label8.Text = "Bem-vindo(a)!";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(70, 218);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(653, 27);
            textBox7.TabIndex = 13;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(438, 144);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(285, 27);
            textBox4.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(368, 147);
            label4.Name = "label4";
            label4.Size = new Size(64, 20);
            label4.TabIndex = 4;
            label4.Text = "Assunto:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 221);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 2;
            label2.Text = "Título:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(70, 144);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(273, 27);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 147);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 0;
            label1.Text = "Autor:";
            // 
            // TelaDePesquisaUsuarioExterno
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Name = "TelaDePesquisaUsuarioExterno";
            Text = "TelaDePesquisaUsuarioExterno";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button button1;
        private Label label8;
        private TextBox textBox7;
        private TextBox textBox4;
        private Label label4;
        private Label label2;
        private TextBox textBox1;
        private Label label1;
    }
}