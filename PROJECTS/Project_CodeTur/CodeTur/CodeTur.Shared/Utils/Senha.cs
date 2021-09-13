using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Shared.Utils
{
    // segurança da senha
    // static faz com que não seja preciso instânciar, pois ela fica disponível em uma única instância na aplicação
    public static class Senha
    {
        // todos os atributos da classe static precisam ser static também

        // para criptografar a senha que vier do front-end
        public static string Criptografar(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        // para validar a senha que está no BD com a senha que está no Form
        // retorna se é verdadeiro ou falso
        public static bool ValidarHashes(string senha, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(senha, hash);
        }

    }
}
