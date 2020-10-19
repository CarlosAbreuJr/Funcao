IF (OBJECT_ID('dbo.FI_SP_AltBeneficiario') IS NOT NULL) DROP PROCEDURE dbo.FI_SP_AltBeneficiario
GO
CREATE PROC FI_SP_AltBeneficiario
@NOME          VARCHAR (50) ,
@Id           BIGINT,
@CPF		   char (11)
AS
BEGIN
	UPDATE BENEFICIARIOS 
	SET 
		NOME = @NOME, 
		CPF = @CPF
	WHERE Id = @Id
END
