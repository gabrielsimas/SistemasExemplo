using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArtigoUnity.Aplicacao.Servico.Fachada;
using ArtigoUnity.Infraestrutura.DTO;
using ArtigoUnity.Infraestrutura.DTO.Filtro;
using ArtigoUnity.Infraestrutura.DTO.Filtro.Estrategia;
using ArtigoUnity.Web.Mvc.Models;


namespace ArtigoUnity.Web.Mvc.Controllers
{	
	public class LivroController : Controller
	{
		private ILivroAplicServico livroServico;
		private IEditoraAplicServico editoraServico;

        public LivroController(ILivroAplicServico livroServico, IEditoraAplicServico editoraServico)
        {
            this.livroServico = livroServico;
            this.editoraServico = editoraServico;
        }

        public ActionResult Listar()
        {
            ICollection<LivroModelConsulta> dtos = ListarLivros();
            return View("Listar", dtos);
        }

        public ICollection<LivroModelConsulta> ListarLivros()
        {
            ICollection<LivroDto> dtos = livroServico.ListarTodosOsLivros();

            if (dtos != null && dtos.Count > 0)
            {

                ICollection<LivroModelConsulta> livros = new List<LivroModelConsulta>();

                foreach (LivroDto linha in dtos)
                {
                    LivroModelConsulta livro = new LivroModelConsulta()
                    {
                        Id = linha.Id,
                        Autor = linha.Autor,
                        Genero = linha.Genero,
                        Isbn = linha.Isbn,
                        Sinopse = linha.Sinopse,
                        Titulo = linha.Titulo
                    };

                    livros.Add(livro);
                }

                return livros;
            }

            return null;

        }

		public ActionResult Cadastrar()
		{
            LivroModelCadastro cadastro = new LivroModelCadastro();
            return View(cadastro);
		}		

		[HttpPost]
		public ActionResult CadastrarLivro(LivroModelCadastro model)
		{
            try
            {
                LivroDto livro = new LivroDto()
                {
                    Autor = model.Autor,
                    Genero = model.Genero,
                    Isbn = model.Isbn,
                    Sinopse = model.Sinopse,
                    Titulo = model.Titulo
                };

                livroServico.CadastrarLivro(livro, null);

                model = new LivroModelCadastro();

            } catch(Exception ex){
                ViewBag.Mensagem = String.Format("Erro salvando Livro {0}: {1}",model.Titulo, ex.Message);
            }

            return View("Cadastrar",model);
		}		

		public ActionResult FiltrarLivros(LivroModelFiltro model) 
		{
			ICollection<LivroModelConsulta> lista = new List<LivroModelConsulta>();
			ICollection<LivroDto> dtoLista;


			if (ModelState.IsValid){

				FiltroLivroDto filtro = new FiltroLivroDto()
				{
					Autor = model.CampoBusca,
					Genero = model.CampoBusca,
					Isbn = model.CampoBusca,
					Sinopse = model.CampoBusca,
					Titulo = model.CampoBusca,
					Estrategia = (EstrategiaLivroDto)model.Filtro
				};

				try
				{
					dtoLista = livroServico.FiltrarLivroPor(filtro);

					if(dtoLista != null && dtoLista.Count > 0)
					{
						//Assembla o dto na Model
						foreach(LivroDto dto in dtoLista){
							LivroModelConsulta modelo = new LivroModelConsulta()
							{
								Id = dto.Id,
								Autor = dto.Autor,
								Genero = dto.Genero,
								Isbn = dto.Isbn,
								Sinopse = dto.Sinopse,
								Titulo = dto.Titulo                               
							};

							lista.Add(modelo);
						}
					}
				}
				catch (Exception ex)
				{
					
					throw;
				}

			}

			return View("Filtrar",lista);
		}        
	}
}