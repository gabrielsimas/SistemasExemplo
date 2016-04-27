using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ddd.Dominio.Modelo.Comum.ValueObject
{
    [Serializable]
    public class Cidade
    {
        private readonly String cidade;

        private Cidade(String cidade)
        {
            this.cidade = cidade;
        }

        public static Cidade of(String cidade)
        {
            ValidaCidade(cidade);
            return new Cidade(cidade);
        }

        public virtual Cidade PegaCidade
        {
            get
            {
                return Cidade.of(this.cidade);
            }
        }

        public static void ValidaCidade(String cidade)
        {
            if(String.IsNullOrEmpty(cidade) || String.IsNullOrWhiteSpace(cidade))
            {
                throw new ArgumentException("Não é permitido valor nulo!");
            }

            if (!Regex.IsMatch(cidade,"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]+$"))
            {
                throw new ArgumentException("Cidade inválida!");
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is Cidade){
                Cidade outra = (Cidade)obj;
                return object.Equals(this.cidade, outra.cidade);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "Cidade=" + cidade;
        }
    }
}
