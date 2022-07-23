using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Demo.Testes
{
    public class AssertNullBoolTestes
    {

        [Fact]
        public void Funcionario_Nome_NaoDeveSerNullOuVazio()
        {
            //Arrange & Act
            var funcionario = new Funcionario(nome: "", salario: 1000);

            //Assert

            Assert.False(string.IsNullOrEmpty(funcionario.Nome));
            //Assert IsNullOrEmpty verifica se valor é falso ou vazio
            //Fulano está sendo passado no construtor log este metodo nunca será nullo ou vazio, mesmo passando a variavel vazia.
        }

        [Fact]
        public void Funcionario_Apelido_NaoDeveTerApelido()
        {
            //Arrange & Act
            var funcionario = new Funcionario(nome: "Alexandre", salario: 1000);

            //Assert
            Assert.Null(funcionario.Apelido);
          //Assert.NotNull(funcionario.Apelido); verifica se valor não é nulo


            //Assert Bool
            Assert.True(string.IsNullOrEmpty(funcionario.Apelido)); // verifica se valor é nulo ou vazio, apelido não foi passado logo valor é true
            Assert.False(condition: funcionario.Apelido?.Length > 0); // verifica se apelido é maior que zero, neste caso o valor é falso pois apelido não fo passado

        }
    }
}
