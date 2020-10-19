--FI_SP_PesqBeneficiario 24,1,20,'Nome',1
            
IF (OBJECT_ID('dbo.FI_SP_PesqBeneficiario') IS NOT NULL) DROP PROCEDURE dbo.FI_SP_PesqBeneficiario
GO
CREATE PROC FI_SP_PesqBeneficiario
    @IDCLIENTE bigint,
	@iniciarEm int,
	@quantidade int,
	@campoOrdenacao varchar(200),
	@crescente bit	
AS
BEGIN
	DECLARE @SCRIPT NVARCHAR(MAX)
	DECLARE @CAMPOS NVARCHAR(MAX)
	DECLARE @ORDER VARCHAR(50)
	
	IF(@campoOrdenacao = 'CPF')
		SET @ORDER =  ' CPF '
	ELSE
		SET @ORDER = ' NOME '

	IF(@crescente = 0)
		SET @ORDER = @ORDER + ' DESC'
	ELSE
		SET @ORDER = @ORDER + ' ASC'

	SET @CAMPOS = '@iniciarEm int,@quantidade int, @IdDoCliente bigint'
	SET @SCRIPT = 
	'SELECT ID, NOME, CPF, IDCLIENTE FROM
		(SELECT ROW_NUMBER() OVER (ORDER BY ' + @ORDER + ') AS Row, ID, NOME, CPF, IDCLIENTE FROM BENEFICIARIOS WITH(NOLOCK))
	AS BeneficiariosWithRowNumbers
	WHERE Row > @iniciarEm AND Row <= (@iniciarEm+@quantidade) and IDCLIENTE=@IdDoCliente ORDER BY'
	
	SET @SCRIPT = @SCRIPT + @ORDER
			
	EXECUTE SP_EXECUTESQL @SCRIPT, @CAMPOS,  @IDCLIENTE, @iniciarEm, @quantidade

	SELECT COUNT(1) FROM BENEFICIARIOS WITH(NOLOCK) WHERE IDCLIENTE=@IDCLIENTE
END