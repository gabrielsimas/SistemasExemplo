using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidade;

namespace Infraestrutura.ORM.EF.Mapeamento.Comum
{
    public class TarefaId: Tarefa
    {
        private Nullable<long> idTarefa;

        public virtual Nullable<long> IdTarefa
        {
            get { return this.idTarefa; }
            set { this.idTarefa = value; }
        }

        public TarefaId()
            :base()
        {

        }

        public override string ToString()
        {
            System.Reflection.PropertyInfo[] propriedades;
            propriedades = GetType().GetProperties(System.Reflection.BindingFlags.Public);
            return propriedades.ToString();
        }

    }
}
