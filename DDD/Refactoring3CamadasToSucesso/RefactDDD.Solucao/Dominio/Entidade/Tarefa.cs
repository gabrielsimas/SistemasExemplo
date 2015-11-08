using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidade
{
	public enum EstadoTarefa
	{
		EmAberto = 0,
		Executada = 1
	}

	[Serializable]
	public class Tarefa
	{
		
		#region Atributos

		private Nullable<long> id;
		private string nome;
		private Nullable<DateTime> dataDaEntrega;
		private string descricao;
		private EstadoTarefa estado;
		private Nullable<long> idUsuario;
		private Usuario usuario;      


		#endregion

		#region Construtores
		public Tarefa()
		{

		}

		public Tarefa(Nullable<long> id, string nome, Nullable<DateTime> dataDaEntrega, string descricao, EstadoTarefa estado,Usuario usuario,Nullable<long> idUsuario)
		{
			this.id = id;
			this.nome = nome;
			this.dataDaEntrega = dataDaEntrega;
			this.descricao = descricao;
			this.estado = estado;
			this.usuario = usuario;
            this.idUsuario = idUsuario;
		}
		#endregion

		#region Propriedades

		public virtual Nullable<long> Id
		{
			get { return this.id; }
			set { this.id = value; }
		}

		public virtual string Nome
		{
			get { return this.nome; }
			set { this.nome = value; }
		}

		public virtual Nullable<DateTime> DataDaEntrega
		{
			get { return this.dataDaEntrega; }
			set { this.dataDaEntrega = value; }
		}

		public virtual string Descricao
		{
			get { return this.descricao; }
			set { this.descricao = value; }
		}

		public virtual EstadoTarefa Estado
		{
			get { return this.estado; }
			set { this.estado = value; }
		}
		
		public Nullable<long> IdUsuario
		{
			get { return this.idUsuario; }
			set { this.idUsuario = value; }
		}        

		public virtual Usuario Usuario
		{
			get { return this.usuario; }
			set { this.usuario = value; }
		}

		#endregion

		#region Sobrescritas do Papai Object

		public override bool Equals(object objeto)
		{
			if (objeto is Tarefa)
			{
				Tarefa tarefa = (Tarefa)objeto;
				if (tarefa.Id.HasValue && this.Id.HasValue)
				{
					return tarefa.Id.Value.Equals(this.Id.Value);
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
