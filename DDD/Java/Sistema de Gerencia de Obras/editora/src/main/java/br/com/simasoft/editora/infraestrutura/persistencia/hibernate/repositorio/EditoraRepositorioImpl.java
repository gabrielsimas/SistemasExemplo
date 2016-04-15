package br.com.simasoft.editora.infraestrutura.persistencia.hibernate.repositorio;

import org.springframework.stereotype.Repository;

import br.com.simasoft.editora.dominio.modelo.editora.Editora;
import br.com.simasoft.editora.dominio.modelo.editora.EditoraRepositorio;
import br.com.simasoft.editora.infraestrutura.persistencia.hibernate.comum.HibernateRepositorioGenericoImpl;

@Repository
public class EditoraRepositorioImpl extends HibernateRepositorioGenericoImpl<Editora, Long> implements EditoraRepositorio {
	
}
