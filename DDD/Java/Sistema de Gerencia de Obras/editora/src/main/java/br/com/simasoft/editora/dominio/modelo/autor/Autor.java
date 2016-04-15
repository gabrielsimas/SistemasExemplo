package br.com.simasoft.editora.dominio.modelo.autor;

import static com.google.common.base.Preconditions.checkArgument;
import static com.google.common.base.Preconditions.checkNotNull;

import java.io.Serializable;
import java.util.List;
import java.util.Objects;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.OneToMany;
import javax.persistence.SequenceGenerator;
import javax.persistence.Table;

import com.google.common.base.Strings;
import com.google.common.collect.ImmutableList;
import com.google.common.collect.Lists;

import br.com.simasoft.editora.dominio.modelo.livro.Livro;
import br.com.simasoft.editora.dominio.modelo.valueobjects.Identidade;
import br.com.simasoft.editora.dominio.modelo.valueobjects.Nome;

@Entity
@Table(name="autor")
public class Autor implements Serializable {

	//Atributos
	private static final long serialVersionUID = 1L;
	
	@Id
	@SequenceGenerator(name="pk_seq_autor",sequenceName="seq_autor",allocationSize=1)
	@GeneratedValue(strategy=GenerationType.SEQUENCE,generator="pk_seq_autor")	
	private Identidade id;
	
	@Column(name="nome",length=100)
	private Nome nome;
	
	@OneToMany(mappedBy="autor")
	private List<Livro> livros = Lists.newLinkedList();
	
	//Construtores
	
	/**
	 * Oferenda pro Hibernate
	 */
	Autor() {
		
	}
	
	/**
	 * Construtor contendo apenas o nome
	 * @param nome Nome do Autor
	 */
	Autor(Nome nome){
		checkArgument(!Strings.isNullOrEmpty(nome.toString()));
		this.nome = nome;
	}
	
	/**
	 * Construtor contendo o id e o nome
	 * @param id 	Identificação do Autor no Banco de Dados
	 * @param nome	Nome do Autor
	 */
	Autor(Identidade id,Nome nome){
		checkArgument(!Strings.isNullOrEmpty(nome.toString()));
		Identidade.checkIdValue(id);
		this.id = id;
		this.nome = nome;
	}
	
	Autor(Autor autor){
		checkNotNull(autor);
		this.id = autor.id;
		this.nome = autor.nome;
	}
		
	public static Autor of(Autor autor){		
		return new Autor(autor);
	}
	public static Autor of(Identidade id,Nome nome){		
		return new Autor(id,nome);
	}
	
	public static Autor of(Nome nome){		
		return new Autor(nome);
	}
	
	public static Autor of(){
		return new Autor();
	}
	
	public List<Livro> pegaLivrosPublicados(){
		return ImmutableList.copyOf(livros);
	}
		
	public static long getSerialversionuid() {
		return serialVersionUID;
	}
	
	public static Autor atualiza(Autor antigo, Autor novo){
		Autor nova = Autor.of(antigo.id,novo.nome);
		return Autor.of(nova.id,nova.nome);
	}
	
	//Sobrescrita de Object	
	@Override
	public boolean equals(Object obj) {
		if (obj instanceof Autor){
			Autor autor = (Autor)obj;
			
			return Objects.equals(this.id,autor.id);
		}
		return true;
	}

	@Override
	public String toString() {
		return "id=" + id + ", nome=" + nome;
	}
	
	@Override
	public int hashCode() {
		return Objects.hash(this.id);
	}
}
