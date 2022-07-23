using Bogus;
using Bogus.DataSets;
using Features.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Features.Tests
{
    [CollectionDefinition(nameof(ClienteBogusCollection))]
    public class ClienteBogusCollection : ICollectionFixture<ClienteBogusFixture>
    { }

    public class ClienteBogusFixture : IDisposable
    {

        public Cliente GerarClienteValido()
        {
            return GerarClientes(1, true).FirstOrDefault();
        }

        public IEnumerable<Cliente> ObterClientesVariados()
        {
            var clientes = new List<Cliente>();

            clientes.AddRange(GerarClientes(50, true).ToList());
            clientes.AddRange(GerarClientes(50, false).ToList());

            return clientes;
        }
        public IEnumerable<Cliente> GerarClientes(int quantidade, bool ativo)
        {

            //var email = new Faker().Internet.Email("eduardo", "pires", "gmail");
            //var clientefaker = new Faker<Cliente>();
            //clientefaker.RuleFor(c => c.Nome, (f, c) => f.Name.FirstName());

            var genero = new Faker().PickRandom<Name.Gender>();

            var clientes = new Faker<Cliente>(locale: "pt_BR")
                .CustomInstantiator(f => new Cliente(
                        Guid.NewGuid(),
                        f.Name.FirstName(genero),
                        f.Name.LastName(genero),
                        f.Date.Past(yearsToGoBack: 80, DateTime.Now.AddYears(-18)),
                        email:"",
                        ativo: true,
                        dataCadastro: DateTime.Now))
                .RuleFor(property: c => c.Email, setter: (f,c) =>
                f.Internet.Email(firstName: c.Nome.ToLower(), lastName: c.Sobrenome.ToLower())); // email foi gerado aqui para usar o nome e sobrenomes gerados pelo genero no codigo acima

            return clientes.Generate(quantidade);
        }

        public Cliente GerarClienteInvalido()
        {
            var genero = new Faker().PickRandom<Name.Gender>();

            var cliente = new Faker<Cliente>(locale: "pt_BR")
                .CustomInstantiator(f => new Cliente(
                Guid.NewGuid(),
                nome: "",
                sobrenome: "",
                dataNascimento: f.Date.Past(yearsToGoBack:1, DateTime.Now.AddYears(1)),
                email: "edu2edu.com",
                ativo: false,
                dataCadastro: DateTime.Now));

            return cliente;
        }

        public void Dispose()
        {

        }
    }
}