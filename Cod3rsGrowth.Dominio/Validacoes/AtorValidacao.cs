using Cod3rsGrowth.Dominio.Modelos;
using FluentValidation;
using System;

namespace Cod3rsGrowth.Dominio.Validacoes;

public class AtorValidacao : AbstractValidator<Ator>
{
    public AtorValidacao()
    {
        const int IdBase = 0;
        RuleFor(n => n.Nome)
            .NotEmpty()
            .WithMessage("O campo de 'Nome' não pode estar vazio!")
            .Matches("^[^0-9]*$")
            .WithMessage("O campo 'Nome' não deve conter números!");
    }
}