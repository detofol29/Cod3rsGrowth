using Cod3rsGrowth.Dominio.Modelos;
using FluentValidation;
using System;

namespace Cod3rsGrowth.Servicos.Validacoes;

public class FilmeValidacao : AbstractValidator<Filme>
{
    public FilmeValidacao()
    {
        RuleFor(p => p.Titulo)
            .NotEmpty()
            .WithMessage("O campo 'Titulo' não pode estar vazio!");

        RuleFor(d => d.DataDeLancamento)
            .LessThan(DateTime.Now)
            .WithMessage("O campo 'data de lançamento' não pode ser superior a data atual");
    }
}