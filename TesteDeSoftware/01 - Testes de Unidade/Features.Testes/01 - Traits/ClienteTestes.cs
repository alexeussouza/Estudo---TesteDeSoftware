
using Features.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Features.Testes
{
    public class ClienteTestes
    {
        [Fact(DisplayName ="Novo Cliente Valido")]
        [Trait("Categoria", "Cliente Trait Testes")]
        public void Cliente_NovoCliente_DeveEstarValido()
        {
            //Arrange
            var cliente = new Cliente(
                Guid.NewGuid(),
                nome: "Eduardo",
                sobrenome: "Pires",
                dataNascimento: DateTime.Now.AddYears(-30),
                email: "edu@edu.com",
                ativo:true,
                dataCadastro: DateTime.Now); // testa se o cliente é valido

            //Act

            var result = cliente.EhValido();

            //Assert

            Assert.True(result);
            Assert.Equal(expected: 0, actual: cliente.ValidationResult.Errors.Count);

        }

        [Fact(DisplayName = "Novo Cliente Inv alido")]
        [Trait("Categoria", "Cliente Trait Testes")]
        public void Cliente_NovoCliente_DeveEstarInvalido()
        {
            //Arrange
            var cliente = new Cliente(
                Guid.NewGuid(),
                nome: "",
                sobrenome: "",
                dataNascimento: DateTime.Now,// testa se o cliente é invalido
                email: "edu.edu.com",
                ativo: true,
                dataCadastro: DateTime.Now); // testa se o cliente é valido

            //Act

            var result = cliente.EhValido();

            //Assert

            Assert.False(result);
            Assert.NotEqual(expected: 0, actual: cliente.ValidationResult.Errors.Count);

        }
    }
}
