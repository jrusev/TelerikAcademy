DECLARE @Length int = RAND() * 5 + 8 -- min_length = 8, max_length = 12
DECLARE @CharPool varchar(100) = 
    'abcdefghijkmnopqrstuvwxyzABCDEFGHIJKLMNPQRSTUVWXYZ23456789.,-_!$@#%^&*'
DECLARE @PoolLength int = Len(@CharPool)
DECLARE @CharCount int = 0
DECLARE @RandStr varchar(100) = ''

WHILE (@CharCount < @Length) BEGIN
    SET @RandStr = @RandStr + SUBSTRING(@Charpool, CONVERT(int, RAND() * @PoolLength), 1)
    SELECT @CharCount = @CharCount + 1
END
PRINT @RandStr
GO