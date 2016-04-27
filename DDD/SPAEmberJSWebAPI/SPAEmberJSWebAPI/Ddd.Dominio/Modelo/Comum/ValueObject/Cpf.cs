using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ddd.Dominio.Modelo.Comum.ValueObject
{
    [Serializable]
    public class Cpf
    {
        private readonly String cpf;
        private Cpf(String cpf)
        {
            this.cpf = cpf;
        }

        public static Cpf of(String valor)
        {
            Checks.CheckNotNull(valor);
            String digitos = Regex.Replace(valor,"\\D","");
            Checks.checkArgument(Regex.IsMatch(digitos,"\\d{11}"));
            Checks.checkArgument(!Regex.IsMatch(digitos,"(\\d)\\1{3}"));
            Checks.checkArgument(isValid(digitos.Substring(0,10)));
            Checks.checkArgument(isValid(digitos));

            return new Cpf(digitos);
        }

        static bool isValid(String digitos)
        {
            if (long.Parse(digitos) % 10 == 0){
                return calculoPonderado(digitos) % 11 < 2;
            }else{
                return calculoPonderado(digitos) % 11 == 0;
            }
        }

        static int calculoPonderado(String digitos)
        {
            char[] cs = digitos.ToCharArray();
            int soma = 0;
            for(int i = 0; i < cs.Length;i++)
            {                
                soma += Convert.ToInt32(cs[i].ToString(),10) * (cs.Length - i);
            }
            return soma;
        }

        public virtual Cpf PegaCpf
        {
            get
            {
                return Cpf.of(cpf);
            }
        }

        public static Boolean ValidaCpf(String cpf)
        {
                Checks.CheckNotNull(cpf);
                String digitos = Regex.Replace(cpf, "\\D", "");
                Checks.checkArgument(Regex.IsMatch(digitos, "\\d{11}"));
                Checks.checkArgument(!Regex.IsMatch(digitos, "(\\d)\\1{3}"));
                Checks.checkArgument(isValid(digitos.Substring(0, 10)));
                Checks.checkArgument(isValid(digitos));
                return true;                
        }

        public override bool Equals(object obj)
        {
            if (obj is Cpf)
            {
                Cpf outro = (Cpf)obj;
                return Object.Equals(this.cpf, outro.cpf);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "CPF=" + cpf;
        }
    }
}
