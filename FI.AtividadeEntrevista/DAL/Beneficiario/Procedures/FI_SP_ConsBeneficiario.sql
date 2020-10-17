﻿IF (OBJECT_ID('dbo.FI_SP_ConsBeneficiario') IS NOT NULL) DROP PROCEDURE dbo.FI_SP_ConsBeneficiario
GO
CREATE PROC FI_SP_ConsBeneficiario
	@ID BIGINT
AS
BEGIN
	IF(ISNULL(@ID,0) = 0)
		SELECT ID, IDCLIENTE, NOME, CPF FROM BENEFICIARIOS WITH(NOLOCK)
	ELSE
		SELECT  ID, IDCLIENTE, NOME, CPF FROM BENEFICIARIOS WITH(NOLOCK) WHERE ID = @ID
END