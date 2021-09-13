using CodeTur.Domain;
using CodeTur.Domain.Commands.Autentication;
using CodeTur.Domain.Commands.Usuario;
using CodeTur.Domain.Handlers.Autentication;
using CodeTur.Domain.Handlers.Usuarios;
using CodeTur.Shared.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Api.Controllers
{
    // v1 - versão 1
    // account - ao invés de usar o [controller] onde colocamos o nome da tabela (por exemplo, Usuario), vai ser colocado account pois será uma maneira mais "universal" das pessoas utilizarem nossa API
    [Route("v1/account")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        // determinando a rota
        [Route("signup")]
        [HttpPost]
        // se precisa de um command, precisa de um handler
        public GenericCommandResult SignUp(CriarContaCommand command, [FromServices] CriarContaHandler handler)
        {
            return (GenericCommandResult)handler.Handler(command);
        }

        [Route("signin")]
        [HttpPost]
        public GenericCommandResult SignIn(LogarCommand command, [FromServices] LogarHandler handler)
        {
            // executa o método Handler e armazena o resultado na variável resultado
            var resultado = (GenericCommandResult)handler.Handler(command);

            // verifica se o resultado foi sucesso
            if (resultado.Sucesso)
            {
                // chama o método de gerar token, esse método recebe um usuário, o usuário está no resultado.Dados, e convertemos esse "Dados" para um objeto do tipo usuário
                var token = GenerateJSONWebToken((Usuario)resultado.Dados);

                // retorna o sucesso do resultado, a mensagem e um objeto json com o token
                return new GenericCommandResult(resultado.Sucesso, resultado.Mensagem, new { token = token });
            }

            // se não passar pela condicional
            return new GenericCommandResult(false, resultado.Mensagem, resultado.Dados);
        }



        // poderia colocar esse método do token dentro do handler/utils
        // Criamos nosso método que vai gerar nosso Token
        private string GenerateJSONWebToken(Usuario userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("codetur-chave-autenticacao"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Definimos nossas Claims (dados da sessão) para poderem ser capturadas
            // a qualquer momento enquanto o Token for ativo
            var claims = new[] {
            new Claim(JwtRegisteredClaimNames.FamilyName, userInfo.Nome),
            new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
            new Claim(ClaimTypes.Role, userInfo.TipoUsuario.ToString()),
            new Claim("role", userInfo.TipoUsuario.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, userInfo.Id.ToString())
            };

            // Configuramos nosso Token e seu tempo de vida
            var token = new JwtSecurityToken (
                "codetur",
                "codetur",
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
