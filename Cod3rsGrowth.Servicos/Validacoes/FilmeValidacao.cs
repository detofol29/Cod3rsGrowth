using Cod3rsGrowth.Dominio.Modelos;
using FluentValidation;

namespace Cod3rsGrowth.Servicos.Validacoes;

public class FilmeValidacao : AbstractValidator<Filme>
{
    public FilmeValidacao()
    {
        RuleFor(p => p.Titulo)
            .NotEmpty()
            .WithMessage("O campo 'Título' não pode estar vazio!");

        RuleFor(d => d.DataDeLancamento)
            .LessThan(DateTime.Now)
            .WithMessage("O campo 'data de lançamento' não pode ser superior a data atual");

        RuleFor(d => d.Diretor)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("O campo 'Diretor' não pode estar vazio!")
            .Must(nome => nome is string)
            .WithMessage("O campo 'Diretor' deve ser uma cadeia de caracteres válidas!")
            .Matches(@"^[a-zA-ZÀ-ÿ\s]*$")
            .WithMessage("O campo 'Diretor' deve conter apenas letras!");

        RuleFor(d => d.Duracao)
            .NotEmpty()
            .WithMessage("O campo 'Duração' não pode estar vazio!");

        RuleFor(d => d.Nota)
            .NotNull()
            .WithMessage("O campo 'Nota' não pode estar vazio!")
            .InclusiveBetween(0, 10)
            .WithMessage("O campo 'Nota' deve conter valores entre 0 e 10!");
    }  
}