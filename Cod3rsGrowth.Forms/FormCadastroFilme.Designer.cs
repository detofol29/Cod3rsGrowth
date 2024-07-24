namespace Cod3rsGrowth.Forms
{
    partial class FormCadastroFilme
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCadastroFilme));
            botaoCancelar = new Button();
            botaoCadastrar = new Button();
            label5 = new Label();
            label4 = new Label();
            campoDiretor = new TextBox();
            labelDiretor = new Label();
            labelGenero = new Label();
            campoTitulo = new TextBox();
            labelTitulo = new Label();
            generoComboBox = new ComboBox();
            classificacaoComboBox = new ComboBox();
            labelNota = new Label();
            CampoNota = new NumericUpDown();
            campoDuracao = new NumericUpDown();
            labelDuracao = new Label();
            pictureBox1 = new PictureBox();
            campoDataDeLancamento = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)CampoNota).BeginInit();
            ((System.ComponentModel.ISupportInitialize)campoDuracao).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // botaoCancelar
            // 
            botaoCancelar.ForeColor = SystemColors.ActiveCaptionText;
            botaoCancelar.Location = new Point(111, 511);
            botaoCancelar.Name = "botaoCancelar";
            botaoCancelar.Size = new Size(119, 29);
            botaoCancelar.TabIndex = 30;
            botaoCancelar.Text = "Cancelar";
            botaoCancelar.UseVisualStyleBackColor = true;
            botaoCancelar.Click += AoClicarBotaoCancelar;
            // 
            // botaoCadastrar
            // 
            botaoCadastrar.ForeColor = SystemColors.ActiveCaptionText;
            botaoCadastrar.Location = new Point(111, 476);
            botaoCadastrar.Name = "botaoCadastrar";
            botaoCadastrar.Size = new Size(119, 29);
            botaoCadastrar.TabIndex = 29;
            botaoCadastrar.Text = "Cadastrar";
            botaoCadastrar.UseVisualStyleBackColor = true;
            botaoCadastrar.Click += AoClicarBotaoCadastrar;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.ButtonHighlight;
            label5.Location = new Point(53, 289);
            label5.Name = "label5";
            label5.Size = new Size(155, 21);
            label5.TabIndex = 28;
            label5.Text = "Data de Lançamento:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(53, 232);
            label4.Name = "label4";
            label4.Size = new Size(101, 21);
            label4.TabIndex = 25;
            label4.Text = "Classificação:";
            // 
            // campoDiretor
            // 
            campoDiretor.Location = new Point(53, 202);
            campoDiretor.Name = "campoDiretor";
            campoDiretor.Size = new Size(227, 23);
            campoDiretor.TabIndex = 24;
            // 
            // labelDiretor
            // 
            labelDiretor.AutoSize = true;
            labelDiretor.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelDiretor.ForeColor = SystemColors.ButtonHighlight;
            labelDiretor.Location = new Point(53, 178);
            labelDiretor.Name = "labelDiretor";
            labelDiretor.Size = new Size(62, 21);
            labelDiretor.TabIndex = 23;
            labelDiretor.Text = "Diretor:";
            // 
            // labelGenero
            // 
            labelGenero.AutoSize = true;
            labelGenero.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelGenero.ForeColor = SystemColors.ButtonHighlight;
            labelGenero.Location = new Point(53, 125);
            labelGenero.Name = "labelGenero";
            labelGenero.Size = new Size(64, 21);
            labelGenero.TabIndex = 21;
            labelGenero.Text = "Gênero:";
            // 
            // campoTitulo
            // 
            campoTitulo.Location = new Point(53, 95);
            campoTitulo.Name = "campoTitulo";
            campoTitulo.Size = new Size(227, 23);
            campoTitulo.TabIndex = 20;
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelTitulo.ForeColor = SystemColors.ButtonHighlight;
            labelTitulo.Location = new Point(53, 71);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(52, 21);
            labelTitulo.TabIndex = 19;
            labelTitulo.Text = "Título:";
            // 
            // generoComboBox
            // 
            generoComboBox.FormattingEnabled = true;
            generoComboBox.Location = new Point(53, 149);
            generoComboBox.Name = "generoComboBox";
            generoComboBox.Size = new Size(227, 23);
            generoComboBox.TabIndex = 33;
            // 
            // classificacaoComboBox
            // 
            classificacaoComboBox.FormattingEnabled = true;
            classificacaoComboBox.Location = new Point(53, 256);
            classificacaoComboBox.Name = "classificacaoComboBox";
            classificacaoComboBox.Size = new Size(227, 23);
            classificacaoComboBox.TabIndex = 34;
            // 
            // labelNota
            // 
            labelNota.AutoSize = true;
            labelNota.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelNota.ForeColor = SystemColors.ButtonHighlight;
            labelNota.Location = new Point(53, 347);
            labelNota.Name = "labelNota";
            labelNota.Size = new Size(47, 21);
            labelNota.TabIndex = 36;
            labelNota.Text = "Nota:";
            // 
            // CampoNota
            // 
            CampoNota.Location = new Point(53, 371);
            CampoNota.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            CampoNota.Name = "CampoNota";
            CampoNota.Size = new Size(227, 23);
            CampoNota.TabIndex = 37;
            // 
            // campoDuracao
            // 
            campoDuracao.Location = new Point(53, 432);
            campoDuracao.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            campoDuracao.Name = "campoDuracao";
            campoDuracao.Size = new Size(227, 23);
            campoDuracao.TabIndex = 39;
            // 
            // labelDuracao
            // 
            labelDuracao.AutoSize = true;
            labelDuracao.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelDuracao.ForeColor = SystemColors.ButtonHighlight;
            labelDuracao.Location = new Point(53, 408);
            labelDuracao.Name = "labelDuracao";
            labelDuracao.Size = new Size(108, 21);
            labelDuracao.TabIndex = 38;
            labelDuracao.Text = "Duração(min):";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(32, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(273, 68);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 40;
            pictureBox1.TabStop = false;
            // 
            // campoDataDeLancamento
            // 
            campoDataDeLancamento.Format = DateTimePickerFormat.Short;
            campoDataDeLancamento.Location = new Point(53, 313);
            campoDataDeLancamento.Name = "campoDataDeLancamento";
            campoDataDeLancamento.Size = new Size(227, 23);
            campoDataDeLancamento.TabIndex = 41;
            campoDataDeLancamento.Value = new DateTime(2005, 11, 29, 0, 0, 0, 0);
            // 
            // FormCadastroFilme
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(339, 566);
            Controls.Add(campoDataDeLancamento);
            Controls.Add(pictureBox1);
            Controls.Add(campoDuracao);
            Controls.Add(labelDuracao);
            Controls.Add(CampoNota);
            Controls.Add(labelNota);
            Controls.Add(classificacaoComboBox);
            Controls.Add(generoComboBox);
            Controls.Add(botaoCancelar);
            Controls.Add(botaoCadastrar);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(campoDiretor);
            Controls.Add(labelDiretor);
            Controls.Add(labelGenero);
            Controls.Add(campoTitulo);
            Controls.Add(labelTitulo);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(355, 605);
            MinimumSize = new Size(355, 605);
            Name = "FormCadastroFilme";
            Text = "FormCadastroFilme";
            Load += AoCarregarFormCadastroFilme;
            ((System.ComponentModel.ISupportInitialize)CampoNota).EndInit();
            ((System.ComponentModel.ISupportInitialize)campoDuracao).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button botaoCancelar;
        private Button botaoCadastrar;
        private Label label5;
        private Label label4;
        private TextBox campoDiretor;
        private Label labelDiretor;
        private Label labelGenero;
        private TextBox campoTitulo;
        private Label labelTitulo;
        private ComboBox generoComboBox;
        private ComboBox classificacaoComboBox;
        private Label labelNota;
        private NumericUpDown CampoNota;
        private NumericUpDown campoDuracao;
        private Label labelDuracao;
        private PictureBox pictureBox1;
        private DateTimePicker campoDataDeLancamento;
    }
}