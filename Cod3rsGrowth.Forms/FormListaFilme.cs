using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Infra.Repositorios;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Dominio.Extensoes;
using Microsoft.IdentityModel.Tokens;
using Cod3rsGrowth.Domuinio.Enumeradores;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.WebUtilities;

namespace Cod3rsGrowth.Forms;

public partial class FormListaFilme : Form
{
    public FilmeServicos service;
    private Usuario usuario;
    private UsuarioServicos servicoUsuario;
    private Thread threadFormsAutenticacao;
    private UsuarioRepositorio repositorio;
    FiltroFilme filtro = new();
    List<Filme> listaDeFilmes = new();
    bool filtroDisponivel;
    bool filtroDisponivelTodos;
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
        generoComboBox.Items.Add("Todos");
        generoComboBox.SelectedItem = "Todos";

        foreach (var classificacao in Enum.GetValues(typeof(ClassificacaoIndicativa)))
        {
            classificacaoComboBox.Items.Add(ExtensaoDosEnuns.ObterDescricao((Enum)classificacao));
        }
        classificacaoComboBox.Items.Add("Todos");
        classificacaoComboBox.SelectedItem = "Todos";

        foreach (var disponivel in Enum.GetValues(typeof(EnumDisponivel)))
        {
            DisponivelComboBox.Items.Add(ExtensaoDosEnuns.ObterDescricao((Enum)disponivel));
        }
        DisponivelComboBox.SelectedItem = ExtensaoDosEnuns.ObterDescricao(EnumDisponivel.Sim);

        AoClicarBotaoFiltrar(null, null);
        labelUsuario.Text = "Usuário: " + usuario.Nome;
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
        generoComboBox.SelectedItem = "Todos";
        classificacaoComboBox.SelectedItem = "Todos";
        DisponivelComboBox.SelectedItem = "Todos";
        toolStripTextBox1.Clear();
        labelFiltroGenero.Text = "Gênero: Todos";
        labelFiltroClassificacao.Text = "Classificação: Todas";
        labelFiltroDisponivel.Text = "Disponível: Todos";
        labelFiltroNota.Text = "Nota Mínima: Nenhuma";
        filtroDisponivelTodos = true;
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
        if (classificacaoComboBox.SelectedItem != "Todos")
        {
            var enumeradores = new TodosEnumeradores();
            var classificacoes = enumeradores.ObterTodos<ClassificacaoIndicativa>();
            var classificacao = classificacoes.Where(g => g.Descricao == classificacaoComboBox.SelectedItem.ToString()).FirstOrDefault();
            filtro.FiltroClassificacao = ExtensaoDosEnuns.ConverterParaClassificacaoEnum(classificacao);
        }
        else
        {
            filtro.FiltroClassificacao = null;
        }
    }

    private void AdicionarFiltroGenero()
    {
        if (generoComboBox.SelectedItem != "Todos")
        {
            var enumeradores = new TodosEnumeradores();
            var generos = enumeradores.ObterTodos<GeneroEnum>();
            var genero = generos.Where(g => g.Descricao == generoComboBox.SelectedItem.ToString()).FirstOrDefault();
            filtro.FiltroGenero = ExtensaoDosEnuns.ConverterParaGeneroEnum(genero);
        }
        else
        {
            filtro.FiltroGenero = null;
        }
    }

    private void AtualizarBarraDeFiltros()
    {
        labelFiltroGenero.Text = "Gênero: " + generoComboBox.SelectedItem.ToString();
        labelFiltroClassificacao.Text = "Classificação: " + classificacaoComboBox.SelectedItem.ToString();
        labelFiltroDisponivel.Text = "Disponível: " + DisponivelComboBox.SelectedItem.ToString();
        labelFiltroNota.Text = toolStripTextBox1.Text.IsNullOrEmpty() ? "Nota Mínima: Nenhuma" : "Nota Mínima: " + toolStripTextBox1.Text;
    }

    private void AdicionarFiltroDisponivel()
    {
        if (DisponivelComboBox.SelectedItem.ToString() == "Todos")
        {
            filtroDisponivelTodos = true;
        }
        else
        {
            switch (DisponivelComboBox.SelectedItem)
            {
                case "Sim":
                    filtroDisponivel = true;
                    filtroDisponivelTodos = false;
                    break;
                case "Não":
                    filtroDisponivel = false;
                    filtroDisponivelTodos = false;
                    break;
            }
        }
    }

    private void AoClicarBotaoSair(object sender, EventArgs e)
    {
        DialogResult resultado = MessageBox.Show("Deseja Realmente sair?", "Sair", MessageBoxButtons.YesNo);

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
        var cadastroFilme = new FormCadastroFilme(service);
        cadastroFilme.ShowDialog();
        IniciarListaDeFimes();
        dataGridView1.DataSource = ServicoFilmeData.ConverteFilmeParaData(listaDeFilmes);
    }

    private void AoClicarBotaoRemover(object sender, EventArgs e)
    {
        string? filmesRemover = null;
        var quantidadeDeLinhasSelecionadas = dataGridView1.SelectedRows.Count;
        if(quantidadeDeLinhasSelecionadas == default)
        {
            MessageBox.Show("Selecione pelo menos uma linha para ser removida!");
        }
        else
        {
            var listaFilmesRemover = new List<FilmeData>();
            for (int i = default; i < quantidadeDeLinhasSelecionadas; i++)
            {
                var filme = (FilmeData)dataGridView1.SelectedRows[i].DataBoundItem;
                listaFilmesRemover.Add(filme);
                filmesRemover += filme.Titulo + "\n";
            }

            DialogResult resultado = MessageBox.Show($"Deseja Realmente remover o(os) filme(s) a seguir da lista de filmes?\n\n {filmesRemover}", "Remover", MessageBoxButtons.YesNo);

            if(resultado == DialogResult.Yes)
            {
                foreach (var filme in listaFilmesRemover)
                {
                    service.Remover(filme.Id);
                }
                MessageBox.Show("Filmes Removidos com sucesso!");
                IniciarListaDeFimes();
                dataGridView1.DataSource = ServicoFilmeData.ConverteFilmeParaData(listaDeFilmes);
            }
        }  
    }
}