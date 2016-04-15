package teste.br.com.simasoft.editora.dominio.modelo.editora;

import org.junit.Test;
import org.springframework.util.Assert;

import br.com.simasoft.editora.dominio.modelo.autor.Autor;
import br.com.simasoft.editora.dominio.modelo.valueobjects.Identidade;
import br.com.simasoft.editora.dominio.modelo.valueobjects.Nome;

public class AutorTeste {
		
	//Teste de Instâncias e passagem de Parâmetros
	@Test
	public void TesteInstancia01(){		
		Autor autor = Autor.of();
		Assert.isInstanceOf(Autor.class, autor,"TesteInstancia01: " + autor.toString());					
	}
	
	@Test
	public void TesteInstancia02(){		
		Identidade id = Identidade.of((long) 1);
		Nome nome = Nome.of("Gabriel Simas");  
		Autor autor = Autor.of(id, nome);		
		Assert.isInstanceOf(Autor.class, autor, autor.toString());				
	}	
}
