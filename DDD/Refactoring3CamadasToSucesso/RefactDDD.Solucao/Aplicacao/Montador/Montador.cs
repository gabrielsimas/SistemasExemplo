using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacao.Dto;
using Dominio.Entidade;
using Framework.Utils;

namespace Aplicacao.Montador
{
    public class Montador
    {
        private Montador()
        {

        }

        public static void Monta(TarefaDto origem, Tarefa destino)
        {
            FisiologiaDaClasse.GeraReplica(typeof(TarefaDto), origem, typeof(Tarefa), destino);            
        }

        public static void Monta(Tarefa origem, TarefaDto destino)
        {
            FisiologiaDaClasse.GeraReplica(typeof(Tarefa), origem, typeof(TarefaDto), destino);            
        }
        public static void Monta(UsuarioDto origem, Usuario destino)
        {
            FisiologiaDaClasse.GeraReplica(typeof(UsuarioDto), origem, typeof(Usuario), destino);            
        }

        public static void Monta(Usuario origem, UsuarioDto destino)
        {
            FisiologiaDaClasse.GeraReplica(typeof(Usuario), origem, typeof(UsuarioDto), destino);            
        }

        public static void Monta(ICollection<TarefaDto> origem, ICollection<Tarefa> destino)
        {
            if(destino == null && destino.Count == 0)
            {
                destino = new List<Tarefa>();
            }

            foreach(TarefaDto dto in origem)
            {
                Tarefa linha = new Tarefa();
                Monta(dto, linha);
                destino.Add(linha);
            }
        }

        public static void Monta(ICollection<Tarefa> origem, ICollection<TarefaDto> destino)
        {
            if (destino == null && destino.Count == 0)
            {
                destino = new List<TarefaDto>();
            }

            foreach (Tarefa tarefa in origem)
            {
                TarefaDto linha = new TarefaDto();
                Monta(tarefa, linha);
                destino.Add(linha);
            }
        }
    }
}
