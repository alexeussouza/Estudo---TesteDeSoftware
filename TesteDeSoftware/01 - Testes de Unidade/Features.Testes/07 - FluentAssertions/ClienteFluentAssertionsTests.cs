using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Features.Tests
{
    [Collection(nameof(ClienteBogusCollection))]
    public class ClienteFluentAssertionsTests
    {
        private readonly ClienteBogusFixture _clienteBogusFixture;
        readonly ITestOutputHelper _outputHelper;

        public ClienteFluentAssertionsTests(ClienteBogusFixture clienteBogusFixture, ITestOutputHelper outputHelper)
        {
            _clienteBogusFixture = clienteBogusFixture;
            _outputHelper = outputHelper;
        }

        [Fact(DisplayName = "Novo Cliente Válido")]
        [Trait("Categoria", "Cliente Fluent Assertions Testes")]
        public void Cliente_NovoCliente_DeveEstarValido()
        {
            // Arrange
            var cliente = _clienteBogusFixture.GerarClienteValido();

            // Act
            var result = cliente.EhValido();

            // Assert
            result.Should().BeTrue();//resultado deve estar verdadeiro
            cliente.ValidationResult.Errors.Should().HaveCount(0);// validação de erros deve ter quantidade zero
        }

        [Fact(DisplayName = "Novo Cliente Inválido")]
        [Trait("Categoria", "Cliente Fluent Assertions Testes")]
        public void Cliente_NovoCliente_DeveEstarInvalido()
        {
            // Arrange
            var cliente = _clienteBogusFixture.GerarClienteInvalido();

            // Act
            var result = cliente.EhValido();

            // Assert
            result.Should().BeFalse();
            cliente.ValidationResult.Errors.Should().HaveCountGreaterOrEqualTo(1);

            _outputHelper.WriteLine($"Foram encontrados {cliente.ValidationResult.Errors.Count} erros nesta validação");
        }
    }
}