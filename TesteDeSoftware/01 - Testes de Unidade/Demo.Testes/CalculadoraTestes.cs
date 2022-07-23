using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Demo.Testes
{
    public class CalculadoraTestes
    {
        [Fact]

        public void Calculadora_Soma_RetornaValorSoma()
        {
            //Arrange
            var calculadora = new Calculadora();


            // Act
            var resultado = calculadora.Somar(2, 2);


            //Assert
            Assert.Equal(4, resultado);
            // Assert.Equal(Valor Esperado, Valor do Resultado)
        }

        [Fact]

        public void Calculadora_Subtracao_RetornaValorSubtracao()
        {
            //Arrange
            var calculadora = new Calculadora();


            // Act
            var resultado = calculadora.Subtrair(4, 2);


            //Assert
            Assert.Equal(2, resultado);
            // Assert.Equal(Valor Esperado, Valor do Resultado)
        }

        //Segunda forma de testar valores, [InlineData(primeiroValor,segundoValor, resultadoEsperado)]
        [Theory]
        [InlineData(1,1,2)]
        [InlineData(2, 3, 5)]
        [InlineData(5, 3, 8)]
        [InlineData(8, 5, 13)]
        [InlineData(13, 5, 18)]
        [InlineData(18, 5, 23)]
        public void Calculadora_Somar_RetornaSomaCorreta(double v1, double v2, double total)
        {
            //arrange
            var calculadora = new Calculadora();


            // Act
            var resultado = calculadora.Somar(v1, v2);


            //Assert
            Assert.Equal(total, resultado);
        }

        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(2, 3, 6)]
        [InlineData(5, 3, 15)]
        [InlineData(8, 5, 40)]
        [InlineData(13, 5, 65)]
        [InlineData(18, 5, 90)]
        public void Calculadora_Multiplicar_RetornaProdutoCorreto(int v1, int v2, int total)
        {
            //arrange
            var calculadora = new Calculadora();


            // Act
            var resultado = calculadora.Multiplicar(v1, v2);


            //Assert
            Assert.Equal(total, resultado);

        }
    }
}
