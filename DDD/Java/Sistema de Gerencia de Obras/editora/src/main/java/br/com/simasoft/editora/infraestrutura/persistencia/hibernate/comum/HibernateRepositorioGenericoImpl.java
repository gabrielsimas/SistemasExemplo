package br.com.simasoft.editora.infraestrutura.persistencia.hibernate.comum;

import java.io.Serializable;
import java.util.List;

import org.springframework.transaction.annotation.Transactional;

/**
 * Classe genérica concreta para Repositório do Hibernate
 * @author 	Gabriel
 * @since	13/02/2016
 * @param 	<E> O tipo da Entidade
 * @param 	<ID> O tipo do Id da entidade
 */
public class HibernateRepositorioGenericoImpl<E,ID extends Serializable> extends HibernateRepositorio implements HibernateRepositorioGenerico<E,ID> {

	//private Class<E> entidade;
	E entidade;
				
	public HibernateRepositorioGenericoImpl() {		
		
	}
	
	/*
	public HibernateRepositorioGenericoImpl(Class<E> entidade) {		
		this.entidade = entidade;
	}
	*/

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

}
