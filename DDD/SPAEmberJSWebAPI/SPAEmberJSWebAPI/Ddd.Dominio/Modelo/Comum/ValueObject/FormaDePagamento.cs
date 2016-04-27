using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ddd.Dominio.Modelo.Comum.ValueObject
{
    public enum FormaDePagamento
    {
        Debito = 0,
        Credito = 1,
        BitCoin = 2,
        NotaDeEmpenho = 3,
        MoedaPopular = 4,
        ECard = 5

    }
}
