﻿using CodeTur.Shared;
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
    // pacote damain
    public class Pacote : Base
    {
        public Pacote(string titulo, string imagem, string descricao, EnStatusPacote status)
        {
            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsNotEmpty(titulo, "Titulo", "Campo 'Titulo' não pode ser vazio!")
                .IsNotEmpty(imagem, "Imagem", "Campo 'Imagem' não pode ser vazio!")
                .IsNotEmpty(descricao, "Descricao", "Campo 'Descricao' não pode ser vazio!")
                .IsNotNull(status, "Status", "Campo 'Status' não pode ser nulo!")
            );

            if (IsValid)
            {
                Titulo = titulo;
                Imagem = imagem;
                Descricao = descricao;
                Status = status;
            }

        }

        public string Titulo { get; private set; }
        public string Imagem { get; private set; }
        public string Descricao { get; private set; }
        public EnStatusPacote Status { get; private set; }

    }
}
