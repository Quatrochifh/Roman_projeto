USE SENAI_ROMAN;
GO
---------------SQL---------------
---------------DML---------------

INSERT INTO TIPO_USUARIO (TIPO)
VALUES		('Professor'),('Administrador');
GO--

SELECT * FROM TIPO_USUARIO;
GO

SELECT * FROM TEMAS;
GO

SELECT * FROM USUARIOS;
GO

SELECT * FROM PROJETOS;
GO

INSERT INTO TEMAS (TEMAS)
VALUES ('Exerc�cios c#'),('Exerc�cios JavaScript'),('Exerc�cios Php'),('Exerc�cios Python');
GO--

INSERT INTO USUARIOS (ID_TIPOUSUARIO, NOME_USU, EMAIL, SENHA)
VALUES (1, 'Lucas Arag�o', 'lucas@gmail.com', 'LucasGamer123')
GO

INSERT INTO USUARIOS (ID_TIPOUSUARIO, NOME_USU, EMAIL, SENHA)
VALUES (2, 'ADM', 'adm@adm.com', 'adms123')
GO


INSERT INTO PROJETOS (ID_TEMA, ID_USUARIO, NOME_PRO, DESCRICAO_PRO)
VALUES (1, 1, 'Projeto Elevador', 'Projeto com inten��o de fazer a programa��o de um elevador')
GO