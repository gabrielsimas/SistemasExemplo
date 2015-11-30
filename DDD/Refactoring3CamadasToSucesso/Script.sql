CREATE DATABASE SGT
go

use SGT
go

CREATE TABLE [dbo].[TB_USUARIO] (
    [cod_usuario]  BIGINT           IDENTITY (1, 1) NOT NULL,
    [nomecompleto] VARCHAR (100) NULL,
    [login]        VARCHAR (20)  NULL,
    [senha]        VARCHAR (500) NULL,
    [estado]       INT           DEFAULT ((1)) NULL
    )
);

ALTER TABLE TB_USUARIO
ADD CONSTRAINT [PK_USUARIO] PRIMARY KEY CLUSTERED ([cod_usuario] ASC)

CREATE TABLE [dbo].[TB_TAREFA] (
    [cod_tarefa]  BIGINT           IDENTITY (1, 1) NOT NULL,
    [cod_usuario] BIGINT           NULL,
    [nome]        VARCHAR (100) NULL,
    [dataentrega] DATETIME      NULL,
    [descricao]   VARCHAR (100) NULL,
    [estado]      INT           DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_TAREFA] PRIMARY KEY CLUSTERED ([cod_tarefa] ASC),
    CONSTRAINT [FK_TAREFA_USUARIO] FOREIGN KEY ([cod_usuario]) REFERENCES [dbo].[TB_USUARIO] ([cod_usuario])
);

ALTER TABLE TB_TAREFA
	ADD CONSTRAINT [PK_TAREFA] PRIMARY KEY CLUSTERED ([cod_tarefa] ASC)

ALTER TABLE TB_TAREFA
    ADD CONSTRAINT [FK_TAREFA_USUARIO] FOREIGN KEY ([cod_usuario]) REFERENCES [dbo].[TB_USUARIO] ([cod_usuario])
    
SET IDENTITY_INSERT [dbo].[TB_USUARIO] ON
INSERT INTO [dbo].[TB_USUARIO] ([cod_usuario], [nomecompleto], [login], [senha], [estado]) VALUES (1, N'Gabriel Simas', N'gsimas', N'f3f673349347f0d83fb46f075c88e584', 1)
SET IDENTITY_INSERT [dbo].[TB_USUARIO] OFF

ALTER TABLE TB_TAREFA
	DROP CONSTRAINT [FK_TAREFA_USUARIO]
	
	ALTER TABLE TB_TAREFA
		DROP CONSTRAINT PK_TAREFA

ALTER TABLE TB_USUARIO
 DROP CONSTRAINT [PK_USUARIO]

ALTER TABLE TB_USUARIO
	ALTER COLUMN cod_usuario BIGINT	
	
ALTER TABLE TB_TAREFA
	ALTER COLUMN cod_tarefa BIGINT	

ALTER TABLE TB_TAREFA
	ALTER COLUMN cod_usuario BIGINT	
	
	INSERT INTO TB_USUARIO
		([nomecompleto], [login], [senha], [estado])
	VALUES
	('Livia Helena Barcia Simas','lhelena','jOlLImeT2ebU+Y5BQTXlqFiszBEyiYFYMYRhNnXaOfj6YnKYeBcvdNVO+1KzD0I+Q6pMAopPe89C8EbsjNQP8m8bWO6gyyGWKPCxuKnbvDuHcL5PcNq3SR7TrEE=',1)