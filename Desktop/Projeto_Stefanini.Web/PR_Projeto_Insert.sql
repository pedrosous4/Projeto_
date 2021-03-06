alter PROCEDURE PR_Projeto_Insert
									@TABELA VARCHAR(100),
									@PASTA VARCHAR(255),
									@CHECKHIST BIT=1,
									@GETCOMAND BIT=0
AS
--========================================================================================================*/
SET NOCOUNT ON
----------------------------------------------------------------------------------------------------------
DECLARE @LISTA TABLE(ID INT IDENTITY(1,1), ARQUIVO VARCHAR(500))

DECLARE		@ARQUIVO VARCHAR(255),
			@COMANDO VARCHAR(255),
			@COUNT INT = 0,
			@FIELDTERMINATOR VARCHAR(5)= ',',
			@ROWTERMINATOR VARCHAR(5)= ';',
			@FORMATO VARCHAR(100) = '.TXT'

SET @PASTA = CASE	WHEN RIGHT(@PASTA,1) <> '\' 
					THEN @PASTA
					ELSE @PASTA END
--========================================================================================================
INSERT INTO @LISTA
SELECT @PASTA

IF @CHECKHIST=1
	DELETE A
	FROM @LISTA A
	WHERE ARQUIVO IS NULL
		OR CHARINDEX(RIGHT(ARQUIVO,4),@FORMATO) < 1

--========================================================================================================

WHILE @COUNT <= (SELECT MAX(ID) FROM @LISTA)
BEGIN
	SET @ARQUIVO = NULL
	
	SELECT @ARQUIVO=@PASTA
	FROM @LISTA
	WHERE ID = @COUNT

	select @ARQUIVO arquivo1 -------------

	IF @ARQUIVO IS NOT NULL
	BEGIN 
	TRY
		SET @COMANDO = ''

		SET @COMANDO = 'BULK INSERT '+@TABELA+'
						FROM '''+ @ARQUIVO +''' 
						WITH (	FIELDTERMINATOR = ''' + @FIELDTERMINATOR + ''', 
								ROWTERMINATOR = '''+ @ROWTERMINATOR +''')'
END


TRY
	BEGIN CATCH
		SELECT -1 RETORNO -- ERRO
	END CATCH
	SET @COUNT = @COUNT+1
END

IF (SELECT COUNT(*) FROM @LISTA) <= 0
	BEGIN
		SELECT 0 RETORNO -- VAZIO
	END
ELSE
	BEGIN
		SELECT 1 RETORNO -- OK
END
--========================================================================================================