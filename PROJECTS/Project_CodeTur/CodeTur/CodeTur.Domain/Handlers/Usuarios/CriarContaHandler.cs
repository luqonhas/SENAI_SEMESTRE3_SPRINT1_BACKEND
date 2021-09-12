using CodeTur.Domain.Commands.Usuario;
using CodeTur.Domain.Repositories;
using CodeTur.Shared.Commands;
using CodeTur.Shared.Handlers.Contracts;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Domain.Handlers.Usuarios
{
    // manipulador - método criar conta
    public class CriarContaHandler : Notifiable<Notification>, IHandler<CriarContaCommand>
    {
        // readonly para ninguém consiga overwrite
        // injeção de dependência 
        private readonly IUsuarioRepository _usuarioRepository;

        // obrigamos que o usuarioRepository seja injetado na classe quando ela for instanciada
        public CriarContaHandler(IUsuarioRepository usuarioRepository)
        {
            // dentro do usuarioRepository será igual ao _usuarioRepository
            _usuarioRepository = usuarioRepository;
        }

        // com esse manipulador conseguimos:
        // verificar se o email existe
        // criptografar a senha antes de mandar para o BD
        // salvar no BD utilizando repository.Adicionar(usuario)
        // enviar um email de boas vindas
        public ICommandResult Handler(CriarContaCommand command)
        {
            // validar o command:
            command.Validar();

            // caso o command seja diferente de IsValid
            if (!command.IsValid)
            {
                // retorna uma mensagem de erro
                return new GenericCommandResult(false, "Informe corretamente os dados de usuário!", command.Notifications);
            }

            // verificar se o email existe:
            var usuarioExiste = _usuarioRepository.BuscarPorEmail(command.Email);

            if (usuarioExiste != null)
            {
                return new GenericCommandResult(false, "E-mail já cadastrado!", "Informe outro e-mail.");
            }

            // salvar novo usuário no BD:
            Usuario novoUsuario = new Usuario(command.Nome, command.Email, command.Senha, command.TipoUsuario);

            if (!novoUsuario.IsValid)
            {
                return new GenericCommandResult(false, "Dados de usuário inválidos!", novoUsuario.Notifications);
            }

            _usuarioRepository.Adicionar(novoUsuario);

            // enviar e-mail de boas vindas

            return new GenericCommandResult(true, "Usuario criado!", "Token");
        }


    }
}
