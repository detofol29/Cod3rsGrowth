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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormListaFilme));
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
            label1 = new Label();
            toolStrip1 = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            toolStripDropDownButton1 = new ToolStripDropDownButton();
            toolStripMenuItem1 = new ToolStripMenuItem();
            GeneroComboBox = new ToolStripComboBox();
            classificaçãoToolStripMenuItem = new ToolStripMenuItem();
            toolStripComboBox1 = new ToolStripComboBox();
            disponívelToolStripMenuItem = new ToolStripMenuItem();
            toolStripComboBox2 = new ToolStripComboBox();
            notaToolStripMenuItem = new ToolStripMenuItem();
            toolStripTextBox1 = new ToolStripTextBox();
            toolStripSeparator1 = new ToolStripSeparator();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)filmeBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)filmeBindingSource).BeginInit();
            toolStrip1.SuspendLayout();
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
            button1.Location = new Point(855, 28);
            button1.Name = "button1";
            button1.Size = new Size(86, 23);
            button1.TabIndex = 1;
            button1.Text = "filtrar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Monocraft", 29.9999962F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(237, 9);
            label1.Margin = new Padding(50);
            label1.MinimumSize = new Size(230, 0);
            label1.Name = "label1";
            label1.Padding = new Padding(10);
            label1.Size = new Size(463, 73);
            label1.TabIndex = 3;
            label1.Text = "Lista de Filmes";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // toolStrip1
            // 
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton1, toolStripDropDownButton1 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.RenderMode = ToolStripRenderMode.Professional;
            toolStrip1.Size = new Size(941, 25);
            toolStrip1.TabIndex = 5;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            toolStripButton1.Alignment = ToolStripItemAlignment.Right;
            toolStripButton1.BackColor = SystemColors.ActiveBorder;
            toolStripButton1.BackgroundImageLayout = ImageLayout.Center;
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.MergeAction = MergeAction.MatchOnly;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(83, 22);
            toolStripButton1.Text = "Limpar Filtros";
            toolStripButton1.Click += toolStripButton1_Click;
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.Alignment = ToolStripItemAlignment.Right;
            toolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton1.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem1, classificaçãoToolStripMenuItem, disponívelToolStripMenuItem, notaToolStripMenuItem, toolStripSeparator1 });
            toolStripDropDownButton1.Image = (Image)resources.GetObject("toolStripDropDownButton1.Image");
            toolStripDropDownButton1.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            toolStripDropDownButton1.Size = new Size(52, 22);
            toolStripDropDownButton1.Text = "Filtros";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { GeneroComboBox });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(180, 22);
            toolStripMenuItem1.Text = "Genero";
            // 
            // GeneroComboBox
            // 
            GeneroComboBox.Name = "GeneroComboBox";
            GeneroComboBox.Size = new Size(121, 23);
            // 
            // classificaçãoToolStripMenuItem
            // 
            classificaçãoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripComboBox1 });
            classificaçãoToolStripMenuItem.Name = "classificaçãoToolStripMenuItem";
            classificaçãoToolStripMenuItem.Size = new Size(180, 22);
            classificaçãoToolStripMenuItem.Text = "Classificação";
            // 
            // toolStripComboBox1
            // 
            toolStripComboBox1.Name = "toolStripComboBox1";
            toolStripComboBox1.Size = new Size(121, 23);
            // 
            // disponívelToolStripMenuItem
            // 
            disponívelToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripComboBox2 });
            disponívelToolStripMenuItem.Name = "disponívelToolStripMenuItem";
            disponívelToolStripMenuItem.Size = new Size(180, 22);
            disponívelToolStripMenuItem.Text = "Disponível";
            // 
            // toolStripComboBox2
            // 
            toolStripComboBox2.Name = "toolStripComboBox2";
            toolStripComboBox2.Size = new Size(121, 23);
            // 
            // notaToolStripMenuItem
            // 
            notaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripTextBox1 });
            notaToolStripMenuItem.Name = "notaToolStripMenuItem";
            notaToolStripMenuItem.Size = new Size(180, 22);
            notaToolStripMenuItem.Text = "Nota";
            // 
            // toolStripTextBox1
            // 
            toolStripTextBox1.Name = "toolStripTextBox1";
            toolStripTextBox1.Size = new Size(100, 23);
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(177, 6);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 395);
            label2.Name = "label2";
            label2.Size = new Size(88, 15);
            label2.TabIndex = 6;
            label2.Text = "Gênero :  Todos";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(128, 395);
            label3.Name = "label3";
            label3.Size = new Size(117, 15);
            label3.TabIndex = 7;
            label3.Text = "Classificação :  Todas";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(297, 395);
            label4.Name = "label4";
            label4.Size = new Size(102, 15);
            label4.TabIndex = 8;
            label4.Text = "Disponível : Todos";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(459, 395);
            label5.Name = "label5";
            label5.Size = new Size(139, 15);
            label5.TabIndex = 9;
            label5.Text = "Nota Mínima:  Nenhuma";
            // 
            // FormListaFilme
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(941, 419);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(toolStrip1);
            Name = "FormListaFilme";
            Text = "Lista de Filmes";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)filmeBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)filmeBindingSource).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public DataGridView dataGridView1;
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
        private Label label1;
        private ToolStrip toolStrip1;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripComboBox GeneroComboBox;
        private ToolStripMenuItem classificaçãoToolStripMenuItem;
        private ToolStripComboBox toolStripComboBox1;
        private ToolStripMenuItem disponívelToolStripMenuItem;
        private ToolStripComboBox toolStripComboBox2;
        private ToolStripMenuItem notaToolStripMenuItem;
        private ToolStripTextBox toolStripTextBox1;
        private ToolStripButton toolStripButton1;
        private ToolStripSeparator toolStripSeparator1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}