using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ddd.Dominio.Modelo.Comum.ValueObject
{
    [Serializable]
    public class Identidade
    {
        private long id;

        private Identidade(long id)
        {
            this.id = id;
        }

        public static Identidade of(long id)
        {
            checkIdValue(id);
            return new Identidade(id);            
        }

        public static void checkIdValue(Identidade id)
        {            
            String padrao = "^[1-9]\\d*$";

            if (!Regex.IsMatch(id.ToString(),padrao))
            {
                throw new ArgumentException("Fora das limites numéricos!");
            }
        }

        public static void checkIdValue(long id)
        {            
            String padrao = "^[1-9]\\d*$";

            if (!Regex.IsMatch(id.ToString(),padrao))
            {
                throw new ArgumentException("Fora das limites numéricos!");
            }
        }

        public virtual Identidade PegaIdentidade
        {
            get
            {
                return Identidade.of(id);
            }
        }

        public virtual long Id
        {
            get
            {
                return id;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is Identidade){
                Identidade outro = (Identidade)obj;

                return Object.Equals(this.id, outro.id);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "Id=" + id;
        }

    }
}
