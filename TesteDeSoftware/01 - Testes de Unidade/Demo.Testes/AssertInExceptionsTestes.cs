using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Demo.Testes
{
    public class AssertInExceptionsTestes
    {

        [Fact]
        public void Calculadora_Dividir_DeveRetornarErroDivisaoPorZero()
        {
            //Arrange
            var calculadora = new Calculadora();

            //Act & Assert
            Assert.Throws<DivideByZeroException>(testCode: () => calculadora.Dividir(10, 0)); // Verifica se será lançada a exceçao ao executar o metodo calculadora.Dividir(10, 0)
        }

        [Fact]
        public void Funcionario_Salario_DeveRetornarErrosSalarioInferiorPermitido()
        {
            //Arrange & Act & Assert
            var exception = Assert.Throws<Exception>(testCode: () => FuncionarioFactory.Criar(nome: "Alexandre", salario: 250));
            // Guardando o valor retornado pelo Assert na variavel exception

            Assert.Equal(expected: "Salário inferior ao permitido", actual: exception.Message);
            // usando variavel exception na comparação do texto no Assert

        }
    }
}
