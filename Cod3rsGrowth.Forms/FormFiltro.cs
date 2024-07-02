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
    public partial class FormFiltro : FormListaFilme
    {
        public FormFiltro(FilmeServicos _service) : base()
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
            comboBoxDisponivel.Items.Add(" Não disponível");

            comboBoxClassificacao.Items.Add("Nenhum");
            comboBoxClassificacao.Items.Add("Livre");
            comboBoxClassificacao.Items.Add("10+");
            comboBoxClassificacao.Items.Add("12+");
            comboBoxClassificacao.Items.Add("14+");
            comboBoxClassificacao.Items.Add("16+");
            comboBoxClassificacao.Items.Add("18+");

            comboBoxEmCartaz.Items.Add("Nenhum");
            comboBoxEmCartaz.Items.Add("Sim");
            comboBoxEmCartaz.Items.Add("Não");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void botaoFiltrar_Click(object sender, EventArgs e)
        {
            
        }
    }
}
