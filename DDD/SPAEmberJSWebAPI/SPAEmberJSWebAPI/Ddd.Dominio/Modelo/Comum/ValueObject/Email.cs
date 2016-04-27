using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ddd.Dominio.Modelo.Comum.ValueObject
{
    [Serializable]
    public class Email
    {
        private readonly String email;

        private static readonly String ATOM = "[a-z0-9!#$%&'*+/=?^_`{|}~-]";
        private static readonly String DOMINIO = "(" + ATOM + "+(\\." + ATOM + "+)*";
        private static readonly String IP = "\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\]";
        private static readonly String PadraoRegex = "^" + ATOM + "+(\\." + ATOM + "+)*@" + DOMINIO + "|"
            + IP + ")$";

        private Email(String valor)
        {
            this.email = valor;
        }

        public static Email of(String valor)
        {
            ValidaEmail(valor);
            return new Email(valor);
        }

        private static void ValidaEmail(String valor)
        {
            Checks.CheckNotNull(valor);
            Checks.checkArgument(Regex.IsMatch(valor,PadraoRegex,RegexOptions.IgnoreCase));
        }

        public Email PegaEmail
        {
            get
            {
                return Email.of(email);
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is Email)
            {
                Email outro = (Email)obj;
                return Object.Equals(this.email, outro.email);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "E-mail=" + email;
        }
    }
}
