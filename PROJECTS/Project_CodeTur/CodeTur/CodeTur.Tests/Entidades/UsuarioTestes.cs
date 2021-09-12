using CodeTur.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CodeTur.Tests
{
    // teste unitário - instância de uma classe
    public class UsuarioTestes
    {
        // parâmetro 'Fact' determina que é um teste
        [Fact]
        public void DeveRetornarSeUsuarioForValido()
        {
            Usuario usuario = new Usuario("Lucas", "lucas@email.com", "lucas123", Shared.EnTipoUsuario.Administrador);

            // define quais condições devem ser encontradas no processo de testes
            Assert.True(usuario.IsValid, "Usuário validado com sucesso!");
        }

    }
}
