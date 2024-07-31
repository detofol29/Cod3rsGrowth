using Cod3rsGrowth.Dominio.Extensoes;
using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Domuinio.Enumeradores;
using Cod3rsGrowth.Infra.Repositorios;
using Cod3rsGrowth.Servicos.Servicos;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Cod3rsGrowth.Forms;

public partial class FormListaFilme : Form
{
    private Usuario usuario;
    private FilmeServicos service;
    private UsuarioServicos servicoUsuario;
    private UsuarioRepositorio repositorio;
    private Thread threadFormsAutenticacao;
    private const string todosElementos = "Todos";
    private const string nenhumElemento = "Nenhum";
    private const string filtroGenero = "Gênero: ";
    private const string filtroClassificacao = "Classificação: ";
    private const string filtroDisponivelLabel = "Disponível: ";
    private const string filtroNota = "Nota Mínima: ";
    private const string disponivel = "Sim";
    private const string indisponivel = "Não";
    private bool filtroDisponivel;
    private bool filtroDisponivelTodos;
    FiltroFilme filtro = new();
    List<Filme> listaDeFilmes = new();
    public FormListaFilme(FilmeServicos _service, Usuario _usuario, UsuarioServicos _servicoUsuario, UsuarioRepositorio _repositorio)
    {
        service = _service;
        usuario = _usuario;
        servicoUsuario = _servicoUsuario;
        repositorio = _repositorio;

        InitializeComponent();
        IniciarListaDeFimes();
        dataGridView1.DataSource = ServicoFilmeData.ConverteFilmeParaData(listaDeFilmes);

        foreach (var genero in Enum.GetValues(typeof(GeneroEnum)))
        {
            generoComboBox.Items.Add(ExtensaoDosEnuns.ObterDescricao((Enum)genero));
        }
        generoComboBox.Items.Add(todosElementos);
        generoComboBox.SelectedItem = todosElementos;

        foreach (var classificacao in Enum.GetValues(typeof(ClassificacaoIndicativa)))
        {
            classificacaoComboBox.Items.Add(ExtensaoDosEnuns.ObterDescricao((Enum)classificacao));
        }
        classificacaoComboBox.Items.Add(todosElementos);
        classificacaoComboBox.SelectedItem = todosElementos;

        foreach (var disponivel in Enum.GetValues(typeof(EnumDisponivel)))
        {
            DisponivelComboBox.Items.Add(ExtensaoDosEnuns.ObterDescricao((Enum)disponivel));
        }
        DisponivelComboBox.SelectedItem = ExtensaoDosEnuns.ObterDescricao(EnumDisponivel.Sim);

        AoClicarBotaoFiltrar(null, null);
        labelUsuario.Text += usuario.Nome;
    }

    public void IniciarListaDeFimes()
    {
        var lista = service.ObterTodos(null);
        listaDeFilmes.Clear();
        foreach (var filme in lista)
        {
            listaDeFilmes.Add(servicoUsuario.LicenciarFilmePorUsuario(usuario, filme));
        }
    }

    private void AoClicarBotaoLimparFiltros(object sender, EventArgs e)
    {
        generoComboBox.SelectedItem = todosElementos;
        classificacaoComboBox.SelectedItem = todosElementos;
        DisponivelComboBox.SelectedItem = todosElementos;
        filtroDisponivelTodos = true;
        toolStripTextBox1.Clear();

        labelFiltroGenero.Text = filtroGenero + todosElementos;
        labelFiltroClassificacao.Text = filtroClassificacao + todosElementos;
        labelFiltroDisponivel.Text = filtroDisponivelLabel + todosElementos;
        labelFiltroNota.Text = filtroNota + nenhumElemento;

        dataGridView1.DataSource = ServicoFilmeData.ConverteFilmeParaData(listaDeFilmes);
    }

    private void AoClicarBotaoFiltrar(object? sender, EventArgs? e)
    {
        var filmesLicenciados = new List<Filme>();

        AdicionarFiltroGenero();
        AdicionarFiltroClassificacao();
        AdicionarFiltroNotaMinima();
        AdicionarFiltroDisponivel();

        foreach (var filme in service.ObterTodos(filtro))
        {
            filmesLicenciados.Add(servicoUsuario.LicenciarFilmePorUsuario(usuario, filme));
        }

        dataGridView1.DataSource = filtroDisponivelTodos
            ? ServicoFilmeData.ConverteFilmeParaData(filmesLicenciados)
            : ServicoFilmeData.ConverteFilmeParaData(filmesLicenciados
                    .Where(f => f.DisponivelNoPlano == filtroDisponivel)
                    .Select(f => f)
                    .ToList());

        AtualizarBarraDeFiltros();
    }

    private void AdicionarFiltroNotaMinima()
    {
        var valorFiltro = toolStripTextBox1.Text.IsNullOrEmpty()
            ? default
            : int.Parse(toolStripTextBox1.Text);

        filtro.FiltroNotaMinima = valorFiltro;
    }

    private void AdicionarFiltroClassificacao()
    {
        if (classificacaoComboBox.SelectedItem != todosElementos) 
        {
            var enumeradores = new TodosEnumeradores();
            var classificacoes = enumeradores.ObterTodos<ClassificacaoIndicativa>();
            var classificacao = classificacoes
                .Where(g => g.Descricao == classificacaoComboBox.SelectedItem.ToString())
                .FirstOrDefault();

            filtro.FiltroClassificacao = ExtensaoDosEnuns.ConverterParaClassificacaoEnum(classificacao!);
        }
        else
        {
            filtro.FiltroClassificacao = null;
        }
    }

