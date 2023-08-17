using Docker.Core.Entities;
using FluentValidation;

namespace Docker.Core.FluentValidators
{
    public class UserValidator : AbstractValidator<Usuario>
    {
        public UserValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("Especifique o Nome do Usuário.");
            RuleFor(x => x.Sobrenome).NotEmpty().WithMessage("Especifique o Sobrenome do Usuário.");
            RuleFor(x => x.Idade).InclusiveBetween(1, 120).WithMessage("A Idade informada não é válida.");
            RuleFor(x => x.Genero).IsInEnum().WithMessage("Especifique o Gênero do Usuário.");
        }
    }
}
