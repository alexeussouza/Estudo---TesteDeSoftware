using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Demo.Testes
{
    public class AssertStringsTestes
    {
        [Fact]

        public void StringTools_UnirNomes_RetornarNomeCompleto()
        {
            //Arrange
            var sut = new StringTools(); // Verifica o metodo unir nomes da classe StringTools

            //Act
            var nomeCompleto =  sut.Unir(nome: "Alexandre", sobrenome:"Souza");

            //Assert
            Assert.Equal(expected: "Alexandre Souza", actual: nomeCompleto);
        }

        [Fact]
        public void StringTools_UnirNomes_DeveIgnorarCaseSensitive()
        {
            //Arrange

            var sut = new StringTools();

            //Act
            var nomeCompleto  = sut.Unir(nome: "Alexandre", sobrenome: "Souza");

            //Assert
            Assert.Equal(expected: "Alexandre Souza", actual: nomeCompleto, ignoreCase: true);
            // Verifica resultado e ignora CaseSensitive das strings
        }

        [Fact]
        public void StringTools_UnirNomes_ContemTrecho()
        {
            //Arrange

            var sut = new StringTools();

            //Act
            var nomeCompleto = sut.Unir(nome: "Alexandre", sobrenome: "Souza");

            //Assert
            Assert.Contains(expectedSubstring: "ndre", actualString: nomeCompleto);
            // Verifica se a string contem o valor informado
        }

        [Fact]
        public void StringTools_UnirNomes_DeveComeçarCom()
        {
            //Arrange
            var sut = new StringTools();

            //Act
            var nomeCompleto = sut.Unir(nome: "Alexandre", sobrenome: "Souza");

            //Assert
            Assert.StartsWith(expectedStartString:"Ale",actualString: nomeCompleto);
            // Verifica o valor no inicio da string
        }

        [Fact]
        public void StringTools_UnirNomes_DeveTerminarCom()
        {
            //Arrange
            var sut = new StringTools();

            //Act
            var nomeCompleto = sut.Unir(nome: "Alexandre", sobrenome: "Souza");

            //Assert
            Assert.EndsWith(expectedEndString:"uza", actualString: nomeCompleto);
            // Verifica o valor no final da string
        }

        [Fact]
        public void StringTools_UnirNomes_ValidarExpressaoRegular()
        {
            //Arrange
            var sut = new StringTools();

            //Act
            var nomeCompleto = sut.Unir(nome:"Alexandre", sobrenome: "Souza");

            //Assert
            Assert.Matches(expectedRegexPattern:"[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", actualString: nomeCompleto);
            // Verifica o valor da expressão regular, nomes de A ate Z maiusculos e minusculos, caso tenha acento ocorre erro
        }
    }
}
