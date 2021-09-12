using CodeTur.Domain.Commands.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CodeTur.Tests.Commands
{
    // teste unitário - command criar conta
    public class CriarContaCommandTest
    {
        // parâmetro que determina que é um teste
        [Fact]
        public void DeveRetornarSucessoSeDadosForemValidos()
        {
            var command = new CriarContaCommand();

            command.Nome = "Lucas";
            command.Email = "lucas@email.com";
            command.Senha = "lucas123";
            command.TipoUsuario = Shared.EnTipoUsuario.Administrador;

            command.Validar();

            Assert.True(command.IsValid, "Os dados foram preenchidos corretamente!");
        }

    }
}
