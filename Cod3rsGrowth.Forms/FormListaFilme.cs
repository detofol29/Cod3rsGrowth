using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Infra.Repositorios;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Dominio.Extensoes;
using Microsoft.IdentityModel.Tokens;
using Cod3rsGrowth.Domuinio.Enumeradores;

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
    bool filtroDisponivel = false;
    bool filtroDisponivelTodos = false;
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

        toolStripComboBox2.Items.Add("Todos");
        toolStripComboBox2.Items.Add("Sim");
        toolStripComboBox2.Items.Add("Não");
        toolStripComboBox2.SelectedItem = "Sim";
        AoClicarBotaoFiltrar(null, null);
        
        labelUsuario.Text = "Usuário: " + usuario.Nome;
    }

    public void IniciarListaDeFimes()
    {
        var lista = service.ObterTodos(null);
        foreach (var filme in lista)
        {
            listaDeFilmes.Add(servicoUsuario.LicenciarFilmePorUsuario(usuario, filme));
        }
    }

    private void AoClicarBotaoLimparFiltros(object sender, EventArgs e)
    {
        generoComboBox.SelectedItem = "Todos";
        classificacaoComboBox.SelectedItem = "Todos";
        toolStripComboBox2.SelectedItem = "Todos";
        toolStripTextBox1.Clear();
        labelFiltroGenero.Text = "Gênero: Todos";
        labelFiltroClassificacao.Text = "Classificação: Todas";
        labelFiltroDisponivel.Text = "Disponível: Todos";
        labelFiltroNota.Text = "Nota Mínima: Nenhuma";
        dataGridView1.DataSource = ServicoFilmeData.ConverteFilmeParaData(listaDeFilmes);
    }

    private void AoClicarBotaoFiltrar(object? sender, EventArgs? e)
    {
        List<Filme> filmesLicenciados = new();

        AdicionarFiltroGenero();
        AdicionarFiltroClassificacao();
        AdicionarFiltroNotaMinima();
        AdicionarFiltroDisponivel();

        foreach (var filme in service.ObterTodos(filtro))
        {
            filmesLicenciados.Add(servicoUsuario.LicenciarFilmePorUsuario(usuario, filme));
        }

        if (filtroDisponivelTodos == false)
        {
            dataGridView1.DataSource = ServicoFilmeData.ConverteFilmeParaData(filmesLicenciados.Where(f => f.DisponivelNoPlano == filtroDisponivel).Select(f => f).ToList());
        }
        else
        {
            dataGridView1.DataSource = ServicoFilmeData.ConverteFilmeParaData(filmesLicenciados);
        }
        atualizarBarraDeFiltros();
    }

    private void AdicionarFiltroNotaMinima()
    {
        if (toolStripTextBox1.Text.IsNullOrEmpty() != true)
        {
            try
            {
                var nota = int.Parse(toolStripTextBox1.Text);
                filtro.FiltroNotaMinima = nota;
            }
            catch
            {
                MessageBox.Show("Digite um valor numérico!");
            }
        }
        else
        {
            filtro.FiltroNotaMinima = null;
        }
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
            filtro.FiltroGenero =  ExtensaoDosEnuns.ConverterParaGeneroEnum(genero);
        }
        else
        {
            filtro.FiltroGenero = null;
        }
    }

    private void atualizarBarraDeFiltros()
    {
        labelFiltroGenero.Text = "Gênero: " + generoComboBox.SelectedItem.ToString();
        labelFiltroClassificacao.Text = "Classificação: " + classificacaoComboBox.SelectedItem.ToString();
        labelFiltroDisponivel.Text = "Disponível: " + toolStripComboBox2.SelectedItem.ToString();
        labelFiltroNota.Text = "Nota Mínima: " + toolStripTextBox1.Text;
    }

    private void AdicionarFiltroDisponivel()
    {
        if (toolStripComboBox2.SelectedItem == "Todos")
        {
            filtroDisponivelTodos = true;
        }
        else
        {
            switch (toolStripComboBox2.SelectedItem)
            {
                case "Sim":
                    filtroDisponivel = true;
                    break;
                case "Não":
                    filtroDisponivel = false;
                    break;
            }
        }
    }

    private void AoClicarBotaoSair(object sender, EventArgs e)
    {
        DialogResult resultado = MessageBox.Show("Deseja Realmente sair?","Sair", MessageBoxButtons.YesNo);

        if(resultado == DialogResult.Yes)
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
}