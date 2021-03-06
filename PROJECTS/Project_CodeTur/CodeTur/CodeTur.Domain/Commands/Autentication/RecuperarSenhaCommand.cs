using CodeTur.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Domain.Commands.Autentication
{
    // command - tipo uma ViewModel
    // senha - método de recuperar senha
    public class RecuperarSenhaCommand : Notifiable<Notification>, ICommand
    {
        public RecuperarSenhaCommand(string email)
        {
            Email = email;
        }

        public string Email { get; private set; }

        public void Validar()
        {
            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsEmail(Email, "Email", "Formato do campo 'Email' está incorreto!")
            );
        }

    }
}
