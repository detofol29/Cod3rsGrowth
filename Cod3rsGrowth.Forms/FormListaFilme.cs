using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Infra.Repositorios;
using Cod3rsGrowth.Servicos.Servicos;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.IO;

namespace Cod3rsGrowth.Forms
{
    public partial class FormListaFilme : Form
    {
        FilmeServicos service;
        public FormListaFilme(IServiceProvider _service)
        {
            service = _service.GetService<FilmeServicos>() ?? throw new Exception("Servico nao encontrado!");
            InitializeComponent();
            //IniciarListaDeFimes();
            dataGridView1.DataSource = service.ObterTodos(null);
            comboBox1.Items.Add("Todos");
            comboBox1.Items.Add(GeneroEnum.Terror);
            comboBox1.Items.Add(GeneroEnum.Romance);
            comboBox1.Items.Add(GeneroEnum.Acao);
            comboBox1.Items.Add(GeneroEnum.Ficcao);
            comboBox1.Items.Add(GeneroEnum.Aventura);
            comboBox1.Items.Add(GeneroEnum.Comedia);
            comboBox1.Items.Add(GeneroEnum.Drama);
            comboBox1.Items.Add(GeneroEnum.Fantasia);
        }
        List<Filme> listaDeFilmes;

        public void IniciarListaDeFimes()
        {
            var lista = service.ObterTodos(null);
            foreach(var filme in lista)
            {
                listaDeFilmes.Add(filme);
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem.ToString() == "Todos")
            {
                dataGridView1.DataSource = service.ObterTodos(null);
            }
            else
            {
                GeneroEnum genero = (GeneroEnum)comboBox1.SelectedItem;
                FiltroFilme filtro = new() { FiltroGenero = genero };
                var listaFiltrada = service.ObterTodos(filtro);
                dataGridView1.DataSource = listaFiltrada;
            }
        }
    }
}