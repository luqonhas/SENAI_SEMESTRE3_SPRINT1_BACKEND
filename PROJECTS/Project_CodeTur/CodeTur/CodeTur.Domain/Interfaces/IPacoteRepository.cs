using CodeTur.Domain.Entidades;
using CodeTur.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Domain.Interfaces
{
    // interface pacote
    public interface IPacoteRepository
    {
        void Cadastrar(Pacote pacote);
        void Alterar(Pacote pacote);
        IEnumerable<Pacote> Listar(EnStatusPacote? ativo = null);
        Pacote BuscarPorTitulo(string titulo);
        Pacote BuscarPorId(Guid id);
    }
}
