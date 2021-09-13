using CodeTur.Domain.Commands.Pacote;
using CodeTur.Domain.Entidades;
using CodeTur.Domain.Interfaces;
using CodeTur.Domain.Repositories;
using CodeTur.Shared.Commands;
using CodeTur.Shared.Handlers.Contracts;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Domain.Handlers.Pacotes
{
    // handler de criar pacote
    public class CriarPacoteHandler : Notifiable<Notification>, IHandler<CriarPacoteCommand>
    {
        private readonly IPacoteRepository _pacoteRepository;

        public CriarPacoteHandler(IPacoteRepository pacoteRepository)
        {
            _pacoteRepository = pacoteRepository;
        }

        public ICommandResult Handler(CriarPacoteCommand command)
        {
            // verificar se o command é válido
            command.Validar();
            if (!command.IsValid)
            {
                return new GenericCommandResult(false, "Dados incorretos do pacote!", command.Notifications);
            }

            // verificar se já existe um pacote com o mesmo título
            var pacoteExiste = _pacoteRepository.BuscarPorTitulo(command.Titulo);
            if (pacoteExiste != null)
            {
                return new GenericCommandResult(false, "Pacote já cadastrado!", command.Notifications);
            }

            // criar uma instância do Pacote
            Pacote pacote = new Pacote(command.Titulo, command.Imagem, command.Descricao, command.Status);
            if (!pacote.IsValid)
            {
                return new GenericCommandResult(false, "Dados inválidos do pacote!", pacote.Notifications);
            }

            // adicionar pacote no BD
            _pacoteRepository.Cadastrar(pacote);

            // adicionar retornar sucesso
            return new GenericCommandResult(true, "Pacote cadastrado com sucesso!", null);
        }

    }
}
