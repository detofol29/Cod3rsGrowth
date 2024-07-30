using Cod3rsGrowth.Dominio.Extensoes;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Domuinio.Enumeradores;
using Cod3rsGrowth.Forms.Properties;
using Cod3rsGrowth.Servicos.Servicos;
using System.Data;
using System.Reflection;
using System.Text;

namespace Cod3rsGrowth.Forms;

public partial class FormCadastroFilme : Form
{
    private FilmeServicos service;
    private FilmeData? filmeBase;
    public FormCadastroFilme(FilmeServicos _service, FilmeData? _filme)
    {
        filmeBase = _filme;
        service = _service;
        InitializeComponent();
    }

    private void AoCarregarFormCadastroFilme(object sender, EventArgs e)
    {
        foreach (var genero in Enum.GetValues(typeof(GeneroEnum)))
        {
            generoComboBox.Items.Add(ExtensaoDosEnuns.ObterDescricao((Enum)genero));
        }

        foreach (var classificacao in Enum.GetValues(typeof(ClassificacaoIndicativa)))
        {
            classificacaoComboBox.Items.Add(ExtensaoDosEnuns.ObterDescricao((Enum)classificacao));
        }

        generoComboBox.SelectedItem = ExtensaoDosEnuns.ObterDescricao((Enum)GeneroEnum.Acao);
        classificacaoComboBox.SelectedItem = ExtensaoDosEnuns.ObterDescricao((Enum)ClassificacaoIndicativa.livre);

        if(filmeBase is not null)
        {
            campoTitulo.Text = filmeBase.Titulo;
            campoDataDeLancamento.Value = filmeBase.DataDeLancamento;
            campoDiretor.Text = filmeBase.Diretor;
            CampoNota.Value = filmeBase.Nota;
            classificacaoComboBox.SelectedItem = filmeBase.Classificacao;
            generoComboBox.SelectedItem = filmeBase.Genero;
            campoDuracao.Value = filmeBase.Duracao;

            Text = "Editar Filme";
            botaoCadastrar.Text = "Editar";
            pictureBox1.Image = Resources.imagemEditarBranco;
            pictureBox1.Location = new Point(44, 12);
            pictureBox1.Size = new Size(250, 49);
        }
    }

    private void AoClicarBotaoCadastrar(object sender, EventArgs e)
    {
        try
        {
            if(filmeBase is not null)
            {
                var filmeEditado = new FilmeData()
                {
                    Id = filmeBase.Id,
                    Titulo = campoTitulo.Text,
                    Diretor = campoDiretor.Text,
                    DataDeLancamento = campoDataDeLancamento.Value,
                    Nota = CampoNota.Value,
                    Classificacao = (string)classificacaoComboBox.SelectedItem,
                    Genero = (string)generoComboBox.SelectedItem,
                    Duracao = (int)campoDuracao.Value
                };

                var filme = ServicoFilmeData.ConverterParaFilme(filmeEditado);
                service.Editar(filme);

                MessageBox.Show("Filme editado com sucesso!");
                Close();
            }
            else
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
                var nota = CampoNota.Value;
                var duracao = campoDuracao.Value;

                var filmeCadastrar = new Filme()
                {
                    Titulo = titulo,
                    Diretor = diretor,
                    Classificacao = classificacaoEnum,
                    Genero = generoEnum,
                    DataDeLancamento = dataDeLancamento,
                    Nota = nota,
                    Duracao = (int)duracao,
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
                    var listaDeErros = new StringBuilder();
                    foreach (var excecao in resultado.Errors)
                    {
                        listaDeErros.AppendLine(excecao.ErrorMessage);
                    }

                    throw new Exception(listaDeErros.ToString());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void AoClicarBotaoCancelar(object sender, EventArgs e)
    {
        DialogResult resultado = filmeBase is null
            ? MessageBox.Show("Deseja cancelar o cadastro?", "Cancelar", MessageBoxButtons.YesNo) 
            : MessageBox.Show("Deseja cancelar a edição?", "Cancelar", MessageBoxButtons.YesNo);

        if (resultado == DialogResult.Yes)
        {
            Close();
        }
    }
}