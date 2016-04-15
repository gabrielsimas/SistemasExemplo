package br.com.simasoft.editora.infraestrutura.persistencia.hibernate.comum.interfaces;

import java.io.Serializable;
import java.util.List;

public interface HibernateRepositorioGenerico<E,ID extends Serializable> {
	
	void criar(E entity) throws Exception;
	void apagar(E entity) throws Exception;
	void atualizar(E entity) throws Exception;
	
	List<E> listarTudo() throws Exception;	
	E buscar(ID chave) throws Exception;
	
}
