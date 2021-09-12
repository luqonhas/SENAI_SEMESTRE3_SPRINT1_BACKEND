using CodeTur.Domain;
using CodeTur.Domain.Entidades;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Infra.Data.Contexts
{
    // context
    public class CodeTurContext : DbContext
    {
        // esse método vai ser chamado na startup
        // será passado o argumento options que será definido na startup da API
        public CodeTurContext(DbContextOptions<CodeTurContext> options) : base(options)
        {
            
        }

        // declarar quais são as tabelas que serão criadas (com DbSet)
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pacote> Pacotes { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }

        // modelamos como que as tabelas devem ficar
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ignoramos que a 'alib' de notificações do Flunt seja gerada no BD automaticamente
            // 'alib' = biblioteca
            modelBuilder.Ignore<Notification>();

            #region mapeamento da tabela Usuarios
                // exemplo da alteração de nome de tabela:
                modelBuilder.Entity<Usuario>().ToTable("Usuarios");

                // determinando a chave
                // nesse caso, não será preciso determinar a PK por conta que o nome do atributo já se chama 'Id', então, já entende que é uma PK automaticamente
                modelBuilder.Entity<Usuario>().Property(x => x.Id);

                // adicionando nome
                modelBuilder.Entity<Usuario>().Property(x => x.Nome).HasColumnType("VARCHAR(40)");
                modelBuilder.Entity<Usuario>().Property(x => x.Nome).HasMaxLength(40);

                // adicionando email
                modelBuilder.Entity<Usuario>().Property(x => x.Email).HasColumnType("VARCHAR(60)");
                modelBuilder.Entity<Usuario>().Property(x => x.Email).HasMaxLength(60);
                modelBuilder.Entity<Usuario>().Property(x => x.Email).IsRequired();
                modelBuilder.Entity<Usuario>().HasIndex(x => x.Email).IsUnique();

                // adicionando senha
                modelBuilder.Entity<Usuario>().Property(x => x.Senha).HasColumnType("VARCHAR(60)");
                modelBuilder.Entity<Usuario>().Property(x => x.Senha).HasMaxLength(60);
                modelBuilder.Entity<Usuario>().Property(x => x.Senha).IsRequired();

                // adicionando data
                modelBuilder.Entity<Usuario>().Property(x => x.Data).HasColumnType("DATETIME");
                modelBuilder.Entity<Usuario>().Property(x => x.Data).HasDefaultValueSql("GETDATE()");
            #endregion

            base.OnModelCreating(modelBuilder); 
        }

    }
}
