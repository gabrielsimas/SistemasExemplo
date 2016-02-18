package br.com.simasoft.editora.infraestrutura.persistencia.hibernate.repositorio;

import org.springframework.stereotype.Repository;

import br.com.simasoft.editora.dominio.contrato.LivroRepositorio;
import br.com.simasoft.editora.dominio.entidade.Livro;
import br.com.simasoft.editora.infraestrutura.persistencia.hibernate.comum.HibernateRepositorioGenericoImpl;

@Repository
public class LivroRepositorioImpl extends HibernateRepositorioGenericoImpl<Livro, Long> implements LivroRepositorio {

}
