using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Features.Clientes;
using Xunit;


namespace Features.Testes
{
    
    [CollectionDefinition(nameof(ClienteCollection))] // Definição da coleção, usando o nameof se a classe mudar de nome ele muda tambem
    public class ClienteCollection : ICollectionFixture<ClienteTesteFixture>
    { } // classe para uma coleção de classes de testes
    
    public class ClienteTesteFixture : IDisposable 
        // ClienteFixtureTeste é iniciado antes de instanciar a classe de teste e fica disponivel para todos os testes que fazem parte da coleçao.
        // Na classe de teste o construtor é criado e destruido em cada teste, no Fixture ele destruido apenas quando o ultimo teste roda no Dispose();
    {
        public Cliente GerarClienteValido() 
        {

            var cliente = new Cliente(
                Guid.NewGuid(),
                nome: "Eduardo",
                sobrenome: "Pires",
                dataNascimento: DateTime.Now.AddYears(-30),
                email: "edu@edu.com",
                ativo: true,
                dataCadastro: DateTime.Now); // testa se o cliente é valido
            
            return cliente;
        }

        public Cliente GerarClienteInvalido() 
        {

            var cliente = new Cliente(
                Guid.NewGuid(),
                nome: "",
                sobrenome: "",
                dataNascimento: DateTime.Now,
                email: "edu.edu.com",
                ativo: true,
                dataCadastro: DateTime.Now); // testa se o cliente é invalido

            return cliente;
        }


        public void Dispose() // para a interface IDisposable é necessário implemetnar o metodo Dipose()
        {
            
        }
    }
}
