namespace Cod3rsGrowth.Forms
{
    partial class FormFiltro
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            comboBoxGenero = new ComboBox();
            comboBoxDisponivel = new ComboBox();
            comboBoxClassificacao = new ComboBox();
            comboBoxEmCartaz = new ComboBox();
            botaoFiltrar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 0;
            label1.Text = "Genero";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 136);
            label2.Name = "label2";
            label2.Size = new Size(75, 15);
            label2.TabIndex = 1;
            label2.Text = "Classificacao";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 74);
            label3.Name = "label3";
            label3.Size = new Size(62, 15);
            label3.TabIndex = 2;
            label3.Text = "Disponivel";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 195);
            label4.Name = "label4";
            label4.Size = new Size(58, 15);
            label4.TabIndex = 3;
            label4.Text = "Em cartaz";
            // 
            // comboBoxGenero
            // 
            comboBoxGenero.FormattingEnabled = true;
            comboBoxGenero.Items.AddRange(new object[] { "Nenhum" });
            comboBoxGenero.Location = new Point(12, 27);
            comboBoxGenero.Name = "comboBoxGenero";
            comboBoxGenero.Size = new Size(136, 23);
            comboBoxGenero.TabIndex = 4;
            comboBoxGenero.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // comboBoxDisponivel
            // 
            comboBoxDisponivel.FormattingEnabled = true;
            comboBoxDisponivel.Items.AddRange(new object[] { "Nenhum" });
            comboBoxDisponivel.Location = new Point(12, 92);
            comboBoxDisponivel.Name = "comboBoxDisponivel";
            comboBoxDisponivel.Size = new Size(136, 23);
            comboBoxDisponivel.TabIndex = 5;
            // 
            // comboBoxClassificacao
            // 
            comboBoxClassificacao.FormattingEnabled = true;
            comboBoxClassificacao.Items.AddRange(new object[] { "Nenhum" });
            comboBoxClassificacao.Location = new Point(12, 154);
            comboBoxClassificacao.Name = "comboBoxClassificacao";
            comboBoxClassificacao.Size = new Size(136, 23);
            comboBoxClassificacao.TabIndex = 6;
            // 
            // comboBoxEmCartaz
            // 
            comboBoxEmCartaz.FormattingEnabled = true;
            comboBoxEmCartaz.Items.AddRange(new object[] { "Nenhum" });
            comboBoxEmCartaz.Location = new Point(12, 213);
            comboBoxEmCartaz.Name = "comboBoxEmCartaz";
            comboBoxEmCartaz.Size = new Size(136, 23);
            comboBoxEmCartaz.TabIndex = 7;
            // 
            // botaoFiltrar
            // 
            botaoFiltrar.Location = new Point(12, 260);
            botaoFiltrar.Name = "botaoFiltrar";
            botaoFiltrar.Size = new Size(119, 26);
            botaoFiltrar.TabIndex = 8;
            botaoFiltrar.Text = "Filtrar";
            botaoFiltrar.UseVisualStyleBackColor = true;
            botaoFiltrar.Click += botaoFiltrar_Click;
            // 
            // FormFiltro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(163, 310);
            Controls.Add(botaoFiltrar);
            Controls.Add(comboBoxEmCartaz);
            Controls.Add(comboBoxClassificacao);
            Controls.Add(comboBoxDisponivel);
            Controls.Add(comboBoxGenero);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormFiltro";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox comboBoxGenero;
        private ComboBox comboBoxDisponivel;
        private ComboBox comboBoxClassificacao;
        private ComboBox comboBoxEmCartaz;
        private Button button1;
        private Button botaoFiltrar;
    }
}