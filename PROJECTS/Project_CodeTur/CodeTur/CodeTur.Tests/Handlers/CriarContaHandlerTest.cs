using CodeTur.Domain.Commands.Usuario;
using CodeTur.Domain.Handlers.Usuarios;
using CodeTur.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CodeTur.Tests.Repositories
{
    public class CriarContaHandlerTest
    {
        [Fact]
        public void DeveRetornarCasoDadosDoHandlerSejamValidos()
        {
            // criar command
            var command = new CriarContaCommand();
            command.Nome = "Lucas";
            command.Email = "lucas@email.com";
            command.Senha = "lucas123";
            command.TipoUsuario = Shared.EnTipoUsuario.Administrador;

            // criar manipulador
            var handler = new CriarContaHandler(new FakeUsuarioRepository());

            // pegar o resultado
            var resultado = (GenericCommandResult)handler.Handler(command);

            // validar a condição
            Assert.True(resultado.Sucesso, "Usuário válido!");
        }
    }
}
