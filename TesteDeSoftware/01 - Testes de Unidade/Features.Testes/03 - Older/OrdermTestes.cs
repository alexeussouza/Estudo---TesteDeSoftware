using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Features.Tests
{
    //Usar a ordenação em casos de integração onde por exemplo, precisa criar um usuario e depois fazer logon, apenas nestes casos
    // um teste não pode depender de outro, se depender está errado, exceto em casos de testes em integração.
   
    [TestCaseOrderer("Features.Tests.PriorityOrderer", "Features.Tests")] // TestCaseOrderer(NameSpace.Classe(onde esta a classe), NameSpace (onde sera feito o teste)
    public class OrdemTestes
    {
        public static bool Teste1Chamado;
        public static bool Teste2Chamado;
        public static bool Teste3Chamado;
        public static bool Teste4Chamado;

        [Fact(DisplayName = "Teste 04"), TestPriority(3)] // na prioridade dos testes este será o 3º a ser executado
        [Trait("Categoria", "Ordenação Testes")]
        public void Teste04()
        {
            Teste4Chamado = true;

            Assert.True(Teste3Chamado);
            Assert.True(Teste1Chamado);
            Assert.False(Teste2Chamado);
        }

        [Fact(DisplayName = "Teste 01"), TestPriority(2)] // na prioridade dos testes este será o 2º a ser executado
        [Trait("Categoria", "Ordenação Testes")]
        public void Teste01()
        {
            Teste1Chamado = true;

            Assert.True(Teste3Chamado);
            Assert.False(Teste4Chamado);
            Assert.False(Teste2Chamado);
        }

        [Fact(DisplayName = "Teste 03"), TestPriority(1)] // na prioridade dos testes este será o 1º a ser executado
        [Trait("Categoria", "Ordenação Testes")]
        public void Teste03()
        {
            Teste3Chamado = true;

            Assert.False(Teste1Chamado);
            Assert.False(Teste2Chamado);
            Assert.False(Teste4Chamado);
        }

        [Fact(DisplayName = "Teste 02"), TestPriority(4)] // na prioridade dos testes este será o 4º a ser executado
        [Trait("Categoria", "Ordenação Testes")]
        public void Teste02()
        {
            Teste2Chamado = true;

            Assert.True(Teste3Chamado);
            Assert.True(Teste4Chamado);
            Assert.True(Teste1Chamado);
        }
    }
}
