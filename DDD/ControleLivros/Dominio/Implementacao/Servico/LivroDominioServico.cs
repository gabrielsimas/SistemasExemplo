using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Framework.Arquitetura.DDD.Dominio.Implementacao.ServicosDeDominio.EF;

namespace Dominio.Implementacao.Servico
{
    public class LivroDominioServico: ServicoDeDominioBase<Livro>, ILivroRepositorio
    {
        #region Atributos
        private ILivroRepositorio livroRepositorio;
        #endregion

        #region Construtores
        public LivroDominioServico(ILivroRepositorio livroRepositorio)
            :base(livroRepositorio)
        {
            this.livroRepositorio = livroRepositorio;
        }
        #endregion

        #region Métodos de Serviço de Domínio

        #endregion
    }
}
