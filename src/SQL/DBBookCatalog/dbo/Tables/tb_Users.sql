/* 
=================================================================================================================
Tabela: Usuários (nome da tabela e colunas traduzidas para o inglês)
Informações: Armazena informações de todos os usuários da plataforma.
Campo	                 Tipo	                   Descrição
Coluna Id	             VARCHAR	               Identificador único
Coluna Nome	             VARCHAR	               Nome completo
Coluna Email	         VARCHAR	               E-mail único
Coluna PasswordHash	     VARCHAR (hash)	           Senha criptografada
Coluna BirthDate	     DATETIME	               Data de nascimento
Coluna DateCreate	     DATETIME	               Data da criação
Coluna DateChange	     DATETIME	               Data de alteração
Coluna DateDelete	     DATETIME	               Data de exclusão
Coluna Status	         BIT	                   Ativo ou Inativo
=================================================================================================================
*/

CREATE TABLE [dbo].[tb_Users]
(
	[Id]            [VARCHAR](450) NOT NULL,
    [UserName]      [VARCHAR](255) NOT NULL,
    [Email]         [VARCHAR](255) UNIQUE NOT NULL,
    [PasswordHash]  [VARCHAR](255) NOT NULL,
	[BirthDate]     [DATETIME] NOT NULL,
    [DateCreate]    [DATETIME] NOT NULL,
	[DateChange]    [DATETIME] NULL,
	[DateDelete]    [DATETIME] NULL,
	[Status]        [BIT] NOT NULL,
 CONSTRAINT [PK_TB_Users] PRIMARY KEY CLUSTERED ([Id] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO