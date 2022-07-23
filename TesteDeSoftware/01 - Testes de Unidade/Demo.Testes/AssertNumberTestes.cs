using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Demo.Testes
{
    public class AssertNumberTestes
    {
        [Fact]
        public void Calculadora_Somar_DeveSerIgual()
        {
            //Arrange
            var calculadora = new Calculadora();

            //Act
            var resultado = calculadora.Somar(1, 2);

            //Assert
            Assert.Equal(expected: 3, actual: resultado);
        }

        [Fact]
        public void Calculadora_Somar_NaoDeveSerIgual()
        {
            //Arrange
            var calculadora = new Calculadora();

            //Act
            var resultado = calculadora.Somar(1.13123123123, 2.2312313123);

            //Assert
            Assert.NotEqual(expected: 3.3, actual: resultado, precision: 1);
            // usando a propridade precision ele usa a precisao de 1 
        }

    }
}
