using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtigoUnity.Dominio.Entidade;
using ArtigoUnity.Infraestrutura.DTO;
using Framework.Utils;

namespace ArtigoUnity.Aplicacao.Servico.Implementacao.Montador
{
    public class Montador        
    {
        private Montador()
        {
            
        }

        public static void Assemblador(EditoraDto origem,Editora destino)
        {
            FisiologiaDaClasse.GeraReplica(typeof(EditoraDto), origem, typeof(Editora), destino);
        }

        public static void Assemblador(Editora origem, EditoraDto destino)
        {
            FisiologiaDaClasse.GeraReplica(typeof(Editora), origem, typeof(EditoraDto), destino);
        }

        public static void Assemblador(LivroDto origem, Livro destino)
        {
            FisiologiaDaClasse.GeraReplica(typeof(LivroDto), origem, typeof(Livro), destino);
        }

        public static void Assemblador(Livro origem, LivroDto destino)
        {
            FisiologiaDaClasse.GeraReplica(typeof(Livro), origem, typeof(LivroDto), destino);
        }

    }
}
