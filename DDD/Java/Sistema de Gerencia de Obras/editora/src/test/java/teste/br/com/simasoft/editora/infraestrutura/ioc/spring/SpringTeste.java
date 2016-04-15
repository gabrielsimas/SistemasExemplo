package teste.br.com.simasoft.editora.infraestrutura.ioc.spring;

import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.core.Logger;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;
import org.springframework.util.Assert;

import br.com.simasoft.editora.dominio.modelo.autor.AutorRepositorio;

@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration(locations={"config/context-infraestrutura.xml"})
public class SpringTeste {

	private Logger logger = (Logger) LogManager.getLogger(SpringTeste.class);
	
	@Autowired
	protected AutorRepositorio autorRepositorio;

	@Test
	public void test() {
		logger.entry();
		Assert.isTrue(true);
	}

}
