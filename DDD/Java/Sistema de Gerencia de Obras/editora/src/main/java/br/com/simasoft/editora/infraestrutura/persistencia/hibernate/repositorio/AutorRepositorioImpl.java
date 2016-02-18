package br.com.simasoft.editora.infraestrutura.persistencia.hibernate.repositorio;

import org.springframework.stereotype.Repository;

import br.com.simasoft.editora.dominio.contrato.AutorRepositorio;
import br.com.simasoft.editora.dominio.entidade.Autor;
import br.com.simasoft.editora.infraestrutura.persistencia.hibernate.comum.HibernateRepositorioGenericoImpl;

@Repository("autorRepositorio_")
public class AutorRepositorioImpl extends HibernateRepositorioGenericoImpl<Autor, Long> implements AutorRepositorio {
	
	/*
	private SessionFactory fabricaDeSessao;

	public SessionFactory getFabricaDeSessao() {
		return fabricaDeSessao;
	}

	public void setFabricaDeSessao(SessionFactory fabricaDeSessao) {
		this.fabricaDeSessao = fabricaDeSessao;
	}
	*/
		
}
