namespace Cod3rsGrowth.Forms
{
    partial class FormCadastro
    {
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCadastro));
            pictureBox1 = new PictureBox();
            campoNome = new TextBox();
            label2 = new Label();
            campoNickName = new TextBox();
            label1 = new Label();
            campoSenha = new TextBox();
            label3 = new Label();
            botaoVerificarSenha = new Button();
            campoConfirmaSenha = new TextBox();
            label4 = new Label();
            caixaSelecionarPlano = new ComboBox();
            label5 = new Label();
            botaoCadastrar = new Button();
            botaoInfoPlano = new Button();
            botaoLogar = new Button();
            helpProvider1 = new HelpProvider();
            labelDisponivel = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.cadastrarImagem;
            pictureBox1.Location = new Point(59, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(180, 41);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // campoNome
            // 
            campoNome.Location = new Point(36, 81);
            campoNome.Name = "campoNome";
            campoNome.Size = new Size(227, 23);
            campoNome.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(36, 57);
            label2.Name = "label2";
            label2.Size = new Size(56, 21);
            label2.TabIndex = 3;
            label2.Text = "Nome:";
            // 
            // campoNickName
            // 
            campoNickName.Location = new Point(36, 135);
            campoNickName.Name = "campoNickName";
            campoNickName.Size = new Size(227, 23);
            campoNickName.TabIndex = 6;
            campoNickName.LostFocus += AoPerderFocoDoNickName;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(36, 111);
            label1.Name = "label1";
            label1.Size = new Size(86, 21);
            label1.TabIndex = 5;
            label1.Text = "NickName:";
            // 
            // campoSenha
            // 
            campoSenha.Location = new Point(36, 188);
            campoSenha.Name = "campoSenha";
            campoSenha.PasswordChar = '*';
            campoSenha.Size = new Size(227, 23);
            campoSenha.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(36, 164);
            label3.Name = "label3";
            label3.Size = new Size(56, 21);
            label3.TabIndex = 7;
            label3.Text = "Senha:";
            // 
            // botaoVerificarSenha
            // 
            botaoVerificarSenha.Location = new Point(268, 188);
            botaoVerificarSenha.Name = "botaoVerificarSenha";
            botaoVerificarSenha.Size = new Size(24, 21);
            botaoVerificarSenha.TabIndex = 10;
            botaoVerificarSenha.Text = "?";
            botaoVerificarSenha.UseVisualStyleBackColor = true;
            botaoVerificarSenha.Click += AoClicarBotaoVerificarSenha;
            // 
            // campoConfirmaSenha
            // 
            campoConfirmaSenha.Location = new Point(36, 242);
            campoConfirmaSenha.Name = "campoConfirmaSenha";
            campoConfirmaSenha.PasswordChar = '*';
            campoConfirmaSenha.Size = new Size(227, 23);
            campoConfirmaSenha.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(36, 218);
            label4.Name = "label4";
            label4.Size = new Size(131, 21);
            label4.TabIndex = 11;
            label4.Text = "Confirmar Senha:";
            // 
            // caixaSelecionarPlano
            // 
            caixaSelecionarPlano.FormattingEnabled = true;
            caixaSelecionarPlano.Location = new Point(36, 299);
            caixaSelecionarPlano.Name = "caixaSelecionarPlano";
            caixaSelecionarPlano.Size = new Size(227, 23);
            caixaSelecionarPlano.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.ButtonHighlight;
            label5.Location = new Point(36, 275);
            label5.Name = "label5";
            label5.Size = new Size(135, 21);
            label5.TabIndex = 14;
            label5.Text = "Selecione o Plano:";
            // 
            // botaoCadastrar
            // 
            botaoCadastrar.ForeColor = SystemColors.ActiveCaptionText;
            botaoCadastrar.Location = new Point(89, 342);
            botaoCadastrar.Name = "botaoCadastrar";
            botaoCadastrar.Size = new Size(119, 29);
            botaoCadastrar.TabIndex = 15;
            botaoCadastrar.Text = "Cadastrar";
            botaoCadastrar.UseVisualStyleBackColor = true;
            botaoCadastrar.Click += AoClicarBotaoCadastrar;
            // 
            // botaoInfoPlano
            // 
            botaoInfoPlano.Location = new Point(268, 301);
            botaoInfoPlano.Name = "botaoInfoPlano";
            botaoInfoPlano.Size = new Size(24, 21);
            botaoInfoPlano.TabIndex = 16;
            botaoInfoPlano.Text = "?";
            botaoInfoPlano.UseVisualStyleBackColor = true;
            botaoInfoPlano.Click += AoClicarBotaoInfoPlano;
            // 
            // botaoLogar
            // 
            botaoLogar.ForeColor = SystemColors.ActiveCaptionText;
            botaoLogar.Location = new Point(89, 377);
            botaoLogar.Name = "botaoLogar";
            botaoLogar.Size = new Size(119, 29);
            botaoLogar.TabIndex = 17;
            botaoLogar.Text = "Logar";
            botaoLogar.UseVisualStyleBackColor = true;
            botaoLogar.Click += AoClicarBotaoLogar;
            // 
            // labelDisponivel
            // 
            labelDisponivel.AutoSize = true;
            labelDisponivel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labelDisponivel.ForeColor = Color.Red;
            labelDisponivel.Location = new Point(192, 117);
            labelDisponivel.Name = "labelDisponivel";
            labelDisponivel.Size = new Size(0, 15);
            labelDisponivel.TabIndex = 18;
            // 
            // FormCadastro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(304, 425);
            Controls.Add(labelDisponivel);
            Controls.Add(botaoLogar);
            Controls.Add(botaoInfoPlano);
            Controls.Add(botaoCadastrar);
            Controls.Add(label5);
            Controls.Add(caixaSelecionarPlano);
            Controls.Add(campoConfirmaSenha);
            Controls.Add(label4);
            Controls.Add(botaoVerificarSenha);
            Controls.Add(campoSenha);
            Controls.Add(label3);
            Controls.Add(campoNickName);
            Controls.Add(label1);
            Controls.Add(campoNome);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(320, 464);
            MinimumSize = new Size(320, 464);
            Name = "FormCadastro";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro";
            Load += FormCadastro_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private TextBox campoNome;
        private Label label2;
        private TextBox campoNickName;
        private Label label1;
        private TextBox campoSenha;
        private Label label3;
        private Button botaoVerificarSenha;
        private TextBox campoConfirmaSenha;
        private Label label4;
        private ComboBox caixaSelecionarPlano;
        private Label label5;
        private Button botaoCadastrar;
        private Button botaoInfoPlano;
        private Button botaoLogar;
        private HelpProvider helpProvider1;
        private Label labelDisponivel;
    }
}