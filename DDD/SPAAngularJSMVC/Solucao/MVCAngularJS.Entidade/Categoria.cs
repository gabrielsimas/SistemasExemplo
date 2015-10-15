using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCAngularJS.Entidade
{
	public class Categoria
	{
		
		#region Atributos

		private int id;
		private String nome;

		#endregion

		#region Construtores
		public Categoria()
		{

		}
		#endregion

		#region Propriedades
		public virtual int Id
		{
			get { return this.id; }
			set { this.id = value; }
		}
		public virtual String Nome
		{
			get { return this.nome; }
			set { this.nome = value; }
		}

		#endregion

		#region Sobrescritas do Papai Object
		public override bool Equals(object objeto)
		{
			if (objeto is Categoria)
			{
				Categoria categoria = (Categoria)objeto;
				if (categoria.Id > 0 && this.Id > 0)
				{
					return categoria.Id.Equals(this.Id);
				}
			}

			return false;
		}
		public override int GetHashCode()
		{
			return this.Id > 0 ? this.Id.GetHashCode() : 0;
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
