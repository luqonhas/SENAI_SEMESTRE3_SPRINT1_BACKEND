using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Shared.Commands
{
    // CQRS
    // para padronizar todos os resultados dentro da API
    public class GenericCommandResult : ICommandResult
    {
        public GenericCommandResult(bool sucesso, string mensagem, object dados)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
            Dados = dados;
        }

        public bool Sucesso { get; set; } // true = mensagem de sucesso || false = mensagem de erro
        public string Mensagem { get; set; } // mensagem para ajudar o front-end (tirando os statuscode para facilitar o front)
        public Object Dados { get; set; } // retornar um Usuario por exemplo
    }
}
