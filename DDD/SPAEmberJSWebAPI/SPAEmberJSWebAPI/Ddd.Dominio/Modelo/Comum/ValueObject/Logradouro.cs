using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ddd.Dominio.Modelo.Comum.ValueObject
{
    [Serializable]
    public class Logradouro
    {
        private readonly String logradouro;

        private Logradouro(String logradouro)
        {
            this.logradouro = logradouro;
        }

        public static Logradouro of(String logradouro)
        {
            Checks.checkArgument(!String.IsNullOrEmpty(logradouro));
            return new Logradouro(logradouro);
        }

        public virtual Logradouro PegaLogradouro
        {
            get
            {
                return Logradouro.of(logradouro);
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is Logradouro)
            {
                Logradouro outro = (Logradouro)obj;
                Object.Equals(this.logradouro, outro.logradouro);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "Logradouro=" + logradouro;
        }
    }
}
