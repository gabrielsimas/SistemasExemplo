using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Utils;

namespace MVCAngularJS.Aplicacao.Implementacao.Montador
{
    public class Mounter<T,DTO>
        where T:class,new()
        where DTO: class,new()
    {        
        private Mounter()
        {

        }

        public static DTO MontaEntidadeParaDto(T entidade, DTO dto){

            if (dto == null) { dto = new DTO(); }

            FisiologiaDaClasse.GeraReplica(typeof(T), entidade, typeof(DTO), dto);
            return dto;
        }

        public static T MontaDtoParaEntidade(T entidade, DTO dto)
        {
            if (entidade == null) { entidade = new T(); }
            FisiologiaDaClasse.GeraReplica(typeof(DTO), dto, typeof(T), entidade);
            return entidade;
        }
    }
}
