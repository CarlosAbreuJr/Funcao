﻿IF (OBJECT_ID('dbo.FI_SP_IncCliente') IS NOT NULL) 
   DROP PROCEDURE dbo.FI_SP_IncCliente
Print 'Não encontrei uso para esta procedure'
GO
CREATE PROC FI_SP_IncCliente
	@CPF           CHAR (11),
    @NOME          VARCHAR (50) ,
    @SOBRENOME     VARCHAR (255),
    @NACIONALIDADE VARCHAR (50) ,
    @CEP           VARCHAR (9)  ,
    @ESTADO        VARCHAR (2)  ,
    @CIDADE        VARCHAR (50) ,
    @LOGRADOURO    VARCHAR (500),
    @EMAIL         VARCHAR (2079)
AS
BEGIN
	INSERT INTO CLIENTES (CPF) VALUES (@CPF)
END