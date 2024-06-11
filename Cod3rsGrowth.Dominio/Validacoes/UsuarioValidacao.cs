using Cod3rsGrowth.Dominio.Modelos;
using FluentValidation;
using System;

namespace Cod3rsGrowth.Dominio.Validacoes;

public class UsuarioValidacao : AbstractValidator<Usuario>
{
    public UsuarioValidacao()
    {
        const int IdBase = 0;

        RuleFor(n => n.Nome)
            .NotEmpty()
            .WithMessage("O campo 'Nome' não pode estar vazio!")
            .Must(nome => nome is string)
            .WithMessage("O campo 'Nome' deve ser uma cadeia de caracteres válidas!")
            .Matches("^[^0-9]*$")
            .WithMessage("O campo 'Nome' não deve conter números!");

        RuleFor(n => n.NickName)
            .NotEmpty()
            .WithMessage("O campo 'nome de usuário' não pode estar vazio!")
            .Must(nome => nome is string)
            .WithMessage("O campo 'Nome' deve ser uma cadeia de caracteres válidas!");

        RuleFor(s => s.Senha)
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