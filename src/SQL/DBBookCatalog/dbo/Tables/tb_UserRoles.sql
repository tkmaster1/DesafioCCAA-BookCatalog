/* 
=================================================================================================================
Tabela: UserRoles (nome da tabela e colunas traduzidas para o inglês)
Informações: Roles do Usuário
Campo	               Tipo	                 Descrição
Coluna UserId	       VARCHAR	             Identificador único,
Coluna RoleName	       VARCHAR               Nome da empresa.
=================================================================================================================
*/
CREATE TABLE [dbo].[tb_UserRoles] (
    UserId   VARCHAR (450) NOT NULL,
    RoleName VARCHAR(50) NOT NULL,
    PRIMARY KEY (UserId, RoleName),
    FOREIGN KEY (UserId) REFERENCES [dbo].[tb_Users](Id)
);