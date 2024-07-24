using Cod3rsGrowth.Dominio.Extensoes;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Domuinio.Enumeradores;
using Cod3rsGrowth.Servicos.Servicos;
using System.Data;

namespace Cod3rsGrowth.Forms;

public partial class FormCadastroFilme : Form
{
    private FilmeServicos service;
    public FormCadastroFilme(FilmeServicos _service)
    {
        service = _service;
        InitializeComponent();
    }

    private void AoCarregarFormCadastroFilme(object sender, EventArgs e)
    {
        foreach (var genero in Enum.GetValues(typeof(GeneroEnum)))
        {
            generoComboBox.Items.Add(ExtensaoDosEnuns.ObterDescricao((Enum)genero));
        }
        generoComboBox.SelectedItem = ExtensaoDosEnuns.ObterDescricao((Enum)GeneroEnum.Acao);

        foreach (var classificacao in Enum.GetValues(typeof(ClassificacaoIndicativa)))
        {
            classificacaoComboBox.Items.Add(ExtensaoDosEnuns.ObterDescricao((Enum)classificacao));
        }
        classificacaoComboBox.SelectedItem = ExtensaoDosEnuns.ObterDescricao((Enum)ClassificacaoIndicativa.livre);
    }

    private void AoClicarBotaoCadastrar(object sender, EventArgs e)
    {
        try
        {
            var enumeradores = new TodosEnumeradores();
            var classificacoes = enumeradores.ObterTodos<ClassificacaoIndicativa>();
            var generos = enumeradores.ObterTodos<GeneroEnum>();
            var classificacao = classificacoes
                .Where(g => g.Descricao == classificacaoComboBox.SelectedItem.ToString())
                .FirstOrDefault();
            var genero = generos
                .Where(g => g.Descricao == generoComboBox.SelectedItem.ToString())
                .FirstOrDefault();

            var titulo = campoTitulo.Text;
            var diretor = campoDiretor.Text;
            var classificacaoEnum = ExtensaoDosEnuns.ConverterParaClassificacaoEnum(classificacao!);
            var generoEnum = ExtensaoDosEnuns.ConverterParaGeneroEnum(genero!);
            var dataDeLancamento = campoDataDeLancamento.Value;
            var nota = int.Parse(CampoNota.Value.ToString());
            var duracao = int.Parse(campoDuracao.Value.ToString());

            var filmeCadastrar = new Filme()
            {
                Titulo = titulo,
                Diretor = diretor,
                Classificacao = classificacaoEnum,
                Genero = generoEnum,
                DataDeLancamento = dataDeLancamento,
                Nota = nota,
                Duracao = duracao,
                EmCartaz = false
            };

            var resultado = service.CriarFilme(filmeCadastrar);
            if (resultado.IsValid)
            {
                MessageBox.Show("Filme cadastrado com sucesso!");
                Close();
            }
            else
            {
                throw new Exception(resultado.Errors.First().ErrorMessage);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void AoClicarBotaoCancelar(object sender, EventArgs e)
    {
        Close();
    }
}