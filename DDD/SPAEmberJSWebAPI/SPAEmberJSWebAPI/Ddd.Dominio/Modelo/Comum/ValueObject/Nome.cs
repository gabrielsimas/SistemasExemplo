using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ddd.Dominio.Modelo.Comum.ValueObject
{
	[Serializable]
	public class Nome
	{
		private String nome;
	
		private Nome(String nome){
			this.nome = nome;
		}
	
		public static Nome of(String nome){
			checkNome(nome);
			return new Nome(nome);
		}
		
		public virtual Nome PegaNome
		{
			get
			{
				return Nome.of(nome);
			}
		}

		public static void checkNome(String nome)
		{
			if (!Regex.IsMatch(nome, "^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ. ]+$"))
			{
				throw new ArgumentException();
			}

			if (String.IsNullOrEmpty(nome)){
				throw new ArgumentNullException();
			}
		}

		public override bool Equals(object obj)
		{
			if (obj is Nome)
			{
				Nome outro = (Nome)obj;
				Object.Equals(this.nome, outro.nome);
			}

			return false;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public override String ToString() {
			return "Nome=" + nome;
		}
   }
}
