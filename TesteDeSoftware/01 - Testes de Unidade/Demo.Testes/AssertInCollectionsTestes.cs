using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Demo.Testes
{
    public class AssertInCollectionsTestes
    {
        [Fact]
        public void Funcionario_Habilidades_NãoDevePossuirHabilidadesVazias()
        {
            //Arrange & Act
            var funcionario = new Funcionario(nome: "Alexandre", salario: 10000);

            //Assert
            Assert.All(funcionario.Habilidades, action: habilidade => Assert.False(string.IsNullOrWhiteSpace(habilidade)));
            //primeiro Assert verifica toda a coleção e no segundo Assert verica uma habilidade de cada vez se é nula ou vazia

        }

        [Fact]
        public void Funcionario_Habilidade_JuniorDevePossuirHabilidadeBasica()
        {

            //Arrange & Act
            var funcionario = new Funcionario(nome: "Alexandre", salario: 1000);

            //Assert
            Assert.Contains(expected: "OOP", funcionario.Habilidades); // Verifica se funcionario contem habilidade OOP

        }

        [Fact]
        public void Funcionario_Habilidades_JuniorNaoDevePossuirHabilidadedeAvancada()
        {
            //Arrange & Act
            var funcionario = new Funcionario(nome: "Alexandre", salario: 1000);// Identifica o nivel do funcionario pela faixa salarial

            //Assert
            Assert.DoesNotContain(expected: "Microservices", funcionario.Habilidades);//funcionario.Habilidades não deve ter Microservices
        }

        [Fact]
        public void Funcionario_Habilidades_SeniorDevePossuirTodasHabilidades()
        {
            //Arrange & Act
            var funcionario = new Funcionario(nome: "Alexandre", salario: 15000);

            var habilidadesBasicas = new[]
            {
                "Lógica de Programação",
                "OOP",
                "Testes",
                "Microservices"
            }; // array com todas habilidades de um Senior


            //Assert
            Assert.Equal(expected: habilidadesBasicas, actual: funcionario.Habilidades); // compara habilidadesBasicas com as habilidades do funcionario selecionado.
        }
    }
}
