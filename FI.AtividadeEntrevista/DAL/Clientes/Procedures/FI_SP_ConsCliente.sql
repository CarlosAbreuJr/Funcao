﻿IF (OBJECT_ID('dbo.FI_SP_ConsCliente') IS NOT NULL) DROP PROCEDURE dbo.FI_SP_ConsCliente
GO
CREATE PROC FI_SP_ConsCliente
	@ID BIGINT
AS
BEGIN
	IF(ISNULL(@ID,0) = 0)
		SELECT NOME, SOBRENOME, NACIONALIDADE, CEP, ESTADO, CIDADE, LOGRADOURO, EMAIL, TELEFONE, ID, CPF FROM CLIENTES WITH(NOLOCK)
	ELSE
		SELECT NOME, SOBRENOME, NACIONALIDADE, CEP, ESTADO, CIDADE, LOGRADOURO, EMAIL, TELEFONE, ID, CPF FROM CLIENTES WITH(NOLOCK) WHERE ID = @ID
END