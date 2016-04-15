package br.com.simasoft.editora.dominio.modelo.livro;

import static com.google.common.base.Preconditions.checkNotNull;

import java.io.Serializable;
import java.util.Objects;

import javax.persistence.Column;
import javax.persistence.Embedded;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.SequenceGenerator;
import javax.persistence.Table;

import br.com.simasoft.editora.dominio.modelo.autor.Autor;
import br.com.simasoft.editora.dominio.modelo.editora.Editora;
import br.com.simasoft.editora.dominio.modelo.valueobjects.DadosDoLivro;
import br.com.simasoft.editora.dominio.modelo.valueobjects.Identidade;
import br.com.simasoft.editora.dominio.modelo.valueobjects.Isbn;

@Entity
@Table(name="livro")
public class Livro implements Serializable {

	private static final long serialVersionUID = 1L;
	
	@Id
	@SequenceGenerator(name="pk_seq_livro",sequenceName="seq_livro",allocationSize=1)
	@GeneratedValue(strategy=GenerationType.SEQUENCE,generator="pk_seq_livro")	
	private Identidade id;
	
	@Column(name="isbn",length=20)
	private Isbn isbn;
	
	@Embedded
	private DadosDoLivro dados;
	/*
	@Column(name="titulo",length=100)
	private Descricao titulo;
	
	@Column(name="genero",length=100)
	private Descricao genero;
	
	@Column(name="sinopse",length=200)
	private Descricao sinopse;
	*/
	
	@ManyToOne
	@JoinColumn(name="idAutor")
	private Autor autor;
	
	@ManyToOne
	@JoinColumn(name="idEditora")
	private Editora editora;
	
	Livro() {

	}
		
	Livro(Identidade id, Isbn isbn, DadosDoLivro dados, Autor autor, Editora editora) {
		checkNotNull(isbn);
		checkNotNull(dados);
		checkNotNull(autor);
		checkNotNull(editora);
		Identidade.checkIdValue(id);
		
		this.id = id;
		this.isbn = isbn;
		this.dados = dados;
		this.autor = autor;
		this.editora = editora;			
	}
	
	Livro(Livro livro){
		checkNotNull(livro.isbn);
		checkNotNull(dados);
		checkNotNull(livro.autor);
		checkNotNull(livro.editora);
		Identidade.checkIdValue(livro.id);
				
		this.isbn = livro.isbn;
		this.dados = DadosDoLivro.of(dados);				
		this.autor = livro.autor != null ? livro.autor : null;
		this.editora = livro.editora != null ? livro.editora : null;
	}

	public static Livro of(Identidade id, Isbn isbn, DadosDoLivro dados, Autor autor, Editora editora){		
		return new Livro(id,isbn,dados,autor,editora);
	}
	
	public static Livro of(){
		return new Livro();
	}
		
	public static Livro of(Livro livro){
		return new Livro(livro);
	}
	
	public Isbn getIsbn() {
		return isbn;
	}
	
	public DadosDoLivro pegaDadosDoLivro(){
		return DadosDoLivro.of(this.dados);
	}
	
	public Autor getAutor() {		
		return Autor.of(this.autor);
	}

	public Editora getEditora() {
		return Editora.of(this.editora);
	}

	public static long getSerialversionuid() {
		return serialVersionUID;
	}
	
	/**
	 * Adiciona um novo Livro
	 * @param livroNovo Objeto contendo os dados do novo Livro
	 * @param autor Objeto contendo os dados do autor
	 * @param editora Objeto contendo os dados da Editora
	 * @return
	 */
	public static Livro adiciona(Livro livroNovo,Autor autor,Editora editora){
		checkNotNull(livroNovo);
		checkNotNull(autor);
		checkNotNull(editora);
		Livro livro = Livro.of();
		livro.autor = Autor.of(autor);
		livro.editora = Editora.of(editora);
		return Livro.of(livro);
	}
	@Override
	public boolean equals(Object obj) {
		if (obj instanceof Livro){
			Livro livro = (Livro)obj;
			
			return Objects.equals(this.isbn, livro.isbn);
		}
		
		return false;
	}
	
	@Override
	public String toString() {
		return "id=" + id + ", isbn=" + isbn;
	}

	@Override
	public int hashCode() {
		return Objects.hash(this.id);
	}	
}

