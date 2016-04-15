package br.com.simasoft.editora.dominio.servico.comum;

import java.io.Serializable;
import java.util.List;

public interface ServicoDominioGenerico<E, ID extends Serializable> {
	
	void salvar(E entity) throws Exception;
	void excluir(E entity) throws Exception;
	void alterar(E entity) throws Exception;
	
	List<E> buscarTudo() throws Exception;	
	E buscarPorId(ID chave) throws Exception;	
}
