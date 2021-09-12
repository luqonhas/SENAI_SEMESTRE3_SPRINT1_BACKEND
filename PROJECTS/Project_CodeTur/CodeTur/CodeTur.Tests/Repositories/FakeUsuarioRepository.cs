using CodeTur.Domain;
using CodeTur.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Tests.Repositories
{
    class FakeUsuarioRepository : IUsuarioRepository
    {
        public void Adicionar(Usuario usuario)
        {
            
        }

        public void Alterar(Usuario usuario)
        {
            
        }

        public void AlterarSenha(Usuario usuario)
        {

        }

        public Usuario BuscarPorEmail(string email)
        {
            return null;
        }

        public Usuario BuscarPorId(Guid id)
        {
            return new Usuario("Lucas", "lucas@email.com", "lucas123", Shared.EnTipoUsuario.Administrador);
        }

        public ICollection<Usuario> Listar(bool? ativo = null)
        {
            return new List<Usuario>()
            {
                new Usuario("Lucas", "lucas@email.com", "lucas123", Shared.EnTipoUsuario.Administrador),
                new Usuario("Lucas2", "lucas2@email.com", "lucas123", Shared.EnTipoUsuario.Comum)
            };
        }
    }
}
