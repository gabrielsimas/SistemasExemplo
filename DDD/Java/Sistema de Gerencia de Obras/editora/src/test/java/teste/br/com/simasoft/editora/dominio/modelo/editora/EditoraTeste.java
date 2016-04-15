package teste.br.com.simasoft.editora.dominio.modelo.editora;

import org.junit.Test;
import org.springframework.util.Assert;

import br.com.simasoft.editora.dominio.modelo.editora.Editora;
import br.com.simasoft.editora.dominio.modelo.valueobjects.Identidade;
import br.com.simasoft.editora.dominio.modelo.valueobjects.Nome;

public class EditoraTeste {
	
	//Factory Mehtod
	
	/**
	 * Testa a cria��o de uma Editora sem par�metros atrav�s de Factory Method (FM)
	 */
	@Test
	public void instanciaEditoraVaziaComoFactoryMethod(){
		
		Editora editora = Editora.of();
		
		Assert.isInstanceOf(Editora.class, editora);
	}
	
	/**
	 * Testa a cria��o de uma entidade Editora com os par�metros de Modelo
	 * Ou seja, apenas com o Nome atrav�s de FM
	 */
	@Test
	public void instanciaEditoraComParametrosDeDominioComoFactoryMethod(){		
		Editora editora = Editora.of(Nome.of("Apress"));
		Assert.isInstanceOf(Editora.class, editora);
	}
	
	/**
	 * Testa a cria��o da entidade para persist�ncia contendo o id.
	 */
	@Test
	public void instanciaEditoraComParametrosParaPersistenciaComoFactoryMethod(){
		Nome nome = Nome.of("Apress");		
		Identidade id = Identidade.of((long)1);		
		Editora editora = Editora.of(id,nome);
		
		Assert.isInstanceOf(Editora.class, editora);
	}
		
}
