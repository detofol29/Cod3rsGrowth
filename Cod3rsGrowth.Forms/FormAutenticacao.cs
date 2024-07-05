using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Infra;
using Cod3rsGrowth.Infra.Repositorios;
using Cod3rsGrowth.Servicos.Servicos;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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
            //Hide();
            //Metodo de autenticar que deve retornar um usuario para usar de parametro
            //new FormListaFilme(filmeService, new Usuario()).Show();
        }    
        public Usuario Autenticar(string nickName, string senha, FilmeRepositorio _servico)
        {
            return new Usuario();
        }
    }
}