using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Domain.Repositories
{
    // interface usuario
    public interface IUsuarioRepository
    {
        void Adicionar(Usuario usuario);
        void Alterar(Usuario usuario);
        Usuario BuscarPorEmail(string email);
        Usuario BuscarPorId(Guid id);

        // bool? ativo = null - retornar somente os usuários ativos || verifica se é vazio no BD
        ICollection<Usuario> Listar(bool? ativo = null);
    }
}
