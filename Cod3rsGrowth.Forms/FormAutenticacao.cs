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
using Microsoft.AspNetCore.Mvc;
using Cod3rsGrowth.web.Controllers;

namespace Cod3rsGrowth.Forms
{
    public partial class FormAutenticacao : Form
    {
        private UsuarioServicos service;
        private UsuarioRepositorio repositorio;
        private FilmeServicos filmeService;
        private Usuario usuario;
        public FormAutenticacao(UsuarioServicos _service, FilmeServicos _filmeService, UsuarioRepositorio _repositorio)
        {
            InitializeComponent();
            service = _service;
            filmeService = _filmeService;
            repositorio = _repositorio;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var nickname = textBox1.Text;
            var senha = textBox2.Text;

            var usuarioInserido = new Usuario()
            {
                NickName = nickname,
                Senha = senha
            };

            var usuarioRetorno = service.AutenticarUsuario(usuarioInserido);
            if(usuarioRetorno == null) { MessageBox.Show("Usuario ou senha Inválidos!"); }
            else
            {
                Hide();
                new FormListaFilme(filmeService, usuarioRetorno).Show();
            }
        }    
    }
}