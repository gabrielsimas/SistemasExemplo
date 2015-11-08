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
        private Nullable<long> idUsuario;

        public virtual Nullable<long> IdUsuario
        {
            get { return this.idUsuario; }
            set { this.idUsuario = value; }
        }

        public TarefaId(Nullable<long> id, string nome, Nullable<DateTime> dataDaEntrega, string descricao, EstadoTarefa estado, Usuario usuario, Nullable<long> idUsuario)
            :base(id,nome,dataDaEntrega,descricao,estado,usuario,idUsuario)
        {
            this.Id = id;
            this.Nome = nome;
            this.DataDaEntrega = dataDaEntrega;
            this.Descricao = descricao;
            this.Estado = estado;
            this.Usuario = usuario;
            this.idUsuario = idUsuario;
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
