using CodeTur.Shared;
using CodeTur.Shared.Enum;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Domain.Entidades
{
    // comentario domain
    public class Comentario : Base
    {
        public Comentario(string texto, string sentimento, EnStatusComentario status, Guid idUsuario, Guid idPacote)
        {
            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsNotEmpty(texto, "Texto", "Campo 'Texto' não pode ser vazio!")
                .IsNotEmpty(sentimento, "Sentimento", "Campo 'Sentimento' não pode ser vazio!")
                .IsNotNull(status, "Status", "Campo 'Status' não pode ser nulo!")
                .IsNotNull(idUsuario, "IdUsuario", "Campo 'IdUsuario' não pode ser nulo!")
                .IsNotNull(idPacote, "IdPacote", "Campo 'IdPacote' não pode ser nulo!")
            );

            if (IsValid)
            {
                Texto = texto;
                Sentimento = sentimento;
                Status = status;
                IdUsuario = idUsuario;
                IdPacote = idPacote;
            }
        }

        public string Texto { get; private set; }
        public string Sentimento { get; private set; }
        public EnStatusComentario Status { get; private set; }

        // composições com outras classes (as FKs)
        // FK usuario
        public Guid IdUsuario { get; set; }
        public Usuario Usuario { get; set; }

        // FK pacote
        public Guid IdPacote { get; set; }
        public Pacote Pacote { get; set; }
    }
}
