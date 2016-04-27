using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ddd.Dominio.Modelo.Comum.ValueObject
{
    [Serializable()]
    public class Cep
    {
        private readonly string cep;

        private Cep(string cep)
        {
            this.cep = cep;
        }

        public static Cep of(string cep)
        {
            ValidaCep(cep);
            return new Cep(cep);
        }

        private static Boolean ValidaCep(String cep)
        {
            String sodigitos = Regex.Replace(cep,"\\D", "");
            if (String.IsNullOrWhiteSpace(sodigitos) || String.IsNullOrEmpty(sodigitos))
            {
                throw new ArgumentException("CEP em formato incorreto!");
            }

            if (!Regex.IsMatch(sodigitos, "\\d{8}"))
            {
                throw new ArgumentException("CEP em formato incorreto!");
            }

            return true;
        }        

        public virtual Cep PegaCep
        {
            get
            {
                return Cep.of(cep);
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is Cep)
            {
                Cep outro = (Cep)obj;
                return object.Equals(this.cep, outro.cep);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "CEP=" + cep;
        }
    }
}
