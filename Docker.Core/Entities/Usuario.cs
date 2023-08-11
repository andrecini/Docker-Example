using Docker.Core.Enums;
using Docker.Core.FluentValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docker.Core.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public int Idade { get; set; }
        public Genero Genero { get; set; }

        public Validacao ValidarUsuario()
        {
            var fluentvalidator = new UserValidator().Validate(this);
            var validacao = new Validacao();

            if (fluentvalidator.IsValid)
            {
                validacao.EhValido = true;
                validacao.Mensagens = null;
            }
            else
            {
                validacao.EhValido = false;
                validacao.Mensagens = fluentvalidator.Errors.Select(x => x.ErrorMessage.ToString()).ToList();
            }

            return validacao;
        }
    }
}
