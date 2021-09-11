using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Shared
{
    // super classe - vai ser um padrão para as outras classes que usarem ela
    // esse abstract faz com que a classe não possa ser instanciada (Base instancia = new Base()), então, ela só pode ser herdada por outras classes
    public abstract class Base : Notifiable<Notification>
    {
        // esse construtor será rodado quando essa superclasse Base for "chamada" de alguma maneira, mas, na teoria, por conta do 'abstract', essa superclasse não pode ser instanciada diretamente, porém, ela pode ser herdada em outras classes, então, quando instanciarmos uma classe que herda essa superclasse, indiretamente, estaremos instanciando a Base e rodando esse construtor
        public Base()
        {
            Id = Guid.NewGuid();
            Data = DateTime.Now;
        }
        
        // gera um id único (J5B2K-5B2JK-B5K2J-BK634)
        public Guid Id { get; set; }

        public DateTime Data { get; set; }

    }
}
