using CodeTur.Shared.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Shared.Handlers.Contracts
{
    public interface IHandlerQuery<T> where T : IQuery
    {
        IQueryResult Handler(T query);
    }
}
