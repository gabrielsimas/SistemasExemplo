using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCAngularJS.Entidade
{
	public class Consumo
	{
		
		#region Atributos

		private int id;
        private int ano;
        private int mes;
        private decimal valor;

        private Categoria categoria;
        private Unidade unidade;

		#endregion

		#region Construtores
		public Consumo()
		{

		}
		#endregion

		#region Propriedades

		public virtual int Id
		{
			get { return this.id; }
			set { this.id = value; }
		}

        public virtual int Ano
        {
            get {return this.ano;}
            set { this.ano = value; }
        }

        public virtual int Mes
        {
            get { return this.mes; }
            set { this.mes = value; }
        }

        public virtual Decimal Valor
        {
            get { return this.valor; }
            set { this.valor = value; }
        }

        public virtual Categoria Categoria
        {
            get { return this.categoria; }
            set { this.categoria = value; }
        }

        public virtual Unidade Unidade
        {
            get { return this.unidade; }
            set { this.unidade = value; }
        }

		#endregion

		#region Sobrescritas do Papai Object

		public override bool Equals(object objeto)
		{
			if (objeto is Consumo)
			{
				Consumo consumo = (Consumo)objeto;
				if (consumo.Id >= 0 && this.Id>= 0)
				{
					return consumo.Id.Equals(this.Id);
				}
			}

			return false;
		}

		public override int GetHashCode()
		{
			return this.Id >= 0 ? this.Id.GetHashCode() : 0;
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
