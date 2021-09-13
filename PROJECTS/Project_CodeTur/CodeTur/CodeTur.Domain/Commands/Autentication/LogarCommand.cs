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
    // login - método de login
    public class LogarCommand : Notifiable<Notification>, ICommand
    {
        public LogarCommand(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }

        public string Email { get; set; }
        public string Senha { get; set; }

        public void Validar()
        {
            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsEmail(Email, "Email", "Formato do campo 'Email' está incorreto!")
                .IsGreaterThan(Senha, 7, "Campo 'Senha' deve ter ao menos 7 caracteres!")
            );
        }

    }
}
