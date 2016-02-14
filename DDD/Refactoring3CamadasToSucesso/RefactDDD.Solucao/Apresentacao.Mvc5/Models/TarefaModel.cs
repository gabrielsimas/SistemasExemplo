using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Apresentacao.Mvc5.Models
{    
        public enum EstadoTarefaModel
        {
            EmAberto = 0,
            Executada = 1
        }

        public class TarefaCadastroModel
        {
            [MaxLength(100)]
            [Required(AllowEmptyStrings = true, ErrorMessage = "É necessário que se entre com o nome da tarefa.")]
            public string Nome { get; set; }
           
            [Required(AllowEmptyStrings = true, ErrorMessage = "É necessário que se entre com a data para entrega da tarefa.")]
            public Nullable<DateTime> DataDaEntrega { get; set; }

            [MaxLength(100)]
            [Required(AllowEmptyStrings = true, ErrorMessage = "É necessário que se entre com a descrição da tarefa.")]
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

        public class PainelDeTarefaModel
        {
            public string Nome { get; set; }
            public Nullable<DateTime> DataDaEntrega { get; set; }
            public string Descricao { get; set; }
            public EstadoTarefaModel Estado { get; set; }
            public Nullable<long> IdUsuario { get; set; }
            
            //Serve para criar uma ListaMater e depois fazer o Linq 
            //com as outras tarefas
            public ICollection<TarefaListarModel> TodasAsTarefas;
            public ICollection<TarefaListarModel> TarefasAVencer;
            public ICollection<TarefaListarModel> TarefasExecutadas;
            public ICollection<TarefaListarModel> TarefasVencidas;
        }

    }