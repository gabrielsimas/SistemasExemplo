using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
	/// <summary>
	/// Entidade Livro
	/// </summary>
	public class Livro
	{				
		#region Construtores
		public Livro()
		{

		}		
		#endregion

		#region Propriedades

		public virtual Nullable<long> Id {get; set;}
		public virtual String Isbn {get; set;}
		public virtual String Titulo {get; set;}
		public virtual String Genero { get; set; }
		public virtual String Sinopse { get; set; }
		public virtual Nullable<long> IdEditora { get; set; }
		public virtual Nullable<long> Idutor { get; set; }

		public virtual Autor Autor { get; set; }
		public virtual Editora Editora { get; set; }

		#endregion

		#region Sobrescritas do Papai Object

		public override bool Equals(object objeto)
		{
			if (objeto is Livro)
			{
				Livro livro = (Livro)objeto;
				if (livro.Id.HasValue && this.Id.HasValue)
				{
					return livro.Id.Value.Equals(this.Id.Value);
				}
			}

			return false;
		}

		public override int GetHashCode()
		{
			return this.Id.HasValue ? this.Id.Value.GetHashCode() : 0;
		}

		public override string ToString()
		{
			System.Reflection.PropertyInfo[] propriedades;
			propriedades = GetType().GetProperties(System.Reflection.BindingFlags.Public);
			return propriedades.ToString();
		}

		#endregion  
				
	}
}
