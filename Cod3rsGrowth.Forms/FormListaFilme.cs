using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Infra.Repositorios;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth_Domínio.Extensoes;
using Microsoft.IdentityModel.Tokens;

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
    public FormListaFilme(FilmeServicos _service, Usuario _usuario, UsuarioServicos _servicoUsuario, UsuarioRepositorio _repositorio)
    {
        service = _service;
        usuario = _usuario;
        servicoUsuario = _servicoUsuario;
        repositorio = _repositorio;

        InitializeComponent();
        IniciarListaDeFimes();
        dataGridView1.DataSource = ServicoFilmeData.ConverteFilmeParaData(listaDeFilmes);

        GeneroComboBox.Items.Add("Todos");
        GeneroComboBox.Items.Add(ExtensaoDosEnuns.ObterDescricao(GeneroEnum.Terror));
        GeneroComboBox.Items.Add(ExtensaoDosEnuns.ObterDescricao(GeneroEnum.Romance));
        GeneroComboBox.Items.Add(ExtensaoDosEnuns.ObterDescricao(GeneroEnum.Acao));
        GeneroComboBox.Items.Add(ExtensaoDosEnuns.ObterDescricao(GeneroEnum.Ficcao));
        GeneroComboBox.Items.Add(ExtensaoDosEnuns.ObterDescricao(GeneroEnum.Aventura));
        GeneroComboBox.Items.Add(ExtensaoDosEnuns.ObterDescricao(GeneroEnum.Comedia));
        GeneroComboBox.Items.Add(ExtensaoDosEnuns.ObterDescricao(GeneroEnum.Drama));
        GeneroComboBox.Items.Add(ExtensaoDosEnuns.ObterDescricao(GeneroEnum.Fantasia));
        GeneroComboBox.SelectedItem = "Todos";

        toolStripComboBox1.Items.Add("Nenhum");
        toolStripComboBox1.Items.Add("Livre");
        toolStripComboBox1.Items.Add("10+");
        toolStripComboBox1.Items.Add("12+");
        toolStripComboBox1.Items.Add("14+");
        toolStripComboBox1.Items.Add("16+");
        toolStripComboBox1.Items.Add("18+");
        toolStripComboBox1.SelectedItem = "Nenhum";

        toolStripComboBox2.Items.Add("Nenhum");
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
        GeneroComboBox.SelectedItem = "Todos";
        toolStripComboBox1.SelectedItem = "Nenhum";
        toolStripComboBox2.SelectedItem = "Nenhum";
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
        bool filtroDisponivel = false;
        bool filtroDisponivelTodos = false;

        if (GeneroComboBox.SelectedItem.ToString() != "Todos")
        {
            GeneroEnum genero = ExtensaoDosEnuns.ObterGeneroEnum(GeneroComboBox.SelectedItem.ToString());
            filtro.FiltroGenero = genero;
        }
        else
        {
            filtro.FiltroGenero = null;
        }

        if (toolStripComboBox1.SelectedItem != null)
        {
            switch (toolStripComboBox1.SelectedItem.ToString())
            {
                case "Livre":
                    filtro.FiltroClassificacao = ClassificacaoIndicativa.livre;
                    break;
                case "10+":
                    filtro.FiltroClassificacao = ClassificacaoIndicativa.dez;
                    break;
                case "12+":
                    filtro.FiltroClassificacao = ClassificacaoIndicativa.doze;
                    break;
                case "14+":
                    filtro.FiltroClassificacao = ClassificacaoIndicativa.quatorze;
                    break;
                case "16+":
                    filtro.FiltroClassificacao = ClassificacaoIndicativa.dezesseis;
                    break;
                case "18+":
                    filtro.FiltroClassificacao = ClassificacaoIndicativa.dezoito;
                    break;
                case "Nenhum":
                    filtro.FiltroClassificacao = null;
                    break;
            }
        }

        if (toolStripComboBox2.SelectedItem != null)
        {
            switch (toolStripComboBox2.SelectedItem.ToString())
            {
                case "Nenhum":
                    filtroDisponivelTodos = true;
                    break;
                case "Sim":
                    filtroDisponivel = true;
                    break;
                case "Não":
                    filtroDisponivel = false;
                    break;
            }
        }

        if (toolStripTextBox1.Text.IsNullOrEmpty() != true)
        {
            try
            {
                var notaMinima = int.Parse(toolStripTextBox1.Text);
                filtro.FiltroNotaMinima = notaMinima;
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

        labelFiltroGenero.Text = "Gênero: " + GeneroComboBox.SelectedItem.ToString();
        labelFiltroClassificacao.Text = "Classificação: " + toolStripComboBox1.SelectedItem.ToString();
        labelFiltroDisponivel.Text = "Disponível: " + toolStripComboBox2.SelectedItem.ToString();
        labelFiltroNota.Text = "Nota Mínima: " + toolStripTextBox1.Text;
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

    private void FormListaFilme_Load(object sender, EventArgs e)
    {
    }
}