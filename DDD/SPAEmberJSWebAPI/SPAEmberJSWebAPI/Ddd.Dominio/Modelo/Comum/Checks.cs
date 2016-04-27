using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ddd.Dominio.Modelo.Comum
{
    public class Checks
    {
        public static void checkArgument(Boolean expressao)
        {
            if (!expressao)
            {
                throw new ArgumentException();
            }
        }

        public static void CheckNotNull(String valor)
        {
            if (String.IsNullOrEmpty(valor) || String.IsNullOrWhiteSpace(valor))
            {
                throw new ArgumentException();
            }
        }
    }
}
