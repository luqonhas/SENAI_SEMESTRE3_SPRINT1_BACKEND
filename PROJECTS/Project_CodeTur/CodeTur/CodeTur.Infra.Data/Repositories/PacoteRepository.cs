using CodeTur.Domain.Entidades;
using CodeTur.Domain.Interfaces;
using CodeTur.Infra.Data.Contexts;
using CodeTur.Shared.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Infra.Data.Repositories
{
    // repository pacote
    public class PacoteRepository : IPacoteRepository
    {
        // injeção de dependência
        private readonly CodeTurContext ctx;

        public PacoteRepository(CodeTurContext context)
        {
            ctx = context;
        }

        public void Alterar(Pacote pacote)
        {
            ctx.Entry(pacote).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public Pacote BuscarPorId(Guid id)
        {
            return ctx.Pacotes.FirstOrDefault(x => x.Id == id);
        }

        public Pacote BuscarPorTitulo(string titulo)
        {
            return ctx.Pacotes.FirstOrDefault(x => x.Titulo.ToLower() == titulo.ToLower());
        }

        public void Cadastrar(Pacote pacote)
        {
            ctx.Pacotes.Add(pacote);
            ctx.SaveChanges();
        }

        public IEnumerable<Pacote> Listar(EnStatusPacote? ativo = null)
        {
            if (ativo == null)
            {
                return ctx.Pacotes
                    .AsNoTracking()
                    .Include(x => x.Comentarios)
                    .OrderBy(x => x.Data);
            }
            else
            {
                return ctx.Pacotes
                    .AsNoTracking()
                    .Include(x => x.Comentarios)
                    .Where(x => x.Status == ativo)
                    .OrderBy(x => x.Data);
            }
        }

    }
}
