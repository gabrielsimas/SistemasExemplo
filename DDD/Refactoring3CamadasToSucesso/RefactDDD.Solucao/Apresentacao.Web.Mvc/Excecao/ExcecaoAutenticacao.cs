using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apresentacao.Web.Mvc.Excecao
{
	public class ExcecaoAutenticacao: Exception    
	{
		public ExcecaoAutenticacao()
			:base()
		{

		}

		public ExcecaoAutenticacao(String mensagem)
			:base(mensagem)
		{

		}
	}
}