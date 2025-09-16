/* 
=================================================================================================================
Tabela: Publishers (tb_Publishers)
Descrição: Armazena as editoras de livros.
Campos:
    - Id          (INT)        → Identificador único da editora (chave primária, identity)
    - Name        (VARCHAR)    → Nome da editora
    - Description (VARCHAR)    → Informações adicionais sobre a editora (opcional)
    - Website     (VARCHAR)    → Site oficial da editora (opcional)
    - DateCreate  (DATETIME)   → Data de criação do registro
    - DateChange  (DATETIME)   → Data da última alteração
    - DateDelete  (DATETIME)   → Data de exclusão lógica
    - Status      (BIT)        → Indica se a editora está Ativa (1) ou Inativa (0)
=================================================================================================================
*/
CREATE TABLE [dbo].[tb_Publishers]
(
    [Id]          INT IDENTITY(1,1) NOT NULL,
    [Name]        VARCHAR(255) NOT NULL,
    [Description] VARCHAR(1000) NULL,
    [Website]     VARCHAR(500) NULL,
    [DateCreate]  DATETIME NOT NULL,
    [DateChange]  DATETIME NULL,
    [DateDelete]  DATETIME NULL,
    [Status]      BIT NOT NULL DEFAULT(1),

    CONSTRAINT [PK_TB_Publishers] PRIMARY KEY CLUSTERED ([Id] ASC)
) ON [PRIMARY]
GO