using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apresentacao.Web.Mvc.Models
{
    public enum EstadoTarefaModel
    {
        EmAberto = 0,
        Executada = 1
    }

    public class TarefaCadastroModel
    {        
        public string Nome { get; set; }
        public Nullable<DateTime> DataDaEntrega { get; set; }
        public string Descricao { get; set; }
        public EstadoTarefaModel Estado { get; set; }
        public Nullable<long> IdUsuario { get; set; }
    }

    public class TarefaEdicaoModel
    {
        public string Nome { get; set; }
        public Nullable<DateTime> DataDaEntrega { get; set; }
        public string Descricao { get; set; }
        public EstadoTarefaModel Estado { get; set; }
        public Nullable<long> IdUsuario { get; set; }
    }

    public class TarefaExcluirModel
    {
        public Nullable<long> Id { get; set; }
        public string Nome { get; set; }
        public Nullable<DateTime> DataDaEntrega { get; set; }
        public string Descricao { get; set; }
        public EstadoTarefaModel Estado { get; set; }
        public Nullable<long> IdUsuario { get; set; }
    }

    public class TarefaListarModel
    {
        public Nullable<long> Id { get; set; }
        public string Nome { get; set; }
        public Nullable<DateTime> DataDaEntrega { get; set; }
        public string Descricao { get; set; }
        public EstadoTarefaModel Estado { get; set; }
        public Nullable<long> IdUsuario { get; set; }
    }
    
}