package teste.br.com.simasoft.editora.dominio.modelo.editora;

import org.junit.Test;
import org.springframework.util.Assert;

public class TipoIdTeste {
	
	@Test
	public void validaIdCorreto(){
		Boolean resultado = false;
		Long id =(long) 1;			
		
		resultado = id.toString().matches("^[1-9]\\d*$");
		
		Assert.isTrue(resultado);
		
	}
	
	@Test
	public void validaIdErrado(){
		Boolean resultado = false;
		Long id =(long) 0;			
		
		resultado = id.toString().matches("^[1-9]\\d*$");
		
		Assert.isTrue(!resultado);
		
	}
	
	@Test
	public void validaIdCorretoMilhao(){
		Boolean resultado = false;
		Long id =(long) 1000000;			
		
		resultado = id.toString().matches("^[1-9]\\d*$");
		
		Assert.isTrue(resultado);
		
	}
	
	@Test
	public void validaIdCorretoMaximoLong(){
		Boolean resultado = false;
		Long id =Long.MAX_VALUE;			
		
		resultado = id.toString().matches("^[1-9]\\d*$");
		
		Assert.isTrue(resultado);
		
	}
}
