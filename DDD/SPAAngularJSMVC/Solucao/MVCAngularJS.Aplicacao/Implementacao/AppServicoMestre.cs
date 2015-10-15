using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCAngularJS.Aplicacao.Fachada;
using MVCAngularJS.Aplicacao.Implementacao.Montador;
using MVCAngularJS.Dominio.Contrato.Repositorio;
using MVCAngularJS.Dominio.Contrato.Servico;

namespace MVCAngularJS.Aplicacao.Implementacao
{
    public class AppServicoMestre<T,DTO>: IFachadaMestre<DTO>
        where T : class,new()
        where DTO: class,new()
    {
        #region Atributos
        private IServicoMestre<T> dominio;        
        #endregion

        #region Construtores
        public AppServicoMestre(IServicoMestre<T> dominio)
        {
            this.dominio = dominio;            
        }
        #endregion

        #region Métodos de Serviço de Aplicação        

        #endregion

        public void Cadastrar(DTO dto)
        {
            try
            {
                T entidade = new T();
                entidade = Mounter<T, DTO>.MontaDtoParaEntidade(entidade,dto);
                 
                dominio.BeginTransaction();
                dominio.Cadastrar(entidade);                
            }
            catch (Exception)
            {
                
                throw;
            }
            finally
            {
                dominio.Commit();
            }
        }

        public void Alterar(DTO dto)
        {
            try
            {
                T entidade = new T();
                entidade = Mounter<T, DTO>.MontaDtoParaEntidade(entidade, dto);

                dominio.BeginTransaction();
                dominio.Alterar(entidade);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                dominio.Commit();
            }
        }

        public void Excluir(DTO dto)
        {
            try
            {
                T entidade = new T();
                entidade = Mounter<T, DTO>.MontaDtoParaEntidade(entidade, dto);

                dominio.BeginTransaction();
                dominio.Excluir(entidade);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                dominio.Commit();
            }
        }

        public DTO BuscarPorId(int id)
        {
            try
            {
                T entidade = dominio.BuscarPorId(id);

                if (entidade != null)
                {
                    DTO dto = new DTO();
                    dto = Mounter<T, DTO>.MontaEntidadeParaDto(entidade,dto);

                    return dto;
                }
                
            }
            catch (Exception)
            {
                
                throw;
            }

            return null;
        }

        public ICollection<DTO> BuscarTodos()
        {
            try
            {
                ICollection<T> entidades = dominio.BuscarTodos();
               
                if (entidades != null && entidades.Count > 0){
                    ICollection<DTO> dtos = new List<DTO>();

                    foreach (T linha in entidades)
                    {
                        DTO dto = new DTO();
                        dto = Mounter<T, DTO>.MontaEntidadeParaDto(linha, dto);
                        dtos.Add(dto);
                    }

                    return dtos;
                }
            }
            catch (Exception)
            {
                
                throw;
            }

            return null;
        }

        public void BeginTransaction()
        {
            dominio.BeginTransaction();
        }

        public void Commit()
        {
            dominio.Commit();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }
    }
}
