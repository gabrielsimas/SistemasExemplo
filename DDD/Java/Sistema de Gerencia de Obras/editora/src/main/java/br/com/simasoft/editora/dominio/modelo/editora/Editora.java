package br.com.simasoft.editora.dominio.modelo.editora;

import static com.google.common.base.Preconditions.checkArgument;
import static com.google.common.base.Preconditions.checkNotNull;

import java.io.Serializable;
import java.util.List;
import java.util.Objects;

import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.Embedded;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.OneToMany;
import javax.persistence.SequenceGenerator;
import javax.persistence.Table;
import javax.persistence.Version;

import com.google.common.base.Strings;
import com.google.common.collect.ImmutableList;
import com.google.common.collect.Lists;

import br.com.simasoft.editora.dominio.modelo.livro.Livro;
import br.com.simasoft.editora.dominio.modelo.valueobjects.Identidade;
import br.com.simasoft.editora.dominio.modelo.valueobjects.Nome;

@Entity
@Table(name="editora")
public class Editora implements Serializable {
	
	private static final long serialVersionUID = 1L;
	
	@Id
	@SequenceGenerator(name="pk_seq_editora",sequenceName="seq_editora",allocationSize=1)
	@GeneratedValue(strategy=GenerationType.SEQUENCE,generator="pk_seq_editora")
	private Identidade id;
	
	@Embedded
	private Nome nome;
	
	@OneToMany(mappedBy="editora",cascade = CascadeType.ALL)
	private List<Livro> livros = Lists.newLinkedList();
	
	@Version
	Long versao;
	
	//Oferenda para o Hibernate
	Editora() {
		
	}
	
	Editora(Nome nome){
		checkArgument(!Strings.isNullOrEmpty(nome.toString()));
		this.nome = nome;
	}
	
	Editora(Identidade id, Nome nome){
		checkArgument(!Strings.isNullOrEmpty(nome.toString()));
		Identidade.checkIdValue(id);
		this.id = id;	
		this.nome = nome;
	}
	
	Editora(Editora editora){
		checkNotNull(editora);
		this.id = editora.id;
		this.nome = editora.nome;
	}
	
	public static Editora of(){
		return new Editora();
	}
	
	public static Editora of(Nome nome){		
		return new Editora(nome);
	}
	
	public static Editora of(Identidade id,Nome nome){
		return new Editora(id,nome);
	}
		
	public static Editora of(Editora editora){
		return new Editora(editora);
	}
	
	public List<Livro> pegaLivrosPublicados() {
		return ImmutableList.copyOf(livros);	
	}
	
	public static long getSerialversionuid() {
		return serialVersionUID;
	}
	
	public Editora atualiza(Editora antigo,Editora novo){
		Editora antiga = Editora.of(antigo.id, antigo.nome);
		Editora nova = Editora.of(antiga.id,novo.nome);
		
		return Editora.of(nova.id,nova.nome);
	}
	
	//Controle de memória
	@Override
	public boolean equals(Object obj) {
		if (obj instanceof Editora){
			Editora editora = (Editora)obj;
			
			return Objects.equals(this.id, editora.id);
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
