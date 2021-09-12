using CodeTur.Shared;
using CodeTur.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Domain.Commands.Usuario
{
    // command - tipo uma ViewModel
    // usuário - método de criar conta
    public class CriarContaCommand : Notifiable<Notification>, ICommand
    {
        public CriarContaCommand()
        {

        }

        public CriarContaCommand(string nome, string email, string senha, EnTipoUsuario tipoUsuario)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            TipoUsuario = tipoUsuario;
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public EnTipoUsuario TipoUsuario { get; set; }

        public void Validar()
        {
            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsNotEmpty(Nome, "Nome", "Campo 'Nome' não pode ser vazio!")
                .IsEmail(Email, "Email", "Formato do campo 'Email' está incorreto!")
                .IsGreaterThan(Senha, 7, "Campo 'Senha' deve ter ao menos 7 caracteres!")
            );
        }

    }
}
