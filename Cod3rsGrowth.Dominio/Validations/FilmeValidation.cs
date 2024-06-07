using Cod3rsGrowth.Dominio.Modelos;
using FluentValidation;
using System;

namespace Cod3rsGrowth.Dominio.Validations;

public class FilmeValidation : AbstractValidator<Filme>
{
    public FilmeValidation()
    {
        RuleFor(p => p.Titulo)
            .NotEmpty()
            .WithMessage("Campo de titulo obrigatorio");

        RuleFor(d => d.DataDeLancamento)
            .Must(d => d <= DateTime.Now)
            .WithMessage("A data de lancamento nao pode ser superior a data atual");

        RuleFor(id => id.Id)
            .NotEmpty()
            .WithMessage("Id não cadastrado");

        RuleFor(id => id.Id)
            .Must(id => id > 0)
            .WithMessage("Id nao pode ser negativo");
    }
}