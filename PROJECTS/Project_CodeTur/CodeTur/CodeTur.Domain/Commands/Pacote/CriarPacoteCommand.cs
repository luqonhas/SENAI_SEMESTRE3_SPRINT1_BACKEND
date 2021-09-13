using CodeTur.Shared.Commands;
using CodeTur.Shared.Enum;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Domain.Commands.Pacote
{
    // command pacote
    public class CriarPacoteCommand : Notifiable<Notification>, ICommand
    {
        public CriarPacoteCommand()
        {

        }
         
        public CriarPacoteCommand(string titulo, string imagem, string descricao, EnStatusPacote status)
        {
            Titulo = titulo;
            Imagem = imagem;
            Descricao = descricao;
            Status = status;
        }

        public string Titulo { get; set; }
        public string Imagem { get; set; }
        public string Descricao { get; set; }
        public EnStatusPacote Status { get; set; }

        public void Validar()
        {
            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsNotEmpty(Titulo, "Titulo", "Campo 'Titulo' não pode ser vazio!")
                .IsNotEmpty(Imagem, "Imagem", "Campo 'Imagem' não pode ser vazio!")
                .IsNotEmpty(Descricao, "Descricao", "Campo 'Descricao' não pode ser vazio!")
                .IsNotNull(Status, "Status", "Campo 'Status' não pode ser nulo!")
            );
        }
    }
}
