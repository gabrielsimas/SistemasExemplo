package br.com.simasoft.editora.dominio.modelo.valueobjects;

import java.io.Serializable;
import java.util.Objects;

import javax.persistence.Column;
import javax.persistence.Embeddable;

import static com.google.common.base.Preconditions.checkNotNull;

@Embeddable
public class DadosDoLivro implements Serializable {
	
	@Column
	private String sinopse;
	
	@Column
	private String titulo;
	
	@Column
	private String genero;
		
	DadosDoLivro(){
		
	}
	
	DadosDoLivro(String sinopse,String titulo, String genero){		
		this.sinopse = sinopse;
		this.titulo = titulo;
		this.genero = genero;
	}
	
	DadosDoLivro(DadosDoLivro dados){
		checkNotNull(dados);
		this.sinopse = dados.sinopse;
		this.titulo = dados.titulo;
		this.sinopse = dados.sinopse;
	}
	
	public static DadosDoLivro of(){
		return new DadosDoLivro();
	}
	
	public static DadosDoLivro of(String sinopse,String titulo, String genero){
		return new DadosDoLivro(sinopse,titulo,genero);
	}
	
	public static DadosDoLivro of(DadosDoLivro dados){
		return new DadosDoLivro(dados);
	}
	
	@Override
	public boolean equals(Object obj) {
		if (obj instanceof DadosDoLivro){
			DadosDoLivro dados = (DadosDoLivro)obj;
			
			return Objects.equals(this.toString(),dados.toString());
		}
		
		return false;
	}
	
	@Override
	public String toString() {
		return "sinopse=" + sinopse + ", titulo=" + titulo + ", genero=" + genero;
	}

	@Override
	public int hashCode() {
		return Objects.hash(this.toString());
	}
}
