using Cod3rsGrowth.Servicos.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Servicos.Servicos;

public class UsuarioServicos : IUsuarioServicos
{
    public void AdicionarFilmeNaMinhaLista(Filme filme, Usuario usuario)
    {
        usuario.MinhaLista.Add(filme);
    }

    public void Logar(string nick, string senha)
    {
    }

    public void Deslogar(Usuario usuario)
    {
    }

    public void LicenciarFilmePorUsuario(Usuario usuario)
    {
    }
}