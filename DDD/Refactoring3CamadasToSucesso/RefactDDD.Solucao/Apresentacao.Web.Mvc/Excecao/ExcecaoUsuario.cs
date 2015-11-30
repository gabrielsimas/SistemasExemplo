using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apresentacao.Web.Mvc.Excecao
{
    public class ExcecaoUsuario
        :Exception
    {
        public ExcecaoUsuario()
            :base()
        {

        }

        public ExcecaoUsuario(String mensagem)
            :base(mensagem)
        {

        }
    }
}