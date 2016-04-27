using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ddd.Dominio.Modelo.Comum.ValueObject
{
    [Serializable]
    public class Endereco
    {
        #region Atributos
        Logradouro logradouro;
        Cep cep;
        Cidade cidade;
        Estado estado;
        #endregion

        #region Construtores

        private Endereco()
        {

        }

        private Endereco(Logradouro logradouro, Cep cep, Cidade cidade, Estado estado)
        {
            this.logradouro = logradouro;
            this.cep = cep;
            this.cidade = cidade;
            this.estado = estado;
        }

        public static Endereco of(Logradouro logradouro, Cep cep, Cidade cidade, Estado estado)
        {
            return new Endereco(logradouro, cep, cidade, estado);
        }

        public static Endereco of()
        {
            return new Endereco();
        }
        #endregion

        #region Propriedades
        public Logradouro Logradouro 
        {
            get {
                return Logradouro.of(logradouro.ToString());
            }

        }

        public Cep Cep
        {
            get {
                return Cep.of(Cep.ToString());
            }
        }
        
        public Cidade Cidade{
            get {
                return Cidade.of(cidade.ToString());
            }
        }
        
        public Estado Estado
        {
            get
            {
                return Estado.of(estado.ToString());
            }
        }
        #endregion
        #region Overrides
        public override bool Equals(object obj)
        {
            if (obj is Endereco){
                Endereco outro = (Endereco)obj;
                return object.Equals(this.ToString(), obj.ToString());
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "Logradouro=" + logradouro + ", CEP=" +cep +", Cidade=" + cidade + ", Estado=" + estado;
        }
        #endregion
    }
}
 