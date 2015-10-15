using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCAngularJS.Aplicacao.Dto
{
    public class ConsumoDto
    {
        public int Id {get; set;}
        public int Ano {get; set;}
        public int Mes {get; set;}
        public decimal Valor { get; set; }
        public CategoriaDto categoria { get; set; }
        public UnidadeDto unidade { get; set; }
    }
}

