﻿using Docker.Core.Entities;
using Docker.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docker.Test.Core.Entities
{
    public class UsuarioTest
    {
        [Fact]
        public void ValidarUsuario_OK()
        {
            // Arrange
            var usuario = new Usuario
            {
                Id = 1,
                Nome = "André",
                Sobrenome = "Cini",
                Idade = 22,
                Genero = Genero.Masculino
            };

            // Act
            var validacao = usuario.ValidarUsuario();

            // Assert
            Assert.True(validacao.EhValido);
            Assert.Null(validacao.Mensagens);
        }

        [Fact]
        public void ValidarUsuario_ERRO()
        {
            // Arrange
            var usuario = new Usuario
            {
                Id = 1,
                Nome = "",
                Sobrenome = "",
                Idade = 140,
                Genero = (Genero)4
            };

            // Act
            var validacao = usuario.ValidarUsuario();

            // Assert
            Assert.False(validacao.EhValido);
            Assert.NotNull(validacao.Mensagens);
            Assert.Equal(4, validacao.Mensagens.Count);
        }
    }
}
