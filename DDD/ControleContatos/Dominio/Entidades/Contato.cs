using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    [Serializable]
    public class Contato
    {
        #region Atributos

        private long id;
        private String nome;
        private String email;
        private EnumSimNao ativo;

        private IList<Telefone> telefones;
        private IList<RedeSocial> redesSociais;

        #endregion

        #region Construtores

        public Contato()
        {
            this.telefones = new List<Telefone>();
            this.redesSociais = new List<RedeSocial>();
        }

        public Contato(long id, String nome, String email, EnumSimNao ativo, IList<Telefone> telefones, IList<RedeSocial> redesSociais)
        {
            this.telefones = new List<Telefone>();
            this.redesSociais = new List<RedeSocial>();
            this.id = id;
            this.nome = nome;
            this.email = email;
            this.ativo = ativo;
            this.telefones = telefones;
            this.redesSociais = redesSociais;
        }

        #endregion

        #region Propriedades

        public virtual long Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        
        public virtual String Nome
        {
            get { return this.nome; }
            set { this.nome = value; }
        }

        public virtual String Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        public virtual EnumSimNao Ativo
        {
            get { return this.ativo; }
            set { this.ativo = value; }
        }

        public virtual IList<Telefone> Telefones
        {
            get { return this.telefones; }
            set { this.telefones = value; }
        }

        public virtual IList<RedeSocial> RedesSociais
        {
            get { return this.redesSociais; }
            set { this.redesSociais = value; }
        }
        #endregion

        #region Sobrescritas

        public override bool Equals(object obj)
        {
            if (obj is Contato)
            {
                Contato objeto = (Contato)obj;

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
            return this.id > 0 ? this.id.GetHashCode() : 0;
        }

        #endregion
    }
}
