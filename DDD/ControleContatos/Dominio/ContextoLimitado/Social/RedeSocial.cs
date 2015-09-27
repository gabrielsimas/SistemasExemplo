using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.ContextoLimitado.Social
{
    [Serializable]
    public class RedeSocial
    {
        #region Atributos

        private Nullable<long> id;
        private String perfil;

        private TipoRedeSocial tipoRedeSocial;

        #endregion

        #region Construtores
        public RedeSocial()
        {
            this.tipoRedeSocial = new TipoRedeSocial();
        }

        public RedeSocial(Nullable<long> id, String perfil, TipoRedeSocial tipoRedeSocial)
        {
            this.tipoRedeSocial = new TipoRedeSocial();

            this.id = id;
            this.perfil = perfil;
            this.tipoRedeSocial = tipoRedeSocial;

        }
        #endregion

        #region Propriedades
        public virtual Nullable<long> Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
       
        public virtual String Perfil
        {
            get { return this.perfil; }
            set { this.perfil = value; }
        }

        public virtual TipoRedeSocial TipoRedeSocial
        {
            get { return this.tipoRedeSocial; }
            set { this.tipoRedeSocial = value; }
        }

        #endregion

        #region Sobrescrita

        public override bool Equals(object obj)
        {
            if (obj is RedeSocial)
            {
                RedeSocial objeto = (RedeSocial)obj;

                if (objeto.Id != null && this.id != null)
                {
                    return objeto.Id.Equals(this.id);
                }
            }

            return false;
        }

        public override string ToString()
        {
            FieldInfo[] atributos;
            atributos = GetType().GetFields(BindingFlags.NonPublic);
            return atributos.ToString();
        }

        public override int GetHashCode()
        {
            return this.id.HasValue ? this.id.GetHashCode() : 0;
        }

        #endregion
    }
}
