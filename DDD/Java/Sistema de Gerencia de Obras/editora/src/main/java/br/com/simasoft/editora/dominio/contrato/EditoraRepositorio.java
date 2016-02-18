package br.com.simasoft.editora.dominio.contrato;

import br.com.simasoft.editora.dominio.entidade.Editora;
import br.com.simasoft.editora.infraestrutura.persistencia.hibernate.comum.HibernateRepositorioGenerico;

public interface EditoraRepositorio extends HibernateRepositorioGenerico<Editora, Long> {

}
