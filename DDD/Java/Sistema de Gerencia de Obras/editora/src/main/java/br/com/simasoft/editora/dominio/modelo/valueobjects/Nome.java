package br.com.simasoft.editora.dominio.modelo.valueobjects;

import static com.google.common.base.Preconditions.checkArgument;

import javax.persistence.Column;
import javax.persistence.Embeddable;

import com.google.common.base.Strings;

@Embeddable
public class Nome {
	
	@Column
	private String nome;
	
	Nome(String nome){
		this.nome = nome;
	}
	
	public static Nome of(String nome){
		checkArgument(!Strings.isNullOrEmpty(nome));
		return new Nome(nome);
	}
	
	public Nome pegaNome(){
		return Nome.of(nome);
	}

	@Override
	public String toString() {
		return "nome=" + nome;
	}
	
}
