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
using Cod3rsGrowth.Dominio.Filtros;
using System.ComponentModel.DataAnnotations;

namespace Cod3rsGrowth.Forms
{
    public partial class FormCadastro : Form
    {
        private UsuarioServicos service;
        public FormCadastro(UsuarioServicos _servicos)
        {
            service = _servicos;
            InitializeComponent();
        }

        private void botaoCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                var nome = campoNome.Text ?? throw new Exception("O campo nome não pode estar vazio!");
                var nick = campoNickName.Text ?? throw new Exception("O campo NickName não pode estar vazio!");
                var senha = campoSenha.Text ?? throw new Exception("O campo senha não pode estar vazio!");
                var confirmaSenha = campoConfirmaSenha.Text ?? throw new Exception("O campo de confirmar senha não pode estar vazio!");
                var plano = caixaSelecionarPlano.SelectedItem;

                if(senha != confirmaSenha)
                {
                    throw new Exception("As senhas não são iguais sua mula");
                }

                var usuarioCadastrar = new Usuario() { Nome = nome, NickName = nick, Senha = senha, Plano = (PlanoEnum)plano };

                var resultado = service.CriarUsuario(usuarioCadastrar);
                if (resultado.IsValid)
                {
                    MessageBox.Show("Usuário criado com sucesso!");
                }
                else
                {
                    MessageBox.Show(resultado.ToString());
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormCadastro_Load(object sender, EventArgs e)
        {
            caixaSelecionarPlano.Items.Add(PlanoEnum.Premium);
            caixaSelecionarPlano.Items.Add(PlanoEnum.Nerd);
            caixaSelecionarPlano.Items.Add(PlanoEnum.Free);
            caixaSelecionarPlano.Items.Add(PlanoEnum.Kids);
            caixaSelecionarPlano.SelectedItem = PlanoEnum.Free;
        }

        private void botaoVerificarNickName_Click(object sender, EventArgs e)
        {
            var nickNameDigitado = campoNickName.Text;
            var usuario = service.ObterTodos(new FiltroUsuario() { FiltroNome = nickNameDigitado})?.FirstOrDefault();

            if (usuario is not null)
            {
                MessageBox.Show("Esse NickName já está em uso!");
                return;
            }
            else
            {
                MessageBox.Show("NickName disponível!");
            }
        }
    }
}
