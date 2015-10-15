using Framework.Utils;
using MVCAngularJS.Aplicacao.Dto;
using MVCAngularJS.Entidade;

namespace MVCAngularJS.Aplicacao.Implementacao.Montador
{
    public class Assembler
    {
        private Assembler()
        {

        }

        public static void Monta(UnidadeDto origem, Unidade destino)
        {
            FisiologiaDaClasse.GeraReplica(typeof(UnidadeDto), origem, typeof(Unidade), destino);
        }

        public static void Monta(Unidade origem, UnidadeDto destino)
        {
            FisiologiaDaClasse.GeraReplica(typeof(Unidade), origem, typeof(UnidadeDto), destino);
        }

        public static void Monta(CategoriaDto origem, Categoria destino)
        {
            FisiologiaDaClasse.GeraReplica(typeof(CategoriaDto), origem, typeof(Categoria), destino);
        }

        public static void Monta(Categoria origem, CategoriaDto destino)
        {
            FisiologiaDaClasse.GeraReplica(typeof(Categoria), origem, typeof(CategoriaDto), destino);
        }

        public static void Monta(ConsumoDto origem, Consumo destino)
        {
            FisiologiaDaClasse.GeraReplica(typeof(ConsumoDto), origem, typeof(Consumo), destino);
        }

        public static void Monta(Consumo origem, ConsumoDto destino)
        {
            FisiologiaDaClasse.GeraReplica(typeof(Consumo), origem, typeof(ConsumoDto), destino);
        }
    }
}
