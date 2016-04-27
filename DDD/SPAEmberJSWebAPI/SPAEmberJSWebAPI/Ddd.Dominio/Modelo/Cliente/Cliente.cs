using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ddd.Dominio.Modelo.Comum.ValueObject;


namespace Ddd.Dominio.Modelo.Cliente
{
    [Serializable]
    public class Cliente
    {
        #region Atributos
        private Identidade id;
        private Nome nomeCompleto;
        private Endereco endereco;
        private Email email;
        private Cpf cpf;       

        #endregion

        #region Construtores
        public Cliente()
        {

        }
        protected Cliente(Identidade id,Nome nome,Endereco endereco,Email email,Cpf cpf)
        {
            this.id = id;
            this.nomeCompleto = nome;
            this.endereco = endereco;
            this.email = email;
            this.cpf = cpf;
        }

        protected Cliente(Nome nome, Endereco endereco, Email email,Cpf cpf)
        {
            this.nomeCompleto = nome;
            this.endereco = endereco;
            this.email = email;
            this.cpf = cpf;
        }
        #endregion

        #region Builders
        public static Cliente of(Identidade id, Nome nome, Endereco endereco, Email email,Cpf cpf)
        {
            return new Cliente(id, nome, endereco, email,cpf);
        }

        public static Cliente of(Nome nome, Endereco endereco, Email email, Cpf cpf)
        {
            return new Cliente(nome, endereco, email,cpf);
        }
        #endregion

        #region Propriedades

        public virtual Identidade Id
        {
            get
            {
                return Identidade.of(long.Parse(id.ToString()));
            }
        }

        public virtual Cpf Cpf
        {
            get
            {
                return Cpf.of(cpf.ToString());
            }
        }

        public virtual Nome Nome
        {
            get
            {
                return Nome.of(nomeCompleto.ToString());
            }
        }

        public virtual Endereco Endereco
        {
            get
            {
                return Endereco.of();
            }
        }

        public virtual Email Email
        {
            get
            {
                return Email.of(email.ToString());
            }
        }        
        #endregion
        
        #region Overrides

        public override bool Equals(object obj)
        {
            if (obj is Cliente){
                Cliente outro = (Cliente)obj;
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
            return "Id=" + id + ", " + "CPF=" + cpf + ", " + "Nome=" + nomeCompleto + ", " + "Endereço=" + endereco + ", " + "E-mail=" + email;                
        }

        #endregion
    }
}
