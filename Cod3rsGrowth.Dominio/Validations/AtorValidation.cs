using Cod3rsGrowth.Dominio.Modelos;
using FluentValidation;
using System;

namespace Cod3rsGrowth.Dominio.Validations;

public class AtorValidation : AbstractValidator<Ator>
{
    public AtorValidation()
    {
        RuleFor(n => n.Nome)
            .NotEmpty()
            .WithMessage("Nome nao pode estar vazio");

        RuleFor(id => id.Id)
            .NotEmpty()
            .WithMessage("Id nao pode ser nulo")
            .Must(id => id > 0)
            .WithMessage("Id precisa ser um numero positivo");
    }
}