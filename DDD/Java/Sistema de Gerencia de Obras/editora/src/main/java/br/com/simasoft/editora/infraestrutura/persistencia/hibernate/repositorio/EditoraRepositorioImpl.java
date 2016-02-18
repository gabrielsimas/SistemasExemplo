package br.com.simasoft.editora.infraestrutura.persistencia.hibernate.repositorio;

import org.springframework.stereotype.Repository;

import br.com.simasoft.editora.dominio.contrato.EditoraRepositorio;
import br.com.simasoft.editora.dominio.entidade.Editora;
import br.com.simasoft.editora.infraestrutura.persistencia.hibernate.comum.HibernateRepositorioGenericoImpl;

@Repository
public class EditoraRepositorioImpl extends HibernateRepositorioGenericoImpl<Editora, Long> implements EditoraRepositorio {
	
}
