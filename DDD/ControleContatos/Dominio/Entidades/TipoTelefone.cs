using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    [Serializable]
    public class TipoTelefone
    {
        #region Atributos

        private Nullable<long> id;
        private String nome;
        private EnumSimNao ativo;

        #endregion

        #region Construtores

        public TipoTelefone()
        {

        }

        public TipoTelefone(Nullable<long> id, String nome, EnumSimNao ativo)
        {
            this.id = id;
            this.nome = nome;
            this.ativo = ativo;
        }

        #endregion

        #region Propriedades

        public virtual Nullable<long> Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        
        public virtual String Nome
        {
            get { return this.nome; }
            set { this.nome = value; }
        }

        public virtual EnumSimNao Ativo
        {
            get { return this.ativo; }
            set { this.ativo = value; }
        }
        #endregion

        #region Sobrescritas de Object

        public override bool Equals(object obj)
        {
            if (obj is TipoTelefone)
            {
                TipoTelefone objeto = (TipoTelefone)obj;

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
