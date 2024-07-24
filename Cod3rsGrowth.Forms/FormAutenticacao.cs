using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Infra.Repositorios;
using Cod3rsGrowth.Servicos.Servicos;

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
                    MessageBox.Show("Usuário ou senha Inválidos!");
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
            catch(Exception ex)
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
    }
}