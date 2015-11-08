using System;
using System.Collections.Generic;

namespace Dominio.Entidade
{
	public enum Status
	{
		inativo = 0,
		ativo = 1
	}

	[Serializable]
	public class Usuario
	{
		
		#region Atributos

		private Nullable<long> id;
		private string nomeCompleto;
		private string login;
		private string senha;
		private Status status;
		private ICollection<Tarefa> tarefas;

		#endregion

		#region Construtores
		public Usuario()
		{

		}
		#endregion

		#region Propriedades

		public virtual Nullable<long> Id
		{
			get { return this.id; }
			set { this.id = value; }
		}

		public virtual string NomeCompleto
		{
			get { return this.nomeCompleto; }
			set { this.nomeCompleto = value; }
		}

		public virtual string Login
		{
			get { return this.login; }
			set { this.login = value; }
		}

		public virtual string Senha
		{
			get { return this.senha; }
			set { this.senha = value; }
		}

		public virtual Status Status
		{
			get { return this.status; }
			set { this.status = value; }
		}

		public virtual ICollection<Tarefa> Tarefas
		{
			get { return this.tarefas; }
			set { this.tarefas = value; }
		}

		#endregion

		#region Sobrescritas do Papai Object

		public override bool Equals(object objeto)
		{
			if (objeto is Usuario)
			{
				Usuario usuario = (Usuario)objeto;
				if (usuario.Id.HasValue && this.Id.HasValue)
				{
					return usuario.Id.Value.Equals(this.Id.Value);
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
