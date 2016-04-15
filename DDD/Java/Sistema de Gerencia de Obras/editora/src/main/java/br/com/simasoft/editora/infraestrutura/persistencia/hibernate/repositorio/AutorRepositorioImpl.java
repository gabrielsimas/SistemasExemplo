package br.com.simasoft.editora.infraestrutura.persistencia.hibernate.repositorio;

import org.springframework.stereotype.Repository;

import br.com.simasoft.editora.dominio.modelo.autor.Autor;
import br.com.simasoft.editora.dominio.modelo.autor.AutorRepositorio;
import br.com.simasoft.editora.infraestrutura.persistencia.hibernate.comum.HibernateRepositorioGenericoImpl;

@Repository
public class AutorRepositorioImpl extends HibernateRepositorioGenericoImpl<Autor, Long> implements AutorRepositorio {
	
}
