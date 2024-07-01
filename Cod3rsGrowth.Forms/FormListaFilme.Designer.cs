namespace Cod3rsGrowth.Forms
{
    partial class FormListaFilme
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

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            dataGridView1 = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            tituloDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dataDeLancamentoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            generoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            emCartazDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            notaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            duracaoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            disponivelNoPlanoDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            diretorDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            classificacaoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            filmeBindingSource1 = new BindingSource(components);
            filmeBindingSource = new BindingSource(components);
            button1 = new Button();
            comboBox1 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)filmeBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)filmeBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, tituloDataGridViewTextBoxColumn, dataDeLancamentoDataGridViewTextBoxColumn, generoDataGridViewTextBoxColumn, emCartazDataGridViewCheckBoxColumn, notaDataGridViewTextBoxColumn, duracaoDataGridViewTextBoxColumn, disponivelNoPlanoDataGridViewCheckBoxColumn, diretorDataGridViewTextBoxColumn, classificacaoDataGridViewTextBoxColumn });
            dataGridView1.DataSource = filmeBindingSource1;
            dataGridView1.Location = new Point(12, 95);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(917, 296);
            dataGridView1.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // tituloDataGridViewTextBoxColumn
            // 
            tituloDataGridViewTextBoxColumn.DataPropertyName = "Titulo";
            tituloDataGridViewTextBoxColumn.HeaderText = "Titulo";
            tituloDataGridViewTextBoxColumn.Name = "tituloDataGridViewTextBoxColumn";
            // 
            // dataDeLancamentoDataGridViewTextBoxColumn
            // 
            dataDeLancamentoDataGridViewTextBoxColumn.DataPropertyName = "DataDeLancamento";
            dataDeLancamentoDataGridViewTextBoxColumn.HeaderText = "DataDeLancamento";
            dataDeLancamentoDataGridViewTextBoxColumn.Name = "dataDeLancamentoDataGridViewTextBoxColumn";
            // 
            // generoDataGridViewTextBoxColumn
            // 
            generoDataGridViewTextBoxColumn.DataPropertyName = "Genero";
            generoDataGridViewTextBoxColumn.HeaderText = "Genero";
            generoDataGridViewTextBoxColumn.Name = "generoDataGridViewTextBoxColumn";
            // 
            // emCartazDataGridViewCheckBoxColumn
            // 
            emCartazDataGridViewCheckBoxColumn.DataPropertyName = "EmCartaz";
            emCartazDataGridViewCheckBoxColumn.HeaderText = "EmCartaz";
            emCartazDataGridViewCheckBoxColumn.Name = "emCartazDataGridViewCheckBoxColumn";
            // 
            // notaDataGridViewTextBoxColumn
            // 
            notaDataGridViewTextBoxColumn.DataPropertyName = "Nota";
            notaDataGridViewTextBoxColumn.HeaderText = "Nota";
            notaDataGridViewTextBoxColumn.Name = "notaDataGridViewTextBoxColumn";
            // 
            // duracaoDataGridViewTextBoxColumn
            // 
            duracaoDataGridViewTextBoxColumn.DataPropertyName = "Duracao";
            duracaoDataGridViewTextBoxColumn.HeaderText = "Duracao";
            duracaoDataGridViewTextBoxColumn.Name = "duracaoDataGridViewTextBoxColumn";
            // 
            // disponivelNoPlanoDataGridViewCheckBoxColumn
            // 
            disponivelNoPlanoDataGridViewCheckBoxColumn.DataPropertyName = "DisponivelNoPlano";
            disponivelNoPlanoDataGridViewCheckBoxColumn.HeaderText = "DisponivelNoPlano";
            disponivelNoPlanoDataGridViewCheckBoxColumn.Name = "disponivelNoPlanoDataGridViewCheckBoxColumn";
            // 
            // diretorDataGridViewTextBoxColumn
            // 
            diretorDataGridViewTextBoxColumn.DataPropertyName = "Diretor";
            diretorDataGridViewTextBoxColumn.HeaderText = "Diretor";
            diretorDataGridViewTextBoxColumn.Name = "diretorDataGridViewTextBoxColumn";
            // 
            // classificacaoDataGridViewTextBoxColumn
            // 
            classificacaoDataGridViewTextBoxColumn.DataPropertyName = "Classificacao";
            classificacaoDataGridViewTextBoxColumn.HeaderText = "Classificacao";
            classificacaoDataGridViewTextBoxColumn.Name = "classificacaoDataGridViewTextBoxColumn";
            // 
            // filmeBindingSource1
            // 
            filmeBindingSource1.DataSource = typeof(Dominio.Modelos.Filme);
            // 
            // filmeBindingSource
            // 
            filmeBindingSource.DataSource = typeof(Dominio.Modelos.Filme);
            // 
            // button1
            // 
            button1.Location = new Point(778, 22);
            button1.Name = "button1";
            button1.Size = new Size(110, 30);
            button1.TabIndex = 1;
            button1.Text = "filtrar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(549, 29);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(174, 23);
            comboBox1.TabIndex = 2;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged_1;
            // 
            // FormListaFilme
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(941, 419);
            Controls.Add(comboBox1);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Name = "FormListaFilme";
            Text = "Lista de Filmes";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)filmeBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)filmeBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn tituloDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dataDeLancamentoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn generoDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn emCartazDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn notaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn duracaoDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn disponivelNoPlanoDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn diretorDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn classificacaoDataGridViewTextBoxColumn;
        private BindingSource filmeBindingSource1;
        private BindingSource filmeBindingSource;
        private Button button1;
        private ComboBox comboBox1;
    }
}