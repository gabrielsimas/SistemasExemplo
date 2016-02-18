package br.com.simasoft.editora.dominio.entidade;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.SequenceGenerator;
import javax.persistence.Table;

@Entity
@Table(name="livro")
public class Livro implements Serializable {

	private static final long serialVersionUID = 1L;
	
	@Id
	@SequenceGenerator(name="pk_seq_livro",sequenceName="seq_livro",allocationSize=1)
	@GeneratedValue(strategy=GenerationType.SEQUENCE,generator="pk_seq_livro")
	@Column(name="id",unique=true,nullable=false)
	private Long id;
	
	@Column(name="isbn",length=20)
	private String isbn;
	
	@Column(name="titulo",length=100)
	private String titulo;
	
	@Column(name="genero",length=100)
	private String genero;
	
	@Column(name="sinopse",length=200)
	private String sinopse;
	
	@ManyToOne
	@JoinColumn(name="idAutor")
	private Autor autor;
	
	@ManyToOne
	@JoinColumn(name="idEditora")
	private Editora editora;
	
	public Livro() {
		// TODO Auto-generated constructor stub
	}

	public Livro(Long id, String isbn, String titulo, String genero, String sinopse, Autor autor, Editora editora) {
		this.id = id;
		this.isbn = isbn;
		this.titulo = titulo;
		this.genero = genero;
		this.sinopse = sinopse;
		this.autor = autor;
		this.editora = editora;
	}

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public String getIsbn() {
		return isbn;
	}

	public void setIsbn(String isbn) {
		this.isbn = isbn;
	}

	public String getTitulo() {
		return titulo;
	}

	public void setTitulo(String titulo) {
		this.titulo = titulo;
	}

	public String getGenero() {
		return genero;
	}

	public void setGenero(String genero) {
		this.genero = genero;
	}

	public String getSinopse() {
		return sinopse;
	}

	public void setSinopse(String sinopse) {
		this.sinopse = sinopse;
	}

	public Autor getAutor() {
		return autor;
	}

	public void setAutor(Autor autor) {
		this.autor = autor;
	}

	public Editora getEditora() {
		return editora;
	}

	public void setEditora(Editora editora) {
		this.editora = editora;
	}

	public static long getSerialversionuid() {
		return serialVersionUID;
	}
	
	@Override
	public boolean equals(Object obj) {
		if (obj instanceof Livro){
			Livro livro = (Livro)obj;
			
			if(livro.getId() != null && this.id != null){
				return livro.getId().equals(this.id);						
			}
		}
		return true;
	}
	
	@Override
	public String toString() {
		return "id=" + id + ", isbn=" + isbn + ", titulo=" + titulo + ", genero=" + genero + ", sinopse="
				+ sinopse;
	}

	@Override
	public int hashCode() {
		return this.id != null ? this.id.hashCode() : 0; //assertiva
	}	
	
}
