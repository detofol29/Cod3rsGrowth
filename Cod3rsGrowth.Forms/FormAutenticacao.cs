using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Infra.Repositorios;
using Cod3rsGrowth.Servicos.Servicos;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Cod3rsGrowth.Forms
{
    public partial class FormAutenticacao : Form
    {
        private UsuarioServicos service;
        private UsuarioRepositorio repositorio;
        private FilmeServicos filmeService;
        private Usuario usuario;
        private Thread threadFormsUsuario;
        private Thread threadFormsCadastro;
        private const char caracterSenha = '*';
        public FormAutenticacao(UsuarioServicos _service, FilmeServicos _filmeService, UsuarioRepositorio _repositorio)
        {
            InitializeComponent();
            service = _service;
            filmeService = _filmeService;
            repositorio = _repositorio;
        }

        private void AoClicarBotaoEntrar(object sender, EventArgs e)
        {
            try
            {
                var validador = ValidarEntradaLogin();
                if (!validador.IsNullOrEmpty())
                {
                    throw new Exception(validador);
                }
                var nickname = campoUsuario.Text;
                var senha = CampoSenha.Text;

                var usuarioInserido = new Usuario()
                {
                    NickName = nickname,
                    Senha = senha
                };

                var usuarioRetorno = service.AutenticarUsuario(usuarioInserido);
                if (usuarioRetorno is null)
                {
                    var mensagemSenhaInvalida = "Senha Inválida!";
                    MessageBox.Show(mensagemSenhaInvalida);
                }
                else
                {
                    usuario = usuarioRetorno;
                    this.Close();
                    threadFormsUsuario = new Thread(AbrirJanelaListaFilmes);
                    threadFormsUsuario.SetApartmentState(ApartmentState.STA);
                    threadFormsUsuario.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AbrirJanelaListaFilmes(object obj)
        {
            Application.Run(new FormListaFilme(filmeService, usuario, service, repositorio));
        }

        private void AbrirJanelaCadastro(object obj)
        {
            Application.Run(new FormCadastro(service, filmeService, repositorio));
        }

        private void AoClicarBotaoCadastrar(object sender, EventArgs e)
        {
            this.Close();
            threadFormsCadastro = new Thread(AbrirJanelaCadastro);
            threadFormsCadastro.SetApartmentState(ApartmentState.STA);
            threadFormsCadastro.Start();
        }

        private void AoClicarAlteraVisibilidadeDaSenha(object sender, EventArgs e)
        {
            CampoSenha.PasswordChar = CampoSenha.PasswordChar == caracterSenha 
                ? default 
                : caracterSenha;
        }

        private string ValidarEntradaLogin()
        {
            var mensagemDeErro = new StringBuilder();
            if (campoUsuario.Text.IsNullOrEmpty())
            {
                mensagemDeErro.AppendLine("O campo 'Usuário' não pode estar vazio!");
            }

            if (CampoSenha.Text.IsNullOrEmpty())
            {
                mensagemDeErro.AppendLine("O campo 'Senha' não pode estar vazio!");
            }

            return mensagemDeErro.ToString();
        }
    }
}