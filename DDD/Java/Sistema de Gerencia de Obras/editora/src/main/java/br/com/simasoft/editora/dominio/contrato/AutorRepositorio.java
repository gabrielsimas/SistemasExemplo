package br.com.simasoft.editora.dominio.contrato;

import br.com.simasoft.editora.dominio.entidade.Autor;
import br.com.simasoft.editora.infraestrutura.persistencia.hibernate.comum.HibernateRepositorioGenerico;

public interface AutorRepositorio extends HibernateRepositorioGenerico<Autor,Long> {
	
}
