using Cod3rsGrowth.Dominio.Modelos;
using FluentValidation;
using System;

namespace Cod3rsGrowth.Dominio.Validations;

public class UsuarioValidation : AbstractValidator<Usuario>
{
    public UsuarioValidation()
    {
        RuleFor(n => n.Nome)
            .NotEmpty()
            .WithMessage("Nome nao pode estar vazio");

        RuleFor(n => n.NickName)
            .NotEmpty()
            .WithMessage("O nome de usuario nao pode estar vazio");

        RuleFor(s => s.Senha)
            .NotEmpty()
            .WithMessage("A senha deve ter no minimo 6 digitos")
            .MinimumLength(6)
            .WithMessage("A senha deve ter no minimo 6 digitos");

        RuleFor(id => id.IdUsuario)
            .NotEmpty()
            .WithMessage("Id nao pode ser nulo")
            .Must(id => id > 0)
            .WithMessage("Id precisa ser um numero positivo");
    }
}