using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Features.Clientes
{
    public class ClienteService : IClienteService   
    {
        private readonly IClienteRepository _clienteRepository; // recebe injeção de dependencia de repositorio
        private readonly IMediator _mediator; // meditaor faz o envio de eventos

        public ClienteService(IClienteRepository clienteRepository, IMediator mediator)
        {
            _clienteRepository = clienteRepository;
            _mediator = mediator;
        } // construtor recebe por injeção de dependência um repositorio (clienteRepository)
          // e _mediator responsavel por lançar mensagens, eventos

        public IEnumerable<Cliente> ObterTodosAtivos()
        {
            return _clienteRepository.ObterTodos().Where(c => c.Ativo); // seleciona apenas clientes ativos
        }

        public void Adicionar(Cliente cliente)// adiciona um cliente e lança um evento de mensagem
        {
            if (!cliente.EhValido())
                return;

            _clienteRepository.Adicionar(cliente);
            _mediator.Publish(new ClienteEmailNotification("admin@me.com", cliente.Email, "Olá", "Bem vindo!"));
        }

        public void Atualizar(Cliente cliente)
        {
            if (!cliente.EhValido())
                return;

            _clienteRepository.Atualizar(cliente);
            _mediator.Publish(new ClienteEmailNotification("admin@me.com", cliente.Email, "Mudanças", "Dê uma olhada!"));
        }

        public void Inativar(Cliente cliente)
        {
            if (!cliente.EhValido())
                return;

            cliente.Inativar();
            _clienteRepository.Atualizar(cliente);
            _mediator.Publish(new ClienteEmailNotification("admin@me.com", cliente.Email, "Até breve", "Até mais tarde!"));
        }

        public void Remover(Cliente cliente)
        {
            _clienteRepository.Remover(cliente.Id);
            _mediator.Publish(new ClienteEmailNotification("admin@me.com", cliente.Email, "Adeus", "Tenha uma boa jornada!"));
        }

        public void Dispose()
        {
            _clienteRepository?.Dispose();
        }

    }
}
