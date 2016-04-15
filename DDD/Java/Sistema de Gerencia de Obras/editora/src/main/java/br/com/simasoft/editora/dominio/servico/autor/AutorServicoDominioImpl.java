package br.com.simasoft.editora.dominio.servico.autor;

import java.util.List;

import org.springframework.stereotype.Service;

import br.com.simasoft.editora.dominio.modelo.autor.Autor;
import br.com.simasoft.editora.dominio.modelo.autor.AutorRepositorio;

@Service
public class AutorServicoDominioImpl implements AutorServicoDominio {
		
	private final AutorRepositorio autorRepositorio;
		
	public AutorServicoDominioImpl(AutorRepositorio autorRepositorio) {		
		this.autorRepositorio = autorRepositorio;
	}

	public void salvar(Autor entity) throws Exception {		
		this.autorRepositorio.criar(entity);		
	}

	public void excluir(Autor entity) throws Exception {
		this.autorRepositorio.apagar(entity);
	}

	public void alterar(Autor entity) throws Exception {
		this.autorRepositorio.atualizar(entity);
	}

	public List<Autor> buscarTudo() throws Exception {
		return this.autorRepositorio.listarTudo();
	}

	public Autor buscarPorId(Long chave) throws Exception {
		return autorRepositorio.buscar(chave);
	}	
}
