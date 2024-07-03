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

namespace Cod3rsGrowth.Forms
{
    public partial class FormAutenticacao : Form
    {
        private UsuarioServicos service;
        private FilmeServicos filmeService;
        public FormAutenticacao(UsuarioServicos _service, FilmeServicos _filmeService)
        {
            InitializeComponent();
            service = _service;
            filmeService = _filmeService;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Autenticar();
        }

        private void Autenticar()
        {
            var usuarioDigitado = textBox1.Text;
            var senhaDigitada = textBox2.Text;
            try 
            {
                var usuarioSelecionado = service.ObterTodos(null).FirstOrDefault(u => u.NickName == usuarioDigitado) ?? throw new Exception("Usuário não encontrado!");

                if (senhaDigitada == usuarioSelecionado.Senha)
                {
                    Hide();
                    new FormListaFilme(filmeService, usuarioSelecionado).Show();
                }
                else
                {
                    MessageBox.Show("Senha Incorreta!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
