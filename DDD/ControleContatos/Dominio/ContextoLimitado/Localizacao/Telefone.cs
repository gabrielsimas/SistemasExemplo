using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.ContextoLimitado.Localizacao
{
    [Serializable]
    public class Telefone
    {
        #region Atributos

        private Nullable<long> id;
        private Nullable<long> numero;

        private TipoTelefone tipoTelefone;

        #endregion

        #region Construtores

        public Telefone()
        {
            this.tipoTelefone = new TipoTelefone();
        }

        public Telefone(Nullable<long> id, Nullable<long> numero, TipoTelefone tipoTelefone)
        {
            this.tipoTelefone = new TipoTelefone();

            this.id = id;
            this.numero = numero;
            this.tipoTelefone = tipoTelefone;
        }

        #endregion

        #region Propriedades

        public virtual Nullable<long> Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        
        public virtual Nullable<long> Numero
        {
            get { return this.numero; }
            set { this.numero = value; }
        }

        public virtual TipoTelefone TipoTelefone
        {
            get { return this.tipoTelefone; }
            set { this.tipoTelefone = value; }
        }

        #endregion

        #region Sobrescrita de Object

        public override bool Equals(object obj)
        {
            if (obj is Telefone)
            {
                Telefone objeto = (Telefone)obj;

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
