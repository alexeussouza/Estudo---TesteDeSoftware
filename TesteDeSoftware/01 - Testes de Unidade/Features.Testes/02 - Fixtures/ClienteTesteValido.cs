using Features.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Features.Testes
{
    [Collection(nameof(ClienteCollection))] // todas as classes que recebem a ClienteFixtureTeste precisa ter declarado que a classe faz parte da coleção ClienteCollection
    public class ClienteTesteValido
    {
        private readonly ClienteTesteFixture _clienteTestesFixture;

        public ClienteTesteValido(ClienteTesteFixture clienteTestesFixture)
        {
            _clienteTestesFixture = clienteTestesFixture;   // injetando no construtor atraves de Injeção de Dependência. 
        }

        [Fact(DisplayName = "Novo Cliente Valido")]
        [Trait("Categoria", "Cliente Trait Testes")]
        public void Cliente_NovoCliente_DeveEstarValido()
        {
            //Arrange
            var cliente = _clienteTestesFixture.GerarClienteValido();  // testa se o cliente é valido  */

            //Act

            var result = cliente.EhValido();

            //Assert

            Assert.True(result);
            Assert.Equal(expected: 0, actual: cliente.ValidationResult.Errors.Count);

        }
    }
}
