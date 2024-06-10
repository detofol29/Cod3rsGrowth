using Cod3rsGrowth.Dominio.Modelos;
using FluentValidation;
using System;

namespace Cod3rsGrowth.Dominio.Validacoes;

public class FilmeValidacao : AbstractValidator<Filme>
{
    public FilmeValidacao()
    {
        const int IdBase = 0;

        RuleFor(p => p.Titulo)
            .NotEmpty()
            .WithMessage("O campo 'Titulo' não pode estar vazio!");

        RuleFor(d => d.DataDeLancamento)
            .LessThan(DateTime.Now)
            .WithMessage("O campo 'data de lançamento' não pode ser superior a data atual");

        RuleFor(id => id.Id)
            .Must(id => id > IdBase)
            .WithMessage("O campo 'Id' não pode ser um número negativo!");
    }
}