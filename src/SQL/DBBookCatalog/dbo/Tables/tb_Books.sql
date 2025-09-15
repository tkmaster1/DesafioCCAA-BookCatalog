/* 
=================================================================================================================
Tabela: Books (tb_Books)
Descrição: Armazena informações de livros cadastrados pelos usuários.
Campos:
    - Id             (INT)        → Identificador único do livro (chave primária, identity)
    - Title          (VARCHAR)    → Título do livro
    - ISBN           (VARCHAR)    → Código ISBN do livro
    - Genre          (VARCHAR)    → Gênero literário
    - Author         (VARCHAR)    → Nome do autor
    - Publisher      (VARCHAR)    → Editora
    - Synopsis       (VARCHAR)    → Sinopse ou descrição do livro
    - CoverImagePath (VARCHAR)    → Caminho/URL da imagem de capa
    - UserId         (VARCHAR)    → Referência ao usuário que cadastrou o livro (FK → tb_Users.Id)
    - DateCreate     (DATETIME)   → Data de criação do registro
    - DateChange     (DATETIME)   → Data da última alteração
    - DateDelete     (DATETIME)   → Data de exclusão lógica
    - Status         (BIT)        → Indica se o livro está Ativo (1) ou Inativo (0)
=================================================================================================================
*/

CREATE TABLE [dbo].[tb_Books]
(
	[Id]             [INT] IDENTITY(1,1) NOT NULL,
    [Title]          [VARCHAR](255) NOT NULL,
    [ISBN]           [VARCHAR](255) NOT NULL,
    [Genre]          [VARCHAR](255) NOT NULL,
    [Author]         [VARCHAR](255) NOT NULL,
    [Publisher]      [VARCHAR](255) NOT NULL,
    [Synopsis]       [VARCHAR](5000) NOT NULL,
    [CoverImagePath] [VARCHAR](255) NOT NULL,
    [UserId]         [VARCHAR](450) NOT NULL,	
    [DateCreate]     [DATETIME] NOT NULL,
	[DateChange]     [DATETIME] NULL,
	[DateDelete]     [DATETIME] NULL,
	[Status]         [BIT] NOT NULL,
 CONSTRAINT [PK_TB_Books] PRIMARY KEY CLUSTERED ([Id] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tb_Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[tb_Users] ([Id])
GO

ALTER TABLE [dbo].[tb_Books] CHECK CONSTRAINT [FK_Books_Users_UserId]
GO