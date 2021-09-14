using CodeTur.Domain.Interfaces;
using CodeTur.Domain.Queries.Pacote;
using CodeTur.Shared.Handlers.Contracts;
using CodeTur.Shared.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CodeTur.Domain.Queries.Pacote.ListarPacotesQuery;

namespace CodeTur.Domain.Handlers.Pacotes
{
    // handler do método de listar pacotes 
    public class ListarPacotesHandler : IHandlerQuery<ListarPacotesQuery>
    {
        // injeção de dependência
        private readonly IPacoteRepository _pacoteRepository;

        public ListarPacotesHandler(IPacoteRepository pacoteRepository)
        {
            _pacoteRepository = pacoteRepository;
        }

        public IQueryResult Handler(ListarPacotesQuery query)
        {
            // será listado todos os pacotes
            var pacote = _pacoteRepository.Listar(query.Ativo);

            // limpamos as informações desnecessárias
            var retornoPacotes = pacote.Select(
                x => 
                {
                    return new ListarPacotesResult()
                    {
                        Id = x.Id,
                        Titulo = x.Titulo,
                        Descricao = x.Descricao,
                        Imagem = x.Imagem,
                        Data = x.Data,
                        QuantidadeComentarios = x.Comentarios.Count
                    };
                }
            );

            return new GenericQueryResult(true, "Pacotes encontrados!", retornoPacotes);

        }
    }
}
