using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ddd.Dominio.Modelo.Comum.ValueObject
{
    [Serializable]
    public class Estado
    {        
        private readonly String estado;

        private Estado(String estado)
        {
            this.estado = estado;
        }

        public static Estado of(String estado)
        {
            return ValidaEstado(estado) ? new Estado(estado) : null;
        }

        private static Boolean ValidaEstado(String estado)
        {
            if (estado.Length > 2)
            {
                throw new ArgumentException("A sigla de um estado só pode conter duas letras!");
            }

            if(String.IsNullOrEmpty(estado) || String.IsNullOrWhiteSpace(estado))
            {
                throw new ArgumentException("Não é permitido o valor nulo!");
            }

            return true;
        }

        public virtual Estado PegaEstado
        {
            get
            {
                return Estado.of(estado);
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is Estado)
            {
                Estado outro = (Estado)obj;
                return Object.Equals(this.estado, outro.estado);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "estado=" + estado;
        }
    }
}
