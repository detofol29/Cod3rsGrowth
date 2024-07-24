using Cod3rsGrowth.Dominio.Modelos;
using FluentValidation;

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

        RuleFor(d => d.Diretor)
            .NotEmpty()
            .WithMessage("O campo 'Diretor' não pode estar vazio!");

        RuleFor(d => d.Duracao)
            .NotEmpty()
            .WithMessage("O campo 'Duracao' não pode estar vazio!");
    }
}