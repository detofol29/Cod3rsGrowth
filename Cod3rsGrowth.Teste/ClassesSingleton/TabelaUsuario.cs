using Cod3rsGrowth.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.Teste.ClassesSingleton;

public class TabelaUsuario
{
    private static TabelaUsuario instancia;

    private List<Usuario> usuarios;

    private TabelaUsuario()
    {
        usuarios = new List<Usuario>
        {
            new() {Nome = "Detofol", IdUsuario = 1, Plano = PlanoEnum.Premium, NickName = "Detofol29", Senha = "123"},
            new() {Nome = "Marcos Paulo", IdUsuario = 2, Plano = PlanoEnum.Nerd, NickName = "Marcos_Paulo", Senha = "123"},
            new() {Nome = "Rubens", IdUsuario = 3, Plano = PlanoEnum.Kids, NickName = "Rubens", Senha = "123"},
            new() {Nome = "Andre", IdUsuario = 4, Plano = PlanoEnum.Free, NickName = "Andr3", Senha = "123"},
        };
    }
    public static TabelaUsuario Instance
    {
        get
        {
            if (instancia == null)
            {
                instancia = new TabelaUsuario();
            }
            return instancia;
        }
    }
    public List<Usuario> Usuarios => usuarios;
}