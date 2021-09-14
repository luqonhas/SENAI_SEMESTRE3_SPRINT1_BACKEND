using CodeTur.Domain.Commands.Pacote;
using CodeTur.Domain.Handlers.Pacotes;
using CodeTur.Domain.Queries.Pacote;
using CodeTur.Shared;
using CodeTur.Shared.Commands;
using CodeTur.Shared.Enum;
using CodeTur.Shared.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CodeTur.Api.Controllers
{
    [Route("v1/package")]
    [ApiController]
    public class PacotesController : ControllerBase
    {
        // diferença do 'command' para 'query':
        // o 'command' vem como argumento
        // a 'query' é instânciada


        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public GenericCommandResult Create(CriarPacoteCommand command, [FromServices] CriarPacoteHandler handler)
        {
            return (GenericCommandResult)handler.Handler(command);
        }

        [Authorize]
        [HttpGet]
        public GenericQueryResult GetAll([FromServices] ListarPacotesHandler handler)
        {
            // criamos uma instância nova da query
            ListarPacotesQuery query = new ListarPacotesQuery();

            // pegamos o tipo de usuário que está nas claims (o id do usuário logado)
            var tipoUsuario = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role);

            // fazemos o comparativo para mostrar somente os ativos para o usuário comum
            // caso o usuário seja diferente de 'Administrador'
            if (tipoUsuario.Value.ToString() != EnTipoUsuario.Administrador.ToString())
            {
                // será listado somente os pacotes ativos
                query.Ativo = EnStatusPacote.Ativo;
            }

            return (GenericQueryResult)handler.Handler(query);

        }

    }
}
