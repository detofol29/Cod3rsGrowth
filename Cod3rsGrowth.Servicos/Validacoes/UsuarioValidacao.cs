using Cod3rsGrowth.Dominio.Modelos;
using FluentValidation;
using System.Linq;

namespace Cod3rsGrowth.Servicos.Validacoes;

public class UsuarioValidacao : AbstractValidator<Usuario>
{
    public UsuarioValidacao()
    {
        RuleFor(n => n.Nome)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("O campo 'Nome' não pode estar vazio!")
            .Must(nome => nome is string)
            .WithMessage("O campo 'Nome' deve ser uma cadeia de caracteres válidas!")
            .Matches(@"^[a-zA-ZÀ-ÿ\s]*$")
            .WithMessage("O campo 'Nome' deve conter apenas letras!");

        RuleFor(n => n.NickName)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("O campo 'NickName' não pode estar vazio!")
            .Must(nome => nome is string)
            .WithMessage("O campo 'Nome' deve ser uma cadeia de caracteres válidas!");

        RuleFor(s => s.Senha)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("O campo 'senha' não pode estar vazio!")
            .MinimumLength(6)
            .WithMessage("O campo 'senha' deve ter no mínimo 6 digitos!")
            .Matches("[A-Z]")
            .WithMessage("O campo 'senha' deve conter pelo menos uma letra maiúscula!")
            .Matches("[a-z]")
            .WithMessage("O campo 'senha' deve conter pelo menos uma letra minuscula!")
            .Matches("[0-9]")
            .WithMessage("O campo 'senha' deve conter pelo menos um número!");
    }
}