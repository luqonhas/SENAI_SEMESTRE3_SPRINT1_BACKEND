using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Shared.Commands
{
    // CQRS
    // command interface
    public interface ICommand
    {
        // validar tudo que for passado para validar
        void Validar();
    }
}
