using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apresentacao.Mvc5.Excecao
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