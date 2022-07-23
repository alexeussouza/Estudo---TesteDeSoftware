using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Demo.Testes
{
    public class AssertInRangesTestes
    {
        [Theory]
        [InlineData(700)]
        [InlineData(1500)]
        [InlineData(2000)]
        [InlineData(7000)]
        [InlineData(7500)]
        [InlineData(8000)]
        [InlineData(8500)]
        [InlineData(15000)]

        public void Funcionario_Salario_FaixaSalarialDevemRespeitarNivelProfissional(double salario)
        {
            //Arrange & Act
            var funcionario = new Funcionario(nome: "Alexandre", salario);



            // Assert
            if (funcionario.NivelProfissional == NivelProfissional.Junior)
                Assert.InRange(actual: funcionario.Salario, low: 500, high: 1999);// verifica se está ertre 500 e valor maximo 1999

            if (funcionario.NivelProfissional == NivelProfissional.Pleno)
                Assert.InRange(actual: funcionario.Salario, low: 2000, high: 7999);// verifica se está ertre 2000 e valor maximo 7999

            if (funcionario.NivelProfissional == NivelProfissional.Senior)
                Assert.InRange(actual: funcionario.Salario, low: 8000, high: double.MaxValue); // verifica se o minimo do salario é 8000 e valor maximo não foi definido

            Assert.NotInRange(actual:funcionario.Salario, low:0, high:499); // Salario não pode estar entre 0 e 499

        }
    }
}
