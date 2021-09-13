using CodeTur.Domain.Commands.Autentication;
using CodeTur.Domain.Repositories;
using CodeTur.Shared.Commands;
using CodeTur.Shared.Handlers.Contracts;
using CodeTur.Shared.Utils;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Domain.Handlers.Autentication
{
    // método de logar
    public class LogarHandler : Notifiable<Notification>, IHandler<LogarCommand>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LogarHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public ICommandResult Handler(LogarCommand command)
        {
            command.Validar();

            if (!command.IsValid)
            {
                return new GenericCommandResult(false, "Informe corretamente os dados de usuário!", command.Notifications);
            }

            // buscar usuário por email
            var usuario = _usuarioRepository.BuscarPorEmail(command.Email);

            // usuário existe?
            if (usuario == null)
            {
                return new GenericCommandResult(false, "Usuário não encontrado!", null);
            }

            // validar hashes
            if (!Senha.ValidarHashes(command.Senha, usuario.Senha))
            {
                return new GenericCommandResult(false, "Senha inválida!", null);
            }

            return new GenericCommandResult(true, "Logado com sucesso!", usuario);
        }

    }
}
