/* 
=================================================================================================================
Tabela: Genres (tb_Genres)
Descrição: Armazena os gêneros literários disponíveis no sistema.
Campos:
    - Id          (INT)        → Identificador único do gênero (chave primária, identity)
    - Name        (VARCHAR)    → Nome do gênero (ex: Romance, Ficção Científica, Fantasia)
    - Description (VARCHAR)    → Descrição opcional sobre o gênero
    - DateCreate  (DATETIME)   → Data de criação do registro
    - DateChange  (DATETIME)   → Data da última alteração
    - DateDelete  (DATETIME)   → Data de exclusão lógica
    - Status      (BIT)        → Indica se o gênero está Ativo (1) ou Inativo (0)
=================================================================================================================
*/
CREATE TABLE [dbo].[tb_Genres]
(
    [Id]          INT IDENTITY(1,1) NOT NULL,
    [Name]        VARCHAR(255) NOT NULL,
    [Description] VARCHAR(1000) NULL,
    [DateCreate]  DATETIME NOT NULL,
    [DateChange]  DATETIME NULL,
    [DateDelete]  DATETIME NULL,
    [Status]      BIT NOT NULL DEFAULT(1),
    
    CONSTRAINT [PK_TB_Genres] PRIMARY KEY CLUSTERED ([Id] ASC)
) ON [PRIMARY]
GO