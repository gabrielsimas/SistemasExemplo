package br.com.simasoft.editora.dominio.modelo.valueobjects;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.Embeddable;

@Embeddable
public class Isbn implements Serializable{
	
	@Column
	private Long isbn;
	
	private Isbn(Long isbn){
		this.isbn = isbn;
	}
	
	public static Isbn of(Long isbn){
		isValid(isbn);
		return new Isbn(isbn);
	}
	
	public static void isValid(Long isbn){
		if (!isbn.toString().matches("\\d{13}")){
			throw new IllegalArgumentException();
		}
	}
	
	public String toString(){
		return isbn.toString();
	}
}
