namespace SistemaDeBiblioteca.Formulário_s_
{
    partial class TelaAdministrador
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            groupBox1 = new GroupBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Cursor = Cursors.Hand;
            button1.DialogResult = DialogResult.Cancel;
            button1.Location = new Point(26, 59);
            button1.Name = "button1";
            button1.Size = new Size(441, 45);
            button1.TabIndex = 0;
            button1.Text = "Cadastrar Usuário";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Cursor = Cursors.Hand;
            button2.Location = new Point(26, 139);
            button2.Name = "button2";
            button2.Size = new Size(441, 43);
            button2.TabIndex = 1;
            button2.Text = "Usuários Cadastrados";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Cursor = Cursors.Hand;
            button3.Location = new Point(26, 219);
            button3.Name = "button3";
            button3.Size = new Size(441, 35);
            button3.TabIndex = 2;
            button3.Text = "Sair";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.None;
            groupBox1.AutoSize = true;
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(button2);
            groupBox1.Location = new Point(82, 34);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(473, 280);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Área do Admin.";
            // 
            // TelaAdministrador
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(639, 384);
            Controls.Add(groupBox1);
            Name = "TelaAdministrador";
            Text = "Área do Administrador";
            TopMost = true;
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private GroupBox groupBox1;
    }
}