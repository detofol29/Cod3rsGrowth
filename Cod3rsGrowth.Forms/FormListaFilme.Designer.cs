using Cod3rsGrowth.Dominio.Extensoes;

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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormListaFilme));
            dataGridView1 = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            tituloDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dataDeLancamentoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            generoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            emCartazDataGridViewCheckBoxColumn = new DataGridViewTextBoxColumn();
            notaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            duracaoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            disponivelNoPlanoDataGridViewCheckBoxColumn = new DataGridViewTextBoxColumn();
            diretorDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            classificacaoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            filmeMockBindingSource = new BindingSource(components);
            filmeBindingSource1 = new BindingSource(components);
            filmeBindingSource = new BindingSource(components);
            toolStrip1 = new ToolStrip();
            botaoLimparFiltros = new ToolStripButton();
            botaoFiltrar = new ToolStripButton();
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
            botaoSair = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            labelUsuario = new ToolStripLabel();
            labelFiltroGenero = new Label();
            labelFiltroClassificacao = new Label();
            labelFiltroDisponivel = new Label();
            labelFiltroNota = new Label();
            imageList1 = new ImageList(components);
            pictureBox2 = new PictureBox();
            labelFiltros = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)filmeMockBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)filmeBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)filmeBindingSource).BeginInit();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.Anchor = AnchorStyles.Top;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.BackgroundColor = SystemColors.ActiveCaptionText;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, tituloDataGridViewTextBoxColumn, dataDeLancamentoDataGridViewTextBoxColumn, generoDataGridViewTextBoxColumn, emCartazDataGridViewCheckBoxColumn, notaDataGridViewTextBoxColumn, duracaoDataGridViewTextBoxColumn, disponivelNoPlanoDataGridViewCheckBoxColumn, diretorDataGridViewTextBoxColumn, classificacaoDataGridViewTextBoxColumn });
            dataGridView1.Cursor = Cursors.Hand;
            dataGridView1.DataSource = filmeMockBindingSource;
            dataGridView1.GridColor = SystemColors.InactiveCaptionText;
            dataGridView1.Location = new Point(12, 95);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(1061, 296);
            dataGridView1.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.Frozen = true;
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            idDataGridViewTextBoxColumn.Width = 40;
            // 
            // tituloDataGridViewTextBoxColumn
            // 
            tituloDataGridViewTextBoxColumn.DataPropertyName = "Titulo";
            tituloDataGridViewTextBoxColumn.Frozen = true;
            tituloDataGridViewTextBoxColumn.HeaderText = "Título";
            tituloDataGridViewTextBoxColumn.Name = "tituloDataGridViewTextBoxColumn";
            tituloDataGridViewTextBoxColumn.ReadOnly = true;
            tituloDataGridViewTextBoxColumn.Width = 200;
            // 
            // dataDeLancamentoDataGridViewTextBoxColumn
            // 
            dataDeLancamentoDataGridViewTextBoxColumn.DataPropertyName = "DataDeLancamento";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataDeLancamentoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            dataDeLancamentoDataGridViewTextBoxColumn.Frozen = true;
            dataDeLancamentoDataGridViewTextBoxColumn.HeaderText = "Data De Lançamento";
            dataDeLancamentoDataGridViewTextBoxColumn.Name = "dataDeLancamentoDataGridViewTextBoxColumn";
            dataDeLancamentoDataGridViewTextBoxColumn.ReadOnly = true;
            dataDeLancamentoDataGridViewTextBoxColumn.Width = 140;
            // 
            // generoDataGridViewTextBoxColumn
            // 
            generoDataGridViewTextBoxColumn.DataPropertyName = "Genero";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            generoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            generoDataGridViewTextBoxColumn.Frozen = true;
            generoDataGridViewTextBoxColumn.HeaderText = "Gênero";
            generoDataGridViewTextBoxColumn.Name = "generoDataGridViewTextBoxColumn";
            generoDataGridViewTextBoxColumn.ReadOnly = true;
            generoDataGridViewTextBoxColumn.Width = 80;
            // 
            // emCartazDataGridViewCheckBoxColumn
            // 
            emCartazDataGridViewCheckBoxColumn.DataPropertyName = "EmCartaz";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            emCartazDataGridViewCheckBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            emCartazDataGridViewCheckBoxColumn.Frozen = true;
            emCartazDataGridViewCheckBoxColumn.HeaderText = "Em Cartaz";
            emCartazDataGridViewCheckBoxColumn.Name = "emCartazDataGridViewCheckBoxColumn";
            emCartazDataGridViewCheckBoxColumn.ReadOnly = true;
            emCartazDataGridViewCheckBoxColumn.Resizable = DataGridViewTriState.True;
            emCartazDataGridViewCheckBoxColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // notaDataGridViewTextBoxColumn
            // 
            notaDataGridViewTextBoxColumn.DataPropertyName = "Nota";
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = "0";
            notaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            notaDataGridViewTextBoxColumn.Frozen = true;
            notaDataGridViewTextBoxColumn.HeaderText = "Nota";
            notaDataGridViewTextBoxColumn.Name = "notaDataGridViewTextBoxColumn";
            notaDataGridViewTextBoxColumn.ReadOnly = true;
            notaDataGridViewTextBoxColumn.Width = 50;
            // 
            // duracaoDataGridViewTextBoxColumn
            // 
            duracaoDataGridViewTextBoxColumn.DataPropertyName = "Duracao";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            duracaoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            duracaoDataGridViewTextBoxColumn.Frozen = true;
            duracaoDataGridViewTextBoxColumn.HeaderText = "Duração";
            duracaoDataGridViewTextBoxColumn.Name = "duracaoDataGridViewTextBoxColumn";
            duracaoDataGridViewTextBoxColumn.ReadOnly = true;
            duracaoDataGridViewTextBoxColumn.Width = 60;
            // 
            // disponivelNoPlanoDataGridViewCheckBoxColumn
            // 
            disponivelNoPlanoDataGridViewCheckBoxColumn.DataPropertyName = "DisponivelNoPlano";
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            disponivelNoPlanoDataGridViewCheckBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            disponivelNoPlanoDataGridViewCheckBoxColumn.HeaderText = "Disponível No Plano";
            disponivelNoPlanoDataGridViewCheckBoxColumn.Name = "disponivelNoPlanoDataGridViewCheckBoxColumn";
            disponivelNoPlanoDataGridViewCheckBoxColumn.ReadOnly = true;
            disponivelNoPlanoDataGridViewCheckBoxColumn.Resizable = DataGridViewTriState.True;
            disponivelNoPlanoDataGridViewCheckBoxColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            disponivelNoPlanoDataGridViewCheckBoxColumn.Width = 130;
            // 
            // diretorDataGridViewTextBoxColumn
            // 
            diretorDataGridViewTextBoxColumn.DataPropertyName = "Diretor";
            diretorDataGridViewTextBoxColumn.HeaderText = "Diretor";
            diretorDataGridViewTextBoxColumn.Name = "diretorDataGridViewTextBoxColumn";
            diretorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // classificacaoDataGridViewTextBoxColumn
            // 
            classificacaoDataGridViewTextBoxColumn.DataPropertyName = "Classificacao";
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            classificacaoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            classificacaoDataGridViewTextBoxColumn.HeaderText = "Classificação";
            classificacaoDataGridViewTextBoxColumn.Name = "classificacaoDataGridViewTextBoxColumn";
            classificacaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // filmeMockBindingSource
            // 
            filmeMockBindingSource.DataSource = typeof(FilmeData);
            // 
            // filmeBindingSource1
            // 
            filmeBindingSource1.DataSource = typeof(Dominio.Modelos.Filme);
            // 
            // filmeBindingSource
            // 
            filmeBindingSource.DataSource = typeof(Dominio.Modelos.Filme);
            // 
            // toolStrip1
            // 
            toolStrip1.AllowMerge = false;
            toolStrip1.BackColor = Color.Black;
            toolStrip1.BackgroundImageLayout = ImageLayout.None;
            toolStrip1.CanOverflow = false;
            toolStrip1.Font = new Font("Yu Gothic UI Semibold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            toolStrip1.GripMargin = new Padding(0);
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new ToolStripItem[] { botaoLimparFiltros, botaoFiltrar, toolStripDropDownButton1, botaoSair, toolStripSeparator2, labelUsuario });
            toolStrip1.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.RenderMode = ToolStripRenderMode.System;
            toolStrip1.Size = new Size(1085, 25);
            toolStrip1.TabIndex = 5;
            toolStrip1.Text = "toolStrip1";
            // 
            // botaoLimparFiltros
            // 
            botaoLimparFiltros.Alignment = ToolStripItemAlignment.Right;
            botaoLimparFiltros.BackColor = Color.Red;
            botaoLimparFiltros.BackgroundImageLayout = ImageLayout.Center;
            botaoLimparFiltros.DisplayStyle = ToolStripItemDisplayStyle.Text;
            botaoLimparFiltros.Image = (Image)resources.GetObject("botaoLimparFiltros.Image");
            botaoLimparFiltros.ImageTransparentColor = Color.Magenta;
            botaoLimparFiltros.MergeAction = MergeAction.MatchOnly;
            botaoLimparFiltros.Name = "botaoLimparFiltros";
            botaoLimparFiltros.Size = new Size(83, 22);
            botaoLimparFiltros.Text = "Limpar Filtros";
            botaoLimparFiltros.TextAlign = ContentAlignment.MiddleRight;
            botaoLimparFiltros.Click += AoClicarBotaoLimparFiltros;
            // 
            // botaoFiltrar
            // 
            botaoFiltrar.Alignment = ToolStripItemAlignment.Right;
            botaoFiltrar.BackColor = Color.Red;
            botaoFiltrar.DisplayStyle = ToolStripItemDisplayStyle.Text;
            botaoFiltrar.ForeColor = SystemColors.ActiveCaptionText;
            botaoFiltrar.ImageTransparentColor = Color.Magenta;
            botaoFiltrar.Name = "botaoFiltrar";
            botaoFiltrar.Size = new Size(41, 22);
            botaoFiltrar.Text = "Filtrar";
            botaoFiltrar.Click += AoClicarBotaoFiltrar;
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.Alignment = ToolStripItemAlignment.Right;
            toolStripDropDownButton1.BackColor = Color.Black;
            toolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton1.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem1, classificaçãoToolStripMenuItem, disponívelToolStripMenuItem, notaToolStripMenuItem, toolStripSeparator1 });
            toolStripDropDownButton1.ForeColor = SystemColors.ButtonFace;
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
            toolStripMenuItem1.Text = "Gênero";
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
            // botaoSair
            // 
            botaoSair.BackColor = Color.Red;
            botaoSair.DisplayStyle = ToolStripItemDisplayStyle.Text;
            botaoSair.Image = (Image)resources.GetObject("botaoSair.Image");
            botaoSair.ImageTransparentColor = Color.Magenta;
            botaoSair.Name = "botaoSair";
            botaoSair.Size = new Size(31, 22);
            botaoSair.Text = "Sair";
            botaoSair.Click += AoClicarBotaoSair;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            // 
            // labelUsuario
            // 
            labelUsuario.ForeColor = SystemColors.ButtonFace;
            labelUsuario.Name = "labelUsuario";
            labelUsuario.Size = new Size(53, 22);
            labelUsuario.Text = "Usuário: ";
            // 
            // labelFiltroGenero
            // 
            labelFiltroGenero.Anchor = AnchorStyles.Bottom;
            labelFiltroGenero.AutoSize = true;
            labelFiltroGenero.BackColor = Color.Black;
            labelFiltroGenero.ForeColor = SystemColors.ButtonFace;
            labelFiltroGenero.Location = new Point(349, 399);
            labelFiltroGenero.Name = "labelFiltroGenero";
            labelFiltroGenero.Size = new Size(88, 15);
            labelFiltroGenero.TabIndex = 6;
            labelFiltroGenero.Text = "Gênero :  Todos";
            // 
            // labelFiltroClassificacao
            // 
            labelFiltroClassificacao.Anchor = AnchorStyles.Bottom;
            labelFiltroClassificacao.AutoSize = true;
            labelFiltroClassificacao.ForeColor = SystemColors.ButtonFace;
            labelFiltroClassificacao.Location = new Point(452, 399);
            labelFiltroClassificacao.Name = "labelFiltroClassificacao";
            labelFiltroClassificacao.Size = new Size(117, 15);
            labelFiltroClassificacao.TabIndex = 7;
            labelFiltroClassificacao.Text = "Classificação :  Todas";
            // 
            // labelFiltroDisponivel
            // 
            labelFiltroDisponivel.Anchor = AnchorStyles.Bottom;
            labelFiltroDisponivel.AutoSize = true;
            labelFiltroDisponivel.ForeColor = SystemColors.ButtonFace;
            labelFiltroDisponivel.Location = new Point(585, 399);
            labelFiltroDisponivel.Name = "labelFiltroDisponivel";
            labelFiltroDisponivel.Size = new Size(102, 15);
            labelFiltroDisponivel.TabIndex = 8;
            labelFiltroDisponivel.Text = "Disponível : Todos";
            // 
            // labelFiltroNota
            // 
            labelFiltroNota.Anchor = AnchorStyles.Bottom;
            labelFiltroNota.AutoSize = true;
            labelFiltroNota.ForeColor = SystemColors.ButtonFace;
            labelFiltroNota.Location = new Point(703, 399);
            labelFiltroNota.Name = "labelFiltroNota";
            labelFiltroNota.Size = new Size(139, 15);
            labelFiltroNota.TabIndex = 9;
            labelFiltroNota.Text = "Nota Mínima:  Nenhuma";
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "icons8-filme-50.png");
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox2.BackgroundImageLayout = ImageLayout.Center;
            pictureBox2.Image = Properties.Resources.imagem_listaDeFilmes;
            pictureBox2.Location = new Point(338, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(434, 86);
            pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox2.TabIndex = 12;
            pictureBox2.TabStop = false;
            // 
            // labelFiltros
            // 
            labelFiltros.AutoSize = true;
            labelFiltros.ForeColor = SystemColors.ButtonHighlight;
            labelFiltros.Location = new Point(282, 399);
            labelFiltros.Name = "labelFiltros";
            labelFiltros.Size = new Size(52, 15);
            labelFiltros.TabIndex = 13;
            labelFiltros.Text = "FILTROS:";
            // 
            // FormListaFilme
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1085, 423);
            Controls.Add(labelFiltros);
            Controls.Add(pictureBox2);
            Controls.Add(labelFiltroNota);
            Controls.Add(labelFiltroDisponivel);
            Controls.Add(labelFiltroClassificacao);
            Controls.Add(labelFiltroGenero);
            Controls.Add(dataGridView1);
            Controls.Add(toolStrip1);
            ForeColor = SystemColors.ActiveCaptionText;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(1101, 462);
            MinimumSize = new Size(1101, 462);
            Name = "FormListaFilme";
            Text = "Lista de Filmes";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)filmeMockBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)filmeBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)filmeBindingSource).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public DataGridView dataGridView1;
        private BindingSource filmeBindingSource1;
        private BindingSource filmeBindingSource;
        private BindingSource filmeMockBindingSource;
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
        private ToolStripButton botaoLimparFiltros;
        private ToolStripSeparator toolStripSeparator1;
        private Label labelFiltroGenero;
        private Label labelFiltroClassificacao;
        private Label labelFiltroDisponivel;
        private Label labelFiltroNota;
        private ImageList imageList1;
        private PictureBox pictureBox2;
        private ToolStripLabel labelUsuario;
        private ToolStripButton botaoFiltrar;
        private Label labelFiltros;
        private ToolStripButton botaoSair;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn tituloDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dataDeLancamentoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn generoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn emCartazDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn notaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn duracaoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn disponivelNoPlanoDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn diretorDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn classificacaoDataGridViewTextBoxColumn;
        private ToolStripSeparator toolStripSeparator2;
    }
}