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
                .IsNotEmpty(nome, "Nome", "Campo 'nome' não pode ser vazio!")
                .IsEmail(email, "Email", "Formato do campo 'email' está incorreto!")
                .IsGreaterThan(senha, 7, "Campo 'senha' deve ter ao menos 7 caracteres!")
            );

            Nome = nome;
            Email = email;
            Senha = senha;
            TipoUsuario = tipoUsuario;
        }


        // pricípios do SOLID:
        // é necessário garantir (trabalhando com OpenClosePrincipal) que essa classa Usuario esteja aberta para fechada para modificação e aberta para extensão
        // ou seja, somente a própria classe (Usuario nesse caso) pode alterar as suas propriedades
        // exemplo, a classe Produtos consegue ler as informações da classe Usuario, mas não consegue alterá-los
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public EnTipoUsuario TipoUsuario { get; private set; }
    }
}
