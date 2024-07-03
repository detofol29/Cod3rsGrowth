using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Infra;
using Cod3rsGrowth.Infra.Repositorios;
using Cod3rsGrowth.Servicos.Servicos;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace Cod3rsGrowth.Forms
{
    public partial class FormListaFilme : Form
    {
        public FilmeServicos service;
        private Usuario usuario;
        FiltroFilme filtro = new();
        public FormListaFilme(FilmeServicos _service, Usuario _usuario)
        {
            service = _service;
            usuario = _usuario;
            InitializeComponent();
            dataGridView1.DataSource = service.ObterTodos(null);
            GeneroComboBox.Items.Add("Todos");
            GeneroComboBox.Items.Add(GeneroEnum.Terror);
            GeneroComboBox.Items.Add(GeneroEnum.Romance);
            GeneroComboBox.Items.Add(GeneroEnum.Acao);
            GeneroComboBox.Items.Add(GeneroEnum.Ficcao);
            GeneroComboBox.Items.Add(GeneroEnum.Aventura);
            GeneroComboBox.Items.Add(GeneroEnum.Comedia);
            GeneroComboBox.Items.Add(GeneroEnum.Drama);
            GeneroComboBox.Items.Add(GeneroEnum.Fantasia);
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
            toolStripComboBox2.SelectedItem = "Nenhum";
        }

        List<Filme>? listaDeFilmes;

        public void IniciarListaDeFimes()
        {
            var lista = service.ObterTodos(null);
            foreach (var filme in lista)
            {
                listaDeFilmes.Add(filme);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (GeneroComboBox.SelectedItem.ToString() != "Todos")
            {
                GeneroEnum genero = (GeneroEnum)GeneroComboBox.SelectedItem;
                filtro.FiltroGenero = genero;
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
                        filtro.FiltroDisponivelNoPlano = null;
                        break;
                    case "Sim":
                        filtro.FiltroDisponivelNoPlano = true;
                        break;
                    case "Não":
                        filtro.FiltroDisponivelNoPlano = false;
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
                catch (Exception ex)
                {
                    MessageBox.Show("Digite um valor numérico!");
                }
            }
            dataGridView1.DataSource = service.ObterTodos(filtro);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            GeneroComboBox.SelectedItem = "Todos";
            toolStripComboBox1.SelectedItem = "Nenhum";
            toolStripComboBox2.SelectedItem = "Nenhum";
            toolStripTextBox1.Clear();
            dataGridView1.DataSource = service.ObterTodos(null);
        }
    }
}