package teste.br.com.simasoft.editora.infraestrutura.ioc.spring;

import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;
import org.springframework.util.Assert;

import br.com.simasoft.editora.dominio.modelo.autor.AutorRepositorio;
import br.com.simasoft.editora.dominio.modelo.editora.EditoraRepositorio;
import br.com.simasoft.editora.dominio.modelo.livro.LivroRepositorio;
import br.com.simasoft.editora.dominio.servico.autor.AutorServicoDominio;

/**
 * Classe para Teste de Integração para a camada de infraestrutura
 * @author Gabriel
 *
 */
@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration(locations={"config/context-backbone.xml"})
public class Integracao {

	@Autowired
	protected AutorRepositorio autorRepositorio;
	
	@Autowired
	protected EditoraRepositorio editoraRepositorio;
	
	@Autowired
	protected LivroRepositorio livroRepositorio;
	
	@Autowired
	protected AutorServicoDominio autorServicoDominio;
	
	@Test
	public void testaIntegracao(){		
		Assert.isInstanceOf(AutorRepositorio.class, autorRepositorio,"AutorRepositorio - OK!");
		Assert.isInstanceOf(EditoraRepositorio.class, editoraRepositorio,"EditoraRepositorio - OK!");
		Assert.isInstanceOf(LivroRepositorio.class, livroRepositorio,"LivroRepositorio - OK!");
		Assert.isInstanceOf(AutorServicoDominio.class, autorServicoDominio,"AutorServicoDominio - OK!");
	}
}
