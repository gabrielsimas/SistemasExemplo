using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DAL.Entidades;
using DAL.Persistencia.DataSource;

namespace DAL.Persistencia
{
    public enum TipoBuscaUsuario
    {
        PorNomeCompleto = 0,
        PorTrechoInicial = 1,
        PorTrechoFinal = 2,
        PorFragmento = 3
    }

    public class UsuarioDao:IDisposable
    {
        #region Atributos

        private ConexaoDeDados conexao;

        #endregion 

        #region Construtores
        public UsuarioDao()
        {

        }

        #endregion

        #region Métodos de Persistência

        public void Gravar(Usuario usuario)
        {
            using(conexao = new ConexaoDeDados())
            {
                try
                {
                    conexao.TbUsuario.Add(usuario);

                    usuario.Senha = GeraHashMd5(usuario.Senha);

                    conexao.SaveChanges();
                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach(var erro in dbEx.EntityValidationErrors){
                        foreach (var linha in erro.ValidationErrors)
                        {
                            linha.ErrorMessage.ToString();
                        }
                    }
                    throw;
                }
            }
        }

        public Usuario BuscarPorId(int id)
        {
            if (id == 0){
                throw new ArgumentNullException("id");
            }
            else if (id < 0)
            {
                throw new ArgumentOutOfRangeException("O id precisa ser maior que zero.");
            }

            using(conexao = new ConexaoDeDados())
            {
                try
                {
                    return this.conexao.TbUsuario.Find(id);
                }
                catch (Exception)
                {                    
                    throw;
                }
            }
        }

        public Usuario BuscarLogin(String login)
        {
            if (String.IsNullOrEmpty(login) || String.IsNullOrWhiteSpace(login))
            {
                throw new ArgumentNullException("login");
            }
            
            using(conexao = new ConexaoDeDados())
            {
                try
                {
                    return this.conexao.TbUsuario.Where(u => u.Login.Equals(login)).SingleOrDefault<Usuario>();
                }
                catch (Exception)
                {
                    
                    throw;
                }
            }
        }
        
        public Usuario BuscarPorNome(String nome, TipoBuscaUsuario chaveBusca)
        {
            if (String.IsNullOrEmpty(nome) || String.IsNullOrWhiteSpace(nome))
            {
                throw new ArgumentNullException("login");
            }

            using(conexao = new ConexaoDeDados())
            {
                try
                {
                    switch (chaveBusca)
                    {
                        case TipoBuscaUsuario.PorNomeCompleto:
                            return conexao.TbUsuario.Where(u => u.NomeCompleto.Equals(nome)).SingleOrDefault<Usuario>();                            
                        case TipoBuscaUsuario.PorTrechoInicial:
                            return conexao.TbUsuario.Where(u => u.NomeCompleto.StartsWith(nome)).SingleOrDefault<Usuario>();
                        case TipoBuscaUsuario.PorTrechoFinal:
                            return conexao.TbUsuario.Where(u => u.NomeCompleto.EndsWith(nome)).SingleOrDefault<Usuario>();
                        case TipoBuscaUsuario.PorFragmento:
                            return conexao.TbUsuario.Where(u => u.NomeCompleto.Contains(nome)).SingleOrDefault<Usuario>();
                        default:
                            return null;
                    }
                }
                catch (Exception)
                {                    
                    throw;
                }
            }
        }
        #endregion

        #region Utilitários

        public string GeraHashMd5(string texto)
        {           
            MD5 hasheadorMd5 = MD5.Create();            

            byte[] dado = hasheadorMd5.ComputeHash(Encoding.Default.GetBytes(texto));
            
            StringBuilder sBuilder = new StringBuilder();
            
            for (int i = 0; i < dado.Length; i++)
            {
                sBuilder.Append(dado[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        #endregion
        public void Dispose()
        {
            if (conexao != null)
            {
                conexao.Dispose();
            }
        }
    }
}
