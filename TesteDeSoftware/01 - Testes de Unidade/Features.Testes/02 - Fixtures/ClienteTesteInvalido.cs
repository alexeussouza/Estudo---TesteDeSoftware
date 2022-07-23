using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Features.Clientes;

namespace Features.Testes
{
    [Collection(nameof(ClienteCollection))] // todas as classes que recebem a ClienteFixtureTeste precisa ter declarado que a classe faz parte da coleção
    public class ClienteTesteInvalido
    {
       private readonly ClienteTesteFixture _clienteTesteFixture;

        public ClienteTesteInvalido(ClienteTesteFixture clienteTesteFixture) // injeta no construtor atraves de Injeção de Dependencia
        {
            _clienteTesteFixture = clienteTesteFixture;
        }
    
        [Fact(DisplayName = "Novo Cliente Invalido")]
        [Trait("Categoria", "Cliente Trait Testes")]
        public void Cliente_NovoCliente_DeveEstarInvalido()
        {
            //Arrange
            var cliente = _clienteTesteFixture.GerarClienteInvalido(); // testa se o cliente é invalido

            //Act

            var result = cliente.EhValido();

            //Assert

            Assert.False(result);
            Assert.NotEqual(expected: 0, actual: cliente.ValidationResult.Errors.Count);

        }
    }
}
