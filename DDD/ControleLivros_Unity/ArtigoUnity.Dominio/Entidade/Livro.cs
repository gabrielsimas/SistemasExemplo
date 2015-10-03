using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtigoUnity.Dominio.Entidade
{
	[Serializable]
	public class Livro
	{
		
		#region Atributos

		private Nullable<long> id;
		private String isbn;
		private String titulo;
		private String genero;
		private String sinopse;
		private String autor;


		private Editora editora;

		#endregion

		#region Propriedades

		public virtual Nullable<long> Id
		{
			get { return this.id; }
			set { this.id = value; }
		}

		public virtual String Isbn
		{
			get { return this.isbn; }
			set { this.isbn = value; }
		}

		public virtual String Titulo
		{
			get { return this.titulo; }
			set { this.titulo = value; }
		}

		public virtual String Genero
		{
			get { return this.genero; }
			set { this.genero = value; }
		}

		public virtual String Sinopse
		{
			get { return this.sinopse; }
			set { this.sinopse = value; }
		}

		public virtual String Autor
		{
			get { return this.autor; }
			set { this.autor = value; }
		}

		public virtual Editora Editora
		{
			get { return this.editora; }
			set { this.editora = value; }
		}
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
