using CodeTur.Domain.Commands.Pacote;
using CodeTur.Domain.Handlers.Pacotes;
using CodeTur.Shared.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTur.Api.Controllers
{
    [Route("v1/package")]
    [ApiController]
    public class PacotesController : ControllerBase
    {
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public GenericCommandResult Create(CriarPacoteCommand command, [FromServices] CriarPacoteHandler handler)
        {
            return (GenericCommandResult)handler.Handler(command);
        }

    }
}
