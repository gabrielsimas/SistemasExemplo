package br.com.simasoft.editora.dominio.modelo.valueobjects;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.Embeddable;

@Embeddable
public class Identidade implements Serializable {
	
	@Column(name="id",unique=true,nullable=false)
	private Long id;
	
	private Identidade(Long id){		
		this.id = id;
	}
	
	public static Identidade of(Long id){
		checkIdValue(id);
		return new Identidade(id);
	}
	
	public static void checkIdValue(Identidade id){
		if (!id.toString().matches("^[1-9]\\d*$")){
			throw new IllegalArgumentException();
		}		
	}
	
	public static void checkIdValue(Long id){
		if (!id.toString().matches("^[1-9]\\d*$")){
			throw new IllegalArgumentException();
		}		
	}

	@Override
	public String toString() {
		return id.toString();
	}
}
