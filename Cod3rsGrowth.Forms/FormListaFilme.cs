using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Modelos;
using System.ComponentModel;
using System.IO;

namespace Cod3rsGrowth.Forms
{
    public partial class FormListaFilme : Form
    {
        public FormListaFilme()
        {
            InitializeComponent();
            IniciarListaDeFimes();
            dataGridView1.DataSource = listaDeFilmes;
            comboBox1.Items.Add(GeneroEnum.Terror);
            comboBox1.Items.Add(GeneroEnum.Romance);
            comboBox1.Items.Add(GeneroEnum.Acao);
            comboBox1.Items.Add(GeneroEnum.Ficcao);
            comboBox1.Items.Add(GeneroEnum.Aventura);
            comboBox1.Items.Add(GeneroEnum.Comedia);
            comboBox1.Items.Add(GeneroEnum.Drama);
            comboBox1.Items.Add(GeneroEnum.Fantasia);
        }
        BindingList<Filme> listaDeFilmes;

        public void IniciarListaDeFimes()
        {
            listaDeFilmes = new BindingList<Filme>();

            listaDeFilmes.AllowNew = true;
            listaDeFilmes.AllowRemove = false;
            listaDeFilmes.RaiseListChangedEvents = true;
            listaDeFilmes.AllowEdit = false;
            listaDeFilmes.Add(new Filme { Titulo = "De Volta Para o Futuro", Genero = GeneroEnum.Ficcao, Classificacao = ClassificacaoIndicativa.livre, Atores = null, DataDeLancamento = new DateTime(1985, 12, 25), DisponivelNoPlano = true, Diretor = "Robert Zemeckis", Duracao = 116, EmCartaz = false, Nota = 10 });
            listaDeFilmes.Add(new Filme { Titulo = "Titanic", Genero = GeneroEnum.Romance, Classificacao = ClassificacaoIndicativa.doze, Atores = null, DataDeLancamento = new DateTime(1998, 01, 16), DisponivelNoPlano = false, Diretor = "James Cameron", Duracao = 194, EmCartaz = false, Nota = 5 });
            listaDeFilmes.Add(new Filme { Titulo = "Star Wars IV", Genero = GeneroEnum.Aventura, Classificacao = ClassificacaoIndicativa.livre, Atores = null, DataDeLancamento = new DateTime(1977, 11, 18), DisponivelNoPlano = true, Diretor = "George Lucas", Duracao = 121, EmCartaz = false, Nota = 10 });
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GeneroEnum genero = (GeneroEnum)comboBox1.SelectedItem;
            FiltroFilme filtro = new() { FiltroGenero = genero };
            //Chamar o obter Todos que se conecta com o banco;
            //adicionar a lista
            var listaFiltrada = new List<Filme>();
            dataGridView1.DataSource = listaFiltrada;
        }
    }
}