﻿using Docker.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docker.Test.Core.Enums
{
    public class GeneroTest
    {
        [Fact]
        public void DeveTerTresValores_OK()
        {
            // Assert
            Assert.Equal(3, System.Enum.GetValues(typeof(Genero)).Length);
        }

        [Theory]
        [InlineData(Genero.Masculino, 1)]
        [InlineData(Genero.Feminino, 2)]
        [InlineData(Genero.Outro, 3)]
        public void DeveTerValores_OK(Genero genero, int valorEsperado)
        {
            // Assert
            Assert.Equal(valorEsperado, (int)genero);
        }
    }
}
