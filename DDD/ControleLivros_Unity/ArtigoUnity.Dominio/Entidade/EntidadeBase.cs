using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtigoUnity.Dominio.Entidade
{
    public abstract class EntidadeBase
    {
        #region Atributos

        private Nullable<long> id;

        #endregion        

        #region Propriedades
        public virtual Nullable<long> Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        #endregion

        #region Sobrescritas do Papai Object
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is EntidadeBase))
                return false;

            if (Object.ReferenceEquals(this,obj))
                return true;            

            EntidadeBase entidade = (EntidadeBase)obj;

            return true;

        }
        public override int GetHashCode()
        {
            return this.Id.HasValue ? this.Id.Value.GetHashCode() : 0;
        }
        #endregion


    }
}
