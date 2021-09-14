using CodeTur.Shared.Enum;
using CodeTur.Shared.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Domain.Queries.Pacote
{
    // método de listar pacotes
    public class ListarPacotesQuery : IQuery
    {
        public EnStatusPacote? Ativo { get; set; } = null;

        public void Validar()
        {
            // não tem motivo para validar por agora
        }

        // será criado uma classe para pegar o que é fundamental para o usuário
        public class ListarPacotesResult
        {
            public Guid Id { get; set; }
            public string Titulo { get; set; }
            public string Descricao { get; set; }
            public string Imagem { get; set; }
            public DateTime Data { get; set; }

            // mostrar quantidade de comentário do pacote
            public int QuantidadeComentarios { get; set; }
        }

    }
}
