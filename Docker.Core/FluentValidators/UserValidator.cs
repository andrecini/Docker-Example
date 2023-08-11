using Docker.Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
