using CodeTur.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Shared.Handlers.Contracts
{
    // interface Handler genérica
    // os outros Handlers vão herdar dessa interface
    // o <T> define que é genérico
    // <T> where T : ICommand - quer que o tipo genérico <T> herde de ICommand, obrigando que essa interface manipuladora genérica tenha uma herança da interface ICommand
    
    public interface IHandlerCommand<T> where T : ICommand
    {
        // esse método faz com que retorne um valor genérico, então com isso, será possível retornar qualquer coisa nesse método
        // ler mensagens do zap do paulo e do vitor do dia 12/09/21 às 15:10
        ICommandResult Handler(T command);
    }
}
