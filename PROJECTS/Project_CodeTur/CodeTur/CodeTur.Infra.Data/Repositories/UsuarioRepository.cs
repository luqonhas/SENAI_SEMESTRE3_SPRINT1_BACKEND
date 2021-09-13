using CodeTur.Domain;
using CodeTur.Domain.Repositories;
using CodeTur.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        // injeção de dependência
        private readonly CodeTurContext ctx;

        public UsuarioRepository(CodeTurContext context)
        {
            ctx = context; 
        }

        public void Adicionar(Usuario usuario)
        {
            ctx.Usuarios.Add(usuario);
            ctx.SaveChanges();
        }

        public void Alterar(Usuario usuario)
        {
            ctx.Entry(usuario).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public Usuario BuscarPorEmail(string email)
        {
            return ctx.Usuarios.FirstOrDefault(x => x.Email.ToLower() == email.ToLower());
        }

        public Usuario BuscarPorId(Guid id)
        {
            return ctx.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<Usuario> Listar(bool? ativo = null)
        {
            return ctx.Usuarios
                // não permite que pegue os dados armazenados em cache
                // vai ser pego os dados que são somente leitura, não armazenados em cache do DbContext
                .AsNoTracking()
                .Include(x => x.Comentarios)
                .OrderBy(x => x.Data)
                .ToList();
        }
    }
}
