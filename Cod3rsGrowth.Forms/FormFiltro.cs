using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Servicos.Servicos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Cod3rsGrowth.Forms
{
    public partial class FormFiltro : Form
    {
        private FormListaFilme form1;
        protected FilmeServicos service;
        public FormFiltro(FormListaFilme form1)
        {
            InitializeComponent();
            comboBoxGenero.Items.Add("Nenhum");
            comboBoxGenero.Items.Add(GeneroEnum.Terror);
            comboBoxGenero.Items.Add(GeneroEnum.Romance);
            comboBoxGenero.Items.Add(GeneroEnum.Acao);
            comboBoxGenero.Items.Add(GeneroEnum.Ficcao);
            comboBoxGenero.Items.Add(GeneroEnum.Aventura);
            comboBoxGenero.Items.Add(GeneroEnum.Comedia);
            comboBoxGenero.Items.Add(GeneroEnum.Drama);
            comboBoxGenero.Items.Add(GeneroEnum.Fantasia);

            comboBoxDisponivel.Items.Add("Nenhum");
            comboBoxDisponivel.Items.Add("Disponível");
            comboBoxDisponivel.Items.Add("Não disponível");

            comboBoxClassificacao.Items.Add("Nenhum");
            comboBoxClassificacao.Items.Add(ClassificacaoIndicativa.livre);
            comboBoxClassificacao.Items.Add(ClassificacaoIndicativa.dez);
            comboBoxClassificacao.Items.Add(ClassificacaoIndicativa.doze);
            comboBoxClassificacao.Items.Add(ClassificacaoIndicativa.quatorze);
            comboBoxClassificacao.Items.Add(ClassificacaoIndicativa.dezesseis);
            comboBoxClassificacao.Items.Add(ClassificacaoIndicativa.dezoito);

            comboBoxEmCartaz.Items.Add("Nenhum");
            comboBoxEmCartaz.Items.Add("Sim");
            comboBoxEmCartaz.Items.Add("Não");
            this.form1 = form1;
            service = form1.service;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

        private void botaoFiltrar_Click(object sender, EventArgs e)
        {
            DataGridView dataGridView1 = form1.GetDataGridView();
            FiltroFilme filtro = new();
            if(comboBoxGenero.SelectedItem.ToString() == "Nunhum")
            {
                filtro.FiltroGenero = null;
            }
            else
            {
                filtro.FiltroGenero = (GeneroEnum)comboBoxGenero.SelectedItem;
            }

            if(comboBoxDisponivel.SelectedItem != null)
            {
                switch (comboBoxDisponivel.SelectedItem.ToString())
                {
                    case "Nenhum":
                        filtro.FiltroDisponivelNoPlano = null;
                        break;
                    case "Disponivel":
                        filtro.FiltroDisponivelNoPlano = true;
                        break;
                    case "Não disponível":
                        filtro.FiltroDisponivelNoPlano = false;
                        break;
                    default:
                        filtro.FiltroDisponivelNoPlano = null;
                        break;
                }
            }

            if (comboBoxClassificacao.SelectedItem != null) 
            {
                if(comboBoxClassificacao.SelectedItem.ToString() == "Nenhum") 
                {
                    filtro.FiltroClassificacao = null;
                }
                else
                {
                    filtro.FiltroClassificacao = (ClassificacaoIndicativa)comboBoxClassificacao.SelectedItem;
                }
            }

            if(comboBoxEmCartaz.SelectedItem != null)
            {
                switch (comboBoxEmCartaz.SelectedItem.ToString())
                {
                    case "Nenhum":
                        filtro.FiltroEmCartaz = null;
                        break;
                    case "Sim":
                        filtro.FiltroEmCartaz = true;
                        break;
                    case "Não":
                        filtro.FiltroEmCartaz = false;
                        break;
                    default:
                        filtro.FiltroEmCartaz = null;
                        break;
                }
            }

            dataGridView1.DataSource = service.ObterTodos(filtro);
        }
    }
}
