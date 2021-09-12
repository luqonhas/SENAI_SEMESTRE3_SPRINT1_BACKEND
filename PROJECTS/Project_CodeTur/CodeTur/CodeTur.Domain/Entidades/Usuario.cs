using CodeTur.Domain.Entidades;
using CodeTur.Shared;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Domain
{
    // usuario domain
    // adicionar a referência da superclasse Base (projeto Shared ou Comum) nas dependências do projeto Domain
    public class Usuario : Base
    {
        public Usuario(string nome, string email, string senha, EnTipoUsuario tipoUsuario)
        {
            // adiciona uma validação por contrato
            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsNotEmpty(nome, "Nome", "Campo 'Nome' não pode ser vazio!")
                .IsEmail(email, "Email", "Formato do campo 'Email' está incorreto!")
                .IsGreaterThan(senha, 7, "Campo 'Senha' deve ter ao menos 7 caracteres!")
            );

            if (IsValid)
            {
                Nome = nome;
                Email = email;
                Senha = senha;
                TipoUsuario = tipoUsuario;
            }

        }


        // pricípios do SOLID:
        // é necessário garantir (trabalhando com OpenClosePrincipal) que essa classa Usuario esteja aberta para fechada para modificação e aberta para extensão
        // ou seja, somente a própria classe (Usuario nesse caso) pode alterar as suas propriedades
        // exemplo, a classe Produtos consegue ler as informações da classe Usuario, mas não consegue alterá-los
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public EnTipoUsuario TipoUsuario { get; private set; }


        // composições com outras classes (as FKs)
        public IReadOnlyCollection<Comentario> Comentarios { get; private set; }

        // para alterar os comentários, será preciso uma lista de apoio
        private List<Comentario> _comentarios { get; set; }

        // regra de negócio - o usuário pode adicionar somente um comentário por pacote
        public void AdicionarComentario(Comentario comentario)
        {
            if (_comentarios.Any(x => x.IdUsuario == comentario.IdUsuario))
            {
                AddNotification("Comentário", "Este usuário possui comentários!");
            }

            if (IsValid)
            {
                _comentarios.Add(comentario);
            }
        }


        // exemplo que a própria classe pode alterar seus atributos:
        // alteração da senha
        public void AtualizaSenha(string senha)
        {
            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsGreaterThan(senha, 7, "Campo 'Senha' deve ter ao menos 7 caracteres!")
            );

            if (IsValid)
            {
                Senha = senha;
            }
        }

        // alteração do email e da senha
        public void AtualizaUsuario(string nome, string email)
        {
            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsNotEmpty(nome, "Nome", "Campo 'Nome' não pode ser vazio!")
                .IsEmail(email, "Email", "Formato do campo 'Email' está incorreto!")
            );

            if (IsValid)
            {
                Nome = nome;
                Email = email;
            }
        }

    }
}
