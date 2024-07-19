﻿using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Infra.Repositorios;
using Cod3rsGrowth.Servicos.Servicos;
using Microsoft.IdentityModel.Tokens;

namespace Cod3rsGrowth.Forms
{
    public partial class FormCadastro : Form
    {
        private UsuarioServicos service;
        private FilmeServicos filmeService;
        private UsuarioRepositorio repositorio;
        private Thread threadFormsAutenticacao;
        public FormCadastro(UsuarioServicos _servicos, FilmeServicos _filmeServicos, UsuarioRepositorio _repositorio)
        {
            filmeService = _filmeServicos;
            repositorio = _repositorio;
            service = _servicos;
            InitializeComponent();
        }

        private void AoClicarBotaoCadastrar(object sender, EventArgs e)
        {
            try
            {
                var nome = campoNome.Text ?? throw new Exception("O campo nome não pode estar vazio!");
                var nick = campoNickName.Text ?? throw new Exception("O campo NickName não pode estar vazio!");
                var senha = campoSenha.Text ?? throw new Exception("O campo senha não pode estar vazio!");
                var confirmaSenha = campoConfirmaSenha.Text ?? throw new Exception("O campo de confirmar senha não pode estar vazio!");
                var plano = caixaSelecionarPlano.SelectedItem;

                if (senha != confirmaSenha)
                {
                    throw new Exception("As senhas não são iguais sua mula");
                }

                var usuarioCadastrar = new Usuario() { Nome = nome, NickName = nick, Senha = senha, Plano = (PlanoEnum)plano };
                var resultado = service.CriarUsuario(usuarioCadastrar);

                if (resultado.IsValid)
                {
                    MessageBox.Show("Usuário criado com sucesso!");
                    this.Close();
                    threadFormsAutenticacao = new Thread(AbrirJanelaLogin);
                    threadFormsAutenticacao.SetApartmentState(ApartmentState.STA);
                    threadFormsAutenticacao.Start();
                }
                else
                {
                    MessageBox.Show(resultado.ToString());
                }

            }
            catch (Exception ex)
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

        private void AoClicarBotaoVerificarNickName(object sender, EventArgs e)
        {
            var nickNameDigitado = campoNickName.Text;
            var usuario = service.ObterTodos(new FiltroUsuario() { FiltroNome = nickNameDigitado })?.FirstOrDefault();

            if (usuario is not null)
            {
                MessageBox.Show("Esse NickName já está em uso!");
                return;
            }
            else
            {
                if (campoNickName.Text.IsNullOrEmpty())
                {
                    MessageBox.Show("NickName vazio!");
                }
                else
                {
                    MessageBox.Show("NickName disponível!");
                }
            }
        }

        private void AbrirJanelaLogin(object obj)
        {
            Application.Run(new FormAutenticacao(service, filmeService, repositorio));
        }

        private void AoClicarBotaoInfoPlano(object sender, EventArgs e)
        {
            MessageBox.Show("******************** PLANOS DA PLATAFORMA ********************\n" +
                "\n --> PLANO FREE: Neste plano só estarão disponíveis os filmes selecionados semanalmente pela equipe da plataforma.\n" +
                "\n --> PLANO KIDS: Neste plano está disponível todos os filmes contendo a classificação indicativa 'Livre'.\n" +
                "\n --> PLANO NERD: Neste plano está disponível todos os filmes de gênero Ficção e Fantasia.\n" +
                "\n --> PLANO PREMIUM: Neste plano estão disponíveis todos os filmes da plataforma!");
        }

        private void AoClicarBotaoVerificarSenha(object sender, EventArgs e)
        {
            MessageBox.Show("O campo 'senha' deve ter no mínimo 6 digitos!\n" +
                "\nO campo 'senha' deve conter pelo menos uma letra maiúscula!\n" +
                "\nO campo 'senha' deve conter pelo menos uma letra minuscula!\n" +
                "\nO campo 'senha' deve conter pelo menos um número!\n");
        }
    }
}