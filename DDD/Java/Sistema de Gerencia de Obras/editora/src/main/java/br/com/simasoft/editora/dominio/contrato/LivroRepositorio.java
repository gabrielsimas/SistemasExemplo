package br.com.simasoft.editora.dominio.contrato;

import br.com.simasoft.editora.dominio.entidade.Livro;
import br.com.simasoft.editora.infraestrutura.persistencia.hibernate.comum.HibernateRepositorioGenerico;

public interface LivroRepositorio extends HibernateRepositorioGenerico<Livro, Long> {

}
