using Cod3rsGrowth.Dominio.Modelos;
using FluentValidation;

namespace Cod3rsGrowth.Servicos.Validacoes;

public class AtorValidacao : AbstractValidator<Ator>
{
    public AtorValidacao()
    {
        RuleFor(n => n.Nome)
            .NotEmpty()
            .WithMessage("O campo de 'Nome' não pode estar vazio!")
            .Matches("^[^0-9]*$")
            .WithMessage("O campo 'Nome' não deve conter números!");
    }
}