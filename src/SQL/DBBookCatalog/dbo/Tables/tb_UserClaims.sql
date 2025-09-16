/* 
=================================================================================================================
Tabela: UserClaims (nome da tabela e colunas traduzidas para o inglês)
Informações: Claims do Usuário
Campo	               Tipo	                 Descrição
Coluna Id	           INT	                 Identificador único
Coluna UserId	       VARCHAR	             Identificador do usuário
Coluna ClaimType	   VARCHAR               Nome da empresa
Coluna ClaimValue	   VARCHAR               Nome da empresa
=================================================================================================================
*/
CREATE TABLE [dbo].[tb_UserClaims]
(
	[Id]           INT IDENTITY (1, 1) NOT NULL,
    [UserId]       VARCHAR (450) NOT NULL,
    [ClaimType]    VARCHAR (1000) NULL,
    [ClaimValue]   VARCHAR (1000) NULL,
    CONSTRAINT [PK_tb_UserClaims] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserClaims_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[tb_Users] ([Id])
)
