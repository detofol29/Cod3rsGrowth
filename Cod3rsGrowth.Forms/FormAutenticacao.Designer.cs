namespace Cod3rsGrowth.Forms
{
    partial class FormAutenticacao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAutenticacao));
            label1 = new Label();
            labelUsuario = new Label();
            campoUsuario = new TextBox();
            labelSenha = new Label();
            CampoSenha = new TextBox();
            botaoEntrar = new Button();
            botaoCadastrar = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(97, 9);
            label1.Name = "label1";
            label1.Size = new Size(95, 37);
            label1.TabIndex = 0;
            label1.Text = "LOGIN";
            // 
            // labelUsuario
            // 
            labelUsuario.AutoSize = true;
            labelUsuario.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelUsuario.Location = new Point(115, 73);
            labelUsuario.Name = "labelUsuario";
            labelUsuario.Size = new Size(67, 21);
            labelUsuario.TabIndex = 1;
            labelUsuario.Text = "Usuário:";
            // 
            // campoUsuario
            // 
            campoUsuario.Location = new Point(37, 97);
            campoUsuario.Name = "campoUsuario";
            campoUsuario.Size = new Size(227, 23);
            campoUsuario.TabIndex = 2;
            // 
            // labelSenha
            // 
            labelSenha.AutoSize = true;
            labelSenha.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelSenha.Location = new Point(115, 143);
            labelSenha.Name = "labelSenha";
            labelSenha.Size = new Size(56, 21);
            labelSenha.TabIndex = 3;
            labelSenha.Text = "Senha:";
            // 
            // CampoSenha
            // 
            CampoSenha.Location = new Point(37, 167);
            CampoSenha.Name = "CampoSenha";
            CampoSenha.PasswordChar = '*';
            CampoSenha.Size = new Size(227, 23);
            CampoSenha.TabIndex = 4;
            // 
            // botaoEntrar
            // 
            botaoEntrar.ForeColor = SystemColors.Desktop;
            botaoEntrar.Location = new Point(84, 212);
            botaoEntrar.Name = "botaoEntrar";
            botaoEntrar.Size = new Size(119, 31);
            botaoEntrar.TabIndex = 5;
            botaoEntrar.Text = "Entrar";
            botaoEntrar.UseVisualStyleBackColor = true;
            botaoEntrar.Click += AoClicarBotaoEntrar;
            // 
            // botaoCadastrar
            // 
            botaoCadastrar.ForeColor = SystemColors.ActiveCaptionText;
            botaoCadastrar.Location = new Point(84, 249);
            botaoCadastrar.Name = "botaoCadastrar";
            botaoCadastrar.Size = new Size(119, 29);
            botaoCadastrar.TabIndex = 6;
            botaoCadastrar.Text = "Cadastrar";
            botaoCadastrar.UseVisualStyleBackColor = true;
            botaoCadastrar.Click += AoClicarBotaoCadastrar;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.LoginImagem;
            pictureBox1.Location = new Point(97, 13);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(109, 33);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // FormAutenticacao
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlText;
            ClientSize = new Size(304, 325);
            Controls.Add(pictureBox1);
            Controls.Add(botaoCadastrar);
            Controls.Add(botaoEntrar);
            Controls.Add(CampoSenha);
            Controls.Add(labelSenha);
            Controls.Add(campoUsuario);
            Controls.Add(labelUsuario);
            Controls.Add(label1);
            ForeColor = SystemColors.ButtonFace;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(320, 364);
            MinimumSize = new Size(320, 364);
            Name = "FormAutenticacao";
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label labelUsuario;
        private TextBox campoUsuario;
        private Label labelSenha;
        private TextBox CampoSenha;
        private Button botaoEntrar;
        private Button botaoCadastrar;
        private PictureBox pictureBox1;
    }
}