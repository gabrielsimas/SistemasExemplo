﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtigoUnity.Dominio.Entidade
{
	[Serializable]
	public class Editora: EntidadeBase
	{
		
		#region Atributos
		
		private String nome;

		private ICollection<Livro> livros;

		#endregion		

		#region Construtores

		public Editora()
		{

		}

		public Editora(Nullable<long> id, String nome, ICollection<Livro> livros)
		{
			this.Id = id;
			this.nome = nome;
			this.livros = livros;
		}        
		#endregion

		#region Propriedades

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
	
		public override string ToString()
		{
			System.Reflection.PropertyInfo[] propriedades;
			propriedades = GetType().GetProperties(System.Reflection.BindingFlags.Public);
			return propriedades.ToString();
		}

		#endregion  
				
	}
}
