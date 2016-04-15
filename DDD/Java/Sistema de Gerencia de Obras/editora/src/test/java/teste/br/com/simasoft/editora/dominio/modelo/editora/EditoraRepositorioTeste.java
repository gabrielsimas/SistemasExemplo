package teste.br.com.simasoft.editora.dominio.modelo.editora;

import br.com.simasoft.editora.dominio.modelo.editora.Editora;
import br.com.simasoft.editora.dominio.modelo.editora.EditoraRepositorio;
import br.com.simasoft.editora.dominio.modelo.valueobjects.Identidade;
import br.com.simasoft.editora.dominio.modelo.valueobjects.Nome;

/**
 * Classe para teste de Reposit�rio 
 * como um Mock, ou seja, sem a persist�ncia
 * Esse teste � para verificar as regras de valida��o do Dom�nio
 * junto com as regras de persist�ncia do Banco de Dados
 * @author Gabriel
 *
 */

public class EditoraRepositorioTeste {

	EditoraRepositorio repositorio;
	
	/**
	 * Salvar uma Editora
	 * @throws Exception 
	 */
	public void criar() throws Exception{
		Nome nome = Nome.of("Apress");		
		repositorio.criar(Editora.of(nome));
	}
	
	public void alterar() throws Exception{
		Identidade id =Identidade.of((long)1);
		Editora nova = Editora.of(id, Nome.of("Apress IT eBooks"));
		Editora antiga = Editora.of(id, Nome.of("Apress"));
		repositorio.atualizar(nova);
	}
	
}
