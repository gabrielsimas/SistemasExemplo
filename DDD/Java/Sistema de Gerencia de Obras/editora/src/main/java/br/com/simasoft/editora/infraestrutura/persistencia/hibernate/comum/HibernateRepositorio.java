package br.com.simasoft.editora.infraestrutura.persistencia.hibernate.comum;

import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.springframework.beans.factory.annotation.Required;

/**
 * Classe abstrata para todos os Repositórios baseados em Hibernate
 * @author		Gabriel
 * @since		13/02/2016
 * @category	DDD - Infraestrutura - Repositório Abstrato	
 */
public abstract class HibernateRepositorio {
	
	protected SessionFactory fabricaDeSessao;
	
	@Required
	public void setFabricaDeSessao(SessionFactory fabricaDeSessao) {
		this.fabricaDeSessao = fabricaDeSessao;
	}
		
	public SessionFactory getFabricaDeSessao() {
		return fabricaDeSessao;
	}

	protected Session pegaSessao(){
		return fabricaDeSessao.getCurrentSession();
	}
	
}
