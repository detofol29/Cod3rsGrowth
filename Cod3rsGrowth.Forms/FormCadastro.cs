using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Infra.Repositorios;
using Cod3rsGrowth.Servicos.Servicos;
using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cod3rsGrowth.Forms
{
    public partial class FormCadastro : Form
    {
        private UsuarioServicos service;
        private FilmeServicos filmeService;
        private UsuarioRepositorio repositorio;
        private Thread threadFormsAutenticacao;

        private const char caracterSenha = '*';

        private const string informacaoPlanos = "******************** PLANOS DA PLATAFORMA ********************\n" +
                "\n --> PLANO FREE: Neste plano só estarão disponíveis os filmes selecionados semanalmente pela equipe da plataforma.\n" +
                "\n --> PLANO KIDS: Neste plano está disponível todos os filmes contendo a classificação indicativa 'Livre'.\n" +
                "\n --> PLANO NERD: Neste plano está disponível todos os filmes de gênero Ficção e Fantasia.\n" +
                "\n --> PLANO PREMIUM: Neste plano estão disponíveis todos os filmes da plataforma!";

        private const string informacaoSenha = "O campo 'senha' deve ter no mínimo 6 digitos!\n" +
                "\nO campo 'senha' deve conter pelo menos uma letra maiúscula!\n" +
                "\nO campo 'senha' deve conter pelo menos uma letra minuscula!\n" +
                "\nO campo 'senha' deve conter pelo menos um número!\n";


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
                var nome = campoNome.Text;
                var nick = campoNickName.Text;
                var senha = campoSenha.Text;
                var confirmaSenha = campoConfirmaSenha.Text;
                var plano = caixaSelecionarPlano.SelectedItem;

                if (senha != confirmaSenha)
                {
                    var mensagemCampoConfirmarSenhaInvalido = "As senhas não são iguais!";
                    throw new Exception(mensagemCampoConfirmarSenhaInvalido);
                }

                var usuarioCadastrar = new Usuario() 
                {
                    Nome = nome,
                    NickName = nick,
                    Senha = senha,
                    Plano = (PlanoEnum)plano
                };
                var resultado = service.CriarUsuario(usuarioCadastrar);

                if (resultado.IsValid)
                {
                    var mensagemDeExito = "Usuário criado com sucesso!";
                    MessageBox.Show(mensagemDeExito);
                    this.Close();
                    threadFormsAutenticacao = new Thread(AbrirJanelaLogin);
                    threadFormsAutenticacao.SetApartmentState(ApartmentState.STA);
                    threadFormsAutenticacao.Start();
                }
                else
                {
                    var listaDeErros = new StringBuilder();
                    foreach (var excecao in resultado.Errors)
                    {
                        listaDeErros.AppendLine(excecao.ErrorMessage);
                    }
                    
                    if (campoConfirmaSenha.Text.IsNullOrEmpty())
                    {
                        var mensagemCampoConfirmarSenhaVazio = "O campo 'Confirmar Senha' não pode estar vazio!";
                        listaDeErros.AppendLine(mensagemCampoConfirmarSenhaVazio);
                    }

                    throw new Exception(listaDeErros.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AoCarregarFormCadastro(object sender, EventArgs e)
        {
            caixaSelecionarPlano.Items.Add(PlanoEnum.Premium);
            caixaSelecionarPlano.Items.Add(PlanoEnum.Nerd);
            caixaSelecionarPlano.Items.Add(PlanoEnum.Free);
            caixaSelecionarPlano.Items.Add(PlanoEnum.Kids);
            caixaSelecionarPlano.SelectedItem = PlanoEnum.Free;
        }

        private string AoClicarBotaoVerificarNickName()
        {
            var nickNameDigitado = campoNickName.Text;
            return service.ValidarNickName(nickNameDigitado);
        }

        private void AbrirJanelaLogin(object obj)
        {
            Application.Run(new FormAutenticacao(service, filmeService, repositorio));
        }

        private void AoClicarBotaoInfoPlano(object sender, EventArgs e)
        {
            MessageBox.Show(informacaoPlanos);
        }

        private void AoClicarBotaoVerificarSenha(object sender, EventArgs e)
        {
            MessageBox.Show(informacaoSenha);
        }

        private void AoClicarBotaoLogar(object sender, EventArgs e)
        {
            this.Close();
            threadFormsAutenticacao = new Thread(AbrirJanelaLogin);
            threadFormsAutenticacao.SetApartmentState(ApartmentState.STA);
            threadFormsAutenticacao.Start();
        }

        public void AoPerderFocoDoNickName(object sender, EventArgs e)
        {
            var mensagemIndisponivel = "Indisponível*";
            var mensagemCampoObrigatorio = "Campo obrigatório*";

            var resultado = AoClicarBotaoVerificarNickName();
            switch (resultado)
            {
                case "Indisponível*":
                    campoNickName.ForeColor = Color.Red;
                    labelDisponivel.Text = mensagemIndisponivel;
                    break;

                case "O campo 'NickName' não pode estar vazio!":
                    campoNickName.ForeColor = Color.Red;
                    labelDisponivel.Text = mensagemCampoObrigatorio;
                    break;

                default:
                    campoNickName.ForeColor = Color.Black;
                    labelDisponivel.Text = null;
                    break;
            }
        }

        private void AoClicarAlteraVisibilidadeDaSenha(object sender, EventArgs e)
        {
            campoSenha.PasswordChar = campoSenha.PasswordChar == caracterSenha 
                ? default 
                : caracterSenha;
        }

        private void AoClicarAlteraVisibilidadeDeSenhaConfirmar(object sender, EventArgs e)
        {
            campoConfirmaSenha.PasswordChar = campoConfirmaSenha.PasswordChar == caracterSenha
                ? default 
                : caracterSenha;
        }
    }
}