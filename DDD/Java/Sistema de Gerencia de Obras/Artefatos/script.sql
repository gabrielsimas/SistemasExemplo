CREATE DATABASE editorajava;

/c editorajava;

CREATE TABLE autor
(
	id		INTEGER DEFAULT nextval('seq_autor'),
	nome	VARCHAR(100)
);

CREATE TABLE editora
(
	id		INTEGER DEFAULT nextval('seq_editora'),
	nome	VARCHAR(100)	
);

CREATE TABLE livro
(
	id			INTEGER DEFAULT nextval('seq_livro'),
	isbn		VARCHAR(20),
	titulo		VARCHAR(100),
	genero		VARCHAR(100),
	sinopse		VARCHAR(200),
	idAutor		INTEGER,
	idEditora	INTEGER
);

ALTER TABLE autor ADD CONSTRAINT autor_pk PRIMARY KEY(id);

ALTER TABLE editora ADD CONSTRAINT editora_pk PRIMARY KEY(id);

ALTER TABLE livro ADD CONSTRAINT livro_pk PRIMARY KEY(id);
ALTER TABLE livro ADD CONSTRAINT fk_livro_autor 	FOREIGN KEY(idAutor)	REFERENCES autor(id);
ALTER TABLE livro ADD CONSTRAINT fk_livro_editora	FOREIGN KEY(idEditora)	REFERENCES editora(id);

CREATE USER editoraJava WITH PASSWORD t3st3@,123;

GRANT usage on schema public to editoraJava;

CREATE SEQUENCE public.seq_autor;
ALTER SEQUENCE public.seq_autor
  OWNER TO editorajava;
REVOKE ALL ON SEQUENCE public.seq_autor FROM public;
COMMENT ON SEQUENCE public.seq_autor
  IS 'Sequence da Tabela autor';
  
 CREATE SEQUENCE public.seq_editora;
GRANT ALL ON SEQUENCE public.seq_editora TO public;
COMMENT ON SEQUENCE public.seq_editora
  IS 'Sequence para a tabela editora';

  CREATE SEQUENCE public.seq_livro;
ALTER SEQUENCE public.seq_livro
  OWNER TO editorajava;
REVOKE ALL ON SEQUENCE public.seq_livro FROM public;
COMMENT ON SEQUENCE public.seq_livro
  IS 'Sequence da tabela livro';
