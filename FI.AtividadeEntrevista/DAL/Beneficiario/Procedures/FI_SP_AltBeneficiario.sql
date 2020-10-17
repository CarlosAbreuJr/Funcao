IF (OBJECT_ID('dbo.FI_SP_AltBeneficiario') IS NOT NULL) DROP PROCEDURE dbo.FI_SP_AltBeneficiario
GO
CREATE PROC FI_SP_AltBeneficiario
@NOME          VARCHAR (50) ,
@Id           BIGINT,
@CPF		   VARCHAR (15)--,
--@IDCLIENTE           BIGINT

AS
BEGIN
	UPDATE BENEFICIARIOS 
	SET 
		NOME = @NOME, 
		CPF = @CPF--,
		--IDCLIENTE = @IDCLIENTE
	WHERE Id = @Id
END
