package br.com.simasoft.editora.dominio.entidade;

import java.io.Serializable;
import java.util.List;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.OneToMany;
import javax.persistence.SequenceGenerator;
import javax.persistence.Table;

@Entity
@Table(name="editora")
public class Editora implements Serializable {

	
	private static final long serialVersionUID = 1L;
	
	@Id
	@SequenceGenerator(name="pk_seq_editora",sequenceName="seq_editora",allocationSize=1)
	@GeneratedValue(strategy=GenerationType.SEQUENCE,generator="pk_seq_editora")
	@Column(name="id",unique=true,nullable=false)	
	private Long id;
	
	@Column(name="nome",length=100)
	private String nome;
	
	@OneToMany(mappedBy="editora")
	private List<Livro> livros;
	
	public Editora() {
		
	}

	public Editora(Long id, String nome) {
		this.id = id;
		this.nome = nome;
	}

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public String getNome() {
		return nome;
	}

	public void setNome(String nome) {
		this.nome = nome;
	}
		
	public List<Livro> getLivros() {
		return livros;
	}

	public void setLivros(List<Livro> livros) {
		this.livros = livros;
	}

	public static long getSerialversionuid() {
		return serialVersionUID;
	}
	
	@Override
	public boolean equals(Object obj) {
		if (obj instanceof Editora){
			Editora editora = (Editora)obj;
			
			if(editora.getId() != null && this.id != null){
				return editora.getId().equals(this.id);						
			}
		}
		return true;
	}

	@Override
	public String toString() {
		return "id=" + id + ", nome=" + nome;
	}
	
	@Override
	public int hashCode() {
		return this.id != null ? this.id.hashCode() : 0; //assertiva
	}	
}
