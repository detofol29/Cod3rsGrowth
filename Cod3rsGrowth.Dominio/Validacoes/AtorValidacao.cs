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
            .WithMessage("O campo de 'Nome' não pode estar vazio!");

        RuleFor(id => id.Id)
            .Must(id => id > IdBase)
            .WithMessage("O campo 'Id' precisa conter um número positivo!");
    }
}