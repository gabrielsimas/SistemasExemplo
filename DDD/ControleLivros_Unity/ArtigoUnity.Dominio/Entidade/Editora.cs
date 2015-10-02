using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtigoUnity.Dominio.Entidade
{
	[Serializable]
	public class Editora
	{
		
		#region Atributos

		private Nullable<long> id;
		private String nome;

		private ICollection<Livro> livros;

		#endregion

		#region Construtores
		public Editora()
		{

		}

		public Editora(Nullable<long> id, String nome)
		{
			this.id = id;
			this.nome = nome;
		}
		#endregion

		#region Propriedades

		public virtual Nullable<long> Id
		{
			get { return this.id; }
			set { this.id = value; }
		}

		public virtual String Nome
		{
			get { return this.nome; }
			set { this.nome = value; }
		}

		public virtual ICollection<Livro> Livros
		{
			get { return this.livros; }
			set { this.livros = value; }
		}

		#endregion

		#region Sobrescritas do Papai Object

		public override bool Equals(object objeto)
		{
			if (objeto is Editora)
			{
				Editora editora = (Editora)objeto;
				if (editora.Id.HasValue && this.Id.HasValue)
				{
					return editora.Id.Value.Equals(this.Id.Value);
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
