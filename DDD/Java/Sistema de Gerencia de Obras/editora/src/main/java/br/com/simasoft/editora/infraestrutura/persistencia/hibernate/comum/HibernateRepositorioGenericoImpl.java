package br.com.simasoft.editora.infraestrutura.persistencia.hibernate.comum;

import java.io.Serializable;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.Transactional;

import br.com.simasoft.editora.infraestrutura.persistencia.hibernate.comum.interfaces.HibernateRepositorioGenerico;

/**
 * Classe genérica concreta para Repositório do Hibernate
 * @author 	Gabriel
 * @param 	<E> O tipo da Entidade
 * @param 	<ID> O tipo do Id da entidade
 */
public class HibernateRepositorioGenericoImpl<E,ID extends Serializable> extends HibernateRepositorio implements HibernateRepositorioGenerico<E,ID> {
		
	private E entidade;
				
	public HibernateRepositorioGenericoImpl() {		
		
	}
		
	@Transactional
	public void criar(E entidade) throws Exception {
		
		pegaSessao().save(entidade);
	}
	
	@Transactional
	public void apagar(E entidade) throws Exception {
		pegaSessao().delete(entidade);
	}

	@Transactional
	public void atualizar(E entidade) throws Exception {
		pegaSessao().update(entidade);		
	}

	@Transactional
	public List<E> listarTudo() throws Exception {
		
		return (List<E>) pegaSessao().createCriteria((Class) entidade).list();
	}

	@Transactional
	public E buscar(ID chave) throws Exception {		
		return (E) pegaSessao().load((Class)entidade, chave);
	}

	public E getEntidade() {
		return entidade;
	}

	public void setEntidade(E entidade) {
		this.entidade = entidade;
	}
}
