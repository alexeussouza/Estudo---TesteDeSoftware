using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Demo.Testes
{
    public class AssertInObjectTypesTestes
    {
        [Fact]
        public void FuncionarioFactory_Criar_DeveRetornarTipoFuncionario()
        {
            //Arrange & Act

            var funcionario = new Funcionario(nome: "Alexandre", salario: 10000);

            
            //Assert
           Assert.IsType<Funcionario>(funcionario); // verifica se a variavel funcionario é do tipo Funcionario

        }

        [Fact]
        public void FuncionarioFactory_Criar_DeveRetornarTipoDerivadoPessoa()
        {

            //Arrange & Act

            var funcionario = new Funcionario(nome: "Alexandre", salario: 10000);


            //Assert
            Assert.IsAssignableFrom<Pessoa>(funcionario); // Verifica se esta classe é derivada(herda) de Pessoa 
        }

    }
}
