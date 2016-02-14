using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apresentacao.Mvc5.Excecao
{
    public class ExcecaoTarefa
        :Exception
    {
        public ExcecaoTarefa()
            :base()
        {

        }

        public ExcecaoTarefa(String mensagem)
            :base(mensagem)
        {

        }
    }
}