    private void AdicionarFiltroGenero()
    {
        if (generoComboBox.SelectedItem != todosElementos)
        {
            var enumeradores = new TodosEnumeradores();
            var generos = enumeradores.ObterTodos<GeneroEnum>();
            var genero = generos
                .Where(g => g.Descricao == generoComboBox.SelectedItem.ToString())
                .FirstOrDefault();

            filtro.FiltroGenero = ExtensaoDosEnuns.ConverterParaGeneroEnum(genero!);
        }
        else
        {
            filtro.FiltroGenero = null;
        }
    }

    private void AtualizarBarraDeFiltros()
    {
        labelFiltroGenero.Text = filtroGenero + generoComboBox.SelectedItem.ToString();
        labelFiltroClassificacao.Text = filtroClassificacao + classificacaoComboBox.SelectedItem.ToString();
        labelFiltroDisponivel.Text = filtroDisponivelLabel + DisponivelComboBox.SelectedItem.ToString();
        labelFiltroNota.Text = toolStripTextBox1.Text.IsNullOrEmpty() 
            ? filtroNota + nenhumElemento 
            : filtroNota + toolStripTextBox1.Text;
    }

    private void AdicionarFiltroDisponivel()
    {
        if (DisponivelComboBox.SelectedItem.ToString() == todosElementos)
        {
            filtroDisponivelTodos = true;
        }
        else
        {
            switch (DisponivelComboBox.SelectedItem)
            {
                case disponivel:
                    filtroDisponivel = true;
                    filtroDisponivelTodos = false;
                    break;
                case indisponivel:
                    filtroDisponivel = false;
                    filtroDisponivelTodos = false;
                    break;
            }
        }
    }

    private void AoClicarBotaoSair(object sender, EventArgs e)
    {
        var mensagemDeConfirmacao = "Deseja Realmente sair?";
        DialogResult resultado = MessageBox.Show(mensagemDeConfirmacao, "Sair", MessageBoxButtons.YesNo);

        if (resultado == DialogResult.Yes)
        {
            this.Close();
            threadFormsAutenticacao = new Thread(AbrirJanelaLogin);
            threadFormsAutenticacao.SetApartmentState(ApartmentState.STA);
            threadFormsAutenticacao.Start();
        }
    }

    private void AbrirJanelaLogin(object obj)
    {
        Application.Run(new FormAutenticacao(servicoUsuario, service, repositorio));
    }

    private void validarEntradaDeValoresNumericos(object sender, KeyPressEventArgs e)
    {
        if (!(char.IsNumber(e.KeyChar)) && !(char.IsControl(e.KeyChar)))
        {
            e.Handled = true;
        }
    }

    private void AoClicarBotaoCadastrarFilme(object sender, EventArgs e)
    {
        var cadastroFilme = new FormCadastroFilme(service, null);
        cadastroFilme.ShowDialog();
        IniciarListaDeFimes();
        dataGridView1.DataSource = ServicoFilmeData.ConverteFilmeParaData(listaDeFilmes);
    }

    private void AoClicarBotaoRemover(object sender, EventArgs e)
    {
        
        var quantidadeDeLinhasSelecionadas = dataGridView1.SelectedRows.Count;
        var mensagemDeErro = "Selecione pelo menos uma linha para ser removida!";

        if (quantidadeDeLinhasSelecionadas == default)
        {
            MessageBox.Show(mensagemDeErro);
        }
        else
        {
            var listaFilmesRemover = dataGridView1.SelectedRows
                .Cast<DataGridViewRow>()
                .Select(linha => (FilmeData)linha.DataBoundItem)
                .ToList();

            var filmesRemover = new StringBuilder();
            foreach (var filme in listaFilmesRemover)
            {
                filmesRemover.AppendLine(filme.Titulo);
            }

            var mensagemDeConfirmacao = $"Deseja Realmente remover o(os) filme(s) a seguir da lista de filmes?\n\n {filmesRemover}";
            var mensagemDeFilmesRemovidos = "Filmes Removidos com sucesso!";

            DialogResult resultado = MessageBox.Show(mensagemDeConfirmacao , "Remover", MessageBoxButtons.YesNo);

            if (resultado == DialogResult.Yes)
            {
                foreach (var filme in listaFilmesRemover)
                {
                    service.Remover(filme.Id);
                }
                
                MessageBox.Show(mensagemDeFilmesRemovidos);
                IniciarListaDeFimes();
                dataGridView1.DataSource = ServicoFilmeData.ConverteFilmeParaData(listaDeFilmes);
            }
        }
    }

    private void aoClicarBotaoEditar(object sender, EventArgs e)
    {
        var numeroDeLinhasNecessario = 1;
        var quantidadeDeLinhasSelecionadas = dataGridView1.SelectedRows.Count;

        if (quantidadeDeLinhasSelecionadas != numeroDeLinhasNecessario)
        {
            var mensagemDeErro = quantidadeDeLinhasSelecionadas > numeroDeLinhasNecessario
                ? "Selecione apenas uma linha para ser editada!"
                : "Selecione uma linha para ser editada!";

            MessageBox.Show(mensagemDeErro);
        }
        else
        {
            var filmeSelecionado = dataGridView1.SelectedRows
                .Cast<DataGridViewRow>()
                .Select(linha => (FilmeData)linha.DataBoundItem)
                .FirstOrDefault();

            var editarFilme = new FormCadastroFilme(service, filmeSelecionado);
            editarFilme.ShowDialog();

            IniciarListaDeFimes();
            dataGridView1.DataSource = ServicoFilmeData.ConverteFilmeParaData(listaDeFilmes);
        }
    }
}